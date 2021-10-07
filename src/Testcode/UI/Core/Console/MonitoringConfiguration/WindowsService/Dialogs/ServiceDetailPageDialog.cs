// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceDetailPageDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Service Detail Tab Page of Windows Service Template Properties.
// </summary>
// <history>
//   [v-brucec] 11/20/2009 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IServiceDetailPageDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceDetailPageDialogControls, for ServiceDetailPageDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-brucec] 11/20/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceDetailPageDialogControls
    {
        /// <summary>
        /// Gets read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access TabControlCollection
        /// </summary>
        TabControl TabControlCollection
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupNameTextBox
        /// </summary>
        TextBox GroupNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomaticServiceCheckBox
        /// </summary>
        CheckBox AutomaticServiceCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupSearchButton
        /// </summary>
        Button GroupSearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceNameTextBox
        /// </summary>
        TextBox ServiceNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceSearchButton
        /// </summary>
        Button ServiceSearchButton
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
    ///   [v-brucec] 11/20/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class ServiceDetailPageDialog : Dialog, IServiceDetailPageDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to TabControlCollection of type TabControl
        /// </summary>
        private TabControl cachedTabControlCollection;
        
        /// <summary>
        /// Cache to hold a reference to GroupNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedGroupNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticServiceCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAutomaticServiceCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to GroupSearchButton of type Button
        /// </summary>
        private Button cachedGroupSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to ServiceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceSearchButton of type Button
        /// </summary>
        private Button cachedServiceSearchButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the ServiceDetailPageDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceDetailPageDialog of type App
        /// </param>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceDetailPageDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IServiceDetailPageDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceDetailPageDialogControls Controls
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
        ///  Property to handle checkbox MonitorOnlyAutomaticService
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AutomaticService
        {
            get
            {
                return this.Controls.AutomaticServiceCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AutomaticServiceCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GroupName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupNameText
        {
            get
            {
                return this.Controls.GroupNameTextBox.Text;
            }
            
            set
            {
                this.Controls.GroupNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServiceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceNameText
        {
            get
            {
                return this.Controls.ServiceNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceNameTextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceDetailPageDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ServiceDetailPageDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceDetailPageDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceDetailPageDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceDetailPageDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ServiceDetailPageDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TabControlCollection control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IServiceDetailPageDialogControls.TabControlCollection
        {
            get
            {
                if ((this.cachedTabControlCollection == null))
                {
                    this.cachedTabControlCollection = new TabControl(this, ServiceDetailPageDialog.ControlIDs.TabControlCollection);
                }
                
                return this.cachedTabControlCollection;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupNameTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceDetailPageDialogControls.GroupNameTextBox
        {
            get
            {
                if ((this.cachedGroupNameTextBox == null))
                {
                    this.cachedGroupNameTextBox = new TextBox(this, TargetGroupAndServiceDialog.ControlIDs.GroupNameTextBox);
                }

                return this.cachedGroupNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticServiceCheckBox control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceDetailPageDialogControls.AutomaticServiceCheckBox
        {
            get
            {
                if ((this.cachedAutomaticServiceCheckBox == null))
                {
                    this.cachedAutomaticServiceCheckBox = new CheckBox(this, TargetGroupAndServiceDialog.ControlIDs.AutomaticServiceCheckBox);
                }

                return this.cachedAutomaticServiceCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupSearchButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceDetailPageDialogControls.GroupSearchButton
        {
            get
            {
                if ((this.cachedGroupSearchButton == null))
                {
                    this.cachedGroupSearchButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.GroupSearchButton);
                }

                return this.cachedGroupSearchButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceDetailPageDialogControls.ServiceNameTextBox
        {
            get
            {
                if ((this.cachedServiceNameTextBox == null))
                {
                    this.cachedServiceNameTextBox = new TextBox(this, TargetGroupAndServiceDialog.ControlIDs.ServiceNameTextBox);
                }

                return this.cachedServiceNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceSearchButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceDetailPageDialogControls.ServiceSearchButton
        {
            get
            {
                if ((this.cachedServiceSearchButton == null))
                {
                    this.cachedServiceSearchButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.ServiceSearchButton);
                }

                return this.cachedServiceSearchButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
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
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AutomaticService
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutomaticService()
        {
            this.Controls.AutomaticServiceCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupSearch
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupSearch()
        {
            this.Controls.GroupSearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ServiceSearch
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickServiceSearch()
        {
            this.Controls.ServiceSearchButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
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
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("PerformanceDataPageDialog.Init :: Attempt "
                            + numberOfTries
                            + " of "
                            + maxTries
                            + "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
                }
            }

            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for TabControlCollection
            /// </summary>
            public const string TabControlCollection = "tabPages";

            /// <summary>
            /// Control ID for GroupNameTextBox
            /// </summary>
            public const string GroupNameTextBox = "textBoxGroupName";

            /// <summary>
            /// Control ID for AutomaticServiceCheckBox
            /// </summary>
            public const string AutomaticServiceCheckBox = "checkBoxAutomaticService";

            /// <summary>
            /// Control ID for GroupSearchButton
            /// </summary>
            public const string GroupSearchButton = "buttonSearchGroup";

            /// <summary>
            /// Control ID for ServiceNameTextBox
            /// </summary>
            public const string ServiceNameTextBox = "serviceNameTextBox";

            /// <summary>
            /// Control ID for ServiceSearchButton
            /// </summary>
            public const string ServiceSearchButton = "browseButton";
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Private Members

            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-brucec] 11/20/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = Templates.Strings.PropertiesDialogTitle;
                    }

                    return cachedDialogTitle;
                }
            }
            #endregion
        }
        #endregion
    }
}
