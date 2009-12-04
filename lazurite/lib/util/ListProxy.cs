using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    public class ListProxy<_T> : IList<_T>, ICollection<_T>, IEnumerable<_T> {
        /// <summary>
        /// 
        /// </summary>
        private IList<_T> content_;


        /// <summary>
        /// 
        /// </summary>
        public ListProxy() {
            this.content_ = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public ListProxy(IList<_T> content) {
            this.content_ = content;
        }


        #region IList<_T> メンバ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(_T item) {
            return this.content_.IndexOf( item );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, _T item) {
            this.content_.Insert( index, item );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) {
            this.content_.RemoveAt( index );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _T this[int index] {
            get {
                return content_[index];
            }
            set {
                content_[index] = value;
            }
        }
        #endregion


        #region ICollection<_T> メンバ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(_T item) {
            this.content_.Add( item );
        }


        /// <summary>
        /// 
        /// </summary>
        public void Clear() {
            this.content_.Clear();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(_T item) {
            return this.content_.Contains( item );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(_T[] array, int arrayIndex) {
            this.content_.CopyTo( array, arrayIndex );
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count {
            get {
                return this.content_.Count;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly {
            get {
                return this.content_.IsReadOnly;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(_T item) {
            return this.content_.Remove( item );
        }
        #endregion


        #region IEnumerable メンバ
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.content_.GetEnumerator();
        }
        #endregion


        #region IEnumerable<_T> メンバ
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<_T> GetEnumerator() {
            return this.content_.GetEnumerator();
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string join() {
            return join( ", " );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string join(string separator) {
            StringBuilder builder = new StringBuilder();
            int i = 0, stop = this.content_.Count;
            foreach ( _T it in this.content_ ) {
                builder.Append( it );
                if ( i < ( stop - 1 ) ) {
                    builder.Append( separator );
                }
                ++i;
            }
            return builder.ToString();
        }
    }
}
