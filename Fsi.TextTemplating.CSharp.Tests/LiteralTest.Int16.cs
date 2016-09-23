using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestInt16
        : IIntegerTest<short>
    {
        [Theory]
        [InlineData("0", (short)0, 0, 0)]
        [InlineData("1", (short)1, 0, 0)]
        [InlineData("-1", (short)-1, 0, 0)]
        [InlineData("10", (short)10, 0, 0)]
        [InlineData("-10", (short)-10, 0, 0)]
        [InlineData("100", (short)100, 0, 0)]
        [InlineData("-100", (short)-100, 0, 0)]
        [InlineData("1000", (short)1000, 0, 0)]
        [InlineData("-1000", (short)-1000, 0, 0)]
        [InlineData("10000", (short)10000, 0, 0)]
        [InlineData("-10000", (short)-10000, 0, 0)]
        [InlineData("32767", short.MaxValue, 0, 0)]
        [InlineData("-32768", short.MinValue, 0, 0)]
        [InlineData("0", (short)0, 3, 0)]
        [InlineData("1", (short)1, 3, 0)]
        [InlineData("-1", (short)-1, 3, 0)]
        [InlineData("10", (short)10, 3, 0)]
        [InlineData("-10", (short)-10, 3, 0)]
        [InlineData("100", (short)100, 3, 0)]
        [InlineData("-100", (short)-100, 3, 0)]
        [InlineData("1_000", (short)1000, 3, 0)]
        [InlineData("-1_000", (short)-1000, 3, 0)]
        [InlineData("10_000", (short)10000, 3, 0)]
        [InlineData("-10_000", (short)-10000, 3, 0)]
        [InlineData("32_767", short.MaxValue, 3, 0)]
        [InlineData("-32_768", short.MinValue, 3, 0)]
        [InlineData("00", (short)0, 0, 2)]
        [InlineData("01", (short)1, 0, 2)]
        [InlineData("-01", (short)-1, 0, 2)]
        [InlineData("10", (short)10, 0, 2)]
        [InlineData("-10", (short)-10, 0, 2)]
        [InlineData("100", (short)100, 0, 2)]
        [InlineData("-100", (short)-100, 0, 2)]
        [InlineData("000", (short)0, 0, 3)]
        [InlineData("001", (short)1, 0, 3)]
        [InlineData("-001", (short)-1, 0, 3)]
        [InlineData("010", (short)10, 0, 3)]
        [InlineData("-010", (short)-10, 0, 3)]
        [InlineData("100", (short)100, 0, 3)]
        [InlineData("-100", (short)-100, 0, 3)]
        [InlineData("1000", (short)1000, 0, 3)]
        [InlineData("-1000", (short)-1000, 0, 3)]
        [InlineData("00_00", (short)0, 2, 4)]
        [InlineData("00_01", (short)1, 2, 4)]
        [InlineData("-00_01", (short)-1, 2, 4)]
        [InlineData("00_10", (short)10, 2, 4)]
        [InlineData("-00_10", (short)-10, 2, 4)]
        [InlineData("01_00", (short)100, 2, 4)]
        [InlineData("-01_00", (short)-100, 2, 4)]
        [InlineData("10_00", (short)1000, 2, 4)]
        [InlineData("-10_00", (short)-1000, 2, 4)]
        [InlineData("1_00_00", (short)10000, 2, 4)]
        [InlineData("-1_00_00", (short)-10000, 2, 4)]
        [InlineData("0_0000", (short)0, 4, 5)]
        [InlineData("0_0001", (short)1, 4, 5)]
        [InlineData("-0_0001", (short)-1, 4, 5)]
        public void Decimal(string expected, short value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((short)0, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData((short)0, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData((short)0, 5, 3, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 5 or more.")]
        [InlineData((short)0, 5, 4, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 5 or more.")]
        [InlineData((short)0, 6, 4, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 5 or more.")]
        [InlineData((short)0, 6, 5, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData((short)0, 5, 5, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalError(short value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
        {

            Assert.Throws(exceptionType,
                () =>
                {
                    try
                    {
                        var csharp = new CSharpHelper();
                        csharp.Decimal(value, groupSize, minDigits);
                    }
                    catch (ArgumentException ex)
                    {
                        Assert.Equal(paramName, ex.ParamName);
                        Assert.Equal(message + $"\r\nParameter name: {paramName}", ex.Message);
                        throw;
                    }
                });
        }

        [Theory]
        [InlineData("0x0", (short)0, 0, 0)]
        [InlineData("0x1", (short)1, 0, 0)]
        [InlineData("0xA", (short)10, 0, 0)]
        [InlineData("0xF", (short)15, 0, 0)]
        [InlineData("0x10", (short)16, 0, 0)]
        [InlineData("0xA0", (short)160, 0, 0)]
        [InlineData("0xA00", (short)2560, 0, 0)]
        [InlineData("0xA000", (short)-24576, 0, 0)]
        [InlineData("0x7FFF", short.MaxValue, 0, 0)]
        [InlineData("0x8000", short.MinValue, 0, 0)]
        [InlineData("0x00", (short)0, 2, 0)]
        [InlineData("0x01", (short)1, 2, 0)]
        [InlineData("0x0A", (short)10, 2, 0)]
        [InlineData("0x0F", (short)15, 2, 0)]
        [InlineData("0x10", (short)16, 2, 0)]
        [InlineData("0xA0", (short)160, 2, 0)]
        [InlineData("0x0A_00", (short)2560, 2, 0)]
        [InlineData("0xA0_00", (short)-24576, 2, 0)]
        [InlineData("0x7F_FF", short.MaxValue, 2, 0)]
        [InlineData("0x80_00", short.MinValue, 2, 0)]
        [InlineData("0x0000", (short)0, 0, 4)]
        [InlineData("0x0001", (short)1, 0, 4)]
        [InlineData("0x000A", (short)10, 0, 4)]
        [InlineData("0x000F", (short)15, 0, 4)]
        [InlineData("0x0010", (short)16, 0, 4)]
        [InlineData("0x00A0", (short)160, 0, 4)]
        [InlineData("0x0A00", (short)2560, 0, 4)]
        [InlineData("0xA000", (short)-24576, 0, 4)]
        [InlineData("0x7FFF", short.MaxValue, 0, 4)]
        [InlineData("0x8000", short.MinValue, 0, 4)]
        [InlineData("0x00_00", (short)0, 2, 4)]
        [InlineData("0x00_01", (short)1, 2, 4)]
        [InlineData("0x00_0A", (short)10, 2, 4)]
        [InlineData("0x00_0F", (short)15, 2, 4)]
        [InlineData("0x00_10", (short)16, 2, 4)]
        [InlineData("0x00_A0", (short)160, 2, 4)]
        [InlineData("0x0A_00", (short)2560, 2, 4)]
        [InlineData("0xA0_00", (short)-24576, 2, 4)]
        [InlineData("0x7F_FF", short.MaxValue, 2, 4)]
        [InlineData("0x80_00", short.MinValue, 2, 4)]
        public void HexaDecimal(string expected, short value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

    }
}
