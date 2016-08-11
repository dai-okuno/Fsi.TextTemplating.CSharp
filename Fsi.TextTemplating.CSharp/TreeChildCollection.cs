using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    internal class TreeChildCollection<T>
        : IEnumerable<T>
        where T : ITreeNode<T>
    {
        public T FirstChild { get; set; }



        public IEnumerator<T> GetEnumerator()
        {
            var child = FirstChild;
            while (child != null)
            {
                yield return child;
                child = child.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
