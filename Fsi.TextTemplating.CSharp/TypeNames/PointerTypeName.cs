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
        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(Helper.AliasName, typeName, context);
        }
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(Helper.CRefName, typeName, context);
        }
        protected override void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(Helper.FullName, typeName, context);
        }
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(Helper.Name, typeName, context);
        }
        private void AppendNameTo(Helper helper, StringBuilder typeName, IFormatterContext context)
        {
            helper.AppendTypeNameTo(ElementTypeName, typeName, context);
            typeName.Append('*');
        }
        protected override void AppendNameToCore(Helper helper, StringBuilder typeName, IFormatterContext context)
        {
            helper.AppendTypeNameTo(ElementTypeName, typeName, context);
            typeName.Append('*');
        }
    }
}
