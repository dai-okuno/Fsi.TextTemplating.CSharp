using System;

using static Fsi.TextTemplating.Utility;

namespace Fsi.TextTemplating
{

    partial class CSharpHelper
    {

        private const int DefaultSByteDecimalMaxLength = 3;

        private const int DefaultSByteHexMaxLength = 2;

        private const int DefaultInt16DecimalMaxLength = 5;

        private const int DefaultInt16HexMaxLength = 4;

        private const int DefaultInt32DecimalMaxLength = 10;

        private const int DefaultInt32HexMaxLength = 8;

        private static char[] Int64Suffix => new[] { 'L' };

        private const int DefaultInt64DecimalMaxLength = 19;

        private const int DefaultInt64HexMaxLength = 16;

        private const int DefaultByteDecimalMaxLength = 3;

        private const int DefaultByteHexMaxLength = 2;

        private const int DefaultUInt16DecimalMaxLength = 5;

        private const int DefaultUInt16HexMaxLength = 4;

        private static char[] UInt32Suffix => new[] { 'u' };

        private const int DefaultUInt32DecimalMaxLength = 10;

        private const int DefaultUInt32HexMaxLength = 8;

        private static char[] UInt64Suffix => new[] { 'u', 'L' };

        private const int DefaultUInt64DecimalMaxLength = 20;

        private const int DefaultUInt64HexMaxLength = 16;

        /// <summary>Returns the decimal sbyte literals.</summary>
        /// <param name="value">The sbyte value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal sbyte literal.</returns>
        public string Decimal(sbyte value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultSByteDecimalMaxLength)
            {
                if (DefaultSByteDecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultSByteDecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                return value.ToString(GetDecimalFormat(minDigits), Invariant); ;
            }
            else if (value < 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length - 1, groupSize, out rem);
                char[] chars;
                var c = 1;
                var s = 1;
                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                chars[0] = '-';
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal sbyte literals.</summary>
        /// <param name="value">the sbyte value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal sbyte literals</returns>

        public string HexaDecimal(sbyte value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultSByteHexMaxLength)
            {
                if (DefaultSByteHexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultSByteHexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal short literals.</summary>
        /// <param name="value">The short value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal short literal.</returns>
        public string Decimal(short value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultInt16DecimalMaxLength)
            {
                if (DefaultInt16DecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultInt16DecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                return value.ToString(GetDecimalFormat(minDigits), Invariant); ;
            }
            else if (value < 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length - 1, groupSize, out rem);
                char[] chars;
                var c = 1;
                var s = 1;
                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                chars[0] = '-';
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal short literals.</summary>
        /// <param name="value">the short value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal short literals</returns>

        public string HexaDecimal(short value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultInt16HexMaxLength)
            {
                if (DefaultInt16HexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultInt16HexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal int literals.</summary>
        /// <param name="value">The int value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal int literal.</returns>
        public string Decimal(int value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultInt32DecimalMaxLength)
            {
                if (DefaultInt32DecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultInt32DecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                return value.ToString(GetDecimalFormat(minDigits), Invariant); ;
            }
            else if (value < 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length - 1, groupSize, out rem);
                char[] chars;
                var c = 1;
                var s = 1;
                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                chars[0] = '-';
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal int literals.</summary>
        /// <param name="value">the int value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal int literals</returns>

        public string HexaDecimal(int value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultInt32HexMaxLength)
            {
                if (DefaultInt32HexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultInt32HexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal long literals.</summary>
        /// <param name="value">The long value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal long literal.</returns>
        public string Decimal(long value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultInt64DecimalMaxLength)
            {
                if (DefaultInt64DecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultInt64DecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                var chars = new char[str.Length + Int64Suffix.Length];
                str.CopyTo(0, chars, 0, str.Length);
                Array.Copy(Int64Suffix, 0, chars, str.Length, Int64Suffix.Length);
                return new string(chars);
            }
            else if (value < 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length - 1, groupSize, out rem);
                char[] chars;
                var c = 1;
                var s = 1;
                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount + Int64Suffix.Length];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount + Int64Suffix.Length];
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                chars[0] = '-';
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                Array.Copy(Int64Suffix, 0, chars, c, Int64Suffix.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount + Int64Suffix.Length];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount + Int64Suffix.Length];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                Array.Copy(Int64Suffix, 0, chars, c, Int64Suffix.Length);
                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal long literals.</summary>
        /// <param name="value">the long value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal long literals</returns>

        public string HexaDecimal(long value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultInt64HexMaxLength)
            {
                if (DefaultInt64HexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultInt64HexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length + Int64Suffix.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                Int64Suffix.CopyTo(chars, _HexPrefix.Length + str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset + Int64Suffix.Length];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + Int64Suffix.Length];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                Array.Copy(Int64Suffix, 0, chars, c, Int64Suffix.Length);
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal byte literals.</summary>
        /// <param name="value">The byte value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal byte literal.</returns>
        public string Decimal(byte value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultByteDecimalMaxLength)
            {
                if (DefaultByteDecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultByteDecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                return value.ToString(GetDecimalFormat(minDigits), Invariant); ;
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal byte literals.</summary>
        /// <param name="value">the byte value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal byte literals</returns>

        public string HexaDecimal(byte value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);

            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);


            if (minDigits < DefaultByteHexMaxLength)
            {
                if (DefaultByteHexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultByteHexMaxLength);

            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));

            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal ushort literals.</summary>
        /// <param name="value">The ushort value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal ushort literal.</returns>
        public string Decimal(ushort value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultUInt16DecimalMaxLength)
            {
                if (DefaultUInt16DecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultUInt16DecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                return value.ToString(GetDecimalFormat(minDigits), Invariant); ;
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal ushort literals.</summary>
        /// <param name="value">the ushort value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal ushort literals</returns>

        public string HexaDecimal(ushort value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);

            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultUInt16HexMaxLength)
            {
                if (DefaultUInt16HexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultUInt16HexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal uint literals.</summary>
        /// <param name="value">The uint value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal uint literal.</returns>
        public string Decimal(uint value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultUInt32DecimalMaxLength)
            {
                if (DefaultUInt32DecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultUInt32DecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                var chars = new char[str.Length + UInt32Suffix.Length];
                str.CopyTo(0, chars, 0, str.Length);
                Array.Copy(UInt32Suffix, 0, chars, str.Length, UInt32Suffix.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount + UInt32Suffix.Length];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount + UInt32Suffix.Length];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                Array.Copy(UInt32Suffix, 0, chars, c, UInt32Suffix.Length);
                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal uint literals.</summary>
        /// <param name="value">the uint value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal uint literals</returns>

        public string HexaDecimal(uint value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultUInt32HexMaxLength)
            {
                if (DefaultUInt32HexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultUInt32HexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length + UInt32Suffix.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                UInt32Suffix.CopyTo(chars, _HexPrefix.Length + str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset + UInt32Suffix.Length];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + UInt32Suffix.Length];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                Array.Copy(UInt32Suffix, 0, chars, c, UInt32Suffix.Length);
                return new string(chars);
            }
        }

        /// <summary>Returns the decimal ulong literals.</summary>
        /// <param name="value">The ulong value.</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The decimal ulong literal.</returns>
        public string Decimal(ulong value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);
            if (minDigits < DefaultUInt64DecimalMaxLength)
            {
                if (DefaultUInt64DecimalMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultUInt64DecimalMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                var chars = new char[str.Length + UInt64Suffix.Length];
                str.CopyTo(0, chars, 0, str.Length);
                Array.Copy(UInt64Suffix, 0, chars, str.Length, UInt64Suffix.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                var c = 0;
                var s = 0;

                if (0 < rem)
                {
                    chars = new char[str.Length + separatorCount + UInt64Suffix.Length];
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[str.Length + separatorCount + UInt64Suffix.Length];
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }

                Array.Copy(UInt64Suffix, 0, chars, c, UInt64Suffix.Length);
                return new string(chars);
            }
        }

        /// <summary>Returns the hexadecimal ulong literals.</summary>
        /// <param name="value">the ulong value</param>
        /// <param name="groupSize">The number of digits between separators.</param>
        /// <param name="minDigits">The minimum number of digits.</param>
        /// <returns>The hexadecimal ulong literals</returns>

        public string HexaDecimal(ulong value, int groupSize, int minDigits)
        {
            if (groupSize < 0) throw Error.ArgumentLessThanValue(nameof(groupSize), 0);
            if (minDigits < 0) throw Error.ArgumentLessThanValue(nameof(minDigits), 0);

            if (minDigits < DefaultUInt64HexMaxLength)
            {
                if (DefaultUInt64HexMaxLength <= groupSize) throw Error.ArgumentEqualsValueOrMore(nameof(groupSize), DefaultUInt64HexMaxLength);
            }
            else
            {
                if (minDigits <= groupSize) throw Error.ArgumentEqualsOtherOrMore(nameof(groupSize), nameof(minDigits));
            }

            if (groupSize == 0)
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                var chars = new char[_HexPrefix.Length + str.Length + UInt64Suffix.Length];
                _HexPrefix.CopyTo(chars, 0);
                str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
                UInt64Suffix.CopyTo(chars, _HexPrefix.Length + str.Length);
                return new string(chars);
            }
            else
            {
                var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
                int rem;
                var separatorCount = DivRem(str.Length, groupSize, out rem);
                char[] chars;
                int c;
                var s = 0;
                if (0 < rem)
                {
                    var offset = groupSize - rem;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset + UInt64Suffix.Length];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Array.Copy(_Chars0, 0, chars, c, offset);
                    c += offset;
                    Copy(str, ref s, chars, ref c, rem);
                }
                else
                {
                    separatorCount -= 1;
                    chars = new char[_HexPrefix.Length + str.Length + separatorCount + UInt64Suffix.Length];
                    _HexPrefix.CopyTo(chars, 0);
                    c = _HexPrefix.Length;
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                while (s < str.Length)
                {
                    chars[c++] = '_';
                    Copy(str, ref s, chars, ref c, groupSize);
                }
                Array.Copy(UInt64Suffix, 0, chars, c, UInt64Suffix.Length);
                return new string(chars);
            }
        }
    }
}
