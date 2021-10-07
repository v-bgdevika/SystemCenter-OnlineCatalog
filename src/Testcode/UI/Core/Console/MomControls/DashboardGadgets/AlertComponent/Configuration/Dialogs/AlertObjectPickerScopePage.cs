// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScopePage.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-lileo] 1/6/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.Configuration
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IAlertSingleObjectPickerControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScopePageControls, for ScopePage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 1/6/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertObjectPickerScopePageControls
    {
        /// <summary>
        /// Gets read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FinishButton
        /// </summary>
        Button FinishButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
    ///   [v-lileo] 1/6/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class AlertObjectPickerScopePage : Dialog, IAlertObjectPickerScopePageControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the UpdateInstanceConfigurationDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of UpdateInstanceConfigurationDialog of type App
        /// </param>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertObjectPickerScopePage(App app, int timeout, string DialogTitle) : 
                base(app, Init(app, timeout,DialogTitle))
        {            
        }
        #endregion

        #region IScopePage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertObjectPickerScopePageControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// <summary>
        /// SinglePickerComponent Control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SinglePickerComponent AlertSinglePickerComponent
        {
            get
            {
                return new SinglePickerComponent(this, Constants.DefaultDialogTimeout);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertObjectPickerScopePageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AlertObjectPickerScopePage.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertObjectPickerScopePageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, AlertObjectPickerScopePage.QueryIds.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertObjectPickerScopePageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertObjectPickerScopePage.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <param name="DialogTitle">DialogTitle.</param>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout,string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
		switch(ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), timeout);
                        break;
                    case ProductSkuLevel.Web:
                        tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, DialogTitle)), timeout);
                        break;
                }
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectAGroupOrObjectStaticControl query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAGroupOrObjectStaticControl = ";[UIA]AutomationId=\'SinglePickerComponentTitle\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SinglePickerComponentSelection query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSinglePickerComponentSelection = ";[UIA]AutomationId=\'SinglePickerComponentSelection\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLaunchButton = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ClearButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClearButton = ";[UIA]AutomationId=\'SinglePickerComponentClearButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId=\'WizardNextButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FinishButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinishButton = ";[UIA]AutomationId=\'WizardCloseButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'WizardCancelButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectAGroupOrObjectStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SinglePickerComponentSelection
            {
                get
                {
                    return new QID(ResourceSinglePickerComponentSelection);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectAGroupOrObjectStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectAGroupOrObjectStaticControl
            {
                get
                {
                    return new QID(ResourceSelectAGroupOrObjectStaticControl);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Button resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LaunchButton
            {
                get
                {
                    return new QID(ResourceLaunchButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ClearButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ClearButton
            {
                get
                {
                    return new QID(ResourceClearButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NextButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NextButton
            {
                get
                {
                    return new QID(ResourceNextButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FinishButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FinishButton
            {
                get
                {
                    return new QID(ResourceFinishButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [asttest] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Configuration Properties
            /// </summary>
            public const string DialogTitle = "Configuration Properties";

            /// <summary>
            /// Resource string for Select a group or object :
            /// </summary>
            public const string SelectAGroupOrObject = "Select a group or object :";
            
        }
        #endregion
    }
}
