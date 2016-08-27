using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestInt64
        : IIntegerTest<long>
    {
        [Theory]
        [InlineData("0L", 0L, 0, 0)]
        [InlineData("1L", 1L, 0, 0)]
        [InlineData("-1L", -1L, 0, 0)]
        [InlineData("100L", 100L, 0, 0)]
        [InlineData("-100L", -100L, 0, 0)]
        [InlineData("1000L", 1000L, 0, 0)]
        [InlineData("-1000L", -1000L, 0, 0)]
        [InlineData("100000L", 100000L, 0, 0)]
        [InlineData("-100000L", -100000L, 0, 0)]
        [InlineData("1000000L", 1000000L, 0, 0)]
        [InlineData("-1000000L", -1000000L, 0, 0)]
        [InlineData("9223372036854775807L", long.MaxValue, 0, 0)]
        [InlineData("-9223372036854775808L", long.MinValue, 0, 0)]
        [InlineData("0L", 0L, 3, 0)]
        [InlineData("1L", 1L, 3, 0)]
        [InlineData("-1L", -1L, 3, 0)]
        [InlineData("100L", 100L, 3, 0)]
        [InlineData("-100L", -100L, 3, 0)]
        [InlineData("1_000L", 1000L, 3, 0)]
        [InlineData("-1_000L", -1000L, 3, 0)]
        [InlineData("-100_000L", -100000L, 3, 0)]
        [InlineData("100_000L", 100000L, 3, 0)]
        [InlineData("1_000_000L", 1000000L, 3, 0)]
        [InlineData("-1_000_000L", -1000000L, 3, 0)]
        [InlineData("9_223_372_036_854_775_807L", long.MaxValue, 3, 0)]
        [InlineData("-9_223_372_036_854_775_808L", long.MinValue, 3, 0)]
        public void Decimal(string expected, long value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        public void HexaDecimal(string expected, long value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }
    }
}
