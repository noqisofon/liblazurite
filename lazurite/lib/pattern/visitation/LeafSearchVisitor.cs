using System;
using System.Text;


namespace lazurite.pattern.visitation {


    using util = lazurite.util;


    /// <summary>
    /// ótÇ¡ÇœÇë{Ç∑ Visitor Ç≈Ç∑ÅB
    /// </summary>
    public class LeafSearchVisitor : HierarchicalVisitor<attitude.AbstractFileNode, attitude.Folder> {
        /// <summary>
        /// 
        /// </summary>
        private string target_ = null;
        /// <summary>
        /// 
        /// </summary>
        private string path_ = "";
        /// <summary>
        /// 
        /// </summary>
        private attitude.AbstractFileNode result_ = null;
        /// <summary>
        /// 
        /// </summary>
        private static readonly string SEPARATOR = "/";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public LeafSearchVisitor(string target) {
            this.target_ = target;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public override bool visitEnter(attitude.Folder composite) {
            StringBuilder path_builder = new StringBuilder( this.path_ );
            path_builder.Append( SEPARATOR );
            path_builder.Append( composite.text );
            this.path_ = path_builder.ToString();

            int compare_length = Math.Min( this.target_.Length, this.path_.Length );

            return region_matches( this.target_, this.path_, compare_length );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public override bool visit(attitude.AbstractFileNode leaf) {
            if ( leaf != null ) {
                string leaf_path = this.path_ + SEPARATOR + leaf.text;

                if ( this.target_ == leaf_path ) {
                    this.result_ = leaf;

                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public override bool visitLeave(attitude.Folder composite) {
            int index = this.path_.LastIndexOf( SEPARATOR );
            this.path_ = this.path_.Substring( 0, index );

            return this.result_ != null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public attitude.AbstractFileNode getResult() {
            return this.result_;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private bool region_matches(string a, string b, int size) {
            for ( int i = 0; i < size; ++i ) {
                if ( a[i] != b[i] ) {
                    return false;
                }
            }
            return true;
        }
    }
}