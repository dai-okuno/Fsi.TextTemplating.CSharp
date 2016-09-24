using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NamespaceNameCollection
        : NamedCollection<INamespaceName>
    {
        public bool TryGet(string key, out INamespaceName value)
        {
            var node = First;
            while (node != null)
            {
                var comp = NameComparer.Compare(GetName(node.Item), key);
                if (comp < 0)
                {
                    node = node.Next;
                    continue;
                }
                else if (comp == 0)
                {
                    value = node.Item;
                    return true;
                }
                else
                {
                    break;
                }
            }
            value = default(INamespaceName);
            return false;
        }
        protected override string GetName(INamespaceName item)
            => item.FullName;

    }
}
