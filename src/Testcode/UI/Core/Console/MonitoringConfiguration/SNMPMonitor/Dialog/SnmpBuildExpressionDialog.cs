// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SnmpBuildExpressionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// [v-bire] 31 DEC 2010 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SNMPMonitor.Dialogs
{
    #region Using directive
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.MomControls;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    #endregion

    #region Interface Definition - ISnmpBuildExpressionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISnmpBuildExpressionDialogControls, for SnmpBuildExpressionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISnmpBuildExpressionDialogControls
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
        /// Read-only property to access FormulaToolStrip
        /// </summary>
        Toolbar FormulaToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FormulaGrid
        /// </summary>
        GridControl FormulaGrid
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Expose UI controls, two customzied control method: ClickInsert, ClickNext.
    /// ClickInsert - Press Atl+s to make insert button invoked.
    /// ClickNext  - Before click Next button, press two tab keys to make sure the formula cell lost focus.
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SnmpBuildExpressionDialog : Dialog, ISnmpBuildExpressionDialogControls
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
        /// Cache to hold a reference to FormulaToolStrip  of type Toolbar
        /// </summary>
        private Toolbar cachedFormulaToolStrip;

        /// <summary>
        /// Cache to hold a refernce to FormulaGrid of type DataGrid
        /// </summary>
        private GridControl cachedFormulaGrid;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor of SnmpBuildExpressionDialog
        /// </summary>
        /// <param name='app'>
        /// Owner of SnmpBuildExpressionDialog of type SnmpBuildExpressionDialog
        /// </param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SnmpBuildExpressionDialog(ConsoleApp app)
            : base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }

        /// <summary>
        /// Constructor of SnmpBuildExpressionDialog
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// <param name="window">The window of SnmpBuildExpressionDialog itself</param>
        public SnmpBuildExpressionDialog(ConsoleApp app, Window window)
            : base(app, window)
        {
        }
        #endregion

        #region ISnmpProbeDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISnmpBuildExpressionDialogControls Controls
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
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpBuildExpressionDialogControls.PreviousButton
        {
            get
            {
                if (this.cachedPreviousButton == null)
                {
                    this.cachedPreviousButton = new Button(this, SnmpBuildExpressionDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpBuildExpressionDialogControls.NextButton
        {
            get
            {
                if (this.cachedNextButton == null)
                {
                    this.cachedNextButton = new Button(this, SnmpBuildExpressionDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpBuildExpressionDialogControls.CreateButton
        {
            get
            {
                if (this.cachedCreateButton == null)
                {
                    this.cachedCreateButton = new Button(this, SnmpBuildExpressionDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpBuildExpressionDialogControls.CancelButton
        {
            get
            {
                if (this.cachedCancelButton == null)
                {
                    this.cachedCancelButton = new Button(this, SnmpBuildExpressionDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        GridControl ISnmpBuildExpressionDialogControls.FormulaGrid
        {
            get
            {
                if (this.cachedFormulaGrid == null)
                {
                    this.cachedFormulaGrid = new GridControl(this, SnmpBuildExpressionDialog.ControlIDs.FormulaGrid);
                }
                return this.cachedFormulaGrid;
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
        Toolbar ISnmpBuildExpressionDialogControls.FormulaToolStrip
        {
            get
            {
                if ((this.cachedFormulaToolStrip == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the Toolbar constructor with 'this' being the only parameter 
                    // is returning the wrong toolbar. There is no caption/name defined for these toolbars therefore we cannot call the 
                    // constructor with the caption/name. Switching over to the UIA tree and using a QID with the AutomationId.

                    QID queryId = new QID(";[UIA]AutomationId='" + SnmpBuildExpressionDialog.ControlIDs.IntermediateElementPagePanel + "';[UIA]AutomationId='" + SnmpBuildExpressionDialog.ControlIDs.IntermediateElementFormulaBuilderControl + "';[UIA]AutomationId='" + SnmpBuildExpressionDialog.ControlIDs.FormulaToolStrip + "' && Role='tool bar'");

                    this.cachedFormulaToolStrip = new Toolbar(this, queryId, Constants.DefaultContextMenuTimeout); //this.cachedFormulaToolStrip = new Toolbar(this);
                }
                return this.cachedFormulaToolStrip;
            }
        }
        #endregion

        #region Control Methods
        /// <summary>
        /// Send Keys of Alt+s to make insert button invoked
        /// </summary>
        public void ClickInsert()
        {
            this.Extended.SetFocus();
            Keyboard.SendKeys(KeyboardCodes.Alt + "s");
        }

        /// <summary>
        /// Before click Next button, will Send two Tab keys first to make sure formula cell lost focus
        /// </summary>
        public void ClickNext()
        {
            int i = 0;
            for (; i < 10; Sleeper.Delay(1000), i++)
            {
                if (!this.Controls.NextButton.IsEnabled)
                {
                    continue;
                }
                else
                {
                    // Note: The first two tabs to make sure parameter cell lost focus
                    Keyboard.SendKeys("{TAB}");
                    Keyboard.SendKeys("{TAB}");

                    this.Controls.NextButton.Click();
                    break;
                }
            }

            if (i == 10)
            {
                throw new Exception("Next button is NOT enabled");
            }
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">SnmpBuildExpressionDialog owning the dialog.</param>)
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            string dialogTitle = Strings.DialogTitle;

            Window tempWindow = null;
            int numberOfTries = 0;
            const int MaxTries = 5;

            while (tempWindow == null && numberOfTries < MaxTries)
            {
                try
                {
                    // first try
                    if (numberOfTries == 0)
                    {
                        // Try to locate an existing instance of a dialog
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                    }
                    else
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(dialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                }
                catch (Exceptions.WindowNotFoundException ex)
                {
                    // log the unsuccessful attempt
                    Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                    if (numberOfTries == MaxTries - 1)
                    {
                        Core.Common.Utilities.LogMessage("Failed to find with title: " + dialogTitle);
                        throw ex;
                    }
                }

                numberOfTries++;
            }

            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Private Members

            /// <summary>
            /// Cache to hold a refernce of dialog title of String
            /// </summary>
            private static string cachedDialogTitle = null;

            /// <summary>
            /// Cache to hold a reference of parameter name column of String
            /// </summary>
            private static string cachedGridParameterNameColumn;

            /// <summary>
            /// Cache to hold a reference of operator column of String
            /// </summary>
            private static string cachedGridOperatorColumn;

            /// <summary>
            /// Cache to hold a reference of value column of String
            /// </summary>
            private static string cachedGridValueColumn;

            /// <summary>
            /// Cache to hold a reference of formula toolstrip insert of String
            /// </summary>
            private static string cachedFormulaToolStripInsert;
            #endregion

            #region Constants

            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            private const string ResourceDialogTitle =
                ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";

            /// <summary>
            /// Resource string for Use discovery community string
            /// </summary>
            private const string ResourceUseDiscoveryCommunityString = ";&Use discovery community string;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpTrapProviderPage;radioButtonDiscoveredCommunityString.Text";

            /// <summary>
            /// Resource string for Use custom community string
            /// </summary>
            private const string ResourceUseCustomCommunityString = ";Use cus&tom community string;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpTrapProviderPage;radioButtonCustomCommunitryString.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridParameterNameColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridParameterNameColumn =
                ";Parameter Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;ParamName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridOperatorColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridOperatorColumn =
                ";Operator;ManagedString;Microsoft.Mom.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGrid;dataGridViewTextBoxColumn2.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: GridValueColumn.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGridValueColumn =
                ";Value;ManagedString;Microsoft.Mom.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaGrid;dataGridViewTextBoxColumn3.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: formulaToolStripInsert.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaToolStripInsert = ";In&sert;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl.resources;insertButton.Text";
            #endregion

            #region Properties

            /// <summary>
            /// Read-only property to access DialogTitle
            /// </summary>
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
            #endregion
        }
        #endregion

        #region Control ID's
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
            /// Control ID for InsertButtonName
            /// </summary>
            public const string InsertButtonName = "Insert";

            /// <summary>
            /// Control ID for IntermediateElementpagePanel
            /// </summary>
            public const string IntermediateElementPagePanel = "pagePanel";

            /// <summary>
            /// Control ID for FormulaToolStrip
            /// </summary>
            public const string FormulaToolStrip = "formulaMenu";

            /// <summary>
            /// Control ID for IntermediateElementFormulaBuilderControl
            /// </summary>
            public const string IntermediateElementFormulaBuilderControl = "formulaBuilderControl";

            /// <summary>
            /// Control ID for FormulaGrid
            /// </summary>
            public const string FormulaGrid = "formulaGrid";

            /// <summary>
            /// Control ID for OperatorComboBox
            /// </summary>
            public const string OperatorComboBox = "OperatorComboBoxEditor";
        }
        #endregion
    }
}
