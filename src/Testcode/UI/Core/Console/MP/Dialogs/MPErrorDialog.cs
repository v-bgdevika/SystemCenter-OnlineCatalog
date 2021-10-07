// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MPErrorDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 10/18/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IMPErrorDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMPErrorDialogControls, for MPErrorDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 10/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMPErrorDialogControls
    {
        /// <summary>
        /// Read-only property to access MissingDependentManagementPacksStaticControl
        /// </summary>
        StaticControl MissingDependentManagementPacksStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MissingDependentManagementPacksPropertyGridView
        /// </summary>
        PropertyGridView MissingDependentManagementPacksPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
        /// </summary>
        StaticControl OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorManagementPackCannotBeImportedStaticControl
        /// </summary>
        StaticControl ErrorManagementPackCannotBeImportedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 10/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MPErrorDialog : Dialog, IMPErrorDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MissingDependentManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMissingDependentManagementPacksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MissingDependentManagementPacksPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedMissingDependentManagementPacksPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe of type StaticControl
        /// </summary>
        private StaticControl cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe;
        
        /// <summary>
        /// Cache to hold a reference to ErrorManagementPackCannotBeImportedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorManagementPackCannotBeImportedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MPErrorDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MPErrorDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IMPErrorDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMPErrorDialogControls Controls
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
        ///  Exposes access to the MissingDependentManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPErrorDialogControls.MissingDependentManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedMissingDependentManagementPacksStaticControl == null))
                {
                    this.cachedMissingDependentManagementPacksStaticControl = new StaticControl(this, MPErrorDialog.ControlIDs.MissingDependentManagementPacksStaticControl);
                }
                return this.cachedMissingDependentManagementPacksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MissingDependentManagementPacksPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IMPErrorDialogControls.MissingDependentManagementPacksPropertyGridView
        {
            get
            {
                if ((this.cachedMissingDependentManagementPacksPropertyGridView == null))
                {
                    this.cachedMissingDependentManagementPacksPropertyGridView = new PropertyGridView(this, MPErrorDialog.ControlIDs.MissingDependentManagementPacksPropertyGridView);
                }
                return this.cachedMissingDependentManagementPacksPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPErrorDialogControls.OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
        {
            get
            {
                if ((this.cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe == null))
                {
                    this.cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe = new StaticControl(this, MPErrorDialog.ControlIDs.OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe);
                }
                return this.cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorManagementPackCannotBeImportedStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPErrorDialogControls.ErrorManagementPackCannotBeImportedStaticControl
        {
            get
            {
                if ((this.cachedErrorManagementPackCannotBeImportedStaticControl == null))
                {
                    this.cachedErrorManagementPackCannotBeImportedStaticControl = new StaticControl(this, MPErrorDialog.ControlIDs.ErrorManagementPackCannotBeImportedStaticControl);
                }
                return this.cachedErrorManagementPackCannotBeImportedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPErrorDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MPErrorDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPErrorDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, MPErrorDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException windowNotFound)
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
                                StringMatchSyntax.WildCard
                                );

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt" + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title: '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw windowNotFound;
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
        /// 	[zhihaoq] 10/18/2008 Created
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
            /// <history>
            ///  [sunsingh] 1/27/2009 Updated ResourceDialogTitle to correct resource string
            /// </history>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Import Management Pack Error;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPErrorDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MissingDependentManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMissingDependentManagementPacks = ";&Missing dependent management packs : ;ManagedString;Microsoft.EnterpriseManagem" +
                "ent.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Adminis" +
                "tration.MPDownloadAndInstall.Dialogs.MPErrorDialog;missingMPListLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe = "Office SharePoint Portal Server 2003 cannot be imported because dependent managem" +
                "ent packs are missing. To remove the management pack from the Import list, click" +
                " Remove.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorManagementPackCannotBeImported
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorManagementPackCannotBeImported = ";Error : Management pack cannot be imported;ManagedString;Microsoft.EnterpriseMan" +
                "agement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Adm" +
                "inistration.MPDownloadAndInstall.Dialogs.MPErrorDialog;titleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";&Remove;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagrammi" +
                "ng.CommandResources.Properties.Resources;Command_Remove";
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
            /// Caches the translated resource string for:  MissingDependentManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMissingDependentManagementPacks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorManagementPackCannotBeImported
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorManagementPackCannotBeImported;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the MissingDependentManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MissingDependentManagementPacks
            {
                get
                {
                    if ((cachedMissingDependentManagementPacks == null))
                    {
                        cachedMissingDependentManagementPacks = CoreManager.MomConsole.GetIntlStr(ResourceMissingDependentManagementPacks);
                    }
                    return cachedMissingDependentManagementPacks;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
            {
                get
                {
                    if ((cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe == null))
                    {
                        cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe = CoreManager.MomConsole.GetIntlStr(ResourceOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe);
                    }
                    return cachedOfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorManagementPackCannotBeImported translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorManagementPackCannotBeImported
            {
                get
                {
                    if ((cachedErrorManagementPackCannotBeImported == null))
                    {
                        cachedErrorManagementPackCannotBeImported = CoreManager.MomConsole.GetIntlStr(ResourceErrorManagementPackCannotBeImported);
                    }
                    return cachedErrorManagementPackCannotBeImported;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    return cachedRemove;
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
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for MissingDependentManagementPacksStaticControl
            /// </summary>
            public const string MissingDependentManagementPacksStaticControl = "missingMPListLabel";
            
            /// <summary>
            /// Control ID for MissingDependentManagementPacksPropertyGridView
            /// </summary>
            public const string MissingDependentManagementPacksPropertyGridView = "missingMPGridView";
            
            /// <summary>
            /// Control ID for OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe
            /// </summary>
            public const string OfficeSharePointPortalServer2003CannotBeImportedBecauseDependentManagementPacksAreMissingToRemoveThe = "infoLabel";
            
            /// <summary>
            /// Control ID for ErrorManagementPackCannotBeImportedStaticControl
            /// </summary>
            public const string ErrorManagementPackCannotBeImportedStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
        }
        #endregion
    }
}
