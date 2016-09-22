using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal abstract class CachedTypeName
        : TypeName
    {

        private string _AliasName;
        private IFormatterContext _AliasNameContext;
        private string _CRefName;
        private IFormatterContext _CRefNameContext;
        private string _FullName;
        private string _Name;
        private IFormatterContext _NameContext;
        private string _TypeOfName;
        private IFormatterContext _TypeOfNameContext;

        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public sealed override void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (_AliasNameContext != context)
            {
                var offset = typeName.Length;
                AppendAliasNameToCore(typeName, context);
                _AliasName = typeName.ToString(offset, typeName.Length - offset);
                _AliasNameContext = context;
            }
            else
            {
                typeName.Append(_AliasName);
            }
        }

        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public sealed override void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (_CRefNameContext != context)
            {
                var offset = typeName.Length;
                AppendCRefNameToCore(typeName, context);
                _CRefName = typeName.ToString(offset, typeName.Length - offset);
                _CRefNameContext = context;
            }
            else
            {
                typeName.Append(_CRefName);
            }
        }

        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        public sealed override void AppendFullNameTo(StringBuilder typeName)
        {
            if (_FullName == null)
            {
                var offset = typeName.Length;
                AppendFullNameToCore(typeName);
                _FullName = typeName.ToString(offset, typeName.Length - offset);
            }
            else
            {
                typeName.Append(_FullName);
            }
        }

        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public sealed override void AppendNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (_NameContext != context)
            {
                var offset = typeName.Length;
                AppendNameToCore(typeName, context);
                _Name = typeName.ToString(offset, typeName.Length - offset);
                _NameContext = context;
            }
            else
            {
                typeName.Append(_Name);
            }
        }

        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public sealed override void AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (_TypeOfNameContext != context)
            {
                var offset = typeName.Length;
                AppendTypeOfNameToCore(typeName, context);
                _TypeOfName = typeName.ToString(offset, typeName.Length - offset);
                _TypeOfNameContext = context;
            }
            else
            {
                typeName.Append(_TypeOfName);
            }
        }

        /// <summary>
        /// Gets the name for type alias declaration.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetAliasName(IFormatterContext context)
        {
            if (_AliasName == null)
            {
                var typeName = new StringBuilder();
                AppendAliasNameToCore(typeName, context);
                _AliasName = typeName.ToString();
                _AliasNameContext = context;
            }
            return _AliasName;
        }

        /// <summary>
        /// Gets the name for cref attribute in document comment.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetCRefName(IFormatterContext context)
        {
            if (_CRefNameContext != context)
            {
                var typeName = new StringBuilder();
                AppendCRefNameToCore(typeName, context);
                _CRefName = typeName.ToString();
                _CRefNameContext = context;
            }
            return _CRefName;
        }

        /// <summary>
        /// Gets the full name of this object.
        /// </summary>
        /// <returns></returns>
        public sealed override string GetFullName()
        {
            if (_FullName == null)
            {
                var typeName = new StringBuilder();
                AppendFullNameToCore(typeName);
                _FullName = typeName.ToString();
            }
            return _FullName;
        }
        public override int GetHashCode()
            => TypeFullName.GetHashCode();
        /// <summary>
        /// Gets the name of this object.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetName(IFormatterContext context)
        {
            if (_NameContext != context)
            {
                var typeName = new StringBuilder();
                AppendNameToCore(typeName, context);
                _Name = typeName.ToString();
                _NameContext = context;
            }
            return _Name;
        }

        /// <summary>
        /// Gets the name for type of operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetTypeOfName(IFormatterContext context)
        {
            if (_TypeOfNameContext != context)
            {
                var typeName = new StringBuilder();
                AppendTypeOfNameToCore(typeName, context);
                _TypeOfName = typeName.ToString();
                _TypeOfNameContext = context;
            }
            return _TypeOfName;
        }

        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected abstract void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context);

        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected abstract void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context);

        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        protected abstract void AppendFullNameToCore(StringBuilder typeName);

        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected abstract void AppendNameToCore(StringBuilder typeName, IFormatterContext context);

        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected abstract void AppendTypeOfNameToCore(StringBuilder typeName, IFormatterContext context);

    }
}
