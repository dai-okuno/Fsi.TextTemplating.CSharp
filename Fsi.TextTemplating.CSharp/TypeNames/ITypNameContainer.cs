using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    interface ITypeNameContainer
    {
        void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context);
        void AppendFullNameTo(StringBuilder typeName, IFormatterContext context);
        void AppendNameTo(StringBuilder typeName, IFormatterContext context);
    }
}
