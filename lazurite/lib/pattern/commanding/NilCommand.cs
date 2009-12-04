namespace lazurite.pattern.commanding {


    /// <summary>
    /// NilCommand クラスは NullObject パターンを利用して、
    /// コマンドを列挙して execute() するときに null 判定を行わなくてもよいようにします。
    /// このクラスは継承できません。
    /// </summary>
    public sealed class NilCommand : Command {
        /// <summary>
        /// Singleton パターンを適用するために必要です。
        /// </summary>
        static private NilCommand the_instance = new NilCommand();


        /// <summary>
        /// シングルトン用にコンストラクタを private にします。
        /// </summary>
        private NilCommand() { }


        /// <summary>
        /// 何もしません。
        /// </summary>
        public override void execute() { }


        /// <summary>
        /// 唯一のインスタンスを取得します。
        /// </summary>
        static public NilCommand instance {
            get {
                return the_instance;
            }
        }
    }
}