using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTest
    {
        public virtual void AppendCRefNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
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
            csharp.Import("System.Collections");
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
            csharp.Import("System.Collections");
            var typeName = new StringBuilder(type.Name.Length);
            csharp.AppendNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }

        public virtual void CRefNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.CRefNameOf(type));
            Assert.Equal(expected, csharp.CRefNameOf(type));
        }
        public virtual void FullNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            Assert.Equal(expected, csharp.FullNameOf(type));
            Assert.Equal(expected, csharp.FullNameOf(type));
        }
        public virtual void NameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            Assert.Equal(expected, csharp.NameOf(type));
            Assert.Equal(expected, csharp.NameOf(type));
        }

        protected void Default(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            Assert.Equal(expected, csharp.Default(type));
            Assert.Equal(expected, csharp.Default(type));
        }
    }

}

