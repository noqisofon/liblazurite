namespace lazurite.pattern.commanding {


    /// <summary>
    /// MacroCommand �N���X�́ACommand ����ׂ�
    /// �A���I�ɋN�������邱�Ƃ�ړI�Ƃ����N���X�ł��B
    /// </summary>
    public abstract class MacroCommand : Command, common.Storeable<Command> {
        /// <summary>
        /// �w�肳�ꂽ�R�}���h��ǉ����܂��B
        /// </summary>
        /// <param name="__stored_command"></param>
        public abstract void store(Command __stored_command);
        
        
        /// <summary>
        /// �w�肳�ꂽ�R�}���h�̔z�񂩂�A�R�}���h��S�Ēǉ����܂��B
        /// </summary>
        /// <param name="__stored_commands"></param>
        public abstract void storeAll(Command[] __stored_commands);
        
        
        /// <summary>
        /// �R�}���h���X�L�b�v���܂��B
        /// </summary>
        public abstract void undo();
        
        
        /// <summary>
        /// �X�g�A�����R�}���h��S�č폜���܂��B
        /// </summary>
        public abstract void clear();


        /// <summary>
        /// �X�g�A�����R�}���h�̐���Ԃ��܂��B
        /// </summary>
        public abstract int entries { get; }
    }


}