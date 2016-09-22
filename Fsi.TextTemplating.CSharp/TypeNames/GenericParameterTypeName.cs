using System;
using System.Text;

namespace Fsi.TextTemplating.TypeNames
{
    internal sealed class GenericParameterTypeName
        : TypeName
    {
        public GenericParameterTypeName(string name)
        {
            Name = name;
            TypeFullName = name;
        }
        public GenericParameterTypeName(Type type)
        {
            Name = type.Name;
            TypeFullName = type.Name;
        }
        private string Name { get; set; }
        public override int GetHashCode()
            => Name.GetHashCode();
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public override void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(Name);
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public override void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(Name);
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        public override void AppendFullNameTo(StringBuilder builder)
        {
            builder.Append(Name);
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public override void AppendNameTo(StringBuilder builder, IFormatterContext context)
        {
            builder.Append(Name);
        }
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public override void AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context)
        { }
        /// <summary>
        /// Gets the name for type alias declaration.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string GetAliasName(IFormatterContext context)
            => Name;
        /// <summary>
        /// Gets the name for cref attribute in document comment.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string GetCRefName(IFormatterContext context)
            => Name;
        /// <summary>
        /// Gets the full name of this object.
        /// </summary>
        /// <returns></returns>
        public override string GetFullName()
            => Name;
        /// <summary>
        /// Gets the name of this object.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string GetName(IFormatterContext context)
            => Name;
        /// <summary>
        /// Gets the name for type of operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string GetTypeOfName(IFormatterContext context)
            => string.Empty;
    }
}
