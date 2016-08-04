using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{

    partial class CSharpTypeFormatter
    {
        private class TypeNameCollection
            : KeyedCollection<Type,TypeName>
        {
            protected override Type GetKey(TypeName item)
                => item.Type;
        }
    }
}
