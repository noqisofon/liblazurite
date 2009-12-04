using System;
using System.Collections.Generic;


namespace lazurite.attitude {


    using lazurite.common;
    using lazurite.pattern.basics;


    /**
     * AbstractFileNode �N���X�� �c���[�\�����ȒP�ɍ쐬���邽�߂ɍ쐬���ꂽ�R���N�V�������N���X�ł��B
     * <pre>
     * ���̃N���X��Composite �p�^�[�����g�p���Ă��܂��B
     * �c�O�Ȃ���A�����񂵂��i�[�ł��܂���B�������炸�B
     * </pre>
     */
    public abstract class AbstractFileNode : IFileNode {
        /// <summary>
        /// ������\�L�B
        /// </summary>
        private string text_;
        /// <summary>
        /// �������m�[�h�ւ̎Q�ƁB
        /// </summary>
        private AbstractFileNode root_;
        /// <summary>
        /// �e�m�[�h�ւ̎Q�ƁB
        /// </summary>
        private AbstractFileNode parent_;
        /// <summary>
        /// �c���[�m�[�h�̐[���B
        /// </summary>
        private int depth_;


        /// <summary>
        /// �h���N���X�p�B
        /// </summary>
        /// <param name="__text"></param>
        protected AbstractFileNode(string __text) {
            this.text_ = __text;
            this.root_ = this;
            this.parent_ = null;
            this.depth_ = 0;
        }


        /**
         * Composite �� append ���ꂽ�Ƃ��ɌĂ΂�܂��B
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
         * �[�x���`�F�b�N���܂��B
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
         * �c���[���X�V���܂��B
         */
        public void refresh() {
            depth_check( root );
        }


        /**
         * Visitor �ɃA�N�Z�X�����܂��B
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
         * Ruby ���B
         */
        public string to_s() { return ToString(); }


        /**
         * ���[�g���擾���܂��B
         */
        public AbstractFileNode root {
            get { return root_; }
        }


        /**
         * �e�m�[�h���擾���܂��B
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
         * ���V�[�o���e�m�[�h�������Ă��邩�ǂ������ʂ��܂��B
         */
        public bool has_parent {
            get { return parent_ != null; }
        }


        /**
         * ���V�[�o�� Composite ���ǂ������ʂ��܂��B
         */
        public virtual bool is_composite {
            get { return false; }
        }


        /**
         * ���V�[�o�̃m�[�h�̐[�����擾���܂��B
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