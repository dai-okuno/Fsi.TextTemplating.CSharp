using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNonParameterized
        : TypeNameTestBase
    {
        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<System.Int32, System.DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public void AliasName(string expected, Type type)
        {
            AppendAliasNameTo(expected, type);
            AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List{T}.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary{int, DateTime}.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public void CRefName(string expected, Type type)
        {
            AppendCRefNameTo(expected, type);
            CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.Threading.CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, System.DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public void FullName(string expected, Type type)
        {
            AppendFullNameTo(expected, type);
            FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public void Name(string expected, Type type)
        {
            AppendNameTo(expected, type);
            NameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("CancellationToken", typeof(CancellationToken))]
        [InlineData("System.Threading.Tasks.ParallelLoopResult", typeof(System.Threading.Tasks.ParallelLoopResult))]
        [InlineData("System.Collections.Generic.List<>.Enumerator", typeof(System.Collections.Generic.List<>.Enumerator))]
        [InlineData("System.Collections.Generic.Dictionary<int, DateTime>.Enumerator", typeof(System.Collections.Generic.Dictionary<int, DateTime>.Enumerator))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.NonParameterizedChild))]
        public void TypeOfName(string expected, Type type)
        {
            AppendTypeOfNameTo(expected, type);
            TypeOfNameOf(expected, type);
        }

    }
}
