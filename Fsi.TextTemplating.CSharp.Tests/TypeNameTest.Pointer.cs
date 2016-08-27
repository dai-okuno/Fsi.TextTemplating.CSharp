using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestPointer
        : TypeNameTest
    {
        [Theory]
        [InlineData("int*", typeof(int))]
        [InlineData("System.DateTime*", typeof(DateTime))]
        [InlineData("System.StringComparison?*", typeof(StringComparison?))]
        [InlineData("System.Action<T>*", typeof(Action<>))]
        [InlineData("System.Tuple<T1, T2>*", typeof(Tuple<,>))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator*", typeof(List<>.Enumerator))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("int*", typeof(int))]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("StringComparison?*", typeof(StringComparison?))]
        [InlineData("Action<T>*", typeof(Action<>))]
        [InlineData("Tuple<T1, T2>*", typeof(Tuple<,>))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator*", typeof(List<>.Enumerator))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("int*", typeof(int))]
        [InlineData("System.DateTime*", typeof(DateTime))]
        [InlineData("System.StringComparison?*", typeof(StringComparison?))]
        [InlineData("System.Action<T>*", typeof(Action<>))]
        [InlineData("System.Tuple<T1, T2>*", typeof(Tuple<,>))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator*", typeof(List<>.Enumerator))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type.MakePointerType());
        }

        [Theory]
        [InlineData("int*", typeof(int))]
        [InlineData("DateTime*", typeof(DateTime))]
        [InlineData("StringComparison?*", typeof(StringComparison?))]
        [InlineData("Action<T>*", typeof(Action<>))]
        [InlineData("Tuple<T1, T2>*", typeof(Tuple<,>))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator*", typeof(List<>.Enumerator))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type.MakePointerType());
        }
    }
}
