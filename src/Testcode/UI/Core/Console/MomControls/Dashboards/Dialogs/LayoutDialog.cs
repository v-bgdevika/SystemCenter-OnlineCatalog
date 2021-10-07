// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="LayoutDialog.cs">
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

    #region Interface Definition - ILayoutDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ILayoutDialogControls, for LayoutDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-vijia] 1/5/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILayoutDialogControls
    {
        /// <summary>
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access SpecifyTheLayoutOfTheDashboardComboBox
        /// </summary>
        ComboBox SpecifyTheLayoutOfTheDashboardComboBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access SelectALayoutTemplateListView
        /// </summary>
        ListView SelectALayoutTemplateListView
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
    public partial class LayoutDialog : Dialog, ILayoutDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;

        /// <summary>
        /// Cache to hold a reference to SpecifyTheLayoutOfTheDashboardComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSpecifyTheLayoutOfTheDashboardComboBox;

        /// <summary>
        /// Cache to hold a reference to SelectALayoutTemplateListView of type ListView
        /// </summary>
        private ListView cachedSelectALayoutTemplateListView;

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
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the LayoutDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of LayoutDialog of type MOMConsoleApp
        /// </param>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public LayoutDialog(ConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(app, dialogTitle, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ILayoutDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ILayoutDialogControls Controls
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
        ///  Gets or sets the text in control SpecifyTheLayoutOfTheDashboard
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheLayoutOfTheDashboardText
        {
            get
            {
                return this.Controls.SpecifyTheLayoutOfTheDashboardComboBox.Text;
            }

            set
            {
                this.Controls.SpecifyTheLayoutOfTheDashboardComboBox.SelectByText(value, true);
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
        ListView ILayoutDialogControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, LayoutDialog.QueryIds.OrientationPane);
                }

                return this.cachedOrientationPane;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SpecifyTheLayoutOfTheDashboardComboBox control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ILayoutDialogControls.SpecifyTheLayoutOfTheDashboardComboBox
        {
            get
            {
                if ((this.cachedSpecifyTheLayoutOfTheDashboardComboBox == null))
                {
                    this.cachedSpecifyTheLayoutOfTheDashboardComboBox = new ComboBox(this, LayoutDialog.QueryIds.SpecifyTheLayoutOfTheDashboardComboBox);
                }

                return this.cachedSpecifyTheLayoutOfTheDashboardComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectALayoutTemplateListView control
        /// </summary>
        /// <history>
        ///   [v-vijia] 1/5/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ILayoutDialogControls.SelectALayoutTemplateListView
        {
            get
            {
                if ((this.cachedSelectALayoutTemplateListView == null))
                {
                    this.cachedSelectALayoutTemplateListView = new ListView(this, LayoutDialog.QueryIds.SelectALayoutTemplateListView);
                }

                return this.cachedSelectALayoutTemplateListView;
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
        Button ILayoutDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, LayoutDialog.QueryIds.PreviousButton);
                }

                return this.cachedPreviousButton;
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
        Button ILayoutDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, LayoutDialog.QueryIds.NextButton);
                }

                return this.cachedNextButton;
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
        Button ILayoutDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, LayoutDialog.QueryIds.FinishButton);
                }

                return this.cachedFinishButton;
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
        Button ILayoutDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, LayoutDialog.QueryIds.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }
        #endregion

        #region Click Methods

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
                        tempWindow = new Window(dialogTitle + "*", StringMatchSyntax.WildCard);
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

        public void SelectLayoutTemplateItem(string itemName)
        {
            string elementName = string.Empty;
            int instance = 0;

            switch (itemName)
            {
                case LayoutTemplates.GridLayout01CellFill:
                    elementName = Strings.ResourceGridLayout01CellFillConfig;
                    instance = 1;
                    break;

                case LayoutTemplates.GridLayout02CellSplitHorizontal:
                    elementName = Strings.ResourceGridLayout02CellSplitHorizontalConfig;
                    instance = 1;
                    break;

                case LayoutTemplates.GridLayout02CellSplitVertical:
                    elementName = Strings.ResourceGridLayout02CellSplitVerticalConfig;
                    instance = 2;
                    break;

                case LayoutTemplates.GridLayout03CellStack:
                    elementName = Strings.ResourceGridLayout03CellStackConfig;
                    instance = 1;
                    break;

                case LayoutTemplates.GridLayout03CellBigTop:
                    elementName = Strings.ResourceGridLayout03CellBigTopConfig;
                    instance = 4;
                    break;

                case LayoutTemplates.GridLayout03CellBigLeft:
                    elementName = Strings.ResourceGridLayout03CellBigLeftConfig;
                    instance = 3;
                    break;

                case LayoutTemplates.GridLayout03CellBigBottom:
                    elementName = Strings.ResourceGridLayout03CellBigBottomConfig;
                    instance = 2;
                    break;

                case LayoutTemplates.GridLayout03CellBigRight:
                    elementName = Strings.ResourceGridLayout03CellBigRightConfig;
                    instance = 5;
                    break;

                case LayoutTemplates.GridLayout04CellBigBottom:
                    elementName = Strings.ResourceGridLayout04CellBigBottomConfig;
                    instance = 5;
                    break;

                case LayoutTemplates.GridLayout04CellTiled:
                    elementName = Strings.ResourceGridLayout04CellTiledConfig;
                    instance = 3;
                    break;

                case LayoutTemplates.GridLayout04CellBigLeft:
                    elementName = Strings.ResourceGridLayout04CellBigLeftConfig;
                    instance = 1;
                    break;

                case LayoutTemplates.GridLayout04CellBigTop:
                    elementName = Strings.ResourceGridLayout04CellBigTopConfig;
                    instance = 2;
                    break;

                case LayoutTemplates.GridLayout04CellBigRight:
                    elementName = Strings.ResourceGridLayout04CellBigRightConfig;
                    instance = 4;
                    break;

                case LayoutTemplates.GridLayout05CellThreeBottom:
                    elementName = Strings.ResourceGridLayout05CellThreeBottomConfig;
                    instance = 4;
                    break;

                case LayoutTemplates.GridLayout05CellOneTop:
                    elementName = Strings.ResourceGridLayout05CellOneTopConfig;
                    instance = 2;
                    break;

                case LayoutTemplates.GridLayout05CellOneBottom:
                    elementName = Strings.ResourceGridLayout05CellOneBottomConfig;
                    instance = 1;
                    break;

                case LayoutTemplates.GridLayout05CellThreeTop:
                    elementName = Strings.ResourceGridLayout05CellThreeTopConfig;
                    instance = 3;
                    break;

                case LayoutTemplates.GridLayout06CellTiled:
                    elementName = Strings.ResourceGridLayout06CellTiledConfig;
                    instance = 1;
                    break;

                case LayoutTemplates.GridLayout09CellTiled:
                    elementName = Strings.ResourceGridLayout09CellTiledConfig;
                    instance = 1;
                    break;

                default:
                    throw new InvalidEnumArgumentException("LayoutDialog:: No such type item");
            }

            foreach (ListViewItem i in this.Controls.SelectALayoutTemplateListView.Items)
            {
                if (ProductSku.Sku == ProductSkuLevel.Mom)
                {
                    if (i.ScreenElement.FindAllDescendants(-1, ";[UIA]Name=\'" + elementName + "\'", null).Count > 0)
                    {
                        i.Select();
                        break;
                    }
                }
                else
                {
                    Utilities.LogMessage("elementName instance: " + instance);                    
                    Window list = new Window(this.Controls.SelectALayoutTemplateListView, new QID(";[UIA]Name=\'Microsoft.EnterpriseManagement.Management.Transport.ComponentRegistry.TransportComponentType\' && Instance = \'" + instance + "\'"), Core.Common.Constants.DefaultDialogTimeout);                   
                    list.ScreenElement.LeftButtonClick(-1, -1);
                }   
            }

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
            /// Contains resource string for SpecifyTheLayoutOfTheDashboardComboBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheLayoutOfTheDashboardComboBox = ";[UIA]AutomationId=\'FolderComboBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectALayoutTemplateListView query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectALayoutTemplateListView = ";[UIA]AutomationId=\'ComponentTypeListBox\'";

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
            /// Gets access to the SpecifyTheLayoutOfTheDashboardComboBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SpecifyTheLayoutOfTheDashboardComboBox
            {
                get
                {
                    return new QID(ResourceSpecifyTheLayoutOfTheDashboardComboBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectALayoutTemplateListView resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 1/5/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectALayoutTemplateListView
            {
                get
                {
                    return new QID(ResourceSelectALayoutTemplateListView);
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
            /// <remark>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrientationPane = "OrientationPane";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = "< Previous";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = "Next >";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = "Finish";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscove" +
                "ry.AdvancedDiscoverySettingsDialog;cancelButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout01CellFillConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout01CellFillConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout01CellFillConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout02CellSplitHorizontalConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout02CellSplitHorizontalConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout02CellSplitHorizontalConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout02CellSplitVerticalConfig
            /// </summar/>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout02CellSplitVerticalConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout02CellSplitVerticalConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout03CellStackConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout03CellStackConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout03CellStackConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout03CellBigTopConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout03CellBigTopConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout03CellBigTopConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout03CellBigLeftConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout03CellBigLeftConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout03CellBigLeftConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout03CellBigBottomConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout03CellBigBottomConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout03CellBigBottomConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout03CellBigRightConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout03CellBigRightConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout03CellBigRightConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout04CellBigBottomConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout04CellBigBottomConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout04CellBigBottomConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout04CellTiledConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout04CellTiledConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout04CellTiledConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout04CellBigLeftConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout04CellBigLeftConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout04CellBigLeftConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout04CellBigTopConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout04CellBigTopConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout04CellBigTopConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout04CellBigRightConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout04CellBigRightConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout04CellBigRightConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout05CellThreeBottomConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout05CellThreeBottomConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout05CellThreeBottomConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout05CellOneTopConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout05CellOneTopConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout05CellOneTopConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout05CellOneBottomConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout05CellOneBottomConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout05CellOneBottomConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout05CellThreeTopConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout05CellThreeTopConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout05CellThreeTopConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout06CellTiledConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout06CellTiledConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout06CellTiledConfig";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// name for GridLayout09CellTiledConfig
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceGridLayout09CellTiledConfig = "Microsoft.SystemCenter.Visualization.Library!GridLayout09CellTiledConfig";


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
                    if (cachedDialogTitle == null)
                    {
                        cachedDialogTitle =
                            MpResources.ConfigurationLibraryMp.GetLocalizedResource.CreateTemplateInstanceWizardTitle;
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
                        cachedTitleUpdateDialog = 
                            MpResources.ConfigurationLibraryMp.GetLocalizedResource.WizardDialogWithCustomPagesTitle;
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
            #endregion
        }

        public class LayoutTemplates
        {
            #region 1 view

            public const string GridLayout01CellFill = "GridLayout01CellFill";

            #endregion

            #region 2 views

            public const string GridLayout02CellSplitHorizontal = "GridLayout02CellSplitHorizontal";
            public const string GridLayout02CellSplitVertical = "GridLayout02CellSplitVertical";

            #endregion

            #region 3 views

            public const string GridLayout03CellStack = "GridLayout03CellStack";
            public const string GridLayout03CellBigTop = "GridLayout03CellBigTop";
            public const string GridLayout03CellBigLeft = "GridLayout03CellBigLeft";
            public const string GridLayout03CellBigBottom = "GridLayout03CellBigBottom";
            public const string GridLayout03CellBigRight = "GridLayout03CellBigRight";

            #endregion

            #region 4 views

            public const string GridLayout04CellBigBottom = "GridLayout04CellBigBottom";
            public const string GridLayout04CellTiled = "GridLayout04CellTiled";
            public const string GridLayout04CellBigLeft = "GridLayout04CellBigLeft";
            public const string GridLayout04CellBigTop = "GridLayout04CellBigTop";
            public const string GridLayout04CellBigRight = "GridLayout04CellBigRight";

            #endregion

            #region 5 views

            public const string GridLayout05CellThreeBottom = "GridLayout05CellThreeBottom";
            public const string GridLayout05CellOneTop = "GridLayout05CellOneTop";
            public const string GridLayout05CellOneBottom = "GridLayout05CellOneBottom";
            public const string GridLayout05CellThreeTop = "GridLayout05CellThreeTop";

            #endregion

            #region 6 views

            public const string GridLayout06CellTiled = "GridLayout06CellTiled";

            #endregion

            #region 9 views

            public const string GridLayout09CellTiled = "GridLayout09CellTiled";

            #endregion
        }
        #endregion
    }
}
