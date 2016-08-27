using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal abstract class TypeName
        : ITypeName
    {
        /// <summary></summary>
        public abstract Type Type { get; }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public abstract void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public abstract void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public abstract void AppendFullNameTo(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public abstract void AppendNameTo(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public sealed override bool Equals(object obj)
            => Equals(obj as ITypeName);

        /// <summary></summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ITypeName other)
            => ReferenceEquals(other, this)
            || (!ReferenceEquals(other, null)
                && Type == other.Type);

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetAliasName(IFormatterContext context);

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetCRefName(IFormatterContext context);

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetFullName(IFormatterContext context);
        
        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override int GetHashCode()
            => Type.GetHashCode();
        
        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract string GetName(IFormatterContext context);

        /// <summary></summary>
        /// <returns></returns>
        public sealed override string ToString()
            => Type.FullName;

    }
}
