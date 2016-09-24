using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    [System.Diagnostics.DebuggerDisplay("{FullName}")]
    internal class GlobalNamespaceName
        : INamespaceName
    {
        public string FullName
            => string.Empty;
        bool INamespaceName.IsDeclared
        {
            get { return false; }
            set { throw new NotSupportedException(); }
        }
        public bool IsGlobal
            => true;

        bool INamespaceName.IsImported
            => false;

        INamespaceName INamespaceName.Parent
            => null;

        INamespaceName INamespaceName.Root
            => null;
        void ITypeNameContainer.AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        { }
        void ITypeNameContainer.AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        { }

        void ITypeNameContainer.AppendFullNameTo(StringBuilder typeName)
        { }

        void ITypeNameContainer.AppendNameTo(StringBuilder typeName, IFormatterContext context)
        { }
        void ITypeNameContainer.AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context)
        { }
        void INamespaceName.BeginImport()
        {
            throw new NotSupportedException();
        }

        void INamespaceName.EndImport()
        {
            throw new NotSupportedException();
        }

        public override int GetHashCode()
            => FullName.GetHashCode();

    }
}
