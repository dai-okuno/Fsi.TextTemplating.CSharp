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
            => type.Name.Remove(type.Name.IndexOf('`'));

        protected override void AppendNameToCore(Helper helper, StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            helper.AppendContainerNameTo(Parent, typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(CoreName);
            typeName.Append(helper.OpenBracket);
            var args = GenericTypeArgumentNames;
            helper.AppendTypeNameTo(args[0], typeName, context);
            for (int i = 1; i < args.Length; i++)
            {
                typeName.Append(", ");
                helper.AppendTypeNameTo(args[i], typeName, context);
            }
            typeName.Append(helper.CloseBracket);
        }
    }
}
