using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NullableTypeName
        : CachedTypeName
    {
        public NullableTypeName(FlyweightFactory factory, Type type)
        {
            UnderlyingTypeName = factory.GetTypeName(Nullable.GetUnderlyingType(type));
            _System = factory.GetNamespaceName(nameof(System));
            TypeFullName = type.FullName;
        }
        private INamespaceName _System;
        //public override FlyweightFactory Factory
        //    => UnderlyingTypeName.Factory;
        private TypeName UnderlyingTypeName { get; }
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append("System.Nullable<");
            UnderlyingTypeName.AppendAliasNameTo(typeName, context);
            typeName.Append('>');
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            if (!_System.IsImported && !_System.IsDeclared)
            {
                typeName.Append("System.");
            }
            typeName.Append("Nullable{");
            UnderlyingTypeName.AppendCRefNameTo(typeName, context);
            typeName.Append('}');
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        protected override void AppendFullNameToCore(StringBuilder typeName)
        {
            UnderlyingTypeName.AppendFullNameTo(typeName);
            typeName.Append('?');
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            UnderlyingTypeName.AppendNameTo(typeName, context);
            typeName.Append('?');
        }
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendTypeOfNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            UnderlyingTypeName.AppendTypeOfNameTo(typeName, context);
            typeName.Append('?');
        }

    }
}
