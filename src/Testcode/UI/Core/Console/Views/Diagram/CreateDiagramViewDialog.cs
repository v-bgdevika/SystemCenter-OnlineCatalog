// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateDiagramViewDialog.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  The dialog for creating new diagram view wizard.
// </summary>
// <history>
//   [v-cheli] 11/24/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Diagram
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    ///   [v-cheli] 11/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// CreateYourOwnTemplate = 0
        /// </summary>
        CreateYourOwnTemplate = 0,
        
        /// <summary>
        /// ChooseFromATemplate = 1
        /// </summary>
        ChooseFromATemplate = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateDiagramViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateDiagramViewDialogControls, for CreateDiagramViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-cheli] 11/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateDiagramViewDialogControls
    {
        /// <summary>
        /// Read-only property to access ViewDetailsButton
        /// </summary>
        Button ViewDetailsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateYourOwnTemplateRadioButton
        /// </summary>
        RadioButton CreateYourOwnTemplateRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseFromATemplateRadioButton
        /// </summary>
        RadioButton ChooseFromATemplateRadioButton
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
        /// Read-only property to access SelectATemplate
        /// </summary>
        ComboBox SelectATemplate
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TabControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl TabControl0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LevelsToShow
        /// </summary>
        Spinner LevelsToShow
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LayoutDirection
        /// </summary>
        ComboBox LayoutDirection
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseTarget
        /// </summary>
        TextBox ChooseTarget
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Description
        /// </summary>
        TextBox Description
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Name
        /// </summary>
        TextBox Name
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
    ///   [v-cheli] 11/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class CreateDiagramViewDialog : Dialog, ICreateDiagramViewDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ViewDetailsButton of type Button
        /// </summary>
        private Button cachedViewDetailsButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateYourOwnTemplateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedCreateYourOwnTemplateRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ChooseFromATemplateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedChooseFromATemplateRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectATemplate of type ComboBox
        /// </summary>
        private ComboBox cachedSelectATemplate;
        
        /// <summary>
        /// Cache to hold a reference to TabControl0 of type TabControl
        /// </summary>
        private TabControl cachedTabControl0;
        
        /// <summary>
        /// Cache to hold a reference to LevelsToShow of type Spinner
        /// </summary>
        private Spinner cachedLevelsToShow;
        
        /// <summary>
        /// Cache to hold a reference to LayoutDirection of type ComboBox
        /// </summary>
        private ComboBox cachedLayoutDirection;
        
        /// <summary>
        /// Cache to hold a reference to ChooseTarget of type TextBox
        /// </summary>
        private TextBox cachedChooseTarget;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to Description of type TextBox
        /// </summary>
        private TextBox cachedDescription;
        
        /// <summary>
        /// Cache to hold a reference to Name of type TextBox
        /// </summary>
        private TextBox cachedName;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateDiagramViewDialog of type CreateDiagramViewDialog
        /// </param>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateDiagramViewDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.CreateYourOwnTemplateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.CreateYourOwnTemplate;
                }
                
                if ((this.Controls.ChooseFromATemplateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.ChooseFromATemplate;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.CreateYourOwnTemplate))
                {
                    this.Controls.CreateYourOwnTemplateRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.ChooseFromATemplate))
                    {
                        this.Controls.ChooseFromATemplateRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateDiagramViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateDiagramViewDialogControls Controls
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
        ///  Routine to set/get the text in control SelectATemplate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectATemplateText
        {
            get
            {
                return this.Controls.SelectATemplate.Text;
            }
            
            set
            {
                this.Controls.SelectATemplate.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LayoutDirection
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LayoutDirectionText
        {
            get
            {
                return this.Controls.LayoutDirection.Text;
            }
            
            set
            {
                this.Controls.LayoutDirection.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ChooseTarget
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ChooseTargetText
        {
            get
            {
                return this.Controls.ChooseTarget.Text;
            }
            
            set
            {
                this.Controls.ChooseTarget.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.Description.Text;
            }
            
            set
            {
                this.Controls.Description.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.Name.Text;
            }
            
            set
            {
                this.Controls.Name.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewDetailsButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.ViewDetailsButton
        {
            get
            {
                if ((this.cachedViewDetailsButton == null))
                {
                    this.cachedViewDetailsButton = new Button(this, CreateDiagramViewDialog.ControlIDs.ViewDetailsButton);
                }
                
                return this.cachedViewDetailsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateYourOwnTemplateRadioButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.CreateYourOwnTemplateRadioButton
        {
            get
            {
                if ((this.cachedCreateYourOwnTemplateRadioButton == null))
                {
                    this.cachedCreateYourOwnTemplateRadioButton = new RadioButton(this, CreateDiagramViewDialog.ControlIDs.CreateYourOwnTemplateRadioButton);
                }
                
                return this.cachedCreateYourOwnTemplateRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseFromATemplateRadioButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.ChooseFromATemplateRadioButton
        {
            get
            {
                if ((this.cachedChooseFromATemplateRadioButton == null))
                {
                    this.cachedChooseFromATemplateRadioButton = new RadioButton(this, CreateDiagramViewDialog.ControlIDs.ChooseFromATemplateRadioButton);
                }
                
                return this.cachedChooseFromATemplateRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateDiagramViewDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectATemplate control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.SelectATemplate
        {
            get
            {
                if ((this.cachedSelectATemplate == null))
                {
                    this.cachedSelectATemplate = new ComboBox(this, CreateDiagramViewDialog.ControlIDs.SelectATemplate);
                }
                
                return this.cachedSelectATemplate;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TabControl0 control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ICreateDiagramViewDialogControls.TabControl0
        {
            get
            {
                if ((this.cachedTabControl0 == null))
                {
                    this.cachedTabControl0 = new TabControl(this, CreateDiagramViewDialog.ControlIDs.TabControl0);
                }
                
                return this.cachedTabControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LevelsToShow control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ICreateDiagramViewDialogControls.LevelsToShow
        {
            get
            {
                if ((this.cachedLevelsToShow == null))
                {
                    this.cachedLevelsToShow = new Spinner(this, CreateDiagramViewDialog.ControlIDs.LevelsToShow);
                }
                
                return this.cachedLevelsToShow;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LayoutDirection control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.LayoutDirection
        {
            get
            {
                if ((this.cachedLayoutDirection == null))
                {
                    this.cachedLayoutDirection = new ComboBox(this, CreateDiagramViewDialog.ControlIDs.LayoutDirection);
                }
                
                return this.cachedLayoutDirection;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseTarget control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.ChooseTarget
        {
            get
            {
                if ((this.cachedChooseTarget == null))
                {
                    this.cachedChooseTarget = new TextBox(this, CreateDiagramViewDialog.ControlIDs.ChooseTarget);
                }
                
                return this.cachedChooseTarget;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, CreateDiagramViewDialog.ControlIDs.BrowseButton);
                }
                
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Description control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.Description
        {
            get
            {
                if ((this.cachedDescription == null))
                {
                    this.cachedDescription = new TextBox(this, CreateDiagramViewDialog.ControlIDs.Description);
                }
                
                return this.cachedDescription;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Name control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.Name
        {
            get
            {
                if ((this.cachedName == null))
                {
                    this.cachedName = new TextBox(this, CreateDiagramViewDialog.ControlIDs.Name);
                }
                
                return this.cachedName;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, CreateDiagramViewDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ViewDetails
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickViewDetails()
        {
            this.Controls.ViewDetailsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();

        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">CreateDiagramViewDialog owning the dialog.</param>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app, Timeout);
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
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
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
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ViewDetailsButton
            /// </summary>
            public const string ViewDetailsButton = "viewTemplateButton";
            
            /// <summary>
            /// Control ID for CreateYourOwnTemplateRadioButton
            /// </summary>
            public const string CreateYourOwnTemplateRadioButton = "customRadioButton";
            
            /// <summary>
            /// Control ID for ChooseFromATemplateRadioButton
            /// </summary>
            public const string ChooseFromATemplateRadioButton = "templateRadioButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for SelectATemplate
            /// </summary>
            public const string SelectATemplate = "templateComboBox";
            
            /// <summary>
            /// Control ID for TabControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TabControl0 = "propertiesTabControl";
            
            /// <summary>
            /// Control ID for LevelsToShow
            /// </summary>
            public const string LevelsToShow = "levelsToShowUpDown";
            
            /// <summary>
            /// Control ID for LayoutDirection
            /// </summary>
            public const string LayoutDirection = "directionComboBox";
            
            /// <summary>
            /// Control ID for ChooseTarget
            /// </summary>
            public const string ChooseTarget = "moTextBox";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "moButton";
            
            /// <summary>
            /// Control ID for Description
            /// </summary>
            public const string Description = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for Name
            /// </summary>
            public const string Name = "nameTextBox";
            
            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "okButton";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Create Diagram View
            /// </summary>
            public const string ResourceDialogTitle = ";Create Diagram View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;$this.Text";
            
            /// <summary>
            /// Resource string for View Details...
            /// </summary>
            public const string ResourceViewDetails = ";&View Details...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;viewTemplateButton.Text";
      
            /// <summary>
            /// Resource string for Create your own template
            /// </summary>
            public const string ResourceCreateYourOwnTemplate = ";Create yo&ur own template;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;customRadioButton.Text";
            
            /// <summary>
            /// Resource string for Choose from a template
            /// </summary>
            public const string ResourceChooseFromATemplate = ";Choose from a tem&plate;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;templateRadioButton.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// <summary>
            /// Resource string for Select a template ...
            /// </summary>
            public const string ResourceSelectATemplate = ";Select a template ...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;SelectTemplate";
            
            /// <summary>
            /// Resource string for Levels to Show: 
            /// </summary>
            public const string ResourceLevelsToShow = ";Levels to S&how: ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;levelsToShowLabel.Text";
            
            /// <summary>
            /// Resource string for Layout Direction: 
            /// </summary>
            public const string ResourceLayoutDirection = ";Layou&t Direction: ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionLabel.Text";
            
            /// <summary>
            /// Resource string for Browse ...
            /// </summary>
            public const string ResourceBrowse = ";Br&owse ...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;moButton.Text";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            public const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.NewMPDialog;createButton.Text";

            #endregion

            #region Private members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ViewDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewDetails;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Create Your Own Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateYourOwnTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Choose From A Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseFromATemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Select A Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectATemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Levels To Show
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLevelsToShow;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the LayoutDirection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLayoutDirection;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
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
            /// Exposes access to the ViewDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewDetails
            {
                get
                {
                    if ((cachedViewDetails == null))
                    {
                        cachedViewDetails = CoreManager.MomConsole.GetIntlStr(ResourceViewDetails);
                    }
                    return cachedViewDetails;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateYourOwnTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateYourOwnTemplate
            {
                get
                {
                    if ((cachedCreateYourOwnTemplate == null))
                    {
                        cachedCreateYourOwnTemplate = CoreManager.MomConsole.GetIntlStr(ResourceCreateYourOwnTemplate);
                    }
                    return cachedCreateYourOwnTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseFromATemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseFromATemplate
            {
                get
                {
                    if ((cachedChooseFromATemplate == null))
                    {
                        cachedChooseFromATemplate = CoreManager.MomConsole.GetIntlStr(ResourceChooseFromATemplate);
                    }
                    return cachedChooseFromATemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
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
            /// Exposes access to the SelectATemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectATemplate
            {
                get
                {
                    if ((cachedSelectATemplate == null))
                    {
                        cachedSelectATemplate = CoreManager.MomConsole.GetIntlStr(ResourceSelectATemplate);
                    }
                    return cachedSelectATemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LevelsToShow translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LevelsToShow
            {
                get
                {
                    if ((cachedLevelsToShow == null))
                    {
                        cachedLevelsToShow = CoreManager.MomConsole.GetIntlStr(ResourceLevelsToShow);
                    }
                    return cachedLevelsToShow;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LayoutDirection translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LayoutDirection
            {
                get
                {
                    if ((cachedLayoutDirection == null))
                    {
                        cachedLayoutDirection = CoreManager.MomConsole.GetIntlStr(ResourceLayoutDirection);
                    }
                    return cachedLayoutDirection;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Browse
            {
                get
                {
                    if ((cachedBrowse == null))
                    {
                        cachedBrowse = CoreManager.MomConsole.GetIntlStr(ResourceBrowse);
                    }
                    return cachedBrowse;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 11/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    return cachedCreate;
                }
            }

            #endregion

        }
        #endregion
    }
}
