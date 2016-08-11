using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal interface ITypeNameBuilder
        :ITypeNameContainer
    {
        void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context);
        void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context);
    }

}
