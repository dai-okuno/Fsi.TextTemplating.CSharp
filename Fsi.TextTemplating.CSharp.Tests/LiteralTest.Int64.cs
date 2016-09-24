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
        [InlineData("0_000000000000000000L", 0L, 18, 19)]
        [InlineData("0_000000000000000001L", 1L, 18, 19)]
        [InlineData("-0_000000000000000001L", -1L, 18, 19)]
        public void Decimal(string expected, long value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0L, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0L, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0L, 19, 17, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 19 or more.")]
        [InlineData(0L, 19, 18, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 19 or more.")]
        [InlineData(0L, 20, 18, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 19 or more.")]
        [InlineData(0L, 20, 19, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0L, 19, 19, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalError(long value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
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
        [InlineData("0x0L", 0x0L, 0, 0)]
        [InlineData("0x7FFFFFFFFFFFFFFFL", long.MaxValue, 0, 0)]
        [InlineData("0x8000000000000000L", long.MinValue, 0, 0)]
        [InlineData("0x0000_0000_0000_0000L", 0x0L, 4, 16)]
        [InlineData("0x7FFF_FFFF_FFFF_FFFFL", long.MaxValue, 4, 16)]
        [InlineData("0x8000_0000_0000_0000L", long.MinValue, 4, 16)]

        [InlineData("0x01_00L", 0x100L, 2, 0)]
        public void HexaDecimal(string expected, long value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0L, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0L, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0L, 16, 15, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 16 or more.")]
        [InlineData(0L, 17, 15, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 16 or more.")]
        [InlineData(0L, 17, 16, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0L, 16, 16, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void HexaDecimalError(long value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
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
