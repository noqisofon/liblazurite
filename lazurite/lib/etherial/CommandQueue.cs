using System;
using System.Collections.Generic;
using System.Data;


namespace lazurite.etherial {


    using lazurite.common;


    /**
     * CommandQueue �N���X�́A�R�}���h�I�u�W�F�N�g�𕡐����L���A
     * �A���I�ɋN�������邱�Ƃ�ړI�Ƃ����R���N�V�������N���X�ł��B
     */
    public class CommandQueue<_Command> where _Command : IDbCommand {
        private Queue<_Command> commandq_;
        /**
         * �V���� CommandQueue �I�u�W�F�N�g���쐬���܂��B 
         */
        public CommandQueue() {
            initialize();
        }
        /**
         * �R�}���h���󂯎���āA�V���� CommandQueue �I�u�W�F�N�g���쐬���܂��B 
         */
        public CommandQueue(_Command __command) {
            initialize();
            push( __command );
        }
        /**
         * �R�}���h�̔z����󂯎���āA�V���� CommandQueue �I�u�W�F�N�g���쐬���܂��B 
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
         * �R���X�g���N�^�Ŏg�p���鋤�ʏ����ł��B
         */
        private void initialize() {
            this.commandq_ = new Queue<_Command>();
        }


        /**
         * �R�}���h��ǉ����܂��B
         */
        public void push(_Command __command) {
            this.commandq_.Enqueue( __command );
        }


        /**
         * �L���[�ɓ����Ă���R�}���h�����o���ĕԂ��܂��B
         */
        public _Command pop() {
            return this.commandq_.Dequeue();
        }


        /**     
         * �L���[�ɓ����Ă���R�}���h�����o�����ɕԂ��܂��B
         */
        public _Command peek() {
            return this.commandq_.Peek();
        }


        /**     
         * �L���[�ɓ����Ă���R�}���h�����o���ċN�������܂��B
         */
        public int execution_pop() {
            _Command command = pop();

            return command.ExecuteNonQuery();
        }
        
        
        /**
         * ���V�[�o�����L���Ă���R�}���h��S�Ď��o���A�z��ɂ��ĕԂ��܂��B
         */
        public _Command[] popAll() {
            List<_Command> li = new List<_Command>();
            while ( commandq_.Count > 0 ) {
                li.Add( commandq_.Dequeue() );
            }
            return li.ToArray();
        }


        /**     
         * �L���[�ɓ����Ă���R�}���h�����o�����ɋN�������܂��B
         */
        public int execution_peek() {
            _Command command = peek();
            return command.ExecuteNonQuery();
        }
        
        
        /**
         * �L���[�ɓ����Ă���R�}���h�̌���Ԃ��܂��B
         */
        public int entries {
            get { return commandq_.Count; }
        }
    }
}