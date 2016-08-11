using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    interface ITreeNode<T>
    {
        T Parent { get; }
        IEnumerable<T> Children { get; }
        T Next { get; set; }
        T Prev { get; set; }
    }
}
