using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class ParameterizedTypeName
            : CachedTypeName
    {
        public ParameterizedTypeName(Type type, INamespaceName namespaceName, ITypeName[] argNames)
            : base(type)
        {
            Parent = namespaceName;
            CoreName = GetCoreName(type);
            GenericTypeArgumentNames = argNames;
        }

        public ParameterizedTypeName(Type type, ITypeName declaringTypeName, ITypeName[] argNames)
            : base(type)
        {
            Parent = declaringTypeName;
            CoreName = GetCoreName(type);
            GenericTypeArgumentNames = argNames;
        }

        private ITypeNameContainer Parent { get; }

        private string CoreName { get; }
        private ITypeName[] GenericTypeArgumentNames { get; }
        private string GetCoreName(Type type)
        {
            if(type.IsNested)
            {
                var start = type.Name.LastIndexOf('+') + 1;
                var end = type.Name.LastIndexOf('`');
                return type.Name.Substring(start, end - start);
            }
            else
            {
                return type.Name.Remove(type.Name.IndexOf('`'));
            }
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
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

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            Parent.AppendFullNameTo(typeName, context);
            typeName.Append('.');
            typeName.Append(CoreName);
            typeName.Append('<');
            var args = GenericTypeArgumentNames;
            args[0].AppendFullNameTo(typeName, context);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                args[i].AppendFullNameTo(typeName, context);
            }
            typeName.Append('>');
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
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
    }
}
