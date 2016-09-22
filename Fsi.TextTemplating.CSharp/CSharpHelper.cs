using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Fsi.TextTemplating.Utility;

namespace Fsi.TextTemplating
{
    using System.Globalization;
    using System.Text;
    using TypeNames;

    public partial class CSharpHelper
    {
        public CSharpHelper()
        {
            Factory = new FlyweightFactory();
            Context = new SourceFileFormatterContext(Factory.GlobalNamespaceName);
        }
        private static readonly char[] _Chars0 = CreateArray(32, '0');

        private static readonly char[] _EmptySuffix = new char[0];

        private static readonly char[] _HexPrefix = new[] { '0', 'x' };

        private static readonly string[] _DecimalFormats = Enumerable.Range(0, 9).Select(p => p == 0 ? "D" : ("D" + p)).ToArray();

        private static readonly string[] _HexaDecimalFormats = Enumerable.Range(0, 9).Select(p => p == 0 ? "X" : ("X" + p)).ToArray();

        private static NumberFormatInfo Invariant { get; }
            = NumberFormatInfo.InvariantInfo;


        #region byte

        private static char[] ByteSuffix => _EmptySuffix;

        private const int DefaultByteDecimalMaxLength = 3;

        private const int DefaultByteHexMaxLength = 2;

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
                return FormatDecimal(value, minDigits, ByteSuffix);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, ByteSuffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, ByteSuffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, ByteSuffix, groupSize);
            }
        }

        #endregion

        #region short

        private static char[] Int16Suffix => _EmptySuffix;

        private const int DefaultInt16DecimalMaxLength = 5;

        private const int DefaultInt16HexMaxLength = 4;

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
                return FormatDecimal(value, minDigits, Int16Suffix);
            }
            else if (value < 0)
            {
                return FormatNegativeDecimal(value, minDigits, Int16Suffix, groupSize);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, Int16Suffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, Int16Suffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, Int16Suffix, groupSize);
            }
        }

        #endregion

        #region int

        private static char[] Int32Suffix
            => _EmptySuffix;

        private const int DefaultInt32DecimalMaxLength = 10;

        private const int DefaultInt32HexMaxLength = 8;

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
                return FormatDecimal<int>(value, minDigits, Int32Suffix);
            }
            else if (value < 0)
            {
                return FormatNegativeDecimal(value, minDigits, Int32Suffix, groupSize);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, Int32Suffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, Int32Suffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, Int32Suffix, groupSize);
            }
        }

        #endregion

        #region long

        private static readonly char[] Int64Suffix = new char[] { 'L' };

        private const int DefaultInt64DecimalMaxLength = 19;

        private const int DefaultInt64HexMaxLength = 16;

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
                return FormatDecimal(value, minDigits, Int64Suffix);
            }
            else if (value < 0L)
            {
                return FormatNegativeDecimal(value, minDigits, Int64Suffix, groupSize);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, Int64Suffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, Int64Suffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, Int64Suffix, groupSize);
            }
        }

        #endregion

        #region sbyte

        private static char[] SByteSuffix => _EmptySuffix;

        private const int DefaultSByteDecimalMaxLength = 3;

        private const int DefaultSByteHexMaxLength = 2;

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
                return FormatDecimal(value, minDigits, SByteSuffix);
            }
            else if (value < 0)
            {
                return FormatNegativeDecimal(value, minDigits, SByteSuffix, groupSize);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, SByteSuffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, SByteSuffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, SByteSuffix, groupSize);
            }
        }

        #endregion

        #region ushort

        private static char[] UInt16Suffix => _EmptySuffix;

        private const int DefaultUInt16DecimalMaxLength = 5;

        private const int DefaultUInt16HexMaxLength = 4;

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
                return FormatDecimal(value, minDigits, UInt16Suffix);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, UInt16Suffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, UInt16Suffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, UInt16Suffix, groupSize);
            }
        }

        #endregion

        #region uint

        private static readonly char[] UInt32Suffix = new char[] { 'u' };

        private const int DefaultUInt32DecimalMaxLength = 10;

        private const int DefaultUInt32HexMaxLength = 8;

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
                return FormatDecimal(value, minDigits, UInt32Suffix);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, UInt32Suffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, UInt32Suffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, UInt32Suffix, groupSize);
            }
        }

        #endregion

        #region ulong

        private static readonly char[] UInt64Suffix = new char[] { 'u', 'L' };

        private const int DefaultUInt64DecimalMaxLength = 20;

        private const int DefaultUInt64HexMaxLength = 16;

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
                return FormatDecimal(value, minDigits, UInt64Suffix);
            }
            else
            {
                return FormatNaturalDecimal(value, minDigits, UInt64Suffix, groupSize);
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
                return FormatHexaDecimal(value, minDigits, UInt64Suffix);
            }
            else
            {
                return FormatHexaDecimal(value, minDigits, UInt64Suffix, groupSize);
            }
        }

        #endregion

        #region System.Type
        private FlyweightFactory Factory { get; }
        /// <summary></summary>
        private IFormatterContext Context { get; set; }
        /// <summary></summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendCRefNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendCRefNameTo(typeName, Context);
        }

        /// <summary></summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendFullNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendFullNameTo(typeName);
        }

        /// <summary></summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        public void AppendNameTo(Type type, StringBuilder typeName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            Factory.GetTypeName(type).AppendNameTo(typeName, Context);
        }

        /// <summary></summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDisposable BeginNamespace(string name)
        {
            var namespaceName = Factory.GetNamespaceName(
                Context.NamespaceName.IsGlobal
                ? name
                : (new StringBuilder(Context.NamespaceName.FullName.Length + 1 + name.Length).Append(Context.NamespaceName.FullName).Append('.').Append(name).ToString()));
            var context = new NamespaceDeclarationFormatterContext(Context, namespaceName);
            var declared = context.NamespaceName;
            do
            {
                declared.IsDeclared = true;
            } while ((declared = declared.Parent) != Context.NamespaceName);
            Context = context;
            return new NamespaceDeclaration(this);
        }

        /// <summary></summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string CRefNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetCRefName(Context);
        }

        /// <summary></summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string FullNameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetFullName();
        }

        /// <summary></summary>
        /// <param name="namespaceName"></param>
        public void Import(string namespaceName)
        {
            var ns = Factory.GetNamespaceName(namespaceName);
            Context.Import(ns);
            ns.BeginImport();
        }

        /// <summary></summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string NameOf(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Factory.GetTypeName(type).GetName(Context);
        }

        /// <summary></summary>
        internal void EndNamespace()
        {
            foreach (var imported in Context.ImportedNamespaceNames)
            {
                imported.EndImport();
            }
            var context = Context;
            Context = context.Parent;
            var declared = context.NamespaceName;
            do
            {
                declared.IsDeclared = false;
            } while ((declared = declared.Parent) != Context.NamespaceName);
        }

        /// <summary></summary>
        private sealed class NamespaceDeclaration
            : IDisposable
        {
            /// <summary></summary>
            /// <param name="helper"></param>
            public NamespaceDeclaration(CSharpHelper helper)
            {
                Helper = helper;
            }

            /// <summary></summary>
            private CSharpHelper Helper { get; }

            /// <summary>Gets or sets this object is disposed.</summary>
            private bool IsDisposed { get; set; }

            /// <summary>Invoke <see cref="EndNamespace"/> of <see cref="ITypeFormatter"/>.</summary>
            public void Dispose()
            {
                if (IsDisposed) return;
                IsDisposed = true;
                Helper.EndNamespace();
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        /// <summary>Converts the value of integer to an equivalent decimal string.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="minDigits"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        private static string FormatDecimal<T>(T value, int minDigits, char[] suffix)
            where T : IFormattable
        {
            var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
            if (0 < suffix.Length)
            {
                var chars = new char[str.Length + suffix.Length];
                str.CopyTo(0, chars, 0, str.Length);
                Array.Copy(suffix, 0, chars, str.Length, suffix.Length);
                return new string(chars);
            }
            else
            {
                return str;
            }
        }

        /// <summary>Converts the value of integer to an equivalent hexa-decimal string.</summary>
        /// <typeparam name="T">The integer type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="minDigits">The precision specifier</param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        private static string FormatHexaDecimal<T>(T value, int minDigits, char[] suffix)
            where T : IFormattable
        {
            var str = value.ToString(GetHexaDecimalFormat(minDigits), Invariant);
            var chars = new char[_HexPrefix.Length + str.Length + suffix.Length];
            _HexPrefix.CopyTo(chars, 0);
            str.CopyTo(0, chars, _HexPrefix.Length, str.Length);
            suffix.CopyTo(chars, _HexPrefix.Length + str.Length);
            return new string(chars);
        }

        /// <summary>Converts the value of integer to an equivalent hexa-decimal string.</summary>
        /// <typeparam name="T">The integer type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="minDigits">The precision specifier</param>
        /// <param name="suffix"></param>
        /// <param name="groupSize">the size of group separator.</param>
        /// <returns></returns>
        private static string FormatHexaDecimal<T>(T value, int minDigits, char[] suffix, int groupSize)
            where T : IFormattable
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
                chars = new char[_HexPrefix.Length + str.Length + separatorCount + offset + suffix.Length];
                _HexPrefix.CopyTo(chars, 0);
                c = _HexPrefix.Length;
                Array.Copy(_Chars0, 0, chars, c, offset);
                c += offset;
                Copy(str, ref s, chars, ref c, rem);
            }
            else
            {
                separatorCount -= 1;
                chars = new char[_HexPrefix.Length + str.Length + separatorCount + suffix.Length];
                _HexPrefix.CopyTo(chars, 0);
                c = _HexPrefix.Length;
                Copy(str, ref s, chars, ref c, groupSize);
            }
            while (s < str.Length)
            {
                chars[c++] = '_';
                Copy(str, ref s, chars, ref c, groupSize);
            }
            if (0 < suffix.Length)
            {
                Array.Copy(suffix, 0, chars, c, suffix.Length);
            }
            return new string(chars);
        }

        /// <summary>Converts the value of natural (positive or zero) integer to an equivalent decimal string.</summary>
        /// <typeparam name="T">The integer type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="minDigits">The precision specifier</param>
        /// <param name="suffix"></param>
        /// <param name="groupSize">the size of group separator.</param>
        /// <returns></returns>
        private static string FormatNaturalDecimal<T>(T value, int minDigits, char[] suffix, int groupSize)
            where T : IFormattable
        {
            var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
            int rem;
            var separatorCount = DivRem(str.Length, groupSize, out rem);
            char[] chars;
            var c = 0;
            var s = 0;

            if (0 < rem)
            {
                chars = new char[str.Length + separatorCount + suffix.Length];
                Copy(str, ref s, chars, ref c, rem);
            }
            else
            {
                separatorCount -= 1;
                chars = new char[str.Length + separatorCount + suffix.Length];
                Copy(str, ref s, chars, ref c, groupSize);
            }

            while (s < str.Length)
            {
                chars[c++] = '_';
                Copy(str, ref s, chars, ref c, groupSize);
            }

            if (0 < suffix.Length)
            {
                Array.Copy(suffix, 0, chars, c, suffix.Length);
            }
            return new string(chars);
        }

        /// <summary>Converts the value of negative integer to an equivalent decimal string.</summary>
        /// <typeparam name="T">The integer type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="minDigits">The precision specifier</param>
        /// <param name="suffix"></param>
        /// <param name="groupSize">the size of group separator.</param>
        /// <returns></returns>
        private static string FormatNegativeDecimal<T>(T value, int minDigits, char[] suffix, int groupSize)
            where T : IFormattable
        {
            var str = value.ToString(GetDecimalFormat(minDigits), Invariant);
            int rem;
            var separatorCount = DivRem(str.Length - 1, groupSize, out rem);
            char[] chars;
            var c = 1;
            var s = 1;
            if (0 < rem)
            {
                chars = new char[str.Length + separatorCount + suffix.Length];
                Copy(str, ref s, chars, ref c, rem);
            }
            else
            {
                separatorCount -= 1;
                chars = new char[str.Length + separatorCount + suffix.Length];
                Copy(str, ref s, chars, ref c, groupSize);
            }
            chars[0] = '-';
            while (s < str.Length)
            {
                chars[c++] = '_';
                Copy(str, ref s, chars, ref c, groupSize);
            }
            if (0 < suffix.Length)
            {
                Array.Copy(suffix, 0, chars, c, suffix.Length);
            }
            return new string(chars);
        }

        /// <summary>Returns the decimal format string with specified precision specifier.</summary>
        /// <param name="minDigits">The precision specifier</param>
        /// <returns></returns>
        private static string GetDecimalFormat(int minDigits)
        {
            if (minDigits < 0) throw new ArgumentOutOfRangeException(nameof(minDigits));
            if (minDigits < _DecimalFormats.Length)
            {
                return _DecimalFormats[minDigits];
            }
            else
            {
                return "D" + minDigits;
            }
        }

        /// <summary>Returns the hexa-decimal format string with specified precision specifier.</summary>
        /// <param name="minDigits">The precision specifier</param>
        /// <returns></returns>
        private static string GetHexaDecimalFormat(int minDigits)
        {
            if (minDigits < 0) throw new ArgumentOutOfRangeException(nameof(minDigits));
            if (minDigits < _HexaDecimalFormats.Length)
            {
                return _HexaDecimalFormats[minDigits];
            }
            else
            {
                return "X" + minDigits;
            }
        }

    }

}
