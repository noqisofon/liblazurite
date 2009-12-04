using System;
using System.Collections.Generic;
using System.Reflection;


namespace lazurite {


    namespace reflection {


        /// <summary>
        /// 
        /// </summary>
        public class PropertyCollection : ICollection<Property>, IEnumerable<Property> {
            /// <summary>
            /// 
            /// </summary>
            private Dictionary<string, Property> properties_ = new Dictionary<string, Property>();


            /// <summary>
            /// 
            /// </summary>
            public PropertyCollection() {
            }


            #region ICollection<Property> ÉÅÉìÉo
            /// <summary>
            /// 
            /// </summary>
            /// <param name="__item"></param>
            public void Add(Property __item) {
                this.properties_.Add( __item.name, __item );
            }


            /// <summary>
            /// 
            /// </summary>
            public void Clear() {
                this.properties_.Clear();
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__item"></param>
            /// <returns></returns>
            public bool Contains(Property __item) {
                return this.properties_.ContainsKey(__item.name);
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__array"></param>
            /// <param name="__array_index"></param>
            public void CopyTo(Property[] __array, int __array_index) {
                
            }


            /// <summary>
            /// 
            /// </summary>
            public int Count {
                get {
                    return properties_.Count;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            public bool IsReadOnly {
                get {
                    return true;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__item"></param>
            /// <returns></returns>
            public bool Remove(Property __item) {
                return this.properties_.Remove( __item.name );
            }
            #endregion


            #region IEnumerable<Property> ÉÅÉìÉo
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IEnumerator<Property> GetEnumerator() {
                return this.properties_.Values.GetEnumerator();
            }
            #endregion


            #region IEnumerable ÉÅÉìÉo
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return this.GetEnumerator();
            }
            #endregion
        }


    }


}
