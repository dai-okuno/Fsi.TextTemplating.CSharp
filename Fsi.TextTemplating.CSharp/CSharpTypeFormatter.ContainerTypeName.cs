using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class ContainerTypeName
            : ISimplify
        {
            public ContainerTypeName(TypeName typeName)
            {
                TypeName = typeName;
            }

            private TypeName TypeName { get; }

            public int AppendCommentNameTo(StringBuilder builder, FormatterContext context)
            {
                var start = builder.Length;
                TypeName.AppendCommentNameTo(builder, context);
                return builder.Length - start;
            }

            public int AppendFullNameTo(StringBuilder builder, FormatterContext context)
            {
                var start = builder.Length;
                TypeName.AppendFullNameTo(builder, context);
                return builder.Length - start;
            }

            public int AppendNameTo(StringBuilder builder, FormatterContext context)
            {
                var start = builder.Length;
                TypeName.AppendNameTo(builder, context);
                return builder.Length - start;
            }
        }
    }
}
