using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestNonParameterized
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.StringComparison", typeof(StringComparison))]
        [InlineData("System.Collections.Generic.List{T}.Enumerator", typeof(List<>.Enumerator))]
        [InlineData("System.Collections.Generic.LinkedList{System.Collections.Generic.Dictionary{System.DateTime, string}.Enumerator}.Enumerator", typeof(LinkedList<Dictionary<DateTime, string>.Enumerator>.Enumerator))]
        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.StringComparison", typeof(StringComparison))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(List<>.Enumerator))]
        [InlineData("System.Collections.Generic.LinkedList<System.Collections.Generic.Dictionary<System.DateTime, string>.Enumerator>.Enumerator", typeof(LinkedList<Dictionary<DateTime, string>.Enumerator>.Enumerator))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("StringComparison", typeof(StringComparison))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(List<>.Enumerator))]
        [InlineData("System.Collections.Generic.LinkedList<System.Collections.Generic.Dictionary<DateTime, string>.Enumerator>.Enumerator", typeof(LinkedList<Dictionary<DateTime, string>.Enumerator>.Enumerator))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.StringComparison", typeof(StringComparison))]
        [InlineData("System.Collections.Generic.List{T}.Enumerator", typeof(List<>.Enumerator))]
        [InlineData("System.Collections.Generic.LinkedList{System.Collections.Generic.Dictionary{System.DateTime, string}.Enumerator}.Enumerator", typeof(LinkedList<Dictionary<DateTime, string>.Enumerator>.Enumerator))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("System.DateTime", typeof(DateTime))]
        [InlineData("System.StringComparison", typeof(StringComparison))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(List<>.Enumerator))]
        [InlineData("System.Collections.Generic.LinkedList<System.Collections.Generic.Dictionary<System.DateTime, string>.Enumerator>.Enumerator", typeof(LinkedList<Dictionary<DateTime, string>.Enumerator>.Enumerator))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("DateTime", typeof(DateTime))]
        [InlineData("StringComparison", typeof(StringComparison))]
        [InlineData("System.Collections.Generic.List<T>.Enumerator", typeof(List<>.Enumerator))]
        [InlineData("System.Collections.Generic.LinkedList<System.Collections.Generic.Dictionary<DateTime, string>.Enumerator>.Enumerator", typeof(LinkedList<Dictionary<DateTime, string>.Enumerator>.Enumerator))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
            Default("default(" + expected + ")", type);
        }
    }
}
