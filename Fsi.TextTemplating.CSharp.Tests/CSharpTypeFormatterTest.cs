using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class CSharpTypeFormatterTest
    {

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
        public void NameOfPrimitive(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
            Assert.Equal(expected, formatter.NameOf(type));

            var builder = new StringBuilder();
            formatter.AppendNameTo(type, builder);
            Assert.Equal(expected, builder.ToString());
        }

        [Theory]
        [InlineData(typeof(bool[]), "bool[]")]
        [InlineData(typeof(char[]), "char[]")]
        [InlineData(typeof(byte[]), "byte[]")]
        [InlineData(typeof(short[]), "short[]")]
        [InlineData(typeof(int[]), "int[]")]
        [InlineData(typeof(long[]), "long[]")]
        [InlineData(typeof(sbyte[]), "sbyte[]")]
        [InlineData(typeof(ushort[]), "ushort[]")]
        [InlineData(typeof(uint[]), "uint[]")]
        [InlineData(typeof(ulong[]), "ulong[]")]
        [InlineData(typeof(float[]), "float[]")]
        [InlineData(typeof(decimal[]), "decimal[]")]
        [InlineData(typeof(double[]), "double[]")]
        [InlineData(typeof(string[]), "string[]")]
        [InlineData(typeof(object[]), "object[]")]
        [InlineData(typeof(bool[,]), "bool[,]")]
        [InlineData(typeof(char[,]), "char[,]")]
        [InlineData(typeof(byte[,]), "byte[,]")]
        [InlineData(typeof(short[,]), "short[,]")]
        [InlineData(typeof(int[,]), "int[,]")]
        [InlineData(typeof(long[,]), "long[,]")]
        [InlineData(typeof(sbyte[,]), "sbyte[,]")]
        [InlineData(typeof(ushort[,]), "ushort[,]")]
        [InlineData(typeof(uint[,]), "uint[,]")]
        [InlineData(typeof(ulong[,]), "ulong[,]")]
        [InlineData(typeof(float[,]), "float[,]")]
        [InlineData(typeof(decimal[,]), "decimal[,]")]
        [InlineData(typeof(double[,]), "double[,]")]
        [InlineData(typeof(string[,]), "string[,]")]
        [InlineData(typeof(object[,]), "object[,]")]
        [InlineData(typeof(bool[,,]), "bool[,,]")]
        [InlineData(typeof(char[,,]), "char[,,]")]
        [InlineData(typeof(byte[,,]), "byte[,,]")]
        [InlineData(typeof(short[,,]), "short[,,]")]
        [InlineData(typeof(int[,,]), "int[,,]")]
        [InlineData(typeof(long[,,]), "long[,,]")]
        [InlineData(typeof(sbyte[,,]), "sbyte[,,]")]
        [InlineData(typeof(ushort[,,]), "ushort[,,]")]
        [InlineData(typeof(uint[,,]), "uint[,,]")]
        [InlineData(typeof(ulong[,,]), "ulong[,,]")]
        [InlineData(typeof(float[,,]), "float[,,]")]
        [InlineData(typeof(decimal[,,]), "decimal[,,]")]
        [InlineData(typeof(double[,,]), "double[,,]")]
        [InlineData(typeof(string[,,]), "string[,,]")]
        [InlineData(typeof(object[,,]), "object[,,]")]
        [InlineData(typeof(bool[,,,]), "bool[,,,]")]
        [InlineData(typeof(char[,,,]), "char[,,,]")]
        [InlineData(typeof(byte[,,,]), "byte[,,,]")]
        [InlineData(typeof(short[,,,]), "short[,,,]")]
        [InlineData(typeof(int[,,,]), "int[,,,]")]
        [InlineData(typeof(long[,,,]), "long[,,,]")]
        [InlineData(typeof(sbyte[,,,]), "sbyte[,,,]")]
        [InlineData(typeof(ushort[,,,]), "ushort[,,,]")]
        [InlineData(typeof(uint[,,,]), "uint[,,,]")]
        [InlineData(typeof(ulong[,,,]), "ulong[,,,]")]
        [InlineData(typeof(float[,,,]), "float[,,,]")]
        [InlineData(typeof(decimal[,,,]), "decimal[,,,]")]
        [InlineData(typeof(double[,,,]), "double[,,,]")]
        [InlineData(typeof(string[,,,]), "string[,,,]")]
        [InlineData(typeof(object[,,,]), "object[,,,]")]
        [InlineData(typeof(bool[,,,,]), "bool[,,,,]")]
        [InlineData(typeof(char[,,,,]), "char[,,,,]")]
        [InlineData(typeof(byte[,,,,]), "byte[,,,,]")]
        [InlineData(typeof(short[,,,,]), "short[,,,,]")]
        [InlineData(typeof(int[,,,,]), "int[,,,,]")]
        [InlineData(typeof(long[,,,,]), "long[,,,,]")]
        [InlineData(typeof(sbyte[,,,,]), "sbyte[,,,,]")]
        [InlineData(typeof(ushort[,,,,]), "ushort[,,,,]")]
        [InlineData(typeof(uint[,,,,]), "uint[,,,,]")]
        [InlineData(typeof(ulong[,,,,]), "ulong[,,,,]")]
        [InlineData(typeof(float[,,,,]), "float[,,,,]")]
        [InlineData(typeof(decimal[,,,,]), "decimal[,,,,]")]
        [InlineData(typeof(double[,,,,]), "double[,,,,]")]
        [InlineData(typeof(string[,,,,]), "string[,,,,]")]
        [InlineData(typeof(object[,,,,]), "object[,,,,]")]
        [InlineData(typeof(bool[][]), "bool[][]")]
        [InlineData(typeof(char[][]), "char[][]")]
        [InlineData(typeof(byte[][]), "byte[][]")]
        [InlineData(typeof(short[][]), "short[][]")]
        [InlineData(typeof(int[][]), "int[][]")]
        [InlineData(typeof(long[][]), "long[][]")]
        [InlineData(typeof(sbyte[][]), "sbyte[][]")]
        [InlineData(typeof(ushort[][]), "ushort[][]")]
        [InlineData(typeof(uint[][]), "uint[][]")]
        [InlineData(typeof(ulong[][]), "ulong[][]")]
        [InlineData(typeof(float[][]), "float[][]")]
        [InlineData(typeof(decimal[][]), "decimal[][]")]
        [InlineData(typeof(double[][]), "double[][]")]
        [InlineData(typeof(string[][]), "string[][]")]
        [InlineData(typeof(object[][]), "object[][]")]
        [InlineData(typeof(bool[][,]), "bool[][,]")]
        [InlineData(typeof(char[][,]), "char[][,]")]
        [InlineData(typeof(byte[][,]), "byte[][,]")]
        [InlineData(typeof(short[][,]), "short[][,]")]
        [InlineData(typeof(int[][,]), "int[][,]")]
        [InlineData(typeof(long[][,]), "long[][,]")]
        [InlineData(typeof(sbyte[][,]), "sbyte[][,]")]
        [InlineData(typeof(ushort[][,]), "ushort[][,]")]
        [InlineData(typeof(uint[][,]), "uint[][,]")]
        [InlineData(typeof(ulong[][,]), "ulong[][,]")]
        [InlineData(typeof(float[][,]), "float[][,]")]
        [InlineData(typeof(decimal[][,]), "decimal[][,]")]
        [InlineData(typeof(double[][,]), "double[][,]")]
        [InlineData(typeof(string[][,]), "string[][,]")]
        [InlineData(typeof(object[][,]), "object[][,]")]
        [InlineData(typeof(bool[,][]), "bool[,][]")]
        [InlineData(typeof(char[,][]), "char[,][]")]
        [InlineData(typeof(byte[,][]), "byte[,][]")]
        [InlineData(typeof(short[,][]), "short[,][]")]
        [InlineData(typeof(int[,][]), "int[,][]")]
        [InlineData(typeof(long[,][]), "long[,][]")]
        [InlineData(typeof(sbyte[,][]), "sbyte[,][]")]
        [InlineData(typeof(ushort[,][]), "ushort[,][]")]
        [InlineData(typeof(uint[,][]), "uint[,][]")]
        [InlineData(typeof(ulong[,][]), "ulong[,][]")]
        [InlineData(typeof(float[,][]), "float[,][]")]
        [InlineData(typeof(decimal[,][]), "decimal[,][]")]
        [InlineData(typeof(double[,][]), "double[,][]")]
        [InlineData(typeof(string[,][]), "string[,][]")]
        [InlineData(typeof(object[,][]), "object[,][]")]
        public void NameOfPrimitiveArray(Type type, string expected)
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
        public void FullNameOfPrimitive(Type type, string expected)
        {
            var formatter = new CSharpTypeFormatter();
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
        }

    }
}
