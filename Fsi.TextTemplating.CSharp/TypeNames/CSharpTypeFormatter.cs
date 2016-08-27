using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating.TypeNames
{
    internal partial class CSharpTypeFormatter
    {
        private IFormatterContext Context { get; set; } = new SourceFileFormatterContext();

        public void AppendCRefTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Context.GetTypeName(type).AppendCRefNameTo(typeName, Context);
        }
        public void AppendFullNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Context.GetTypeName(type).AppendFullNameTo(typeName, Context);
        }

        public void AppendNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Context.GetTypeName(type).AppendNameTo(typeName, Context);
        }

        public IDisposable BeginNamespace(string namespaceName)
        {
            var context = new NamespaceDeclarationFormatterContext(Context, namespaceName);
            Context = context;
            var declared = Context.NamespaceName;
            do
            {
                declared.IsDeclared = true;
            } while ((declared = declared.Parent) != Context.Parent.NamespaceName);
            return new NamespaceDeclaration(this);
        }
        public string CRefOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Context.GetTypeName(type).GetCRefName(Context);
        }
        public string Default(Type type)
        {
            var builder = new StringBuilder();
            builder.Append("default(");
            AppendNameTo(type, builder);
            builder.Append(')');
            return builder.ToString();
        }

        public string FullNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Context.GetTypeName(type).GetFullName(Context);
        }

        public void Import(string namespaceName)
        {
            Context.Import(namespaceName).BeginImport();
        }

        public string NameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Context.GetTypeName(type).GetName(Context);
        }

        internal void EndNamespace()
        {
            foreach (var imported in Context.ImportedNamespaceNames)
            {
                imported.EndImport();
            }
            var declared = Context.NamespaceName;
            do
            {
                declared.IsDeclared = false;
            } while ((declared = declared.Parent) != Context.Parent.NamespaceName);
            Context = Context.Parent;
        }
        private sealed class NamespaceDeclaration
            : IDisposable
        {
            public NamespaceDeclaration(CSharpTypeFormatter formatter)
            {
                Formatter = formatter;
            }
            private CSharpTypeFormatter Formatter { get; }

            private bool IsDisposed { get; set; }

            public void Dispose()
            {
                if (IsDisposed) return;
                IsDisposed = true;
                Formatter.EndNamespace();
                GC.SuppressFinalize(this);
            }
        }
    }
}
