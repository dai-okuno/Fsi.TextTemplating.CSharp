using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNonParameterized
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<System.Int32, System.DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void AppendAliasNameTo(string expected, Type type)
        {
            base.AppendAliasNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<System.Int32, System.DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void AliasNameOf(string expected, Type type)
        {
            base.AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List{T}.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary{int, DateTime}.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List{T}.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary{int, DateTime}.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, System.DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, System.DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
        }
    }
}
