using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTreeView
{
    /// <summary>
    /// Information about a directory item such as a drive, folder or a file
    /// </summary>
    public class DirectoryItem
    {

        public DirectoryItem(string fullPath, DirectoryItemType type)
        {
            this.FullPath = fullPath;
            this.Type = type;
        }



        /// <summary>
        /// The type of this DirectoryItem
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }


        /// <summary>
        /// The name of this directory
        /// </summary>
        public string Name { get => this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); }



    }
}
