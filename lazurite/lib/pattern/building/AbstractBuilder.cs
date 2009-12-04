namespace lazurite.pattern.building {


    /// <summary>
    /// ���̒��ۓI�� Builder �N���X�́A�K�v�Œ���̃��\�b�h���������A�h���N���X�����₷�����܂��B
    /// </summary>
    /// <typeparam name="_Target">��������^�B</typeparam>
    public abstract class AbstractBuilder<_Target> : basics.IBuilder<_Target> {
        // Builder �������ΏۂƂ���I�u�W�F�N�g�ł��B
        private _Target content_;


        /// <summary>
        /// �w�肳�ꂽ�����Ώۂ��󂯎���āAAbstractBuilder ���\�z���܂��B
        /// </summary>
        /// <param name="__content">�����Ώۂ̃I�u�W�F�N�g�B</param>
        protected AbstractBuilder(_Target __content) {
            this.content_ = __content;
        }


        /// <summary>
        /// �����Ώۂ��\�z���܂��B
        /// </summary>
        public abstract void buildPart();


        /// <summary>
        /// �h�� Builder ���Ő����ΏۂɃA�N�Z�X���邽�߂ɕK�v�ł��B
        /// </summary>
        protected _Target content {
            get { return content_; }
        }


        /// <summary>
        /// �������������Ώۂ�Ԃ��܂��B
        /// </summary>
        public _Target result {
            get { return content_; }
        }
    }
}