﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fsi.TextTemplating {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラス。
    /// </summary>
    // このクラスは、StronglyTypedResourceBuilder 
    // クラスにより、ResGen または Visual Studio のようなツールで自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集し、ResGen を
    // /str オプションで再実行するか、VS プロジェクトを再ビルドします。
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resource() {
        }
        
        /// <summary>
        ///    このクラスに使用される、キャッシュされた ResourceManager のインスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fsi.TextTemplating.CSharp.Resource", typeof(Resource).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    現在のスレッドの CurrentUICulture プロパティを、
        ///    厳密に型指定されたリソース クラスを使用して、すべてのリソース ルックアップに対して上書きします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    &apos;{0}&apos; equals &apos;{1}&apos; or more. に類似したローカライズされた文字列を検索します。
        /// </summary>
        public static string EqualsOtherOrMore {
            get {
                return ResourceManager.GetString("EqualsOtherOrMore", resourceCulture);
            }
        }
        
        /// <summary>
        ///    &apos;{0}&apos; equals {1} or more. に類似したローカライズされた文字列を検索します。
        /// </summary>
        public static string EqualsValueOrMore {
            get {
                return ResourceManager.GetString("EqualsValueOrMore", resourceCulture);
            }
        }
        
        /// <summary>
        ///    &apos;{0}&apos; is less than &apos;{1}&apos;. に類似したローカライズされた文字列を検索します。
        /// </summary>
        public static string LessThanOther {
            get {
                return ResourceManager.GetString("LessThanOther", resourceCulture);
            }
        }
        
        /// <summary>
        ///    &apos;{0}&apos; is less than {1}. に類似したローカライズされた文字列を検索します。
        /// </summary>
        public static string LessThanValue {
            get {
                return ResourceManager.GetString("LessThanValue", resourceCulture);
            }
        }
    }
}
