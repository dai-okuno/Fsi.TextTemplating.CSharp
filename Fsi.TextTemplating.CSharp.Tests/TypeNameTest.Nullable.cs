using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNullable
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.Nullable{int}", typeof(int?))]
        [InlineData("System.Nullable{System.Collections.Generic.Dictionary{System.Nullable{System.DateTime}, System.Nullable{int}}.Enumerator}", typeof(Dictionary<DateTime?, int?>.Enumerator?))]

        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }
        [Theory]
        [InlineData("int?", typeof(int?))]
        [InlineData("System.Collections.Generic.Dictionary<System.DateTime?, int?>.Enumerator?", typeof(Dictionary<DateTime?, int?>.Enumerator?))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("int?", typeof(int?))]
        [InlineData("System.Collections.Generic.Dictionary<DateTime?, int?>.Enumerator?", typeof(Dictionary<DateTime?, int?>.Enumerator?))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.Nullable{int}", typeof(int?))]
        [InlineData("System.Nullable{System.Collections.Generic.Dictionary{System.Nullable{System.DateTime}, System.Nullable{int}}.Enumerator}", typeof(Dictionary<DateTime?, int?>.Enumerator?))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }
        [Theory]
        [InlineData("int?", typeof(int?))]
        [InlineData("System.Collections.Generic.Dictionary<System.DateTime?, int?>.Enumerator?", typeof(Dictionary<DateTime?, int?>.Enumerator?))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("int?", typeof(int?))]
        [InlineData("System.Collections.Generic.Dictionary<DateTime?, int?>.Enumerator?", typeof(Dictionary<DateTime?, int?>.Enumerator?))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
            Default("default(" + expected + ")", type);
        }
    }
}
