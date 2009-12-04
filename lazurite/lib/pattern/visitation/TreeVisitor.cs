namespace lazurite.pattern.visitation {


    using util = lazurite.util;
    using common = lazurite.common;


    /// <summary>
    /// TreeVisitor �N���X�� �c���[�\���ւ̊Ȍ��ȃA�N�Z�X���@��񋟂��܂��B
    /// </summary>
    public class TreeVisitor : AbstractVisitor<attitude.AbstractFileNode> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__closuer"></param>
        public TreeVisitor(util::subroutine<attitude.AbstractFileNode> __closuer)
            : base( __closuer ) 
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__tree"></param>
        public override bool visit(attitude.AbstractFileNode __tree) {
            this.visit_routine_( __tree );
            if ( __tree.is_composite ) {
                attitude.Folder node = __tree as attitude.Folder;
                if ( !node.is_nodeEmpty ) {
                    //common::Algorithms.each<attitude.Tree>( ( __tree as attitude.Composite ).nodes,
                    //                                           delegate(attitude.Tree it) { visit( it ); }
                    //                                         );
                    foreach ( attitude.AbstractFileNode it in node.nodes ) {
                        visit( it );
                    }
                }
                return true;
            }
            return false;
        }
    }
}
