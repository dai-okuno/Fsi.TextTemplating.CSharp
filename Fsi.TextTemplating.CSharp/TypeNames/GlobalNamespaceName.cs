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
        public GlobalNamespaceName(FlyweightFactory factory)
        {
            Factory = factory;
        }
        public int Depth
            => 0;
        public FlyweightFactory Factory { get; }
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

        public bool Equals(INamespaceName other)
            => ReferenceEquals(other, this);

        public override int GetHashCode()
            => Name.GetHashCode();

    }
}
