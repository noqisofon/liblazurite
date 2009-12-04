using System;


namespace lazurite.util.microsoft.win32api {

    /// <summary>
    /// FILETIME �\���̂� 1601 �N 1 �� 1 ������� 100 �i�m�b�Ԋu�̐���\�� 64 �r�b�g�̒l�ł��B
    /// </summary>
    public struct FILETIME {
        /// <summary>
        /// �t�@�C�����Ԃ̉��� 32 �r�b�g���i�[����܂��B
        /// </summary>
        public uint DateTimeLow;
        /// <summary>
        /// �t�@�C�����Ԃ̏��32�r�b�g���i�[����܂��B
        /// </summary>
        public uint DateTimeHigh;


        /// <summary>
        /// ���݂� FILETIME ��\���������Ԃ��܂��B
        /// </summary>
        /// <returns>���݂� FILETIME ��\�� string�B</returns>
        public override string ToString() {
            return string.Format( "#<FILETIME:0x{0:x} @DateTimeLow={1} @DateTimeHigh={2}>",
                                  (uint)this.GetHashCode(),
                                  this.DateTimeLow,
                                  this.DateTimeHigh
                                );
        }


        /// <summary>
        /// DateTime �ɕϊ����ĕԂ��܂��B
        /// </summary>
        /// <returns>�ϊ����ꂽ DateTime�B</returns>
        public DateTime ToDateTime() {
            return DateTime.FromFileTime( util.microsoft.Integer.toLargeIntegerFromHighAndLow( this.DateTimeHigh, this.DateTimeLow ) );
        }
    }
}