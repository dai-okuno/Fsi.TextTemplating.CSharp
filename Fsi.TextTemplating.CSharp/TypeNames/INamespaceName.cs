using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal interface INamespaceName
        : ITypeNameContainer
    {
        string FullName { get; }
        bool IsDeclared { get; set; }
        bool IsGlobal { get; }
        bool IsImported { get; }
        
        INamespaceName Parent { get; }

        INamespaceName Root { get; }

        void BeginImport();
        void EndImport();
    }
}
