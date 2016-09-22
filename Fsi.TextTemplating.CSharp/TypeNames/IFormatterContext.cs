using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal interface IFormatterContext
    {
        IFormatterContext Parent { get; }
        IEnumerable<INamespaceName> ImportedNamespaceNames { get; }
        INamespaceName NamespaceName { get; }
        void Import(INamespaceName namespaceName);

    }
}
