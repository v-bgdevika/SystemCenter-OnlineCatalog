// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SaveReportToManagementPackWizardGeneralDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-liqluo] 3/23/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - ISaveReportToManagementPackWizardGeneralDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISaveReportToManagementPackWizardGeneralDialogControls, for SaveReportToManagementPackWizardGeneralDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-liqluo] 3/23/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISaveReportToManagementPackWizardGeneralDialogControls
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
        /// Gets read-only property to access NewButton
        /// </summary>
        Button NewButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SelectDestinationManagementPackComboBox
        /// </summary>
        ComboBox SelectDestinationManagementPackComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
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
    ///   [v-liqluo] 3/22/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SaveReportToManagementPackWizardGeneralDialog : Dialog, ISaveReportToManagementPackWizardGeneralDialogControls
    {
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
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SaveReportToManagementPackWizardGeneralDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SaveReportToManagementPackWizardGeneralDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SaveReportToManagementPackWizardGeneralDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISaveReportToManagementPackWizardGeneralDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISaveReportToManagementPackWizardGeneralDialogControls Controls
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
        ///  Gets or sets the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectDestinationManagementPackText
        {
            get
            {
                return this.Controls.SelectDestinationManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.SelectDestinationManagementPackComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
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
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardGeneralDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardGeneralDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardGeneralDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardGeneralDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NewButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardGeneralDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.NewButton);
                }
                
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISaveReportToManagementPackWizardGeneralDialogControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISaveReportToManagementPackWizardGeneralDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NameTextBox control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISaveReportToManagementPackWizardGeneralDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, SaveReportToManagementPackWizardGeneralDialog.ControlIDs.NameTextBox);
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
        ///   [v-liqluo] 3/23/2010 Created
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
        ///   [v-liqluo] 3/23/2010 Created
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
        ///   [v-liqluo] 3/23/2010 Created
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
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Constants.OneSecond * 3);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 15;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow)
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Constants.OneSecond * 3);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 3);
                    }
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
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/23/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for Save Report to a Management Pack Wizard
            /// </summary>
            private const string ResourceDialogTitle = ";Save Report to a Management Pack Wizard;ManagedString;Microsoft.EnterpriseManagement." +
                "UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Save.SaveReportResources;WizardTitle";
            
            /// <summary>
            /// Resource string for < Previous
            /// </summary>
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Res" +
                "ources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en" +
                ";previousButton.Text";
            
            /// <summary>
            /// Resource string for Next >
            /// </summary>
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resourc" +
                "es.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;nex" +
                "tButton.Text";
            
            /// <summary>
            /// Resource string for Finish
            /// </summary>
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResource" +
                "s;FinishText";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;c" +
                "ancelBtn.Text";
            
            /// <summary>
            /// Resource string for New...
            /// </summary>
            private const string ResourceNew = ";Ne&w...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile." +
                "ProfileAccounts;toolStripButtonNew.Text";
            #endregion

            #region Private Members
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            private static string cachedDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Previous
            /// </summary>
            private static string cachedPrevious;

            /// <summary>
            /// Caches the translated resource string for: Next >
            /// </summary>
            private static string cachedNext;

            /// <summary>
            /// Caches the translated resource string for: Finish
            /// </summary>
            private static string cachedFinish;

            /// <summary>
            /// Caches the translated resource string for: Cancel
            /// </summary>
            private static string cachedCancel;

            /// <summary>
            /// Caches the translated resource string for: New
            /// </summary>
            private static string cachedNew;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/23/2010 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/23/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }

                    return cachedPrevious;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/23/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }

                    return cachedNext;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/23/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }

                    return cachedFinish;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/23/2010 Created
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
            /// Exposes access to the Delivery translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/23/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string New
            {
                get
                {
                    if ((cachedNew == null))
                    {
                        cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
                    }

                    return cachedNew;
                }
            }
            #endregion
        }
        #endregion
    }
}
