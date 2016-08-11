using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.TypeNames.Tests
{
    public class CSharpTypeFormatterTest
    {

        [Theory]
        [InlineData(typeof(int[]), "int[]")]
        [InlineData(typeof(int[,]), "int[,]")]
        [InlineData(typeof(int[,,]), "int[,,]")]
        [InlineData(typeof(int[,,,]), "int[,,,]")]
        [InlineData(typeof(int[,,,,]), "int[,,,,]")]
        [InlineData(typeof(int[][]), "int[][]")]
        [InlineData(typeof(int[][,]), "int[][,]")]
        [InlineData(typeof(int[,][]), "int[,][]")]
        [InlineData(typeof(DateTime[]), "DateTime[]")]
        [InlineData(typeof(DateTime[,]), "DateTime[,]")]
        [InlineData(typeof(DateTime[,,]), "DateTime[,,]")]
        [InlineData(typeof(DateTime[,,,]), "DateTime[,,,]")]
        [InlineData(typeof(DateTime[,,,,]), "DateTime[,,,,]")]
        [InlineData(typeof(DateTime[][]), "DateTime[][]")]
        [InlineData(typeof(DateTime[][,]), "DateTime[][,]")]
        [InlineData(typeof(DateTime[,][]), "DateTime[,][]")]
        public void NameOfArray(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
            formatter.Import("System");
            Assert.Equal(expected, formatter.NameOf(type));

            var builder = new StringBuilder();
            formatter.AppendNameTo(type, builder);
            Assert.Equal(expected, builder.ToString());
        }

        [Theory]
        [InlineData(typeof(int?), "int?")]
        [InlineData(typeof(DateTime?), "DateTime?")]
        public void NameOfNullable(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
            formatter.Import("System");
            Assert.Equal(expected, formatter.NameOf(type));

            var builder = new StringBuilder();
            formatter.AppendNameTo(type, builder);
            Assert.Equal(expected, builder.ToString());
        }

        [Theory]
        [InlineData(typeof(bool), "bool")]
        [InlineData(typeof(char), "char")]
        [InlineData(typeof(byte), "byte")]
        [InlineData(typeof(short), "short")]
        [InlineData(typeof(int), "int")]
        [InlineData(typeof(long), "long")]
        [InlineData(typeof(sbyte), "sbyte")]
        [InlineData(typeof(ushort), "ushort")]
        [InlineData(typeof(uint), "uint")]
        [InlineData(typeof(ulong), "ulong")]
        [InlineData(typeof(float), "float")]
        [InlineData(typeof(decimal), "decimal")]
        [InlineData(typeof(double), "double")]
        [InlineData(typeof(string), "string")]
        [InlineData(typeof(object), "object")]
        [InlineData(typeof(void), "void")]
        [InlineData(typeof(DateTime), "System.DateTime")]
        [InlineData(typeof(StringBuilder), "System.Text.StringBuilder")]
        [InlineData(typeof(Func<>), "System.Func<TResult>")]
        [InlineData(typeof(Func<int>), "System.Func<int>")]
        [InlineData(typeof(Func<DateTime, int>), "System.Func<System.DateTime, int>")]
        [InlineData(typeof(Func<DateTime, Action<string>, int>), "System.Func<System.DateTime, System.Action<string>, int>")]
        [InlineData(typeof(List<int>), "System.Collections.Generic.List<int>")]
        [InlineData(typeof(List<int>.Enumerator), "System.Collections.Generic.List<int>.Enumerator")]
        public void NameOf(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
            Assert.Equal(expected, formatter.NameOf(type));

            var builder = new StringBuilder();
            formatter.AppendNameTo(type, builder);
            Assert.Equal(expected, builder.ToString());
        }

        [Theory]
        [InlineData(typeof(bool), "bool")]
        [InlineData(typeof(char), "char")]
        [InlineData(typeof(byte), "byte")]
        [InlineData(typeof(short), "short")]
        [InlineData(typeof(int), "int")]
        [InlineData(typeof(long), "long")]
        [InlineData(typeof(sbyte), "sbyte")]
        [InlineData(typeof(ushort), "ushort")]
        [InlineData(typeof(uint), "uint")]
        [InlineData(typeof(ulong), "ulong")]
        [InlineData(typeof(float), "float")]
        [InlineData(typeof(decimal), "decimal")]
        [InlineData(typeof(double), "double")]
        [InlineData(typeof(string), "string")]
        [InlineData(typeof(object), "object")]
        [InlineData(typeof(void), "void")]
        [InlineData(typeof(DateTime), "System.DateTime")]
        [InlineData(typeof(StringBuilder), "System.Text.StringBuilder")]
        [InlineData(typeof(Func<>), "System.Func<TResult>")]
        [InlineData(typeof(Func<int>), "System.Func<int>")]
        [InlineData(typeof(Func<DateTime, int>), "System.Func<System.DateTime, int>")]
        [InlineData(typeof(Func<DateTime, Action<string>, int>), "System.Func<System.DateTime, System.Action<string>, int>")]
        [InlineData(typeof(List<int>), "System.Collections.Generic.List<int>")]
        [InlineData(typeof(List<int>.Enumerator), "System.Collections.Generic.List<int>.Enumerator")]
        public void FullNameOfPrimitive(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
            formatter.Import("System");
            Assert.Equal(expected, formatter.FullNameOf(type));

            var builder = new StringBuilder();
            formatter.AppendFullNameTo(type, builder);
            Assert.Equal(expected, builder.ToString());
        }

        [Theory]
        [InlineData(typeof(bool), "bool")]
        [InlineData(typeof(char), "char")]
        [InlineData(typeof(byte), "byte")]
        [InlineData(typeof(short), "short")]
        [InlineData(typeof(int), "int")]
        [InlineData(typeof(long), "long")]
        [InlineData(typeof(sbyte), "sbyte")]
        [InlineData(typeof(ushort), "ushort")]
        [InlineData(typeof(uint), "uint")]
        [InlineData(typeof(ulong), "ulong")]
        [InlineData(typeof(float), "float")]
        [InlineData(typeof(decimal), "decimal")]
        [InlineData(typeof(double), "double")]
        [InlineData(typeof(string), "string")]
        [InlineData(typeof(object), "object")]
        [InlineData(typeof(void), "void")]
        public void CRefOfPrimitive(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
            Assert.Equal(expected, formatter.CRefOf(type));

            var builder = new StringBuilder();
            formatter.AppendCRefTo(type, builder);
            Assert.Equal(expected, builder.ToString());

            formatter.Import("System");
            Assert.Equal(expected, formatter.CRefOf(type));

            builder.Clear();
            formatter.AppendCRefTo(type, builder);
            Assert.Equal(expected, builder.ToString());
        }

    }
}
