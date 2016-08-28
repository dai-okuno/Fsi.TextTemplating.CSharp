using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestUInt32
        : IIntegerTest<uint>
    {
        [Theory]
        [InlineData("0u", 0u, 0, 0)]
        [InlineData("1u", 1u, 0, 0)]
        [InlineData("10u", 10u, 0, 0)]
        [InlineData("100u", 100u, 0, 0)]
        [InlineData("1000u", 1000u, 0, 0)]
        [InlineData("4294967295u", uint.MaxValue, 0, 0)]
        [InlineData("0u", 0u, 3, 0)]
        [InlineData("1u", 1u, 3, 0)]
        [InlineData("10u", 10u, 3, 0)]
        [InlineData("100u", 100u, 3, 0)]
        [InlineData("1_000u", 1000u, 3, 0)]
        [InlineData("10_000u", 10000u, 3, 0)]
        [InlineData("100_000u", 100000u, 3, 0)]
        [InlineData("1_000_000u", 1000000u, 3, 0)]
        [InlineData("4_294_967_295u", uint.MaxValue, 3, 0)]
        public void Decimal(string expected, uint value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }
        [Theory]
        [InlineData("0x0u", 0x0u, 0, 0)]
        [InlineData("0x1u", 0x1u, 0, 0)]
        [InlineData("0xFFFFFFFFu", uint.MaxValue, 0, 0)]
        [InlineData("0x00000000u", 0x0u, 0, 8)]
        [InlineData("0xFFFFFFFFu", uint.MaxValue, 0, 8)]
        [InlineData("0x00_00_00_00u", 0x0u, 2, 8)]
        [InlineData("0xFF_FF_FF_FFu", uint.MaxValue, 2, 8)]
        [InlineData("0x0000_0000u", 0x0u, 4, 8)]
        [InlineData("0xFFFF_FFFFu", uint.MaxValue, 4, 8)]

        public void HexaDecimal(string expected, uint value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }
    }
}
