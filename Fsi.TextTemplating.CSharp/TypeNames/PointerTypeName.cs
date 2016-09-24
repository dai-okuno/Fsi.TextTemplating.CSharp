using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class PointerTypeName
        : CachedTypeName
    {
        public PointerTypeName(FlyweightFactory factory, Type type)
        {
            ElementTypeName = factory.GetTypeName(type.GetElementType());
            TypeFullName = type.FullName;
        }
        private TypeName ElementTypeName { get; }

        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendAliasNameTo(typeName, context);
            typeName.Append('*');
        }

        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendCRefNameTo(typeName, context);
            typeName.Append('*');
        }

        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        protected override void AppendFullNameToCore(StringBuilder typeName)
        {
            ElementTypeName.AppendFullNameTo(typeName);
            typeName.Append('*');
        }

        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendNameTo(typeName, context);
            typeName.Append('*');
        }

        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendTypeOfNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendTypeOfNameTo(typeName, context);
            typeName.Append('*');
        }

    }
}
