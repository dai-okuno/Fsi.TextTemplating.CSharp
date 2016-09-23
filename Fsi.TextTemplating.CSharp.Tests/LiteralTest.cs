using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    internal interface IIntegerTest<T>
    {

        void Decimal(string expected, T value, int groupSize, int minDigits);
        void HexaDecimal(string expected, T value, int groupSize, int minDigits);
    }
}
