using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Fsi.TextTemplating.TypeNames
{
    internal interface ITypeName
            : IEquatable<ITypeName>, ITypeNameBuilder, ITypeNameContainer
    {

        /// <summary></summary>
        Type Type { get; }

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        string GetAliasName(IFormatterContext context);

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        string GetCRefName(IFormatterContext context);

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        string GetFullName(IFormatterContext context);

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        string GetName(IFormatterContext context);

    }
}
