using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace lazurite.common {


    using Utility = lazurite.util;


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Aggregate"></typeparam>
    /// <typeparam name="_T"></typeparam>
    public class AggregateAdapter<_Aggregate, _T> where _Aggregate : ICollection<_T> {
        /// <summary>
        /// 
        /// </summary>
        private _Aggregate aggregate_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__A"></param>
        public AggregateAdapter(_Aggregate __A) {
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
        /// <param name="__closuer"></param>
        public void each(Utility::subroutine<_T> __closuer) {
            foreach ( _T it in this.aggregate_ ) {
                __closuer( it );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__closuer"></param>
        public void each_index(Utility::subroutine<int, _T> __closuer) {
            int i = 0;
            foreach (_T it in this.aggregate_) { 
                __closuer( i, it );
            }
        }
    }
}