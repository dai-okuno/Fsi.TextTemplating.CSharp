using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsi.TextTemplating
{
    internal class Error
    {
        /// <summary>'<paramref name="name"/>' is less than '<paramref name="other"/>'.</summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="other">The name of the object compared with the argument.</param>
        /// <returns><see cref="ArgumentException"/>.</returns>
        public static ArgumentException ArgumentLessThanOther(string name, string other)
            => new ArgumentException(Format(Resource.LessThanOther, name, other));

        /// <summary>'<paramref name="name"/>' is less than <paramref name="value"/>.</summary>
        /// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value compared with the argument.</param>
        /// <returns><see cref="ArgumentException"/>.</returns>
        public static ArgumentOutOfRangeException ArgumentLessThanValue<TValue>(string name, TValue value)
            => new ArgumentOutOfRangeException(name, Format(Resource.LessThanValue, name, value));

        /// <summary>'name' equals 'other' or more.</summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static ArgumentException ArgumentEqualsOtherOrMore(string name, string other)
            => new ArgumentException(Format(Resource.EqualsOtherOrMore, name, other));

        /// <summary>'name' equals value or more.</summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value compared with the argument.</param>
        /// <returns></returns>
        public static ArgumentOutOfRangeException ArgumentEqualsValueOrMore<TValue>(string name, TValue value)
            => new ArgumentOutOfRangeException(name, Format(Resource.EqualsValueOrMore, name, value));


        private static string Format(string format, params object[] args)
            => string.Format(Resource.Culture, format, args);


    }
}
