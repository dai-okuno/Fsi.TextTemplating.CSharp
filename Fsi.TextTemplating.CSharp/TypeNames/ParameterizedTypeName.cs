using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class ParameterizedTypeName
            : TypeNameBase
    {
        public ParameterizedTypeName(Type type, NamespaceName namespaceName, TypeName[] argNames)
            : base(type)
        {
            Parent = namespaceName;
            CoreName = GetCoreName(type);
            GenericTypeArgumentNames = argNames;
        }

        public ParameterizedTypeName(Type type, TypeName declaringTypeName, TypeName[] argNames)
            : base(type)
        {
            Parent = declaringTypeName;
            CoreName = GetCoreName(type);
            GenericTypeArgumentNames = argNames;
        }

        private ITypeNameContainer Parent { get; }

        private string CoreName { get; }

        private TypeName[] GenericTypeArgumentNames { get; }

        private string GetCoreName(Type type)
            => type.Name.Remove(type.Name.IndexOf('`'));


        protected override void AppendCRefToCore(StringBuilder builder, FormatterContext context)
        {
            if (0 < Parent.AppendCommentNameTo(builder, context))
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
            if (0 < Parent.AppendFullNameTo(builder, context))
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
            if (0 < Parent.AppendNameTo(builder, context))
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
