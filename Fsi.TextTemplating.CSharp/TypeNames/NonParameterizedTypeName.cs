using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
internal class NonParameterizedTypeName
        : TypeNameBase
    {
        public NonParameterizedTypeName(Type type, NamespaceName namespaceName)
            : base(type)
        {
            Parent = namespaceName;
        }
        public NonParameterizedTypeName(Type type, TypeName declaringTypeName)
            : base(type)
        {
            Parent = declaringTypeName;
        }


        private ITypeNameContainer Parent { get; }


        protected override void AppendCRefToCore(StringBuilder builder, FormatterContext context)
        {
            if (0 < Parent.AppendCommentNameTo(builder, context))
            { builder.Append('.'); }
            builder.Append(Type.Name);
        }

        protected override void AppendFullNameToCore(StringBuilder builder, FormatterContext context)
        {
            if (0 < Parent.AppendFullNameTo(builder, context))
            { builder.Append('.'); }
            builder.Append(Type.Name);
        }

        protected override void AppendNameToCore(StringBuilder builder, FormatterContext context)
        {
            if (0 < Parent.AppendNameTo(builder, context))
            { builder.Append('.'); }
            builder.Append(Type.Name);
        }
    }
}
