using System;
using System.Collections.Generic;
using System.Data;


namespace lazurite.etherial {


    using lazurite.common;


    /**
     * CommandQueue クラスは、コマンドオブジェクトを複数所有し、
     * 連続的に起動させることを目的としたコレクション風クラスです。
     */
    public class CommandQueue<_Command> where _Command : IDbCommand {
        private Queue<_Command> commandq_;
        /**
         * 新しく CommandQueue オブジェクトを作成します。 
         */
        public CommandQueue() {
            initialize();
        }
        /**
         * コマンドを受け取って、新しく CommandQueue オブジェクトを作成します。 
         */
        public CommandQueue(_Command __command) {
            initialize();
            push( __command );
        }
        /**
         * コマンドの配列を受け取って、新しく CommandQueue オブジェクトを作成します。 
         */
        public CommandQueue(_Command[] __commands) {
            initialize();
            //Algorithms.each<_Command>(
            //    __commands,
            //    delegate(_Command it) { push( it ); }
            //);
            foreach ( _Command it in __commands ) {
                push(it);
            }
        }


        /**
         * コンストラクタで使用する共通処理です。
         */
        private void initialize() {
            this.commandq_ = new Queue<_Command>();
        }


        /**
         * コマンドを追加します。
         */
        public void push(_Command __command) {
            this.commandq_.Enqueue( __command );
        }


        /**
         * キューに入っているコマンドを取り出して返します。
         */
        public _Command pop() {
            return this.commandq_.Dequeue();
        }


        /**     
         * キューに入っているコマンドを取り出さずに返します。
         */
        public _Command peek() {
            return this.commandq_.Peek();
        }


        /**     
         * キューに入っているコマンドを取り出して起動させます。
         */
        public int execution_pop() {
            _Command command = pop();

            return command.ExecuteNonQuery();
        }
        
        
        /**
         * レシーバが所有しているコマンドを全て取り出し、配列にして返します。
         */
        public _Command[] popAll() {
            List<_Command> li = new List<_Command>();
            while ( commandq_.Count > 0 ) {
                li.Add( commandq_.Dequeue() );
            }
            return li.ToArray();
        }


        /**     
         * キューに入っているコマンドを取り出さずに起動させます。
         */
        public int execution_peek() {
            _Command command = peek();
            return command.ExecuteNonQuery();
        }
        
        
        /**
         * キューに入っているコマンドの個数を返します。
         */
        public int entries {
            get { return commandq_.Count; }
        }
    }
}