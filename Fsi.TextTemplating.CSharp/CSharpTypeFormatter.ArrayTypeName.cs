using System;
using System.Text;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class ArrayTypeName
            : TypeNameBase
        {
            private ArrayTypeName(Type type, TypeName elementTypeName, string ranks)
                : base(type)
            {
                ElementTypeName = elementTypeName;
                Ranks = ranks;
            }

            private TypeName ElementTypeName { get; }

            private string Ranks { get; }

            public static ArrayTypeName Create(Type type, FormatterContext context)
            {
                var t = type;
                var ranks = string.Empty;
                do
                {
                    int rank;
                    switch (rank = t.GetArrayRank())
                    {
                        case 1:
                            ranks += "[]";
                            break;
                        case 2:
                            ranks += "[,]";
                            break;
                        case 3:
                            ranks += "[,,]";
                            break;
                        default:
                            ranks += ("[" + new string(',', rank - 1) + "]");
                            break;
                    }
                } while ((t = t.GetElementType()).IsArray);
                return new ArrayTypeName(type, context.GetTypeName(t), ranks);
            }

            protected override void AppendCRefToCore(StringBuilder builder, FormatterContext context)
            {
                ElementTypeName.AppendCRefTo(builder, context);
                builder.Append(Ranks);
            }

            protected override void AppendFullNameToCore(StringBuilder builder, FormatterContext context)
            {
                ElementTypeName.AppendFullNameTo(builder, context);
                builder.Append(Ranks);
            }

            protected override void AppendNameToCore(StringBuilder builder, FormatterContext formatter)
            {
                ElementTypeName.AppendNameTo(builder, formatter);
                builder.Append(Ranks);
            }

        }
    }
}
