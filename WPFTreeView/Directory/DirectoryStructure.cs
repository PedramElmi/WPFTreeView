using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WPFTreeView
{
    /// <summary>
    /// A helper class to query about information of the directories
    /// </summary>
    public static class DirectoryStructure
    {

        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every drive on the machine
            var drives = Directory.GetLogicalDrives();
            var output = (from drive in drives
                         select new DirectoryItem(drive,DirectoryItemType.Drive));
            return output.ToList();
        }

        /// <summary>
        /// Gets the directory top-level content
        /// </summary>
        /// <param name="fullPath">The full path the content to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {

            var items = new List<DirectoryItem>();

            #region Get Folders
            
            // ignoring any issues and getting folders inside of the directory
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange((from dir in dirs
                                    select new DirectoryItem(dir, DirectoryItemType.Folder)).ToList());
                }
            }
            catch
            {

            }

            #endregion

            #region Get Files

            // ignoring any issues and getting files inside of the directory
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange((from file in fs
                                    select new DirectoryItem(file, DirectoryItemType.File)).ToList());
                }
            }
            catch
            {

            }

            #endregion

            return items;

        }


        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string directoryPath)
        {

            if (string.IsNullOrEmpty(directoryPath))
            {
                return string.Empty;
            }

            // make all slashes backslashes
            var normalizedPath = directoryPath.Replace('/', '\\');

            // find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // check for -1 index if we don't find a backslash return the path itself
            if (lastIndex <= 0)
            {
                return directoryPath;
            }
            return directoryPath.Substring(lastIndex + 1);

        }
        #endregion
    }
}
