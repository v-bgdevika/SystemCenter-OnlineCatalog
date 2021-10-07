using System;
using System.Collections.ObjectModel;
using Maui.Core;
using Microsoft.EnterpriseManagement.Monitoring;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using MomConsole = Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Console.MomControls.DashboardGadgets;

namespace Mom.Test.UI.Core.Console.MomControls.Dashboards
{
    public class NetworkSummaryDashboard : Dashboard
    {
        // Use UIClassMaker to get the QIDs
        // ClassName:	"ScrollViewer"


        public QID NodeWithMostAlertsView = new QID(";[UIA]AutomationId='SCOMViewHost' && Instance='6'");

        // Views on the dashboard
        private NodeWithMostAlert nodesWithMostAlert;
        private Window parentWindow = null;
        // ViewPane pane = null;
        //INetworkDevicesQuery networkDevicesQuery = null;

        //public ReadOnlyCollection<MonitoringObject> Devices
        //{
        //    get;
        //    private set;
        //}

        public NodeWithMostAlert NodesWithMostAlert
        {
            get
            {
                return nodesWithMostAlert;
            }
        }

        public static string Path
        {
            get
            {
                return MomConsole.NavigationPane.Strings.Monitoring +
                    Constants.PathDelimiter + "Network Management"
                    + Constants.PathDelimiter + "Network Summary Dashboard";
            }
        }

        public NetworkSummaryDashboard(Window knownWindow)
            : base(knownWindow)
        {
            // this.networkDevicesQuery = query;
            //this.OpenView();
            this.parentWindow = knownWindow;
            this.parentWindow.Extended.SetFocus();

            // build the provider of the data
               INodesWithMostAlerts nodesWithMostAlertprovider = new NodesWithMostAlerts();

            this.nodesWithMostAlert = new NodeWithMostAlert(this.NodeWithMostAlertsInSummaryDashBoardView(), nodesWithMostAlertprovider);
  
        }

        
        private Window NodeWithMostAlertsInSummaryDashBoardView()
        {
            return new Window(this, NodeWithMostAlertsView, TIME_OUT * 5);
        }

    }
}