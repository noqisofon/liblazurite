using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace lazurite.pattern.building {


    /// <summary>
    /// Composite Ç©ÇÁÅA TreeNode Ç÷ÇÃïœä∑ÇçsÇ¢Ç‹Ç∑ÅB
    /// </summary>
    public class TreeNodeConvertor : HierarchyBuilder<TreeNode> {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__target_path"></param>
        public TreeNodeConvertor(string __target_path)
            : base( __target_path ) 
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__target_path"></param>
        /// <param name="__weave_filter"></param>
        public TreeNodeConvertor(string __target_path, TreeWeaver<TreeNode> __weave_filter)
            : base( __target_path, __weave_filter ) 
        {
        }



        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {
            FileSystemPacker packer = new FileSystemPacker( base.target_path_ );
            packer.buildPart();

            this.root_ = fraction_pack( packer.result as attitude.Folder );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__composite"></param>
        /// <returns></returns>
        private TreeNode fraction_pack(attitude.Folder __composite) {
            Queue<TreeNode> q = new Queue<TreeNode>();

            if ( !__composite.is_nodeEmpty ) {
                foreach ( attitude.AbstractFileNode article in __composite.nodes ) {
                    TreeNode node;
                    bool is_composite = false;

                    if ( article.is_composite ) {
                        is_composite = true;
                        node = fraction_pack( article as attitude.Folder );
                    } else {
                        node = new TreeNode( article.text );
                    }

                    if ( weave_filter_ != null ) { weave_filter_( node, is_composite ); }

                    q.Enqueue( node );
                }
            }
            q.Enqueue( new TreeNode( __composite.text, packing( q ) ) );
            
            return q.Dequeue();
        }
    }
}
