﻿using System;
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
        [InlineData("0_0000", (ushort)0, 4, 5)]
        [InlineData("0_0001", (ushort)1, 4, 5)]
        public void Decimal(string expected, ushort value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((ushort)0, -1, 0, "groupSize", "'groupSize' is less than 0.")]
        [InlineData((ushort)0, 0, -1, "minDigits", "'minDigits' is less than 0.")]
        [InlineData((ushort)0, 5, 3, "groupSize", "'groupSize' equals 5 or more.")]
        [InlineData((ushort)0, 5, 4, "groupSize", "'groupSize' equals 5 or more.")]
        [InlineData((ushort)0, 6, 4, "groupSize", "'groupSize' equals 5 or more.")]
        public void DecimalArgumentOutOfRangeError(ushort value, int groupSize, int minDigits, string paramName, string message)
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

        [InlineData((ushort)0, 6, 5, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData((ushort)0, 5, 5, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void DecimalArgumentError(ushort value, int groupSize, int minDigits, string paramName, string message)
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
        [InlineData("0x0", (ushort)0x0, 0, 0)]
        [InlineData("0x1", (ushort)0x1, 0, 0)]
        [InlineData("0x10", (ushort)0x10, 0, 0)]
        [InlineData("0x100", (ushort)0x100, 0, 0)]
        [InlineData("0x1000", (ushort)0x1000, 0, 0)]
        [InlineData("0xFFFF", ushort.MaxValue, 0, 0)]
        [InlineData("0x0000", (ushort)0x0, 0, 4)]
        [InlineData("0x0001", (ushort)0x1, 0, 4)]
        [InlineData("0x0010", (ushort)0x10, 0, 4)]
        [InlineData("0x0100", (ushort)0x100, 0, 4)]
        [InlineData("0x1000", (ushort)0x1000, 0, 4)]
        [InlineData("0xFFFF", ushort.MaxValue, 0, 4)]
        [InlineData("0x00_00", (ushort)0x0, 2, 4)]
        [InlineData("0x00_01", (ushort)0x1, 2, 4)]
        [InlineData("0x00_10", (ushort)0x10, 2, 4)]
        [InlineData("0x01_00", (ushort)0x100, 2, 4)]
        [InlineData("0x10_00", (ushort)0x1000, 2, 4)]
        [InlineData("0xFF_FF", ushort.MaxValue, 2, 4)]
        [InlineData("0x01_00", (ushort)0x100, 2, 0)]

        public void HexaDecimal(string expected, ushort value, int groupSize, int minDigits)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((ushort)0, -1, 0, "groupSize", "'groupSize' is less than 0.")]
        [InlineData((ushort)0, 0, -1, "minDigits", "'minDigits' is less than 0.")]
        [InlineData((ushort)0, 4, 3, "groupSize", "'groupSize' equals 4 or more.")]
        [InlineData((ushort)0, 5, 3, "groupSize", "'groupSize' equals 4 or more.")]
        public void HexaDecimalArgumentOutOfError(ushort value, int groupSize, int minDigits, string paramName, string message)
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
        [InlineData((ushort)0, 5, 4, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        [InlineData((ushort)0, 4, 4, "groupSize", "'groupSize' equals 'minDigits' or more.")]
        public void HexaDecimalArgumentError(ushort value, int groupSize, int minDigits, string paramName, string message)
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
