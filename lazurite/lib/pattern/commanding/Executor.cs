using System;


namespace lazurite.pattern.commanding {


    /// <summary>
    /// コマンドを実行する前と後に何らかの処理を行う特殊なコマンドです。
    /// </summary>
    class Executor : Command {
        // 内部コマンド。
        private Command command_;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler before;
        
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler after;


        /// <summary>
        /// 
        /// </summary>
        public Executor() {
            initialize( NilCommand.instance );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__command"></param>
        public Executor(Command __command) {
            initialize( __command );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__commands"></param>
        public Executor(Command[] __commands) {
            initialize( new MacroQueueCommand( __commands ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__command"></param>
        private void initialize(Command __command) {
            this.command_ = __command;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ergs"></param>
        protected virtual void onBeforePerform(EventArgs ergs) {
            if ( before != null ) {
                before( this, ergs );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ergs"></param>
        protected virtual void onAfterPerform(EventArgs ergs) {
            if ( after != null ) {
                after( this, ergs );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void execute() {
            onBeforePerform( EventArgs.Empty );
            try {
                this.command_.execute();
            } finally {
                onAfterPerform( EventArgs.Empty );
            }
        }
    }
}