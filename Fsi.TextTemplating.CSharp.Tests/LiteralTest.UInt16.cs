using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestUInt16
        : IIntegerTest<ushort>
    {
        [Theory]
        [InlineData("0", (ushort)0, 0, 0)]
        [InlineData("1", (ushort)1, 0, 0)]
        [InlineData("10", (ushort)10, 0, 0)]
        [InlineData("100", (ushort)100, 0, 0)]
        [InlineData("1000", (ushort)1000, 0, 0)]
        [InlineData("65535", ushort.MaxValue, 0, 0)]
        [InlineData("0", (ushort)0, 3, 0)]
        [InlineData("1", (ushort)1, 3, 0)]
        [InlineData("10", (ushort)10, 3, 0)]
        [InlineData("100", (ushort)100, 3, 0)]
        [InlineData("1_000", (ushort)1000, 3, 0)]
        [InlineData("65_535", ushort.MaxValue, 3, 0)]
        public void Decimal(string expected, ushort value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        public void HexaDecimal(string expected, ushort value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }
    }
}
