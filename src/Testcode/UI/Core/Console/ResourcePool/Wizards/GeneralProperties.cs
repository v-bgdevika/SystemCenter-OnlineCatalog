// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GeneralProperties.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [asttest] 11/8/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ResourcePool
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IGeneralPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGeneralPropertiesControls, for GeneralProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGeneralPropertiesControls
    {
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
        /// Gets read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Gets read-only property to access TextLinkLabelLinkLabel
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel2
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel3
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel3
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel4
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel4
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DescriptionTextbox
        /// </summary>
        TextBox DescriptionTextbox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
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
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class GeneralProperties : Dialog, IGeneralPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel2 of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel2;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel3 of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel3;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel4 of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel4;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextbox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextbox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the GeneralProperties class.
        /// </summary>
        /// <param name='app'>
        /// Owner of GeneralProperties of type App
        /// </param>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GeneralProperties(App app, bool created, string poolName="") :
            base(app, Init(app, created, poolName))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IGeneralProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGeneralPropertiesControls Controls
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
        ///  Gets or sets the text in control DescriptionTextbox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionTextboxText
        {
            get
            {
                return this.Controls.DescriptionTextbox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextbox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control NameTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameTextBoxText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GeneralProperties.QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GeneralProperties.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, GeneralProperties.QueryIds.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GeneralProperties.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        LinkLabel IGeneralPropertiesControls.TextLinkLabelLinkLabel
        {
            get
            {
                if ((this.cachedTextLinkLabelLinkLabel == null))
                {
                    this.cachedTextLinkLabelLinkLabel = new LinkLabel(this, GeneralProperties.QueryIds.TextLinkLabelLinkLabel);
                }
                
                return this.cachedTextLinkLabelLinkLabel;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel2 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel IGeneralPropertiesControls.TextLinkLabelLinkLabel2
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedTextLinkLabelLinkLabel2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextLinkLabelLinkLabel2 = new LinkLabel(wndTemp);
                }
                
                return this.cachedTextLinkLabelLinkLabel2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel3 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel IGeneralPropertiesControls.TextLinkLabelLinkLabel3
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedTextLinkLabelLinkLabel3 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextLinkLabelLinkLabel3 = new LinkLabel(wndTemp);
                }
                
                return this.cachedTextLinkLabelLinkLabel3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel4 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel IGeneralPropertiesControls.TextLinkLabelLinkLabel4
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedTextLinkLabelLinkLabel4 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextLinkLabelLinkLabel4 = new LinkLabel(wndTemp);
                }
                
                return this.cachedTextLinkLabelLinkLabel4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DescriptionTextbox control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.DescriptionTextbox
        {
            get
            {
                if ((this.cachedDescriptionTextbox == null))
                {
                    this.cachedDescriptionTextbox = new TextBox(this, GeneralProperties.QueryIds.DescriptionTextbox);
                }
                
                return this.cachedDescriptionTextbox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NameTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, GeneralProperties.QueryIds.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
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
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
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
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, bool created, string poolName)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            string dialogTitle;

            if (created == true)
            {
                dialogTitle = Strings.CreatedDialogTitle;
            }
            else
            {
                dialogTitle = string.Format(Strings.EditDialogTitle, poolName);
            }
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[UIA, VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), Timeout);
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
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.WildCard);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw;
                }
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId=\'previousButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId=\'nextButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CreateButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateButton = ";[UIA]AutomationId=\'commitButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'cancelButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel2 = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel3 = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel4 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel4 = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DescriptionTextbox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescriptionTextbox = ";[UIA]AutomationId=\'descriptionTextbox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NameTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNameTextBox = ";[UIA]AutomationId=\'nameTextbox\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
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
            ///   [asttest] 11/8/2010 Created
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
            /// Gets access to the CreateButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CreateButton
            {
                get
                {
                    return new QID(ResourceCreateButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
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
            /// Gets access to the TextLinkLabelLinkLabel resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel2
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel3 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel3
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel3);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel4 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel4
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel4);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DescriptionTextbox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DescriptionTextbox
            {
                get
                {
                    return new QID(ResourceDescriptionTextbox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NameTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NameTextBox
            {
                get
                {
                    return new QID(ResourceNameTextBox);
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
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains Resource string for: "Create a Resource Pool Wizard"
            /// </summary>            
            private const string ResourceCreatedDialogTitle =
                ";Create a Resource Pool Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_Wizard_Title_Create";

            /// <summary>
            /// Contains Resource string for: "{0} Properties"
            /// </summary>            
            private const string ResourceEditDialogTitle =
                ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_Wizard_Title_Edit";
            

            #endregion

            #region Private members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Create a Resource Pool Wizard"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreatedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "{0} Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditDialogTitle;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Create a Resource Pool Wizard"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string CreatedDialogTitle
            {
                get
                {
                    if ((cachedCreatedDialogTitle == null))
                    {
                        cachedCreatedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceCreatedDialogTitle);
                    }

                    return cachedCreatedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "{0} Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string EditDialogTitle
            {
                get
                {
                    if ((cachedEditDialogTitle == null))
                    {
                        cachedEditDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceEditDialogTitle);
                    }

                    return cachedEditDialogTitle;
                }
            }
            #endregion
                        
            /// <summary>
            /// Resource string for < Previous
            /// </summary>
            public const string Previous = "< Previous";
            
            /// <summary>
            /// Resource string for Next >
            /// </summary>
            public const string Next = "Next >";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            public const string Create = "Create";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel = "textLinkLabel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel2 = "textLinkLabel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel3 = "textLinkLabel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel4 = "textLinkLabel";
        }
        #endregion
    }
}
