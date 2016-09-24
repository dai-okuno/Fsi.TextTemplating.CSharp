using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTestByte
        : IIntegerTest<byte>
    {

        [Theory]
        [InlineData("0", (byte)0, 0, 0)]
        [InlineData("1", (byte)1, 0, 0)]
        [InlineData("100", (byte)100, 0, 0)]
        [InlineData("255", byte.MaxValue, 0, 0)]
        [InlineData("0", byte.MinValue, 0, 0)]
        [InlineData("0", (byte)0, 1, 0)]
        [InlineData("1", (byte)1, 1, 0)]
        [InlineData("1_0", (byte)10, 1, 0)]
        [InlineData("1_0_0", (byte)100, 1, 0)]
        [InlineData("2_5_5", byte.MaxValue, 1, 0)]
        [InlineData("00", (byte)0, 0, 2)]
        [InlineData("01", (byte)1, 0, 2)]
        [InlineData("10", (byte)10, 0, 2)]
        [InlineData("100", (byte)100, 0, 2)]
        [InlineData("0255", byte.MaxValue, 0, 4)]
        [InlineData("0_0", (byte)0, 1, 2)]
        [InlineData("0_1", (byte)1, 1, 2)]
        [InlineData("1_0", (byte)10, 1, 2)]
        [InlineData("1_0_0", (byte)100, 1, 2)]
        [InlineData("0_2_5_5", byte.MaxValue, 1, 4)]
        [InlineData("1_00", (byte)100, 2, 0)]
        public void Decimal(string expected, byte value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }
        [Theory]
        [InlineData((byte)0, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData((byte)0, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData((byte)0, 3, 1, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 3 or more.")]
        [InlineData((byte)0, 3, 2, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 3 or more.")]
        [InlineData((byte)0, 4, 2, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 3 or more.")]
        [InlineData((byte)0, 4, 3, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData((byte)0, 3, 3, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalError(byte value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
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
        [InlineData("0x0", (byte)0, 0, 0)]
        [InlineData("0x1", (byte)1, 0, 0)]
        [InlineData("0xA", (byte)10, 0, 0)]
        [InlineData("0xF", (byte)15, 0, 0)]
        [InlineData("0x10", (byte)16, 0, 0)]
        [InlineData("0xA0", (byte)160, 0, 0)]
        [InlineData("0xFF", byte.MaxValue, 0, 0)]
        [InlineData("0x00", (byte)0, 0, 2)]
        [InlineData("0x01", (byte)1, 0, 2)]
        [InlineData("0x0A", (byte)10, 0, 2)]
        [InlineData("0x0F", (byte)15, 0, 2)]
        [InlineData("0x10", (byte)16, 0, 2)]
        [InlineData("0xA0", (byte)160, 0, 2)]
        [InlineData("0xFF", byte.MaxValue, 0, 2)]
        [InlineData("0x0", (byte)0, 1, 0)]
        [InlineData("0x1", (byte)1, 1, 0)]
        [InlineData("0x1_0", (byte)16, 1, 0)]
        [InlineData("0x0_0", (byte)0, 1, 2)]
        [InlineData("0x0_1", (byte)1, 1, 2)]
        [InlineData("0x1_0", (byte)16, 1, 2)]
        [InlineData("0x00_10", (byte)16, 2, 3)]
        public void HexaDecimal(string expected, byte value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((byte)0, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData((byte)0, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData((byte)0, 2, 1, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 2 or more.")]
        [InlineData((byte)0, 3, 1, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 2 or more.")]
        [InlineData((byte)0, 3, 2, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData((byte)0, 2, 2, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void HexaDecimalError(byte value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
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
