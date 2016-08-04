using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class NonGenericTypeName
            : TypeNameBase
        {
            public NonGenericTypeName(Type type)
                : this(default(ISimplify), type)
            {

            }
            public NonGenericTypeName(TypeName declaringTypeName, Type type)
                : this(new ContainerTypeName(declaringTypeName), type)
            {

            }

            private NonGenericTypeName(ISimplify simplify, Type type)
                : base(type)
            {
                Simplify = simplify;
            }

            private ISimplify Simplify { get; }


            protected override void AppendCommentNameToCore(StringBuilder builder, FormatterContext context)
            {
                if (0 < Simplify.AppendCommentNameTo(builder, context))
                { builder.Append('.'); }
                builder.Append(Type.Name);
            }

            protected override void AppendFullNameToCore(StringBuilder builder, FormatterContext context)
            {
                if (0 < Simplify.AppendFullNameTo(builder, context))
                { builder.Append('.'); }
                builder.Append(Type.Name);
            }

            protected override void AppendNameToCore(StringBuilder builder, FormatterContext context)
            {
                if (0 < Simplify.AppendNameTo(builder, context))
                { builder.Append('.'); }
                builder.Append(Type.Name);
            }
        }
    }
}
