using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal sealed class NamespaceDeclarationFormatterContext
        : IFormatterContext
    {
        public NamespaceDeclarationFormatterContext(IFormatterContext parent, INamespaceName namespaceName)
        {
            Parent = parent;
            NamespaceName = namespaceName;
        }
        public INamespaceName NamespaceName { get; }

        public IFormatterContext Parent { get; }

        IEnumerable<INamespaceName> IFormatterContext.ImportedNamespaceNames
            => ImportedNamespaceNames;

        private List<INamespaceName> ImportedNamespaceNames { get; }
            = new List<INamespaceName>();

        public void Import(INamespaceName namespaceName)
        {
            ImportedNamespaceNames.Add(namespaceName);
        }

        public override string ToString()
            => NamespaceName.FullName;

    }
}
