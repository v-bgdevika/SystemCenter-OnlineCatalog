// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BuildExpressionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	Build Expression Rule Dialog which is included 
//  in several Wizards, such as Create Rule Wizard and Create Monitor Wizard.
// </summary>
// <history>
// 	[ruhim] 3/12/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IBuildExpressionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBuildExpressionDialogControls, for BuildExpressionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBuildExpressionDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
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

        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MonitorTypeStaticControl
        /// </summary>
        StaticControl MonitorTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EventLogTypeStaticControl
        /// </summary>
        StaticControl EventLogTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BuildEventExpressionStaticControl
        /// </summary>
        StaticControl BuildEventExpressionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConfigureHealthStaticControl
        /// </summary>
        StaticControl ConfigureHealthStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access KnowledgeStaticControl
        /// </summary>
        StaticControl KnowledgeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterOneOrMoreEventsStaticControl
        /// </summary>
        StaticControl FilterOneOrMoreEventsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BuildTheExpressionToFilterOneOrMoreEventsStaticControl
        /// </summary>
        StaticControl BuildTheExpressionToFilterOneOrMoreEventsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FormulaGrid
        /// </summary>
        PropertyGridView FormulaGrid
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ManagementPackTextBox
        /// </summary>
        TextBox ManagementPackTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FormulaToolStrip
        /// </summary>
        Toolbar FormulaToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BuildEventExpressionStaticControl2
        /// </summary>
        StaticControl BuildEventExpressionStaticControl2
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Expression query builder, "Build Expression" dialog.
    /// This class manages the advanced functions for build expression queries.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BuildExpressionDialog : Dialog, IBuildExpressionDialogControls
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
        /// Cache to hold a reference to MonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to EventLogTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to BuildEventExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventExpressionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;

        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;

        /// <summary>
        /// Cache to hold a reference to KnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKnowledgeStaticControl;

        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;

        /// <summary>
        /// Cache to hold a reference to FilterOneOrMoreEventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterOneOrMoreEventsStaticControl;

        /// <summary>
        /// Cache to hold a reference to BuildTheExpressionToFilterOneOrMoreEventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildTheExpressionToFilterOneOrMoreEventsStaticControl;

        /// <summary>
        /// Cache to hold a reference to FormulaGrid of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedFormulaGrid;

        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;

        /// <summary>
        /// Cache to hold a reference to ManagementPackTextBox of type TextBox
        /// </summary>
        private TextBox cachedManagementPackTextBox;

        /// <summary>
        /// Cache to hold a reference to FormulaToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedFormulaToolStrip;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to BuildEventExpressionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventExpressionStaticControl2;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of BuildExpressionDialog of type App
        /// </param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public BuildExpressionDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region IBuildExpressionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBuildExpressionDialogControls Controls
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
        ///  Routine to set/get the text in control ManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackText
        {
            get
            {
                return this.Controls.ManagementPackTextBox.Text;
            }

            set
            {
                this.Controls.ManagementPackTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildExpressionDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, BuildExpressionDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildExpressionDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, BuildExpressionDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildExpressionDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, BuildExpressionDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildExpressionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, BuildExpressionDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, BuildExpressionDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.EventLogTypeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventLogTypeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedEventLogTypeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventLogTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.BuildEventExpressionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBuildEventExpressionStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedBuildEventExpressionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedBuildEventExpressionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedConfigureHealthStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureHealthStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureAlertsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KnowledgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.KnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedKnowledgeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedKnowledgeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterOneOrMoreEventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.FilterOneOrMoreEventsStaticControl
        {
            get
            {
                if ((this.cachedFilterOneOrMoreEventsStaticControl == null))
                {
                    this.cachedFilterOneOrMoreEventsStaticControl = new StaticControl(this, BuildExpressionDialog.ControlIDs.FilterOneOrMoreEventsStaticControl);
                }
                return this.cachedFilterOneOrMoreEventsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildTheExpressionToFilterOneOrMoreEventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.BuildTheExpressionToFilterOneOrMoreEventsStaticControl
        {
            get
            {
                if ((this.cachedBuildTheExpressionToFilterOneOrMoreEventsStaticControl == null))
                {
                    this.cachedBuildTheExpressionToFilterOneOrMoreEventsStaticControl = new StaticControl(this, BuildExpressionDialog.ControlIDs.BuildTheExpressionToFilterOneOrMoreEventsStaticControl);
                }
                return this.cachedBuildTheExpressionToFilterOneOrMoreEventsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaGrid control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IBuildExpressionDialogControls.FormulaGrid
        {
            get
            {
                if ((this.cachedFormulaGrid == null))
                {
                    this.cachedFormulaGrid = new PropertyGridView(this, BuildExpressionDialog.ControlIDs.FormulaGrid);
                }
                return this.cachedFormulaGrid;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildExpressionDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, BuildExpressionDialog.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IBuildExpressionDialogControls.ManagementPackTextBox
        {
            get
            {
                if ((this.cachedManagementPackTextBox == null))
                {
                    this.cachedManagementPackTextBox = new TextBox(this, BuildExpressionDialog.ControlIDs.ManagementPackTextBox);
                }
                return this.cachedManagementPackTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaToolStrip control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        ///     [a-joelj]   06OCT09 Maui 2.0 Required Change: Calling the Toolbar constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IBuildExpressionDialogControls.FormulaToolStrip
        {
            get
            {
                if ((this.cachedFormulaToolStrip == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the Toolbar constructor with 'this' being the only parameter 
                    // is returning the wrong toolbar. There is no caption/name defined for these toolbars therefore we cannot call the 
                    // constructor with the caption/name. Switching over to the UIA tree and using a QID with the AutomationId.

                    QID queryId = new QID(";[UIA]AutomationId='" + BuildExpressionDialog.ControlIDs.IntermediateElementPagePanel + "';[UIA]AutomationId='" + BuildExpressionDialog.ControlIDs.IntermediateElementFormulaBuilderControl + "';[UIA]AutomationId='" + BuildExpressionDialog.ControlIDs.FormulaToolStrip + "' && Role='tool bar'");

                    this.cachedFormulaToolStrip = new Toolbar(this, queryId, Constants.DefaultContextMenuTimeout * 3); //this.cachedFormulaToolStrip = new Toolbar(this);
                }
                return this.cachedFormulaToolStrip;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, BuildExpressionDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventExpressionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionDialogControls.BuildEventExpressionStaticControl2
        {
            get
            {
                if ((this.cachedBuildEventExpressionStaticControl2 == null))
                {
                    this.cachedBuildEventExpressionStaticControl2 = new StaticControl(this, BuildExpressionDialog.ControlIDs.BuildEventExpressionStaticControl2);
                }
                return this.cachedBuildEventExpressionStaticControl2;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
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
        /// 	[ruhim] 3/12/2006 Created
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
        /// 	[ruhim] 3/12/2006 Created
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
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <param name="windowCaption">dialog title</param>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
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
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLogType = ";Event Log Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventExpression = ";Build Event Expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvaluatorCondition;$this.N" +
                "avigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledge = ";Knowledge;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.MonitorKnowledgePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterOneOrMoreEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterOneOrMoreEvents = ";Filter one or more events;ManagedString;Microsoft.MOM.UI.Components.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvaluatorCondition;page" +
                "SectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildTheExpressionToFilterOneOrMoreEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildTheExpressionToFilterOneOrMoreEvents = ";Build the expression to filter one or more events:;ManagedString;Microsoft.MOM.U" +
                "I.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Expressi" +
                "onEvaluatorCondition;expressionPageLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FormulaGrid
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaGrid = ";FormulaGrid;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl;formulaGrid." +
                "Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";>;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.I" +
                "nternal.UI.Controls.FormulaBuilder.TextBoxAndButton;button.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventExpression2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventExpression2 = ";Build Event Expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvaluatorCondition;$this.N" +
                "avigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridPropertyColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridPropertyColumn =
                ";Value Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGrid.resources;dataGridViewTextBoxColumn1.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridOperatorColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridOperatorColumn =
                ";Operator;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGrid.resources;dataGridViewTextBoxColumn2.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridValueColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridValueColumn =
                ";Value;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGrid.resources;dataGridViewTextBoxColumn3.HeaderText";

             /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridParameterNameColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridParameterNameColumn =
                ";Parameter Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;ParamName";

            #region formulaToolStrip

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripInsert.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripInsert = ";In&sert;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl.resources;insertButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripInsertExpression.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripInsertExpression = ";&Insert Expression;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Controls.FormulaBuilder.RowContextMenuStrip;MenuInsertExpression";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripInsertAndGroup.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripInsertAndGroup = ";In&sert And group;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Controls.FormulaBuilder.RowContextMenuStrip;MenuInsertAndGroup";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripInsertOrGroup.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripInsertOrGroup = ";Insert Or Gro&up;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Controls.FormulaBuilder.RowContextMenuStrip;MenuInsertOrGroup";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripDelete.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripDelete = ";&Delete;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl.resources;deleteButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripFormula.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripFormula = ";F&ormula;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl.resources;previewButton.Text";

            #endregion

            #region Event Property Name Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Event Source.
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceEventSource =
                ";Event Source;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;PublisherName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Event ID.
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceEventID =
                ";Event ID;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;EventDisplayNumber";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: EventNumber.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventNumber = ";Event Number;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;EventDisplayNumber";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: EventPublisherName.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventPublisherName = ";Event Publisher Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;PublisherName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: EventGuid.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventGuid = ";Event Guid;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;EventOriginId";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Description.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;EventDescription";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: EventLevel.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLevel = ";Event Level;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;EventLevel";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: PublisherGuid.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourcePublisherGuid = ";Publisher Guid;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;PublisherId";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: FullEventNumber.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFullEventNumber = ";Full Event Number;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;Number";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: EventCategory.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventCategory = ";Event Category;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;Category";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: LoggingComputer.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceLoggingComputer = ";Logging Computer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;LoggingComputer";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Logname/Channel.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceLognameChannel = ";Logname/Channel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;Channel";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: User.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceUser = ";User;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.EventView;User";

            #endregion

            #region Operator Expression Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// Contains resource string for: Equality.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceEquality = ";Equals;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorEquals";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: NotEquals.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotEquals =
                ";Does not equal;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorNotEquals";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Contains.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceContains = ";Contains;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorContains";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: NotContains.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotContains = ";Not contains;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorNotContains";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GreaterThan.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceGreaterThan = ";Greater than;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorGreaterThan";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: LessThan.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceLessThan = ";Less than;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorLessThan";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GreaterThanOrEqualTo.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceGreaterThanOrEqualTo = ";Greater than or equal to;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorGreaterThanOrEqualTo";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: LessThanOrEqualTo.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceLessThanOrEqualTo = ";Less than or equal to;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorLessThanOrEqualTo";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: MatchesWildcard.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchesWildcard = ";Matches wildcard;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorMatchesWildCard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: NotMatchesWildcard.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotMatchesWildcard = ";Not matches wildcard;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorNotMatchesWildCard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: MatchesRegularExpression.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchesRegularExpression = ";Matches regular expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorMatchesRegularExpression";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: NotMatchesRegularExpression.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotMatchesRegularExpression = ";Not matches regular expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGridResources.resources;OperatorNotMatchesRegularExpression";

            #endregion

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLogType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventExpression;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKnowledge;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterOneOrMoreEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterOneOrMoreEvents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildTheExpressionToFilterOneOrMoreEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildTheExpressionToFilterOneOrMoreEvents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FormulaGrid
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormulaGrid;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventExpression2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventExpression2;

            /// <summary>
            /// Cache to hold a reference to GridPropertyColumn
            /// </summary>
            private static string cachedGridPropertyColumn;

            /// <summary>
            /// Cache to hold a reference to GridOperatorColumn
            /// </summary>
            private static string cachedGridOperatorColumn;

            /// <summary>
            /// Cache to hold a reference to GridValueColumn
            /// </summary>
            private static string cachedGridValueColumn;

            /// <summary>
            /// Cache to hold a reference to GridParameterNameColumn
            /// </summary>
            private static string cachedGridParameterNameColumn;

            #region Event Property Names Private Members
            
            /// <summary>
            /// Cache to hold a reference to Event Source
            /// </summary>
            private static string cachedEventSource;

            /// <summary>
            /// Cache to hold a reference to Event ID
            /// </summary>
            private static string cachedEventID;

            /// <summary>
            /// Cache to hold a reference to EventNumber
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedEventNumber;

            /// <summary>
            /// Cache to hold a reference to EventPublisherName
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedEventPublisherName;

            /// <summary>
            /// Cache to hold a reference to EventGuid
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedEventGuid;

            /// <summary>
            /// Cache to hold a reference to Description
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedDescription;

            /// <summary>
            /// Cache to hold a reference to EventCategory
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedEventCategory;

            /// <summary>
            /// Cache to hold a reference to EventLevel
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedEventLevel;

            /// <summary>
            /// Cache to hold a reference to FullEventNumber
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedFullEventNumber;

            /// <summary>
            /// Cache to hold a reference to LoggingComputer
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedLoggingComputer;

            /// <summary>
            /// Cache to hold a reference to LognameChannel
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedLognameChannel;

            /// <summary>
            /// Cache to hold a reference to PublisherGuid
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedPublisherGuid;

            /// <summary>
            /// Cache to hold a reference to User
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedUser;

            #endregion

            #region formulaToolStrip

            /// <summary>
            /// Cache to hold a reference to formulaToolStripInsert
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedFormulaToolStripInsert;

            /// <summary>
            /// Cache to hold a reference to formulaToolStripInsertAndGroup
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedFormulaToolStripInsertAndGroup;

            /// <summary>
            /// Cache to hold a reference to formulaToolStripInsertOrGroup
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedFormulaToolStripInsertOrGroup;

            /// <summary>
            /// Cache to hold a reference to formulaToolStripDelete
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedFormulaToolStripDelete;

            /// <summary>
            /// Cache to hold a reference to formulaToolStripFormula
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedFormulaToolStripFormula;

            #endregion

            #region Operator expressions
            /// <summary>
            /// Cache to hold a reference to Equality
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedEquality;

            /// <summary>
            /// Cache to hold a reference to NotEquals
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedNotEquals;

            /// <summary>
            /// Cache to hold a reference to Contains
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedContains;

            /// <summary>
            /// Cache to hold a reference to NotContains
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedNotContains;

            /// <summary>
            /// Cache to hold a reference to GreaterThan
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedGreaterThan;

            /// <summary>
            /// Cache to hold a reference to LessThan
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedLessThan;

            /// <summary>
            /// Cache to hold a reference to GreaterThanOrEqualTo
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedGreaterThanOrEqualTo;

            /// <summary>
            /// Cache to hold a reference to LessThanOrEqualTo
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedLessThanOrEqualTo;

            /// <summary>
            /// Cache to hold a reference to MatchesWildcard
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedMatchesWildcard;

            /// <summary>
            /// Cache to hold a reference to NotMatchesWildcard
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedNotMatchesWildcard;

            /// <summary>
            /// Cache to hold a reference to MatchesRegularExpression
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedMatchesRegularExpression;

            /// <summary>
            /// Cache to hold a reference to NotMatchesRegularExpression
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedNotMatchesRegularExpression;

            #endregion

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
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
            /// 	[ruhim] 3/12/2006 Created
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
            /// 	[ruhim] 3/12/2006 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
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
            /// Exposes access to the MonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorType
            {
                get
                {
                    if ((cachedMonitorType == null))
                    {
                        cachedMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceMonitorType);
                    }
                    return cachedMonitorType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventLogType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLogType
            {
                get
                {
                    if ((cachedEventLogType == null))
                    {
                        cachedEventLogType = CoreManager.MomConsole.GetIntlStr(ResourceEventLogType);
                    }
                    return cachedEventLogType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventExpression translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventExpression
            {
                get
                {
                    if ((cachedBuildEventExpression == null))
                    {
                        cachedBuildEventExpression = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventExpression);
                    }
                    return cachedBuildEventExpression;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth
            {
                get
                {
                    if ((cachedConfigureHealth == null))
                    {
                        cachedConfigureHealth = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth);
                    }
                    return cachedConfigureHealth;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    return cachedConfigureAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Knowledge translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Knowledge
            {
                get
                {
                    if ((cachedKnowledge == null))
                    {
                        cachedKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceKnowledge);
                    }
                    return cachedKnowledge;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    return cachedGeneral;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterOneOrMoreEvents translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterOneOrMoreEvents
            {
                get
                {
                    if ((cachedFilterOneOrMoreEvents == null))
                    {
                        cachedFilterOneOrMoreEvents = CoreManager.MomConsole.GetIntlStr(ResourceFilterOneOrMoreEvents);
                    }
                    return cachedFilterOneOrMoreEvents;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildTheExpressionToFilterOneOrMoreEvents translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildTheExpressionToFilterOneOrMoreEvents
            {
                get
                {
                    if ((cachedBuildTheExpressionToFilterOneOrMoreEvents == null))
                    {
                        cachedBuildTheExpressionToFilterOneOrMoreEvents = CoreManager.MomConsole.GetIntlStr(ResourceBuildTheExpressionToFilterOneOrMoreEvents);
                    }
                    return cachedBuildTheExpressionToFilterOneOrMoreEvents;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FormulaGrid translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaGrid
            {
                get
                {
                    if ((cachedFormulaGrid == null))
                    {
                        cachedFormulaGrid = CoreManager.MomConsole.GetIntlStr(ResourceFormulaGrid);
                    }
                    return cachedFormulaGrid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    return cachedAdd;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventExpression2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventExpression2
            {
                get
                {
                    if ((cachedBuildEventExpression2 == null))
                    {
                        cachedBuildEventExpression2 = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventExpression2);
                    }
                    return cachedBuildEventExpression2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GridPropertyColumn translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 16NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GridPropertyColumn
            {
                get
                {
                    if ((cachedGridPropertyColumn == null))
                    {
                        cachedGridPropertyColumn = CoreManager.MomConsole.GetIntlStr(ResourceGridPropertyColumn);
                    }
                    return cachedGridPropertyColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GridOperatorColumn translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 16NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GridOperatorColumn
            {
                get
                {
                    if ((cachedGridOperatorColumn == null))
                    {
                        cachedGridOperatorColumn = CoreManager.MomConsole.GetIntlStr(ResourceGridOperatorColumn);
                    }
                    return cachedGridOperatorColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GridValueColumn translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 16NOV05 Created (using snippet)
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GridValueColumn
            {
                get
                {
                    if ((cachedGridValueColumn == null))
                    {
                        cachedGridValueColumn = CoreManager.MomConsole.GetIntlStr(ResourceGridValueColumn);
                    }
                    return cachedGridValueColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GridParameterNameColumn translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 16April07 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GridParameterNameColumn
            {
                get
                {
                    if ((cachedGridParameterNameColumn == null))
                    {
                        cachedGridParameterNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceGridParameterNameColumn);
                    }
                    return cachedGridParameterNameColumn;
                }
            }

            #region Event Property Names Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Source translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 16April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventSource
            {
                get
                {
                    if ((cachedEventSource == null))
                    {
                        cachedEventSource = CoreManager.MomConsole.GetIntlStr(ResourceEventSource);
                    }
                    return cachedEventSource;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event ID translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 16April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventID
            {
                get
                {
                    if ((cachedEventID == null))
                    {
                        cachedEventID = CoreManager.MomConsole.GetIntlStr(ResourceEventID);
                    }
                    return cachedEventID;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventNumber translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 21NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventNumber
            {
                get
                {
                    if ((cachedEventNumber == null))
                    {
                        cachedEventNumber = CoreManager.MomConsole.GetIntlStr(ResourceEventNumber);
                    }
                    return cachedEventNumber;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventPublisherName translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventPublisherName
            {
                get
                {
                    if ((cachedEventPublisherName == null))
                    {
                        cachedEventPublisherName = CoreManager.MomConsole.GetIntlStr(ResourceEventPublisherName);
                    }
                    return cachedEventPublisherName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventGuid translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventGuid
            {
                get
                {
                    if ((cachedEventGuid == null))
                    {
                        cachedEventGuid = CoreManager.MomConsole.GetIntlStr(ResourceEventGuid);
                    }
                    return cachedEventGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    return cachedDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventCategory translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventCategory
            {
                get
                {
                    if ((cachedEventCategory == null))
                    {
                        cachedEventCategory = CoreManager.MomConsole.GetIntlStr(ResourceEventCategory);
                    }
                    return cachedEventCategory;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventLevel translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLevel
            {
                get
                {
                    if ((cachedEventLevel == null))
                    {
                        cachedEventLevel = CoreManager.MomConsole.GetIntlStr(ResourceEventLevel);
                    }
                    return cachedEventLevel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FullEventNumber translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FullEventNumber
            {
                get
                {
                    if ((cachedFullEventNumber == null))
                    {
                        cachedFullEventNumber = CoreManager.MomConsole.GetIntlStr(ResourceFullEventNumber);
                    }
                    return cachedFullEventNumber;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LoggingComputer translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LoggingComputer
            {
                get
                {
                    if ((cachedLoggingComputer == null))
                    {
                        cachedLoggingComputer = CoreManager.MomConsole.GetIntlStr(ResourceLoggingComputer);
                    }
                    return cachedLoggingComputer;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LognameChannel translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LognameChannel
            {
                get
                {
                    if ((cachedLognameChannel == null))
                    {
                        cachedLognameChannel = CoreManager.MomConsole.GetIntlStr(ResourceLognameChannel);
                    }
                    return cachedLognameChannel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PublisherGuid translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PublisherGuid
            {
                get
                {
                    if ((cachedPublisherGuid == null))
                    {
                        cachedPublisherGuid = CoreManager.MomConsole.GetIntlStr(ResourcePublisherGuid);
                    }
                    return cachedPublisherGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the User translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 28NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string User
            {
                get
                {
                    if ((cachedUser == null))
                    {
                        cachedUser = CoreManager.MomConsole.GetIntlStr(ResourceUser);
                    }
                    return cachedUser;
                }
            }

            #endregion

            #region FormulaToolStrip

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the formulaToolStripInsert translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 01DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaToolStripInsert
            {
                get
                {
                    if ((cachedFormulaToolStripInsert == null))
                    {
                        cachedFormulaToolStripInsert = CoreManager.MomConsole.GetIntlStr(ResourceFormulaToolStripInsert);
                    }
                    return cachedFormulaToolStripInsert;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the formulaToolStripInsertAndGroup translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 01DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaToolStripInsertAndGroup
            {
                get
                {
                    if ((cachedFormulaToolStripInsertAndGroup == null))
                    {
                        cachedFormulaToolStripInsertAndGroup = CoreManager.MomConsole.GetIntlStr(ResourceFormulaToolStripInsertAndGroup);
                    }
                    return cachedFormulaToolStripInsertAndGroup;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the formulaToolStripInsertOrGroup translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 01DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaToolStripInsertOrGroup
            {
                get
                {
                    if ((cachedFormulaToolStripInsertOrGroup == null))
                    {
                        cachedFormulaToolStripInsertOrGroup = CoreManager.MomConsole.GetIntlStr(ResourceFormulaToolStripInsertOrGroup);
                    }
                    return cachedFormulaToolStripInsertOrGroup;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FormulaToolStripDelete translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaToolStripDelete
            {
                get
                {
                    if ((cachedFormulaToolStripDelete == null))
                    {
                        cachedFormulaToolStripDelete = CoreManager.MomConsole.GetIntlStr(ResourceFormulaToolStripDelete);
                    }
                    return cachedFormulaToolStripDelete;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FormulaToolStripFormula translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 01DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaToolStripFormula
            {
                get
                {
                    if ((cachedFormulaToolStripFormula == null))
                    {
                        cachedFormulaToolStripFormula = CoreManager.MomConsole.GetIntlStr(ResourceFormulaToolStripFormula);
                    }
                    return cachedFormulaToolStripFormula;
                }
            }

            #endregion

            #region Operator Expressions

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Equality translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Equality
            {
                get
                {
                    if ((cachedEquality == null))
                    {
                        cachedEquality = CoreManager.MomConsole.GetIntlStr(ResourceEquality);
                    }
                    return cachedEquality;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotEquals translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotEquals
            {
                get
                {
                    if ((cachedNotEquals == null))
                    {
                        cachedNotEquals = CoreManager.MomConsole.GetIntlStr(ResourceNotEquals);
                    }
                    return cachedNotEquals;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GreaterThan translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GreaterThan
            {
                get
                {
                    if ((cachedGreaterThan == null))
                    {
                        cachedGreaterThan = CoreManager.MomConsole.GetIntlStr(ResourceGreaterThan);
                    }
                    return cachedGreaterThan;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GreaterThanOrEqualTo translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GreaterThanOrEqualTo
            {
                get
                {
                    if ((cachedGreaterThanOrEqualTo == null))
                    {
                        cachedGreaterThanOrEqualTo = CoreManager.MomConsole.GetIntlStr(ResourceGreaterThanOrEqualTo);
                    }
                    return cachedGreaterThanOrEqualTo;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LessThan translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessThan
            {
                get
                {
                    if ((cachedLessThan == null))
                    {
                        cachedLessThan = CoreManager.MomConsole.GetIntlStr(ResourceLessThan);
                    }
                    return cachedLessThan;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LessThanOrEqualTo translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessThanOrEqualTo
            {
                get
                {
                    if ((cachedLessThanOrEqualTo == null))
                    {
                        cachedLessThanOrEqualTo = CoreManager.MomConsole.GetIntlStr(ResourceLessThanOrEqualTo);
                    }
                    return cachedLessThanOrEqualTo;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Contains translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Contains
            {
                get
                {
                    if ((cachedContains == null))
                    {
                        cachedContains = CoreManager.MomConsole.GetIntlStr(ResourceContains);
                    }
                    return cachedContains;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotContains translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotContains
            {
                get
                {
                    if ((cachedNotContains == null))
                    {
                        cachedNotContains = CoreManager.MomConsole.GetIntlStr(ResourceNotContains);
                    }
                    return cachedNotContains;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MatchesWildcard translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchesWildcard
            {
                get
                {
                    if ((cachedMatchesWildcard == null))
                    {
                        cachedMatchesWildcard = CoreManager.MomConsole.GetIntlStr(ResourceMatchesWildcard);
                    }
                    return cachedMatchesWildcard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotMatchesWildcard translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotMatchesWildcard
            {
                get
                {
                    if ((cachedNotMatchesWildcard == null))
                    {
                        cachedNotMatchesWildcard = CoreManager.MomConsole.GetIntlStr(ResourceNotMatchesWildcard);
                    }
                    return cachedNotMatchesWildcard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MatchesRegularExpression translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchesRegularExpression
            {
                get
                {
                    if ((cachedMatchesRegularExpression == null))
                    {
                        cachedMatchesRegularExpression = CoreManager.MomConsole.GetIntlStr(ResourceMatchesRegularExpression);
                    }
                    return cachedMatchesRegularExpression;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotMatchesRegularExpression translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 02DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotMatchesRegularExpression
            {
                get
                {
                    if ((cachedNotMatchesRegularExpression == null))
                    {
                        cachedNotMatchesRegularExpression = CoreManager.MomConsole.GetIntlStr(ResourceNotMatchesRegularExpression);
                    }
                    return cachedNotMatchesRegularExpression;
                }
            }

            #endregion

            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for MonitorTypeStaticControl
            /// </summary>
            public const string MonitorTypeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for EventLogTypeStaticControl
            /// </summary>
            public const string EventLogTypeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for BuildEventExpressionStaticControl
            /// </summary>
            public const string BuildEventExpressionStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for KnowledgeStaticControl
            /// </summary>
            public const string KnowledgeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for FilterOneOrMoreEventsStaticControl
            /// </summary>
            public const string FilterOneOrMoreEventsStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for BuildTheExpressionToFilterOneOrMoreEventsStaticControl
            /// </summary>
            public const string BuildTheExpressionToFilterOneOrMoreEventsStaticControl = "expressionPageLabel";

            /// <summary>
            /// Control ID for FormulaGrid
            /// </summary>
            public const string FormulaGrid = "formulaGrid";

            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "button";

            /// <summary>
            /// Control ID for ManagementPackTextBox
            /// </summary>
            public const string ManagementPackTextBox = "textbox";

            /// <summary>
            /// Control ID for FormulaToolStrip
            /// </summary>
            public const string FormulaToolStrip = "formulaMenu";

            /// <summary>
            /// Control ID for IntermediateElementpagePanel
            /// </summary>
            public const string IntermediateElementPagePanel = "pagePanel";

            /// <summary>
            /// Control ID for IntermediateElementFormulaBuilderControl
            /// </summary>
            public const string IntermediateElementFormulaBuilderControl = "formulaBuilderControl";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for BuildEventExpressionStaticControl2
            /// </summary>
            public const string BuildEventExpressionStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
