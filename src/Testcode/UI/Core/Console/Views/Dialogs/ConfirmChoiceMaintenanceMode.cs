// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfirmChoiceMaintenanceMode.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 7/15/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IConfirmChoiceMaintenanceModeControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfirmChoiceMaintenanceModeControls, for ConfirmChoiceMaintenanceMode.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 7/15/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfirmChoiceMaintenanceModeControls
    {
        /// <summary>
        /// Read-only property to access NoButton
        /// </summary>
        Button NoButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YesButton
        /// </summary>
        Button YesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveContainedObjectsCheckBox
        /// </summary>
        CheckBox RemoveContainedObjectsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl
        /// </summary>
        StaticControl AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl
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
    /// 	[lucyra] 7/15/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfirmChoiceMaintenanceMode : Dialog, IConfirmChoiceMaintenanceModeControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 15000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NoButton of type Button
        /// </summary>
        private Button cachedNoButton;
        
        /// <summary>
        /// Cache to hold a reference to YesButton of type Button
        /// </summary>
        private Button cachedYesButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveContainedObjectsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRemoveContainedObjectsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfirmChoiceMaintenanceMode of type App
        /// </param>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfirmChoiceMaintenanceMode(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IConfirmChoiceMaintenanceMode Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfirmChoiceMaintenanceModeControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox RemoveContainedObjects
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RemoveContainedObjects
        {
            get
            {
                return this.Controls.RemoveContainedObjectsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.RemoveContainedObjectsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmChoiceMaintenanceModeControls.NoButton
        {
            get
            {
                if ((this.cachedNoButton == null))
                {
                    this.cachedNoButton = new Button(this, ConfirmChoiceMaintenanceMode.ControlIDs.NoButton);
                }
                return this.cachedNoButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YesButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmChoiceMaintenanceModeControls.YesButton
        {
            get
            {
                if ((this.cachedYesButton == null))
                {
                    this.cachedYesButton = new Button(this, ConfirmChoiceMaintenanceMode.ControlIDs.YesButton);
                }
                return this.cachedYesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveContainedObjectsCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConfirmChoiceMaintenanceModeControls.RemoveContainedObjectsCheckBox
        {
            get
            {
                if ((this.cachedRemoveContainedObjectsCheckBox == null))
                {
                    this.cachedRemoveContainedObjectsCheckBox = new CheckBox(this, ConfirmChoiceMaintenanceMode.ControlIDs.RemoveContainedObjectsCheckBox);
                }
                return this.cachedRemoveContainedObjectsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfirmChoiceMaintenanceModeControls.AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl
        {
            get
            {
                if ((this.cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl == null))
                {
                    this.cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl = new StaticControl(this, ConfirmChoiceMaintenanceMode.ControlIDs.AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl);
                }
                return this.cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button No
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNo()
        {
            this.Controls.NoButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Yes
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickYes()
        {
            this.Controls.YesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RemoveContainedObjects
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemoveContainedObjects()
        {
            this.Controls.RemoveContainedObjectsCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);

                if (tempWindow != null)
                {
                    return tempWindow;
                }

                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + ".");
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
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
            private const string ResourceDialogTitle = ";Maintenance Mode;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MaintenanceModeExitDialog;$this.Text";       
            //;Maintenance Mode;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.SharedResources;MaintenanceMode.Remove.Title
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  No
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNo = ";&No;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement" +
                ".Mom.UI.MaintenanceModeExitDialog;noButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Yes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYes = ";&Yes;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.UI.MaintenanceModeExitDialog;yesButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveContainedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveContainedObjects = ";&Remove contained objects;ManagedString;Microsoft.MOM.UI.Components.dll;Microsof" +
                "t.EnterpriseManagement.Mom.UI.MaintenanceModeExitDialog;containedObjectsCheckbox" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode = ";Are you sure you wish to remove the selected objects from Maintenance Mode?;Mana" +
                "gedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI." +
                "MaintenanceModeExitDialog;captionLabel.Text";
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
            /// Caches the translated resource string for:  No
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Yes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemoveContainedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveContainedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
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
            /// Exposes access to the No translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
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
            /// Exposes access to the Yes translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
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
            /// Exposes access to the RemoveContainedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveContainedObjects
            {
                get
                {
                    if ((cachedRemoveContainedObjects == null))
                    {
                        cachedRemoveContainedObjects = CoreManager.MomConsole.GetIntlStr(ResourceRemoveContainedObjects);
                    }
                    return cachedRemoveContainedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode
            {
                get
                {
                    if ((cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode == null))
                    {
                        cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode = CoreManager.MomConsole.GetIntlStr(ResourceAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode);
                    }
                    return cachedAreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceMode;
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
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NoButton
            /// </summary>
            public const string NoButton = "noButton";
            
            /// <summary>
            /// Control ID for YesButton
            /// </summary>
            public const string YesButton = "yesButton";
            
            /// <summary>
            /// Control ID for RemoveContainedObjectsCheckBox
            /// </summary>
            public const string RemoveContainedObjectsCheckBox = "containedObjectsCheckbox";
            
            /// <summary>
            /// Control ID for AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl
            /// </summary>
            public const string AreYouSureYouWishToRemoveTheSelectedObjectsFromMaintenanceModeStaticControl = "captionLabel";
        }
        #endregion
    }
}
