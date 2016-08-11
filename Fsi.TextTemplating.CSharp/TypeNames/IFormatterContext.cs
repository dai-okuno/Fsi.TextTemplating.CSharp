using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal interface IFormatterContext
    {
        SourceFileFormatterContext Root { get; }
        IFormatterContext Parent { get; }
        IEnumerable<INamespaceName> ImportedNamespaceNames { get; }
        INamespaceName NamespaceName { get; }
        INamespaceName GetNamespaceName(string namespaceName);
        ITypeName GetTypeName(Type type);
        INamespaceName Import(string namespaceName);
    }
}
