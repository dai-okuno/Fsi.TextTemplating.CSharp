using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    interface ITypeNameContainer
    {
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context);
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context);
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">The <see cref="StringBuilder"/> to append name.</param>
        void AppendFullNameTo(StringBuilder typeName);
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        void AppendNameTo(StringBuilder typeName, IFormatterContext context);
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        void AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context);
    }
}
