using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace lazurite.util {


    using lazurite.pattern.factories;


    /// <summary>
    /// 
    /// </summary>
    public class ColorFactory : AbstractPoolingFactory<Color> {
        /// <summary>
        /// 
        /// </summary>
        private static ColorPool Poolish_ = new ColorPool();


        /// <summary>
        /// 
        /// </summary>
        public ColorFactory() { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__R"></param>
        /// <param name="__G"></param>
        /// <param name="__B"></param>
        /// <returns></returns>
        public Color create(byte __R, byte __G, byte __B) {
            Color result = Poolish_.find( __R, __G, __B );
            if ( result != Color.Empty ) {
                return result;
            }
            result = Color.FromArgb( __R, __G, __B );
            Poolish_.store( result );

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__color_name"></param>
        /// <returns></returns>
        public override Color create(string __color_name) {
            return Poolish_.find( __color_name );
        }


        /// <summary>
        /// Color オブジェクトをプーリングします。
        /// </summary>
        protected class ColorPool : AbstractTargetPool<Color> {
            /// <summary>
            /// 
            /// </summary>
            private List<Color> colors_;


            /// <summary>
            /// 
            /// </summary>
            public ColorPool() {
                this.colors_ = new List<Color>();

                foreach ( string color_name in Enum.GetNames( typeof( KnownColor ) ) ) {
                    store( Color.FromName( color_name ) );
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__stored_color"></param>
            public override void store(Color __stored_color) {
                this.colors_.Add( __stored_color );
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__stored_colors"></param>
            public override void storeAll(Color[] __stored_colors) {
                this.colors_.AddRange( __stored_colors );
            }


            /// <summary>
            /// 
            /// </summary>
            public override int entries {
                get {
                    return this.colors_.Count;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__R"></param>
            /// <param name="__G"></param>
            /// <param name="__B"></param>
            /// <returns></returns>
            public Color find(byte __R, byte __G, byte __B) {
                foreach ( Color c in this.colors_ ) {
                    if ( c.R == __R && c.G == __G && c.B == __B ) {
                        return c;
                    }
                }
                return Color.Empty;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="__color_name"></param>
            /// <returns></returns>
            public Color find(string __color_name) {
                foreach ( Color c in this.colors_ ) {
                    if ( c.Name == __color_name ) {
                        return c;
                    }
                }
                return Color.Empty;
            }
        }
    }
}
