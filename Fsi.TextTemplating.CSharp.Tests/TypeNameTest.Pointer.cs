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
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("System.Func<int>*", typeof(Func<int>))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("Func<int>*", typeof(Func<int>))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("System.DateTime*", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("System.Func<int>*", typeof(Func<int>))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("CancellationToken*", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult*", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<int>.Enumerator*", typeof(System.Collections.Generic.List<int>.Enumerator))]
        [InlineData("Func<int>*", typeof(Func<int>))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type.MakePointerType());
        }
    }
}
