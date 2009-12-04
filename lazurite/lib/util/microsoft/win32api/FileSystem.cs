using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;


namespace lazurite.util.microsoft.win32api {
    /// <summary>
    /// 
    /// </summary>
    public static class FileSystem {
        public const short FILE_ATTRIBUTE_NORMAL = 0x80;

        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;

        public const uint FILE_FLAG_WRITE_THROUGH = 0x80000000;
        public const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        public const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
        public const uint FILE_FLAG_RANDOM_ACCESS = 0x10000000;
        public const uint FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000;
        public const uint FILE_FLAG_DELETE_ON_CLOSE = 0x04000000;
        public const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
        public const uint FILE_FLAG_POSIX_SEMANTICS = 0x01000000;
        public const uint FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000;
        public const uint FILE_FLAG_OPEN_NO_RECALL = 0x00100000;
        public const uint FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000;

        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint OPEN_ALWAYS = 4;
        public const uint TRUNCATE_EXISTING = 5;


        /// <summary>
        /// 指定されたファイルに関する情報を取得します。
        /// </summary>
        /// <param name="hFile">情報を取得するべきファイルのハンドルを指定します。</param>
        /// <param name="lpFileInformation">1 個の 構造体へ参照を指定します。</param>
        /// <returns></returns>
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool GetFileInformationByHandle(
          SafeFileHandle hFile,                                  // ファイルのハンドル
          out BY_HANDLE_FILE_INFORMATION lpFileInformation // バッファ
        );


        /// <summary>
        /// ファイルを開くか、作成します。
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns></returns>
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern SafeFileHandle CreateFile(string lpFileName,
                                                        uint dwDesiredAccess,
                                                        uint dwShareMode,
                                                        IntPtr lpSecurityAttributes,
                                                        uint dwCreationDisposition,
                                                        uint dwFlagsAndAttributes,
                                                        IntPtr hTemplateFile
                                                      );
    }


}