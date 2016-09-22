using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNullable
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.Nullable<System.DateTime>", typeof(DateTime?))]
        [InlineData("System.Nullable<System.Threading.CancellationToken>", typeof(CancellationToken?))]
        [InlineData("System.Nullable<System.Threading.Tasks.ParallelLoopResult>", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Nullable<System.Collections.Generic.List<System.Int32>.Enumerator>", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void AppendAliasNameTo(string expected, Type type)
        {
            base.AppendAliasNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.Nullable<System.DateTime>", typeof(DateTime?))]
        [InlineData("System.Nullable<System.Threading.CancellationToken>", typeof(CancellationToken?))]
        [InlineData("System.Nullable<System.Threading.Tasks.ParallelLoopResult>", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Nullable<System.Collections.Generic.List<System.Int32>.Enumerator>", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void AliasNameOf(string expected, Type type)
        {
            base.AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("Nullable{DateTime}", typeof(DateTime?))]
        [InlineData("Nullable{CancellationToken}", typeof(CancellationToken?))]
        [InlineData("Nullable{System.Threading.Tasks.ParallelLoopResult}", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("Nullable{System.Collections.Generic.List{int}.Enumerator}", typeof(System.Collections.Generic.List<int>.Enumerator?))]

        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }

        [Theory]
        [InlineData("Nullable{DateTime}", typeof(DateTime?))]
        [InlineData("Nullable{CancellationToken}", typeof(CancellationToken?))]
        [InlineData("Nullable{System.Threading.Tasks.ParallelLoopResult}", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("Nullable{System.Collections.Generic.List{int}.Enumerator}", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime?", typeof(DateTime?))]
        [InlineData("System.Threading.CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime?", typeof(DateTime?))]
        [InlineData("System.Threading.CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime?", typeof(DateTime?))]
        [InlineData("CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("DateTime?", typeof(DateTime?))]
        [InlineData("CancellationToken?", typeof(CancellationToken?))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult?", typeof(System.Threading.Tasks.ParallelLoopResult?))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator?", typeof(System.Collections.Generic.List<int>.Enumerator?))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
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
    }
}
