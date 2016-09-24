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
        [InlineData("0_0000000000000000000uL", 0uL, 19, 20)]
        [InlineData("0_0000000000000000001uL", 1uL, 19, 20)]
        public void Decimal(string expected, ulong value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0uL, -1, 0, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0uL, 0, -1, typeof(ArgumentOutOfRangeException), "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0uL, 20, 18, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 20 or more.")]
        [InlineData(0uL, 20, 19, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 20 or more.")]
        [InlineData(0uL, 21, 19, typeof(ArgumentOutOfRangeException), "groupSize", "'groupSize' equals 20 or more.")]
        [InlineData(0uL, 21, 20, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0uL, 20, 20, typeof(ArgumentException), "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalError(ulong value, int groupSize, int minDigits, Type exceptionType, string paramName, string message)
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
        [InlineData("0x0uL", 0x0uL, 0, 0)]
        [InlineData("0xFFFFFFFFFFFFFFFFuL", ulong.MaxValue, 0, 0)]
        [InlineData("0x00_00_00_00_00_00_00_00uL", 0x0uL, 2, 16)]
        [InlineData("0xFF_FF_FF_FF_FF_FF_FF_FFuL", ulong.MaxValue, 2, 16)]
        [InlineData("0x0000_0000_0000_0000uL", 0x0uL, 4, 16)]
        [InlineData("0xFFFF_FFFF_FFFF_FFFFuL", ulong.MaxValue, 4, 16)]
        [InlineData("0x01_00uL", 0x100uL, 2, 0)]
        public void HexaDecimal(string expected, ulong value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }
    }
}
