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
        public abstract Type Type { get; }

        public abstract void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context);

        public abstract void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context);

        public abstract void AppendFullNameTo(StringBuilder typeName, IFormatterContext context);

        public abstract void AppendNameTo(StringBuilder typeName, IFormatterContext context);

        public sealed override bool Equals(object obj)
            => Equals(obj as ITypeName);
        public bool Equals(ITypeName other)
            => ReferenceEquals(other, this)
            || (!ReferenceEquals(other, null)
                && Type == other.Type);
        public abstract string GetAliasName(IFormatterContext context);
        public abstract string GetCRefName(IFormatterContext context);
        public abstract string GetFullName(IFormatterContext context);
        public sealed override int GetHashCode()
            => Type.GetHashCode();
        public abstract string GetName(IFormatterContext context);
        public sealed override string ToString()
            => Type.FullName;
        protected virtual void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameToCore(Helper.AliasName, typeName, context);
        }
        protected virtual void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameToCore(Helper.CRefName, typeName, context);
        }
        protected virtual void AppendFullNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameToCore(Helper.FullName, typeName, context);
        }
        protected virtual void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameToCore(Helper.Name, typeName, context);
        }
        protected virtual void AppendNameToCore(Helper helper, StringBuilder typeName, IFormatterContext context)
        { }
        protected abstract class Helper
        {
            public static ContextUnboundHelper AliasName { get; }
                = new AliasNameHelper();

            public static ContextBoundHelper CRefName { get; }
                = new CRefNameHelper();

            public static ContextUnboundHelper FullName { get; }
                = new FullNameHelper();

            public static ContextBoundHelper Name { get; }
                = new NameHelper();

            public virtual char CloseBracket
                => '>';

            public virtual char OpenBracket
                => '<';
            public abstract void AppendContainerNameTo(ITypeNameContainer builder, StringBuilder typeName, IFormatterContext context);
            public abstract void AppendTypeNameTo(ITypeNameBuilder builder, StringBuilder typeName, IFormatterContext context);
            protected abstract void AppendToCore(TypeName builder, StringBuilder typeName, IFormatterContext context);
        }
        private class AliasNameHelper
            : ContextUnboundHelper
        {
            public override void AppendContainerNameTo(ITypeNameContainer builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendFullNameTo(typeName, context);
            }
            public override void AppendTypeNameTo(ITypeNameBuilder builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendAliasNameTo(typeName, context);
            }
            protected override void AppendToCore(TypeName builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendAliasNameToCore(typeName, context);
            }
        }
        protected abstract class ContextBoundHelper
            : Helper
        {
            public void AppendTo(TypeName builder, StringBuilder typeName, IFormatterContext context, ref string cache, ref IFormatterContext cacheContext)
            {
                if (context != cacheContext)
                {
                    var offset = typeName.Length;
                    AppendToCore(builder, typeName, context);
                    cache = typeName.ToString(offset, typeName.Length - offset);
                    cacheContext = context;
                }
                else
                {
                    typeName.Append(cache);
                }
            }
            public string GetName(TypeName builder, IFormatterContext context, ref string cache, ref IFormatterContext cacheContext)
            {
                if (context != cacheContext)
                {
                    var typeName = new StringBuilder(builder.Type.FullName.Length);
                    AppendToCore(builder, typeName, context);
                    cache = typeName.ToString();
                    cacheContext = context;
                }
                return cache;
            }
        }
        protected abstract class ContextUnboundHelper
            : Helper
        {
            public void AppendTo(TypeName builder, StringBuilder typeName, IFormatterContext context, ref string cache)
            {
                if (cache == null)
                {
                    var offset = typeName.Length;
                    AppendToCore(builder, typeName, context);
                    cache = typeName.ToString(offset, typeName.Length - offset);
                }
                else
                {
                    typeName.Append(cache);
                }
            }
            public string GetName(TypeName builder, IFormatterContext context, ref string cache)
            {
                if (cache == null)
                {
                    var typeName = new StringBuilder(builder.Type.FullName.Length);
                    AppendToCore(builder, typeName, context);
                    cache = typeName.ToString();
                }
                return cache;
            }
        }
        private class CRefNameHelper
            : ContextBoundHelper
        {
            public override char CloseBracket
                => '}';
            public override char OpenBracket
                => '{';

            public override void AppendContainerNameTo(ITypeNameContainer builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendNameTo(typeName, context);
            }
            public override void AppendTypeNameTo(ITypeNameBuilder builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendCRefNameTo(typeName, context);
            }
            protected override void AppendToCore(TypeName builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendCRefNameToCore(typeName, context);
            }
        }
        private class FullNameHelper
            : ContextUnboundHelper
        {
            public override void AppendContainerNameTo(ITypeNameContainer builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendFullNameTo(typeName, context);
            }
            public override void AppendTypeNameTo(ITypeNameBuilder builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendFullNameTo(typeName, context);
            }
            protected override void AppendToCore(TypeName builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendFullNameToCore(typeName, context);
            }
        }
        private class NameHelper
            : ContextBoundHelper
        {
            public override void AppendContainerNameTo(ITypeNameContainer builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendNameTo(typeName, context);
            }
            public override void AppendTypeNameTo(ITypeNameBuilder builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendNameTo(typeName, context);
            }
            protected override void AppendToCore(TypeName builder, StringBuilder typeName, IFormatterContext context)
            {
                builder.AppendNameToCore(typeName, context);
            }
        }
    }
}
