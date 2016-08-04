using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {
        private class NamespaceName
            : ISimplify, IEquatable<NamespaceName>
        {
            private NamespaceName(string fullName)
            {
                FullName = fullName;
            }

            private string FullName { get; set; }

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
                if (context.IsImported(FullName))
                {
                    return 0;
                }

                var start = builder.Length;
                return builder.Length - start;
            }
        }

        private class DeclaredNamespaceName
        {
            public DeclaredNamespaceName(string fullName)
            {
                FullName = fullName;
                var parts = fullName.Split(NameSplitter);
                Parts = new NamespacePart[parts.Length];
                var buffer = new StringBuilder(fullName.Length);
                for (int i = 0; i < parts.Length; i++)
                {
                    Parts[i] = new NamespacePart(buffer, parts[i]);
                }
            }
            public DeclaredNamespaceName(DeclaredNamespaceName parent, string name)
            {
                var parts = name.Split(NameSplitter);
                Parts = new NamespacePart[parent.Parts.Length + parts.Length];
                parent.Parts.CopyTo(Parts, 0);

            }

            private static char[] NameSplitter { get; } = new[] { '.' };
            private string FullName { get; }

            private NamespacePart[] Parts { get; }

            public int AppendTo(string namespaceName, StringBuilder builder)
            {
                if (FullName == namespaceName)
                {
                    return 0;
                }
                if (!Parts[0].StartsWith(namespaceName))
                {
                    builder.Append(namespaceName);
                    return namespaceName.Length;
                }
                for (int i = 1; i < Parts.Length - 1; i++)
                {
                    if (!Parts[i].StartsWith(namespaceName))
                    {
                        var partialName = namespaceName.Substring(Parts[i - 1].FullName.Length + 1);
                        builder.Append(partialName);
                        return partialName.Length;
                    }
                }
                throw new Exception($"logic error:{typeof(DeclaredNamespaceName).FullName}.{nameof(AppendTo)}");
            }
            public override string ToString()
            {
                return FullName;
            }
            private class NamespacePart
            {
                public NamespacePart(StringBuilder buffer, string name)
                {
                    FullName = buffer.Append('.').Append(name).ToString();
                    Name = name;
                }
                public string FullName { get; }
                public string Name { get; }

                public bool StartsWith(string namespaceName)
                    => namespaceName.StartsWith(FullName)
                    && (namespaceName.Length == FullName.Length
                        || namespaceName[FullName.Length] == '.');
            }
        }

    }
}
