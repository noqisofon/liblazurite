using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace lazurite.pattern.building {


    using lazurite.common;


    /**
     * @class   FileEnumerater      FileEnumerater.cs
     * �t�@�C���ƃt�H���_��񋓂��܂��B
     */
    public class FileEnumerater : basics.IBuilder<FileSystemInfo[]> {
        /// <summary>
        /// 
        /// </summary>
        private List<FileSystemInfo> filelist_;
        /// <summary>
        /// 
        /// </summary>
        private string path_;


        /**
         * �w�肳�ꂽ�p�X���󂯎���āAFileEnumerater �I�u�W�F�N�g��V�����쐬���܂��B
         */
        public FileEnumerater(string __path) {
            this.filelist_ = new List<FileSystemInfo>();
            this.path_ = __path;
        }


        /// <summary>
        /// 
        /// </summary>
        public void buildPart() {
            this.filelist_.AddRange( eachFileAndDirectories( new DirectoryInfo( path_ ) ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        static private FileSystemInfo[] eachFileAndDirectories(DirectoryInfo current) {
            List<FileSystemInfo> li = new List<FileSystemInfo>();
            //Algorithms.each<FileSystemInfo>(
            //    current.GetFileSystemInfos(),
            //    delegate(FileSystemInfo article) {
            //        li.Add( article );
            //        if ( article is DirectoryInfo ) {
            //            li.AddRange( eachFileAndDirectories( article as DirectoryInfo ) );
            //        }
            //    }
            //);
            foreach ( FileSystemInfo fsi in current.GetFileSystemInfos() ) {
                li.Add( fsi );
                if ( fsi.GetType() == typeof( DirectoryInfo ) ) {
                    li.AddRange( eachFileAndDirectories( fsi as DirectoryInfo ) );
                }
            }
            return li.ToArray();
        }


        /// <summary>
        /// ��ƃt�H���_���̑S�Ẵt�H���_��t�@�C����z��ɂ��ĕԂ��܂��B
        /// </summary>
        public FileSystemInfo[] result {
            get {
                return filelist_.ToArray();
            }
        }
    }
}