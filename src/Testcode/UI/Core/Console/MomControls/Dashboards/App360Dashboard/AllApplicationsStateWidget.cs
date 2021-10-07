namespace Mom.Test.UI.Core.Console.MomControls.Dashboards.App360Dashboard
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.IO;
    using System.Xml.Linq;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using Mom.Test.UI.Core.ResourceLoader;
    using Maui.Core.Utilities;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Common;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.Monitoring;
    #endregion

    public partial class AllApplicationsDashboard : Dashboard
    {
        public class AllApplicationsStateWidget : DataGridViewHost
        {
            [Resource(ID = "Title")]
            private string widgetTitle;
            public static string expectedWidgetTitle;

            [Resource(ID = "ColumnHealth")]
            private string columnHealth;
            public static string expectedColumnHealth;

            [Resource(ID = "ColumnDisplayName")]
            private string columnDisplayName;
            public static string expectedColumnDisplayName;

            [Resource(ID = "ColumnAverageResponseTime")]
            private string columnAverageResponseTime;
            public static string expectedColumnAverageResponseTime;

            [Resource(ID = "ColumnAvailability")]
            private string columnAvailability;
            public static string expectedColumnAvailability;

            [Resource(ID = "ColumnPerformance")]
            private string columnPerformance;
            public static string expectedColumnPerformance;

            [Resource(ID = "ColumnReliability")]
            private string columnReliability;
            public static string expectedColumnReliability;

            #region Constants

            // There is a know MAUI issue that it returns all column headers under the scope of the whole main window 
            // no matter what parent window you pass, hence we need to hardcode the index of each column header
            private const int chIndexHealth = 0;
            private const int chIndexDisplayName = 1;
            private const int chIndexAverageResponseTime = 2;
            private const int chIndexAvailability = 3;
            private const int chIndexPerformance = 4;
            private const int chIndexReliability = 5;

            #endregion

            #region Constructor

            public AllApplicationsStateWidget(Window knownWindow, XElement element)
                : base(knownWindow)
            {
                ResourceLoader.LoadResources(this, element);

                expectedWidgetTitle = widgetTitle;
                expectedColumnHealth = columnHealth;
                expectedColumnDisplayName = columnDisplayName;
                expectedColumnAverageResponseTime = columnAverageResponseTime;
                expectedColumnAvailability = columnAvailability;
                expectedColumnPerformance = columnPerformance;
                expectedColumnReliability = columnReliability;
            }

            #endregion

            #region Properties

            public string SelectedApplicationName
            {
                get
                {
                    string selectedApplicationName = null;
                    foreach (var row in this.DataGrid.RowsExtended)
                    {
                        if (row.ScreenElementExtended.HasFocus)
                        {
                            selectedApplicationName = row.CellsExtended[chIndexDisplayName].NameExtended;
                        }
                    }
                    if (String.IsNullOrEmpty(selectedApplicationName))
                    {
                        // if selectedApplicationName is null or empty, return the 1st row application name
                        selectedApplicationName = this.DataGrid.RowsExtended[0].CellsExtended[chIndexDisplayName].NameExtended;
                    }
                    return selectedApplicationName;
                }
            }

            #endregion

            #region Public Methods

            public void SelectRowByIndex(int rowId)
            {
                if (rowId < 0 || rowId >= this.DataGrid.RowsExtended.Count)
                {
                    throw new InvalidOperationException("AllApplicationsStateWidget.SelectRowByIndex :: row index is out of range.");
                }
                else
                {
                    this.DataGrid.RowsExtended[rowId].CellsExtended[0].Select();
                    this.WaitForReady();
                }
            }

            public void SelectRowByApplicationName(string applicationName)
            {
                int rowIndex = this.GetRowIndexByAppName(applicationName);
                if (rowIndex == -1)
                {
                    throw new InvalidOperationException("AllApplicationsStateWidget.SelectRowByApplicationName :: expected distributed application is not found!");
                }
                else
                {
                    this.SelectRowByIndex(rowIndex);
                }
            }

            public bool VerifyColumHeaders()
            {
                if (String.Equals(this.DataGrid.ColumnHeaders[chIndexHealth].Trim(), expectedColumnHealth)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexDisplayName].Trim(), expectedColumnDisplayName)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexAverageResponseTime].Trim(), expectedColumnAverageResponseTime)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexAvailability].Trim(), expectedColumnAvailability)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexPerformance].Trim(), expectedColumnPerformance)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexReliability].Trim(), expectedColumnReliability))
                {
                    Utilities.LogMessage("AllApplicationsStateWidget.VerifyColumHeaders :: All column headers in widget match.");
                    return true;
                }
                else
                {
                    Utilities.LogMessage("AllApplicationsStateWidget.VerifyColumHeaders :: There is column header in widget mismatches.");
                    return false;
                }
            }

            public bool VerifyEntityDisplayName()
            {
                // get the list of actual entity display names
                List<string> actualEntityDisplayNames = new List<string>();
                foreach (var row in this.DataGrid.RowsExtended)
                {
                    actualEntityDisplayNames.Add(row.CellsExtended[chIndexDisplayName].NameExtended);
                }

                #region Get Expected DistributedApp Names by SDK
                // use sdk to get the all instances of class "Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication"
                List<string> expectedEntityDisplayNames = new List<string>();
                ManagementGroup mg = new ManagementGroup(Topology.RootMomSdkServerName);

                // get the class
                ManagementPackClassCriteria criteria = new ManagementPackClassCriteria("Name = 'Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication'");
                ManagementPackClass cls = mg.EntityTypes.GetClasses(criteria)[0];

                // get the objects
                MonitoringObjectCriteria objCriteria = new MonitoringObjectCriteria("", cls);
                IObjectReader<MonitoringObject> objs = mg.EntityObjects.GetObjectReader<MonitoringObject>(objCriteria, new ObjectQueryOptions());

                // add to list
                foreach (var obj in objs)
                {
                    expectedEntityDisplayNames.Add(obj.DisplayName);
                }

                #endregion

                // compare display names between expected entities and actual entities
                if (expectedEntityDisplayNames.Count != actualEntityDisplayNames.Count)
                {
                    Utilities.LogMessage("AllApplicationsStateWidget.VerifyEntityDisplayName :: counts of expected entities and actual entities mismatch.");
                    return false;
                }
                else
                {
                    foreach (var item in expectedEntityDisplayNames)
                    {
                        if (!actualEntityDisplayNames.Contains(item))
                        {
                            Utilities.LogMessage("AllApplicationsStateWidget.VerifyEntityDisplayName :: expected entity '" + item + "' not found in actual entities.");
                            return false;
                        }
                    }
                    return true;
                }
            }

            #endregion

            #region Private Methods

            private int GetRowIndexByAppName(string distributedAppname)
            {
                int index = -1;
                for (int i = 0; i < this.DataGrid.RowsExtended.Count; i++)
                {
                    if (String.Equals(this.DataGrid.RowsExtended[i].CellsExtended[chIndexDisplayName].NameExtended.Trim(), distributedAppname))
                    {
                        index = i;
                        break;
                    }
                }
                return index;
            }

            #endregion
        }
    }
}
