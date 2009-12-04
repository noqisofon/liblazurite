using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace lazurite.pattern.building {


    using lazurite.attitude;


    /// <summary>
    /// 
    /// </summary>
    public class FileSystemPacker : HierarchyBuilder<attitude.AbstractFileNode> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__target_path"></param>
        public FileSystemPacker(string __target_path)
            : base( __target_path ) 
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {
            this.root_ = fraction_pack( new DirectoryInfo( base.target_path_ ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__current_directory"></param>
        /// <returns></returns>
        attitude.AbstractFileNode fraction_pack(DirectoryInfo __current_directory) {
            attitude.Folder trunk = new attitude.Folder( __current_directory.Name );

            foreach ( FileSystemInfo article in __current_directory.GetFileSystemInfos() ) {
                attitude.AbstractFileNode node;

                if ( article.Attributes == FileAttributes.Directory ) {
                    node = fraction_pack( article as DirectoryInfo );
                } else {
                    node = new FileNode( article.Name );
                }

                trunk.append( node );
            }
            return trunk;
        }
    }
}