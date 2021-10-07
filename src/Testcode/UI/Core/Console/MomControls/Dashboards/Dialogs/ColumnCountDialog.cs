// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ColumnCountDialog.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-vijia] 1/5/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IColumnCountDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IColumnCountDialogControls, for ColumnCountDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-vijia] 1/5/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IColumnCountDialogControls
    {
        /// <summary>
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ColumnCountTextBox
        /// </summary>
        TextBox ColumnCountTextBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access UpButtonButton
        /// </summary>
        Button UpButtonButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access DownButtonButton
        /// </summary>
        Button DownButtonButton
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
        /// Gets read-only property to access _PreviousStaticControl
        /// </summary>
        StaticControl _PreviousStaticControl
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
        /// Gets read-only property to access _NextStaticControl
        /// </summary>
        StaticControl _NextStaticControl
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
        /// Gets read-only property to access _FinishStaticControl
        /// </summary>
        StaticControl _FinishStaticControl
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
        /// Gets read-only property to access _CancelStaticControl
        /// </summary>
        StaticControl _CancelStaticControl
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
    ///   [v-vijia] 1/5/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class ColumnCountDialog : Dialog, IColumnCountDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;

        /// <summary>
        /// Cache to hold a reference to ColumnCountTextBox of type TextBox
        /// </summary>
        private TextBox cachedColumnCountTextBox;

        /// <summary>
        /// Cache to hold a reference to UpButtonButton of type Button
        /// </summary>
        private Button cachedUpButtonButton;

        /// <summary>
        /// Cache to hold a reference to DownButtonButton of type Button
        /// </summary>
        private Button cachedDownButtonButton;

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to _PreviousStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_PreviousStaticControl;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to _NextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_NextStaticControl;

        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;

        /// <summary>
        /// Cache to hold a reference to _FinishStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_FinishStaticControl;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to _CancelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_CancelStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the ColumnCountDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ColumnCountDialog of type MOMConsoleApp
        /// </param>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ColumnCountDialog(ConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(app, dialogTitle, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IColumnCountDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IColumnCountDialogControls Controls
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
        ///  Gets or sets the text in control ColumnCount
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ColumnCountText
        {
            get
            {
                return this.Controls.ColumnCountTextBox.Text;
            }

            set
            {
                this.Controls.ColumnCountTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OrientationPane control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IColumnCountDialogControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, ColumnCountDialog.QueryIds.OrientationPane);
                }

                return this.cachedOrientationPane;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnCountTextBox control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IColumnCountDialogControls.ColumnCountTextBox
        {
            get
            {
                if ((this.cachedColumnCountTextBox == null))
                {
                    this.cachedColumnCountTextBox = new TextBox(this, ColumnCountDialog.QueryIds.ColumnCountTextBox);
                }

                return this.cachedColumnCountTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the UpButtonButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IColumnCountDialogControls.UpButtonButton
        {
            get
            {
                if ((this.cachedUpButtonButton == null))
                {
                    this.cachedUpButtonButton = new Button(this, ColumnCountDialog.QueryIds.UpButtonButton);
                }

                return this.cachedUpButtonButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DownButtonButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IColumnCountDialogControls.DownButtonButton
        {
            get
            {
                if ((this.cachedDownButtonButton == null))
                {
                    this.cachedDownButtonButton = new Button(this, ColumnCountDialog.QueryIds.DownButtonButton);
                }

                return this.cachedDownButtonButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IColumnCountDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ColumnCountDialog.QueryIds.PreviousButton);
                }

                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _PreviousStaticControl control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (_PreviousStaticControl) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IColumnCountDialogControls._PreviousStaticControl
        {
            get
            {
                if ((this.cached_PreviousStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cached_PreviousStaticControl = new StaticControl(wndTemp);
                }

                return this.cached_PreviousStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IColumnCountDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ColumnCountDialog.QueryIds.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _NextStaticControl control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (_NextStaticControl) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IColumnCountDialogControls._NextStaticControl
        {
            get
            {
                if ((this.cached_NextStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cached_NextStaticControl = new StaticControl(wndTemp);
                }

                return this.cached_NextStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IColumnCountDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ColumnCountDialog.QueryIds.FinishButton);
                }

                return this.cachedFinishButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _FinishStaticControl control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (_FinishStaticControl) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IColumnCountDialogControls._FinishStaticControl
        {
            get
            {
                if ((this.cached_FinishStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cached_FinishStaticControl = new StaticControl(wndTemp);
                }

                return this.cached_FinishStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IColumnCountDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ColumnCountDialog.QueryIds.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _CancelStaticControl control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (_CancelStaticControl) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IColumnCountDialogControls._CancelStaticControl
        {
            get
            {
                if ((this.cached_CancelStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cached_CancelStaticControl = new StaticControl(wndTemp);
                }

                return this.cached_CancelStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UpButton
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUpButton()
        {
            this.Controls.UpButtonButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DownButton
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDownButton()
        {
            this.Controls.DownButtonButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
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
        ///   [v-vijia] 1/5/2011 Created
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
        ///   [v-vijia] 1/5/2011 Created
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
        ///   [v-vijia] 1/5/2011 Created
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
        /// <param name="app">MOMConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, string dialogTitle, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        // Try to locate an existing instance of a dialog
                        tempWindow = new Window(dialogTitle + "*", StringMatchSyntax.WildCard); //new Window(app.MainWindow, new QID(";[VisibleOnly]Name = '" + Strings.DialogTitle + "' && Role = 'window'"), timeout);
                        break;
                    case ProductSkuLevel.Web:                        
                        tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, dialogTitle)), timeout);
                        break;
                    default:
                        break;
                }
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                int maxRetries = Constants.DefaultMaxRetry;
                int retries = 0;
                while (tempWindow == null && retries < maxRetries)
                {
                    retries++;
                    try
                    {
                        // look for the dialog again
                        tempWindow = new Window(Strings.DialogTitle + "*", StringMatchSyntax.WildCard);
                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for windows search
                        Sleeper.Delay(timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + retries
                            + " of "
                            + maxRetries
                            + "...");
                    }
                }

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

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OrientationPane query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrientationPane = ";[UIA]AutomationId=\'OrientationListBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ColumnCountTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnCountTextBox = ";[UIA]AutomationId=\'valueText\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for UpButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUpButtonButton = ";[UIA]AutomationId=\'upButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DownButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDownButtonButton = ";[UIA]AutomationId=\'downButton\'";

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
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OrientationPane resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OrientationPane
            {
                get
                {
                    return new QID(ResourceOrientationPane);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnCountTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnCountTextBox
            {
                get
                {
                    return new QID(ResourceColumnCountTextBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the UpButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID UpButtonButton
            {
                get
                {
                    return new QID(ResourceUpButtonButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DownButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DownButtonButton
            {
                get
                {
                    return new QID(ResourceDownButtonButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
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
            ///   [v-vijia] 1/5/2011 Created
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
            ///   [v-vijia] 1/5/2011 Created
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
            ///   [v-vijia] 1/5/2011 Created
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
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OrientationPane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrientationPane = "OrientationPane";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = "< Previous";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_Previous = "< _Previous";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = "Next >";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_Next = "_Next >";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = "Finish";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_Finish = "_Finish";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_Cancel = "_Cancel";
            #endregion

            #region Fields
            private static string cachedDialogTitle;
            private static string cachedTitleUpdateDialog;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if(cachedDialogTitle == null)
                    {
                        cachedDialogTitle = MpResources.ConfigurationLibraryMp.GetLocalizedResource.CreateTemplateInstanceWizardTitle;
                    }
                    
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitleUpdateDialog translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string DialogTitleUpdateDialog
            {
                get
                {
                    if (cachedTitleUpdateDialog == null)
                    {
                        cachedTitleUpdateDialog = MpResources.ConfigurationLibraryMp.GetLocalizedResource.WizardDialogWithCustomPagesTitle;
                    }

                    return cachedTitleUpdateDialog;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OrientationPane translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OrientationPane
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceOrientationPane);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
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
            /// Gets access to the _Previous translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _Previous
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(Resource_Previous);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
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
            /// Gets access to the _Next translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _Next
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(Resource_Next);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Finish translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
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
            /// Gets access to the _Finish translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _Finish
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(Resource_Finish);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the _Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(Resource_Cancel);
                }
            }
            #endregion
        }
        #endregion
    }
}
