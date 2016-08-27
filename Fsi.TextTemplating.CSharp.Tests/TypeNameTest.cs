using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTest
    {
        public virtual void AppendCRefNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            var typeName = new StringBuilder(type.FullName.Length);
            csharp.AppendCRefNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendCRefNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        public virtual void AppendFullNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            var typeName = new StringBuilder(type.FullName.Length);
            csharp.AppendFullNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendFullNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }
        public virtual void AppendNameTo(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            var typeName = new StringBuilder(type.Name.Length);
            csharp.AppendNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
            typeName.Clear();
            csharp.AppendNameTo(type, typeName);
            Assert.Equal(expected, typeName.ToString());
        }

        public virtual void CRefNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            Assert.Equal(expected, csharp.CRefNameOf(type));
            Assert.Equal(expected, csharp.CRefNameOf(type));
        }
        public virtual void FullNameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            Assert.Equal(expected, csharp.FullNameOf(type));
            Assert.Equal(expected, csharp.FullNameOf(type));
        }
        public virtual void NameOf(string expected, Type type)
        {
            var csharp = new CSharpHelper();
            csharp.Import("System");
            csharp.Import("System.Collections");
            Assert.Equal(expected, csharp.NameOf(type));
            Assert.Equal(expected, csharp.NameOf(type));
        }

    }

}

//namespace Fsi.TextTemplating.TypeNames.Tests
//{

//    public class CSharpTypeFormatterTest
//    {

//        [Theory]
//        [InlineData(typeof(int[]), "int[]")]
//        [InlineData(typeof(int[,]), "int[,]")]
//        [InlineData(typeof(int[,,]), "int[,,]")]
//        [InlineData(typeof(int[,,,]), "int[,,,]")]
//        [InlineData(typeof(int[,,,,]), "int[,,,,]")]
//        [InlineData(typeof(int[][]), "int[][]")]
//        [InlineData(typeof(int[][,]), "int[][,]")]
//        [InlineData(typeof(int[,][]), "int[,][]")]
//        [InlineData(typeof(DateTime[]), "DateTime[]")]
//        [InlineData(typeof(DateTime[,]), "DateTime[,]")]
//        [InlineData(typeof(DateTime[,,]), "DateTime[,,]")]
//        [InlineData(typeof(DateTime[,,,]), "DateTime[,,,]")]
//        [InlineData(typeof(DateTime[,,,,]), "DateTime[,,,,]")]
//        [InlineData(typeof(DateTime[][]), "DateTime[][]")]
//        [InlineData(typeof(DateTime[][,]), "DateTime[][,]")]
//        [InlineData(typeof(DateTime[,][]), "DateTime[,][]")]
//        public void NameOfArray(Type type, string expected)
//        {
//            var formatter = new CSharpTypeFormatter();
//            formatter.Import("System");
//            Assert.Equal(expected, formatter.NameOf(type));

//            var builder = new StringBuilder();
//            formatter.AppendNameTo(type, builder);
//            Assert.Equal(expected, builder.ToString());
//        }

//        [Theory]
//        [InlineData(typeof(int?), "int?")]
//        [InlineData(typeof(DateTime?), "DateTime?")]
//        public void NameOfNullable(Type type, string expected)
//        {
//            var formatter = new CSharpTypeFormatter();
//            formatter.Import("System");
//            Assert.Equal(expected, formatter.NameOf(type));

//            var builder = new StringBuilder();
//            formatter.AppendNameTo(type, builder);
//            Assert.Equal(expected, builder.ToString());
//        }

//        [Theory]
//        [InlineData(typeof(bool), "bool")]
//        [InlineData(typeof(char), "char")]
//        [InlineData(typeof(byte), "byte")]
//        [InlineData(typeof(short), "short")]
//        [InlineData(typeof(int), "int")]
//        [InlineData(typeof(long), "long")]
//        [InlineData(typeof(sbyte), "sbyte")]
//        [InlineData(typeof(ushort), "ushort")]
//        [InlineData(typeof(uint), "uint")]
//        [InlineData(typeof(ulong), "ulong")]
//        [InlineData(typeof(float), "float")]
//        [InlineData(typeof(decimal), "decimal")]
//        [InlineData(typeof(double), "double")]
//        [InlineData(typeof(string), "string")]
//        [InlineData(typeof(object), "object")]
//        [InlineData(typeof(void), "void")]
//        [InlineData(typeof(DateTime), "System.DateTime")]
//        [InlineData(typeof(StringBuilder), "System.Text.StringBuilder")]
//        [InlineData(typeof(Func<>), "System.Func<TResult>")]
//        [InlineData(typeof(Func<int>), "System.Func<int>")]
//        [InlineData(typeof(Func<DateTime, int>), "System.Func<System.DateTime, int>")]
//        [InlineData(typeof(Func<DateTime, Action<string>, int>), "System.Func<System.DateTime, System.Action<string>, int>")]
//        [InlineData(typeof(List<int>), "System.Collections.Generic.List<int>")]
//        [InlineData(typeof(List<int>.Enumerator), "System.Collections.Generic.List<int>.Enumerator")]
//        public void NameOf(Type type, string expected)
//        {
//            var formatter = new CSharpTypeFormatter();
//            Assert.Equal(expected, formatter.NameOf(type));

//            var builder = new StringBuilder();
//            formatter.AppendNameTo(type, builder);
//            Assert.Equal(expected, builder.ToString());
//        }

//        [Theory]
//        [InlineData(typeof(bool), "bool")]
//        [InlineData(typeof(char), "char")]
//        [InlineData(typeof(byte), "byte")]
//        [InlineData(typeof(short), "short")]
//        [InlineData(typeof(int), "int")]
//        [InlineData(typeof(long), "long")]
//        [InlineData(typeof(sbyte), "sbyte")]
//        [InlineData(typeof(ushort), "ushort")]
//        [InlineData(typeof(uint), "uint")]
//        [InlineData(typeof(ulong), "ulong")]
//        [InlineData(typeof(float), "float")]
//        [InlineData(typeof(decimal), "decimal")]
//        [InlineData(typeof(double), "double")]
//        [InlineData(typeof(string), "string")]
//        [InlineData(typeof(object), "object")]
//        [InlineData(typeof(void), "void")]
//        [InlineData(typeof(DateTime), "System.DateTime")]
//        [InlineData(typeof(StringBuilder), "System.Text.StringBuilder")]
//        [InlineData(typeof(Func<>), "System.Func<TResult>")]
//        [InlineData(typeof(Func<int>), "System.Func<int>")]
//        [InlineData(typeof(Func<DateTime, int>), "System.Func<System.DateTime, int>")]
//        [InlineData(typeof(Func<DateTime, Action<string>, int>), "System.Func<System.DateTime, System.Action<string>, int>")]
//        [InlineData(typeof(List<int>), "System.Collections.Generic.List<int>")]
//        [InlineData(typeof(List<int>.Enumerator), "System.Collections.Generic.List<int>.Enumerator")]
//        public void FullNameOfPrimitive(Type type, string expected)
//        {
//            var formatter = new CSharpTypeFormatter();
//            formatter.Import("System");
//            Assert.Equal(expected, formatter.FullNameOf(type));

//            var builder = new StringBuilder();
//            formatter.AppendFullNameTo(type, builder);
//            Assert.Equal(expected, builder.ToString());
//        }

//        [Theory]
//        [InlineData(typeof(bool), "bool")]
//        [InlineData(typeof(char), "char")]
//        [InlineData(typeof(byte), "byte")]
//        [InlineData(typeof(short), "short")]
//        [InlineData(typeof(int), "int")]
//        [InlineData(typeof(long), "long")]
//        [InlineData(typeof(sbyte), "sbyte")]
//        [InlineData(typeof(ushort), "ushort")]
//        [InlineData(typeof(uint), "uint")]
//        [InlineData(typeof(ulong), "ulong")]
//        [InlineData(typeof(float), "float")]
//        [InlineData(typeof(decimal), "decimal")]
//        [InlineData(typeof(double), "double")]
//        [InlineData(typeof(string), "string")]
//        [InlineData(typeof(object), "object")]
//        [InlineData(typeof(void), "void")]
//        public void CRefOfPrimitive(Type type, string expected)
//        {
//            var formatter = new CSharpTypeFormatter();
//            Assert.Equal(expected, formatter.CRefNameOf(type));

//            var builder = new StringBuilder();
//            formatter.AppendCRefNameTo(type, builder);
//            Assert.Equal(expected, builder.ToString());

//            formatter.Import("System");
//            Assert.Equal(expected, formatter.CRefNameOf(type));

//            builder.Clear();
//            formatter.AppendCRefNameTo(type, builder);
//            Assert.Equal(expected, builder.ToString());
//        }

//    }
//}
