using System;
using System.Text;


namespace lazurite.util {


    public static class RadixConvert {
        #region Int16型およびUInt16型用のメソッド群
        /// <summary>
        /// 3～36進数の数値文字列をInt16型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toInt16メソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static short toInt16(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, short.MaxValue );

            return (short)digit;
        }


        /// <summary>
        /// 3～36進数の数値文字列をUInt16型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toUInt16メソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static ushort toUInt16(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, ushort.MaxValue );

            return (ushort)digit;
        }


        /// <summary>
        /// UInt16型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(short n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }


        /// <summary>
        /// UInt16型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(ushort n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }
        #endregion


        #region Int32型およびUInt32型用のメソッド群
        /// <summary>
        /// 3～36進数の数値文字列をInt32型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toInt32メソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static int toInt32(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, int.MaxValue );

            return (int)digit;
        }


        /// <summary>
        /// 3～36進数の数値文字列をUInt32型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toUInt32メソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static uint toUInt32(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, uint.MaxValue );

            return (uint)digit;
        }


        /// <summary>
        /// UInt32型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(int n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }


        /// <summary>
        /// UInt32型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(uint n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }
        #endregion


        #region Int64型およびUInt64型用のメソッド群
        /// <summary>
        /// 3～36進数の数値文字列をInt64型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toInt64メソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static long toInt64(string s, int radix) {
            ulong digit = toUInt64( s, radix );
            check_digit_overflow( digit, long.MaxValue );

            return (long)digit;
        }


        /// <summary>
        /// 3～36進数の数値文字列をUInt64型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toUInt64メソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static ulong toUInt64(string s, int radix) {
            // 引数をチェックをする
            check_number_argument( s );
            check_radix_argument( radix );

            ulong current_value = 0;                              // 変換中の数値
            ulong maximum_value = ulong.MaxValue / (ulong)radix; // 最大値の1けた前の数値

            // 数値文字列を解析して数値に変換する
            char num;   // 処理中の1けたの数値文字列
            int digit;  // 処理中の1けたの数値
            int length = s.Length;
            for ( int i = 0; i < length; i++ ) {
                num = s[i];
                digit = get_digit_from_number( num );
                check_digit_out_of_range( digit, radix );

                // 次にradixを掛けるときに数値がオーバーフローしないかを事前にチェックする
                check_digit_overflow( current_value, maximum_value );
                current_value = current_value * (ulong)radix + (ulong)digit;
            }

            return current_value;
        }


        /// <summary>
        /// UInt64型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(long n, int radix, bool uppercase) {

            return toString( (ulong)n, radix, uppercase );
        }


        /// <summary>
        /// UInt64型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(ulong n, int radix, bool uppercase) {
            // 引数をチェックをする
            check_radix_argument( radix );

            // 数値の「0」は、どの進数でも「0」になる
            if ( n == 0 ) {
                return "0";
            }

            StringBuilder current_value = new StringBuilder( 41 ); // 変換中の数値文字列
            // ※UInt64.MaxValueの数値を3進数で表現すると41けたです。
            ulong current_digit = n;                              // 未処理の数値

            // 数値を解析して数値文字列に変換する
            ulong digit;   // 処理中の1けたの数値
            do {
                // 一番下のけたの数値を取り出す
                digit = current_digit % (ulong)radix;
                // 取り出した1けたを切り捨てる
                current_digit = current_digit / (ulong)radix;

                current_value.Insert( 0, get_number_from_digit( (int)digit, uppercase ) );
            } while ( current_digit != 0 );

            return current_value.ToString();
        }
        #endregion


        #region Decimal型用のメソッド群
        /// <summary>
        /// 3～36進数の数値文字列をDecimal型の数値に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toDecimalメソッドを使ってください。
        /// ※＋や－の符号や0xなどのプレフィックスには対応していません。
        /// ※引数となる数値文字列に、スペースなどの文字を含めないでください。
        /// </remarks>
        /// <param name="s">数値文字列</param>
        /// <param name="radix">基数</param>
        /// <returns>数値</returns>
        public static decimal toDecimal(string s, int radix) {
            // 引数をチェックをする
            check_number_argument( s );
            check_radix_argument( radix );

            decimal current_value = 0;                                   // 変換中の数値
            decimal maximum_value = decimal.MaxValue / (decimal)radix;   // 最大値の1けた前の数値

            // 数値文字列を解析して数値に変換する
            char num;   // 処理中の1けたの数値文字列
            int digit;  // 処理中の1けたの数値
            int length = s.Length;
            for ( int i = 0; i < length; i++ ) {
                num = s[i];
                digit = get_digit_from_number( num );
                check_digit_out_of_range( digit, radix );

                // 次にradixを掛けるときに数値がオーバーフローしないかを事前にチェックする
                check_digit_overflow( current_value, maximum_value );
                current_value = current_value * (decimal)radix + (decimal)digit;
            }

            return current_value;
        }


        /// <summary>
        /// Decimal型の数値を3～36進数の数値文字列に変換します。
        /// </summary>
        /// <remarks>
        /// ※2／8／10／16進数は、Convert.toStringメソッドを使ってください。
        /// ※－符号には対応していません。
        /// </remarks>
        /// <param name="n">数値</param>
        /// <param name="radix">基数</param>
        /// <param name="uppercase">大文字か（true）、小文字か（false）</param>
        /// <returns>数値文字列</returns>
        public static string toString(decimal n, int radix, bool uppercase) {
            // 引数をチェックをする
            check_radix_argument( radix );

            // 数値の「0」は、どの進数でも「0」になる
            if ( n == 0 ) {
                return "0";
            }

            StringBuilder current_value = new StringBuilder( 120 ); // 変換中の数値文字列
            // ※decimal.MaxValueの数値を3進数で表現すると120けたです。
            decimal current_digit = n;                              // 未処理の数値

            // 数値を解析して数値文字列に変換する
            decimal digit;   // 処理中の1けたの数値
            do {
                // 一番下のけたの数値を取り出す
                digit = current_digit % (decimal)radix;
                // 取り出した1けたを切り捨てる
                current_digit = current_digit / (decimal)radix;

                current_value.Insert( 0, get_number_from_digit( (int)digit, uppercase ) );
            } while ( current_digit != 0 );

            return current_value.ToString();
        }
        #endregion


        #region 内部で使用しているメソッド群
        private static void check_number_argument(string s) {
            if ( s == null || s == String.Empty ) {

                throw new ArgumentException( "数値文字列が指定されていません。" );
            }
        }


        private static void check_radix_argument(int radix) {

            if ( radix == 2 || radix == 8 || radix == 10 || radix == 16 ) {
                throw new ArgumentException( "(2|8|10|16)進数は System.Convert クラスを使ってください。" );
            }
            if ( radix <= 1 || 36 < radix ) {
                throw new ArgumentException( "3..36 進数にしか対応していません。" );
            }
        }


        private static void check_digit_out_of_range(int digit, int radix) {
            if ( digit < 0 || radix <= digit ) {
                throw new ArgumentOutOfRangeException( "数値が範囲外です。" );
            }
        }


        private static void check_digit_overflow(ulong current_value, ulong maximum_value) {
            if ( current_value > maximum_value ) {
                throw new OverflowException( "数値が最大値を超えました。" );
            }
        }
        private static void check_digit_overflow(decimal current_value, decimal maximum_value) {
            if ( current_value > maximum_value ) {
                throw new OverflowException( "数値が最大値を超えました。" );
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