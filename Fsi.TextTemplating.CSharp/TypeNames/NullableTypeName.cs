using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
internal class NullableTypeName
        : TypeNameBase
    {
        public NullableTypeName(Type type, TypeName underlyingTypeName) : base(type)
        {
            UnderlyingTypeName = underlyingTypeName;
        }
        private TypeName UnderlyingTypeName { get; }
        protected override void AppendCRefToCore(StringBuilder builder, FormatterContext context)
        {
            builder.Append("global::System.Nullable{");
            UnderlyingTypeName.AppendCRefTo(builder, context);
            builder.Append('}');
        }
        protected override void AppendFullNameToCore(StringBuilder builder, FormatterContext context)
        {
            UnderlyingTypeName.AppendFullNameTo(builder, context);
            builder.Append('?');
        }
        protected override void AppendNameToCore(StringBuilder builder, FormatterContext context)
        {
            UnderlyingTypeName.AppendNameTo(builder, context);
            builder.Append('?');
        }
    }
}
