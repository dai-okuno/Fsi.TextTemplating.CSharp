using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal sealed class NamespaceDeclarationFormatterContext
        : IFormatterContext
    {
        public NamespaceDeclarationFormatterContext(IFormatterContext parent, string subNamespaceName)
        {
            Parent = parent;
            NamespaceName = parent.GetNamespaceName(
                parent.NamespaceName.IsGlobal
                ? subNamespaceName
                : (parent.NamespaceName.FullName + "." + subNamespaceName));
        }
        public INamespaceName NamespaceName { get; }

        public IFormatterContext Parent { get; }

        IEnumerable<INamespaceName> IFormatterContext.ImportedNamespaceNames
            => Parent.ImportedNamespaceNames;

        private List<INamespaceName> ImportedNamespaceNames { get; }
            = new List<INamespaceName>();

        public INamespaceName GetNamespaceName(string namespaceName)
            => Parent.GetNamespaceName(namespaceName);

        public ITypeName GetTypeName(Type type)
            => Parent.GetTypeName(type);

        public INamespaceName Import(string namespaceName)
        {
            var value = Parent.Import(namespaceName);
            ImportedNamespaceNames.Add(value);
            return value;
        }

        public override string ToString()
            => NamespaceName.FullName;

    }
}
