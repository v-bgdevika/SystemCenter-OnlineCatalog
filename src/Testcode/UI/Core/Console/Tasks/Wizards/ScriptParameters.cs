// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScriptParameters.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IScriptParametersControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScriptParametersControls, for ScriptParameters.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScriptParametersControls
    {
        /// <summary>
        /// Read-only property to access TargetButton
        /// </summary>
        Button TargetButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitoringTypeTextBox
        /// </summary>
        TextBox MonitoringTypeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParametersStaticControl
        /// </summary>
        StaticControl ParametersStaticControl
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
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ScriptParameters : Dialog, IScriptParametersControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TargetButton of type Button
        /// </summary>
        private Button cachedTargetButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringTypeTextBox of type TextBox
        /// </summary>
        private TextBox cachedMonitoringTypeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParametersStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScriptParameters of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScriptParameters(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IScriptParameters Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScriptParametersControls Controls
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
        ///  Routine to set/get the text in control MonitoringType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MonitoringTypeText
        {
            get
            {
                return this.Controls.MonitoringTypeTextBox.Text;
            }
            
            set
            {
                this.Controls.MonitoringTypeTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptParametersControls.TargetButton
        {
            get
            {
                if ((this.cachedTargetButton == null))
                {
                    this.cachedTargetButton = new Button(this, ScriptParameters.ControlIDs.TargetButton);
                }
                return this.cachedTargetButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptParametersControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScriptParameters.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptParametersControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ScriptParameters.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IScriptParametersControls.MonitoringTypeTextBox
        {
            get
            {
                if ((this.cachedMonitoringTypeTextBox == null))
                {
                    this.cachedMonitoringTypeTextBox = new TextBox(this, ScriptParameters.ControlIDs.MonitoringTypeTextBox);
                }
                return this.cachedMonitoringTypeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptParametersControls.ParametersStaticControl
        {
            get
            {
                if ((this.cachedParametersStaticControl == null))
                {
                    this.cachedParametersStaticControl = new StaticControl(this, ScriptParameters.ControlIDs.ParametersStaticControl);
                }
                return this.cachedParametersStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Target
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTarget()
        {
            this.Controls.TargetButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
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
                                 app.GetIntlStr(Strings.DialogTitle) + "*",
                                 StringMatchSyntax.WildCard,
                                 WindowClassNames.WinForms10Window8,
                                 StringMatchSyntax.WildCard,
                                 app,
                                 Timeout);
                 
                         // wait for the window to report ready
                         UISynchronization.WaitForUIObjectReady(
                             tempWindow,
                             Timeout);
                     }
                     catch (Exceptions.WindowNotFoundException)
                     {
                         //sleep to wait for window search
                         Sleeper.Delay(Timeout);

                         // log the outcome of this attempt
                         Core.Common.Utilities.LogMessage("Attempt "
                             + numberOfTries
                             + " of "
                             + MaxTries
                             + "...");
                     }
                 }
                 
                 // check for success
                 if (tempWindow == null)
                 {
                     // log the failure
                 
                     // throw the existing WindowNotFound exception
                     throw;
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
        /// 	[faizalk] 4/24/2006 Created
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
            private const string ResourceDialogTitle = "Script - ";

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
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParameters = ";&Parameters:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;idL" +
                "abelParameters.Text";
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
            /// Caches the translated resource string for:  Target
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameters;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the Target translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Parameters
            {
                get
                {
                    if ((cachedParameters == null))
                    {
                        cachedParameters = CoreManager.MomConsole.GetIntlStr(ResourceParameters);
                    }
                    return cachedParameters;
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
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TargetButton
            /// </summary>
            public const string TargetButton = "btnTarget";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "btnCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "btnAccept";
            
            /// <summary>
            /// Control ID for MonitoringTypeTextBox
            /// </summary>
            public const string MonitoringTypeTextBox = "txtParametersValue";
            
            /// <summary>
            /// Control ID for ParametersStaticControl
            /// </summary>
            public const string ParametersStaticControl = "lblParameters";
        }
        #endregion
    }
}
