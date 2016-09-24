using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NonParameterizedTypeName
        : CachedTypeName
    {
        public NonParameterizedTypeName(FlyweightFactory factory, Type type)
        {
            Parent = factory.GetNamespaceName(type.Namespace);
            Name = type.Name;
            TypeFullName = type.FullName;
        }
        public NonParameterizedTypeName(FlyweightFactory factory, TypeName declaringTypeName, Type type)
        {
            Parent = declaringTypeName;
            Name = type.Name;
            TypeFullName = type.FullName;
        }
        private string Name { get; }
        private ITypeNameContainer Parent { get; }
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendAliasNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Name);
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendCRefNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Name);
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        protected override void AppendFullNameToCore(StringBuilder typeName)
        {
            Parent.AppendFullNameTo(typeName);
            typeName.Append('.').Append(Name);
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Name);
        }
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendTypeOfNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            var offset = typeName.Length;
            Parent.AppendTypeOfNameTo(typeName, context);
            if (offset < typeName.Length)
            {
                typeName.Append('.');
            }
            typeName.Append(Name);
        }
    }
}
