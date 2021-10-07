// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="LogNameDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
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
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;

    #region Interface Definition - ILogNameDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ILogNameDialogControls, for LogNameDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILogNameDialogControls
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
        /// Read-only property to access SpecifyTheEventLogToReadTheEventsFromStaticControl
        /// </summary>
        StaticControl SpecifyTheEventLogToReadTheEventsFromStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ComputerNameStaticControl
        /// </summary>
        StaticControl ComputerNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
        /// </summary>
        StaticControl ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectDestinationManagementPackTextBox
        /// </summary>
        TextBox SelectDestinationManagementPackTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LogNameStaticControl
        /// </summary>
        StaticControl LogNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox
        /// </summary>
        TextBox ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
        /// </summary>
        StaticControl SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
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
        /// Read-only property to access EventLogNameStaticControl
        /// </summary>
        StaticControl EventLogNameStaticControl
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Log Name" dialog of the Create Monitor Wizard.
    /// This class manages the advanced functions for the "Log Name" dialog
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class LogNameDialog : Dialog, ILogNameDialogControls
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
        /// Cache to hold a reference to SpecifyTheEventLogToReadTheEventsFromStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheEventLogToReadTheEventsFromStaticControl;

        /// <summary>
        /// Cache to hold a reference to ComputerNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe of type StaticControl
        /// </summary>
        private StaticControl cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe;

        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackTextBox of type TextBox
        /// </summary>
        private TextBox cachedSelectDestinationManagementPackTextBox;

        /// <summary>
        /// Cache to hold a reference to LogNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLogNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox of type TextBox
        /// </summary>
        private TextBox cachedExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox;

        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;

        /// <summary>
        /// Cache to hold a reference to SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to EventLogNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogNameStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of LogNameDialog of type App
        /// </param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public LogNameDialog(Mom.Test.UI.Core.Console.MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region ILogNameDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ILogNameDialogControls Controls
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
        ///  Routine to set/get the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectDestinationManagementPackText
        {
            get
            {
                return this.Controls.SelectDestinationManagementPackTextBox.Text;
            }

            set
            {
                this.Controls.SelectDestinationManagementPackTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ExpandTheFoldersAndSelectAMonitorTypeToCreate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExpandTheFoldersAndSelectAMonitorTypeToCreateText
        {
            get
            {
                return this.Controls.ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox.Text;
            }

            set
            {
                this.Controls.ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox.Text = value;
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
        Button ILogNameDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, LogNameDialog.ControlIDs.PreviousButton);
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
        Button ILogNameDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, LogNameDialog.ControlIDs.NextButton);
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
        Button ILogNameDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, LogNameDialog.ControlIDs.CreateButton);
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
        Button ILogNameDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, LogNameDialog.ControlIDs.CancelButton);
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
        StaticControl ILogNameDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, LogNameDialog.ControlIDs.MonitorTypeStaticControl);
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
        StaticControl ILogNameDialogControls.EventLogTypeStaticControl
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
        StaticControl ILogNameDialogControls.BuildEventExpressionStaticControl
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
        StaticControl ILogNameDialogControls.ConfigureHealthStaticControl
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
        StaticControl ILogNameDialogControls.ConfigureAlertsStaticControl
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
        StaticControl ILogNameDialogControls.KnowledgeStaticControl
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
        StaticControl ILogNameDialogControls.GeneralStaticControl
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
        ///  Exposes access to the SpecifyTheEventLogToReadTheEventsFromStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNameDialogControls.SpecifyTheEventLogToReadTheEventsFromStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheEventLogToReadTheEventsFromStaticControl == null))
                {
                    this.cachedSpecifyTheEventLogToReadTheEventsFromStaticControl = new StaticControl(this, LogNameDialog.ControlIDs.SpecifyTheEventLogToReadTheEventsFromStaticControl);
                }
                return this.cachedSpecifyTheEventLogToReadTheEventsFromStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNameDialogControls.ComputerNameStaticControl
        {
            get
            {
                if ((this.cachedComputerNameStaticControl == null))
                {
                    this.cachedComputerNameStaticControl = new StaticControl(this, LogNameDialog.ControlIDs.ComputerNameStaticControl);
                }
                return this.cachedComputerNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNameDialogControls.ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
        {
            get
            {
                if ((this.cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe == null))
                {
                    this.cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe = new StaticControl(this, LogNameDialog.ControlIDs.ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe);
                }
                return this.cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ILogNameDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, LogNameDialog.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ILogNameDialogControls.SelectDestinationManagementPackTextBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackTextBox == null))
                {
                    this.cachedSelectDestinationManagementPackTextBox = new TextBox(this, LogNameDialog.ControlIDs.SelectDestinationManagementPackTextBox);
                }
                return this.cachedSelectDestinationManagementPackTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LogNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNameDialogControls.LogNameStaticControl
        {
            get
            {
                if ((this.cachedLogNameStaticControl == null))
                {
                    this.cachedLogNameStaticControl = new StaticControl(this, LogNameDialog.ControlIDs.LogNameStaticControl);
                }
                return this.cachedLogNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ILogNameDialogControls.ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox
        {
            get
            {
                if ((this.cachedExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox == null))
                {
                    this.cachedExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox = new TextBox(this, LogNameDialog.ControlIDs.ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox);
                }
                return this.cachedExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ILogNameDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, LogNameDialog.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNameDialogControls.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
        {
            get
            {
                if ((this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta == null))
                {
                    this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta = new StaticControl(this, LogNameDialog.ControlIDs.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta);
                }
                return this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta;
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
        StaticControl ILogNameDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, LogNameDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNameDialogControls.EventLogNameStaticControl
        {
            get
            {
                if ((this.cachedEventLogNameStaticControl == null))
                {
                    this.cachedEventLogNameStaticControl = new StaticControl(this, LogNameDialog.ControlIDs.EventLogNameStaticControl);
                }
                return this.cachedEventLogNameStaticControl;
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
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>
        /// <param name="windowCaption">Wizard dialog title.</param>
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
            private const string ResourceDialogTitle = "Create Monitor Wizard";

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
            /// Contains resource string for:  SpecifyTheEventLogToReadTheEventsFrom
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheEventLogToReadTheEventsFrom = ";Specify the event log to read the events from;ManagedString;Microsoft.MOM.UI.Com" +
                "ponents.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EvtLogDataSou" +
                "rce;pageSectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputerName = ";Co&mputer name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;compNameLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe = @";Refer to a property of the target entity type that will be substituted during runtime. To use the local computer, leave the field blank.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;targetPropRefLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLogName = ";L&og name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.EvtLogDataSource;logNameLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs = ";Specify an event log name to read events from. You can browse to a computer to v" +
                "iew and select from available event logs.;ManagedString;Microsoft.MOM.UI.Compone" +
                "nts.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;" +
                "infoLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventLogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLogName = ";Event Log Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;$this.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: ApplicationLogName.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo: File bug to get resource string. 
            private const string ResourceApplicationLogName = "Application";    // ";Application;Win32String;gpresult.exe;283";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: SystemLogName.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo: File bug to get resource string. 
            private const string ResourceSystemLogName = "System";    // ";System;Win32String;gpresult.exe;281";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: SecurityLogName.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo: File bug to get resource string. 
            private const string ResourceSecurityLogName = "Security";  // ";Security;Win32String;gpresult.exe;282";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: MonadLogName.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo:Add the persistent id for this resource string.
            private const string ResourceMonadLogName = "MonadLog";

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
            /// Caches the translated resource string for:  SpecifyTheEventLogToReadTheEventsFrom
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheEventLogToReadTheEventsFrom;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputerName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLogName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventLogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLogName;

            /// <summary>
            /// Cache to hold a reference to ApplicationLogName
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedApplicationLogName;

            /// <summary>
            /// Cache to hold a reference to SystemLogName
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedSystemLogName;

            /// <summary>
            /// Cache to hold a reference to SecurityLogName
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedSecurityLogName;

            /// <summary>
            /// Cache to hold a reference to MonadLogName
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedMonadLogName;
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
            /// Exposes access to the SpecifyTheEventLogToReadTheEventsFrom translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheEventLogToReadTheEventsFrom
            {
                get
                {
                    if ((cachedSpecifyTheEventLogToReadTheEventsFrom == null))
                    {
                        cachedSpecifyTheEventLogToReadTheEventsFrom = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheEventLogToReadTheEventsFrom);
                    }
                    return cachedSpecifyTheEventLogToReadTheEventsFrom;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComputerName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComputerName
            {
                get
                {
                    if ((cachedComputerName == null))
                    {
                        cachedComputerName = CoreManager.MomConsole.GetIntlStr(ResourceComputerName);
                    }
                    return cachedComputerName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
            {
                get
                {
                    if ((cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe == null))
                    {
                        cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe = CoreManager.MomConsole.GetIntlStr(ResourceReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe);
                    }
                    return cachedReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LogName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LogName
            {
                get
                {
                    if ((cachedLogName == null))
                    {
                        cachedLogName = CoreManager.MomConsole.GetIntlStr(ResourceLogName);
                    }
                    return cachedLogName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
            {
                get
                {
                    if ((cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs == null))
                    {
                        cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs);
                    }
                    return cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs;
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
            /// Exposes access to the EventLogName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLogName
            {
                get
                {
                    if ((cachedEventLogName == null))
                    {
                        cachedEventLogName = CoreManager.MomConsole.GetIntlStr(ResourceEventLogName);
                    }
                    return cachedEventLogName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApplicationLogName translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApplicationLogName
            {
                get
                {
                    if ((cachedApplicationLogName == null))
                    {
                        cachedApplicationLogName = CoreManager.MomConsole.GetIntlStr(ResourceApplicationLogName);
                    }
                    return cachedApplicationLogName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemLogName translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemLogName
            {
                get
                {
                    if ((cachedSystemLogName == null))
                    {
                        cachedSystemLogName = CoreManager.MomConsole.GetIntlStr(ResourceSystemLogName);
                    }
                    return cachedSystemLogName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonadLogName translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonadLogName
            {
                get
                {
                    if ((cachedMonadLogName == null))
                    {
                        cachedMonadLogName = CoreManager.MomConsole.GetIntlStr(ResourceMonadLogName);
                    }
                    return cachedMonadLogName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SecurityLogName translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SecurityLogName
            {
                get
                {
                    if ((cachedSecurityLogName == null))
                    {
                        cachedSecurityLogName = CoreManager.MomConsole.GetIntlStr(ResourceSecurityLogName);
                    }
                    return cachedSecurityLogName;
                }
            }
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
            /// Control ID for SpecifyTheEventLogToReadTheEventsFromStaticControl
            /// </summary>
            public const string SpecifyTheEventLogToReadTheEventsFromStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for ComputerNameStaticControl
            /// </summary>
            public const string ComputerNameStaticControl = "compNameLabel";

            /// <summary>
            /// Control ID for ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe
            /// </summary>
            public const string ReferToAPropertyOfTheTargetEntityTypeThatWillBeSubstitutedDuringRuntimeToUseTheLocalComputerLeaveThe = "targetPropRefLabel";

            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "hostTypesButton";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackTextBox
            /// </summary>
            public const string SelectDestinationManagementPackTextBox = "computerNameTextBox";

            /// <summary>
            /// Control ID for LogNameStaticControl
            /// </summary>
            public const string LogNameStaticControl = "logNameLabel";

            /// <summary>
            /// Control ID for ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox
            /// </summary>
            public const string ExpandTheFoldersAndSelectAMonitorTypeToCreateTextBox = "logNameTextBox";

            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "browseButton";

            /// <summary>
            /// Control ID for SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
            /// </summary>
            public const string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta = "infoLabel";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for EventLogNameStaticControl
            /// </summary>
            public const string EventLogNameStaticControl = "headerLabel";
        }
        #endregion
    }
}
