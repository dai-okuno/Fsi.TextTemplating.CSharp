using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestArray
        : TypeNameTest
    {

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("int[,]", typeof(int[,]))]
        [InlineData("int[,,]", typeof(int[,,]))]
        [InlineData("int[,,,]", typeof(int[,,,]))]
        [InlineData("int[][,]", typeof(int[][,]))]
        [InlineData("int[][,][,,]", typeof(int[][,][,,]))]
        public void Ranks(string expected, Type type)
        {
            base.NameOf(expected, type);
        }
        [Theory]
        [InlineData("System.DateTime[]", typeof(DateTime[]))]
        [InlineData("System.Threading.CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List<System.Int32>.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("System.Func<System.Int32>[]", typeof(Func<int>[]))]
        public override void AppendAliasNameTo(string expected, Type type)
        {
            base.AppendAliasNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime[]", typeof(DateTime[]))]
        [InlineData("System.Threading.CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List<System.Int32>.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("System.Func<System.Int32>[]", typeof(Func<int>[]))]
        public override void AliasNameOf(string expected, Type type)
        {
            base.AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime[]", typeof(DateTime[]))]
        [InlineData("CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List{int}.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("Func{int}[]", typeof(Func<int>[]))]
        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }

        [Theory]
        [InlineData("DateTime[]", typeof(DateTime[]))]
        [InlineData("CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List{int}.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("Func{int}[]", typeof(Func<int>[]))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime[]", typeof(DateTime[]))]
        [InlineData("System.Threading.CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("System.Func<int>[]", typeof(Func<int>[]))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime[]", typeof(DateTime[]))]
        [InlineData("System.Threading.CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("System.Func<int>[]", typeof(Func<int>[]))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime[]", typeof(DateTime[]))]
        [InlineData("CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("Func<int>[]", typeof(Func<int>[]))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("DateTime[]", typeof(DateTime[]))]
        [InlineData("CancellationToken[]", typeof(CancellationToken[]))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult[]", typeof(System.Threading.Tasks.ParallelLoopResult[]))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator[]", typeof(System.Collections.Generic.List<int>.Enumerator[]))]
        [InlineData("Func<int>[]", typeof(Func<int>[]))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
        }

    }
}
