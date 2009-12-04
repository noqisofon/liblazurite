using System;
using System.Collections;


namespace lazurite.common {


    using util = lazurite.util;


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Aggregate"></typeparam>
    /// <typeparam name="_T"></typeparam>
    public class CollectionAdapter<_Aggregate, _T> where _Aggregate : ICollection, IList {
        /// <summary>
        /// 
        /// </summary>
        private _Aggregate aggregate_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__A"></param>
        public CollectionAdapter(_Aggregate __A) {
            this.aggregate_ = __A;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__result"></param>
        /// <param name="__pred"></param>
        /// <returns></returns>
        public _Aggregate collect(_Aggregate __result, unary_predicate<_T> __pred) {
            foreach ( _T it in this.aggregate_ ) {
                if ( __pred( it ) ) {
                    __result.Add( it );
                }
            }
            return __result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__closure"></param>
        public void each(util::subroutine<_T> __closure) {
            foreach ( _T it in this.aggregate_ ) {
                __closure( it );
            }
        }
    }
}