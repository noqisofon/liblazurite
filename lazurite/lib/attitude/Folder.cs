using System;
using System.Collections.Generic;


namespace lazurite.attitude {


    using lazurite.common;
    using lazurite.pattern.basics;
    using lazurite.pattern.visitation;


    /// <summary>
    /// 
    /// </summary>
    public sealed class Folder : AbstractFileNode, IFolder<AbstractFileNode> {
        // 子ノードリスト。
        private LinkedList<AbstractFileNode> nodes_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__text"></param>
        public Folder(string __text)
            : base( __text ) 
        {
            this.nodes_ = new LinkedList<AbstractFileNode>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__text"></param>
        /// <param name="__nodes"></param>
        public Folder(string __text, AbstractFileNode[] __nodes)
            : base( __text ) 
        {
            this.nodes_ = new LinkedList<AbstractFileNode>();
            appendAll( __nodes );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__text"></param>
        /// <param name="__other"></param>
        public Folder(string __text, Folder __other)
            : base( __text ) {
            this.nodes_ = new LinkedList<AbstractFileNode>();
            append( __other );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__text"></param>
        /// <param name="__others"></param>
        public Folder(string __text, Folder[] __others)
            : base( __text ) {
            this.nodes_ = new LinkedList<AbstractFileNode>();
            appendAll( __others );
        }


        /**
         * 子ノードを追加します。
         */
        public void append(AbstractFileNode __child) {
            setParent( __child );
            nodes_.AddLast( __child );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__childs"></param>
        public void appendAll(AbstractFileNode[] __childs) {
            foreach ( AbstractFileNode node in __childs ) {
                append( node );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitor"></param>
        public bool accept(HierarchicalVisitor<attitude.AbstractFileNode, attitude.Folder> visitor) {
            if (visitor.visitEnter(this)) {
                foreach ( AbstractFileNode t in this.nodes_ ) {
                    if ( t.accept(visitor) ) {
                        break;
                    }
                }
            }
            return visitor.visitLeave(this);
        }


        /**
         * レシーバから最初に出現した、指定された値を削除します。
         */
        private void remove(AbstractFileNode __deleted_child) {
            if ( this.nodes_.Contains( __deleted_child ) ) {
                this.nodes_.Remove( __deleted_child );
            }
        }


        /**
         * レシーバから最後に出現した、指定された値を削除し、その位置を返します。
         */
        public int erase(AbstractFileNode __eraced_child) {
            int i = 0;
            AbstractFileNode target = null;
            foreach ( AbstractFileNode t in nodes_ ) {
                if ( t == __eraced_child ) {
                    target = t;
                }
                ++i;
            }

            if ( target != null ) {
                remove( target );

                return i;
            }
            return -1;
        }


        /**
         * レシーバから子ノードを全て削除します。
         */
        public void clear() {
            nodes_.Clear();
            refresh();
        }


        /**
         * レシーバが所有している子ノードから、指定されたノードの位置を返します。
         */
        public int indexOf(AbstractFileNode __other) {
            int i = 0;
            if ( !is_nodeEmpty ) {
                foreach ( AbstractFileNode t in nodes_ ) {
                    if ( t == __other ) {
                        return i;
                    }
                    ++i;
                }
            }
            return -1;
        }


        /**
         * レシーバが所有している子ノードから、指定されたノードの最後に出現した位置を返します。
         */
        public int lastIndexOf(AbstractFileNode __other) {
            int i = 0;
            AbstractFileNode target = null;
            if ( !is_nodeEmpty ) {
                foreach ( AbstractFileNode t in nodes_ ) {
                    if ( t == __other ) {
                        target = t;
                    }
                    ++i;
                }
            }
            return ( target != null ) ? i : -1;
        }


        /**
         * レシーバが所有している子ノードの数を返します。
         */
        public int entries {
            get {
                return this.nodes_.Count;
            }
        }


        /**
         * 最初の子ノードを取得します。
         * <pre>
         * レシーバの nodes の先頭に入っているノードを返します。
         * 子ノードが無い場合、 null を返します。
         * </pre>
         */
        public AbstractFileNode firstNode {
            get {
                return nodes_.Count > 0 ? nodes_.First.Value : null;
            }
        }


        /**
         * parent が所有している子ノード内の次の要素を返します。
         */
        public AbstractFileNode nextNode {
            get {
                Folder c = parent as Folder;
                if ( c.nodes_.Contains( this ) ) {
                    return c.nodes_.Find( this ).Next.Value;
                }
                return null;
            }
        }


        /**
         * parent が所有している子ノード内の前の要素を返します。
         */
        public AbstractFileNode prevNode {
            get {
                Folder c = parent as Folder;
                if ( c.nodes_.Contains( this ) ) {
                    return c.nodes_.Find( this ).Previous.Value;
                }
                return null;
            }
        }


        /**
         * 最後の子ノードを取得します。
         * <pre>
         * レシーバの nodes の末尾に入っているノードを返します。
         * 子ノードが無い場合、 null を返します。
         * </pre>
         */
        public AbstractFileNode lastNode {
            get {
                return nodes_.Count > 0 ? nodes_.Last.Value : null;
            }
        }


        /**
         * レシーバが所有している子ノードを配列にして返します。
         */
        public AbstractFileNode[] nodes {
            get {
                if ( !is_nodeEmpty ) {
                    List<AbstractFileNode> li = new List<AbstractFileNode>();
                    foreach ( AbstractFileNode leaf in nodes_ ) {
                        li.Add( leaf );
                    }
                    return li.ToArray();
                }
                return null;
            }
        }


        /**
         * レシーバが子ノードを所有していなかったら真を返します。
         */
        public bool is_nodeEmpty {
            get {
                return nodes_.Count == 0;
            }
        }


        /**
         * レシーバが Composite かどうか判別します。
         */
        public override bool is_composite {
            get { return true; }
        }
    }
}