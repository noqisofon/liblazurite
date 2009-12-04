namespace lazurite.pattern.commanding {


    /// <summary>
    /// Command クラスは、全てのコマンドの基底クラスです。
    /// </summary>
    public abstract class Command : basics.ICommand {
        /// <summary>
        /// コマンドを起動します。
        /// </summary>
        public abstract void execute();
    }
}