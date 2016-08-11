using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NamespaceNameCollection
        : IEnumerable<INamespaceName>
    {
        public NamespaceNameCollection()
        {
            _Table = new Node[GetTableSize(DefaultTableSize)];
            _Mask = _Table.Length - 1;
        }

        private const int DefaultTableSize = 256;
        private static readonly int[] _TableSizes = new[] {
            0x00000001, 0x00000002, 0x00000004, 0x00000008,
            0x00000010, 0x00000020, 0x00000040, 0x00000080,
            0x00000100, 0x00000200, 0x00000400, 0x00000800,
            0x00001000, 0x00002000, 0x00004000, 0x00008000,
            0x00010000, 0x00020000, 0x00040000, 0x00080000,
            0x00100000, 0x00200000, 0x00400000, 0x00800000,
            0x01000000, 0x02000000, 0x04000000, 0x08000000,
            0x10000000, 0x20000000, 0x40000000, };

        public int Count { get; private set; }

        private readonly int _Mask;

        private Node[] _Table;

        public void Add(INamespaceName item)
        {
            var t = item.FullName.GetHashCode() & _Mask;
            var node = _Table[t];
            if (node == null)
            {
                _Table[t] = new Node() { _Item = item };
                return;
            }
            while (node._Next != null)
            {
                node = node._Next;
            }
            node._Next = new Node() { _Item = item };
        }

        public bool Contains(INamespaceName item)
        {
            var key = item.FullName;
            var t = key.GetHashCode() & _Mask;
            var node = _Table[t];
            while (node != null)
            {
                if (key == node._Item.FullName)
                {
                    return true;
                }
                else
                {
                    node = node._Next;
                }
            }
            return false;
        }

        public bool TryGetValue(string key, out INamespaceName item)
        {
            var t = key.GetHashCode() & _Mask;
            var node = _Table[t];
            while (node != null)
            {
                if (key == node._Item.FullName)
                {
                    item = node._Item;
                    return true;
                }
                else
                {
                    node = node._Next;
                }
            }
            item = default(INamespaceName);
            return false;
        }

        public IEnumerator<INamespaceName> GetEnumerator()
        {
            for (int t = 0; t < _Table.Length; t++)
            {
                var node = _Table[t];
                if (node == null) continue;
                yield return node._Item;
                while ((node = node._Next) != null)
                {
                    yield return node._Item;
                }
            }
        }

        private int GetTableSize(int capacity)
        {
            for (int i = 1; i < _TableSizes.Length; i++)
            {
                if (capacity < _TableSizes[i]) return _TableSizes[i - 1];
            }
            return DefaultTableSize;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class Node
        {
            public INamespaceName _Item;
            public Node _Next;
            public override string ToString()
            {
                return _Item?.ToString() ?? string.Empty;
            }
        }

    }
}
