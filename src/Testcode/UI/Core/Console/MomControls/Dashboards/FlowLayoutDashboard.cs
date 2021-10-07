// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="FlowLayoutDashboard.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <summary>
//   IT Pro Dashboard Wizard Flow Layout
// </summary>
// <history>
//   [v-vijia] 1/31/2011 Created
// </history>
// ------------------------------------------------------------------------------
using System;
using Maui.Core;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using Maui.Core.Utilities;
using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard;

namespace Mom.Test.UI.Core.Console.MomControls.Dashboards
{
    public class FlowLayoutDashboard : GridLayoutDashboard
    {
        #region QIDs

        /// <summary>
        /// QID for the Add Cell task button
        /// </summary>
        public static QID addCellTaskQID = new QID(";[UIA]Name='Add Cell'");

        /// <summary>
        /// Gets the QID of Add Cell task button
        /// </summary>
        /// <returns></returns>
        protected virtual QID GetAddCellTaskQID()
        {
            return addCellTaskQID;
        }

         #endregion

        #region Private variables

        /// <summary>
        /// The Add Cell button in dashboard task host
        /// </summary>
        private Button addCellTaskButton;

        /// <summary>
        /// The number of columns in dashboard
        /// </summary>
        private int columnCount;

        /// <summary>
        /// The number of rows in dashboard
        /// </summary>
        private int rowCount;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of FlowLayoutDashboard class
        /// </summary>
        /// <param name="knownWindow">Parent window that hosts the dashboard</param>
        /// <param name="columnCount">Number of columns in the dashboard</param>
        public FlowLayoutDashboard(Window knownWindow, int columnCount)
            : this(knownWindow, columnCount, columnCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of FlowLayoutDashboard class
        /// </summary>
        /// <param name="knownWindow">Parent window that hosts the dashboard</param>
        /// <param name="columnCount">Number of columns in the dashboard</param>
        /// <param name="cellCount">Number of cells in the dashboard</param>
        public FlowLayoutDashboard(Window knownWindow, int columnCount, int cellCount)
            : base(knownWindow, cellCount)
        {
            if (columnCount < 1 || columnCount > 3)
            {
                throw new ArgumentOutOfRangeException("FlowLayoutDashboard :: column count should be 1 to 3");
            }
            else
            {
                this.columnCount = columnCount;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The number of columns in dashboard
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return this.columnCount;
            }
        }

        /// <summary>
        /// The number of rows in dashboard
        /// </summary>
        public int RowCount
        {
            get
            {
                if (this.cellCount == 0)
                {
                    this.rowCount = 0;
                }
                else
                {
                    if ((this.cellCount % this.columnCount) > 0)
                    {
                        this.rowCount = this.cellCount / this.columnCount + 1;
                    }
                    else
                    {
                        this.rowCount = this.cellCount / this.columnCount;
                    }
                }

                return this.rowCount;
            }
        }

        /// <summary>
        /// The DropDown task button control
        /// </summary>
        private Button dropDownButton;

        protected Button DropDownButton
        {
            get
            {
                if (this.dropDownButton == null)
                {
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            this.dropDownButton = new Button(this.TaskHost, Dashboard.ControlQIDs.taskHostQID, TIME_OUT);
                            break;
                        case ProductSkuLevel.Web:
                            this.dropDownButton = new Button(this, new QID(";[UIA]AutomationId='button'"), TIME_OUT); //TODO: should use right QID for web console
                            break;
                    }
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.dropDownButton, Constants.DefaultContextMenuTimeout);
                return this.dropDownButton;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add a new cell into dashboard by clicking Add Cell task button
        /// </summary>
        public void AddCell()
        {
            this.DropDownButton.ScreenElement.LeftButtonClick(-1, -1);
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.AddCell);
            // Cell count + 1
            this.cellCount++;

            // Add the new cell into Cells
            this.Cells.Add(this.GetLayoutCell(this.cellCount));
        }

        /// <summary>
        /// Get the widget view in a cell by position
        /// </summary>
        /// <param name="column">cell's column position, starts from 1</param>
        /// <param name="row">cell's row position, starts from 1</param>
        /// <returns></returns>
        public WidgetViewHost GetLayoutCell(int column, int row)
        {
            if (column < 1 || column > this.columnCount)
            {
                throw new ArgumentOutOfRangeException("GetLayoutCell :: column index must be in 1 - " + this.columnCount);
            }
            if (row < 1 || row > this.rowCount)
            {
                throw new ArgumentOutOfRangeException("GetLayoutCell :: row index must be in 1 - " + this.rowCount);
            }
            int cellIndex = (row - 1) * this.columnCount + column;
            return this.GetLayoutCell(cellIndex);
        }


        /// <summary>
        /// Method to create flow layout dashboard
        /// </summary>
        /// <param name="name">General Properties dailog: Name</param>
        /// <param name="description">General Properties dailog: Description</param>
        /// <param name="mpName">General Properties dailog: management pack</param>
        /// <param name="columnCount">Column Count dialog: column count</param>
        /// <param name="dashboardFolderName">dashboard folder name</param>
        public void CreateFlowLayoutDashboard(string name, string description, string mpName, int columnCount, string dashboardFolderName = "")
        {
            Utilities.LogMessage("FlowLayoutDashboard.CreateFlowLayoutDashboard (...)");

            DashboardParams settings = new DashboardParams();
            settings.Name = name;
            settings.Description = description;
            settings.ManagementPack = mpName;
            Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.TemplateFlowLayoutDashboard.ColumnCountPagesParams param = new TemplateFlowLayoutDashboard.ColumnCountPagesParams();
            param.ColumnCount = columnCount;
            settings.CustomPageParams = param;
            settings.Template = new TemplateFlowLayoutDashboard();

            // Launch New Dashboard and Widget Wizard
            if (dashboardFolderName == string.Empty)
            {
                dashboardFolderName = NavigationPane.Strings.Monitoring;
            }

            DashboardCreationWizard layoutDashboardCreatetionWizard = null;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    layoutDashboardCreatetionWizard = DashboardCreationWizard.Launch(dashboardFolderName, this.createDashboardContextMenuPath);


                    break;
                case ProductSkuLevel.Web:
                    layoutDashboardCreatetionWizard = DashboardCreationWizard.Launch(DashboardCreationWizardEntry.WebConsoleLink, dashboardFolderName);
                    break;
                default:
                    break;
            }   

            // Setting wizard
            layoutDashboardCreatetionWizard.SettingWizard(settings);
        }

        /// <summary>
        /// Method to configure the dashboard
        /// </summary>
        /// <param name="nodePath">node path in Navigation pane</param>
        /// <param name="name">General Properties dailog: Name</param>
        /// <param name="description">General Properties dailog: Description</param>
        /// <param name="columnCount">Column Count dialog: column count</param>
        public void ConfigureFlowLayoutDashboard(string nodePath, string name, string description, int columnCount)
        {
            Utilities.LogMessage("GridLayoutDashboard.ConfigFlowLayoutDashboard (...)");

            DashboardParams settings = new DashboardParams();
            settings.Name = name;
            settings.Description = description;
            Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.TemplateFlowLayoutDashboard.ColumnCountPagesParams param = new TemplateFlowLayoutDashboard.ColumnCountPagesParams();
            param.ColumnCount = columnCount;
            settings.CustomPageParams = param;
            settings.Template = new TemplateFlowLayoutDashboard();

            // Launch wizard
            Utilities.LogMessage("GridLayoutDashboard.ConfigureGridLayoutDashboard:: launch Update Configuration");
            DashboardConfigurationWizard wizard = DashboardConfigurationWizard.Launch(nodePath);

            // Setting wizard
            wizard.SettingWizard(settings);
        }

        #endregion
    }
}
