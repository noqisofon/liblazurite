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
        // �q�m�[�h���X�g�B
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
         * �q�m�[�h��ǉ����܂��B
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
         * ���V�[�o����ŏ��ɏo�������A�w�肳�ꂽ�l���폜���܂��B
         */
        private void remove(AbstractFileNode __deleted_child) {
            if ( this.nodes_.Contains( __deleted_child ) ) {
                this.nodes_.Remove( __deleted_child );
            }
        }


        /**
         * ���V�[�o����Ō�ɏo�������A�w�肳�ꂽ�l���폜���A���̈ʒu��Ԃ��܂��B
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
         * ���V�[�o����q�m�[�h��S�č폜���܂��B
         */
        public void clear() {
            nodes_.Clear();
            refresh();
        }


        /**
         * ���V�[�o�����L���Ă���q�m�[�h����A�w�肳�ꂽ�m�[�h�̈ʒu��Ԃ��܂��B
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
         * ���V�[�o�����L���Ă���q�m�[�h����A�w�肳�ꂽ�m�[�h�̍Ō�ɏo�������ʒu��Ԃ��܂��B
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
         * ���V�[�o�����L���Ă���q�m�[�h�̐���Ԃ��܂��B
         */
        public int entries {
            get {
                return this.nodes_.Count;
            }
        }


        /**
         * �ŏ��̎q�m�[�h���擾���܂��B
         * <pre>
         * ���V�[�o�� nodes �̐擪�ɓ����Ă���m�[�h��Ԃ��܂��B
         * �q�m�[�h�������ꍇ�A null ��Ԃ��܂��B
         * </pre>
         */
        public AbstractFileNode firstNode {
            get {
                return nodes_.Count > 0 ? nodes_.First.Value : null;
            }
        }


        /**
         * parent �����L���Ă���q�m�[�h���̎��̗v�f��Ԃ��܂��B
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
         * parent �����L���Ă���q�m�[�h���̑O�̗v�f��Ԃ��܂��B
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
         * �Ō�̎q�m�[�h���擾���܂��B
         * <pre>
         * ���V�[�o�� nodes �̖����ɓ����Ă���m�[�h��Ԃ��܂��B
         * �q�m�[�h�������ꍇ�A null ��Ԃ��܂��B
         * </pre>
         */
        public AbstractFileNode lastNode {
            get {
                return nodes_.Count > 0 ? nodes_.Last.Value : null;
            }
        }


        /**
         * ���V�[�o�����L���Ă���q�m�[�h��z��ɂ��ĕԂ��܂��B
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
         * ���V�[�o���q�m�[�h�����L���Ă��Ȃ�������^��Ԃ��܂��B
         */
        public bool is_nodeEmpty {
            get {
                return nodes_.Count == 0;
            }
        }


        /**
         * ���V�[�o�� Composite ���ǂ������ʂ��܂��B
         */
        public override bool is_composite {
            get { return true; }
        }
    }
}