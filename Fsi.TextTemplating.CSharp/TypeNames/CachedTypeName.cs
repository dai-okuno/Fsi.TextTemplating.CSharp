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
        public CachedTypeName(Type type)
        {
            Type = type;
        }
        public sealed override Type Type { get; }
        private string _AliasName;
        private string _CRefName;
        private IFormatterContext _CRefNameContext;
        private string _FullName;
        private string _Name;
        private IFormatterContext _NameContext;

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public sealed override void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (_AliasName == null)
            {
                AppendNameTo(typeName, context);
            }
            else
            {
                typeName.Append(_AliasName);
            }
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
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

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public sealed override void AppendFullNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (_FullName == null)
            {
                var offset = typeName.Length;
                AppendFullNameToCore(typeName, context);
                _FullName = typeName.ToString(offset, typeName.Length - offset);
            }
            else
            {
                typeName.Append(_FullName);
            }
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
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

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetAliasName(IFormatterContext context)
        {
            if (_AliasName == null)
            {
                return GetName(context);
            }
            else
            {
                return _AliasName;
            }
        }

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetCRefName(IFormatterContext context)
        {
            if (_CRefNameContext != context)
            {
                var typeName = new StringBuilder(Type.FullName.Length);
                AppendCRefNameToCore(typeName, context);
                _CRefName = typeName.ToString();
                _CRefNameContext = context;
            }
            return _CRefName;
        }

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetFullName(IFormatterContext context)
        {
            if (_FullName == null)
            {
                var typeName = new StringBuilder(Type.FullName.Length);
                AppendFullNameToCore(typeName, context);
                _FullName = typeName.ToString();
            }
            return _FullName;
        }

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public sealed override string GetName(IFormatterContext context)
        {
            if (_NameContext != context)
            {
                var typeName = new StringBuilder(Type.FullName.Length);
                AppendNameToCore(typeName, context);
                _Name = typeName.ToString();
                _NameContext = context;
            }
            return _Name;
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected abstract void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected abstract void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context);

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        protected abstract void AppendNameToCore(StringBuilder typeName, IFormatterContext context);

    }
}
