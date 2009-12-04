namespace lazurite.pattern.basics {


    public interface tag_Strategy {
        /// <summary>
        /// アルゴリズムの名前を返します。
        /// </summary>
        string name { get; }
    }

    
    
    /// <summary>
    /// アルゴリズムを動的に変更することができます。
    /// </summary>
    public interface IStrategy : tag_Strategy {
        /// <summary>
        /// アルゴリズムを実行します。
        /// </summary>
        void execute();
    }
}