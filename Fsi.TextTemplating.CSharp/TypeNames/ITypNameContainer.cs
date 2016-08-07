using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    interface ITypeNameContainer
    {
        int AppendCommentNameTo(StringBuilder builder, FormatterContext context);

        int AppendFullNameTo(StringBuilder builder, FormatterContext context);

        int AppendNameTo(StringBuilder builder, FormatterContext context);
    }
}
