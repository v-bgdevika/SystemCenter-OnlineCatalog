//-------------------------------------------------------------------
// <copyright file="Win32Window.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains utility classes for the MOMX UI automated tests
// </summary>
// 
// <history>
// [mbickle] 01JAN05:  Created
// </history>
// <remarks>
// TODO: Need to decide if this is necesary to keep.
//       If we keep, then it needs to be cleaned up for FxCop/StyleCop
//       If we don't need it then it needs to go away.
// </remarks>
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

    #region Win32Window Class
    /// <summary>
    /// Encapsulates window functions that aren't in the framework.
    /// NOTE: This class is not thread-safe. 
    /// </summary>
    public class Win32Window
    {
        #region Private Data Members
        /// <summary>
        /// SRCCOPY
        /// </summary>
        private const int SRCCOPY = 0x00CC0020;  // dest = source 

        /// <summary>
        /// topLevelWindows
        /// </summary>
        private static ArrayList topLevelWindows;

        /// <summary>
        /// window
        /// </summary>
        private IntPtr window;

        /// <summary>
        /// windowList
        /// </summary>
        private ArrayList windowList;

        #endregion

        #region Consts
        //const int GWL_EXSTYLE = -20;
        //const int WS_EX_TOOLWINDOW = 0x00000080;
        //const int WS_EX_APPWINDOW = 0x00040000;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Create a Win32Window
        /// </summary>
        /// <param name="window">The window handle</param>
        public Win32Window(IntPtr window)
        {
            this.window = window;
        }
        #endregion

        #region Static Public Properties
        
        /// <summary>
        /// All top level windows 
        /// </summary>
        public static ArrayList TopLevelWindows
        {
            get
            {
                topLevelWindows = new ArrayList();
                NativeMethods.EnumWindows(new NativeMethods.EnumWindowsProc(EnumerateTopLevelProc), 0);
                ArrayList top = topLevelWindows;
                topLevelWindows = null;
                return top;
            }
        }

        /// <summary>
        /// The deskop window
        /// </summary>
        public static Win32Window DesktopWindow
        {
            get
            {
                return new Win32Window(NativeMethods.GetDesktopWindow());
            }
        }

        /// <summary>
        /// The current foreground window
        /// </summary>
        //public static Win32Window ForegroundWindow
        //{
        //    get
        //    {
        //        return new Win32Window(NativeMethods.GetForegroundWindow());
        //    }
        //}
        
        /// <summary>
        /// DesktopAsBitmap
        /// </summary>
        //public static Image DesktopAsBitmap
        //{
        //    get
        //    {
        //        Image image = new Bitmap(
        //            Screen.PrimaryScreen.Bounds.Width,
        //            Screen.PrimaryScreen.Bounds.Height);
                
        //        Graphics gr1 = Graphics.FromImage(image);
        //        IntPtr dc1 = gr1.GetHdc();
        //        IntPtr dc2 = NativeMethods.GetWindowDC(NativeMethods.GetDesktopWindow());
        //        NativeMethods.BitBlt(
        //            dc1,
        //            0, 
        //            0, 
        //            Screen.PrimaryScreen.Bounds.Width,
        //            Screen.PrimaryScreen.Bounds.Height, 
        //            dc2, 
        //            0, 
        //            0, 
        //            SRCCOPY); 
        //        gr1.ReleaseHdc(dc1);
        //        return image;
        //    }
        //}

        #endregion        

        #region Public Properties
        /// <summary>
        /// Rectangle
        /// </summary>
        public NativeMethods.Rect Rectangle
        {
            get
            {
                NativeMethods.Rect windowRect;

                windowRect.top = -1;
                windowRect.bottom = -1;
                windowRect.left = -1;
                windowRect.right = -1;

                NativeMethods.GetWindowRect(this.Window, ref windowRect);

                return windowRect;
            }
        }

        /// <summary>
        /// The placement of this window
        /// </summary>
        public NativeMethods.WindowPlacement WindowPlacement
        {
            get
            {
                NativeMethods.WindowPlacement placement = new NativeMethods.WindowPlacement();
                NativeMethods.GetWindowPlacement(this.window, ref placement);
                return placement;
            }
        }

        /// <summary>
        /// Extract the window handle 
        /// </summary>
        public IntPtr Window
        {
            get
            {
                return this.window;
            }
        }

        /// <summary>
        /// Return true if this window is null
        /// </summary>
        public bool IsNull
        {
            get
            {
                return this.window == IntPtr.Zero;
            }
        }

        /// <summary>
        /// The children of this window, as an ArrayList
        /// </summary>
        public ArrayList Children
        {
            get
            {
                this.windowList = new ArrayList();
                NativeMethods.EnumChildWindows(this.window, new NativeMethods.EnumWindowsProc(this.EnumerateChildProc), 0);
                ArrayList children = this.windowList;
                this.windowList = null;
                return children;
            }
        }

        /// <summary>
        /// Get the parent of this window. Null if this is a top-level window
        /// </summary>
        //public Win32Window Parent
        //{
        //    get
        //    {
        //        return new Win32Window(NativeMethods.GetParent(this.window));
        //    }
        //}

        /// <summary>
        /// Get the last (topmost) active popup
        /// </summary>
        //public Win32Window LastActivePopup
        //{
        //    get
        //    {
        //        IntPtr popup = NativeMethods.GetLastActivePopup(this.window);
        //        if (popup == this.window)
        //        {
        //            return new Win32Window(IntPtr.Zero);
        //        }
        //        else
        //        {
        //            return new Win32Window(popup);
        //        }
        //    }
        //}

        /// <summary>
        /// The text in this window
        /// </summary>
        //public string Text
        //{
        //    get
        //    {
        //        int length = NativeMethods.GetWindowTextLength(this.window);
        //        StringBuilder sb = new StringBuilder(length + 1);
        //        NativeMethods.GetWindowText(this.window, sb, sb.Capacity);
        //        return sb.ToString();
        //    }

        //    set
        //    {
        //        NativeMethods.SetWindowText(this.window, value);
        //    }
        //}

        /// <summary>
        /// ThreadId
        /// </summary>
        public int ThreadId
        {
            get
            {
                return NativeMethods.GetWindowThreadProcessId(this.window, IntPtr.Zero);
            }
        }

        /// <summary>
        /// The id of the process that owns this window
        /// </summary>
        //public int ProcessId
        //{
        //    get
        //    {
        //        int processId = 0;
        //        NativeMethods.GetWindowThreadProcessId(this.window, ref processId);
        //        return processId;
        //    }
        //}

        /// <summary>
        /// Whether the window is minimized
        /// </summary>
        //public int Minimized
        //{
        //    get
        //    {
        //        return NativeMethods.IsIconic(this.window);
        //    }
        //}

        /// <summary>
        /// Whether the window is maximized
        /// </summary>
        //public int Maximized
        //{
        //    get
        //    {
        //        return NativeMethods.IsZoomed(this.window);
        //    }
        //}
        #endregion

        #region Unsafe Code: Public Properties
        /// <summary>
        /// WindowAsBitmap
        /// </summary>
        //public unsafe Image WindowAsBitmap
        //{
        //    get
        //    {
        //        if (this.IsNull)
        //        {
        //            return null;
        //        }

        //        this.SetForegroundWindow();
                
        //        System.Threading.Thread.Sleep(500);

        //        NativeMethods.Rect rect = new NativeMethods.Rect();
        //        if (!NativeMethods.GetWindowRect(this.window, ref rect))
        //        {
        //            return null;
        //        }

        //        NativeMethods.WindowInfo windowInfo = new NativeMethods.WindowInfo();
        //        windowInfo.size = sizeof(NativeMethods.WindowInfo);
        //        if (!NativeMethods.GetWindowInfo(this.window, ref windowInfo))
        //        {
        //            return null;
        //        }

        //        Image image = new Bitmap(rect.Width, rect.Height);
        //        Graphics gr1 = Graphics.FromImage(image);
        //        IntPtr dc1 = gr1.GetHdc();
        //        IntPtr dc2 = NativeMethods.GetWindowDC(this.window);
        //        NativeMethods.BitBlt(dc1, 0, 0, rect.Width, rect.Height, dc2, 0, 0, SRCCOPY); 
        //        gr1.ReleaseHdc(dc1);

        //        return image;
        //    }
        //}

        /// <summary>
        /// WindowClientAsBitmap
        /// </summary>
        //public unsafe Image WindowClientAsBitmap
        //{
        //    get
        //    {
        //        if (this.IsNull)
        //        {
        //            return null;
        //        }

        //        this.SetForegroundWindow();
        //        System.Threading.Thread.Sleep(500);

        //        NativeMethods.Rect rect = new NativeMethods.Rect();
        //        if (!NativeMethods.GetClientRect(this.window, ref rect))
        //        {
        //            return null;
        //        }

        //        NativeMethods.WindowInfo windowInfo = new NativeMethods.WindowInfo();
        //        windowInfo.size = sizeof(NativeMethods.WindowInfo);
        //        if (!NativeMethods.GetWindowInfo(this.window, ref windowInfo))
        //        {
        //            return null;
        //        }

        //        int xcoordOffset = windowInfo.client.X - windowInfo.window.X;
        //        int ycoordOffset = windowInfo.client.Y - windowInfo.window.Y;

        //        Image image = new Bitmap(rect.Width, rect.Height);
        //        Graphics gr1 = Graphics.FromImage(image);
        //        IntPtr dc1 = gr1.GetHdc();
        //        IntPtr dc2 = NativeMethods.GetWindowDC(this.window);
        //        NativeMethods.BitBlt(dc1, 0, 0, rect.Width, rect.Height, dc2, xcoordOffset, ycoordOffset, SRCCOPY); 
        //        gr1.ReleaseHdc(dc1);
        //        return image;
        //    }
        //}

        #endregion

        #region Static Public Methods
        /// <summary>
        /// EnumerateTopLevelProc
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="i">int</param>
        /// <returns>bool</returns>
        public static bool EnumerateTopLevelProc(IntPtr window, int i)
        {
            topLevelWindows.Add(new Win32Window(window));
            return true;
        }

        /// <summary>
        /// Return all windows of a given thread
        /// </summary>
        /// <param name="threadId">The thread id</param>
        /// <returns>ArrayList</returns>
        public static ArrayList GetThreadWindows(int threadId)
        {
            topLevelWindows = new ArrayList();
            NativeMethods.EnumThreadWindows(threadId, new NativeMethods.EnumWindowsProc(EnumerateThreadProc), 0);
            ArrayList windows = topLevelWindows;
            topLevelWindows = null;
            return windows;
        }

        /// <summary>
        /// EnumerateThreadProc
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="i">int</param>
        /// <returns>bool</returns>
        public static bool EnumerateThreadProc(IntPtr window, int i)
        {
            topLevelWindows.Add(new Win32Window(window));
            return true;
        }

        /// <summary>
        /// Find a window by name or class
        /// </summary>
        /// <param name="className">Name of the class, or null</param>
        /// <param name="windowName">Name of the window, or null</param>
        /// <returns>Win32Window</returns>
        public static Win32Window FindWindow(string className, string windowName)
        {
            return new Win32Window(NativeMethods.FindWindowWin32(className, windowName));
        }
        
        /// <summary>
        /// Tests whether one window is a child of another
        /// </summary>
        /// <param name="parent">Parent window</param>
        /// <param name="window">Window to test</param>
        /// <returns>int</returns>
        //public static int IsChild(Win32Window parent, Win32Window window)
        //{
        //    return NativeMethods.IsChild(parent.window, window.window);
        //}
        #endregion

        #region Unsafe Public Methods
        /// <summary>
        /// GetDesktopRectAsBitmap
        /// </summary>
        /// <param name="captureArea">Capture Area</param>
        /// <returns>Image</returns>
        //public unsafe static Image GetDesktopRectAsBitmap(NativeMethods.Rect captureArea)
        //{
        //    Image desktopImage = Win32Window.DesktopAsBitmap;
        //    Bitmap bmp = new Bitmap(captureArea.Width, captureArea.Height);

        //    Graphics g = Graphics.FromImage(bmp);
        //    g.DrawImage(
        //        desktopImage,
        //        new Rectangle(0, 0, 10, 10),
        //        captureArea.left,
        //        captureArea.top,
        //        captureArea.Width,
        //        captureArea.Height,
        //        GraphicsUnit.Pixel);

        //    return bmp;
        //}
        #endregion

        #region Public Methods
        /// <summary>
        /// EnumerateChildPRoc
        /// </summary>
        /// <param name="windowPointer">window</param>
        /// <param name="i">int</param>
        /// <returns>bool</returns>
        public bool EnumerateChildProc(IntPtr windowPointer, int i)
        {
            this.windowList.Add(new Win32Window(windowPointer));
            return true;
        }

        /// <summary>
        /// Bring a window to the top
        /// </summary>
        public void BringWindowToTop()
        {
            NativeMethods.BringWindowToTop(this.window);
        }

        /// <summary>
        /// SetForegroundWindow
        /// </summary>
        /// <returns>bool</returns>
        //public IntPtr SetForegroundWindow()
        //{
        //    return NativeMethods.SetForegroundWindow(this.window);
        //}

        /// <summary>
        /// Find a child of this window
        /// </summary>
        /// <param name="className">Name of the class, or null</param>
        /// <param name="windowName">Name of the window, or null</param>
        /// <returns>Win32Window</returns>
        public Win32Window FindChild(string className, string windowName)
        {
            return new Win32Window(
                NativeMethods.FindWindowEx(this.window, IntPtr.Zero, className, windowName));
        }
        
        /// <summary>
        /// Send a windows message to this window
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="wparam">wparam</param>
        /// <param name="lparam">lparam</param>
        /// <returns>int</returns>
        public int SendMessage(int message, int wparam, int lparam)
        {
            return NativeMethods.SendMessage(this.window, message, wparam, lparam);
        }

        /// <summary>
        /// Post a windows message to this window
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="wparam">wparam</param>
        /// <param name="lparam">lparam</param>
        /// <returns>int</returns>
        public int PostMessage(int message, int wparam, int lparam)
        {
            return NativeMethods.PostMessage(this.window, message, wparam, lparam);
        }

        /// <summary>
        /// Get a long value for this window. See GetWindowLong()
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>int</returns>
        //public int GetWindowLong(int index)
        //{
        //    return NativeMethods.GetWindowLong(this.window, index);
        //}

        /// <summary>
        /// Set a long value for this window. See SetWindowLong()
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="value">value</param>
        /// <returns>int</returns>
        public int SetWindowLong(int index, int value)
        {
            return NativeMethods.SetWindowLong(this.window, index, value);
        }

        /// <summary>
        /// The id of the thread that owns this window
        /// </summary>
        //public void MakeToolWindow()
        //{
        //    int windowStyle = this.GetWindowLong(NativeMethods.GWL_EXSTYLE);
        //    this.SetWindowLong(NativeMethods.GWL_EXSTYLE, windowStyle | NativeMethods.WS_EX_TOOLWINDOW);
        //}

        #endregion
    }
    #endregion
}
