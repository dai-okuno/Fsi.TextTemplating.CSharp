using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestInt32
        : IIntegerTest<int>
    {

        [Theory]
        [InlineData("0", 0, 0, 0)]
        [InlineData("1", 1, 0, 0)]
        [InlineData("-1", -1, 0, 0)]
        [InlineData("10", 10, 0, 0)]
        [InlineData("-10", -10, 0, 0)]
        [InlineData("100", 100, 0, 0)]
        [InlineData("-100", -100, 0, 0)]
        [InlineData("1000", 1000, 0, 0)]
        [InlineData("-1000", -1000, 0, 0)]
        [InlineData("100000", 100000, 0, 0)]
        [InlineData("-100000", -100000, 0, 0)]
        [InlineData("1000000", 1000000, 0, 0)]
        [InlineData("-1000000", -1000000, 0, 0)]
        [InlineData("2147483647", int.MaxValue, 0, 0)]
        [InlineData("-2147483648", int.MinValue, 0, 0)]
        [InlineData("0", 0, 1, 0)]
        [InlineData("1", 1, 1, 0)]
        [InlineData("-1", -1, 1, 0)]
        [InlineData("1_0", 10, 1, 0)]
        [InlineData("-1_0", -10, 1, 0)]
        [InlineData("1_0_0", 100, 1, 0)]
        [InlineData("-1_0_0", -100, 1, 0)]
        [InlineData("1_0_0_0", 1000, 1, 0)]
        [InlineData("-1_0_0_0", -1000, 1, 0)]
        [InlineData("1_0_0_0_0", 10000, 1, 0)]
        [InlineData("-1_0_0_0_0", -10000, 1, 0)]
        [InlineData("2_1_4_7_4_8_3_6_4_7", int.MaxValue, 1, 0)]
        [InlineData("-2_1_4_7_4_8_3_6_4_8", int.MinValue, 1, 0)]
        [InlineData("0", 0, 2, 0)]
        [InlineData("1", 1, 2, 0)]
        [InlineData("-1", -1, 2, 0)]
        [InlineData("10", 10, 2, 0)]
        [InlineData("-10", -10, 2, 0)]
        [InlineData("1_00", 100, 2, 0)]
        [InlineData("-1_00", -100, 2, 0)]
        [InlineData("10_00", 1000, 2, 0)]
        [InlineData("-10_00", -1000, 2, 0)]
        [InlineData("1_00_00", 10000, 2, 0)]
        [InlineData("-1_00_00", -10000, 2, 0)]
        [InlineData("21_47_48_36_47", int.MaxValue, 2, 0)]
        [InlineData("-21_47_48_36_48", int.MinValue, 2, 0)]
        [InlineData("0", 0, 3, 0)]
        [InlineData("1", 1, 3, 0)]
        [InlineData("-1", -1, 3, 0)]
        [InlineData("10", 10, 3, 0)]
        [InlineData("-10", -10, 3, 0)]
        [InlineData("100", 100, 3, 0)]
        [InlineData("-100", -100, 3, 0)]
        [InlineData("1_000", 1000, 3, 0)]
        [InlineData("-1_000", -1000, 3, 0)]
        [InlineData("100_000", 100000, 3, 0)]
        [InlineData("-100_000", -100000, 3, 0)]
        [InlineData("1_000_000", 1000000, 3, 0)]
        [InlineData("-1_000_000", -1000000, 3, 0)]
        [InlineData("2_147_483_647", int.MaxValue, 3, 0)]
        [InlineData("-2_147_483_648", int.MinValue, 3, 0)]
        [InlineData("0", 0, 4, 0)]
        [InlineData("1", 1, 4, 0)]
        [InlineData("-1", -1, 4, 0)]
        [InlineData("10", 10, 4, 0)]
        [InlineData("-10", -10, 4, 0)]
        [InlineData("100", 100, 4, 0)]
        [InlineData("-100", -100, 4, 0)]
        [InlineData("1000", 1000, 4, 0)]
        [InlineData("-1000", -1000, 4, 0)]
        [InlineData("1_0000", 10000, 4, 0)]
        [InlineData("-1_0000", -10000, 4, 0)]
        [InlineData("1_0000_0000", 100000000, 4, 0)]
        [InlineData("-1_0000_0000", -100000000, 4, 0)]
        [InlineData("21_4748_3647", int.MaxValue, 4, 0)]
        [InlineData("-21_4748_3648", int.MinValue, 4, 0)]
        [InlineData("0_000000000", 0, 9, 10)]
        [InlineData("0_000000001", 1, 9, 10)]
        [InlineData("-0_000000001", -1, 9, 10)]
        public void Decimal(string expected, int value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0, 10, 8, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 10 or more.")]
        [InlineData(0, 10, 9, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 10 or more.")]
        [InlineData(0, 11, 9, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 10 or more.")]
        [InlineData(0, 11, 10, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0, 10, 10, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalError(int value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
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
        [InlineData("0x0", 0x0, 0, 0)]
        [InlineData("0x1", 0x1, 0, 0)]
        [InlineData("0xA", 0xA, 0, 0)]
        [InlineData("0xF", 0xF, 0, 0)]
        [InlineData("0x10", 0x10, 0, 0)]
        [InlineData("0x100", 0x100, 0, 0)]
        [InlineData("0x1000", 0x1000, 0, 0)]
        [InlineData("0x10000", 0x10000, 0, 0)]
        [InlineData("0x100000", 0x100000, 0, 0)]
        [InlineData("0x1000000", 0x1000000, 0, 0)]
        [InlineData("0x10000000", 0x10000000, 0, 0)]
        [InlineData("0x7FFFFFFF", int.MaxValue, 0, 0)]
        [InlineData("0x80000000", int.MinValue, 0, 0)]
        [InlineData("0x0", 0x0, 1, 0)]
        [InlineData("0x1", 0x1, 1, 0)]
        [InlineData("0xA", 0xA, 1, 0)]
        [InlineData("0xF", 0xF, 1, 0)]
        [InlineData("0x1_0", 0x10, 1, 0)]
        [InlineData("0x1_0_0", 0x100, 1, 0)]
        [InlineData("0x00", 0x00, 2, 0)]
        [InlineData("0x01", 0x01, 2, 0)]
        [InlineData("0x0A", 0x0A, 2, 0)]
        [InlineData("0x0F", 0x0F, 2, 0)]
        [InlineData("0x10", 0x10, 2, 0)]
        [InlineData("0x01_00", 0x0100, 2, 0)]
        [InlineData("0x00_00", 0x0000, 2, 4)]
        [InlineData("0x00_01", 0x0001, 2, 4)]
        [InlineData("0x00_0A", 0x000A, 2, 4)]
        [InlineData("0x00_0F", 0x000F, 2, 4)]
        [InlineData("0x00_10", 0x0010, 2, 4)]
        [InlineData("0x01_00", 0x0100, 2, 4)]
        [InlineData("0x01_00_00_00", 0x01000000, 2, 4)]
        [InlineData("0x10_00_00_00", 0x10000000, 2, 4)]
        [InlineData("0x7F_FF_FF_FF", int.MaxValue, 2, 4)]
        [InlineData("0x80_00_00_00", int.MinValue, 2, 4)]
        [InlineData("0x0000_0000", 0x00000000, 4, 8)]
        [InlineData("0x0000_0001", 0x00000001, 4, 8)]
        [InlineData("0x0000_000A", 0x0000000A, 4, 8)]
        [InlineData("0x0000_000F", 0x0000000F, 4, 8)]
        [InlineData("0x0000_0010", 0x00000010, 4, 8)]
        [InlineData("0x0000_0100", 0x00000100, 4, 8)]
        [InlineData("0x0000_1000", 0x00001000, 4, 8)]
        [InlineData("0x0001_0000", 0x00010000, 4, 8)]
        [InlineData("0x0010_0000", 0x00100000, 4, 8)]
        [InlineData("0x0100_0000", 0x01000000, 4, 8)]
        [InlineData("0x1000_0000", 0x10000000, 4, 8)]
        [InlineData("0x7FFF_FFFF", int.MaxValue, 4, 8)]
        [InlineData("0x8000_0000", int.MinValue, 4, 8)]
        public void HexaDecimal(string expected, int value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0, 8, 7, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 8 or more.")]
        [InlineData(0, 9, 7, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 8 or more.")]
        [InlineData(0, 9, 8, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0, 8, 8, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void HexaDecimalError(int value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
        {
            Assert.Throws(exceptionType,
                () =>
                {
                    try
                    {
                        var csharp = new CSharpHelper();
                        csharp.HexaDecimal(value, groupSize, minDigits);
                    }
                    catch (ArgumentException ex)
                    {
                        Assert.Equal(paramName, ex.ParamName);
                        Assert.Equal(message + $"\r\nParameter name: {paramName}", ex.Message);
                        throw;
                    }
                });
        }
    }
}
