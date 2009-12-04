using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.composition {


    /// <summary>
    /// 
    /// </summary>
    public class Composite : Tree, basics.IComposite {

        /// <summary>
        /// 
        /// </summary>
        private List<basics.Compositable> contents_ = new List<basics.Compositable>();


        /// <summary>
        /// 
        /// </summary>
        public Composite() {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__component"></param>
        public Composite(basics.Compositable __component) {
            addComponent( __component );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__item"></param>
        public Composite(object __item)
            : base( __item ) 
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__item"></param>
        /// <param name="__component"></param>
        public Composite(object __item, basics.Compositable __component)
            : base( __item ) 
        {
            addComponent( __component );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adden_component"></param>
        /// <returns></returns>
        public bool addComponent(basics.Compositable __adden_component) {
            if ( __adden_component == null && __adden_component == this ) {
                return false;
            }
            this.contents_.Add( __adden_component );

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_component"></param>
        /// <returns></returns>
        public bool removeComponent(basics.Compositable __removed_component) {
            if ( __removed_component == null && __removed_component == this ) {
                return false;
            } else if (this.contents_.Count == 0) {
                return false;
            }
            this.contents_.Remove( __removed_component );

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public basics.Compositable[] getChild() {
            return this.contents_.ToArray();
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool is_composite {
            get {
                return true;
            }
        }
    }
}
