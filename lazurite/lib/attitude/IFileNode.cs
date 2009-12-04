using System;
using System.Collections.Generic;


namespace lazurite.attitude {


    /// <summary>
    /// 
    /// </summary>
    public interface IFileNode {
        /// <summary>
        /// �m�[�h�̐[����Ԃ��܂��B
        /// </summary>
        int depth { get; }
        
        
        /// <summary>
        /// �J�����g���x���ł̃C���f�b�N�X�ʒu��Ԃ��܂��B
        /// </summary>
        int index { get; }

        
        /// <summary>
        /// 
        /// </summary>
        string text { get; set; }
        
        
        /// <summary>
        /// �e�m�[�h�����݂��邩�ǂ����𔻕ʂ��܂��B
        /// </summary>
        bool has_parent { get; }
        
        
        /// <summary>
        /// �q�m�[�h�����݂��邩�ǂ����𔻕ʂ��܂��B
        /// </summary>
        bool is_composite { get; }
        
        
        /// <summary>
        /// �X�V���܂��B
        /// </summary>
        void refresh();
    }
}