using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Fsi.TextTemplating.TypeNames
{

    internal class SourceFileFormatterContext
        : IFormatterContext
    {
        public SourceFileFormatterContext()
        {
            ImportedNamespaceNames = new HashSet<INamespaceName>();
            NamespaceName = new GlobalNamespaceName();
            NamespaceNames = new NamespaceNameCollection();
        }
        private HashSet<INamespaceName> ImportedNamespaceNames { get; }
        IEnumerable<INamespaceName> IFormatterContext.ImportedNamespaceNames
            => ImportedNamespaceNames;

        public GlobalNamespaceName NamespaceName { get; }
        INamespaceName IFormatterContext.NamespaceName
            => NamespaceName;
        public SourceFileFormatterContext Root
            => this;
        IFormatterContext IFormatterContext.Parent
            => null;
        private NamespaceNameCollection NamespaceNames { get; }
        private TypeNameCollection TypeNames { get; } = new TypeNameCollection()
            {
                PrimitiveTypeName.@string,
                PrimitiveTypeName.@void,
                PrimitiveTypeName.@bool,
                PrimitiveTypeName.@byte,
                PrimitiveTypeName.@short,
                PrimitiveTypeName.@int,
                PrimitiveTypeName.@long,
                PrimitiveTypeName.@sbyte,
                PrimitiveTypeName.@ushort,
                PrimitiveTypeName.@uint,
                PrimitiveTypeName.@ulong,
                PrimitiveTypeName.@decimal,
                PrimitiveTypeName.@float,
                PrimitiveTypeName.@double,
                PrimitiveTypeName.@char,
                PrimitiveTypeName.@object,
            };
        public INamespaceName GetNamespaceName(string namespaceName)
        {
            INamespaceName value;
            if (NamespaceNames.TryGetValue(namespaceName, out value))
            {
                return value;
            }
            var i = namespaceName.LastIndexOf('.');
            if (i < 0)
            {
                value = new NamespaceName(NamespaceName, namespaceName);
            }
            else
            {
                var parent = GetNamespaceName(namespaceName.Remove(i));
                value = new NamespaceName(parent, namespaceName);
            }
            NamespaceNames.Add(value);
            return value;
        }
        public ITypeName GetTypeName(Type type)
        {
            ITypeName value;
            if (!TypeNames.TryGetValue(type, out value))
            {
                if (type.HasElementType)
                {
                    if (type.IsArray)
                    {
                        value = ArrayTypeName.Create(type, this);
                    }
                    else if (type.IsPointer)
                    {
                        value = new PointerTypeName(type, GetTypeName(type.GetElementType()));
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
                    Type[] args;
                    if (type.IsConstructedGenericType)
                    {
                        args = type.GenericTypeArguments;
                    }
                    else
                    {
                        var typeInfo = type.GetTypeInfo();
                        if (typeInfo.IsGenericTypeDefinition)
                        {
                            args = typeInfo.GenericTypeParameters;
                        }
                        else
                        {
                            args = Type.EmptyTypes;
                        }
                    }
                    if (0 < args.Length)
                    {
                        var declaringArgCount = 0;
                        var declaring = type.DeclaringType.GetTypeInfo();
                        if (declaring.IsGenericTypeDefinition)
                        {
                            declaringArgCount = declaring.GenericTypeParameters.Length;
                        }
                        if (declaringArgCount == args.Length)
                        {
                            value = new NonParameterizedTypeName(type, GetTypeName(type.DeclaringType.MakeGenericType(args)));
                        }
                        else if (0 < declaringArgCount)
                        {
                            var declaringArgs = new Type[declaringArgCount];
                            Array.Copy(args, declaringArgs, declaringArgs.Length);
                            value = new ParameterizedTypeName(type, GetTypeName(type.DeclaringType.MakeGenericType(declaringArgs)), GetTypeNames(args, declaringArgCount));
                        }
                        else
                        {
                            value = new ParameterizedTypeName(type, GetTypeName(type.DeclaringType), GetTypeNames(args, 0));
                        }
                    }
                    else
                    {
                        value = new NonParameterizedTypeName(type, GetTypeName(type.DeclaringType));
                    }
                }
                else
                {
                    var typeInfo = type.GetTypeInfo();
                    var args = typeInfo.GenericTypeArguments;
                    if (0 < args.Length)
                    {
                        var underlying = Nullable.GetUnderlyingType(type);
                        if (underlying != null)
                        {
                            value = new NullableTypeName(type, GetTypeName(underlying));
                        }
                        else
                        {
                            value = new ParameterizedTypeName(type, GetNamespaceName(type.Namespace), GetTypeNames(args, 0));
                        }
                    }
                    else if (0 < (args = typeInfo.GenericTypeParameters).Length)
                    {
                        value = new ParameterizedTypeName(type, GetNamespaceName(type.Namespace), GetTypeNames(args, 0));
                    }
                    else
                    {
                        value = new NonParameterizedTypeName(type, GetNamespaceName(type.Namespace));
                    }
                }
                TypeNames.Add(value);
            }
            return value;
        }
        public INamespaceName Import(string namespaceName)
        {
            var value = GetNamespaceName(namespaceName);
            ImportedNamespaceNames.Add(value);
            return value;
        }
        private ITypeName[] GetTypeNames(Type[] types, int offset)
        {
            var result = new ITypeName[types.Length - offset];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GetTypeName(types[i + offset]);
            }
            return result;
        }

    }
}
