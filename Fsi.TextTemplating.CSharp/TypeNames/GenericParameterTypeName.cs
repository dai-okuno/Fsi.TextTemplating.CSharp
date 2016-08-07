using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
internal class GenericParameterTypeName
            : TypeName
    {
        public GenericParameterTypeName(Type type)
        {
            Type = type;
        }
        public override Type Type { get; }

        public override void AppendCRefTo(StringBuilder builder, FormatterContext context)
        {
            builder.Append(Type.Name);
        }

        public override void AppendFullNameTo(StringBuilder builder, FormatterContext context)
        {
            builder.Append(Type.Name);
        }

        public override void AppendNameTo(StringBuilder builder, FormatterContext context)
        {
            builder.Append(Type.Name);
        }
        public override string GetCRef(FormatterContext context)
            => Type.Name;

        public override string GetFullName(FormatterContext context)
            => Type.Name;

        public override string GetName(FormatterContext context)
            => Type.Name;
    }
}
