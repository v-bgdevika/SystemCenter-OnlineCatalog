//-------------------------------------------------------------------
// <copyright file="TasksView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Tasks View
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//   [ruhim]   19July06: Adding resource strings    
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.Tasks
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    /// <summary>
    /// Tasks View
    /// </summary>
    public class TasksView
    {
        /// <summary>
        /// Tasks View
        /// </summary>
        public TasksView()
        {
        }

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Tasks View
        /// </summary>
        /// <history> 	
        ///   [ruhim]  19July06: Created
        ///   [a-joelj] 20FEB09  Added new resource for "Tasks" pivoted view window
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains resource string for: Name Column header under Tasks View        
            /// </summary>
            private const string ResourceNameColumnHeader =
            ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView;NameColumn";

            /// <summary>
            /// Contains resource string for: Tasks View pivote window        
            /// </summary>
            private const string ResourceTasksView =
            ";Tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView;ViewName";
            
            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Column header under Tasks View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tasks View pivote window
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasksView;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name Column header under Tasks View translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19July06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NameColumnHeader
            {
                get
                {
                    if ((cachedNameColumnHeader == null))
                    {
                        cachedNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceNameColumnHeader);
                    }

                    return cachedNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tasks View pivote window translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 18FEB09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TasksView
            {
                get
                {
                    if ((cachedTasksView == null))
                    {
                        cachedTasksView = CoreManager.MomConsole.GetIntlStr(ResourceTasksView);
                    }

                    return cachedTasksView;
                }
            }
                        
            #endregion

        }
        #endregion
    }
}
