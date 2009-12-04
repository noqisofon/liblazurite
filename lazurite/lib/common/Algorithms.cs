using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.common {


    using util = lazurite.util;


    /// <summary>
    /// リテラルな配列にデリゲートを使って何かするメソッドコレクション。
    /// </summary>
    /// <remarks>デバッグしにくいので非推奨のクラスにしてしまいます。</remarks>
    [Obsolete("デバッグしにくくなる恐れがあります。")]
    static public class Algorithms {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="it"></param>
        /// <returns></returns>
        public delegate _T unary_filter<_T>(_T it);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__left"></param>
        /// <param name="__right"></param>
        /// <returns></returns>
        public delegate _T binary_filter<_T>(_T __left, _T __right);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__pred"></param>
        static public void map<_T>(_T[] __ary, unary_filter<_T> __pred) {
            for ( int i = 0; i < __ary.Length; ++i ) {
                __ary[i] = __pred( __ary[i] );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__first_val"></param>
        /// <param name="__pred"></param>
        /// <returns></returns>
        static public _T reduce<_T>(_T[] __ary, _T __first_val, binary_filter<_T> __pred) {
            _T tmp = __first_val;
            foreach ( _T it in __ary ) {
                tmp = __pred( tmp, it );
            }
            return tmp;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__pred"></param>
        static public void each<_T>(_T[] __ary, util::subroutine<_T> __pred) {
            foreach ( _T it in __ary ) {
                __pred( it );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__pred"></param>
        static public void each_index<_T>(_T[] __ary, util::subroutine<int, _T> __pred) {
            for ( int i = 0; i < __ary.Length; ++i ) {
                __pred( i, __ary[i] );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__if_pred"></param>
        /// <param name="__pred"></param>
        static public void each_if<_T>(_T[] __ary, unary_predicate<_T> __if_pred, util::subroutine<_T> __pred) {
            foreach ( _T it in __ary ) {
                if ( __if_pred( it ) ) {
                    __pred( it );
                }
            }
        }


        /// <summary>
        /// __if_pred が真を返す要素のみ入った配列を返します。
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__if_pred"></param>
        /// <returns></returns>
        static public _T[] reject<_T>(_T[] __ary, unary_predicate<_T> __if_pred) {
            List<_T> li = new List<_T>();
            foreach ( _T it in __ary ) {
                if ( __if_pred( it ) ) {
                    li.Add( it );
                }
            }
            return li.ToArray();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__val"></param>
        /// <returns></returns>
        static public _T find<_T>(_T[] __ary, _T __val) {
            return find_if<_T>( 
                __ary, 
                delegate(_T it) { return it.Equals( __val ); } 
            );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__pred"></param>
        /// <returns></returns>
        static public _T find_if<_T>(_T[] __ary, unary_predicate<_T> __pred) {
            foreach ( _T it in __ary ) {
                if ( __pred( it ) ) {
                    return it;
                }
            }
            return default( _T );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="__ary"></param>
        /// <param name="__separator"></param>
        /// <returns></returns>
        static public string join<_T>(_T[] __ary, string __separator) {
            StringBuilder joiner = new StringBuilder();
            int i = 0;
            int last_arrival = __ary.Length;
            foreach ( _T it in __ary ) {
                joiner.Append( it.ToString() );
                if ( i < last_arrival - 1 ) {
                    joiner.Append( __separator );
                }
                ++i;
            }
            return joiner.ToString();
        }
    }
}
