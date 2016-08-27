using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class PointerTypeName
        : CachedTypeName
    {
        public PointerTypeName(Type type, ITypeName elementTypeName)
            : base(type)
        {
            ElementTypeName = elementTypeName;
        }

        private ITypeName ElementTypeName { get; }
        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendCRefNameTo(typeName, context);
            typeName.Append('*');
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendFullNameTo(typeName, context);
            typeName.Append('*');
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendNameTo(typeName, context);
            typeName.Append('*');
        }
    }
}
