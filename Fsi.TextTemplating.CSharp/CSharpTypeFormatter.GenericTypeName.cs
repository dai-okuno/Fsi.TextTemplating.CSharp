using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class GenericTypeName
            : TypeNameBase
        {
            public GenericTypeName(Type type, TypeName[] argNames)
                : this(default(ISimplify), type, argNames)
            { }

            public GenericTypeName(TypeName declaringTypeName, Type type, TypeName[] argNames)
                : this(new ContainerTypeName(declaringTypeName), type, argNames)
            { }

            private GenericTypeName(ISimplify simplify, Type type, TypeName[] argNames)
                : base(type)
            {
                Simplify = simplify;
                GenericTypeArgumentNames = argNames;
            }

            private ISimplify Simplify { get; }

            private string CoreName { get; }

            private TypeName[] GenericTypeArgumentNames { get; }


            protected override void AppendCRefToCore(StringBuilder builder, FormatterContext context)
            {
                if (0 < Simplify.AppendCommentNameTo(builder, context))
                { builder.Append('.'); }
                builder.Append(CoreName);
                builder.Append('{');
                GenericTypeArgumentNames[0].AppendCRefTo(builder, context);
                for (int i = 1; i < GenericTypeArgumentNames.Length; i++)
                {
                    builder.Append(", ");
                    GenericTypeArgumentNames[i].AppendCRefTo(builder, context);
                }
                builder.Append('}');
            }

            protected override void AppendFullNameToCore(StringBuilder builder, FormatterContext context)
            {
                if (0 < Simplify.AppendFullNameTo(builder, context))
                { builder.Append('.'); }
                builder.Append(CoreName);
                builder.Append('<');
                GenericTypeArgumentNames[0].AppendFullNameTo(builder, context);
                for (int i = 1; i < GenericTypeArgumentNames.Length; i++)
                {
                    builder.Append(", ");
                    GenericTypeArgumentNames[i].AppendFullNameTo(builder, context);
                }
                builder.Append('>');
            }

            protected override void AppendNameToCore(StringBuilder builder, FormatterContext context)
            {
                if (0 < Simplify.AppendNameTo(builder, context))
                { builder.Append('.'); }
                builder.Append(CoreName);
                builder.Append('<');
                GenericTypeArgumentNames[0].AppendNameTo(builder, context);
                for (int i = 1; i < GenericTypeArgumentNames.Length; i++)
                {
                    builder.Append(", ");
                    GenericTypeArgumentNames[i].AppendNameTo(builder, context);
                }
                builder.Append('>');
            }


        }
    }
}
