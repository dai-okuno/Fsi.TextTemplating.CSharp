﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{

    internal class TypeNameCollection
        : IEnumerable<ITypeName>
    {
        public TypeNameCollection()
        {
            _Table = new Node[GetTableSize(256)];
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

        private readonly int _Mask;

        private Node[] _Table;

        public int Count { get; private set; }
        public void Add(ITypeName item)
        {
            var t = item.Type.GetHashCode() & _Mask;
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
            Count++;
        }

        public bool Contains(ITypeName item)
        {
            var t = item.Type.GetHashCode() & _Mask;
            var node = _Table[t];
            while (node != null)
            {
                if (item == node._Item)
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

        public bool TryGetValue(Type key, out ITypeName item)
        {
            var t = key.GetHashCode() & _Mask;
            var node = _Table[t];
            while (node != null)
            {
                if (key == node._Item.Type)
                {
                    item = node._Item;
                    return true;
                }
                else
                {
                    node = node._Next;
                }
            }
            item = default(ITypeName);
            return false;
        }

        public IEnumerator<ITypeName> GetEnumerator()
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
            for (int i = _TableSizes.Length - 1; i >= 0; i--)
            {
                if (_TableSizes[i] <= capacity) return _TableSizes[i];
            }
            return DefaultTableSize;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class Node
        {
            public ITypeName _Item;
            public Node _Next;
            public override string ToString()
            {
                return _Item?.ToString() ?? string.Empty;
            }
        }
    }
}
