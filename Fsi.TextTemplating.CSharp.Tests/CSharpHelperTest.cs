using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpHelperTest
    {
        public CSharpHelperTest()
        { }
        
        [Theory]
        [InlineData((byte)0, 0, 0, "0")]
        [InlineData((byte)1, 0, 0, "1")]
        [InlineData((byte)100, 0, 0, "100")]
        [InlineData(byte.MaxValue, 0, 0, "255")]
        [InlineData(byte.MinValue, 0, 0, "0")]
        [InlineData((byte)0, 1, 0, "0")]
        [InlineData((byte)1, 1, 0, "1")]
        [InlineData((byte)10, 1, 0, "1_0")]
        [InlineData((byte)100, 1, 0, "1_0_0")]
        [InlineData(byte.MaxValue, 1, 0, "2_5_5")]
        [InlineData((byte)0, 0, 2, "00")]
        [InlineData((byte)1, 0, 2, "01")]
        [InlineData((byte)10, 0, 2, "10")]
        [InlineData((byte)100, 0, 2, "100")]
        [InlineData(byte.MaxValue, 0, 4, "0255")]
        [InlineData((byte)0, 1, 2, "0_0")]
        [InlineData((byte)1, 1, 2, "0_1")]
        [InlineData((byte)10, 1, 2, "1_0")]
        [InlineData((byte)100, 1, 2, "1_0_0")]
        [InlineData(byte.MaxValue, 1, 4, "0_2_5_5")]
        public void DecimalByte(byte value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((byte)0, 0, 0, "0x0")]
        [InlineData((byte)1, 0, 0, "0x1")]
        [InlineData((byte)10, 0, 0, "0xA")]
        [InlineData((byte)15, 0, 0, "0xF")]
        [InlineData((byte)16, 0, 0, "0x10")]
        [InlineData((byte)160, 0, 0, "0xA0")]
        [InlineData(byte.MaxValue, 0, 0, "0xFF")]
        [InlineData((byte)0, 0, 2, "0x00")]
        [InlineData((byte)1, 0, 2, "0x01")]
        [InlineData((byte)10, 0, 2, "0x0A")]
        [InlineData((byte)15, 0, 2, "0x0F")]
        [InlineData((byte)16, 0, 2, "0x10")]
        [InlineData((byte)160, 0, 2, "0xA0")]
        [InlineData(byte.MaxValue, 0, 2, "0xFF")]
        public void HexaDecimalByte(byte value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((short)0, 0, 0, "0")]
        [InlineData((short)1, 0, 0, "1")]
        [InlineData((short)-1, 0, 0, "-1")]
        [InlineData((short)100, 0, 0, "100")]
        [InlineData((short)-100, 0, 0, "-100")]
        [InlineData((short)1000, 0, 0, "1000")]
        [InlineData((short)-1000, 0, 0, "-1000")]
        [InlineData(short.MaxValue, 0, 0, "32767")]
        [InlineData(short.MinValue, 0, 0, "-32768")]
        [InlineData((short)0, 3, 0, "0")]
        [InlineData((short)1, 3, 0, "1")]
        [InlineData((short)-1, 3, 0, "-1")]
        [InlineData((short)100, 3, 0, "100")]
        [InlineData((short)-100, 3, 0, "-100")]
        [InlineData((short)1000, 3, 0, "1_000")]
        [InlineData((short)-1000, 3, 0, "-1_000")]
        [InlineData(short.MaxValue, 3, 0, "32_767")]
        [InlineData(short.MinValue, 3, 0, "-32_768")]
        public void DecimalInt16(short value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((short)0, 0, 0, "0x0")]
        [InlineData((short)1, 0, 0, "0x1")]
        [InlineData((short)10, 0, 0, "0xA")]
        [InlineData((short)15, 0, 0, "0xF")]
        [InlineData((short)16, 0, 0, "0x10")]
        [InlineData((short)160, 0, 0, "0xA0")]
        [InlineData((short)2560, 0, 0, "0xA00")]
        [InlineData((short)-24576, 0, 0, "0xA000")]
        [InlineData(short.MaxValue, 0, 0, "0x7FFF")]
        [InlineData(short.MinValue, 0, 0, "0x8000")]
        [InlineData((short)0, 2, 0, "0x00")]
        [InlineData((short)1, 2, 0, "0x01")]
        [InlineData((short)10, 2, 0, "0x0A")]
        [InlineData((short)15, 2, 0, "0x0F")]
        [InlineData((short)16, 2, 0, "0x10")]
        [InlineData((short)160, 2, 0, "0xA0")]
        [InlineData((short)2560, 2, 0, "0x0A_00")]
        [InlineData((short)-24576, 2, 0, "0xA0_00")]
        [InlineData(short.MaxValue, 2, 0, "0x7F_FF")]
        [InlineData(short.MinValue, 2, 0, "0x80_00")]
        [InlineData((short)0, 0, 4, "0x0000")]
        [InlineData((short)1, 0, 4, "0x0001")]
        [InlineData((short)10, 0, 4, "0x000A")]
        [InlineData((short)15, 0, 4, "0x000F")]
        [InlineData((short)16, 0, 4, "0x0010")]
        [InlineData((short)160, 0, 4, "0x00A0")]
        [InlineData((short)2560, 0, 4, "0x0A00")]
        [InlineData((short)-24576, 0, 4, "0xA000")]
        [InlineData(short.MaxValue, 0, 4, "0x7FFF")]
        [InlineData(short.MinValue, 0, 4, "0x8000")]
        [InlineData((short)0, 2, 4, "0x00_00")]
        [InlineData((short)1, 2, 4, "0x00_01")]
        [InlineData((short)10, 2, 4, "0x00_0A")]
        [InlineData((short)15, 2, 4, "0x00_0F")]
        [InlineData((short)16, 2, 4, "0x00_10")]
        [InlineData((short)160, 2, 4, "0x00_A0")]
        [InlineData((short)2560, 2, 4, "0x0A_00")]
        [InlineData((short)-24576, 2, 4, "0xA0_00")]
        [InlineData(short.MaxValue, 2, 4, "0x7F_FF")]
        [InlineData(short.MinValue, 2, 4, "0x80_00")]
        public void HexaDecimalInt16(short value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.HexaDecimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0, 0, 0, "0")]
        [InlineData(1, 0, 0, "1")]
        [InlineData(-1, 0, 0, "-1")]
        [InlineData(10, 0, 0, "10")]
        [InlineData(-10, 0, 0, "-10")]
        [InlineData(100, 0, 0, "100")]
        [InlineData(-100, 0, 0, "-100")]
        [InlineData(1000, 0, 0, "1000")]
        [InlineData(-1000, 0, 0, "-1000")]
        [InlineData(100000, 0, 0, "100000")]
        [InlineData(-100000, 0, 0, "-100000")]
        [InlineData(1000000, 0, 0, "1000000")]
        [InlineData(-1000000, 0, 0, "-1000000")]
        [InlineData(int.MaxValue, 0, 0, "2147483647")]
        [InlineData(int.MinValue, 0, 0, "-2147483648")]
        [InlineData(0, 3, 0, "0")]
        [InlineData(1, 3, 0, "1")]
        [InlineData(-1, 3, 0, "-1")]
        [InlineData(10, 3, 0, "10")]
        [InlineData(-10, 3, 0, "-10")]
        [InlineData(100, 3, 0, "100")]
        [InlineData(-100, 3, 0, "-100")]
        [InlineData(1000, 3, 0, "1_000")]
        [InlineData(-1000, 3, 0, "-1_000")]
        [InlineData(100000, 3, 0, "100_000")]
        [InlineData(-100000, 3, 0, "-100_000")]
        [InlineData(1000000, 3, 0, "1_000_000")]
        [InlineData(-1000000, 3, 0, "-1_000_000")]
        [InlineData(int.MaxValue, 3, 0, "2_147_483_647")]
        [InlineData(int.MinValue, 3, 0, "-2_147_483_648")]
        public void DecimalInt32(int value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0L, 0, 0, "0L")]
        [InlineData(1L, 0, 0, "1L")]
        [InlineData(-1L, 0, 0, "-1L")]
        [InlineData(100L, 0, 0, "100L")]
        [InlineData(-100L, 0, 0, "-100L")]
        [InlineData(1000L, 0, 0, "1000L")]
        [InlineData(-1000L, 0, 0, "-1000L")]
        [InlineData(100000L, 0, 0, "100000L")]
        [InlineData(-100000L, 0, 0, "-100000L")]
        [InlineData(1000000L, 0, 0, "1000000L")]
        [InlineData(-1000000L, 0, 0, "-1000000L")]
        [InlineData(long.MaxValue, 0, 0, "9223372036854775807L")]
        [InlineData(long.MinValue, 0, 0, "-9223372036854775808L")]
        [InlineData(0L, 3, 0, "0L")]
        [InlineData(1L, 3, 0, "1L")]
        [InlineData(-1L, 3, 0, "-1L")]
        [InlineData(100L, 3, 0, "100L")]
        [InlineData(-100L, 3, 0, "-100L")]
        [InlineData(1000L, 3, 0, "1_000L")]
        [InlineData(-1000L, 3, 0, "-1_000L")]
        [InlineData(-100000L, 3, 0, "-100_000L")]
        [InlineData(100000L, 3, 0, "100_000L")]
        [InlineData(1000000L, 3, 0, "1_000_000L")]
        [InlineData(-1000000L, 3, 0, "-1_000_000L")]
        [InlineData(long.MaxValue, 3, 0, "9_223_372_036_854_775_807L")]
        [InlineData(long.MinValue, 3, 0, "-9_223_372_036_854_775_808L")]
        public void DecimalInt64(long value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData((ushort)0, 0, 0, "0")]
        [InlineData((ushort)1, 0, 0, "1")]
        [InlineData((ushort)10, 0, 0, "10")]
        [InlineData((ushort)100, 0, 0, "100")]
        [InlineData((ushort)1000, 0, 0, "1000")]
        [InlineData(ushort.MaxValue, 0, 0, "65535")]
        [InlineData((ushort)0, 3, 0, "0")]
        [InlineData((ushort)1, 3, 0, "1")]
        [InlineData((ushort)10, 3, 0, "10")]
        [InlineData((ushort)100, 3, 0, "100")]
        [InlineData((ushort)1000, 3, 0, "1_000")]
        [InlineData(ushort.MaxValue, 3, 0, "65_535")]
        public void DecimalUInt16(ushort value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

        [Theory]
        [InlineData(0u, 0, 0, "0u")]
        [InlineData(1u, 0, 0, "1u")]
        [InlineData(10u, 0, 0, "10u")]
        [InlineData(100u, 0, 0, "100u")]
        [InlineData(1000u, 0, 0, "1000u")]
        [InlineData(uint.MaxValue, 0, 0, "4294967295u")]
        [InlineData(0u, 3, 0, "0u")]
        [InlineData(1u, 3, 0, "1u")]
        [InlineData(10u, 3, 0, "10u")]
        [InlineData(100u, 3, 0, "100u")]
        [InlineData(1000u, 3, 0, "1_000u")]
        [InlineData(10000u, 3, 0, "10_000u")]
        [InlineData(100000u, 3, 0, "100_000u")]
        [InlineData(1000000u, 3, 0, "1_000_000u")]
        [InlineData(uint.MaxValue, 3, 0, "4_294_967_295u")]
        public void DecimalUInt32(uint value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }
        [Theory]
        [InlineData(0uL, 0, 0, "0uL")]
        [InlineData(1uL, 0, 0, "1uL")]
        [InlineData(10uL, 0, 0, "10uL")]
        [InlineData(100uL, 0, 0, "100uL")]
        [InlineData(1000uL, 0, 0, "1000uL")]
        [InlineData(ulong.MaxValue, 0, 0, "18446744073709551615uL")]
        [InlineData(0uL, 3, 0, "0uL")]
        [InlineData(1uL, 3, 0, "1uL")]
        [InlineData(10uL, 3, 0, "10uL")]
        [InlineData(100uL, 3, 0, "100uL")]
        [InlineData(1000uL, 3, 0, "1_000uL")]
        [InlineData(10000uL, 3, 0, "10_000uL")]
        [InlineData(100000uL, 3, 0, "100_000uL")]
        [InlineData(1000000uL, 3, 0, "1_000_000uL")]
        [InlineData(ulong.MaxValue, 3, 0, "18_446_744_073_709_551_615uL")]
        public void DecimalUInt64(ulong value, int groupSize, int minDigits, string expected)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.Decimal(value, groupSize, minDigits));
        }

    }
}
