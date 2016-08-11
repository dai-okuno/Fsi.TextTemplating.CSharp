using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NullableTypeName
        : CachedTypeName
    {
        public NullableTypeName(Type type, ITypeName underlyingTypeName)
            : base(type)
        {
            UnderlyingTypeName = underlyingTypeName;
        }

        private ITypeName UnderlyingTypeName { get; }

        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append("System.Nullable<");
            UnderlyingTypeName.AppendAliasNameTo(typeName, context);
            typeName.Append('>');
        }

        protected override void AppendCRefNameToCore(StringBuilder typename, IFormatterContext context)
        {
            context.GetNamespaceName("System").AppendNameTo(typename, context);
            typename.Append("Nullable{");
            UnderlyingTypeName.AppendCRefNameTo(typename, context);
            typename.Append('}');
        }
        protected override void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            UnderlyingTypeName.AppendFullNameTo(typeName, context);
            typeName.Append('?');
        }
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            UnderlyingTypeName.AppendNameTo(typeName, context);
            typeName.Append('?');
        }
    }
}
