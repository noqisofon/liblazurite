using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace lazurite.util {


    /// <summary>
    /// �摜��
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
            // �w�肳�ꂽ�傫���� Bitmap �I�u�W�F�N�g���쐬���܂��B
            Bitmap dest = new Bitmap( width, height );

            // ��� Bitmap �I�u�W�F�N�g���� Graphics �I�u�W�F�N�g���쐬���܂��B
            Graphics g = Graphics.FromImage( dest );
            // �ۊǃ��[�h��ݒ肵�܂��B
            g.InterpolationMode = imode;
            // �ۊǃ��[�h���g�p���āA�w�肳�ꂽ�傫���̉摜��`���܂��B
            g.DrawImage( src, 0, 0, width, height );

            // �w�肳�ꂽ�t�@�C�����ŕۑ����܂��B
            dest.Save( filename, format );
        }
    }
}