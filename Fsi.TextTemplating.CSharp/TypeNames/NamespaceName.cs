using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NamespaceName
        : ITypeNameContainer, IEquatable<NamespaceName>
    {
        public NamespaceName(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; set; }

        public bool IsImported { get; set; }

        public int AppendCommentNameTo(StringBuilder builder, FormatterContext context)
            => AppendSimplifiedNameTo(builder, context);

        public int AppendFullNameTo(StringBuilder builder, FormatterContext context)
        {
            var start = builder.Length;
            builder.Append(FullName);
            return builder.Length - start;
        }

        public int AppendNameTo(StringBuilder builder, FormatterContext context)
            => AppendSimplifiedNameTo(builder, context);

        public override bool Equals(object obj)
            => Equals(obj as NamespaceName);

        public bool Equals(NamespaceName other)
            => !ReferenceEquals(other, null)
            && FullName == other.FullName;

        public override int GetHashCode()
            => FullName.GetHashCode();

        public override string ToString()
            => FullName;

        private int AppendSimplifiedNameTo(StringBuilder builder, FormatterContext context)
        {
            if (IsImported)
            {
                return 0;
            }

            var start = builder.Length;
            // TODO: Append declared part
            return builder.Length - start;
        }
    }
}
