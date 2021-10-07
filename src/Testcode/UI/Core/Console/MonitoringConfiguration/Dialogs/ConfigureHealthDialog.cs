// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfigureHealthDialog.cs">
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

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    #region Using directive
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.MomControls;
    #endregion


    #region Interface Definition - IConfigureHealthDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfigureHealthDialogControls, for ConfigureHealthDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfigureHealthDialogControls
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
        /// Read-only property to access MapMonitorConditionsToHealthStatesStaticControl
        /// </summary>
        StaticControl MapMonitorConditionsToHealthStatesStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DataGridView1
        /// </summary>
        PropertyGridView DataGridView1
        {
            get;
        }

        /// Health state data grid
        /// </summary>
        GridControl StatesGridView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
        /// </summary>
        StaticControl SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
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
        /// Read-only property to access ConfigureHealthStaticControl2
        /// </summary>
        StaticControl ConfigureHealthStaticControl2
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Configure Health" dialog of the Create a Monitor Wizard.
    /// This class manages the advanced functions for the "Configure Health" dialog
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfigureHealthDialog : Dialog, IConfigureHealthDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Public Constants
        public const int MonitorConditionColumnIndex = 0;
        public const int OperationalStateColumnIndex = 1;
        public const int HealthStateColumnIndex = 2;

        public const string FirstRaised = "First *";
        public const string SecondRaised = "Second *";
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
        /// Cache to hold a reference to MapMonitorConditionsToHealthStatesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMapMonitorConditionsToHealthStatesStaticControl;

        /// <summary>
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;

        /// <summary>
        /// Cache to hold a reference to StatesGridView
        /// </summary>
        private GridControl cachedStatesGridView;

        /// <summary>
        /// Cache to hold a reference to SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl2;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfigureHealthDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfigureHealthDialog(Maui.Core.App app)
            :
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region IConfigureHealthDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfigureHealthDialogControls Controls
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
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureHealthDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConfigureHealthDialog.ControlIDs.PreviousButton);
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
        Button IConfigureHealthDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConfigureHealthDialog.ControlIDs.NextButton);
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
        Button IConfigureHealthDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ConfigureHealthDialog.ControlIDs.CreateButton);
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
        Button IConfigureHealthDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfigureHealthDialog.ControlIDs.CancelButton);
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
        StaticControl IConfigureHealthDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, ConfigureHealthDialog.ControlIDs.MonitorTypeStaticControl);
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
        StaticControl IConfigureHealthDialogControls.EventLogTypeStaticControl
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
        StaticControl IConfigureHealthDialogControls.BuildEventExpressionStaticControl
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
        StaticControl IConfigureHealthDialogControls.ConfigureHealthStaticControl
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
        StaticControl IConfigureHealthDialogControls.ConfigureAlertsStaticControl
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
        StaticControl IConfigureHealthDialogControls.KnowledgeStaticControl
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
        StaticControl IConfigureHealthDialogControls.GeneralStaticControl
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
        ///  Exposes access to the MapMonitorConditionsToHealthStatesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureHealthDialogControls.MapMonitorConditionsToHealthStatesStaticControl
        {
            get
            {
                if ((this.cachedMapMonitorConditionsToHealthStatesStaticControl == null))
                {
                    this.cachedMapMonitorConditionsToHealthStatesStaticControl = new StaticControl(this, ConfigureHealthDialog.ControlIDs.MapMonitorConditionsToHealthStatesStaticControl);
                }
                return this.cachedMapMonitorConditionsToHealthStatesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31/12/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        GridControl IConfigureHealthDialogControls.StatesGridView
        {
            get
            {
                if (this.cachedStatesGridView == null)
                {
                    this.cachedStatesGridView = new GridControl(this, ConfigureHealthDialog.ControlIDs.DataGridView1);
                }
                return this.cachedStatesGridView;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IConfigureHealthDialogControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, ConfigureHealthDialog.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureHealthDialogControls.SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
        {
            get
            {
                if ((this.cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl == null))
                {
                    this.cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl = new StaticControl(this, ConfigureHealthDialog.ControlIDs.SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl);
                }
                return this.cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl;
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
        StaticControl IConfigureHealthDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConfigureHealthDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureHealthDialogControls.ConfigureHealthStaticControl2
        {
            get
            {
                if ((this.cachedConfigureHealthStaticControl2 == null))
                {
                    this.cachedConfigureHealthStaticControl2 = new StaticControl(this, ConfigureHealthDialog.ControlIDs.ConfigureHealthStaticControl2);
                }
                return this.cachedConfigureHealthStaticControl2;
            }
        }
        #endregion

        #region Control Methods

        /// <summary>
        /// Set health state specified by event raised
        /// </summary>
        /// <param name="healthState">health state</param>
        /// <param name="whichEvent">value of FirstEventRaised, SecondEventRaised</param>
        public void SetHealthState(string healthState, TrapOrProbeRaised whichEvent)
        {
            int rowPos = GetRowIndex(whichEvent);

            this.Controls.StatesGridView.SetCellOption(this.Controls.StatesGridView.Rows[rowPos].Cells[HealthStateColumnIndex], healthState);
        }

        /// <summary>
        /// Get health state specified by event raised
        /// </summary>
        /// <param name="whichEvent">value of FirstEventRaised, SecondEventRaised</param>
        /// <returns>health state</returns>
        public string GetHealthState(TrapOrProbeRaised whichEvent)
        {
            return GetCellValue(whichEvent, HealthStateColumnIndex);
        }

        /// <summary>
        /// Get data grid cell value specified by event raised and column index
        /// </summary>
        /// <param name="whichEvent">value of FirstEventRaised, SecondEventRaised</param>
        /// <param name="colIndex">column index</param>
        /// <returns>data grid cell value</returns>
        public string GetCellValue(TrapOrProbeRaised whichEvent, int colIndex)
        {
            int rowPos = GetRowIndex(whichEvent);

            return this.Controls.StatesGridView.Rows[rowPos].Cells[colIndex].GetValue();
        }

        /// <summary>
        /// Get row index specified by event raised
        /// </summary>
        /// <param name="whichRaised">value of FirstEventRaised, SecondEventRaised</param>
        /// <returns>row index</returns>
        private int GetRowIndex(TrapOrProbeRaised whichRaised)
        {
            switch (whichRaised)
            {
                case TrapOrProbeRaised.First:
                    return GetRowIndex(MonitorConditionColumnIndex, FirstRaised);

                case TrapOrProbeRaised.Second:
                    return GetRowIndex(MonitorConditionColumnIndex, SecondRaised);
            }

            throw new Exception("Unknown raised type: " + whichRaised.ToString());
        }

        /// <summary>
        /// Get row index specified by column index and cell value
        /// </summary>
        /// <param name="cellIndex">column index</param>
        /// <param name="cellValue">cell value</param>
        /// <returns></returns>
        private int GetRowIndex(int cellIndex, string cellValue)
        {
            int rowCount = this.Controls.StatesGridView.Rows.Count;
            if (rowCount == 0)
            {
                throw new Exception("Rows count is zero");
            }

            DataGridViewRowCollection rowCol = this.Controls.StatesGridView.Rows;

            for (int i = 1; i <= rowCount; i++)
            {
                if (Regex.IsMatch(rowCol[i].Cells[cellIndex].GetValue(), cellValue))
                {
                    return i;
                }
            }

            throw new Exception("Cannot find row index with cell value: " + cellValue + " and cell index: " + cellIndex);
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
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 5;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);

                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
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
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";

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
            /// Contains resource string for:  MapMonitorConditionsToHealthStates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMapMonitorConditionsToHealthStates = ";Map monitor conditions to health states;ManagedString;Microsoft.MOM.UI.Component" +
                "s.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CreateMonitorWizard" +
                ".OperationalStatesMappingPage;pageSectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";dataGridView1;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect = @";Specify what health state should be generated for each of the conditions that this monitor will detect:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CreateMonitorWizard.OperationalStatesMappingPage;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth2 = ";Configure Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";
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
            /// Caches the translated resource string for:  MapMonitorConditionsToHealthStates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMapMonitorConditionsToHealthStates;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth2;
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
            /// Exposes access to the MapMonitorConditionsToHealthStates translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MapMonitorConditionsToHealthStates
            {
                get
                {
                    if ((cachedMapMonitorConditionsToHealthStates == null))
                    {
                        cachedMapMonitorConditionsToHealthStates = CoreManager.MomConsole.GetIntlStr(ResourceMapMonitorConditionsToHealthStates);
                    }
                    return cachedMapMonitorConditionsToHealthStates;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataGridView1
            {
                get
                {
                    if ((cachedDataGridView1 == null))
                    {
                        cachedDataGridView1 = CoreManager.MomConsole.GetIntlStr(ResourceDataGridView1);
                    }
                    return cachedDataGridView1;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect
            {
                get
                {
                    if ((cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect == null))
                    {
                        cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect);
                    }
                    return cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect;
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
            /// Exposes access to the ConfigureHealth2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth2
            {
                get
                {
                    if ((cachedConfigureHealth2 == null))
                    {
                        cachedConfigureHealth2 = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth2);
                    }
                    return cachedConfigureHealth2;
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
            /// Control ID for MapMonitorConditionsToHealthStatesStaticControl
            /// </summary>
            public const string MapMonitorConditionsToHealthStatesStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "statesGridView";

            /// <summary>
            /// Control ID for SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
            /// </summary>
            public const string SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl = "label1";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for ConfigureHealthStaticControl2
            /// </summary>
            public const string ConfigureHealthStaticControl2 = "headerLabel";
        }
        #endregion
    }

    /// <summary>
    /// Enum value for EventRaised
    /// </summary>
    public enum TrapOrProbeRaised
    {
        First,
        Second
    }
}
