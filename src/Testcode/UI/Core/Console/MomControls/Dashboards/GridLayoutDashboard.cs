// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GridLayoutDashboard.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   IT Pro Dashboard Wizard
// </project>
// <summary>
//   Grid layout
// </summary>
// <history>
//   [v-vijia] 1/25/2011   Added P1 Cases
//   [v-raienl] 12/28/2010  Created
// </history>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Maui.Core;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using Maui.Core.Utilities;
using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard;

namespace Mom.Test.UI.Core.Console.MomControls.Dashboards
{
    public class GridLayoutDashboard : Dashboard
    {
        #region Private variables

        private const string HorizontalScrollBarQID = @";[UIA]AutomationId='HorizontalScrollBar'";

        protected string createDashboardContextMenuPath;

        /// <summary>
        /// The number of cells in dashboard
        /// </summary>
        protected int cellCount;

        /// <summary>
        /// The cells that the dashboard hosts
        /// </summary>
        private List<WidgetViewHost> cells;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of GridLayoutDashboard class
        /// </summary>
        /// <param name="knownWindow">Parent window that hosts the dashboard</param>
        /// <param name="cellCount">Number of cells in the dashboard</param>
        public GridLayoutDashboard(Window knownWindow, int cellCount)
            : base(knownWindow)
        {
            if (cellCount <= 0)
            {
                throw new ArgumentOutOfRangeException("GridLayoutDashboard :: cell count should be larger than 0");
            }
            else
            {
                this.cellCount = cellCount;
            }

            this.createDashboardContextMenuPath = Views.Views.Strings.NewContextMenu +
                                                  Common.Constants.PathDelimiter +
                                                  Views.Views.Strings.DashboardViewContextMenu;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The number of cells in dashboard
        /// </summary>
        public int CellCount
        {
            get
            {
                return this.cellCount;
            }
        }

        /// <summary>
        /// The Cells that the dashboard hosts, index starts from 0
        /// </summary>
        public List<WidgetViewHost> Cells
        {
            get
            {
                if (this.cells == null)
                {
                    this.cells = new List<WidgetViewHost>();
                    for (int i = 0; i < this.cellCount; i++)
                    {
                        this.cells.Add(this.GetLayoutCell(i + 1));
                    }
                }

                return this.cells;
            }
        }

        /// <summary>
        /// Check if the dashboard has Horizatial Scroll bar
        /// </summary>
        public bool HasHorizontalScrollBar
        {
            get
            {
                bool hasScrollBar = false;
                try
                {
                    Window scrollbar = new Window(this, new QID(HorizontalScrollBarQID), TIME_OUT);
                    if (scrollbar.IsVisible)
                    {
                        hasScrollBar = true;
                    }
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    //swallow
                }

                return hasScrollBar;
            }
        }

        /// <summary>
        /// Horizatial Scroll bar in the dashboard
        /// </summary>
        public Maui.Core.WinControls.HorizontalScrollBar HorizontalScrollBar
        {
            get
            {
                return new Maui.Core.WinControls.HorizontalScrollBar(this, new QID(HorizontalScrollBarQID));
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to config the dashboard
        /// </summary>
        /// <param name="nodePath">node path in Navigation pane</param>
        /// <param name="name">General Properties dailog: Name</param>
        /// <param name="description">General Properties dailog: Description</param>
        /// <param name="layoutIndex">Layout dialog: layout index</param>
        /// <param name="layoutTemplateIndex">Layout dialog: layout template index</param>
        public void ConfigureGridLayoutDashboard(string nodePath, string name, string description, string layoutTemplate)
        {
            Utilities.LogMessage("GridLayoutDashboard.ConfigureGridLayoutDashboard (...)");

            DashboardParams settings = new DashboardParams();
            settings.Name = name;
            settings.Description = description;
            TemplateGridLayoutDashboard.LayoutPagesParams param = new TemplateGridLayoutDashboard.LayoutPagesParams();
            param.layoutTemplate = layoutTemplate;
            settings.CustomPageParams = param;
            settings.Template = new TemplateGridLayoutDashboard();

            //Launch Properties dialog
            Utilities.LogMessage("GridLayoutDashboard.ConfigureGridLayoutDashboard:: launch Update Configuration");
            DashboardConfigurationWizard dashboardConfigurationWizard = DashboardConfigurationWizard.Launch(nodePath);
            
            //config dashboard
            dashboardConfigurationWizard.SettingWizard(settings);
        }

        /// <summary>
        /// Method to personalize the dashboard
        /// </summary>
        public void PersonalizeGridLayoutDashboard()
        {
            throw new NotImplementedException();
            //TODO: Implement it once personalization dialog is finally settled
        }

        /// <summary>
        /// Method to create the dashboard
        /// </summary>
        /// <param name="name">General Properties dailog: Name</param>
        /// <param name="description">General Properties dailog: Description</param>
        /// <param name="mp">General Properties dailog: management pack</param>
        /// <param name="layoutIndex">Layout dialog: layout index</param>
        /// <param name="layoutTemplateIndex">Layout dialog: layout template index</param>
        /// <param name="dashboardFolderName">dashboard folder name</param>
        public void CreateGridLayoutDashboard(string name, string description, string mpName, int layoutIndex, string layoutTemplate, string dashboardFolderName = "")
        {
            Utilities.LogMessage("GridLayoutDashboard.CreateGridLayoutDashboard (...)");

            DashboardParams settings = new DashboardParams();
            settings.Name = name;
            settings.Description = description;
            settings.ManagementPack = mpName;
            TemplateGridLayoutDashboard.LayoutPagesParams param = new TemplateGridLayoutDashboard.LayoutPagesParams();
            param.LayoutIndex = layoutIndex;
            param.layoutTemplate = layoutTemplate;
            settings.CustomPageParams = param;
            settings.Template = new TemplateGridLayoutDashboard();

            // Launch New Dashboard and Widget Wizard
            if (dashboardFolderName == "")
            {
                dashboardFolderName = NavigationPane.Strings.Monitoring;
            }

            DashboardCreationWizard layoutDashboardCreatetionWizard =null;            
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

            layoutDashboardCreatetionWizard.SettingWizard(settings);
        }

        /// <summary>
        /// Method to remove the dashboard
        /// </summary>
        /// <param name="nodePath">node path of dashboard in Navigation pane</param>
        public void RemoveLayoutDashboard(string nodePath)
        {
            Utilities.LogMessage("GridLayoutDashboard.RemoveGridLayoutDashboard (...)");

            if (ProductSku.Sku == ProductSkuLevel.Mom)
            {
                // Select dashboard
                Utilities.LogMessage("GridLayoutDashboard.RemoveGridLayoutDashboard:: Select dashboard :" + nodePath);
                CoreManager.MomConsole.NavigationPane.SelectNode(nodePath);
            }            

            //Bug#203047
            //CoreManager.MomConsole.WaitForStatusReady();
            System.Threading.Thread.Sleep(5000);

            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    // Execute Edit->Delete
                    CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.DeleteContextMenu, true);

                    //Select "Yes" on confirmation dialog
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        MomConsoleApp.Strings.DialogTitle,
                        StringMatchSyntax.WildCard,
                        MomConsoleApp.ActionIfWindowNotFound.Error);
                    CoreManager.MomConsole.WaitForStatusReady();
                    break;
                case ProductSkuLevel.Web:
                     Utilities.LogMessage("TaskStrip.ClickLink:: Try to find the link");
                     Maui.Core.WinControls.Control linkElement = new Maui.Core.WinControls.Control(CoreManager.MomConsole.MainWindow, new QID(";[UIA]ClassName = 'Hyperlink' && [UIA, VisibleOnly]Name = ~'Delete'"), Constants.DefaultViewLoadTimeout);
                        
                    if (linkElement == null)
                    {
                        throw new Window.Exceptions.WindowNotFoundException("Failed to get the link.");
                    }

                    CoreManager.MomConsole.Waiters.WaitForWindowEnabled(linkElement as Window, Constants.OneSecond * 10);
                    Utilities.LogMessage("TaskStrip.ClickLink:: Try to click the link");
                    linkElement.ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.NoFlag);

                    //Select "Yes" on confirmation dialog                    
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        "Delete Dashboard",
                        StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);
                    
                    break;
                default:
                    break;
            }            
                 
           
        }


        /// <summary>
        /// Method to add widget
        /// </summary>
        /// <param name="cellIndex">Cell Index</param>
        /// <param name="widgetType">Widget type</param>
        /// <param name="name">General Properties dailog: Name</param>
        /// <param name="description">General Properties dailog: Description</param>
        /// <param name="mp">General Properties dailog: management pack</param>
        /// <param name="param">parameters for custome dialog</param>
        public void AddWidget(int cellIndex, string widgetType, string name, string description, string mpName, ICustomPageParams param)
        {
            Utilities.LogMessage("AddWidget (...)");
            Utilities.LogMessage("GridLayoutDashboard.AddWidget:: Add widget in cell:" + cellIndex);
            Utilities.LogMessage("AddWidget:: Widget type:" + widgetType);

            if (cellIndex < 0 || cellIndex > this.cellCount - 1)
                throw new ArgumentOutOfRangeException("AddWidget:: cell index: " + cellIndex + " is invalid");

            // Set params
            DashboardParams settings = new DashboardParams();
            settings.Name = name;
            settings.Description = description;
            settings.ManagementPack = mpName;
            settings.CustomPageParams = param;
            settings.Template = (ITemplate)Activator.CreateInstance(Type.GetType(widgetType));            

            this.Cells[cellIndex].AddWidget(settings);
        }

        /// <summary>
        /// Method to configure widget
        /// </summary>
        /// <param name="cellIndex">Cell Index</param>
        /// <param name="name">General Properties dailog: Name</param>
        /// <param name="description">General Properties dailog: Description</param>
        /// <param name="param">parameters for custome dialog</param>
        public void ConfigureWidget(int cellIndex, string name, string description, ICustomPageParams param)
        {
            Utilities.LogMessage("ConfigureWidget (...)");
            Utilities.LogMessage("ConfigureWidget:: Add widget in cell:" + cellIndex);

            if (cellIndex < 0 || cellIndex > this.cellCount - 1)
                throw new ArgumentOutOfRangeException("ConfigureWidget:: cell index: " + cellIndex + " is invalid");

            this.Cells[cellIndex].ConfigureWidget(name, description, param);
        }

        /// <summary>
        /// Method to Personalize widget
        /// </summary>
        /// <param name="cellIndex">Cell Index</param>
        /// <param name="param">parameters for custome dialog</param>
        public void PersonalizeWidget(int cellIndex, ICustomPageParams param)
        {
            Utilities.LogMessage("PersonalizeWidget (...)");
            Utilities.LogMessage("PersonalizeWidget:: Add widget in cell:" + cellIndex);

            if (cellIndex < 0 || cellIndex > this.cellCount - 1)
                throw new ArgumentOutOfRangeException("PersonalizeWidget:: cell index: " + cellIndex + " is invalid");

            this.Cells[cellIndex].PersonalizeWidget(param);
        }

        /// <summary>
        /// Method to remove widget
        /// </summary>
        /// <param name="widgetTitle">widget title</param>
        public void RemoveWidget(string widgetTitle)
        {
            int cellInstance = this.GetCellInstanceByWidgetTitle(widgetTitle);
            this.RemoveWidget(cellInstance);
        }

        /// <summary>
        /// Method to remove widget
        /// </summary>
        /// <param name="cellInstance">cell instance</param>
        public void RemoveWidget(int cellInstance)
        {
            Utilities.LogMessage("RemoveWidget:: ...");

            if (cellInstance <= 0 || cellInstance > this.cellCount)
                throw new ArgumentOutOfRangeException("RemoveWidget :: Cell index is out of range.");
			this.Cells[cellInstance - 1].Click();
            this.Cells[cellInstance - 1].DeleteWidget();
        }

        /// <summary>
        /// Method to move widget
        /// </summary>
        /// <param name="cellIndex">cell index</param>
        /// <param name="direction">moving direction: left/right</param>
        public void MoveWidget(int cellIndex, string direction)
        {
            Utilities.LogMessage("MoveWidget:: Move widget: cell index:" + cellIndex + ", direction:" + direction);

            if (cellIndex < 0 || cellIndex >= this.cellCount)
                throw new ArgumentOutOfRangeException("MoveWidget:: cell index is out of range.");
            this.Cells[cellIndex].Click();
            if (direction == Constants.Left)
            {
                this.Cells[cellIndex].MoveViewLeft();
            }
            else if (direction == Constants.Right)
            {
                this.Cells[cellIndex].MoveViewRight();
            }
            else
            {
                throw new InvalidOperationException("MoveWidget:: Direction of moving cell is invilad.");
            }

            Sleeper.Delay(Constants.OneSecond * 2);
        }

        #endregion

        #region Private method

        /// <summary>
        /// Method to get cell's instance by widget title
        /// </summary>
        /// <param name="widgetTitle">widget title</param>
        /// <returns>cell instance</returns>
        public int GetCellInstanceByWidgetTitle(string widgetTitle)
        {
            Utilities.LogMessage("GetCellInstanceByWidgetTitle:: Title:" + widgetTitle);

            int cellInstance = -1;
            for (int i = 0; i < this.cellCount; i++)
            {
                if (this.Cells[i].Title.Text == widgetTitle)
                {
                    cellInstance = i + 1;
                    break;
                }
            }

            Utilities.LogMessage("GetCellInstanceByWidgetTitle:: Cell instance:" + cellInstance);

            return cellInstance;
        }

        /// <summary>
        /// Method to get the WidgetViewHost in a cell of dashboard
        /// </summary>
        /// <param name="cellIndex">The index of the cell in dashboard</param>
        /// <returns>Instance of WidgetViewHost</returns>
        protected WidgetViewHost GetLayoutCell(int cellIndex)
        {
            if (cellIndex <= 0 || cellIndex > this.CellCount)
            {
                throw new ArgumentOutOfRangeException("GetLayoutCell :: cell index is out of range.");
            }
            else
            {         
                return new WidgetViewHost(
                         new Window(
                             this,
                             new QID(";[UIA]AutomationId='SCOMViewHost' && Instance='" + cellIndex + "'"),
                             TIME_OUT));
            }
        }

        #endregion
    }
}
