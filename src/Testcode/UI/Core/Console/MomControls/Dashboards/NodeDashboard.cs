using System;
using System.Linq;
using Maui.Core;
using Mom.Test.UI.Core.Common;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Monitoring.Components;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using dataAccess = Microsoft.EnterpriseManagement.Presentation.DataAccess;
using System.Xml.Linq;
using System.Threading;
using System.Collections.Generic;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
namespace Mom.Test.UI.Core.Console.MomControls.Dashboards
{    
    public class NetworkNodeDashboard : Dashboard
    {
        // Use UIClassMaker to get the QIDs
        public QID criticalAlertsGeneratedByThisNode = new QID(";[UIA]AutomationId='SCOMViewHost' && Instance='7'");
        public QID scrollViewer = new QID(";[UIA]AutomationID='VerticalScrollBar' && ClassName='ScrollBar'");

        private VerticalScrollBar verticalScrollBar;
        /// <summary>
        /// The title of the dashboard
        /// </summary>
        public VerticalScrollBar VerticalScrollBar
        {
            get
            {
                if (this.verticalScrollBar == null)
                {
                    this.verticalScrollBar = new VerticalScrollBar(this, ControlQIDs.verticalScrollBarQID, TIME_OUT);
                }

                return this.verticalScrollBar;
            }
        }


        // Views on the dashboard
        private AlertsView alertsView;
       // private NodeWithMostAlert alertDetailsView;

        // parent window of the dashboard
        private Window parentWindow = null;

        public AlertsView AlertView
        {
            get
            {
                return alertsView;
            }
        }
        
        public NetworkNodeDashboard(Window knownWindow, dataAccess.IDataObject target)
            : base(knownWindow)
        {
            // Console.WriteLine("Opening the node dashboard for the node: " + node.DisplayName);
           
            this.parentWindow = knownWindow;
            this.parentWindow.Extended.SetFocus();

            // build up the providers of the data
            //IAlertsQuery alertsProvider = new AlertsQuery();
           // IAlertDetailsDisplayStringQuery alertDetailsDisplayStringQuery = new AlertDetailsDisplayStringQuery();
            //IAlertDetailsQuery alertDetailsQuery = new  Mom.Test.UI.Core.Common.AlertDetailsQuery();
            
            if (target!=null)
               // To Do Fix It Get correct Wy to Get TargetID from IdataObject
               // alertsProvider.TargetId = target["ManagedEntityId"];
            // Load the dashboard resources
            
               // resourcesFile = "NetworkNodeDashboardResources.xml";

            ResourceLoader.ResourceLoader.LoadResources(this, ResourceLoader.ResourceLoader.GetSection("Dashboard", "NetworkNodeDashboardResources.xml"));

            /// <summary>
            /// 
            /// </summary>
            Dictionary<string, object> properties = new Dictionary<string, object>();

            // create the views
            this.alertsView = new AlertsView(
                this.GetCriticalAertsGeneratedByThisNodeView(),
                properties,
                ResourceLoader.ResourceLoader.GetSection("AlertsView", "NetworkNodeDashboardResources.xml"));

        }

        public NetworkNodeDashboard(Window knownWindow, MonitoringObject node)
            : base(knownWindow)
        {

        }

        public void Close()
        {
            this.parentWindow.Extended.CloseWindow();
           // Console.WriteLine("Network node dashboard instance is closed");
        }

        public void VerifyContents()
        {
           
        }

        #region ViewHost to ContainerGrid mappings

        private Window GetCriticalAertsGeneratedByThisNodeView()
        {
            return new Window(this, criticalAlertsGeneratedByThisNode, TIME_OUT * 5);
        }

        #endregion

        #region View Verification

        private void VerifyAlertsInCriticalAlertViewForNode()
        {
            this.alertsView.Verify();
        }


        #endregion
    }
}
