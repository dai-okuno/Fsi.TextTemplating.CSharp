using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    public partial class CSharpTypeFormatter
    {
        private FormatterContext Context { get; set; }

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
            Context = Context.BeginNamespace(namespaceName);

            return new NamespaceDeclaration(this);
        }

        private void EndNamespace()
        {
            Context = Context.EndNamespace();
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
            Context.Import(namespaceName);
        }

        public string NameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Context.GetTypeName(type).GetName(Context);
        }

    }
}
