using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestArray
        : TypeNameTest
    {

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("System.DateTime[,]", typeof(DateTime[,]))]
        [InlineData("System.Tuple{int}[,,]", typeof(Tuple<int>[,,]))]
        [InlineData("System.Tuple{System.Tuple{string, int}, System.DateTime}[,,,]", typeof(Tuple<Tuple<string, int>, DateTime>[,,,]))]
        [InlineData("System.Nullable{System.DateTime}[][,]", typeof(DateTime?[][,]))]
        [InlineData("System.Collections.Generic.Dictionary{string, System.Collections.Generic.List{System.DateTime}}[]", typeof(Dictionary<string, List<DateTime>>[]))]
        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("System.DateTime[,]", typeof(DateTime[,]))]
        [InlineData("System.Tuple<int>[,,]", typeof(Tuple<int>[,,]))]
        [InlineData("System.Tuple<System.Tuple<string, int>, System.DateTime>[,,,]", typeof(Tuple<Tuple<string, int>, DateTime>[,,,]))]
        [InlineData("System.DateTime?[][,]", typeof(DateTime?[][,]))]
        [InlineData("System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.DateTime>>[]", typeof(Dictionary<string, List<DateTime>>[]))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("DateTime[,]", typeof(DateTime[,]))]
        [InlineData("Tuple<int>[,,]", typeof(Tuple<int>[,,]))]
        [InlineData("Tuple<Tuple<string, int>, DateTime>[,,,]", typeof(Tuple<Tuple<string, int>, DateTime>[,,,]))]
        [InlineData("DateTime?[][,]", typeof(DateTime?[][,]))]
        [InlineData("System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<DateTime>>[]", typeof(Dictionary<string, List<DateTime>>[]))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("System.DateTime[,]", typeof(DateTime[,]))]
        [InlineData("System.Tuple{int}[,,]", typeof(Tuple<int>[,,]))]
        [InlineData("System.Tuple{System.Tuple{string, int}, System.DateTime}[,,,]", typeof(Tuple<Tuple<string, int>, DateTime>[,,,]))]
        [InlineData("System.Nullable{System.DateTime}[][,]", typeof(DateTime?[][,]))]
        [InlineData("System.Collections.Generic.Dictionary{string, System.Collections.Generic.List{System.DateTime}}[]", typeof(Dictionary<string, List<DateTime>>[]))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("System.DateTime[,]", typeof(DateTime[,]))]
        [InlineData("System.Tuple<int>[,,]", typeof(Tuple<int>[,,]))]
        [InlineData("System.Tuple<System.Tuple<string, int>, System.DateTime>[,,,]", typeof(Tuple<Tuple<string, int>, DateTime>[,,,]))]
        [InlineData("System.DateTime?[][,]", typeof(DateTime?[][,]))]
        [InlineData("System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.DateTime>>[]", typeof(Dictionary<string, List<DateTime>>[]))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("int[]", typeof(int[]))]
        [InlineData("DateTime[,]", typeof(DateTime[,]))]
        [InlineData("Tuple<int>[,,]", typeof(Tuple<int>[,,]))]
        [InlineData("Tuple<Tuple<string, int>, DateTime>[,,,]", typeof(Tuple<Tuple<string, int>, DateTime>[,,,]))]
        [InlineData("DateTime?[][,]", typeof(DateTime?[][,]))]
        [InlineData("System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<DateTime>>[]", typeof(Dictionary<string, List<DateTime>>[]))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
            Default("default(" + expected + ")", type);
        }

    }
}
