using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class TypeNameCollection
        : NamedCollection<TypeName>
    {

        public bool TryGet(Type key, out TypeName value)
        {
            var keyFullName = key.FullName;
            var node = First;
            while (node != null)
            {
                var comp = NameComparer.Compare(GetName(node.Item), keyFullName);
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
            value = default(TypeName);
            return false;
        }
        protected override string GetName(TypeName item)
            => item.TypeFullName;
    }
}
