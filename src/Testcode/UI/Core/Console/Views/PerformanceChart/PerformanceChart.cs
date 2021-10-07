//-------------------------------------------------------------------
// <copyright file="PerformanceChart.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   PerformanceChart View
// </summary>
//  <history>
// [v-kantao] 2/22/2011 Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.PerformanceChart
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MomCommon = Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Common;
    using MomConsole = Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.MomControls;
    using Maui.Core.WinControls;
    using Maui.Core;
    using Maui.Core.Utilities;
    using System.Xml.Linq;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.Reflection;
    using System.IO;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    #endregion



    /// <summary>
    /// Performance View
    /// </summary>
    public class PerformanceChart
    {
        public static string DefaultMPName = "Default Management Pack";

        [Resource(ID = "Color")]
        private string colorColumn;
        private static string Color;

        [Resource(ID = "Show")]
        private string showColumn;
        private static string Show;

        [Resource(ID = "Name")]
        private string nameColumn;
        private static string Name;

        [Resource(ID = "Minimum")]
        private string minimumColumn;
        private static string Minimum;

        [Resource(ID = "AverageValue")]
        private string AverageValueColumn;
        private static string AverageValue;

        [Resource(ID = "DisplayName")]
        private string DisplayNameColumn;
        public static string DisplayName;

        [Resource(ID = "CounterName")]
        private string CounterNameColumn;
        public static string CounterName;

        [Resource(ID = "ObjectName")]
        private string ObjectNameColumn;
        private static string ObjectName;

        [Resource(ID = "InstanceName")]
        private string InstanceNameColumn;
        private static string InstanceName;

        [Resource(ID = "Path")]
        private string PathColumn;
        private static string Path;

        #region Constructor
        static PerformanceChart()
        {
            // initialize static resource string here
            new PerformanceChart();
        }

        /// <summary>
        /// Performance View
        /// </summary>
        public PerformanceChart()
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.PerformanceChartResource.xml"));
            XDocument dashboardWizardDocument = XDocument.Load(stream);
            XElement EmbemdedAlertComponentResource = ResourceLoader.GetSection("PerformanceChartComponent", dashboardWizardDocument);
            ResourceLoader.LoadResources(this, EmbemdedAlertComponentResource);

            // Loading Rescource String
            Color = colorColumn;
            Show = showColumn;
            Name = nameColumn;
            Minimum = minimumColumn;
            AverageValue = AverageValueColumn;
            DisplayName = DisplayNameColumn;
            CounterName = CounterNameColumn;
            ObjectName = ObjectNameColumn;
            InstanceName = InstanceNameColumn;
            Path = PathColumn;

            Utilities.LogMessage("PerformanceChart :: Tesing lodaing resource " + DisplayName + " and " + CounterName);
        }

        #endregion

        #region Public Methods
        /// -------------------------------------------------------------------
        /// <summary>
        /// Verify show and hide of checkbox in legend
        /// </summary>
        /// <param name="expectedStatus">Expected status of Checkbox</param>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static void VerifyShowHide()
        {

            Utilities.LogMessage("VerifyShowHide");
            Maui.Core.MauiCollection<IScreenElement> CheckBoxCollection = default(MauiCollection<IScreenElement>);
            DataGridControl DataGrid = GetLegendDataGrid();
            CheckBoxCollection = DataGrid.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly] ClassName = '" + "Checkbox" + "'", null);
            StaticControl checkbox = new StaticControl(DataGrid, new QID(";[UIA]AutomationId = 'HostedCheckBox'"), MomCommon.Constants.OneMinute);
            Utilities.TakeScreenshot("Before Uncheck check box");
            Utilities.LogMessage("PerformanceChart.VerifyShowhide :: Check box status" + checkbox.IsVisible.ToString());
            Sleeper.Delay(MomCommon.Constants.OneSecond);
            int maxtry = 0;
            while (maxtry < 5)
            {
                if (checkbox.IsVisible.Equals(true))
                {
                    checkbox.ScreenElement.LeftButtonClick(10, 10);
                    Utilities.LogMessage("click check box successully");
                    break;
                }

                else
                {
                    Sleeper.Delay(MomCommon.Constants.TenSeconds);
                    Utilities.LogMessage("Checkbox still invisible");
                    maxtry++;
                }
            }
            Sleeper.Delay(MomCommon.Constants.TenSeconds);
            Utilities.LogMessage("PerformanceChart.VerifyShowhide :: Check box status" + checkbox.IsVisible.ToString());
            //CheckBoxCollection[0].Check();
            while (maxtry < 5)
            {
                if (checkbox.IsVisible.Equals(true))
                {
                    checkbox.ScreenElement.LeftButtonClick(10, 10);
                    Utilities.LogMessage("click check box successully");
                    break;
                }

                else
                {
                    Sleeper.Delay(MomCommon.Constants.TenSeconds);
                    Utilities.LogMessage("Checkbox still invisible");
                    maxtry++;
                }
            }



        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Verify Default Legend Settings
        /// </summary>
        /// <param name="defaultcount">Default peroperty count</param>
        /// <param name="defaultVis">Default name of the first prpperty in legend</param>
        /// <param name="defualtName">Default name of the second prpperty in legend</param>
        /// <param name="defualtColor">Default name of the third prpperty in legend</param>
        /// <param name="SeriesCount">Default count of series</param>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static void VerifyDefaultLegendSettings(string defaultcount, string SeriesCount)
        {
            Utilities.LogMessage("VerifyLegendProperty");
            DataGridControl DataGrid = GetLegendDataGrid();

            int seriesCount = DataGrid.RowsExtended.Count;

            List<string> properties = DataGrid.ColumnHeaders;

            if (properties.Count.ToString() != defaultcount)
            {
                Utilities.LogMessage("VerifyLegendProperty :: Default property count to show is not correct");
                Utilities.TakeScreenshot("VerifyLegendProperty");
                throw new Exception("Default property count to show is not correct");
            }

            if (!properties.Contains(Show))
            {
                Utilities.LogMessage("VerifyLegendProperty :: Default Show Column Header is not correct");
                Utilities.TakeScreenshot("VerifyLegendProperty");
                throw new Exception("Default property to show is not correct");
            }
            if (!properties.Contains(Name))
            {
                Utilities.LogMessage("VerifyLegendProperty ::  Default Target Column is not correct");
                Utilities.TakeScreenshot("VerifyLegendProperty");
                throw new Exception("Default property to show is not correct");
            }

            if (!properties.Contains(Color))
            {
                Utilities.LogMessage("VerifyLegendProperty ::  Default Color Column is not correct");
                Utilities.TakeScreenshot("VerifyLegendProperty");
                throw new Exception("Default property to show is not correct");
            }

            //if there is an agent the seriesCount will not equal to the default seriesCount so comment the following lines
            //if (seriesCount.ToString() != SeriesCount)
            //{
            //    Utilities.LogMessage("VerifyLegendProperty ::  Default Series count in Legend is" + seriesCount.ToString() + " " + SeriesCount);
            //    Utilities.TakeScreenshot("VerifyLegendProperty");
            //    throw new Exception("Default series count to show is not correct");
            //}
            //}

        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Verify Legend Sort
        /// </summary>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static void VerifyLegendSort(List<string> legends)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            Utilities.LogMessage(currentMethodName + ":: VerifyLegendSort");
            List<int> Indexlist = new List<int>();
            List<string> SortListAsc = new List<string>();
            List<string> SortListDes = new List<string>();
            SortListAsc.Add("Ascending");
            SortListDes.Add("Descending");
            DataGridControl DataGrid = GetLegendDataGrid();
            List<string> properties = DataGrid.ColumnHeaders;
            MomConsole.Views.PerformanceChart.PerformanceChart chart = new MomConsole.Views.PerformanceChart.PerformanceChart();
            foreach (string property in legends)
            {
                string legendProperty = RescourceFinder(property);

                int column = DataGrid.GetColumnIndex(legendProperty);

                Utilities.LogMessage(currentMethodName + ":: Begin to verify column =" + column.ToString());
                Indexlist.Add(column);

                Sleeper.Delay(MomCommon.Constants.OneSecond);
                Utilities.LogMessage(currentMethodName + ":: Begin to Click sort");
                DataGrid.ClickColumnHeader(column - 1);

                Utilities.LogMessage(currentMethodName + ":: Begin to verify Ascending sort for" + property + " Resource is " + legendProperty);
                if (!MomConsole.MomControls.DashboardGadgets.AlertComponent.Personalization.Personalization.VerifyRowsSort(DataGrid.RowsExtended, Indexlist, SortListAsc))
                {
                    throw new Exception(currentMethodName + ":: Ascending Sort is not correct");
                }
                CoreManager.MomConsole.Waiters.WaitForStatusReady(MomCommon.Constants.DefaultDialogTimeout);

                DataGrid.ClickColumnHeader(column - 1);
                Utilities.LogMessage(currentMethodName + ":: Begin to verify Descending sort");
                if (!MomConsole.MomControls.DashboardGadgets.AlertComponent.Personalization.Personalization.VerifyRowsSort(DataGrid.RowsExtended, Indexlist, SortListDes))
                {
                    throw new Exception(currentMethodName + ":: Descending Sort is not correct");
                }
                Indexlist.Clear();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(MomCommon.Constants.DefaultDialogTimeout);
                Sleeper.Delay(MomCommon.Constants.OneSecond);
            }
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Select item in Personalization wizard
        /// </summary>
        /// <param name="legends">Selected item in Personalization wizard</param>
        /// <param name="PerformanceViewPath">PerformanceView Path</param>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static void PersonalizeSelection(List<string> legends, string PerformanceViewPath)
        {
            Utilities.LogMessage("PersonalizeSelection");
            MomConsole.Views.Dashboard.Wizard.DashboardParams Params = new MomConsole.Views.Dashboard.Wizard.DashboardParams();
            Params.Template = new MomConsole.Views.Dashboard.Wizard.PerformanceChart();
            MomConsole.Views.Dashboard.Wizard.PerformanceChart.CustomPagesParams custom = new MomConsole.Views.Dashboard.Wizard.PerformanceChart.CustomPagesParams();
            MomConsole.Views.PerformanceChart.PerformanceChart chart = new MomConsole.Views.PerformanceChart.PerformanceChart();
            Utilities.LogMessage("PersonalizeSelection :: Binding Resource");
            for (int i = 0; i < legends.Count; i++)
            {
                legends[i] = RescourceFinder(legends[i]);
            }

            custom.PropertiesShowLegend = legends;

            Params.CustomPageParams = custom;
            Utilities.LogMessage("PersonalizeSelection :: Launch Personalizaton");

            CoreManager.MomConsole.Waiters.WaitForReady();

            MomConsole.MomControls.DashboardControls.WidgetViewHost wvH = new MomConsole.MomControls.DashboardControls.WidgetViewHost(new Window(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='SCOMViewHost'"), MomCommon.Constants.OneSecond * 5));
            wvH.PersonalizeWidget(Params.CustomPageParams);

        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Verify Selected Legend Property
        /// </summary>
        /// <param name="legends">Selected item in Personalization wizard</param>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static bool VerifySelectedLegendProperty(List<string> legends)
        {
            Utilities.LogMessage("VerifySelectedLegendProperty");
            int maxRetry = 20;
            int count = 0;
            bool needRetry = false;
            bool verifyPass = false;
            Utilities.LogMessage("VerifySelectedLegendProperty :: Binding Resource");
            MomConsole.Views.PerformanceChart.PerformanceChart chart = new MomConsole.Views.PerformanceChart.PerformanceChart();

            for (int i = 0; i < legends.Count; i++)
            {
                legends[i] = RescourceFinder(legends[i]);
            }
            while (count < maxRetry)
            {
                try
                {
                    needRetry = false;
                    foreach (string legend in legends)
                    {
                        DataGridControl DataGrid = GetLegendDataGrid();
                        //Add refresh to load grid again
                        DataGrid.RefreshColumnHeaders();
                        List<string> properties = DataGrid.ColumnHeaders;
                        int tryTime = 0;
                        while (!properties.Contains(legend) && tryTime <= maxRetry)
                        {
                            // Retry to get the chart fully displayed
                            Utilities.LogMessage("VerifySelectedLegendProperty :: Retry to find " + legend);
                            Sleeper.Delay(MomCommon.Constants.OneSecond);
                            tryTime++;
                            DataGrid = GetLegendDataGrid();
                            properties.Clear();
                            properties = DataGrid.ColumnHeaders;
                        }
                        if (!properties.Contains(legend))
                        {
                            verifyPass = false;
                            //throw new Exception("VerifySelectedLegendProperty ::Legend is not displayed for property " + legend); 
                            Utilities.LogMessage("VerifySelectedLegendProperty ::Legend is not displayed for property " + legend);
                        }
                        else
                        {
                            Utilities.LogMessage("VerifySelectedLegendProperty :: legend found" + legend);
                            verifyPass = true;
                        }

                    }

                }
                catch (System.InvalidOperationException)
                {
                    Utilities.LogMessage("VerifySelectedLegendProperty ::Retry to find performance view content");
                    count++;
                    Sleeper.Delay(MomCommon.Constants.OneSecond * 2);
                    needRetry = true;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("VerifySelectedLegendProperty ::Retry to find performance widget");
                    count++;
                    Sleeper.Delay(MomCommon.Constants.OneSecond * 2);
                    needRetry = true;
                }

                if (!needRetry)
                {
                    break;
                }

            }

            return verifyPass;

        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Widget Creation
        /// </summary>
        /// <param name="settings">Performance widget settings paramters</param>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static void WidgetCreation(MomConsole.Views.Dashboard.Wizard.DashboardParams settings)
        {
            Utilities.LogMessage("WidgetCreation :: WidgetCreation Launch");
            MomConsole.MomControls.DashboardControls.WidgetViewHost wvH = new MomConsole.MomControls.DashboardControls.WidgetViewHost(new Window(new QID(";[UIA]AutomationId='SCOMViewHost'"), 5000));
            wvH.AddWidget(settings);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Widget Configuration
        /// </summary>
        /// <param name="description">Widget description</param>
        /// <param name="generatedChartName">Chart Name</param>
        /// <param name="settings">Widget settings</param>
        /// <history>
        /// [v-kantao] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        /// 
        public static void WidgetConfiguration(string generatedChartName, string description, MomConsole.Views.Dashboard.Wizard.DashboardParams settings)
        {
            Utilities.LogMessage("WidgetConfiguration :: WidgetConfiguration Launch");
            MomConsole.Views.Dashboard.Wizard.PerformanceChart.CustomPagesParams custom = new MomConsole.Views.Dashboard.Wizard.PerformanceChart.CustomPagesParams();

            custom = (MomConsole.Views.Dashboard.Wizard.PerformanceChart.CustomPagesParams)settings.CustomPageParams;

            MomConsole.MomControls.DashboardControls.WidgetViewHost wvH = new MomConsole.MomControls.DashboardControls.WidgetViewHost(new Window(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='SCOMViewHost'"), MomCommon.Constants.OneSecond * 5));
            wvH.ConfigureWidget(generatedChartName, description, custom);
        }


        #endregion

        #region Private Methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to return the resource string, Please do construct first
        /// </summary>
        /// <returns>Resource string of the control</returns>
        ///  <param name="controlName">Control name</param>)
        /// <history>
        ///  
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string RescourceFinder(string controlName)
        {
            Utilities.LogMessage("RescourceFinder");
            string rescourceString;

            if (controlName == "Target")
            {
                rescourceString = Name;
            }
            else if (controlName == "Show")
            {
                rescourceString = Show;
            }
            else if (controlName == "Color")
            {
                rescourceString = Color;
            }
            else if (controlName == "Minimum Value")
            {
                rescourceString = Minimum;
            }
            else if (controlName == "Average Value")
            {
                rescourceString = AverageValue;
            }
            else if (controlName == "Path")
            {
                rescourceString = Path;
            }
            else if (controlName == "Performance Object")
            {
                rescourceString = ObjectName;
            }
            else if (controlName == "Performance Counter")
            {
                rescourceString = CounterName;
            }
            else if (controlName == "Performance Instance")
            {
                rescourceString = InstanceName;
            }
            else
            {
                Utilities.LogMessage("RescourceFinder :: No matched resource find");
                rescourceString = controlName;
            }

            Utilities.LogMessage("RescourceFinder :: Got resource for " + controlName + " is " + rescourceString);
            return rescourceString;
        }

        private static DataGridControl GetLegendDataGrid()
        {
            DataGridControl dataGrid = null;
            Exception lastException = null;
            Sleeper sleeper = new Sleeper(Mom.Test.UI.Core.Common.Constants.OneMinute);

            while (sleeper.IsNotExpired && dataGrid == null)
            {
                try
                {
                    dataGrid = new DataGridControl(CoreManager.MomConsole.ViewPane, new QID(Strings.QidInnerDataGrid));
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                sleeper.Sleep();
            }

            if (dataGrid != null)
            {
                dataGrid.WaitForRowsLoaded();
                return dataGrid;
            }
            else
            {
                throw lastException;
            }
        }
        #endregion



        #region Strings
        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains resource string for QidInnerDataGrid
            /// </summary>
            public const string QidInnerDataGrid = ";[UIA]AutomationId='InnerDataGrid'";



            #endregion


        }
        #endregion
    }
}
