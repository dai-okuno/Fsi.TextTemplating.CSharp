using System;
using System.Text;

namespace Fsi.TextTemplating
{
    using TypeNames;
    partial class CSharpHelper
    {
        private FlyweightFactory Factory { get; }
        /// <summary></summary>
        private IFormatterContext Context { get; set; }
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendAliasNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendAliasNameTo(typeName, Context);
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendCRefNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendCRefNameTo(typeName, Context);
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendFullNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendFullNameTo(typeName);
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendNameTo(typeName, Context);
        }
        public void AppendTypeOfNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendTypeOfNameTo(typeName, Context);
        }
        /// <summary>
        /// Begin namespace declaration with specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDisposable BeginNamespaceDeclaration(string name)
        {
            var namespaceName = Factory.GetNamespaceName(
                Context.NamespaceName.IsGlobal
                ? name
                : (new StringBuilder(Context.NamespaceName.FullName.Length + 1 + name.Length).Append(Context.NamespaceName.FullName).Append('.').Append(name).ToString()));
            var context = new NamespaceDeclarationFormatterContext(Context, namespaceName);
            var declared = context.NamespaceName;
            do
            {
                declared.IsDeclared = true;
            } while ((declared = declared.Parent) != Context.NamespaceName);
            Context = context;
            return new NamespaceDeclaration(this);
        }
        /// <summary>
        /// Gets the name for type alias declaration.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string AliasNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetAliasName(Context);
        }
        /// <summary>
        /// Gets the name for cref attribute in document comment.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string CRefNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetCRefName(Context);
        }
        /// <summary>
        /// Gets the full name of this object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string FullNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetFullName();
        }
        /// <summary>
        /// Gets the hash code of this object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string TypeOfNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetTypeOfName(Context);
        }
        /// <summary></summary>
        /// <param name="namespaceName"></param>
        public void Import(string namespaceName)
        {
            var ns = Factory.GetNamespaceName(namespaceName);
            Context.Import(ns);
            ns.BeginImport();
        }
        /// <summary>
        /// Gets the name of this object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string NameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetName(Context);
        }

        /// <summary></summary>
        internal void EndNamespace()
        {
            foreach (var imported in Context.ImportedNamespaceNames)
            {
                imported.EndImport();
            }
            var context = Context;
            Context = context.Parent;
            var declared = context.NamespaceName;
            do
            {
                declared.IsDeclared = false;
            } while ((declared = declared.Parent) != Context.NamespaceName);
        }

        /// <summary></summary>
        private sealed class NamespaceDeclaration
            : IDisposable
        {
            /// <summary></summary>
            /// <param name="helper"></param>
            public NamespaceDeclaration(CSharpHelper helper)
            {
                Helper = helper;
            }

            /// <summary></summary>
            private CSharpHelper Helper { get; }

            /// <summary>Gets or sets this object is disposed.</summary>
            private bool IsDisposed { get; set; }

            /// <summary>Invoke <see cref="EndNamespace"/> of <see cref="ITypeFormatter"/>.</summary>
            public void Dispose()
            {
                if (IsDisposed) return;
                IsDisposed = true;
                Helper.EndNamespace();
                GC.SuppressFinalize(this);
            }
        }

    }
}
