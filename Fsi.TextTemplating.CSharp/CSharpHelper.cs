using System;
using System.Globalization;
using System.Linq;

using static Fsi.TextTemplating.Utility;

namespace Fsi.TextTemplating
{
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
        
        /// <summary>Returns the decimal format string with specified precision specifier.</summary>
        /// <param name="minDigits">The precision specifier</param>
        /// <returns></returns>
        private static string GetDecimalFormat(int minDigits)
        {
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
