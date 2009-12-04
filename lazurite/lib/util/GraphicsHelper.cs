using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace lazurite.util {


    /// <summary>
    /// 画像を
    /// </summary>
    public class GraphicsHelper {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="filename"></param>
        static public void scaleImage(Image src, int width, int height, string filename) {
            scaleImage( src, width, height, filename, InterpolationMode.HighQualityBicubic );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="filename"></param>
        /// <param name="imode"></param>
        static public void scaleImage(Image src, int width, int height, string filename, InterpolationMode imode) {
            scaleImage( src, width, height, filename, imode, src.RawFormat );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="filename"></param>
        /// <param name="imode"></param>
        /// <param name="format"></param>
        static public void scaleImage(Image src, int width, int height, string filename, InterpolationMode imode, ImageFormat format) {
            // 指定された大きさの Bitmap オブジェクトを作成します。
            Bitmap dest = new Bitmap( width, height );

            // 空の Bitmap オブジェクトから Graphics オブジェクトを作成します。
            Graphics g = Graphics.FromImage( dest );
            // 保管モードを設定します。
            g.InterpolationMode = imode;
            // 保管モードを使用して、指定された大きさの画像を描きます。
            g.DrawImage( src, 0, 0, width, height );

            // 指定されたファイル名で保存します。
            dest.Save( filename, format );
        }
    }
}