using System;


namespace lazurite.util.microsoft.win32api {
    /// <summary>
    /// 
    /// </summary>
    public struct BY_HANDLE_FILE_INFORMATION {
        public uint dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public uint dwVolumeSerialNumber;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint nNumberOfLinks;
        public uint nFileIndexHigh;
        public uint nFileIndexLow;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format( "#<BY_HANDLE_FILE_INFORMATION:0x{0:x} @FileAttributes={1} "
                + "@CreationTime={2} "
                + "@LastAccessTime={3} "
                + "@LastWriteTime={4} "
                + "@VolumeSerialNumber={5} "
                + "@FileSizeHigh={6} "
                + "@FileSizeLow={7} "
                + "@NumberOfLinks={8} "
                + "@FileIndexHight={9} "
                + "@FileIndexLow={10}>",
                (uint)this.GetHashCode(),
                this.dwFileAttributes,
                this.ftCreationTime,
                this.ftLastAccessTime,
                this.ftLastWriteTime,
                this.dwVolumeSerialNumber,
                this.nFileSizeHigh,
                this.nFileSizeLow,
                this.nNumberOfLinks,
                this.nFileIndexHigh,
                this.nFileIndexLow );
        }
    }
}
