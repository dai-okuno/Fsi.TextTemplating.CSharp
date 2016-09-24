using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    [System.Diagnostics.DebuggerDisplay("{FullName}")]
    internal class NamespaceName
        : INamespaceName
    {
        public NamespaceName(INamespaceName parent, string fullName)
        {
            FullName = fullName;
            Parent = parent;
            if (parent.IsGlobal)
            {
                Root = this;
            }
            else
            {
                Root = parent.Root;
            }
        }

        private int _ImportedCount;
        
        public string FullName { get; }
        public bool IsDeclared { get; set; }
        public bool IsGlobal
            => false;

        public bool IsImported
        {
            get { return 0 < _ImportedCount; }
        }
        
        public INamespaceName Root { get; }

        public INamespaceName Parent { get; }

        private string CachedName { get; set; }

        private IFormatterContext CachedContext { get; set; }
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public void AppendAliasNameTo(StringBuilder typeName, IFormatterContext context)
        {
            typeName.Append(FullName);
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public void AppendCRefNameTo(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(typeName, context);
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        public void AppendFullNameTo(StringBuilder typeName)
        {
            typeName.Append(FullName);
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public void AppendNameTo(StringBuilder typeName, IFormatterContext context)
        {
            if (IsImported) return;
            if (CachedContext != context)
            {
                if (context.NamespaceName.IsGlobal || Root != context.NamespaceName.Root)
                {
                    CachedName = FullName;
                }
                else if (IsDeclared)
                {
                    CachedName = string.Empty;
                }
                else
                {
                    var anscestor = Parent;
                    for (; ; anscestor = anscestor.Parent)
                    {
                        if (anscestor.IsDeclared)
                        {
                            CachedName = FullName.Substring(anscestor.FullName.Length + 1);
                            break;
                        }
                        else if (anscestor.IsGlobal)
                        {
                            CachedName = FullName;
                            break;
                        }
                    }
                }
                CachedContext = context;
                typeName.Append(CachedName);
            }
            else
            {
                typeName.Append(CachedName);
            }
        }
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        public void AppendTypeOfNameTo(StringBuilder typeName, IFormatterContext context)
        {
            AppendNameTo(typeName, context);
        }
        public void BeginImport()
        {
            _ImportedCount++;
        }

        public void EndImport()
        {
            _ImportedCount--;
        }

        public override int GetHashCode()
            => FullName.GetHashCode();


    }
}
