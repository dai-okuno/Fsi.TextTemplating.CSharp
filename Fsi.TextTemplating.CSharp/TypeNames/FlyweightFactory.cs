using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Fsi.TextTemplating.TypeNames
{

    internal class FlyweightFactory
    {
        public FlyweightFactory()
        {
            GlobalNamespaceName = new GlobalNamespaceName(this);
            _NamespaceNames = new NamespaceNameCollection[NamespaceNamesSize];
            _NamespaceNamesMask = _NamespaceNames.Length - 1;
            _TypeNames = new TypeNameCollection[TypeNamesSize];
            foreach (var primitive in PrimitiveTypeName.GetValues(this))
            {
                Add(primitive);
            }
        }

        private const int DefaultTableSize = 256;
        private static readonly int[] _TableSizes = new[] {
            0x00000001, 0x00000002, 0x00000004, 0x00000008,
            0x00000010, 0x00000020, 0x00000040, 0x00000080,
            0x00000100, 0x00000200, 0x00000400, 0x00000800,
            0x00001000, 0x00002000, 0x00004000, 0x00008000,
            0x00010000, 0x00020000, 0x00040000, 0x00080000,
            0x00100000, 0x00200000, 0x00400000, 0x00800000,
            0x01000000, 0x02000000, 0x04000000, 0x08000000,
            0x10000000, 0x20000000, 0x40000000, };


        private const int TypeNamesSize = 256;
        private const int TypeNamesMask = TypeNamesSize - 1;

        private const int NamespaceNamesSize = 256;
        private const int NamespaceNamesMask = NamespaceNamesSize - 1;

        private TypeNameCollection[] _TypeNames;

        private NamespaceNameCollection[] _NamespaceNames;
        private readonly int _NamespaceNamesMask;
        public GlobalNamespaceName GlobalNamespaceName { get; }
        /// <summary>Gets <see cref="INamespaceName"/> for specified name.</summary>
        /// <param name="fullName">Full name of namespace.</param>
        /// <returns><see cref="INamespaceName"/>.</returns>
        public INamespaceName GetNamespaceName(string fullName)
        {
            INamespaceName value;
            if (TryGet(fullName, out value))
            {
                return value;
            }
            var i = fullName.LastIndexOf('.');
            if (i < 0)
            {
                value = new NamespaceName(GlobalNamespaceName, fullName);
            }
            else
            {
                var parent = GetNamespaceName(fullName.Remove(i));
                value = new NamespaceName(parent, fullName);
            }
            Add(value);
            return value;
        }

        /// <summary>Gets <see cref="TypeName"/> for a specified <see cref="Type"/>.</summary>
        /// <param name="type"></param>
        /// <returns><see cref="TypeName"/></returns>
        public TypeName GetTypeName(Type type)
        {
            TypeName value;
            if (!TryGet(type, out value))
            {
                value = GetTypeNameCore(type);
                Add(value);
            }
            return value;
        }

        internal TypeName[] GetTypeNames(Type[] types)
        {
            var typeNames = new TypeName[types.Length];
            for (int i = 0; i < typeNames.Length; i++)
            {
                typeNames[i] = GetTypeName(types[i]);
            }
            return typeNames;
        }

        internal TypeName[] GetTypeNames(Type[] types, int offset)
        {
            var typeNames = new TypeName[types.Length - offset];
            for (int i = 0; i < typeNames.Length; i++)
            {
                typeNames[i] = GetTypeName(types[offset + i]);
            }
            return typeNames;
        }

        private TypeName GetTypeNameCore(Type type)
        {
            TypeName value;
            if (type.HasElementType)
            {
                if (type.IsArray)
                {
                    value = new ArrayTypeName(this, type);
                }
                else if (type.IsPointer)
                {
                    value = new PointerTypeName(this, type);
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            else if (type.IsGenericParameter)
            {
                value = new GenericParameterTypeName(type);
            }
            else if (type.IsNested)
            {
                var typeInfo = type.GetTypeInfo();
                if (typeInfo.IsGenericTypeDefinition)
                {
                    var declaringInfo = type.DeclaringType.GetTypeInfo();
                    if (declaringInfo.IsGenericType)
                    {
                        var typeParams = typeInfo.GenericTypeParameters;
                        var declaringTypeParams = declaringInfo.GenericTypeParameters;
                        if (declaringTypeParams.Length < typeParams.Length)
                        {   // Declaring<T>.Nested<U>
                            value = new ParameterizedTypeName(this, GetTypeName(type.DeclaringType), typeInfo);
                        }
                        else
                        {   // Declaring<T>.Nested
                            value = new NonParameterizedTypeName(this, GetTypeName(type.DeclaringType), type);
                        }
                    }
                    else
                    {   // Declaring.Nested<U>
                        value = new ParameterizedTypeName(this, GetTypeName(type.DeclaringType), typeInfo);
                    }
                }
                else if (typeInfo.IsGenericType)
                {
                    var declaringInfo = type.DeclaringType.GetTypeInfo();
                    if (declaringInfo.IsGenericType)
                    {
                        var typeArgs = type.GenericTypeArguments;
                        var declaringTypeArgs = declaringInfo.GenericTypeParameters;
                        if (declaringTypeArgs.Length < typeArgs.Length)
                        {   // Declaring<Constructed>.Nested<Constructed>
                            Array.Copy(typeArgs, declaringTypeArgs, declaringTypeArgs.Length);
                            var parent = declaringInfo.MakeGenericType(declaringTypeArgs);
                            value = new ParameterizedTypeName(this, GetTypeName(parent), type);
                        }
                        else
                        {   // Declaring<Constructed>.Nested
                            var parent = declaringInfo.MakeGenericType(typeArgs);
                            value = new NonParameterizedTypeName(this, GetTypeName(parent), type);
                        }
                    }
                    else
                    {   // Declaring.Nested<Constructed>
                        value = new ParameterizedTypeName(this, GetTypeName(type.DeclaringType), type);
                    }
                }
                else
                {   // Declaring.Nested
                    value = new NonParameterizedTypeName(this, GetTypeName(type.DeclaringType), type);
                }
            }
            else
            {
                var typeInfo = type.GetTypeInfo();
                if (typeInfo.IsGenericTypeDefinition)
                {   // Generic<T>
                    value = new ParameterizedTypeName(this, typeInfo);
                }
                else if (typeInfo.IsGenericType)
                {
                    var underlying = Nullable.GetUnderlyingType(type);
                    if (underlying != null)
                    {   // Struct?
                        value = new NullableTypeName(this, type);
                    }
                    else
                    {   // Generic<constructed>
                        value = new ParameterizedTypeName(this, type);
                    }
                }
                else
                {   // NonGeneric
                    value = new NonParameterizedTypeName(this, type);
                }
            }

            return value;
        }

        private void Add(INamespaceName item)
        {
            var position = item.FullName.GetHashCode() & NamespaceNamesMask;
            var nodes = _NamespaceNames[position];
            if (nodes == null)
            {
                _NamespaceNames[position] = nodes = new NamespaceNameCollection();
            }
            nodes.Add(item);
        }

        private void Add(TypeName item)
        {
            var position = item.TypeFullName.GetHashCode() & TypeNamesMask;
            var nodes = _TypeNames[position];
            if (nodes == null)
            {
                _TypeNames[position] = nodes = new TypeNameCollection();
            }
            nodes.Add(item);
        }

        private bool TryGet(string key, out INamespaceName item)
        {
            var position = key.GetHashCode() & NamespaceNamesMask;
            var nodes = _NamespaceNames[position];
            if (nodes != null)
            {
                return nodes.TryGet(key, out item);
            }
            else
            {
                item = default(INamespaceName);
                return false;
            }
        }
        private bool TryGet(Type key, out TypeName item)
        {
            var position = (key.IsGenericParameter ? key.Name : key.FullName).GetHashCode() & TypeNamesMask;
            var nodes = _TypeNames[position];
            if (nodes != null)
            {
                return nodes.TryGet(key, out item);
            }
            else
            {
                item = default(TypeName);
                return false;
            }
        }
    }
}
