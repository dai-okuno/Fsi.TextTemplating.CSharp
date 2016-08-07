using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Fsi.TextTemplating.TypeNames
{

    internal class RootFormatterContext
            : FormatterContext
    {

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

        public override NamespaceName GetNamespaceName(string namespaceName)
            => new NamespaceName(namespaceName);

        public override TypeName GetTypeName(Type type)
        {
            TypeName value;
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
                    var args = type.GenericTypeArguments;
                    if (0 < args.Length)
                    {
                        var container = type.DeclaringType.GetTypeInfo();
                        var containerParams = container.GenericTypeParameters;
                        if (containerParams.Length < args.Length)
                        {
                            var containerArgs = new Type[containerParams.Length];
                            Array.Copy(args, containerArgs, containerArgs.Length);
                            value = new ParameterizedTypeName(type, GetTypeName(container.MakeGenericType(containerArgs)), GetTypeNames(args, containerArgs.Length));
                        }
                        else
                        {
                            value = new NonParameterizedTypeName(type, GetTypeName(type.DeclaringType.MakeGenericType(args)));
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

        private TypeName[] GetTypeNames(Type[] types, int offset)
        {
            var result = new TypeName[types.Length];
            for (int i = offset; i < types.Length; i++)
            {
                result[i] = GetTypeName(types[i]);
            }
            return result;
        }

    }
}
