// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfirmPropertiesSaveDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 14-Aug-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    
    #region Interface Definition - IConfirmPropertiesSaveDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfirmPropertiesSaveDialogControls, for ConfirmPropertiesSaveDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 14-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfirmPropertiesSaveDialogControls
    {
        /// <summary>
        /// Read-only property to access YesButton
        /// </summary>
        Button YesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoButton
        /// </summary>
        Button NoButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WouldYouLikeToSaveYourChangesStaticControl
        /// </summary>
        StaticControl WouldYouLikeToSaveYourChangesStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the User Role Properties's
    /// "Save User Role Changes" screen.
    /// </summary>
    /// <history>
    /// 	[ruhim] 14-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfirmPropertiesSaveDialog : Dialog, IConfirmPropertiesSaveDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to YesButton of type Button
        /// </summary>
        private Button cachedYesButton;
        
        /// <summary>
        /// Cache to hold a reference to NoButton of type Button
        /// </summary>
        private Button cachedNoButton;
        
        /// <summary>
        /// Cache to hold a reference to WouldYouLikeToSaveYourChangesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWouldYouLikeToSaveYourChangesStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfirmPropertiesSaveDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfirmPropertiesSaveDialog(Maui.Core.App app)
            : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IConfirmPropertiesSaveDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfirmPropertiesSaveDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YesButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmPropertiesSaveDialogControls.YesButton
        {
            get
            {
                if ((this.cachedYesButton == null))
                {
                    this.cachedYesButton = new Button(this, ConfirmPropertiesSaveDialog.ControlIDs.YesButton);
                }
                return this.cachedYesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmPropertiesSaveDialogControls.NoButton
        {
            get
            {
                if ((this.cachedNoButton == null))
                {
                    this.cachedNoButton = new Button(this, ConfirmPropertiesSaveDialog.ControlIDs.NoButton);
                }
                return this.cachedNoButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WouldYouLikeToSaveYourChangesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfirmPropertiesSaveDialogControls.WouldYouLikeToSaveYourChangesStaticControl
        {
            get
            {
                if ((this.cachedWouldYouLikeToSaveYourChangesStaticControl == null))
                {
                    this.cachedWouldYouLikeToSaveYourChangesStaticControl = new StaticControl(this, ConfirmPropertiesSaveDialog.ControlIDs.WouldYouLikeToSaveYourChangesStaticControl);
                }
                return this.cachedWouldYouLikeToSaveYourChangesStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Yes
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickYes()
        {
            this.Controls.YesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button No
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNo()
        {
            this.Controls.NoButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";
//"Microsoft Operations Manager";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Yes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceYes = "&Yes";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  No
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceNo = "&No";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WouldYouLikeToSaveYourChanges
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceWouldYouLikeToSaveYourChanges = //"Would you like to save your changes?";
                ";Would you like to save your changes?;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;SaveConfirmation";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Yes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  No
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WouldYouLikeToSaveYourChanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWouldYouLikeToSaveYourChanges;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 14-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Yes translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 14-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Yes
            {
                get
                {
                    if ((cachedYes == null))
                    {
                        cachedYes = CoreManager.MomConsole.GetIntlStr(ResourceYes);
                    }
                    return cachedYes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the No translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 14-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string No
            {
                get
                {
                    if ((cachedNo == null))
                    {
                        cachedNo = CoreManager.MomConsole.GetIntlStr(ResourceNo);
                    }
                    return cachedNo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WouldYouLikeToSaveYourChanges translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 14-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WouldYouLikeToSaveYourChanges
            {
                get
                {
                    if ((cachedWouldYouLikeToSaveYourChanges == null))
                    {
                        cachedWouldYouLikeToSaveYourChanges = CoreManager.MomConsole.GetIntlStr(ResourceWouldYouLikeToSaveYourChanges);
                    }
                    return cachedWouldYouLikeToSaveYourChanges;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 14-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for YesButton
            /// </summary>
            public const int YesButton = 6;
            
            /// <summary>
            /// Control ID for NoButton
            /// </summary>
            public const int NoButton = 7;
            
            /// <summary>
            /// Control ID for WouldYouLikeToSaveYourChangesStaticControl
            /// </summary>
            public const int WouldYouLikeToSaveYourChangesStaticControl = 65535;
        }
        #endregion
    }
}
