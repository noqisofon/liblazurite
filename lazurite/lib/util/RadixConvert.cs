using System;
using System.Text;


namespace lazurite.util {


    public static class RadixConvert {
        #region Int16�^�����UInt16�^�p�̃��\�b�h�Q
        /// <summary>
        /// 3�`36�i���̐��l�������Int16�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toInt16���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static short toInt16(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, short.MaxValue );

            return (short)digit;
        }


        /// <summary>
        /// 3�`36�i���̐��l�������UInt16�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toUInt16���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static ushort toUInt16(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, ushort.MaxValue );

            return (ushort)digit;
        }


        /// <summary>
        /// UInt16�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(short n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }


        /// <summary>
        /// UInt16�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(ushort n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }
        #endregion


        #region Int32�^�����UInt32�^�p�̃��\�b�h�Q
        /// <summary>
        /// 3�`36�i���̐��l�������Int32�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toInt32���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static int toInt32(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, int.MaxValue );

            return (int)digit;
        }


        /// <summary>
        /// 3�`36�i���̐��l�������UInt32�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toUInt32���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static uint toUInt32(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, uint.MaxValue );

            return (uint)digit;
        }


        /// <summary>
        /// UInt32�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(int n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }


        /// <summary>
        /// UInt32�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(uint n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }
        #endregion


        #region Int64�^�����UInt64�^�p�̃��\�b�h�Q
        /// <summary>
        /// 3�`36�i���̐��l�������Int64�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toInt64���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static long toInt64(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, long.MaxValue );

            return (long)digit;
        }


        /// <summary>
        /// 3�`36�i���̐��l�������UInt64�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toUInt64���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static ulong toUInt64(string s, int radix) {
            // �������`�F�b�N������
            check_number_argument( s );
            check_radix_argument( radix );

            ulong current_value = 0;                              // �ϊ����̐��l
            ulong maximum_value = ulong.MaxValue / (ulong)radix; // �ő�l��1�����O�̐��l

            // ���l���������͂��Đ��l�ɕϊ�����
            char num;   // ��������1�����̐��l������
            int digit;  // ��������1�����̐��l
            int length = s.Length;
            for ( int i = 0; i < length; i++ ) {
                num = s[i];
                digit = get_digit_from_number( num );
                check_digit_out_of_range( digit, radix );

                // ����radix���|����Ƃ��ɐ��l���I�[�o�[�t���[���Ȃ��������O�Ƀ`�F�b�N����
                check_digit_overflow( current_value, maximum_value );
                current_value = current_value * (ulong)radix + (ulong)digit;
            }

            return current_value;
        }


        /// <summary>
        /// UInt64�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(long n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }


        /// <summary>
        /// UInt64�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(ulong n, int radix, bool uppercase) {
            // �������`�F�b�N������
            check_radix_argument( radix );

            // ���l�́u0�v�́A�ǂ̐i���ł��u0�v�ɂȂ�
            if ( n == 0 ) {
                return "0";
            }

            StringBuilder current_value = new StringBuilder( 41 ); // �ϊ����̐��l������
            // ��UInt64.MaxValue�̐��l��3�i���ŕ\�������41�����ł��B
            ulong current_digit = n;                              // �������̐��l

            // ���l����͂��Đ��l������ɕϊ�����
            ulong digit;   // ��������1�����̐��l
            do {
                // ��ԉ��̂����̐��l�����o��
                digit = current_digit % (ulong)radix;
                // ���o����1������؂�̂Ă�
                current_digit = current_digit / (ulong)radix;

                current_value.Insert( 0, get_number_from_digit( (int)digit, uppercase ) );
            } while ( current_digit != 0 );

            return current_value.ToString();
        }
        #endregion


        #region Decimal�^�p�̃��\�b�h�Q
        /// <summary>
        /// 3�`36�i���̐��l�������Decimal�^�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toDecimal���\�b�h���g���Ă��������B
        /// ���{��|�̕�����0x�Ȃǂ̃v���t�B�b�N�X�ɂ͑Ή����Ă��܂���B
        /// �������ƂȂ鐔�l������ɁA�X�y�[�X�Ȃǂ̕������܂߂Ȃ��ł��������B
        /// </remarks>
        /// <param name="s">���l������</param>
        /// <param name="radix">�</param>
        /// <returns>���l</returns>
        public static decimal toDecimal(string s, int radix) {
            // �������`�F�b�N������
            check_number_argument( s );
            check_radix_argument( radix );

            decimal current_value = 0;                                   // �ϊ����̐��l
            decimal maximum_value = decimal.MaxValue / (decimal)radix;   // �ő�l��1�����O�̐��l

            // ���l���������͂��Đ��l�ɕϊ�����
            char num;   // ��������1�����̐��l������
            int digit;  // ��������1�����̐��l
            int length = s.Length;
            for ( int i = 0; i < length; i++ ) {
                num = s[i];
                digit = get_digit_from_number( num );
                check_digit_out_of_range( digit, radix );

                // ����radix���|����Ƃ��ɐ��l���I�[�o�[�t���[���Ȃ��������O�Ƀ`�F�b�N����
                check_digit_overflow( current_value, maximum_value );
                current_value = current_value * (decimal)radix + (decimal)digit;
            }

            return current_value;
        }


        /// <summary>
        /// Decimal�^�̐��l��3�`36�i���̐��l������ɕϊ����܂��B
        /// </summary>
        /// <remarks>
        /// ��2�^8�^10�^16�i���́AConvert.toString���\�b�h���g���Ă��������B
        /// ���|�����ɂ͑Ή����Ă��܂���B
        /// </remarks>
        /// <param name="n">���l</param>
        /// <param name="radix">�</param>
        /// <param name="uppercase">�啶�����itrue�j�A���������ifalse�j</param>
        /// <returns>���l������</returns>
        public static string toString(decimal n, int radix, bool uppercase) {
            // �������`�F�b�N������
            check_radix_argument( radix );

            // ���l�́u0�v�́A�ǂ̐i���ł��u0�v�ɂȂ�
            if ( n == 0 ) {
                return "0";
            }

            StringBuilder current_value = new StringBuilder( 120 ); // �ϊ����̐��l������
            // ��decimal.MaxValue�̐��l��3�i���ŕ\�������120�����ł��B
            decimal current_digit = n;                              // �������̐��l

            // ���l����͂��Đ��l������ɕϊ�����
            decimal digit;   // ��������1�����̐��l
            do {
                // ��ԉ��̂����̐��l�����o��
                digit = current_digit % (decimal)radix;
                // ���o����1������؂�̂Ă�
                current_digit = current_digit / (decimal)radix;

                current_value.Insert( 0, get_number_from_digit( (int)digit, uppercase ) );
            } while ( current_digit != 0 );

            return current_value.ToString();
        }
        #endregion


        #region �����Ŏg�p���Ă��郁�\�b�h�Q
        private static void check_number_argument(string s) {
            if ( s == null || s == String.Empty ) {

                throw new ArgumentException( "���l�����񂪎w�肳��Ă��܂���B" );
            }
        }


        private static void check_radix_argument(int radix) {

            if ( radix == 2 || radix == 8 || radix == 10 || radix == 16 ) {
                throw new ArgumentException( "(2|8|10|16)�i���� System.Convert �N���X���g���Ă��������B" );
            }
            if ( radix <= 1 || 36 < radix ) {
                throw new ArgumentException( "3..36 �i���ɂ����Ή����Ă��܂���B" );
            }
        }


        private static void check_digit_out_of_range(int digit, int radix) {
            if ( digit < 0 || radix <= digit ) {
                throw new ArgumentOutOfRangeException( "���l���͈͊O�ł��B" );
            }
        }


        private static void check_digit_overflow(ulong current_value, ulong maximum_value) {
            if ( current_value > maximum_value ) {
                throw new OverflowException( "���l���ő�l�𒴂��܂����B" );
            }
        }
        private static void check_digit_overflow(decimal current_value, decimal maximum_value) {
            if ( current_value > maximum_value ) {
                throw new OverflowException( "���l���ő�l�𒴂��܂����B" );
            }
        }


        private static int get_digit_from_number(char num) {
            if ( num >= '0' && num <= '9' ) {
                return num - '0';
            } else if ( num >= 'A' && num <= 'Z' ) {
                return num - 'A' + 10;
            } else if ( num >= 'a' && num <= 'z' ) {
                return num - 'a' + 10;
            } else {
                return -1;
            }
        }


        private static char get_number_from_digit(int digit, bool uppercase) {
            if ( digit < 10 ) {
                return (char)( '0' + digit );
            } else if ( uppercase ) {
                return (char)( 'A' + digit - 10 );
            } else {
                return (char)( 'a' + digit - 10 );
            }
        }
        #endregion
    }


}