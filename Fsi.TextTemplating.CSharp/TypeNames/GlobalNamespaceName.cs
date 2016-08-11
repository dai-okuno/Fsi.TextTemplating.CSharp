using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class GlobalNamespaceName
        : INamespaceName
    {
        public static GlobalNamespaceName Default { get; } = new GlobalNamespaceName();
        public int Depth
            => 0;

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

        bool INamespaceName.IsRoot
            => false;

        public string Name
            => "global";

        INamespaceName INamespaceName.Parent
            => null;

        INamespaceName INamespaceName.Root
            => null;

        void ITypeNameContainer.AppendFullNameTo(StringBuilder typeName, IFormatterContext context)
        { }

        void ITypeNameContainer.AppendNameTo(StringBuilder typeName, IFormatterContext context)
        { }

        void INamespaceName.BeginImport()
        {
            throw new NotSupportedException();
        }

        void INamespaceName.EndImport()
        {
            throw new NotSupportedException();
        }

        public bool Equals(INamespaceName other)
            => ReferenceEquals(other, this);

        public override int GetHashCode()
            => Name.GetHashCode();

    }
}
