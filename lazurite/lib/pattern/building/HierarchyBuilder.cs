using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace lazurite.pattern.building {


    using lazurite.common;


    //public delegate _Tree FractionFilter<_Target>(_Target __current);
    public delegate void TreeWeaver<_Tree>(_Tree __node, bool __is_composite);


    /**
     * HierarchyPacker �N���X�́A�c���[�\���̑Ώە����Q�l�ɁA�ċA���g����
     * TreeView �R���g���[���ł̃c���[�\�����ȒP�ɍ쐬���邽�߂̒��ۃN���X�ł��B
     *
     * ���̗�ł́A2 ��̃f�B���N�g�����J�����g�Ƃ����؍\�����쐬���܂��B
     * <pre>
     * Exsample:
     *      HierarchyPacker<Tree> packer = new FileSystemPacker("../../");
     *      packer.each_pack();
     *      Tree tree = packer.result;
     * </pre>
     */
    public abstract class HierarchyBuilder<_Tree> : basics.IBuilder<_Tree> {
        /**
         * ���[�g�̕�����\���B
         */
        protected string target_path_;
        /**
         * TreeView �I�u�W�F�N�g�Ɉ�ԋ߂��m�[�h�B
         */
        protected _Tree root_;
        /**
         * �A�C�R����ݒ肷�邽�߂Ƀt�B���^�����O����f���Q�[�g�B
         */
        protected TreeWeaver<_Tree> weave_filter_ = null;


        /**
         * �c���[�\���̈�ԏ�̃p�X���w�肵�� HierarchyPacker �I�u�W�F�N�g �����������܂��B
         *      @param  __target_path �c���[�\���̈�ԏ�̃p�X�B
         */
        protected HierarchyBuilder(string __target_path) {
            initialize( __target_path, null );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__target_path"></param>
        /// <param name="__weave_filter"></param>
        protected HierarchyBuilder(string __target_path, TreeWeaver<_Tree> __weave_filter) {
            initialize( __target_path, __weave_filter );
        }


        /**
         * �R���X�g���N�^�ōs�����������̃��\�b�h�ɏW�񂵂܂��B
         */
        private void initialize(string __target_path, TreeWeaver<_Tree> __weave_filter) {
            this.target_path_ = __target_path;
            this.weave_filter_ = __weave_filter;
        }


        /// <summary>
        /// 
        /// </summary>
        public abstract void buildPart();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__q"></param>
        /// <returns></returns>
        protected _Tree[] packing(Queue<_Tree> __q) {
            _Tree[] nodes = new _Tree[__q.Count];
            for ( int i = 0; i < nodes.Length; ++i ) {
                nodes[i] = __q.Dequeue();
            }
            return nodes;
        }


        /// <summary>
        /// ���ʕ����擾���܂��B
        /// </summary>
        public _Tree result {
            get { return root_; }
        }
    }
}