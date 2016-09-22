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
        private static readonly PrimitiveTypeName[] _Values =
            new PrimitiveTypeName[]
            {
                new PrimitiveTypeName(typeof(char), "char"),
                new PrimitiveTypeName(typeof(sbyte), "sbyte"),
                new PrimitiveTypeName(typeof(short), "short"),
                new PrimitiveTypeName(typeof(int), "int"),
                new PrimitiveTypeName(typeof(long), "long"),
                new PrimitiveTypeName(typeof(byte), "byte"),
                new PrimitiveTypeName(typeof(ushort), "ushort"),
                new PrimitiveTypeName(typeof(uint), "uint"),
                new PrimitiveTypeName(typeof(ulong), "ulong"),
                new PrimitiveTypeName(typeof(float), "float"),
                new PrimitiveTypeName(typeof(double), "double"),
                new PrimitiveTypeName(typeof(decimal), "decimal"),
                new PrimitiveTypeName(typeof(bool), "bool"),
                new PrimitiveTypeName(typeof(string), "string"),
                new PrimitiveTypeName(typeof(object), "object"),
                new PrimitiveTypeName(typeof(void), "void"),
            };
        public static IReadOnlyList<PrimitiveTypeName> GetValues(FlyweightFactory factory)
            => _Values;
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
        public override int GetHashCode()
            => Type.FullName.GetHashCode();
        public override string GetName(IFormatterContext context)
            => PrimitiveName;
        public override string GetTypeOfName(IFormatterContext context)
            => PrimitiveName;
    }

}
