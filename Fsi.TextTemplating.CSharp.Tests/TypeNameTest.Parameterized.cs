using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestParameterized
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.Func{TResult}", typeof(Func<>))]
        [InlineData("System.Func{T, TResult}", typeof(Func<,>))]
        [InlineData("System.Func{System.Action{System.DateTime}, System.Collections.DictionaryEntry, System.Collections.Generic.Dictionary{string, int}}", typeof(Func<Action<DateTime>, System.Collections.DictionaryEntry, Dictionary<string, int>>))]
        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }
        [Theory]
        [InlineData("System.Func<TResult>", typeof(Func<>))]
        [InlineData("System.Func<T, TResult>", typeof(Func<,>))]
        [InlineData("System.Func<System.Action<System.DateTime>, System.Collections.DictionaryEntry, System.Collections.Generic.Dictionary<string, int>>", typeof(Func<Action<DateTime>, System.Collections.DictionaryEntry, Dictionary<string, int>>))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }
        [Theory]
        [InlineData("Func<TResult>", typeof(Func<>))]
        [InlineData("Func<T, TResult>", typeof(Func<,>))]
        [InlineData("Func<Action<DateTime>, DictionaryEntry, System.Collections.Generic.Dictionary<string, int>>", typeof(Func<Action<DateTime>, System.Collections.DictionaryEntry, Dictionary<string, int>>))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }
        [Theory]
        [InlineData("System.Func{TResult}", typeof(Func<>))]
        [InlineData("System.Func{T, TResult}", typeof(Func<,>))]
        [InlineData("System.Func{System.Action{System.DateTime}, System.Collections.DictionaryEntry, System.Collections.Generic.Dictionary{string, int}}", typeof(Func<Action<DateTime>, System.Collections.DictionaryEntry, Dictionary<string, int>>))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }
        [Theory]
        [InlineData("System.Func<TResult>", typeof(Func<>))]
        [InlineData("System.Func<T, TResult>", typeof(Func<,>))]
        [InlineData("System.Func<System.Action<System.DateTime>, System.Collections.DictionaryEntry, System.Collections.Generic.Dictionary<string, int>>", typeof(Func<Action<DateTime>, System.Collections.DictionaryEntry, Dictionary<string, int>>))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }
        [Theory]
        [InlineData("Func<TResult>", typeof(Func<>))]
        [InlineData("Func<T, TResult>", typeof(Func<,>))]
        [InlineData("Func<Action<DateTime>, DictionaryEntry, System.Collections.Generic.Dictionary<string, int>>", typeof(Func<Action<DateTime>, System.Collections.DictionaryEntry, Dictionary<string, int>>))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
        }
    }
}
