using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class PrimitiveTypeName
            : TypeName
        {
            private PrimitiveTypeName(Type type, string primitiveName)
            {
                Type = type;
                PrimitiveName = primitiveName;
            }
            public static PrimitiveTypeName @char { get; } = new PrimitiveTypeName(typeof(char), nameof(@char));
            public static PrimitiveTypeName @sbyte { get; } = new PrimitiveTypeName(typeof(sbyte), nameof(@sbyte));
            public static PrimitiveTypeName @short { get; } = new PrimitiveTypeName(typeof(short), nameof(@short));
            public static PrimitiveTypeName @int { get; } = new PrimitiveTypeName(typeof(int), nameof(@int));
            public static PrimitiveTypeName @long { get; } = new PrimitiveTypeName(typeof(long), nameof(@long));
            public static PrimitiveTypeName @byte { get; } = new PrimitiveTypeName(typeof(byte), nameof(@byte));
            public static PrimitiveTypeName @ushort { get; } = new PrimitiveTypeName(typeof(ushort), nameof(@ushort));
            public static PrimitiveTypeName @uint { get; } = new PrimitiveTypeName(typeof(uint), nameof(@uint));
            public static PrimitiveTypeName @ulong { get; } = new PrimitiveTypeName(typeof(ulong), nameof(@ulong));
            public static PrimitiveTypeName @float { get; } = new PrimitiveTypeName(typeof(float), nameof(@float));
            public static PrimitiveTypeName @double { get; } = new PrimitiveTypeName(typeof(double), nameof(@double));
            public static PrimitiveTypeName @decimal { get; } = new PrimitiveTypeName(typeof(decimal), nameof(@decimal));
            public static PrimitiveTypeName @bool { get; } = new PrimitiveTypeName(typeof(bool), nameof(@bool));
            public static PrimitiveTypeName @string { get; } = new PrimitiveTypeName(typeof(string), nameof(@string));
            public static PrimitiveTypeName @object { get; } = new PrimitiveTypeName(typeof(object), nameof(@object));
            public static PrimitiveTypeName @void { get; } = new PrimitiveTypeName(typeof(void), nameof(@void));

            public string PrimitiveName { get; }

            public override Type Type { get; }

            public override void AppendNameTo(StringBuilder builder, FormatterContext context)
            {
                builder.Append(PrimitiveName);
            }


            public override void AppendCRefTo(StringBuilder builder, FormatterContext context)
            {
                builder.Append(PrimitiveName);
            }

            public override void AppendFullNameTo(StringBuilder builder, FormatterContext context)
            {
                builder.Append(PrimitiveName);
            }
            public override string GetCRef(FormatterContext context)
                => PrimitiveName;
            public override string GetFullName(FormatterContext context)
                => PrimitiveName;
            public override string GetName(FormatterContext context)
                => PrimitiveName;
        }

    }
}
