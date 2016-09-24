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
        [InlineData("0_000000000u", 0u, 9, 10)]
        [InlineData("0_000000001u", 1u, 9, 10)]
        public void Decimal(string expected, uint value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0u, -1, 0, "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0u, 0, -1, "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0u, 10, 8, "groupSize", "'groupSize' equals 10 or more.")]
        [InlineData(0u, 10, 9, "groupSize", "'groupSize' equals 10 or more.")]
        [InlineData(0u, 11, 9, "groupSize", "'groupSize' equals 10 or more.")]
        public void DecimalArgumentOutOfRangeError(uint value, int groupSize, int minDigits, string paramName, string message)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(paramName,
                () =>
                {
                    var csharp = new CSharpHelper();
                    csharp.Decimal(value, groupSize, minDigits);
                });
            Assert.Equal(message + $"\r\nParameter name: {paramName}", ex.Message);
        }

        [Theory]
        [InlineData(0u, 11, 10, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0u, 10, 10, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalArgumentError(uint value, int groupSize, int minDigits, string paramName, string message)
        {
            var ex = Assert.Throws<ArgumentException>(paramName,
                () =>
                {
                    var csharp = new CSharpHelper();
                    csharp.Decimal(value, groupSize, minDigits);
                });
            Assert.Equal(message + $"\r\nParameter name: {paramName}", ex.Message);
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
        [InlineData("0x01_00u", 0x100u, 2, 0)]

        public void HexaDecimal(string expected, uint value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0u, -1, 0, "groupSize", "'groupSize' is less than 0.")]
        [InlineData(0u, 0, -1, "minDigits", "'minDigits' is less than 0.")]
        [InlineData(0u, 8, 7, "groupSize", "'groupSize' equals 8 or more.")]
        [InlineData(0u, 9, 7, "groupSize", "'groupSize' equals 8 or more.")]
        public void HexaDecimalArgumentOutOfError(uint value, int groupSize, int minDigits, string paramName, string message)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(paramName,
                () =>
                {
                    var csharp = new CSharpHelper();
                    csharp.HexaDecimal(value, groupSize, minDigits);
                });
            Assert.Equal(message + $"\r\nParameter name: {paramName}", ex.Message);
        }

        [Theory]
        [InlineData(0u, 9, 8, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData(0u, 8, 8, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void HexaDecimalArgumentError(uint value, int groupSize, int minDigits, string paramName, string message)
        {
            var ex = Assert.Throws<ArgumentException>(paramName,
                () =>
                {
                    var csharp = new CSharpHelper();
                    csharp.HexaDecimal(value, groupSize, minDigits);
                });
            Assert.Equal(message + $"\r\nParameter name: {paramName}", ex.Message);
        }

    }
}
