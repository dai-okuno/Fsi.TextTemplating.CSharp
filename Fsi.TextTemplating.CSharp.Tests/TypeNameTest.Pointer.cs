using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestPointer
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.DateTime*", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<System.Int32>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("System.Func<System.Int32>*", typeof(Func<int>))]
        public void AliasName(string expected, Type type)
        {
            AppendAliasNameTo(expected, type.MakePointerType());
            AliasNameOf(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List{int}.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("Func{int}*", typeof(Func<int>))]
        public void CRefName(string expected, Type type)
        {
            AppendCRefNameTo(expected, type.MakePointerType());
            CRefNameOf(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("System.DateTime*", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("System.Func<int>*", typeof(Func<int>))]
        public void FullName(string expected, Type type)
        {
            AppendFullNameTo(expected, type.MakePointerType());
            FullNameOf(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("Func<int>*", typeof(Func<int>))]
        public void Name(string expected, Type type)
        {
            AppendNameTo(expected, type.MakePointerType());
            NameOf(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("Func<int>*", typeof(Func<int>))]
        public void TypeOfName(string expected, Type type)
        {
            AppendTypeOfNameTo(expected, type.MakePointerType());
            TypeOfNameOf(expected, type.MakePointerType());
        }

    }
}
