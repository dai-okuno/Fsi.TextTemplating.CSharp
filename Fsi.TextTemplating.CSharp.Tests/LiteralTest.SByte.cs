using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestSByte
        : IIntegerTest<sbyte>
    {
        [Theory]
        [InlineData("0", (sbyte)0, 0, 0)]
        [InlineData("1", (sbyte)1, 0, 0)]
        [InlineData("-1", (sbyte)-1, 0, 0)]
        [InlineData("10", (sbyte)10, 0, 0)]
        [InlineData("-10", (sbyte)-10, 0, 0)]
        [InlineData("100", (sbyte)100, 0, 0)]
        [InlineData("-100", (sbyte)-100, 0, 0)]
        [InlineData("127", sbyte.MaxValue, 0, 0)]
        [InlineData("-128", sbyte.MinValue, 0, 0)]
        [InlineData("0", (sbyte)0, 1, 0)]
        [InlineData("1", (sbyte)1, 1, 0)]
        [InlineData("-1", (sbyte)-1, 1, 0)]
        [InlineData("1_0", (sbyte)10, 1, 0)]
        [InlineData("-1_0", (sbyte)-10, 1, 0)]
        [InlineData("1_0_0", (sbyte)100, 1, 0)]
        [InlineData("-1_0_0", (sbyte)-100, 1, 0)]
        [InlineData("1_2_7", sbyte.MaxValue, 1, 0)]
        [InlineData("-1_2_8", sbyte.MinValue, 1, 0)]
        [InlineData("000", (sbyte)0, 0, 3)]
        [InlineData("001", (sbyte)1, 0, 3)]
        [InlineData("-001", (sbyte)-1, 0, 3)]
        [InlineData("010", (sbyte)10, 0, 3)]
        [InlineData("-010", (sbyte)-10, 0, 3)]
        [InlineData("100", (sbyte)100, 0, 3)]
        [InlineData("-100", (sbyte)-100, 0, 3)]
        [InlineData("127", sbyte.MaxValue, 0, 3)]
        [InlineData("-128", sbyte.MinValue, 0, 3)]
        [InlineData("0_00", (sbyte)0, 2, 3)]
        [InlineData("0_01", (sbyte)1, 2, 3)]
        [InlineData("-0_01", (sbyte)-1, 2, 3)]
        [InlineData("0_10", (sbyte)10, 2, 3)]
        [InlineData("-0_10", (sbyte)-10, 2, 3)]
        [InlineData("1_00", (sbyte)100, 2, 3)]
        [InlineData("-1_00", (sbyte)-100, 2, 3)]
        [InlineData("1_27", sbyte.MaxValue, 2, 3)]
        [InlineData("-1_28", sbyte.MinValue, 2, 3)]
        public void Decimal(string expected, sbyte value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }
        [Theory]
        [InlineData("0x0", (sbyte)0x0, 0, 0)]
        [InlineData("0x1", (sbyte)0x1, 0, 0)]
        [InlineData("0xA", (sbyte)0xA, 0, 0)]
        [InlineData("0xF", (sbyte)0xF, 0, 0)]
        [InlineData("0x10", (sbyte)0x10, 0, 0)]
        [InlineData("0x7F", sbyte.MaxValue, 0, 0)]
        [InlineData("0x80", sbyte.MinValue, 0, 0)]
        [InlineData("0x00", (sbyte)0x0, 0, 2)]
        [InlineData("0x01", (sbyte)0x1, 0, 2)]
        [InlineData("0x0A", (sbyte)0xA, 0, 2)]
        [InlineData("0x0F", (sbyte)0xF, 0, 2)]
        [InlineData("0x10", (sbyte)0x10, 0, 2)]
        [InlineData("0x7F", sbyte.MaxValue, 0, 2)]
        [InlineData("0x80", sbyte.MinValue, 0, 2)]
        [InlineData("0x0_0_0", (sbyte)0x0, 1, 3)]
        [InlineData("0x0_0_1", (sbyte)0x1, 1, 3)]
        [InlineData("0x0_0_A", (sbyte)0xA, 1, 3)]
        [InlineData("0x0_0_F", (sbyte)0xF, 1, 3)]
        [InlineData("0x0_1_0", (sbyte)0x10, 1, 3)]
        [InlineData("0x0_7_F", sbyte.MaxValue, 1, 3)]
        [InlineData("0x0_8_0", sbyte.MinValue, 1, 3)]
        public void HexaDecimal(string expected, sbyte value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }
    }
}
