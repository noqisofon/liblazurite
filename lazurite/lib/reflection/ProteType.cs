using System;
using System.Collections.Generic;
using System.Reflection;


namespace lazurite {


    namespace reflection {


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_Class"></typeparam>
        public class ProteType<_Class> {
            /// <summary>
            /// 
            /// </summary>
            private _Class target_;
            /// <summary>
            /// 
            /// </summary>
            private Type target_type_;
            /// <summary>
            /// 
            /// </summary>
            private PropertyCollection properties_;


            /// <summary>
            /// 
            /// </summary>
            public PropertyCollection properties {
                get {
                    return this.properties_;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="__that"></param>
            public ProteType(_Class __that) {
                this.target_ = __that;
                this.target_type_ = typeof( _Class );
                this.properties_ = new PropertyCollection();

                foreach ( PropertyInfo prop in this.target_type_.GetProperties() ) {
                    this.properties_.Add( new Property( this.target_, prop ) );
                }
            }



        }


    }


}