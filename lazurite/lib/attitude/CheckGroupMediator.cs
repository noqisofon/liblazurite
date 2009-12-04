using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace lazurite.attitude {


    using lazurite.common;
    using lazurite.pattern.mediators;


    /// <summary>
    /// CheckBox���̃X�g���b�v �̃O���[�v��ݒ肵�āA�ǂꂩ�������ꂽ��A���̃X�g���b�v�ɂ����f�����܂��B
    /// </summary>
    public class CheckGroupMediator : AbstractMediator<ToolStripMenuItem> {


        /// <summary>
        /// 
        /// </summary>
        public CheckGroupMediator()
            : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__item"></param>
        /// <returns></returns>
        public override bool send(ToolStripMenuItem __item) {
            List<ToolStripMenuItem> li = new List<ToolStripMenuItem>( base.contents );
            if ( li.Contains( __item ) ) {

                foreach ( ToolStripMenuItem it in li ) {
                    
                    if ( it != __item ) {
                        it.Checked = false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
