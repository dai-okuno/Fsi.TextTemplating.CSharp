using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class GenericParameterTypeName
            : TypeName
        {
            public GenericParameterTypeName(Type type)
            {
                Type = type;
            }
            public override Type Type { get; }

            public override void AppendCommentNameTo(StringBuilder builder, FormatterContext context)
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
            public override string GetCommentName(FormatterContext context)
                => Type.Name;

            public override string GetFullName(FormatterContext context)
                => Type.Name;

            public override string GetName(FormatterContext context)
                => Type.Name;
        }
    }
}
