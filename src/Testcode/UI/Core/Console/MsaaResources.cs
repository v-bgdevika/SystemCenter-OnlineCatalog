//-------------------------------------------------------------------
// <copyright file="MsaaReousrces.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Resources Strings for a bunch of Accessiblity Names.
// </summary>
// 
//  <history>
//  [mbickle] 10JAN07:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    #endregion

    /// <summary>
    /// MSAA Resources
    /// </summary>
    public class MsaaResources
    {
        #region Strings Class
        /// <summary>
        /// Strings Class for all the different ActiveAccessiblity Names
        /// </summary>
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains resource string for:  TopLeftHeaderCell
            /// </summary>
            private const string ResourceTopLeftHeaderCell = ";Top Left Header Cell;ManagedString;System.Windows.Forms.dll;System.Windows.Forms;DataGridView_AccTopLeftColumnHeaderCellName";

            /// <summary>
            /// Contains resource string for:  OffScreen
            /// </summary>
            private const string ResourceOffscreen = ";Offscreen;Win32String;oleaccrc.dll;1017";

            /// <summary>
            /// Contains resrouce string for: Expanded
            /// </summary>
            private const string ResourceExpanded = ";expanded;Win32String;oleaccrc.dll;1010";
            
            /// <summary>
            /// Contains resrouce string for: Collapsed
            /// </summary>
            private const string ResourceCollapsed = ";collapsed;Win32String;oleaccrc.dll;1011";

            /// <summary>
            /// Contains resource string for:  Invisible
            /// </summary>
            private const string ResourceInvisible = ";invisible;Win32String;oleaccrc.dll;1016";

            /// <summary>
            /// Contains resource string for:  Selectable
            /// </summary>
            private const string ResourceSelectable = ";Selectable;Win32String;oleaccrc.dll;1022";

            /// <summary>
            /// Contains resource string for:  Horizontal
            /// </summary>
            private const string ResourceHorizontalName = ";Horizontal;Win32String;oleaccrc.dll;186";

            /// <summary>
            /// Contains resource string for:  PageLeft
            /// </summary>
            private const string ResourcePageLeftName = ";Page left;Win32String;oleaccrc.dll;188";

            /// <summary>
            /// Contains resource string for:  PageRight
            /// </summary>
            private const string ResourcePageRightName = ";Page right;Win32String;oleaccrc.dll;190";

            /// <summary>
            /// Contains resource string for:  PageUp
            /// </summary>
            private const string ResourcePageUpName = ";Page up;Win32String;oleaccrc.dll;182";

            /// <summary>
            /// Contains resource string for:  PageDown
            /// </summary>
            private const string ResourcePageDownName = ";Page down;Win32String;oleaccrc.dll;184";

            /// <summary>
            /// Contains resource string for:  Vertical
            /// </summary>
            private const string ResourceVerticalName = ";Vertical;Win32String;oleaccrc.dll;180";

            /// <summary>
            /// Contains resource string for:  ColumnLeft
            /// </summary>
            private const string ResourceColumnLeftName = ";Column left;Win32String;oleaccrc.dll;187";

            /// <summary>
            /// Contains resource string for:  ColumnRight
            /// </summary>
            private const string ResourceColumnRightName = ";Column right;Win32String;oleaccrc.dll;191";

            /// <summary>
            /// Contains resource string for:  LineUp
            /// </summary>
            private const string ResourceLineUpName = ";Line up;Win32String;oleaccrc.dll;181";

            /// <summary>
            /// Contains resource string for:  LineDown
            /// </summary>
            private const string ResourceLineDownName = ";Line down;Win32String;oleaccrc.dll;185";

            /// <summary>
            /// Contains resource string for: Horizontal Scroll Bar
            /// </summary>
            private const string ResourceHorizontalScrollBar = ";Horizontal Scroll Bar;ManagedString;System.Windows.Forms.dll;System.Windows.Forms;DataGridView_AccHorizontalScrollBarAccName";

            /// <summary>
            /// Contains resource string for: Vertical Scroll Bar
            /// </summary>
            private const string ResourceVerticalScrollBar = ";Vertical Scroll Bar;ManagedString;System.Windows.Forms.dll;System.Windows.Forms;DataGridView_AccVerticalScrollBarAccName";

            #endregion

            #region Member Variables
            /// <summary>
            /// cachedTopLeftHeaderCell
            /// </summary>
            private static string cachedTopLeftHeaderCell;

            /// <summary>
            /// cachedOffscreen
            /// </summary>
            private static string cachedOffscreen;

            /// <summary>
            /// cachedCollapsed
            /// </summary>
            private static string cachedCollapsed;

            /// <summary>
            /// cachedExpanded
            /// </summary>
            private static string cachedExpanded;

            /// <summary>
            /// cachedInvisible
            /// </summary>
            private static string cachedInvisible;

            /// <summary>
            /// cachedSelectable
            /// </summary>
            private static string cachedSelectable;

            /// <summary>
            /// cachedHorizontalName
            /// </summary>
            private static string cachedHorizontalName;

            /// <summary>
            /// cachedPageLeftName
            /// </summary>
            private static string cachedPageLeftName;

            /// <summary>
            /// cachedPageRightName
            /// </summary>
            private static string cachedPageRightName;

            /// <summary>
            /// cachedPageUpName
            /// </summary>
            private static string cachedPageUpName;

            /// <summary>
            /// cachedPageDownName
            /// </summary>
            private static string cachedPageDownName;

            /// <summary>
            /// cachedVerticalName
            /// </summary>
            private static string cachedVerticalName;

            /// <summary>
            /// cachedColumnLeftName
            /// </summary>
            private static string cachedColumnLeftName;

            /// <summary>
            /// cachedColumnRightName
            /// </summary>
            private static string cachedColumnRightName;

            /// <summary>
            /// cachedLineUpName
            /// </summary>
            private static string cachedLineUpName;

            /// <summary>
            /// cachedLineDownName
            /// </summary>
            private static string cachedLineDownName;

            /// <summary>
            /// cachedHorizontalScrollBar
            /// </summary>
            private static string cachedHorizontalScrollBar;

            /// <summary>
            /// cachedVerticalScrollBar
            /// </summary>
            private static string cachedVerticalScrollBar;

            #endregion

            #region Properties
            /// --------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TopLeftHeaderCell translated resource string
            /// </summary>
            /// <history>
            ///	[mbickle] 23NOV05 Created
            /// </history>
            /// --------------------------------------------------------------
            public static string TopLeftHeaderCell
            {
                get
                {
                    if ((cachedTopLeftHeaderCell == null))
                    {
                        cachedTopLeftHeaderCell = CoreManager.MomConsole.GetIntlStr(ResourceTopLeftHeaderCell);
                    }

                    return cachedTopLeftHeaderCell;
                }
            }

            /// <summary>
            /// Offscreen STate
            /// </summary>
            public static string Offscreen
            {
                get
                {
                    if (cachedOffscreen == null)
                    {
                        cachedOffscreen = CoreManager.MomConsole.GetIntlStr(ResourceOffscreen);
                    }

                    return cachedOffscreen;
                }
            }

            /// <summary>
            /// Collapsed State
            /// </summary>
            public static string Collapsed
            {
                get
                {
                    if (cachedCollapsed == null)
                    {
                        cachedCollapsed = CoreManager.MomConsole.GetIntlStr(ResourceCollapsed);
                    }

                    return cachedCollapsed;
                }
            }

            /// <summary>
            /// Expanded State
            /// </summary>
            public static string Expanded
            {
                get
                {
                    if (cachedExpanded == null)
                    {
                        cachedExpanded = CoreManager.MomConsole.GetIntlStr(ResourceExpanded);
                    }

                    return cachedExpanded;
                }
            }

            /// <summary>
            /// Invisible State
            /// </summary>
            public static string Invisible
            {
                get
                {
                    if (cachedInvisible == null)
                    {
                        cachedInvisible = CoreManager.MomConsole.GetIntlStr(ResourceInvisible);
                    }

                    return cachedInvisible;
                }
            }

            /// <summary>
            /// Selectable
            /// </summary>
            public static string Selectable
            {
                get
                {
                    if (cachedSelectable == null)
                    {
                        cachedSelectable = CoreManager.MomConsole.GetIntlStr(ResourceSelectable);
                    }

                    return cachedSelectable;
                }
            }

            /// <summary>
            /// Horizontal
            /// </summary>
            public static string HorizontalName
            {
                get
                {
                    if (cachedHorizontalName == null)
                    {
                        cachedHorizontalName = CoreManager.MomConsole.GetIntlStr(ResourceHorizontalName);
                    }

                    return cachedHorizontalName;
                }
            }

            /// <summary>
            /// Page Left
            /// </summary>
            public static string PageLeftName
            {
                get
                {
                    if (cachedPageLeftName == null)
                    {
                        cachedPageLeftName = CoreManager.MomConsole.GetIntlStr(ResourcePageLeftName);
                    }

                    return cachedPageLeftName;
                }
            }

            /// <summary>
            /// Page Right
            /// </summary>
            public static string PageRightName
            {
                get
                {
                    if (cachedPageRightName == null)
                    {
                        cachedPageRightName = CoreManager.MomConsole.GetIntlStr(ResourcePageRightName);
                    }

                    return cachedPageRightName;
                }
            }

            /// <summary>
            /// Page Up
            /// </summary>
            public static string PageUpName
            {
                get
                {
                    if (cachedPageUpName == null)
                    {
                        cachedPageUpName = CoreManager.MomConsole.GetIntlStr(ResourcePageUpName);
                    }

                    return cachedPageUpName;
                }
            }

            /// <summary>
            /// Page Down
            /// </summary>
            public static string PageDownName
            {
                get
                {
                    if (cachedPageDownName == null)
                    {
                        cachedPageDownName = CoreManager.MomConsole.GetIntlStr(ResourcePageDownName);
                    }

                    return cachedPageDownName;
                }
            }

            /// <summary>
            /// Vertical 
            /// </summary>
            public static string VerticalName
            {
                get
                {
                    if (cachedVerticalName == null)
                    {
                        cachedVerticalName = CoreManager.MomConsole.GetIntlStr(ResourceVerticalName);
                    }

                    return cachedVerticalName;
                }
            }

            /// <summary>
            /// Column Left
            /// </summary>
            public static string ColumnLeftName
            {
                get
                {
                    if (cachedColumnLeftName == null)
                    {
                        cachedColumnLeftName = CoreManager.MomConsole.GetIntlStr(ResourceColumnLeftName);
                    }

                    return cachedColumnLeftName;
                }
            }

            /// <summary>
            /// Column Right
            /// </summary>
            public static string ColumnRightName
            {
                get
                {
                    if (cachedColumnRightName == null)
                    {
                        cachedColumnRightName = CoreManager.MomConsole.GetIntlStr(ResourceColumnRightName);
                    }

                    return cachedColumnRightName;
                }
            }

            /// <summary>
            /// Line Up
            /// </summary>
            public static string LineUpName
            {
                get
                {
                    if (cachedLineUpName == null)
                    {
                        cachedLineUpName = CoreManager.MomConsole.GetIntlStr(ResourceLineUpName);
                    }

                    return cachedLineUpName;
                }
            }

            /// <summary>
            /// Line Down
            /// </summary>
            public static string LineDownName
            {
                get
                {
                    if (cachedLineDownName == null)
                    {
                        cachedLineDownName = CoreManager.MomConsole.GetIntlStr(ResourceLineDownName);
                    }

                    return cachedLineDownName;
                }
            }

            /// <summary>
            /// Horizontal Scroll Bar
            /// </summary>
            public static string HorizontalScrollBar
            {
                get
                {
                    if (cachedHorizontalScrollBar == null)
                    {
                        cachedHorizontalScrollBar = CoreManager.MomConsole.GetIntlStr(ResourceHorizontalScrollBar);
                    }

                    return cachedHorizontalScrollBar;
                }
            }

            /// <summary>
            /// Vertical Scroll Bar
            /// </summary>
            public static string VerticalScrollBar
            {
                get
                {
                    if (cachedVerticalScrollBar == null)
                    {
                        cachedVerticalScrollBar = CoreManager.MomConsole.GetIntlStr(ResourceVerticalScrollBar);
                    }

                    return cachedVerticalScrollBar;
                }
            }
            #endregion
        }
        #endregion
    }
}
