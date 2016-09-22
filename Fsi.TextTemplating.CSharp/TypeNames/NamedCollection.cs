using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal abstract class NamedCollection<TItem>
    {
        protected Node First { get; private set; }
        protected Node Last { get; private set; }
        protected StringComparer NameComparer { get; } = StringComparer.Ordinal;

        public void Add(TItem item)
        {
            if (Last == null)
            {
                Last = First = new Node() { Item = item };
            }
            else
            {
                var itemTypeFullName = GetName(item);
                var node = First;
                while (node.Next != null)
                {
                    var comp = NameComparer.Compare(GetName(node.Next.Item), itemTypeFullName);
                    if (comp < 0)
                    {
                        node = node.Next;
                        continue;
                    }
                    else
                    {
                        node.Next = new Node() { Item = item, Next = node.Next };
                        return;
                    }
                }
                Last = (node.Next = new Node() { Item = item });
            }
        }

        protected abstract string GetName(TItem item);

        protected sealed class Node
        {
            public TItem Item { get; set; }
            public Node Next { get; set; }
        }
    }
}
