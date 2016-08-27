using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NonParameterizedTypeName
        : CachedTypeName
    {
        public NonParameterizedTypeName(Type type, INamespaceName namespaceName)
            : base(type)
        {
            Parent = namespaceName;
        }
        public NonParameterizedTypeName(Type type, ITypeName declaringTypeName)
            : base(type)
        {
            Parent = declaringTypeName;
        }

        private ITypeNameContainer Parent { get; }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendCRefNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Type.Name);
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            Parent.AppendFullNameTo(typeName, context);
            typeName.Append('.').Append(Type.Name);
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Type.Name);
        }
    }
}
