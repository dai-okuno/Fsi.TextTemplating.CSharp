using System;
using System.Text;

namespace Fsi.TextTemplating.TypeNames
{
    internal class ArrayTypeName
        : CachedTypeName
    {
        public ArrayTypeName(TypeName elementTypeName, string ranks)
        {
            ElementTypeName = elementTypeName;
            Ranks = ranks;
            TypeFullName = GetFullName();
        }
        public ArrayTypeName(FlyweightFactory factory, Type type)
        {
            var t = type;
            var ranks = string.Empty;
            do
            {
                int rank;
                switch (rank = t.GetArrayRank())
                {
                    case 1:
                        ranks += "[]";
                        break;
                    case 2:
                        ranks += "[,]";
                        break;
                    case 3:
                        ranks += "[,,]";
                        break;
                    default:
                        ranks += ("[" + new string(',', rank - 1) + "]");
                        break;
                }
            } while ((t = t.GetElementType()).IsArray);
            ElementTypeName = factory.GetTypeName(t);
            Ranks = ranks;
            TypeFullName = type.FullName;
        }
        //public override FlyweightFactory Factory
        //    => ElementTypeName.Factory;
        private TypeName ElementTypeName { get; }
        private string Ranks { get; }
        /// <summary>
        /// Append the name for the type alias declaration.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendAliasNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendAliasNameTo(typeName, context);
            typeName.Append(Ranks);
        }
        /// <summary>
        /// Append the name for cref attribute in document comment.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendCRefNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendCRefNameTo(typeName, context);
            typeName.Append(Ranks);
        }
        /// <summary>
        /// Append the full name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        protected override void AppendFullNameToCore(StringBuilder typeName)
        {
            ElementTypeName.AppendFullNameTo(typeName);
            typeName.Append(Ranks);
        }
        /// <summary>
        /// Append the name of this object.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendTypeOfNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendTypeOfNameTo(typeName, context);
            typeName.Append(Ranks);
        }
        /// <summary>
        /// Append the name for typeof operator.
        /// </summary>
        /// <param name="typeName">A <see cref="StringBuilder"/> to append the name.</param>
        /// <param name="context"></param>
        protected override void AppendNameToCore(StringBuilder typeName, IFormatterContext context)
        {
            ElementTypeName.AppendNameTo(typeName, context);
            typeName.Append(Ranks);
        }
    }
}

