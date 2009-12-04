using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace lazurite.attitude {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    /// <typeparam name="_Collection"></typeparam>
    public class CollectionAdapter<_T, _Collection> : IEnumerable<_T> where _Collection : ICollection<_T>, new() {
        /// <summary>
        /// 
        /// </summary>
        private _Collection content_;


        /// <summary>
        /// 
        /// </summary>
        public int size {
            get {
                return content_.Count;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public CollectionAdapter() {
            this.content_ = new _Collection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public CollectionAdapter(_Collection other) {
            this.content_ = other;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="others"></param>
        //public CollectionAdapter(_T[] others) {
        //    this.content_ = new _Collection();
        //    appendAll( others );
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public CollectionAdapter(params _T[] args) {
            this.content_ = new _Collection();
            appendAll( args );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void append(_T item) {
            this.content_.Add( item );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void appendAll(_Collection items) {
            foreach ( _T item in items ) {
                append( item );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void appendAll(params _T[] items) {
            foreach ( _T item in items ) {
                append( item );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void clear() {
            this.content_.Clear();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool contains(_T item) {
            return this.content_.Contains( item );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool erase(_T item) {
            return this.content_.Remove( item );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _T at(int index) {
            if ( index >= size || index < 0 ) {
                return default( _T );
            }

            IEnumerator<_T> iterator = this.content_.GetEnumerator();
            _T result = default( _T );
            bool test = false;

            for ( int times = 0; test = iterator.MoveNext(); ++times ) {
                if ( index == times ) {
                    result = iterator.Current;

                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public _T[] subCollection(int start, int end) {
            IEnumerator<_T> iterator = this.content_.GetEnumerator();
            _T[] results = new _T[( end - start ) + 1];
            int times = 0;
            int index = 0;

            for ( ; iterator.MoveNext(); ++times ) {
                if ( start <= times && times <= end ) {
                    results[index] = iterator.Current;
                    ++index;
                }
            }
            return results;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public CollectionAdapter<_T, _Collection> concat(_Collection items) {
            appendAll( items );

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public CollectionAdapter<_T, _Collection> concat(params _T[] items) {
            appendAll( items );

            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string join() {
            IEnumerator<_T> iterator = this.content_.GetEnumerator();
            StringBuilder builder = new StringBuilder();

            for ( ; iterator.MoveNext(); ) {
                builder.Append( iterator.Current.ToString() );
            }

            return builder.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string join(string separator) {
            IEnumerator<_T> iterator = this.content_.GetEnumerator();
            StringBuilder builder = new StringBuilder();

            for ( int index = 0; iterator.MoveNext(); ++index ) {
                builder.Append( iterator.Current.ToString() );
                if ( index < size - 1 ) {
                    builder.Append( separator );
                }
            }

            return builder.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string inspect() {
            StringBuilder builder = new StringBuilder();
            builder.Append( "[\"" );
            builder.Append( join( "\", \"" ) );
            builder.Append( "\"]" );

            return builder.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eh"></param>
        public void each(each_handler<_T> hander) {
            foreach ( _T it in this.content_ ) {
                hander( it );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eh"></param>
        public void each_index(each_index_handler<_T> handler) {
            for ( int i = 0; i < size; ++i ) {
                handler( i );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string to_s() {
            return inspect();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public _T[] to_a() {
            return subCollection( 0, size - 1 );
        }


        #region IEnumerable<_T> ÉÅÉìÉo
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<_T> GetEnumerator() {
            return this.content_.GetEnumerator();
        }
        #endregion
        #region IEnumerable ÉÅÉìÉo
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.content_.GetEnumerator();
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return inspect();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    /// <param name="element"></param>
    /// <returns></returns>
    public delegate void each_handler<_T>(_T element);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    public delegate void each_index_handler<_T>(int index);
}
