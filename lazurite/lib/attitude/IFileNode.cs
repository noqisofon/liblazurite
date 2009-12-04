using System;
using System.Collections.Generic;


namespace lazurite.attitude {


    /// <summary>
    /// 
    /// </summary>
    public interface IFileNode {
        /// <summary>
        /// ノードの深さを返します。
        /// </summary>
        int depth { get; }
        
        
        /// <summary>
        /// カレントレベルでのインデックス位置を返します。
        /// </summary>
        int index { get; }

        
        /// <summary>
        /// 
        /// </summary>
        string text { get; set; }
        
        
        /// <summary>
        /// 親ノードが存在するかどうかを判別します。
        /// </summary>
        bool has_parent { get; }
        
        
        /// <summary>
        /// 子ノードが存在するかどうかを判別します。
        /// </summary>
        bool is_composite { get; }
        
        
        /// <summary>
        /// 更新します。
        /// </summary>
        void refresh();
    }
}