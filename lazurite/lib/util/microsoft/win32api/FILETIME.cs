using System;


namespace lazurite.util.microsoft.win32api {

    /// <summary>
    /// FILETIME 構造体は 1601 年 1 月 1 日からの 100 ナノ秒間隔の数を表す 64 ビットの値です。
    /// </summary>
    public struct FILETIME {
        /// <summary>
        /// ファイル時間の下位 32 ビットが格納されます。
        /// </summary>
        public uint DateTimeLow;
        /// <summary>
        /// ファイル時間の上位32ビットが格納されます。
        /// </summary>
        public uint DateTimeHigh;


        /// <summary>
        /// 現在の FILETIME を表す文字列を返します。
        /// </summary>
        /// <returns>現在の FILETIME を表す string。</returns>
        public override string ToString() {
            return string.Format( "#<FILETIME:0x{0:x} @DateTimeLow={1} @DateTimeHigh={2}>",
                                  (uint)this.GetHashCode(),
                                  this.DateTimeLow,
                                  this.DateTimeHigh
                                );
        }


        /// <summary>
        /// DateTime に変換して返します。
        /// </summary>
        /// <returns>変換された DateTime。</returns>
        public DateTime ToDateTime() {
            return DateTime.FromFileTime( util.microsoft.Integer.toLargeIntegerFromHighAndLow( this.DateTimeHigh, this.DateTimeLow ) );
        }
    }
}