using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    public abstract class KeyedCollection<TKey, TItem>
        : IEnumerable<TItem>
    {
        protected KeyedCollection() : this(DefaultTableSize, EqualityComparer<TKey>.Default)
        { }

        protected KeyedCollection(int capacity, IEqualityComparer<TKey> comparer)
        {
            _Table = new Node[GetSize(capacity)];
            _Mask = _Table.Length - 1;
            Comparer = comparer;
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

        private int _Count;
        private readonly int _Mask;

        private IEqualityComparer<TKey> Comparer { get; }

        private Node[] _Table;
        public int Count
            => _Count;

        public void Add(TItem item)
        {
            var t = GetKey(item).GetHashCode() & _Mask;
            Node node;
            if ((node = _Table[t]) == null)
            {
                _Table[t] = new Node() { _Item = item };
                return;
            }
            do
            {

            } while ((node = node._Next) != null);

        }

        public bool Contains(TItem item)
        {
            var key = GetKey(item);
            var t = key.GetHashCode() & _Mask;
            Node node;
            if ((node = _Table[t]) == null)
            {
                return false;
            }
            do
            {
                if (Comparer.Equals(key, GetKey(node._Item)))
                {
                    return true;
                }
            } while ((node = node._Next) != null);
            return false;
        }

        public bool TryGetValue(TKey key, out TItem item)
        {
            var t = key.GetHashCode() & _Mask;
            Node node;
            if ((node = _Table[t]) == null)
            {
                item = default(TItem);
                return false;
            }
            do
            {
                if (Comparer.Equals(key, GetKey(node._Item)))
                {
                    item = node._Item;
                    return true;
                }
            } while ((node = node._Next) != null);
            item = default(TItem);
            return false;
        }

        public IEnumerator<TItem> GetEnumerator()
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

        protected abstract TKey GetKey(TItem item);


        private int GetSize(int capacity)
        {
            for (int i = _TableSizes.Length - 1; i >= 0; i--)
            {
                if (_TableSizes[i] <= capacity) return _TableSizes[i];
            }
            return DefaultTableSize;
        }
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class Node
        {
            public TItem _Item;
            public Node _Next;
        }

    }
}
