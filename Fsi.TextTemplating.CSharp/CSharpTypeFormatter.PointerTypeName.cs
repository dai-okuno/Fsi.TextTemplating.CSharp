using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class PointerTypeName
            : TypeNameBase
        {
            public PointerTypeName(Type type, TypeName elementTypeName)
                : base(type)
            {
                ElementTypeName = elementTypeName;
            }

            private TypeName ElementTypeName { get; }

            protected override void AppendCRefToCore(StringBuilder builder, FormatterContext context)
            {
                ElementTypeName.AppendCRefTo(builder, context);
                builder.Append('*');
            }

            protected override void AppendFullNameToCore(StringBuilder builder, FormatterContext context)
            {
                ElementTypeName.AppendFullNameTo(builder, context);
                builder.Append('*');
            }

            protected override void AppendNameToCore(StringBuilder builder, FormatterContext formatter)
            {
                ElementTypeName.AppendNameTo(builder, formatter);
                builder.Append('*');
            }

        }
    }
}
