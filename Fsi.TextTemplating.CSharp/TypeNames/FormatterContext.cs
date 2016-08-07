using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{

    internal abstract class FormatterContext
    {
        protected FormatterContext()
        { }

        protected List<NamespaceName> ImportedNamespaceNames { get; }
            = new List<NamespaceName>();

        public void Import(string namespaceName)
        {
            var imported = GetNamespaceName(namespaceName);
            imported.IsImported = true;
            ImportedNamespaceNames.Add(imported);
        }

        public FormatterContext BeginNamespace(string namespaceName)
            => new NamespaceDeclarationFormatterContext(this, namespaceName);

        public virtual FormatterContext EndNamespace()
        {
            throw new NotSupportedException();
        }
        public abstract NamespaceName GetNamespaceName(string namespaceName);

        public abstract TypeName GetTypeName(Type type);

    }


    internal class NamespaceDeclarationFormatterContext
            : FormatterContext
    {
        public NamespaceDeclarationFormatterContext(FormatterContext parent, string namespaceName)
        {
            Parent = parent;
            DeclaredNamespaceName = parent.GetNamespaceName(namespaceName);
        }

        private FormatterContext Parent { get; }

        private NamespaceName DeclaredNamespaceName { get; }

        public override FormatterContext EndNamespace()
            => Parent;

        public override NamespaceName GetNamespaceName(string namespaceName)
            => Parent.GetNamespaceName(namespaceName);

        public override TypeName GetTypeName(Type type)
            => Parent.GetTypeName(type);
    }

    internal sealed class NamespaceDeclaration
        : IDisposable
    {
        public NamespaceDeclaration(CSharpTypeFormatter formatter)
        {
            Formatter = formatter;
        }

        private const int Disposed = 1;

        private const int NotDisposed = 0;

        private int _IsDisposed;
        private CSharpTypeFormatter Formatter { get; }
        public void Dispose()
        {
            if (System.Threading.Interlocked.CompareExchange(ref _IsDisposed, Disposed, NotDisposed) != NotDisposed) return;
            Formatter.EndNamespace();
        }
    }

}
