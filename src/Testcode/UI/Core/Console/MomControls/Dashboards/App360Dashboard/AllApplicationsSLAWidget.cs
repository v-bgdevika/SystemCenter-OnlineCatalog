namespace Mom.Test.UI.Core.Console.MomControls.Dashboards.App360Dashboard
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.IO;
    using System.Xml.Linq;
    using Maui.Core.WinControls;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using Mom.Test.UI.Core.ResourceLoader;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Common;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.Monitoring;
    #endregion

    public partial class AllApplicationsDashboard : Dashboard
    {
        public class AllApplicationsSLAWidget : DataGridViewHost
        {
            [Resource(ID = "Title")]
            private string widgetTitle;
            public static string expectedWidgetTitle;

            //[Resource(ID = "ColumnSLACompliance")]
            //private string columnSLACompliance;
            //public static string expectedColumnSLACompliance;

            //[Resource(ID = "ColumnSLAName")]
            //private string columnSLAName;
            //public static string expectedColumnSLAName;

            #region Constants

            // There is a know MAUI issue that it returns all column headers under the scope of the whole main window 
            // no matter what parent window you pass, hence we need to hardcode the index of each column header
            private const int chIndexSLACompliance = 6;
            private const int chIndexDisplayName = 1;

            #endregion

            #region Constructor

            public AllApplicationsSLAWidget(Window knownWindow, XElement element)
                : base(knownWindow)
            {
                ResourceLoader.LoadResources(this, element);

                expectedWidgetTitle = widgetTitle;
                //UI has changed, doesn't contain this two string any more
                //expectedColumnSLACompliance = columnSLACompliance;
                //expectedColumnSLAName = columnSLAName;
            }

            #endregion

            #region Public Methods

            //public bool VerifyColumHeaders()
            //{
            //    if (String.Equals(this.DataGrid.ColumnHeaders[chIndexSLACompliance].Trim(), expectedColumnSLACompliance)
            //        && String.Equals(this.DataGrid.ColumnHeaders[chIndexDisplayName].Trim(), expectedColumnSLAName))
            //    {
            //        Utilities.LogMessage("AllApplicationsSLAWidget.VerifyColumHeaders :: All column headers in widget match.");
            //        return true;
            //    }
            //    else
            //    {
            //        Utilities.LogMessage("AllApplicationsSLAWidget.VerifyColumHeaders :: There is column header in widget mismatches.");
            //        return false;
            //    }
            //}

            public bool VerifySLADisplayName(string selctedAppName)
            {
                Utilities.LogMessage("VerifySLADisplayname::");
                // get the list of actual SLA display names
                List<string> actualSLADisplayNames = new List<string>();
                Window SLAWidget = new Window (new QID(QIDs.allApplicationsSLAQID),TIME_OUT);
                Maui.Core.MauiCollection<IScreenElement> InstanceCollection = SLAWidget.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly]ClassName='Header1Label'", null);
               
                foreach (IScreenElement row in InstanceCollection)
                {
                    
                    actualSLADisplayNames.Add(row.Name);                 
                }

                #region Get Expected SLA Names by SDK
                // get the list of expected SLA diaplay names using sdk
                List<string> expectedSLADisplayNames = new List<string>();
                ManagementGroup mg = new ManagementGroup(Topology.RootMomSdkServerName);

                // get 3-tier application class
                ManagementPackClassCriteria criteria = new ManagementPackClassCriteria("Name = 'Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication'");
                ManagementPackClass cls = mg.EntityTypes.GetClasses(criteria)[0];

                // get the 3-tier application instance that is currently selected
                MonitoringObjectCriteria objCriteria = new MonitoringObjectCriteria("DisplayName = '" + selctedAppName + "'", cls);
                IObjectReader<MonitoringObject> objs = mg.EntityObjects.GetObjectReader<MonitoringObject>(objCriteria, new ObjectQueryOptions());
                MonitoringObject selectedInstance = objs.GetData(0);

                // get all SLAs in management group
                IList<ManagementPackConfigurationGroup> slas = mg.ServiceLevelAgreements.GetConfigurationGroups();
                foreach (var sla in slas)
                {
                    // get class with id being the 3-tier class id
                    ManagementPackClassCriteria cri = new ManagementPackClassCriteria("Id = '" + sla.Target.Id + "'");
                    ManagementPackClass targetCls = mg.EntityTypes.GetClasses(cri)[0];

                    // if the selected distributed application instance is the instance of 3-tier class, add the SLA display name
                    if (selectedInstance.IsInstanceOf(targetCls))
                    {
                        expectedSLADisplayNames.Add(sla.DisplayName);
                    }
                }
                #endregion
                Utilities.LogMessage("ActualSLADisplayName :: " + actualSLADisplayNames.Count);
                Utilities.LogMessage("ExpectedSLADisplayName:: " + expectedSLADisplayNames.Count);
                // compare display names between expected SLAs and actual SLAs
                if (expectedSLADisplayNames.Count != actualSLADisplayNames.Count)
                {
                    Utilities.LogMessage("AllApplicationsSLAWidget.VerifySLADisplayName :: counts of expected SLAs and actual SLAs mismatch.");
                    return false;
                }
                else
                {
                    foreach (var item in expectedSLADisplayNames)
                    {
                        if (!actualSLADisplayNames.Contains(item))
                        {
                            Utilities.LogMessage("AllApplicationsSLAWidget.VerifySLADisplayName :: expected SLA '" + item + "' not found in actual SLAs");
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
