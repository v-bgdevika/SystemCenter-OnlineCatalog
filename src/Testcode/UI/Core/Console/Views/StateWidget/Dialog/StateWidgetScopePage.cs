// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NewInstanceWizardApp.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-juli] 5/23/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.StateWidget
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console.MomControls;

    #region Interface Definition - IStateWidgetScopePageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IStateWidgetScopePageControls, for NewInstanceWizardApp.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStateWidgetScopePageControls
    {
        /// <summary>
        /// Gets read-only property to access SpecifyTheScopeStaticControl
        /// </summary>
        StaticControl SpecifyTheScopeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MultiPickerComponentAddButtonButton
        /// </summary>
        Button MultiPickerComponentAddButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MultiPickerComponentRemoveButtonButton
        /// </summary>
        Button MultiPickerComponentRemoveButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access GroupsAndObjectsDataGrid
        /// </summary>
        DataGridControl GroupsAndObjectsDataGrid
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AllClassesStaticControl
        /// </summary>
        StaticControl AllClassesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Button
        /// </summary>
        Button Button
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ResetButton
        /// </summary>
        Button ResetButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
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
        
        /// <summary>
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add app.window functionality description here.
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class StateWidgetScopePage : Dialog, IStateWidgetScopePageControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Static Members

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        private static Window activeWindow;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SpecifyTheScopeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheScopeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MultiPickerComponentAddButtonButton of type Button
        /// </summary>
        private Button cachedMultiPickerComponentAddButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to MultiPickerComponentRemoveButtonButton of type Button
        /// </summary>
        private Button cachedMultiPickerComponentRemoveButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to GroupsAndObjectsDataGrid of type DataGrid
        /// </summary>
        private DataGridControl cachedGroupsAndObjectsDataGrid;
        
        /// <summary>
        /// Cache to hold a reference to AllClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAllClassesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button of type Button
        /// </summary>
        private Button cachedButton;
        
        /// <summary>
        /// Cache to hold a reference to ResetButton of type Button
        /// </summary>
        private Button cachedResetButton;
        
        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
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
        
        /// <summary>
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the NewInstanceWizardApp class.
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public StateWidgetScopePage(App app, int timeout, string DialogTitle) :
            base(app, Init(app, timeout, DialogTitle))
        {
          
        }
        #endregion     
        
        #region IStateWidgetScopePageControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this app.window
        /// </summary>
        /// <value>An interface that groups all of the app.window's control properties together</value>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IStateWidgetScopePageControls Controls
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
        ///  Gets access to the SpecifyTheScopeStaticControl control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IStateWidgetScopePageControls.SpecifyTheScopeStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheScopeStaticControl == null))
                {
                    this.cachedSpecifyTheScopeStaticControl = new StaticControl(this, QueryIds.SpecifyTheScopeStaticControl);
                }
                
                return this.cachedSpecifyTheScopeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiPickerComponentAddButtonButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.MultiPickerComponentAddButtonButton
        {
            get
            {
                if ((this.cachedMultiPickerComponentAddButtonButton == null))
                {
                    this.cachedMultiPickerComponentAddButtonButton = new Button(this, QueryIds.MultiPickerComponentAddButtonButton);
                }
                
                return this.cachedMultiPickerComponentAddButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiPickerComponentRemoveButtonButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.MultiPickerComponentRemoveButtonButton
        {
            get
            {
                if ((this.cachedMultiPickerComponentRemoveButtonButton == null))
                {
                    this.cachedMultiPickerComponentRemoveButtonButton = new Button(this, QueryIds.MultiPickerComponentRemoveButtonButton);
                }
                
                return this.cachedMultiPickerComponentRemoveButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupsAndObjectsDataGrid control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridControl IStateWidgetScopePageControls.GroupsAndObjectsDataGrid
        {
            get
            {
                if ((this.cachedGroupsAndObjectsDataGrid == null))
                {
                    this.cachedGroupsAndObjectsDataGrid = new DataGridControl(this, QueryIds.GroupsAndObjectsDataGrid);
                }
                
                return this.cachedGroupsAndObjectsDataGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AllClassesStaticControl control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IStateWidgetScopePageControls.AllClassesStaticControl
        {
            get
            {
                if ((this.cachedAllClassesStaticControl == null))
                {
                    this.cachedAllClassesStaticControl = new StaticControl(this, QueryIds.AllClassesStaticControl);
                }
                
                return this.cachedAllClassesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Button control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.Button
        {
            get
            {
                if ((this.cachedButton == null))
                {
                    this.cachedButton = new Button(this, QueryIds.Button);
                }
                
                return this.cachedButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ResetButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.ResetButton
        {
            get
            {
                if ((this.cachedResetButton == null))
                {
                    this.cachedResetButton = new Button(this, QueryIds.ResetButton);
                }
                
                return this.cachedResetButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, QueryIds.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetScopePageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OrientationPane control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IStateWidgetScopePageControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, QueryIds.OrientationPane);
                }
                
                return this.cachedOrientationPane;
            }
        }
        #endregion        
      
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MultiPickerComponentAddButton
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMultiPickerComponentAddButton()
        {
            this.Controls.MultiPickerComponentAddButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MultiPickerComponentRemoveButton
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMultiPickerComponentRemoveButton()
        {
            this.Controls.MultiPickerComponentRemoveButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClassPickerComponentAddButton
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClassPickerComponentAddButton()
        {
            this.Controls.Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Reset
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickReset()
        {
            this.Controls.ResetButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
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
        ///   [v-juli] 5/23/2011 Created
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
        ///   [v-juli] 5/23/2011 Created
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
        /// <history>
        ///   [v-juli] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout, string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), timeout);
            }
            catch (Maui.Core.Dialog.Exceptions.WindowNotFoundException)
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
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SpecifyTheScopeStaticControl query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheScopeStaticControl = ";[UIA]AutomationId=\'WizardPageTitleText\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MultiPickerComponentAddButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMultiPickerComponentAddButtonButton = ";[UIA]AutomationId=\'wizardControl\';[UIA]AutomationId=\'MultiPickerComponentAddButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MultiPickerComponentRemoveButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMultiPickerComponentRemoveButtonButton = ";[UIA]AutomationId=\'MultiPickerComponentRemoveButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for GroupsAndObjectsDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupsAndObjectsDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AllClassesStaticControl query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllClassesStaticControl = ";[UIA]AutomationId=\'SinglePickerComponentSelection\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceButton = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ResetButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResetButton = ";[UIA]AutomationId=\'SinglePickerComponentClearButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId=\'WizardPreviousButton\'";
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OrientationPane query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrientationPane = ";[UIA]AutomationId=\'OrientationListBox\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SpecifyTheScopeStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SpecifyTheScopeStaticControl
            {
                get
                {
                    return new QID(ResourceSpecifyTheScopeStaticControl);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MultiPickerComponentAddButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MultiPickerComponentAddButtonButton
            {
                get
                {
                    return new QID(ResourceMultiPickerComponentAddButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MultiPickerComponentRemoveButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MultiPickerComponentRemoveButtonButton
            {
                get
                {
                    return new QID(ResourceMultiPickerComponentRemoveButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupsAndObjectsDataGrid resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupsAndObjectsDataGrid
            {
                get
                {
                    return new QID(ResourceGroupsAndObjectsDataGrid);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AllClassesStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AllClassesStaticControl
            {
                get
                {
                    return new QID(ResourceAllClassesStaticControl);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Button resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Button
            {
                get
                {
                    return new QID(ResourceButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ResetButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ResetButton
            {
                get
                {
                    return new QID(ResourceResetButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PreviousButton
            {
                get
                {
                    return new QID(ResourcePreviousButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NextButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
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
            ///   [v-juli] 5/23/2011 Created
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
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OrientationPane resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OrientationPane
            {
                get
                {
                    return new QID(ResourceOrientationPane);
                }
            }
            #endregion
        }
        #endregion     
   
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Class Name
            /// </summary>
            /// -----------------------------------------------------------------------------            
            private const string ResourceObjectClass = ";Object;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;ObjectString";


            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectClass;

      
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectClass
            {
                get
                {
                    if ((cachedObjectClass == null))
                    {
                        cachedObjectClass = CoreManager.MomConsole.GetIntlStr(ResourceObjectClass);
                    }

                    return cachedObjectClass;
                }
            }
           
            #endregion
        }

    }
}
