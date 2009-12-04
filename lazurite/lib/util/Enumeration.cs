using System;


namespace lazurite.util {


    /// <summary>
    /// System.Enum のショートカットです。
    /// パースするときなど、キャストしなくてもいいので安心です。
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    public sealed class Enumeration<_T> {
        /// <summary>
        /// 
        /// </summary>
        private Type target_type_;


        /// <summary>
        /// 
        /// </summary>
        public Enumeration() {
            this.target_type_ = typeof( _T );
        }


        /// <summary>
        /// 文字列から、列挙体の値を返します。
        /// </summary>
        /// <param name="__value"></param>
        /// <param name="__ignore_case">大文字小文字を</param>
        /// <returns></returns>
        public _T valueOf(string __value, bool __ignore_case) {
            return (_T)Enum.Parse( this.target_type_, __value, __ignore_case );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T valueOf(string __value) {
            return valueOf( __value, false );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(byte __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(int __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(long __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(object __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(sbyte __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(short __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(uint __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(ulong __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public _T fromValue(ushort __value) {
            return (_T)Enum.ToObject( this.target_type_, __value );

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public _T[] to_a() {
            return (_T[])Enum.GetValues( this.target_type_ );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] names {
            get {
                return Enum.GetNames( this.target_type_ );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        public string this[object __value] {
            get {
                return Enum.GetName( this.target_type_, __value );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__value"></param>
        /// <returns></returns>
        public bool defined(object __value) {
            return Enum.IsDefined( this.target_type_, __value );
        }
    }
}