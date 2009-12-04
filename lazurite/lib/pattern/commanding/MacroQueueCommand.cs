using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.commanding {


    /*
     * MacroQueueCommand クラスは、コマンドの格納に Queue を使用したクラスです。 
     */
    public class MacroQueueCommand : MacroCommand {
        //
        private Queue<Command> commands_;


        /// <summary>
        /// 
        /// </summary>
        public MacroQueueCommand() {
            this.commands_ = new Queue<Command>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__command"></param>
        public MacroQueueCommand(Command __command) {
            this.commands_ = new Queue<Command>();
            store( __command );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__commands"></param>
        public MacroQueueCommand(Command[] __commands) {
            this.commands_ = new Queue<Command>();
            storeAll( __commands );
        }


        /// <summary>
        /// 
        /// </summary>
        public override void execute() {
            foreach ( Command command in commands_ ) {
                command.execute();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__stored_command"></param>
        public override void store(Command __stored_command) {
            if ( __stored_command != this ) {
                this.commands_.Enqueue( __stored_command );
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
                this.commands_.Dequeue();
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
