using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNullable
        : TypeNameTestBase
    {
        [Theory]
        [InlineData("System.Nullable<System.DateTime>", typeof(DateTime?))]
        [InlineData("System.Nullable<System.Threading.CancellationToken>", typeof(CancellationToken?))]
        [InlineData("System.Nullable<System.Threading.Tasks.ParallelLoopResult>", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Nullable<System.Collections.Generic.List<System.Int32>.Enumerator>", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public void AliasName(string expected, Type type)
        {
            AppendAliasNameTo(expected, type);
            AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("Nullable{DateTime}", typeof(DateTime?))]
        [InlineData("Nullable{CancellationToken}", typeof(CancellationToken?))]
        [InlineData("Nullable{System.Threading.Tasks.ParallelLoopResult}", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("Nullable{System.Collections.Generic.List{int}.Enumerator}", typeof(System.Collections.Generic.List<int>.Enumerator?))]

        public void CRefName(string expected, Type type)
        {
            AppendCRefNameTo(expected, type);
            CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.Nullable{System.DateTime}", typeof(DateTime?))]
        [InlineData("System.Nullable{CancellationToken}", typeof(CancellationToken?))]
        [InlineData("System.Nullable{System.Threading.Tasks.ParallelLoopResult}", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Nullable{System.Collections.Generic.List{int}.Enumerator}", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public void CRefNameOfWithoutSystemNamespace(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System.Threading");
            Assert.Equal(expected, csharp.CRefNameOf(type));
            Assert.Equal(expected, csharp.CRefNameOf(type));
        }

        [Theory]
        [InlineData("System.DateTime?", typeof(DateTime?))]
        [InlineData("System.Threading.CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public void FullName(string expected, Type type)
        {
            AppendFullNameTo(expected, type);
            FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime?", typeof(DateTime?))]
        [InlineData("CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public void Name(string expected, Type type)
        {
            AppendNameTo(expected, type);
            NameOf(expected, type);
        }
        [Theory]
        [InlineData("DateTime?", typeof(DateTime?))]
        [InlineData("CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public void TypeOfName(string expected, Type type)
        {
            AppendTypeOfNameTo(expected, type);
            TypeOfNameOf(expected, type);
        }

    }
}
