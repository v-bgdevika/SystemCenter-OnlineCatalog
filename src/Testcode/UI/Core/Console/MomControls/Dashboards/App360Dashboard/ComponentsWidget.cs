namespace Mom.Test.UI.Core.Console.MomControls.Dashboards.App360Dashboard
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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

    public partial class ApplicationOverviewDashboard : Dashboard
    {
        public class ComponentsWidget : DataGridViewHost
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

            [Resource(ID = "ColumnInstances")]
            private string columnInstances;
            public static string expectedColumnInstances;

            [Resource(ID = "ColumnTier")]
            private string columnTier;
            public static string expectedColumnTier;

            private string distributedAppName = null;

            #region Constants

            // There is a know MAUI issue that it returns all column headers under the scope of the whole main window 
            // no matter what parent window you pass, hence we need to hardcode the index of each column header
            private const int chIndexHealth = 0;
            private const int chIndexDisplayName = 1;
            //private const int chIndexInstances = 5;
            private const int chIndexTier= 13;

            #endregion

            #region Constructor

            public ComponentsWidget(Window knownWindow, XElement element, string distributedAppName)
                : base(knownWindow)
            {
                ResourceLoader.LoadResources(this, element);

                expectedWidgetTitle = widgetTitle;
                expectedColumnHealth = columnHealth;
                expectedColumnDisplayName = columnDisplayName;
                expectedColumnInstances = columnInstances;
                expectedColumnTier = columnTier;

                this.distributedAppName = distributedAppName;
            }

            #endregion

            #region Public Methods

            public bool VerifyColumHeaders()
            {
                Utilities.LogMessage("ActualColumnTier index " + this.DataGrid.GetColumnIndex(columnTier));
                if (String.Equals(this.DataGrid.ColumnHeaders[chIndexHealth].Trim(), expectedColumnHealth)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexDisplayName].Trim(), expectedColumnDisplayName)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexTier].Trim(), expectedColumnTier))
                {
                    Utilities.LogMessage("ComponentsWidget.VerifyColumHeaders :: All column headers in widget match.");
                    return true;
                }
                else
                {
                    Utilities.LogMessage("ComponentsWidget.VerifyColumHeaders :: There is column header in widget mismatches.");
                    Utilities.LogMessage("ExpectedColumnHealth " +expectedColumnHealth);
                    Utilities.LogMessage("expectedColumnDisplayName " + expectedColumnDisplayName);
                    Utilities.LogMessage("expectedColumnInstances " + expectedColumnInstances);
                    Utilities.LogMessage("expectedColumnTier " + expectedColumnTier);
                    Utilities.LogMessage("ActualColumnHealth " + this.DataGrid.ColumnHeaders[chIndexHealth].Trim());
                    Utilities.LogMessage("ActualColumnDisplayName " + this.DataGrid.ColumnHeaders[chIndexDisplayName].Trim());
                    Utilities.LogMessage("ActualColumnTier " + this.DataGrid.ColumnHeaders[chIndexTier].Trim());
                    Utilities.LogMessage("ActualColumnTier index " + this.DataGrid.GetColumnIndex(columnTier));

                    return false;
                }
            }

            public bool VerifyComponentDisplayName()
            {
                // get the list of actual component display names
                List<string> actualComponentDisplayNames = new List<string>();
                foreach (var row in this.DataGrid.RowsExtended)
                {
                    actualComponentDisplayNames.Add(row.CellsExtended[chIndexDisplayName].NameExtended);
                }

                #region Get Expected Component Names by SDK

                List<string> expectedComponentDisplayNames = new List<string>();
                ManagementGroup mg = new ManagementGroup(Topology.RootMomSdkServerName);

                // get the 360 DA class
                ManagementPackClassCriteria clsCriteria = new ManagementPackClassCriteria("Name = 'Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication'");
                ManagementPackClass cls360DA = mg.EntityTypes.GetClasses(clsCriteria)[0];

                // get the instance of selected distributed application
                MonitoringObjectCriteria objCriteria = new MonitoringObjectCriteria("DisplayName = '" + this.distributedAppName + "'", cls360DA);
                IObjectReader<MonitoringObject> objs = mg.EntityObjects.GetObjectReader<MonitoringObject>(objCriteria, new ObjectQueryOptions());
                MonitoringObject selectedDistributedAppObj = objs.GetData(0);
                // get all related monitoring object with one level traversal depth
                ReadOnlyCollection<MonitoringObject> allComponentObjs = selectedDistributedAppObj.GetRelatedMonitoringObjects(TraversalDepth.OneLevel);

                // store the component display names into list
                foreach (var obj in allComponentObjs)
                {
                    ReadOnlyCollection<MonitoringObject> roles = obj.GetRelatedMonitoringObjects(TraversalDepth.OneLevel);
                    foreach (var role in roles)
                    {
                        expectedComponentDisplayNames.Add(role.DisplayName);
                    }
                }

                #endregion

                // compare display names between expected components and actual components
                if (expectedComponentDisplayNames.Count != actualComponentDisplayNames.Count)
                {
                    Utilities.LogMessage("ComponentsWidget.VerifyComponentDisplayName :: counts of expected components and actual components mismatch.");
                    return false;
                }
                else
                {
                    foreach (var item in expectedComponentDisplayNames)
                    {
                        if (!actualComponentDisplayNames.Contains(item))
                        {
                            Utilities.LogMessage("ComponentsWidget.VerifyComponentDisplayName :: expected component '" + item + "' not found in actual components.");
                            return false;
                        }
                    }
                    return true;
                }
            }

            #endregion
        }
    }
}
