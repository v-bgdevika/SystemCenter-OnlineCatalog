//-------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Native Methods
// </summary>
//  <history>
//   [mbickle] 01APR05: Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    #endregion

    /// <summary>
    /// Native Methods
    /// </summary>
    public abstract class NativeMethods : Maui.Core.NativeMethods 
    {
        #region Consts
        /// <summary>
        /// WS_EX_TOOLWINDOW
        /// </summary>
        public const int WS_EX_TOOLWINDOW = 0x00000080;

        /// <summary>
        /// WS_EX_APPWINDOW
        /// </summary>
        public const int WS_EX_APPWINDOW = 0x00040000;
        #endregion

        
        #region STRUCT
        ///// <summary>
        ///// Enum for SendMessageTimeoutFlags
        ///// </summary>
        //public enum SendMessageTimeoutFlags : uint
        //{
        //    /// <summary>
        //    /// SMTO_NORMAL
        //    /// </summary>
        //    SMTO_NORMAL = 0x0000,
        //    /// <summary>
        //    /// SMTO_BLOCK
        //    /// </summary>
        //    SMTO_BLOCK = 0x0001,
        //    /// <summary>
        //    /// SMTO_ABORTIFHUNG
        //    /// </summary>
        //    SMTO_ABORTIFHUNG = 0x0002,
        //    /// <summary>
        //    /// SMTO_NOTIMEOUTIFNOTHUNG
        //    /// </summary>
        //    SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        //}
        #endregion
        
        #region Delegates
        /// <summary>
        /// BOOL CALLBACK EnumWindowsProc(
        ///                HWND hwnd,      // handle to parent window
        ///                LPARAM lParam   // application-defined value
        /// </summary>
        /// <param name="window">Window Pointer</param>
        /// <param name ="i">Int</param>
        /// <returns>Bool</returns>
        public delegate bool EnumWindowsProc(
            IntPtr window, int i);
        #endregion

        #region Static Public Methods
        /// <summary>
        /// BringWindowToTop
        /// </summary>
        /// <param name="window">window</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool BringWindowToTop(IntPtr window);
    
        /// <summary>
        /// FindWindowEx
        /// </summary>
        /// <param name="parent">parent</param>
        /// <param name="childAfter">child after</param>
        /// <param name="className">class name</param>
        /// <param name="windowName">window name</param>
        /// <returns>pointer</returns>
        [DllImport("user32.dll")]
        new internal static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childAfter, string className, string windowName);

        /// <summary>
        /// FindWindowWin32
        /// </summary>
        /// <param name="className">class name</param>
        /// <param name="windowName">window name</param>
        /// <returns>pointer</returns>
        [DllImport("user32.dll", EntryPoint="FindWindow")]
        internal static extern IntPtr FindWindowWin32(string className, string windowName);

        /// <summary>
        /// SendMessage
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="message">Message</param>
        /// <param name="wparam">wparam</param>
        /// <param name="lparam">lparam</param>
        /// <returns>Int</returns>
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr window, int message, int wparam, int lparam);
        ///// <summary>
        ///// SendMessageTimeout
        ///// </summary>
        ///// <param name="hWnd">hWnd</param>
        ///// <param name="Msg">Msg</param>
        ///// <param name="wParam">wParam</param>
        ///// <param name="lParam">lParam</param>
        ///// <param name="fuFlags">fuFlags</param>
        ///// <param name="uTimeout">uTimeout</param>
        ///// <param name="lpdwResult">lpdwResult</param>
        ///// <returns>UIntPtr</returns>
        //[DllImport("user32.dll")]
        //internal static extern IntPtr SendMessageTimeout(IntPtr hWnd,
        //                                        uint Msg,
        //                                        UIntPtr wParam,
        //                                        string lParam,
        //                                        SendMessageTimeoutFlags fuFlags,
        //                                        uint uTimeout,
        //                                        out UIntPtr lpdwResult);


        /// <summary>
        /// PostMessage
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="message">Message</param>
        /// <param name="wparam">wparam</param>
        /// <param name="lparam">lparam</param>
        /// <returns>Int</returns>
        [DllImport("user32.dll")]
        internal static extern int PostMessage(IntPtr window, int message, int wparam, int lparam);

        /// <summary>
        /// GetWindowText
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="text">Text</param>
        /// <param name="copyCount">Copy Count</param>
        /// <returns>Int</returns>
        [DllImport("user32.dll")]
        internal static extern int GetWindowText(
            IntPtr window,
            [In][Out] StringBuilder text,
            int copyCount);

        /// <summary>
        /// SetWindowText
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="text">Text</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool SetWindowText(
            IntPtr window,
            [MarshalAs(UnmanagedType.LPTStr)]
            string text);

        /// <summary>
        /// SetWindowLong
        /// </summary>
        /// <param name="window">Window Pointer</param>
        /// <param name="index">Index</param>
        /// <param name="value">Value</param>
        /// <returns>Int</returns>
        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(
            IntPtr window,
            int index,
            int value);
    
        /// <summary>
        /// EnumChildWindows
        /// </summary>
        /// <param name="window">Window Pointer</param>
        /// <param name="callback">callback</param>
        /// <param name="i">int</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr window, EnumWindowsProc callback, int i);

        /// <summary>
        /// EnumThreadWindows
        /// </summary>
        /// <param name="threadId">Thread Id</param>
        /// <param name="callback">callback</param>
        /// <param name="lParam">int</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool EnumThreadWindows(int threadId, EnumWindowsProc callback, int lParam);

        /// <summary>
        /// EnumWindows
        /// </summary>
        /// <param name="callback">callback</param>
        /// <param name="i">int</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool EnumWindows(EnumWindowsProc callback, int i);

        /// <summary>
        /// GetWindowThreadProcessId
        /// </summary>
        /// <param name="window">Window Pointer</param>
        /// <param name="ptr">pointer</param>
        /// <returns>int</returns>
        [DllImport("user32.dll")]
        internal static extern int GetWindowThreadProcessId(IntPtr window, IntPtr ptr);

        /// <summary>
        /// GetWindowPlacement
        /// </summary>
        /// <param name="window">Window Pointer</param>
        /// <param name="position">position</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool GetWindowPlacement(IntPtr window, ref WindowPlacement position);

        /// <summary>
        /// GetCurrentObject
        /// </summary>
        /// <param name="hdc">hdc</param>
        /// <param name="objectType">object type</param>
        /// <returns>IntPtr</returns>
        [DllImport("gdi32")]
        internal static extern IntPtr GetCurrentObject(IntPtr hdc, ushort objectType);

        /// <summary>
        /// FindWindow
        /// </summary>
        /// <param name="lpclassname">lpClassName</param>
        /// <param name="lpwindowname">lpWindowName</param>
        /// <returns>IntPtr</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr FindWindow(
            [MarshalAs(UnmanagedType.LPTStr)] string lpclassname,
            [MarshalAs(UnmanagedType.LPTStr)] string lpwindowname);

        /// <summary>
        /// GetWindowRect
        /// </summary>
        /// <param name="hwnd">Hwnd</param>
        /// <param name="rectangle">rectangle</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
    
        /// <summary>
        /// GetClientRect
        /// </summary>
        /// <param name="hwnd">Hwnd</param>
        /// <param name="rectangle">rectangle</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hwnd, ref Rect rectangle);
    
        /// <summary>
        /// Get Window Info
        /// </summary>
        /// <param name="hwnd">Hwnd</param>
        /// <param name="info">WindowInfo</param>
        /// <returns>bool</returns>
        [DllImport("user32.dll")]
        internal static extern bool GetWindowInfo(IntPtr hwnd, ref WindowInfo info);
        #endregion

        #region Structs
        /// <summary>
        /// Like the Win32 rect type. Can't use Rectangle because it uses
        /// a different format...
        /// </summary>
        public struct Rect
        {
            /// <summary>
            /// Left
            /// </summary>
            public int left;

            /// <summary>
            /// Top
            /// </summary>
            public int top;

            /// <summary>
            /// Right
            /// </summary>
            public int right;

            /// <summary>
            /// Bottom
            /// </summary>
            public int bottom;

            /// <summary>
            /// Width
            /// </summary>
            public int Width
            {
                get
                {
                    return this.right - this.left;
                }
            }

            /// <summary>
            /// Height
            /// </summary>
            public int Height
            {
                get
                {
                    return this.bottom - this.top;
                }
            }
        }

        /// <summary>
        /// Window Placement Struct.
        /// </summary>
        public struct WindowPlacement
        {
            /// <summary>
            /// Length
            /// </summary>
            public int length;

            /// <summary>
            /// Flags
            /// </summary>
            public int flags;

            /// <summary>
            /// ShowCmd
            /// </summary>
            public int showCmd;

            /// <summary>
            /// minPosition
            /// </summary>
            public Point minPosition;

            /// <summary>
            /// maxPosition
            /// </summary>
            public Point maxPosition;

            /// <summary>
            /// normalPosition
            /// </summary>
            public Rectangle normalPosition;
        }

        /// <summary>
        /// Window Info
        /// </summary>
        public struct WindowInfo
        {
            /// <summary>
            /// Size
            /// </summary>
            public int size;

            /// <summary>
            /// Window
            /// </summary>
            public Rectangle window;

            /// <summary>
            /// client
            /// </summary>
            public Rectangle client;

            /// <summary>
            /// Style
            /// </summary>
            public int style;

            /// <summary>
            /// exStyle
            /// </summary>
            public int exStyle;

            /// <summary>
            /// windowStatus
            /// </summary>
            public int windowStatus;

            /// <summary>
            /// xWindowBorders
            /// </summary>
            public uint xWindowBorders;

            /// <summary>
            /// yWindowBorders
            /// </summary>
            public uint yWindowBorders;

            /// <summary>
            /// atomWindowType
            /// </summary>
            public short atomWindowtype;

            /// <summary>
            /// Creator Version
            /// </summary>
            public short creatorVersion;
        }
        #endregion
    }
}
