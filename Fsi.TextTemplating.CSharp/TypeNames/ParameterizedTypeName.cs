using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class ParameterizedTypeName
            : CachedTypeName
    {
        public ParameterizedTypeName(FlyweightFactory factory, Type type)
        {
            Parent = factory.GetNamespaceName(type.Namespace);
            CoreName = GetCoreName(type.Name);

            GenericTypeArgumentNames = factory.GetTypeNames(type.GenericTypeArguments);

            TypeFullName = type.FullName;
        }

        public ParameterizedTypeName(FlyweightFactory factory, TypeInfo typeInfo)
        {
            Parent = factory.GetNamespaceName(typeInfo.Namespace);
            CoreName = GetCoreName(typeInfo.Name);

            GenericTypeArgumentNames = factory.GetTypeNames(typeInfo.GenericTypeParameters);

            TypeFullName = typeInfo.FullName;
        }
        public ParameterizedTypeName(FlyweightFactory factory, TypeName parentTypeName, Type type)
        {
            Parent = parentTypeName;
            CoreName = GetCoreName(type.Name);

            var parameterized = parentTypeName as ParameterizedTypeName;
            if (parameterized != null)
            {
                GenericTypeArgumentNames = factory.GetTypeNames(type.GenericTypeArguments, parameterized.GenericTypeArgumentNames.Length);
            }
            else
            {
                GenericTypeArgumentNames = factory.GetTypeNames(type.GenericTypeArguments);
            }

            TypeFullName = type.FullName;
        }
        public ParameterizedTypeName(FlyweightFactory factory, TypeName parentTypeName, TypeInfo typeInfo)
        {
            Parent = parentTypeName;
            CoreName = GetCoreName(typeInfo.Name);

            var parameterized = parentTypeName as ParameterizedTypeName;
            if (parameterized != null)
            {
                GenericTypeArgumentNames = factory.GetTypeNames(typeInfo.GenericTypeParameters, parameterized.GenericTypeArgumentNames.Length);
            }
            else
            {
                GenericTypeArgumentNames = factory.GetTypeNames(typeInfo.GenericTypeParameters);
            }

            TypeFullName = typeInfo.FullName;
        }
        private ITypeNameContainer Parent { get; }

        private string CoreName { get; }
        private TypeName[] GenericTypeArgumentNames { get; }
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendAliasNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(CoreName);
            typeName.Append('<');
            var args = GenericTypeArgumentNames;
            args[0].AppendAliasNameTo(typeName, context);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                args[i].AppendAliasNameTo(typeName, context);
            }
            typeName.Append('>');
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendCRefNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(CoreName);
            typeName.Append('{');
            var args = GenericTypeArgumentNames;
            args[0].AppendCRefNameTo(typeName, context);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                args[i].AppendCRefNameTo(typeName, context);
            }
            typeName.Append('}');
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        protected override void AppendFullNameToCore(StringBuilder typeName)
        {
            Parent.AppendFullNameTo(typeName);
            typeName.Append('.');
            typeName.Append(CoreName);
            typeName.Append('<');
            var args = GenericTypeArgumentNames;
            args[0].AppendFullNameTo(typeName);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                args[i].AppendFullNameTo(typeName);
            }
            typeName.Append('>');
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(CoreName);
            typeName.Append('<');
            var args = GenericTypeArgumentNames;
            args[0].AppendNameTo(typeName, context);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                args[i].AppendNameTo(typeName, context);
            }
            typeName.Append('>');
        }
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendTypeOfNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendTypeOfNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(CoreName);
            typeName.Append('{');
            var args = GenericTypeArgumentNames;
            args[0].AppendTypeOfNameTo(typeName, context);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                args[i].AppendTypeOfNameTo(typeName, context);
            }
            typeName.Append('}');
        }

        private string GetCoreName(string typeName)
            => typeName.Remove(typeName.IndexOf('`'));

    }
}
