using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    partial class CSharpTypeFormatter
    {

        private abstract class FormatterContext
        {
            protected FormatterContext()
            { }

            protected FormatterContext(DeclaredNamespaceName declaredNamespaceName)
            {
                DeclaredNamespaceName = DeclaredNamespaceName;
            }
            protected internal int ImportedNamespaceCount { get; protected set; }
            public abstract bool IsImported(string namespaceName);
            public abstract void Import(string namespaceName);

            public DeclaredNamespaceName DeclaredNamespaceName { get; }

            public FormatterContext BeginNamespace(string namespaceName)
                => new NamespaceDeclarationFormatterContext(this, namespaceName);

            public virtual FormatterContext EndNamespace()
            {
                throw new NotSupportedException();
            }

            public abstract TypeName GetTypeName(Type type);

        }

        private class RootFormatterContext
            : FormatterContext
        {
            private string[] ImportedNamespaces { get; set; } = new string[8];
            private TypeNameCollection TypeNames { get; } = new TypeNameCollection()
            {
                PrimitiveTypeName.@string,
                PrimitiveTypeName.@void,
                PrimitiveTypeName.@bool,
                PrimitiveTypeName.@byte,
                PrimitiveTypeName.@short,
                PrimitiveTypeName.@int,
                PrimitiveTypeName.@long,
                PrimitiveTypeName.@sbyte,
                PrimitiveTypeName.@ushort,
                PrimitiveTypeName.@uint,
                PrimitiveTypeName.@ulong,
                PrimitiveTypeName.@decimal,
                PrimitiveTypeName.@float,
                PrimitiveTypeName.@double,
                PrimitiveTypeName.@char,
                PrimitiveTypeName.@object,
            };

            public override bool IsImported(string namespaceName)
            {
                var namespaces = ImportedNamespaces;
                for (int i = 0; i < namespaces.Length; i++)
                {
                    if (namespaces[i] == namespaceName) return true;
                }
                return false;
            }

            public override void Import(string namespaceName)
            {
                var namespaces = ImportedNamespaces;
                if (namespaces.Length < ImportedNamespaceCount)
                {
                    namespaces[ImportedNamespaceCount++] = namespaceName;
                }
                else
                {
                    var expanded = new string[namespaces.Length + 4];
                    namespaces.CopyTo(expanded, 0);
                    expanded[ImportedNamespaceCount++] = namespaceName;
                    ImportedNamespaces = expanded;
                }
            }
            public override TypeName GetTypeName(Type type)
            {
                TypeName value;
                if (!TypeNames.TryGetValue(type, out value))
                {
                    if (type.HasElementType)
                    {
                        if (type.IsArray)
                        {
                            value = ArrayTypeName.Create(type, this);
                        }
                        else if (type.IsPointer)
                        {
                            value = new PointerTypeName(type, GetTypeName(type.GetElementType()));
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }
                    }
                    else if (type.IsGenericParameter)
                    {
                        value = new GenericParameterTypeName(type);
                    }
                    else if (type.IsNested)
                    {
                        var args = type.GenericTypeArguments;
                        if (0 < args.Length)
                        {
                            value = new GenericTypeName(GetTypeName(type.DeclaringType), type, GetTypeNames(args));
                        }
                        else
                        {
                            value = new NonGenericTypeName(GetTypeName(type.DeclaringType), type);
                        }
                    }
                    else
                    {
                        var args = type.GenericTypeArguments;
                        if (0 < args.Length)
                        {
                            value = new GenericTypeName(type, GetTypeNames(args));
                        }
                        else
                        {
                            value = new NonGenericTypeName(type);
                        }
                    }
                    TypeNames.Add(value);
                }
                return value;
            }
            private TypeName[] GetTypeNames(Type[] types)
            {
                var result = new TypeName[types.Length];
                for (int i = 0; i < types.Length; i++)
                {
                    result[i] = GetTypeName(types[i]);
                }
                return result;
            }
            
        }

        private class NamespaceDeclarationFormatterContext
            : FormatterContext
        {
            public NamespaceDeclarationFormatterContext(FormatterContext parent, string namespaceName)
                : base(parent.DeclaredNamespaceName == null ? new DeclaredNamespaceName(namespaceName) : new DeclaredNamespaceName(parent.DeclaredNamespaceName, namespaceName))
            {
                Parent = parent;
                ImportedNamespaceCount = parent.ImportedNamespaceCount;
            }
            private FormatterContext Parent { get; }
            public override void Import(string namespaceName)
            {
                Parent.Import(namespaceName);
                ImportedNamespaceCount++;
            }

            public override bool IsImported(string namespaceName)
                => Parent.IsImported(namespaceName);
            public override FormatterContext EndNamespace()
                => Parent;

            public override TypeName GetTypeName(Type type)
                => Parent.GetTypeName(type);
        }

        private sealed class NamespaceDeclaration
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
}
