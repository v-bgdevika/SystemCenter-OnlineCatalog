//-------------------------------------------------------------------
// <copyright file="KeyboardCodes.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
// Keyboard Codes for use with MAUI.Send
// </summary>
//
// <history>
//  [mbickle] 13OCT04 Code Cleanup.  Consolidated the General/Metakeys class 
//                    into just the Keys class.
// </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Basic Keyboard access keys used primarily with SendKeys method.
    /// </summary>
    /// <remarks>
    ///     To specify keys combined with any combination of the SHIFT, CTRL, and 
    ///     ALT keys, precede the key code with one or more of the following codes: 
    ///         Key Code 
    ///         SHIFT + 
    ///         CTRL ^ 
    ///         ALT % 
    ///
    ///     To specify that any combination of SHIFT, CTRL, and ALT should be held down 
    ///     while several other keys are pressed, enclose the code for those keys in 
    ///     parentheses. 
    ///     For example, to specify to hold down SHIFT while E and C are pressed, use 
    ///     "+(EC)".
    ///     To specify to hold down SHIFT while E is pressed, followed by C without 
    ///     SHIFT, use "+EC". 
    ///     
    ///     To specify repeating keys, use the form {key number}. You must put a space 
    ///     between key and number. For example, {LEFT 42} means press the LEFT ARROW
    ///     key 42 times; {h 10} means press H 10 times. 
    /// </remarks>
    /// <history>
    /// </history>
    /// ------------------------------------------------------------------
    public sealed class KeyboardCodes
    {
        #region Keys
        /// <summary>
        /// BACKSPACE Key
        /// </summary>
        public const string Backspace = "{BACKSPACE}";

        /// <summary>
        /// Back key
        /// </summary>
        public const string Back = "{BS}";

        /// <summary>
        /// BACKSPACE Key
        /// </summary>
        public const string Bksp = "{BKSP}";

        /// <summary>
        /// Break Key
        /// </summary>
        public const string Break = "{BREAK}";

        /// <summary>
        /// Capslock Key
        /// </summary>
        public const string CapsLock = "{CAPSLOCK}";

        /// <summary>
        /// Delete Key
        /// </summary>
        public const string Delete = "{DELETE}";

        /// <summary>
        /// Delete Key
        /// </summary>
        public const string Del = "{DEL}";

        /// <summary>
        /// Down Arrow Key
        /// </summary>
        public const string DownArrow = "{DOWN}";

        /// <summary>
        /// End Key
        /// </summary>
        public const string End = "{END}";

        /// <summary>
        /// Enter Key
        /// </summary>
        public const string Enter = "{ENTER}";

        /// <summary>
        /// Tilde Key 
        /// </summary>
        public const string Tilde = "~"; // Enter

        /// <summary>
        /// Esc Key
        /// </summary>
        public const string Esc = "{ESC}";

        /// <summary>
        /// Help Key
        /// </summary>
        public const string Help = "{HELP}";

        /// <summary>
        /// Home Key
        /// </summary>
        public const string Home = "{HOME}";

        /// <summary>
        /// Ins Key
        /// </summary>
        public const string Ins = "{INS}";

        /// <summary>
        /// Insert
        /// </summary>
        public const string Insert = "{INSERT}";

        /// <summary>
        /// Left Arrow
        /// </summary>
        public const string LeftArrow = "{LEFT}";

        /// <summary>
        /// Numlock
        /// </summary>
        public const string NumLock = "{NUMLOCK}";

        /// <summary>
        /// Page Down
        /// </summary>
        public const string PageDown = "{PGDN}";

        /// <summary>
        /// Page Up
        /// </summary>
        public const string PageUp = "{PGUP}";

        /// <summary>
        /// Print Screen
        /// </summary>
        public const string PrintScreen = "{PRTSC}"; //(reserved for future use) 

        /// <summary>
        /// Right Arrow
        /// </summary>
        public const string RightArrow = "{RIGHT}";

        /// <summary>
        /// Scroll Lock
        /// </summary>
        public const string ScrollLock = "{SCROLLLOCK}";

        /// <summary>
        /// Tab
        /// </summary>
        public const string Tab = "{TAB}";

        /// <summary>
        /// Up Arrow
        /// </summary>
        public const string UpArrow = "{UP}";

        /// <summary>
        /// Space
        /// </summary>
        public const string Space = " ";

        /// <summary>
        /// F1
        /// </summary>
        public const string F1 = "{F1}";

        /// <summary>
        /// F2
        /// </summary>
        public const string F2 = "{F2}";

        /// <summary>
        /// F3
        /// </summary>
        public const string F3 = "{F3}";

        /// <summary>
        /// F4
        /// </summary>
        public const string F4 = "{F4}";

        /// <summary>
        /// F5
        /// </summary>
        public const string F5 = "{F5}";

        /// <summary>
        /// F6
        /// </summary>
        public const string F6 = "{F6}";

        /// <summary>
        /// F7
        /// </summary>
        public const string F7 = "{F7}";

        /// <summary>
        /// F8
        /// </summary>
        public const string F8 = "{F8}";

        /// <summary>
        /// F9
        /// </summary>
        public const string F9 = "{F9}";

        /// <summary>
        /// F10
        /// </summary>
        public const string F10 = "{F10}";

        /// <summary>
        /// F11
        /// </summary>
        public const string F11 = "{F11}";

        /// <summary>
        /// F12
        /// </summary>
        public const string F12 = "{F12}";

        /// <summary>
        /// F13
        /// </summary>
        public const string F13 = "{F13}";

        /// <summary>
        /// F14
        /// </summary>
        public const string F14 = "{F14}";

        /// <summary>
        /// F15
        /// </summary>
        public const string F15 = "{F15}";

        /// <summary>
        /// F16
        /// </summary>
        public const string F16 = "{F16}";

        /// <summary>
        /// Windows
        /// </summary>
        public const string Windows = "{WIN}";

        /// <summary>
        /// Context Menu Application Key
        /// </summary>
        public const string ContextMenu = "{APPS}";

        /// <summary>
        /// Control Key
        /// </summary>
        public const string Ctrl = "^";

        /// <summary>
        /// Shift Key
        /// </summary>
        public const string Shift = "+";

        /// <summary>
        /// Alt Key
        /// </summary>
        public const string Alt = "%";
#endregion

        #region Keypad
        /// <summary>
        /// Add
        /// </summary>
        public const string Add = "{ADD}";

        /// <summary>
        /// Subtract
        /// </summary>
        public const string Subtract = "{SUBTRACT}";

        /// <summary>
        /// Multiply
        /// </summary>
        public const string Multiply = "{MULTIPLY}";

        /// <summary>
        /// Divide
        /// </summary>
        public const string Divide = "{DIVIDE}";
#endregion

        #region Shortcuts
        /// <summary>
        /// Help F1
        /// </summary>
        public const string HelpF1 = F1;

        /// <summary>
        /// Copy Ctrl+C
        /// </summary>
        public const string Copy = Ctrl + "C";

        /// <summary>
        /// Cut Ctrl+X
        /// </summary>
        public const string Cut = Ctrl + "X";

        /// <summary>
        /// Paste Ctrl+V
        /// </summary>
        public const string Paste = Ctrl + "V";

        /// <summary>
        /// Select All Ctrl+A
        /// </summary>
        public const string SelectAll = Ctrl + "A";
        
        /// <summary>
        /// CloseWindow ALT+F4
        /// </summary>
        public const string CloseWindow = Alt + F4;

        /// <summary>
        /// Bring up Context Menu via Shift+F10
        /// </summary>
        public const string ShiftF10 = Shift + F10;

        /// <summary>
        /// OpsConsole Refresh Ctrl+F5
        /// </summary>
        public const string ConsoleRefresh = Ctrl + F5;

        /// <summary>
        /// Ctrl+Tab
        /// </summary>
        public const string ChangeTab = Ctrl + Tab;

        /// <summary>
        /// Alt+Space
        /// </summary>
        public const string ControlMenuAccess = Alt + Space;

        /// <summary>
        /// Shift+Tab
        /// </summary>
        public const string ShiftTab = Shift + Tab;

        /// <summary>
        /// Win + D
        /// </summary>
        public const string WinD = Windows + "D";

#endregion

        #region Constructor
        /// <summary>
        /// KeyboardCodes
        /// </summary>
        private KeyboardCodes()
        {
        }
        #endregion

        #region "Public Methods"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns a repeat of a key n times.
        /// </summary>
        /// <param name="key">Key to repeat</param>
        /// <param name="times">Number of times to repeat</param>
        /// <returns>String</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public static string Repeat(string key, int times)
        {
            if (key.StartsWith("{"))
            {
                return key.Insert(key.Length - 1, " " + times.ToString());
            }
            else
            {
                return String.Format("{{0} {1}}", times, key);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Concatinates two strings.
        /// </summary>
        /// <param name="powerKey">Power Key</param>
        /// <param name="key">Key</param>
        /// <returns>String</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public static string PowerKeys(string powerKey, string key)
        {
            return String.Format("{0}{1}", powerKey, key);
        }
#endregion
    }
}
