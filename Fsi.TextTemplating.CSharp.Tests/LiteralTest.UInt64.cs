using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestUInt64
        : IIntegerTest<ulong>
    {
        [Theory]
        [InlineData("0uL", 0uL, 0, 0)]
        [InlineData("1uL", 1uL, 0, 0)]
        [InlineData("10uL", 10uL, 0, 0)]
        [InlineData("100uL", 100uL, 0, 0)]
        [InlineData("1000uL", 1000uL, 0, 0)]
        [InlineData("18446744073709551615uL", ulong.MaxValue, 0, 0)]
        [InlineData("0uL", 0uL, 3, 0)]
        [InlineData("1uL", 1uL, 3, 0)]
        [InlineData("10uL", 10uL, 3, 0)]
        [InlineData("100uL", 100uL, 3, 0)]
        [InlineData("1_000uL", 1000uL, 3, 0)]
        [InlineData("10_000uL", 10000uL, 3, 0)]
        [InlineData("100_000uL", 100000uL, 3, 0)]
        [InlineData("1_000_000uL", 1000000uL, 3, 0)]
        [InlineData("18_446_744_073_709_551_615uL", ulong.MaxValue, 3, 0)]
        public void Decimal(string expected, ulong value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        public void HexaDecimal(string expected, ulong value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }
    }
}
