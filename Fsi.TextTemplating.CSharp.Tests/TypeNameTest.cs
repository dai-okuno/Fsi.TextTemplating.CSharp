using System;
using System.Text;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTest
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
        protected void AppendTypeOfNameTo(string expected,Type type)
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
        protected void AliasNameOf(string expected,Type type)
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

