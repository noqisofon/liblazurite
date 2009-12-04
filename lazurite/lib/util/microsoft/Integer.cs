using System;


namespace lazurite.util.microsoft {


    /// <summary>
    /// 
    /// </summary>
    public static class Integer {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        public static long toLargeIntegerFromHighAndLow(uint high, uint low) {
            return (long)( ( ( (ulong)high ) << 32 ) | (uint)low );
        }
    }
}
