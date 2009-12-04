using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.attitude {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    public class ListAdapter<_T> : CollectionAdapter<_T, List<_T>> {
        /// <summary>
        /// 
        /// </summary>
        public ListAdapter() 
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public ListAdapter(List<_T> other) 
            : base(other)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="others"></param>
        public ListAdapter(params _T[] others) 
            : base(others)
        {
        }
    }
}
