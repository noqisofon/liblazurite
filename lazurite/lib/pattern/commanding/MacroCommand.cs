namespace lazurite.pattern.commanding {


    /// <summary>
    /// MacroCommand クラスは、Command を並べて
    /// 連続的に起動させることを目的としたクラスです。
    /// </summary>
    public abstract class MacroCommand : Command, common.Storeable<Command> {
        /// <summary>
        /// 指定されたコマンドを追加します。
        /// </summary>
        /// <param name="__stored_command"></param>
        public abstract void store(Command __stored_command);
        
        
        /// <summary>
        /// 指定されたコマンドの配列から、コマンドを全て追加します。
        /// </summary>
        /// <param name="__stored_commands"></param>
        public abstract void storeAll(Command[] __stored_commands);
        
        
        /// <summary>
        /// コマンドをスキップします。
        /// </summary>
        public abstract void undo();
        
        
        /// <summary>
        /// ストアしたコマンドを全て削除します。
        /// </summary>
        public abstract void clear();


        /// <summary>
        /// ストアしたコマンドの数を返します。
        /// </summary>
        public abstract int entries { get; }
    }


}