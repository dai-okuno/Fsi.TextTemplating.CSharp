using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    internal class Utility
    {
        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T[] CreateArray<T>(int length, T value)
        {
            var array = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
            return array;
        }

        /// <summary></summary>
        /// <param name="src"></param>
        /// <param name="srcIndex"></param>
        /// <param name="dest"></param>
        /// <param name="destIndex"></param>
        /// <param name="length"></param>
        public static void Copy(string src, ref int srcIndex, char[] dest, ref int destIndex, int length)
        {
            src.CopyTo(srcIndex, dest, destIndex, length);
            srcIndex += length;
            destIndex += length;
        }

        /// <summary></summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <param name="remainder"></param>
        /// <returns></returns>
        public static int DivRem(int dividend, int divisor, out int remainder)
        {
            var result = dividend / divisor;
            remainder = dividend - (result * divisor);
            return result;
        }

    }
}
