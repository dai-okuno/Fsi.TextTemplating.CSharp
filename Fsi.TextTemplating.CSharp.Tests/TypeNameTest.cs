using System;
using System.Text;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTest
    {
        public virtual void AppendAliasNameTo(string expected, Type type)
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
        public virtual void AppendCRefNameTo(string expected, Type type)
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
        public virtual void AppendFullNameTo(string expected, Type type)
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
        public virtual void AppendNameTo(string expected, Type type)
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

        public virtual void AliasNameOf(string expected,Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.AliasNameOf(type));
            Assert.Equal(expected, csharp.AliasNameOf(type));
        }
        public virtual void CRefNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.CRefNameOf(type));
            Assert.Equal(expected, csharp.CRefNameOf(type));
        }
        public virtual void FullNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.FullNameOf(type));
            Assert.Equal(expected, csharp.FullNameOf(type));
        }
        public virtual void NameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.NameOf(type));
            Assert.Equal(expected, csharp.NameOf(type));
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

