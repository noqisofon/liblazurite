namespace lazurite.pattern.basics {


    public interface tag_Strategy {
        /// <summary>
        /// �A���S���Y���̖��O��Ԃ��܂��B
        /// </summary>
        string name { get; }
    }

    
    
    /// <summary>
    /// �A���S���Y���𓮓I�ɕύX���邱�Ƃ��ł��܂��B
    /// </summary>
    public interface IStrategy : tag_Strategy {
        /// <summary>
        /// �A���S���Y�������s���܂��B
        /// </summary>
        void execute();
    }
}