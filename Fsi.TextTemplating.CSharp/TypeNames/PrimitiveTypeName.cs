using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class PrimitiveTypeName
        : TypeName
    {
        private PrimitiveTypeName(Type type, string primitiveName)
        {
            Type = type;
            PrimitiveName = primitiveName;
            TypeFullName = type.FullName;
        }
        public static PrimitiveTypeName @bool()
            => new PrimitiveTypeName(typeof(bool), nameof(@bool));
        public static PrimitiveTypeName @byte()
            => new PrimitiveTypeName(typeof(byte), nameof(@byte));
        public static PrimitiveTypeName @char()
            => new PrimitiveTypeName(typeof(char), nameof(@char));
        public static PrimitiveTypeName @decimal()
            => new PrimitiveTypeName(typeof(decimal), nameof(@decimal));
        public static PrimitiveTypeName @double()
            => new PrimitiveTypeName(typeof(double), nameof(@double));
        public static PrimitiveTypeName @float()
            => new PrimitiveTypeName(typeof(float), nameof(@float));
        public static PrimitiveTypeName @int()
            => new PrimitiveTypeName(typeof(int), nameof(@int));
        public static PrimitiveTypeName @long()
            => new PrimitiveTypeName(typeof(long), nameof(@long));
        public static PrimitiveTypeName @object()
            => new PrimitiveTypeName(typeof(object), nameof(@object));
        public static PrimitiveTypeName @sbyte()
            => new PrimitiveTypeName(typeof(sbyte), nameof(@sbyte));
        public static PrimitiveTypeName @short()
            => new PrimitiveTypeName(typeof(short), nameof(@short));
        public static PrimitiveTypeName @string()
            => new PrimitiveTypeName(typeof(string), nameof(@string));
        public static PrimitiveTypeName @uint()
            => new PrimitiveTypeName(typeof(uint), nameof(@uint));
        public static PrimitiveTypeName @ulong()
            => new PrimitiveTypeName(typeof(ulong), nameof(@ulong));
        public static PrimitiveTypeName @ushort()
            => new PrimitiveTypeName(typeof(ushort), nameof(@ushort));
        public static PrimitiveTypeName @void()
            => new PrimitiveTypeName(typeof(void), nameof(@void));

        public string PrimitiveName { get; }

        public Type Type { get; }
        public override void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(Type.FullName);
        }

        public override void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(PrimitiveName);
        }

        public override void AppendFullNameTo(StringBuilder typeName)
        {
            typeName.Append(PrimitiveName);
        }

        public override void AppendNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(PrimitiveName);
        }
        public override void AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(PrimitiveName);
        }
        public override string GetAliasName(IFormatterContext context)
            => Type.FullName;

        public override string GetCRefName(IFormatterContext context)
            => PrimitiveName;

        public override string GetFullName()
            => PrimitiveName;
        public override string GetName(IFormatterContext context)
            => PrimitiveName;
        public override string GetTypeOfName(IFormatterContext context)
            => PrimitiveName;
    }

}
