using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class CachedTypeName
        : TypeName
    {
        public CachedTypeName(Type type)
        {
            Type = type;
        }
        public sealed override Type Type { get; }
        private string _AliasName;
        private string _CRefName;
        private IFormatterContext _CRefNameContext;
        private string _FullName;
        private string _Name;
        private IFormatterContext _NameContext;

        public sealed override void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            Helper.AliasName.AppendTo(this, typeName, context, ref _AliasName);
        }

        public sealed override void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            Helper.CRefName.AppendTo(this, typeName, context, ref _CRefName, ref _CRefNameContext);
        }
        public sealed override void AppendFullNameTo(StringBuilder typeName, IFormatterContext context)
        {
            Helper.FullName.AppendTo(this, typeName, context, ref _FullName);
        }
        public sealed override void AppendNameTo(StringBuilder typeName, IFormatterContext context)
        {
            Helper.Name.AppendTo(this, typeName, context, ref _Name, ref _NameContext);
        }
        public sealed override string GetAliasName(IFormatterContext context)
            => Helper.AliasName.GetName(this, context, ref _AliasName);
        public sealed override string GetCRefName(IFormatterContext context)
            => Helper.CRefName.GetName(this, context, ref _CRefName, ref _CRefNameContext);
        public sealed override string GetFullName(IFormatterContext context)
            => Helper.FullName.GetName(this, context, ref _FullName);
        public sealed override string GetName(IFormatterContext context)
            => Helper.Name.GetName(this, context, ref _Name, ref _NameContext);
    }
}
