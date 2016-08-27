using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal class NamespaceName
        : INamespaceName
    {
        public NamespaceName(INamespaceName parent, string fullName)
        {
            Depth = parent.Depth + 1;
            FullName = fullName;
            Name = fullName.Substring(parent.FullName.Length + 1);
            Parent = parent;
            Root = parent.IsGlobal ? this : parent.Root;
        }

        private int _ImportedCount;

        public int Depth { get; }

        public string FullName { get; }
        public bool IsDeclared { get; set; }
        public bool IsGlobal
            => false;

        public bool IsImported
        {
            get { return 0 < _ImportedCount; }
        }

        public bool IsRoot
            => Depth == 1;

        public string Name { get; }

        public INamespaceName Root { get; }

        public INamespaceName Parent { get; }

        private string CachedName { get; set; }

        private IFormatterContext CachedContext { get; set; }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(typeName, context);
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public void AppendFullNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(FullName);
        }

        /// <summary></summary>
        /// <param name="typeName"></param>
        /// <param name="context"></param>
        public void AppendNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (IsImported) return;
            if (CachedContext != context)
            {
                if (!context.NamespaceName.IsGlobal && context.NamespaceName.Root.IsDeclared)
                {
                    var offset = typeName.Length;
                    AppendContainerName(this, typeName);
                    CachedName = typeName.ToString(offset, typeName.Length - offset);
                }
                else
                {
                    CachedName = FullName;
                }
                CachedContext = context;
            }
            typeName.Append(CachedName);
        }

        public void BeginImport()
        {
            _ImportedCount++;
        }

        public void EndImport()
        {
            _ImportedCount--;
        }

        public override bool Equals(object obj)
            => Equals(obj as INamespaceName);

        public bool Equals(INamespaceName other)
            => ReferenceEquals(other, this)
            || (!ReferenceEquals(other, null)
                && FullName == other.FullName);

        public override int GetHashCode()
            => FullName.GetHashCode();

        public override string ToString()
            => FullName;
        private void AppendContainerName(INamespaceName namespaceName, StringBuilder typeName)
        {
            if (namespaceName.IsDeclared || namespaceName.IsGlobal) return;
            AppendContainerName(namespaceName.Parent, typeName);
            typeName.Append(Name).Append('.');
        }

    }
}
