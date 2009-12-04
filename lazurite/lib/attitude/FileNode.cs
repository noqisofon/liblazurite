using System;
using System.Collections.Generic;


namespace lazurite.attitude {


    /// <summary>
    /// 木構造の末端を表すクラスです。
    /// </summary>
    public class FileNode : AbstractFileNode {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__text"></param>
        public FileNode(string __text)
            : base( __text ) 
        {
        }
    }
}