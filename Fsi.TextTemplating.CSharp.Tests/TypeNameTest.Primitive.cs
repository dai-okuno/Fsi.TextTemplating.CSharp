﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fsi.TextTemplating.CSharp.Tests
{
    public class TypeNameTestPrimitive
        : TypeNameTest
    {
        [Theory]
        [InlineData("System.Boolean", typeof(bool))]
        [InlineData("System.String", typeof(string))]
        [InlineData("System.Char", typeof(char))]
        [InlineData("System.Byte", typeof(byte))]
        [InlineData("System.Int16", typeof(short))]
        [InlineData("System.Int32", typeof(int))]
        [InlineData("System.Int64", typeof(long))]
        [InlineData("System.SByte", typeof(sbyte))]
        [InlineData("System.UInt16", typeof(ushort))]
        [InlineData("System.UInt32", typeof(uint))]
        [InlineData("System.UInt64", typeof(ulong))]
        [InlineData("System.Single", typeof(float))]
        [InlineData("System.Double", typeof(double))]
        [InlineData("System.Decimal", typeof(decimal))]
        [InlineData("System.Object", typeof(object))]
        [InlineData("System.Void", typeof(void))]
        public override void AppendAliasNameTo(string expected, Type type)
        {
            base.AppendAliasNameTo(expected, type);
        }

        [Theory]
        [InlineData("System.Boolean", typeof(bool))]
        [InlineData("System.String", typeof(string))]
        [InlineData("System.Char", typeof(char))]
        [InlineData("System.Byte", typeof(byte))]
        [InlineData("System.Int16", typeof(short))]
        [InlineData("System.Int32", typeof(int))]
        [InlineData("System.Int64", typeof(long))]
        [InlineData("System.SByte", typeof(sbyte))]
        [InlineData("System.UInt16", typeof(ushort))]
        [InlineData("System.UInt32", typeof(uint))]
        [InlineData("System.UInt64", typeof(ulong))]
        [InlineData("System.Single", typeof(float))]
        [InlineData("System.Double", typeof(double))]
        [InlineData("System.Decimal", typeof(decimal))]
        [InlineData("System.Object", typeof(object))]
        [InlineData("System.Void", typeof(void))]
        public override void AliasNameOf(string expected, Type type)
        {
            base.AliasNameOf(expected, type);
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("char", typeof(char))]
        [InlineData("byte", typeof(byte))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]
        public override void AppendCRefNameTo(string expected, Type type)
        {
            base.AppendCRefNameTo(expected, type);
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("char", typeof(char))]
        [InlineData("byte", typeof(byte))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]
        public override void CRefNameOf(string expected, Type type)
        {
            base.CRefNameOf(expected, type);
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("char", typeof(char))]
        [InlineData("byte", typeof(byte))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]
        public override void AppendFullNameTo(string expected, Type type)
        {
            base.AppendFullNameTo(expected, type);
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("char", typeof(char))]
        [InlineData("byte", typeof(byte))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]
        public override void FullNameOf(string expected, Type type)
        {
            base.FullNameOf(expected, type);
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("char", typeof(char))]
        [InlineData("byte", typeof(byte))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]
        public override void AppendNameTo(string expected, Type type)
        {
            base.AppendNameTo(expected, type);
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("char", typeof(char))]
        [InlineData("byte", typeof(byte))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("float", typeof(float))]
        [InlineData("double", typeof(double))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("object", typeof(object))]
        [InlineData("void", typeof(void))]
        public override void NameOf(string expected, Type type)
        {
            base.NameOf(expected, type);
        }
    }
}
