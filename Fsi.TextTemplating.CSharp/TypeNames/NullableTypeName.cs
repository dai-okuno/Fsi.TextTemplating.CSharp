using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NullableTypeName
        : CachedTypeName
    {
        public NullableTypeName(Type type, ITypeName underlyingTypeName)
            : base(type)
        {
            UnderlyingTypeName = underlyingTypeName;
        }

        private ITypeName UnderlyingTypeName { get; }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            context.GetNamespaceName("System").AppendCRefNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append("Nullable{");
            UnderlyingTypeName.AppendCRefNameTo(typeName, context);
            typeName.Append('}');
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            UnderlyingTypeName.AppendFullNameTo(typeName, context);
            typeName.Append('?');
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            UnderlyingTypeName.AppendNameTo(typeName, context);
            typeName.Append('?');
        }
    }
}
