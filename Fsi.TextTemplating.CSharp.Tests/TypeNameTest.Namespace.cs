using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNamespace
    {
        [Theory]
        [InlineData("int", typeof(int))]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("TextTemplating.CSharp.Tests.NamespaceA", typeof(NamespaceA))]
        [InlineData("TextTemplating.NamespaceB", typeof(NamespaceB))]
        [InlineData("NamespaceC", typeof(NamespaceC))]
        [InlineData("Collections.NamespaceD", typeof(Collections.NamespaceD))]
        public void Declare1(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            using (csharp.BeginNamespace("Fsi"))
            {
                Assert.Equal(expected, csharp.NameOf(type));
            }
        }
        [Theory]
        [InlineData("int", typeof(int))]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("CSharp.Tests.NamespaceA", typeof(NamespaceA))]
        [InlineData("NamespaceB", typeof(NamespaceB))]
        [InlineData("NamespaceC", typeof(NamespaceC))]
        [InlineData("Collections.NamespaceD", typeof(Collections.NamespaceD))]
        public void Declare2(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            using (csharp.BeginNamespace("Fsi.TextTemplating"))
            {
                Assert.Equal(expected, csharp.NameOf(type));
            }
        }
        [Theory]
        [InlineData("int", typeof(int))]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("CSharp.Tests.NamespaceA", typeof(NamespaceA))]
        [InlineData("NamespaceB", typeof(NamespaceB))]
        [InlineData("NamespaceC", typeof(NamespaceC))]
        [InlineData("Collections.NamespaceD", typeof(Collections.NamespaceD))]
        public void DeclareNested(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            using (csharp.BeginNamespace("Fsi"))
            {
                using (csharp.BeginNamespace("TextTemplating"))
                {
                    Assert.Equal(expected, csharp.NameOf(type));
                }
            }
        }
        [Theory]
        [InlineData("int", typeof(int))]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.Task", typeof(Task))]
        [InlineData("System.Collections.Generic.List<T>", typeof(List<>))]
        public void ImportAtGlobal(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.NameOf(type));
        }
        [Theory]
        [InlineData("int", "int", typeof(int))]
        [InlineData("System.DateTime", "DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", "CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.Task", "System.Threading.Tasks.Task", typeof(Task))]
        [InlineData("System.Collections.Generic.List<T>", "System.Collections.Generic.List<T>", typeof(List<>))]
        public void ImportInNamespace(string atGlobal, string inNamespace, Type type)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(atGlobal, csharp.NameOf(type));
            using (csharp.BeginNamespace("Fsi"))
            {
                csharp.Import("System");
                csharp.Import("System.Threading");
                Assert.Equal(inNamespace, csharp.NameOf(type));
            }
            Assert.Equal(atGlobal, csharp.NameOf(type));
            using (csharp.BeginNamespace("Fsi"))
            {
                csharp.Import("System");
                csharp.Import("System.Threading");
                Assert.Equal(inNamespace, csharp.NameOf(type));
            }
        }

        [Theory]
        [InlineData("int", "int", "int", typeof(int))]
        [InlineData("System.DateTime", "DateTime", "DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", "System.Threading.CancellationToken", "CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.Task", "System.Threading.Tasks.Task", "System.Threading.Tasks.Task", typeof(Task))]
        [InlineData("System.Collections.Generic.List<T>", "System.Collections.Generic.List<T>", "System.Collections.Generic.List<T>", typeof(List<>))]
        public void ImportInNestedNamespace(string atGlobal, string inNamespace, string inNestedNamespace, Type type)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(atGlobal, csharp.NameOf(type));
            using (csharp.BeginNamespace("Fsi"))
            {
                csharp.Import("System");
                Assert.Equal(inNamespace, csharp.NameOf(type));
                using (csharp.BeginNamespace("TextTemplating"))
                {
                    csharp.Import("System.Threading");
                    Assert.Equal(inNestedNamespace, csharp.NameOf(type));
                }
            }
            Assert.Equal(atGlobal, csharp.NameOf(type));
            using (csharp.BeginNamespace("Fsi"))
            {
                csharp.Import("System");
                Assert.Equal(inNamespace, csharp.NameOf(type));
                using (csharp.BeginNamespace("TextTemplating"))
                {
                    csharp.Import("System.Threading");
                    Assert.Equal(inNestedNamespace, csharp.NameOf(type));
                }
            }
        }
    }
    internal class NamespaceA
    {

    }
}
namespace Fsi.TextTemplating
{
    internal class NamespaceB
    {

    }
}
namespace Fsi
{
    internal class NamespaceC
    {

    }
}
namespace Fsi.Collections
{
    internal class NamespaceD
    {

    }
}
