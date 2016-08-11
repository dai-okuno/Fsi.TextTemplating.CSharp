﻿using System;
using System.Text;

namespace Fsi.TextTemplating.TypeNames
{
    internal class ArrayTypeName
        : CachedTypeName
    {
        private ArrayTypeName(Type type, ITypeName elementTypeName, string ranks)
            : base(type)
        {
            ElementTypeName = elementTypeName;
            Ranks = ranks;
        }

        private ITypeName ElementTypeName { get; }

        private string Ranks { get; }

        public static ArrayTypeName Create(Type type, IFormatterContext context)
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
            return new ArrayTypeName(type, context.GetTypeName(t), ranks);
        }

        protected override void AppendNameToCore(Helper helper, StringBuilder typeName, IFormatterContext context)
        {
            helper.AppendTypeNameTo(ElementTypeName, typeName, context);
            typeName.Append(Ranks);
        }
    }
}

