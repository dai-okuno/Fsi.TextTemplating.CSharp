using System;
using System.Text;
using System.Reflection;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTest
    {

        [Fact]
        public void AliasNameArgNull()
        {
            var csharp = new CSharpHelper();
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.AppendAliasNameTo(default(Type), new StringBuilder()); });
            Assert.Throws<ArgumentNullException>("typeName",
                () => { csharp.AppendAliasNameTo(typeof(int), default(StringBuilder)); });
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.AliasNameOf(default(Type)); });
        }

        [Fact]
        public void CRefNameArgNull()
        {
            var csharp = new CSharpHelper();
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.AppendCRefNameTo(default(Type), new StringBuilder()); });
            Assert.Throws<ArgumentNullException>("typeName",
                () => { csharp.AppendCRefNameTo(typeof(int), default(StringBuilder)); });
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.CRefNameOf(default(Type)); });
        }

        [Fact]
        public void FullNameArgNull()
        {
            var csharp = new CSharpHelper();
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.AppendFullNameTo(default(Type), new StringBuilder()); });
            Assert.Throws<ArgumentNullException>("typeName",
                () => { csharp.AppendFullNameTo(typeof(int), default(StringBuilder)); });
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.FullNameOf(default(Type)); });
        }

        [Fact]
        public void NameArgNull()
        {
            var csharp = new CSharpHelper();
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.AppendNameTo(default(Type), new StringBuilder()); });
            Assert.Throws<ArgumentNullException>("typeName",
                () => { csharp.AppendNameTo(typeof(int), default(StringBuilder)); });
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.NameOf(default(Type)); });
        }

        [Fact]
        public void TypeOfNameArgNull()
        {
            var csharp = new CSharpHelper();
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.AppendTypeOfNameTo(default(Type), new StringBuilder()); });
            Assert.Throws<ArgumentNullException>("typeName",
                () => { csharp.AppendTypeOfNameTo(typeof(int), default(StringBuilder)); });
            Assert.Throws<ArgumentNullException>("type",
                () => { csharp.TypeOfNameOf(default(Type)); });
        }

        [Fact]
        public void ByRefType()
        {
            var csharp = new CSharpHelper();
            Assert.Throws(typeof(NotSupportedException),
                () => { csharp.NameOf(typeof(int).MakeByRefType()); });

        }

        [Fact]
        public void NamespaceDisposeTwice()
        {
            var csharp = new CSharpHelper();
            using (var ns = csharp.BeginNamespaceDeclaration("Fsi"))
            {
                ns.Dispose();
            }
            Assert.Equal("int", csharp.NameOf(typeof(int)));
        }
        [Fact]
        public void GenericParameterTypeName()
        {
            var parameters = typeof(Func<,,,,>).GetTypeInfo().GenericTypeParameters;
            var csharp = new CSharpHelper();
            Assert.Equal("T1", csharp.AliasNameOf(parameters[0]));
            Assert.Equal("T2", csharp.CRefNameOf(parameters[1]));
            Assert.Equal("T3", csharp.FullNameOf(parameters[2]));
            Assert.Equal("T4", csharp.NameOf(parameters[3]));
            Assert.Equal(string.Empty, csharp.TypeOfNameOf(parameters[4]));
        }
    }
    public class TypeNameTestBase
    {

        protected void AppendAliasNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            var typeName = new StringBuilder(type.FullName.Length);
            csharp.AppendAliasNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendAliasNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        protected void AppendCRefNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            var typeName = new StringBuilder(type.FullName.Length);
            csharp.AppendCRefNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendCRefNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        protected void AppendFullNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            var typeName = new StringBuilder(type.FullName.Length);
            csharp.AppendFullNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendFullNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        protected void AppendNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            var typeName = new StringBuilder(type.Name.Length);
            csharp.AppendNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        protected void AppendTypeOfNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            var typeName = new StringBuilder(type.Name.Length);
            csharp.AppendTypeOfNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendTypeOfNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        protected void AliasNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.AliasNameOf(type));
            Assert.Equal(expected, csharp.AliasNameOf(type));
        }
        protected void CRefNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.CRefNameOf(type));
            Assert.Equal(expected, csharp.CRefNameOf(type));
        }
        protected void FullNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.FullNameOf(type));
            Assert.Equal(expected, csharp.FullNameOf(type));
        }
        protected void NameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.NameOf(type));
            Assert.Equal(expected, csharp.NameOf(type));
        }

        protected void TypeOfNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.TypeOfNameOf(type));
            Assert.Equal(expected, csharp.TypeOfNameOf(type));
        }
    }


    internal class NonParameterized
    {
        internal class ParameterizedChild<U1, U2>
        {
        }
        internal class NonParameterizedChild
        {

        }
    }
    internal class Parameterized<T1>
    {
        internal class ParameterizedChild<U1>
        {
        }
        internal class NonParameterizedChild
        {

        }
    }
}

