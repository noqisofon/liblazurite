using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.composition {


    /// <summary>
    /// 
    /// </summary>
    public class Node : Tree {
        /// <summary>
        /// 
        /// </summary>
        public Node() {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__item"></param>
        public Node(object __item)
            : base( __item ) 
        {
        }
    }
}
