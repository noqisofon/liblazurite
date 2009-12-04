using System;
using System.Collections.Generic;


namespace lazurite.attitude {


    using lazurite.common;
    using lazurite.pattern.basics;


    /**
     * AbstractFileNode クラスは ツリー構造を簡単に作成するために作成されたコレクション風クラスです。
     * <pre>
     * 此のクラスはComposite パターンを使用しています。
     * 残念ながら、文字列しか格納できません。あしからず。
     * </pre>
     */
    public abstract class AbstractFileNode : IFileNode {
        /// <summary>
        /// 文字列表記。
        /// </summary>
        private string text_;
        /// <summary>
        /// 根っこノードへの参照。
        /// </summary>
        private AbstractFileNode root_;
        /// <summary>
        /// 親ノードへの参照。
        /// </summary>
        private AbstractFileNode parent_;
        /// <summary>
        /// ツリーノードの深さ。
        /// </summary>
        private int depth_;


        /// <summary>
        /// 派生クラス用。
        /// </summary>
        /// <param name="__text"></param>
        protected AbstractFileNode(string __text) {
            this.text_ = __text;
            this.root_ = this;
            this.parent_ = null;
            this.depth_ = 0;
        }


        /**
         * Composite に append されたときに呼ばれます。
         */
        protected void setParent(AbstractFileNode __child) {
            __child.parent_ = this;
            if ( this.parent == null ) {
                __child.root_ = this;
            } else {
                __child.root_ = this.parent_;
            }
            depth_check( this );
        }


        /*
         * 深度をチェックします。
         */
        private static void depth_check(AbstractFileNode __current) {
            if ( __current.is_composite ) {
                Folder c = (Folder)__current;
                
                if ( !c.is_nodeEmpty ) {

                    foreach ( AbstractFileNode it in c.nodes ) {
                        it.depth_ = __current.depth_ + 1;
                        it.root_ = __current.root_;

                        if ( it.is_composite ) {
                            depth_check( it );
                        }

                    }
                    //Algorithms.each<Tree>( 
                    //    c.nodes, 
                    //    delegate(Tree node) {
                    //        node.depth_ = __current.depth + 1;
                    //        node.root_ = __current.root_;
                    //        if ( node.is_composite ) {
                    //            depth_check(node);
                    //        }
                    //    } 
                    //);
                }

            }
        }


        /**
         * ツリーを更新します。
         */
        public void refresh() {
            depth_check( root );
        }


        /**
         * Visitor にアクセスさせます。
         */
        public bool accept(IVisitor<AbstractFileNode> __visitor) {
            return __visitor.visit( this );
        }


        /**
         * 
         */
        public override string ToString() {
            return text;
        }


        /**
         * Ruby 風。
         */
        public string to_s() { return ToString(); }


        /**
         * ルートを取得します。
         */
        public AbstractFileNode root {
            get { return root_; }
        }


        /**
         * 親ノードを取得します。
         */
        public AbstractFileNode parent {
            get { return parent_; }
        }


        /**
         * 
         */
        public string text {
            get { return text_; }
            set { text_ = value; }
        }


        /**
         * レシーバが親ノードを持っているかどうか判別します。
         */
        public bool has_parent {
            get { return parent_ != null; }
        }


        /**
         * レシーバが Composite かどうか判別します。
         */
        public virtual bool is_composite {
            get { return false; }
        }


        /**
         * レシーバのノードの深さを取得します。
         */
        public int depth {
            get { return depth_; }
        }


        /**
         * 
         */
        public int index {
            get {
                return parent != null ? ( parent as Folder ).indexOf( this ) : -1;
            }
        }
    }
}