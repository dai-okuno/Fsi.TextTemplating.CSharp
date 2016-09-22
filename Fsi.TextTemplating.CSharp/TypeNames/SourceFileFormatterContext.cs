using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Fsi.TextTemplating.TypeNames
{

    internal class SourceFileFormatterContext
        : IFormatterContext
    {
        public SourceFileFormatterContext(GlobalNamespaceName namespaceName)
        {
            ImportedNamespaceNames = new List<INamespaceName>();
            NamespaceName = namespaceName;
        }
        private List<INamespaceName> ImportedNamespaceNames { get; }

        IEnumerable<INamespaceName> IFormatterContext.ImportedNamespaceNames
            => ImportedNamespaceNames;

        public GlobalNamespaceName NamespaceName { get; }
        INamespaceName IFormatterContext.NamespaceName
            => NamespaceName;
        public SourceFileFormatterContext Root
            => this;
        IFormatterContext IFormatterContext.Parent
            => null;

        public void Import(INamespaceName namespaceName)
        {
            ImportedNamespaceNames.Add(namespaceName);
        }
    }
}
