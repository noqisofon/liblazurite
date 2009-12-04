using System;
using System.Collections.Generic;
using System.Reflection;


namespace lazurite {


    namespace reflection {


        /// <summary>
        /// 
        /// </summary>
        public class Property {
            /// <summary>
            /// 
            /// </summary>
            private object       owner_;
            /// <summary>
            /// 
            /// </summary>
            private PropertyInfo content_;


            /// <summary>
            /// 
            /// </summary>
            public string name {
                get {
                    return content_.Name;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            public Type type {
                get {
                    return content_.PropertyType;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            public object value {
                get {
                    return content_.GetValue( owner_, null );
                }
                set {
                    content_.SetValue( owner_, value, null );
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__owner"></param>
            /// <param name="__content"></param>
            /// <param name="?"></param>
            public Property(object __owner, PropertyInfo __content) {
                this.owner_  = __owner;
                this.content_ = __content;
            }
        }
    }


}