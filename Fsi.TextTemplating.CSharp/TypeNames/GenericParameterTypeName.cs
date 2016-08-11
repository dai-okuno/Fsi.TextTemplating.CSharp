using System;
using System.Text;

namespace Fsi.TextTemplating.TypeNames
{
    internal sealed class GenericParameterTypeName
        : TypeName
    {
        public GenericParameterTypeName(Type type)
        {
            Type = type;
        }
        public override Type Type { get; }
        public override void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(Type.Name);
        }
        public override void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(Type.Name);
        }
        public override void AppendFullNameTo(StringBuilder builder, IFormatterContext context)
        {
            builder.Append(Type.Name);
        }
        public override void AppendNameTo(StringBuilder builder, IFormatterContext context)
        {
            builder.Append(Type.Name);
        }
        public override string GetAliasName(IFormatterContext context)
            => Type.Name;
        public override string GetCRefName(IFormatterContext context)
            => Type.Name;
        public override string GetFullName(IFormatterContext context)
            => Type.Name;
        public override string GetName(IFormatterContext context)
            => Type.Name;
    }
}
