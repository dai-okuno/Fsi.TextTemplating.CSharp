using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal abstract class TypeName
        : ITypeNameContainer, IEquatable<TypeName>
    {
        public static TypeName[] EmptyArray { get; } = new TypeName[0];

        protected internal string TypeFullName { get; set; }

        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public abstract void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context);
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public abstract void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context);
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        public abstract void AppendFullNameTo(StringBuilder typeName);
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public abstract void AppendNameTo(StringBuilder typeName, IFormatterContext context);
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public abstract void AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
            => Equals(obj as TypeName);

        /// <summary></summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TypeName other)
            => ReferenceEquals(other, this)
            || (!ReferenceEquals(other, null)
                && GetFullName() == other.GetFullName());
        /// <summary>
        /// Gets the name for type alias declaration.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetAliasName(IFormatterContext context);
        /// <summary>
        /// Gets the name for cref attribute in document comment.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetCRefName(IFormatterContext context);
        /// <summary>
        /// Gets the full name of this object.
        /// </summary>
        /// <returns></returns>
        public abstract string GetFullName();
        /// <summary>
        /// Gets the hash code of this object.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override int GetHashCode()
            => GetFullName().GetHashCode();
        /// <summary>
        /// Gets the name of this object.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetName(IFormatterContext context);
        /// <summary>
        /// Gets the name for type of operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetTypeOfName(IFormatterContext context);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => GetFullName();

    }
}
