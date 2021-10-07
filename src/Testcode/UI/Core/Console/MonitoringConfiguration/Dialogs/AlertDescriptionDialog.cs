// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertDescriptionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 5/16/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertDescriptionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertDescriptionDialogControls, for AlertDescriptionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 5/16/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertDescriptionDialogControls
    {
        /// <summary>
        /// Read-only property to access ValueTextBox
        /// </summary>
        TextBox ValueTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataButton
        /// </summary>
        Button DataButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetButton
        /// </summary>
        Button TargetButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access ValueStaticControl
        /// </summary>
        StaticControl ValueStaticControl
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
    /// 	[dialac] 5/16/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertDescriptionDialog : Dialog, IAlertDescriptionDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ValueTextBox of type TextBox
        /// </summary>
        private TextBox cachedValueTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DataButton of type Button
        /// </summary>
        private Button cachedDataButton;
        
        /// <summary>
        /// Cache to hold a reference to TargetButton of type Button
        /// </summary>
        private Button cachedTargetButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ValueStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedValueStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertDescriptionDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertDescriptionDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertDescriptionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertDescriptionDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Value
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ValueText
        {
            get
            {
                return this.Controls.ValueTextBox.Text;
            }
            
            set
            {
                this.Controls.ValueTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertDescriptionDialogControls.ValueTextBox
        {
            get
            {
                if ((this.cachedValueTextBox == null))
                {
                    this.cachedValueTextBox = new TextBox(this, AlertDescriptionDialog.ControlIDs.ValueTextBox);
                }
                
                return this.cachedValueTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertDescriptionDialogControls.DataButton
        {
            get
            {
                if ((this.cachedDataButton == null))
                {
                    this.cachedDataButton = new Button(this, AlertDescriptionDialog.ControlIDs.DataButton);
                }
                
                return this.cachedDataButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertDescriptionDialogControls.TargetButton
        {
            get
            {
                if ((this.cachedTargetButton == null))
                {
                    this.cachedTargetButton = new Button(this, AlertDescriptionDialog.ControlIDs.TargetButton);
                }
                
                return this.cachedTargetButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertDescriptionDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertDescriptionDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertDescriptionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertDescriptionDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertDescriptionDialogControls.ValueStaticControl
        {
            get
            {
                if ((this.cachedValueStaticControl == null))
                {
                    this.cachedValueStaticControl = new StaticControl(this, AlertDescriptionDialog.ControlIDs.ValueStaticControl);
                }
                
                return this.cachedValueStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Data
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickData()
        {
            this.Controls.DataButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Target
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTarget()
        {
            this.Controls.TargetButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                //tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);

            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
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
        /// 	[dialac] 5/16/2008 Created
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
            //private const string ResourceDialogTitle = "Alert Description";
            private const string ResourceDialogTitle = ";Alert Description;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;BuildAlertDescriptionDialog";
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Data
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceData = ";&Data;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;btnData.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Target
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTarget = ";&Target;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;btnTarget.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceValue = ";&Value:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;lblValue.Tex" +
                "t";
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
            /// Caches the translated resource string for:  Data
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedData;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Target
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValue;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 5/16/2008 Created
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
            /// Exposes access to the Data translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 5/16/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Data
            {
                get
                {
                    if ((cachedData == null))
                    {
                        cachedData = CoreManager.MomConsole.GetIntlStr(ResourceData);
                    }
                    
                    return cachedData;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Target translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 5/16/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Target
            {
                get
                {
                    if ((cachedTarget == null))
                    {
                        cachedTarget = CoreManager.MomConsole.GetIntlStr(ResourceTarget);
                    }
                    
                    return cachedTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 5/16/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 5/16/2008 Created
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
            /// Exposes access to the Value translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 5/16/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Value
            {
                get
                {
                    if ((cachedValue == null))
                    {
                        cachedValue = CoreManager.MomConsole.GetIntlStr(ResourceValue);
                    }
                    
                    return cachedValue;
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
        /// 	[dialac] 5/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ValueTextBox
            /// </summary>
            public const string ValueTextBox = "txtExpressionValue";
            
            /// <summary>
            /// Control ID for DataButton
            /// </summary>
            public const string DataButton = "btnData";
            
            /// <summary>
            /// Control ID for TargetButton
            /// </summary>
            public const string TargetButton = "btnTarget";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "btnAccept";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "btnCancel";
            
            /// <summary>
            /// Control ID for ValueStaticControl
            /// </summary>
            public const string ValueStaticControl = "lblValue";
        }
        #endregion
    }
}
