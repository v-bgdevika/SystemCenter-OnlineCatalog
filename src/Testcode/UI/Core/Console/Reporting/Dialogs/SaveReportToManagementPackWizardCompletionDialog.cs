// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SaveReporttoaManagementPackWizardCompletionDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-liqluo] 3/24/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.HtmlControls;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - ISaveReportToManagementPackWizardCompletionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISaveReportToManagementPackWizardCompletionDialogControls, for SaveReportToManagementPackWizardCompletionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-liqluo] 3/24/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISaveReportToManagementPackWizardCompletionDialogControls
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
        /// Gets read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HtmlDoc
        /// </summary>
        HtmlDocument HtmlDoc
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ResultLable
        /// </summary>
        StaticControl ResultLable
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
    ///   [v-liqluo] 3/24/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SaveReportToManagementPackWizardCompletionDialog : Dialog, ISaveReportToManagementPackWizardCompletionDialogControls
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
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to HtmlDoc of type HtmlDocument
        /// </summary>
        private HtmlDocument cachedHtmlDoc;
        
        /// <summary>
        /// Cache to hold a reference to ResultLable of type StaticControl
        /// </summary>
        private StaticControl cachedResultLable;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SaveReportToManagementPackWizardCompletionDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SaveReportToManagementPackWizardCompletionDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SaveReportToManagementPackWizardCompletionDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISaveReportToManagementPackWizardCompletionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISaveReportToManagementPackWizardCompletionDialogControls Controls
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
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardCompletionDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SaveReportToManagementPackWizardCompletionDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardCompletionDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SaveReportToManagementPackWizardCompletionDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardCompletionDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, SaveReportToManagementPackWizardCompletionDialog.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveReportToManagementPackWizardCompletionDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, SaveReportToManagementPackWizardCompletionDialog.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HtmlDoc control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (HtmlDoc) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        HtmlDocument ISaveReportToManagementPackWizardCompletionDialogControls.HtmlDoc
        {
            get
            {
                if ((this.cachedHtmlDoc == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHtmlDoc = new HtmlDocument(wndTemp);
                }
                
                return this.cachedHtmlDoc;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ResultLable control
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISaveReportToManagementPackWizardCompletionDialogControls.ResultLable
        {
            get
            {
                if ((this.cachedResultLable == null))
                {
                    this.cachedResultLable = new StaticControl(this, SaveReportToManagementPackWizardCompletionDialog.ControlIDs.ResultLable);
                }
                
                return this.cachedResultLable;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
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
        ///   [v-liqluo] 3/24/2010 Created
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
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
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
        ///   [v-liqluo] 3/24/2010 Created
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

                        //Check the StaticControl to make it's the Completion dialog
                        Utilities.LogMessage("Trying to get the control resultLable.");
                        StaticControl resultLable = null;

                        try
                        {
                            resultLable = new StaticControl(tempWindow, ControlIDs.ResultLable);
                            Utilities.LogMessage("Get the control resultLable finished.");
                            if (resultLable != null && resultLable.IsVisible)
                            {
                                Utilities.LogMessage("Succefully get the SaveReportToManagementPackWizardCompletionDialog");
                            }
                            else
                            {
                                Utilities.LogMessage("ResultLable is null or is not visible.");
                                tempWindow = null;
                            }
                        }
                        catch(System.Exception)
                        {
                            Utilities.LogMessage("Catch exception while getting the ResultLable.");
                            tempWindow = null;
                        }
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
        ///   [v-liqluo] 3/24/2010 Created
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
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ResultLable
            /// </summary>
            public const string ResultLable = "label3";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-liqluo] 3/24/2010 Created
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
            private const string ResourceClose = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;c" +
                "ancelBtn.Text";

            /// <summary>
            /// Resource string for SavedSucceedText
            /// </summary>
            private const string ResourceSavedSucceedText = ";You have successfully saved this report to a Management Pack." +
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal." +
                "UI.Reporting.Wizards.Save.SaveReportSummaryPage;label3.Text";
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
            /// Caches the translated resource string for: Close
            /// </summary>
            private static string cachedClose;

            /// <summary>
            /// Caches the translated resource string for: SavedSucceedText
            /// </summary>
            private static string cachedSavedSucceedText;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/24/2010 Created
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
            /// 	[v-liqluo] 3/24/2010 Created
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
            /// 	[v-liqluo] 3/24/2010 Created
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
            /// 	[v-liqluo] 3/24/2010 Created
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
            /// 	[v-liqluo] 3/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }

                    return cachedClose;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SavedSucceedText translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 3/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SavedSucceedText
            {
                get
                {
                    if ((cachedSavedSucceedText == null))
                    {
                        cachedSavedSucceedText = CoreManager.MomConsole.GetIntlStr(ResourceSavedSucceedText);
                    }

                    return cachedSavedSucceedText;
                }
            }
            #endregion
        }
        #endregion
    }
}
