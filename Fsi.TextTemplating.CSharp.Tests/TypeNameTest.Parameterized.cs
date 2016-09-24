using System;
using System.Threading;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestParameterized
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.Func<TResult>", typeof(Func<>))]
        [InlineData("System.Func<System.Func<System.Int32>>", typeof(Func<Func<int>>))]
        [InlineData("System.Threading.AsyncLocal<System.Func<System.Int32>>", typeof(AsyncLocal<Func<int>>))]
        [InlineData("System.Threading.Tasks.Task<System.Func<System.Int32>>", typeof(System.Threading.Tasks.Task<Func<int>>))]
        [InlineData("System.Collections.Generic.Dictionary<System.String, System.Func<System.Int32>>", typeof(System.Collections.Generic.Dictionary<string, Func<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<T1>.ParameterizedChild<U1>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<>.ParameterizedChild<>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<System.Threading.CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<System.Int32>>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<U1, U2>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<,>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<System.Int32, System.Threading.Tasks.Task<System.DateTime>>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>))]
        public void AliasName(string expected, Type type)
        {
            AppendAliasNameTo(expected, type);
            AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("Func{TResult}", typeof(Func<>))]
        [InlineData("Func{Func{int}}", typeof(Func<Func<int>>))]
        [InlineData("AsyncLocal{Func{int}}", typeof(AsyncLocal<Func<int>>))]
        [InlineData("System.Threading.Tasks.Task{Func{int}}", typeof(System.Threading.Tasks.Task<Func<int>>))]
        [InlineData("System.Collections.Generic.Dictionary{string, Func{int}}", typeof(System.Collections.Generic.Dictionary<string, Func<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized{T1}.ParameterizedChild{U1}", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<>.ParameterizedChild<>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized{CancellationToken}.ParameterizedChild{System.Threading.Tasks.Task{int}}", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild{U1, U2}", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<,>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild{int, System.Threading.Tasks.Task{DateTime}}", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>))]
        public void CRefName(string expected, Type type)
        {
            AppendCRefNameTo(expected, type);
            CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.Func<TResult>", typeof(Func<>))]
        [InlineData("System.Func<System.Func<int>>", typeof(Func<Func<int>>))]
        [InlineData("System.Threading.AsyncLocal<System.Func<int>>", typeof(AsyncLocal<Func<int>>))]
        [InlineData("System.Threading.Tasks.Task<System.Func<int>>", typeof(System.Threading.Tasks.Task<Func<int>>))]
        [InlineData("System.Collections.Generic.Dictionary<string, System.Func<int>>", typeof(System.Collections.Generic.Dictionary<string, Func<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<T1>.ParameterizedChild<U1>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<>.ParameterizedChild<>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<System.Threading.CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<U1, U2>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<,>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<System.DateTime>>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>))]
        public void FullName(string expected, Type type)
        {
            AppendFullNameTo(expected, type);
            FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("Func<TResult>", typeof(Func<>))]
        [InlineData("Func<Func<int>>", typeof(Func<Func<int>>))]
        [InlineData("AsyncLocal<Func<int>>", typeof(AsyncLocal<Func<int>>))]
        [InlineData("System.Threading.Tasks.Task<Func<int>>", typeof(System.Threading.Tasks.Task<Func<int>>))]
        [InlineData("System.Collections.Generic.Dictionary<string, Func<int>>", typeof(System.Collections.Generic.Dictionary<string, Func<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<T1>.ParameterizedChild<U1>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<>.ParameterizedChild<>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<U1, U2>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<,>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>))]
        public void Name(string expected, Type type)
        {
            AppendNameTo(expected, type);
            NameOf(expected, type);
        }

        [Theory]
        [InlineData("Func<>", typeof(Func<>))]
        [InlineData("Func<,>", typeof(Func<,>))]
        [InlineData("Func<,,>", typeof(Func<,,>))]
        [InlineData("Func<,,,>", typeof(Func<,,,>))]
        [InlineData("Func<,,,,,,,,,,,,,,,,>", typeof(Func<,,,,,,,,,,,,,,,,>))]
        [InlineData("Func<Func<int>>", typeof(Func<Func<int>>))]
        [InlineData("AsyncLocal<Func<int>>", typeof(AsyncLocal<Func<int>>))]
        [InlineData("System.Threading.Tasks.Task<Func<int>>", typeof(System.Threading.Tasks.Task<Func<int>>))]
        [InlineData("System.Collections.Generic.Dictionary<string, Func<int>>", typeof(System.Collections.Generic.Dictionary<string, Func<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<>.ParameterizedChild<>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<>.ParameterizedChild<>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>", typeof(Fsi.TextTemplating.CSharp.Tests.Parameterized<CancellationToken>.ParameterizedChild<System.Threading.Tasks.Task<int>>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<,>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<,>))]
        [InlineData("Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>", typeof(Fsi.TextTemplating.CSharp.Tests.NonParameterized.ParameterizedChild<int, System.Threading.Tasks.Task<DateTime>>))]
        public void TypeOfName(string expected, Type type)
        {
            AppendTypeOfNameTo(expected, type);
            TypeOfNameOf(expected, type);
        }

    }
}
