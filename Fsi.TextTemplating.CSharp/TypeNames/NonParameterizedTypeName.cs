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

        protected override void AppendNameToCore(Helper helper, StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            helper.AppendContainerNameTo(Parent, typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Type.Name);
        }
    }
}
