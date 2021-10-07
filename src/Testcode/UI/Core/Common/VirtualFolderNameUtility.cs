//-------------------------------------------------------------------
// <copyright file="VirtualFolderNameUtility.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Utility Class to get Virtual Folder Name.
// </summary>
// <history>
//   [lucyra] 12ODec08 Created
// </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    using System.Runtime.InteropServices;
    #endregion

    #region Enum Virtual Folder
    /// <summary>
    /// Enum to get virtual folder
    /// </summary>
    public enum VirtualFolder
    {
        /// <summary>
        /// My Computer
        /// </summary>
        MyComputer,
        /// <summary>
        /// My Documents
        /// </summary>
        MyDocuments,
        /// <summary>
        /// Network Neighbourhood
        /// </summary>
        NetworkNeighbourhood,
        /// <summary>
        /// Recycle Bin
        /// </summary>
        RecycleBin,
        /// <summary>
        /// Internet Explorer
        /// </summary>
        InternetExplorer,
        /// <summary>
        /// Program Files
        /// </summary>
        ProgramFiles,
        /// <summary>
        /// Local Disk
        /// </summary>
        LocalDisk
    };
    #endregion

    /// <summary>
    /// Virtual Folder Name Utility
    /// </summary>
    public class VirtualFolderNameUtility
    {
        [DllImport("User32.dll")]
        static extern int LoadString(
            IntPtr hInstance,
            int uID,
            StringBuilder lpBuffer,
            int nBufferMax);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibraryEx(
            string lpFileName,
            IntPtr hFile,
            uint dwFlags);

        private const string shellLibraryName = "Shell32.dll";
        private const int LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        private const int MYCOMPUTER_RESOURCE_OFFSET = 9216;
        private const int MYDOCUMENTS_RESOURCE_OFFSET = 9227;
        private const int NETWORKNEIGHBOURHOOD_RESOURCE_OFFSET = 9217;
        private const int RECYCLEBIN_RESOURCE_OFFSET = 8964;
        private const int INTERNETEXPLORER_RESOURCE_OFFSET = 9222;
        private const int PROGRAMFILES_RESOURCE_OFFSET = 21781;
        private const int LOCALDISK_RESOURCE_OFFSET = 9404;

        /// <summary>
        /// Gets the localized name of certain virtual system folders.
        /// </summary>
        /// <param name="folder">A member of the VirtualFolder enumeration.</param>
        /// <returns>localized string</returns>
        public static string GetLocalizedName(
            VirtualFolder folder)
        {
            return VirtualFolderNameUtility.GetLocalizedName(folder, 0);
        }

        /// <summary>
        /// Gets the localized name of certain virtual system folders.
        /// </summary>
        /// <param name="folder">A member of the VirtualFolder enumeration.</param>
        /// <param name="offset">offset value for shell32 string table</param>
        /// <returns>localized string</returns>
        public static string GetLocalizedName(
            VirtualFolder folder,
            int offset)
        {
            IntPtr sh32lib = LoadLibraryEx(
                shellLibraryName,
                IntPtr.Zero,
                LOAD_LIBRARY_AS_DATAFILE);

            StringBuilder sb = new StringBuilder(256);

            switch (folder)
            {
                case VirtualFolder.MyComputer:
                    LoadString(sh32lib, MYCOMPUTER_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                case VirtualFolder.MyDocuments:
                    LoadString(sh32lib, MYDOCUMENTS_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                case VirtualFolder.NetworkNeighbourhood:
                    LoadString(sh32lib, NETWORKNEIGHBOURHOOD_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                case VirtualFolder.RecycleBin:
                    LoadString(sh32lib, RECYCLEBIN_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                case VirtualFolder.InternetExplorer:
                    LoadString(sh32lib, INTERNETEXPLORER_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                case VirtualFolder.ProgramFiles:
                    LoadString(sh32lib, PROGRAMFILES_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                case VirtualFolder.LocalDisk:
                    LoadString(sh32lib, LOCALDISK_RESOURCE_OFFSET + offset, sb, 255);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("folder");
            }

            return sb.ToString();
        }

    }
}
