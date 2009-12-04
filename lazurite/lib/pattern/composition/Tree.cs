using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.composition {


    /// <summary>
    /// 
    /// </summary>
    public abstract class Tree : basics.Compositable {


        /// <summary>
        /// 
        /// </summary>
        private object item_;



        /// <summary>
        /// 
        /// </summary>
        protected Tree() {
            this.item_ = null;
        }
        /// <summary>
        /// 
        /// </summary>
        protected Tree(object __item) {
            this.item_ = __item;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__visitor"></param>
        /// <returns></returns>
        public virtual bool accept(basics.IVisitor __visitor) {
            return __visitor.visit( this );
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual bool is_composite {
            get { return false; }
        }


        /// <summary>
        /// 
        /// </summary>
        public object item {
            get {
                return item_;
            }
            set {
                item_ = value;
            }
        }
    }
}
