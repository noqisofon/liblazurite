namespace lazurite.pattern.commanding {


    /// <summary>
    /// Command �N���X�́A�S�ẴR�}���h�̊��N���X�ł��B
    /// </summary>
    public abstract class Command : basics.ICommand {
        /// <summary>
        /// �R�}���h���N�����܂��B
        /// </summary>
        public abstract void execute();
    }
}