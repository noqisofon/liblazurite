using System.Collections.Generic;


namespace lazurite.pattern.commanding {


    /// <summary>
    /// MacroStackCommand クラスは、コマンドの格納に Stack を使用したクラスです。 
    /// </summary>
    public class MacroStackCommand : MacroCommand {
        //
        private Stack<Command> commands_;


        /// <summary>
        /// 
        /// </summary>
        public MacroStackCommand() {
            this.commands_ = new Stack<Command>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__command"></param>
        public MacroStackCommand(Command __command) {
            this.commands_ = new Stack<Command>();
            store( __command );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__commands"></param>
        public MacroStackCommand(Command[] __commands) {
            this.commands_ = new Stack<Command>();
            storeAll( __commands );
        }


        /// <summary>
        /// 
        /// </summary>
        public override void execute() {
            foreach ( Command command in this.commands_ ) {
                command.execute();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__stored_command"></param>
        public override void store(Command __stored_command) {
            if ( __stored_command != this ) {
                this.commands_.Push( __stored_command );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="__stored_commands"></param>
        public override void storeAll(Command[] __stored_commands) {
            foreach ( Command command in __stored_commands ) {
                store( command );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void undo() {
            if ( this.commands_.Count != 0 ) {
                this.commands_.Pop();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void clear() {
            this.commands_.Clear();
        }


        /// <summary>
        /// 
        /// </summary>
        public override int entries {
            get { return this.commands_.Count; }
        }
    }
}