using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Fsi.TextTemplating.TypeNames
{
    internal abstract class TypeName
            : IEquatable<TypeName>, ITypeNameContainer
    {

        public abstract Type Type { get; }

        /// <summary></summary>
        /// <param name="builder"></param>
        /// <param name="context"></param>
        public abstract void AppendCRefTo(StringBuilder builder, FormatterContext context);

        /// <summary></summary>
        /// <param name="builder"></param>
        /// <param name="context"></param>
        public abstract void AppendFullNameTo(StringBuilder builder, FormatterContext context);

        /// <summary></summary>
        /// <param name="builder"></param>
        /// <param name="context"></param>
        public abstract void AppendNameTo(StringBuilder builder, FormatterContext context);

        public override bool Equals(object obj)
            => Equals(obj as TypeName);

        public bool Equals(TypeName other)
            => !ReferenceEquals(other, null)
            && Type.Equals(other.Type);

        public override int GetHashCode()
            => Type.GetHashCode();

        public abstract string GetCRef(FormatterContext context);
        public abstract string GetFullName(FormatterContext context);

        public abstract string GetName(FormatterContext context);

        public override string ToString()
            => Type.FullName;

        int ITypeNameContainer.AppendCommentNameTo(StringBuilder builder, FormatterContext context)
        {
            var start = builder.Length;
            AppendCRefTo(builder, context);
            return builder.Length - start;
        }

        int ITypeNameContainer.AppendFullNameTo(StringBuilder builder, FormatterContext context)
        {
            var start = builder.Length;
            AppendFullNameTo(builder, context);
            return builder.Length - start;
        }

        int ITypeNameContainer.AppendNameTo(StringBuilder builder, FormatterContext context)
        {
            var start = builder.Length;
            AppendNameTo(builder, context);
            return builder.Length - start;
        }

        protected class ContextName
        {
            public ContextName(FormatterContext context, string name)
            {
                Context = context;
                Name = name;
            }
            public string Name { get; }
            public FormatterContext Context { get; }

            public override string ToString()
            {
                return Name;
            }

        }
    }
}
