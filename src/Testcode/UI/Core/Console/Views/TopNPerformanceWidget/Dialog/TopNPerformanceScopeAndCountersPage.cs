// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TopNPerformanceScopeAndCountersPage.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-vijia] 8/10/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.TopNPerformanceWidget.Dialog
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #region Interface Definition - ITopNPerformanceScopeAndCountersPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITopNPerformanceScopeAndCountersPageControls, for TopNPerformanceScopeAndCountersPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-vijia] 8/10/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITopNPerformanceScopeAndCountersPageControls
    {
        /// <summary>
        /// Gets read-only property to access Button
        /// </summary>
        Button GroupOrObjectLauncherButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access Button3
        /// </summary>
        Button PerformanceCounterLauncherButton
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
        /// Gets read-only property to access GroupOrObjectSelectionText
        /// </summary>
        StaticControl GroupOrObjectSelectionText
        {
            get;
        }


        /// <summary>
        /// Gets read-only property to access PerformanceCounterSelectionText
        /// </summary>
        StaticControl PerformanceCounterSelectionText
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
    ///   [v-vijia] 8/10/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TopNPerformanceScopeAndCountersPage : Dialog, ITopNPerformanceScopeAndCountersPageControls
    {

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the TopNPerformanceScopeAndCountersPage class.
        /// </summary>
        /// <param name='app'>
        /// Owner of TopNPerformanceScopeAndCountersPage of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TopNPerformanceScopeAndCountersPage(MomConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ITopNPerformanceScopeAndCountersPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITopNPerformanceScopeAndCountersPageControls Controls
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
        ///  Gets access to the Button control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceScopeAndCountersPageControls.GroupOrObjectLauncherButton
        {
            get
            {
                return new Button(this, TopNPerformanceScopeAndCountersPage.QueryIds.GroupOrObjectLauncherButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Button3 control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (SinglePickerComponentLauncherButton) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceScopeAndCountersPageControls.PerformanceCounterLauncherButton
        {
            get
            {
                return new Button(this, TopNPerformanceScopeAndCountersPage.QueryIds.PerformanceCounterLauncherButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceScopeAndCountersPageControls.PreviousButton
        {
            get
            {
                return new Button(this, TopNPerformanceScopeAndCountersPage.QueryIds.PreviousButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceScopeAndCountersPageControls.NextButton
        {
            get
            {
                return new Button(this, TopNPerformanceScopeAndCountersPage.QueryIds.NextButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceScopeAndCountersPageControls.FinishButton
        {
            get
            {
                return new Button(this, TopNPerformanceScopeAndCountersPage.QueryIds.FinishButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceScopeAndCountersPageControls.CancelButton
        {
            get
            {
                return new Button(this, TopNPerformanceScopeAndCountersPage.QueryIds.CancelButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupOrObjectSelectionText control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITopNPerformanceScopeAndCountersPageControls.GroupOrObjectSelectionText
        {
            get
            {
                return new StaticControl(this, TopNPerformanceScopeAndCountersPage.QueryIds.GroupOrObjectSelection);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PerformanceCounterSelectionText control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITopNPerformanceScopeAndCountersPageControls.PerformanceCounterSelectionText
        {
            get
            {
                return new StaticControl(this, TopNPerformanceScopeAndCountersPage.QueryIds.PerformanceCounterSelection);
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click GroupOrObjectLauncherButton
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupOrObjectLauncherButton()
        {
            this.Controls.GroupOrObjectLauncherButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on PerformanceCounterLauncherButton
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPerformanceCounterLauncherButton()
        {
            this.Controls.PerformanceCounterLauncherButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/10/2011 Created
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
        ///   [v-vijia] 8/10/2011 Created
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
        ///   [v-vijia] 8/10/2011 Created
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
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion

        #region Selection Text Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets the text in control GroupOrObjectSelectionText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupOrObjectText
        {
            get
            {
                return this.Controls.GroupOrObjectSelectionText.Text;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets the text in control PerformanceCounterSelectionText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PerformanceCounterText
        {
            get
            {
                string text = string.Empty;

                //Get Object
                StaticControl obj = new StaticControl(this.Controls.PerformanceCounterSelectionText,
                                                      new QID(";[UIA]AutomationId = 'textBlock' && Instance = '1'"));
                text = text + obj.Text;

                //Get first delimiter
                StaticControl firstDelimiter = new StaticControl(this.Controls.PerformanceCounterSelectionText,
                                                      new QID(";[UIA]AutomationId = 'textBlock' && Instance = '2'"));
                text = text + firstDelimiter.Text;

                //Get Counter
                StaticControl counter = new StaticControl(this.Controls.PerformanceCounterSelectionText,
                                                      new QID(";[UIA]AutomationId = 'textBlock' && Instance = '3'"));
                text = text + counter.Text;

                //Get second delimiter
                StaticControl secondDelimiter = new StaticControl(this.Controls.PerformanceCounterSelectionText,
                                                      new QID(";[UIA]AutomationId = 'textBlock' && Instance = '4'"));
                text = text + secondDelimiter.Text;

                //Get Instance
                StaticControl instance = new StaticControl(this.Controls.PerformanceCounterSelectionText,
                                                      new QID(";[UIA]AutomationId = 'textBlock' && Instance = '5'"));
                text = text + instance.Text;

                return text;
            }
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
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
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
        ///   [v-vijia] 8/10/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupOrObjectLauncherButton = ";[UIA]AutomationId='SinglePickerComponentLauncherButton' && instance = '1'";

            /// <summary>
            /// Contains resource string for Selection query Id
            /// </summary>
            private const string ResourceGroupOrObjectSelection = ";[UIA]AutomationId='SinglePickerComponentSelection' && instance = '1'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceLauncherButton = ";[UIA]AutomationId='SinglePickerComponentLauncherButton' && instance = '2'";

            /// <summary>
            /// Contains resource string for Selection query Id
            /// </summary>
            private const string ResourcePerformanceSelection = ";[UIA]AutomationId='SinglePickerComponentSelection' && instance = '2'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceButton = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceButton2 = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceButton3 = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";

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

            /// <summary>
            /// Contains resource string for IncludeCheckBox query id
            /// </summary>
            private const string ResourceIncludeCheckBox = ";[UIA]AutomationId=\'checkBox\'";

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Button resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupOrObjectLauncherButton
            {
                get
                {
                    return new QID(ResourceGroupOrObjectLauncherButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Selection resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupOrObjectSelection
            {
                get
                {
                    return new QID(ResourceGroupOrObjectSelection);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Button3 resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PerformanceCounterLauncherButton
            {
                get
                {
                    return new QID(ResourcePerformanceLauncherButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PerformanceCounter resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PerformanceCounterSelection
            {
                get
                {
                    return new QID(ResourcePerformanceSelection);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
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
            ///   [v-vijia] 8/10/2011 Created
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
            ///   [v-vijia] 8/10/2011 Created
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
            ///   [v-vijia] 8/10/2011 Created
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
            /// Gets access to the IncludeCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID IncludeCheckBox
            {
                get
                {
                    return new QID(ResourceIncludeCheckBox);
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
        ///   [v-vijia] 8/10/2011 Created
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
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "New Instance Wizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ...
            /// ...
            /// </remark>
            private const string ResourceEllipsis0 = "...";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _3
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ...
            /// ...
            /// </remark>
            private const string Resource_3 = "...";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _5
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ...
            /// ...
            /// </remark>
            private const string Resource_5 = "...";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = "< Previous";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = "Next >";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = "Finish";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the _3 translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _3
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(Resource_3);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the _5 translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _5
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(Resource_5);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceNext);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Finish translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/10/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }
            #endregion
        }
        #endregion
    }
}
