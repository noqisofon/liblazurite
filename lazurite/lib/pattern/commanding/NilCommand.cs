namespace lazurite.pattern.commanding {


    /// <summary>
    /// NilCommand �N���X�� NullObject �p�^�[���𗘗p���āA
    /// �R�}���h��񋓂��� execute() ����Ƃ��� null ������s��Ȃ��Ă��悢�悤�ɂ��܂��B
    /// ���̃N���X�͌p���ł��܂���B
    /// </summary>
    public sealed class NilCommand : Command {
        /// <summary>
        /// Singleton �p�^�[����K�p���邽�߂ɕK�v�ł��B
        /// </summary>
        static private NilCommand the_instance = new NilCommand();


        /// <summary>
        /// �V���O���g���p�ɃR���X�g���N�^�� private �ɂ��܂��B
        /// </summary>
        private NilCommand() { }


        /// <summary>
        /// �������܂���B
        /// </summary>
        public override void execute() { }


        /// <summary>
        /// �B��̃C���X�^���X���擾���܂��B
        /// </summary>
        static public NilCommand instance {
            get {
                return the_instance;
            }
        }
    }
}