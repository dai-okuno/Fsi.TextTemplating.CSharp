using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal interface INamespaceName
        : ITypeNameContainer, IEquatable<INamespaceName>
    {
        int Depth { get; }
        string FullName { get; }
        bool IsDeclared { get; set; }
        bool IsGlobal { get; }
        bool IsImported { get; }
        bool IsRoot { get; }

        string Name { get; }

        INamespaceName Parent { get; }

        INamespaceName Root { get; }

        void BeginImport();
        void EndImport();
    }
}
