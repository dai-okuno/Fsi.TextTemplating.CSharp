using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private abstract class TypeNameBase
            : TypeName
        {
            public TypeNameBase(Type type)
            {
                Type = type;
            }

            public sealed override Type Type { get; }

            private string FullName { get; set; }

            private ContextName CRef { get; set; }
            private ContextName Name { get; set; }


            public sealed override void AppendCRefTo(StringBuilder builder, FormatterContext context)
            {
                if (CRef == null || CRef.Context != context)
                {
                    var start = builder.Length;
                    AppendCRefToCore(builder, context);
                    CRef = new ContextName(context, builder.ToString(start, builder.Length - start));
                }
                else
                {
                    builder.Append(CRef.Name);
                }
            }

            public sealed override void AppendFullNameTo(StringBuilder builder, FormatterContext context)
            {
                if (FullName == null)
                {
                    var start = builder.Length;
                    AppendFullNameToCore(builder, context);
                    FullName = builder.ToString(start, builder.Length - start);
                }
                else
                {
                    builder.Append(FullName);
                }
            }

            public sealed override void AppendNameTo(StringBuilder builder, FormatterContext context)
            {
                if (Name == null || Name.Context != context)
                {
                    var start = builder.Length;
                    AppendNameToCore(builder, context);
                    Name = new ContextName(context, builder.ToString(start, builder.Length - start));
                }
                else
                {
                    builder.Append(Name.Name);
                }
            }
            protected abstract void AppendCRefToCore(StringBuilder builder, FormatterContext context);
            protected abstract void AppendFullNameToCore(StringBuilder builder, FormatterContext context);
            protected abstract void AppendNameToCore(StringBuilder builder, FormatterContext context);

            public sealed override string GetCRef(FormatterContext context)
            {
                if (CRef == null || CRef.Context != context)
                {
                    var builder = new StringBuilder(Type.FullName.Length);
                    AppendCRefToCore(builder, context);
                    CRef = new ContextName(context, builder.ToString());
                }
                return CRef.Name;
            }
            public sealed override string GetFullName(FormatterContext context)
            {
                if (FullName == null)
                {
                    var builder = new StringBuilder(Type.FullName.Length);
                    AppendFullNameToCore(builder, context);
                    FullName = builder.ToString();
                }
                return FullName;
            }

            public sealed override string GetName(FormatterContext context)
            {
                if (Name == null || Name.Context != context)
                {
                    var builder = new StringBuilder(Type.FullName.Length);
                    AppendNameToCore(builder, context);
                    Name = new ContextName(context, builder.ToString());
                }
                return Name.Name;
            }
        }
    }
}
