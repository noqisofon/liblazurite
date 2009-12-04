using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace lazurite.pattern.building {


    using lazurite.common;


    //public delegate _Tree FractionFilter<_Target>(_Target __current);
    public delegate void TreeWeaver<_Tree>(_Tree __node, bool __is_composite);


    /**
     * HierarchyPacker クラスは、ツリー構造の対象物を参考に、再帰を使って
     * TreeView コントロールでのツリー構造を簡単に作成するための抽象クラスです。
     *
     * 此の例では、2 つ上のディレクトリをカレントとした木構造を作成します。
     * <pre>
     * Exsample:
     *      HierarchyPacker<Tree> packer = new FileSystemPacker("../../");
     *      packer.each_pack();
     *      Tree tree = packer.result;
     * </pre>
     */
    public abstract class HierarchyBuilder<_Tree> : basics.IBuilder<_Tree> {
        /**
         * ルートの文字列表現。
         */
        protected string target_path_;
        /**
         * TreeView オブジェクトに一番近いノード。
         */
        protected _Tree root_;
        /**
         * アイコンを設定するためにフィルタリングするデリゲート。
         */
        protected TreeWeaver<_Tree> weave_filter_ = null;


        /**
         * ツリー構造の一番上のパスを指定して HierarchyPacker オブジェクト を初期化します。
         *      @param  __target_path ツリー構造の一番上のパス。
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
         * コンストラクタで行う処理をこのメソッドに集約します。
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
        /// 成果物を取得します。
        /// </summary>
        public _Tree result {
            get { return root_; }
        }
    }
}