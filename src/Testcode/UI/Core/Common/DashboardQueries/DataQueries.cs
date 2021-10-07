using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Monitoring;
//using Microsoft.EnterpriseManagement.Test.UI.Dashboards.Common;
using System.Globalization;
using Microsoft.EnterpriseManagement.Presentation.Controls.Data;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using System.Threading;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
//using System.Windows.Forms;
//using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Presentation.Controls.Queries;
using System.Collections;
using Microsoft.EnterpriseManagement.Presentation.Controls.DataGrid;
using NetworkDashBoard = Microsoft.EnterpriseManagement.Presentation.Controls.Data.NetworkDashboards;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace Mom.Test.UI.Core.Common
{
    #region Interfaces

    public interface INetworkDevicesQuery
    {
        ReadOnlyCollection<MonitoringObject> GetNetworkDevices();
    }

    public interface IAlertsQuery
    {
        IList<string> ProjectionColumns
        {
            get;
            set;
        }

        Guid TargetId
        {
           get;
           set;
        }

      IEnumerable<IDataObject> GetAlerts();
      IEnumerable<IDataObject> GetAllAlerts();
    }

    //public interface IAlertDetailsDisplayStringQuery
    //{
    //    IList<string> AlertProperties
    //    {
    //        get;
    //        set;
    //    }

    //    ICollection<IDataObject> GetPropertyNameAndDisplayNamePairs();
    //}

   // public interface IAlertDetailsQuery
  //  {
    //    Guid AlertId
    //    {
    //      get;
     //       set;
     //   }

     //   ICollection<IDataObject> PropertyNameAndDisplayNamePairs
     //  {
     //       get;
      //     set;
      //  }

    //    IEnumerable<IDataObject> GetAlertDetails();
    //}

    public interface INodesWithMostAlerts
    {

        IEnumerable<IDataObject> GetNodesWithMostAlert();
    }

    #endregion

    #region Implementations

    public class NetworkDevicesQuery : INetworkDevicesQuery
    {
        const string NetworkLibrary = "System.NetworkManagement.Library";

        public ReadOnlyCollection<MonitoringObject> GetNetworkDevices()
        {
            ManagementGroup connection = SDKConnectionManager.Current.GetManagementGroup();

            // Get the network management MP
            var networkMP = connection.GetManagementPacks().Where(mp => mp.Name.Equals(NetworkLibrary)).FirstOrDefault();

            // Get the node class
            var monitoringClass = connection.GetMonitoringClass("System.NetworkManagement.Node", networkMP);

            return connection.GetMonitoringObjects(monitoringClass);
        }
    }

    public class AlertsQuery : IAlertsQuery
    {        
       AutoResetEvent sync = new AutoResetEvent(false);
        DataGridCommonLibrary dataGridCommonLibrary = new DataGridCommonLibrary();

        public IList<string> ProjectionColumns
        {
            get;
            set;
        }

        public Guid TargetId
       {
            get;
            set;
        }

        private void query_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("AlertsQuery.query_PropertyChanged PropertyName: " + e.PropertyName);

           if (e.PropertyName == "Output") 
            {
               this.sync.Set();
            }

            if (e.PropertyName == "LastError")
            {
                this.sync.Set();
            }
        }


        public IEnumerable<IDataObject> GetAlerts()
        {
            throw new NotImplementedException();
        }
	public IEnumerable<IDataObject> GetAllAlerts()
        {
            throw new NotImplementedException();
        }
    }


    //public class AlertDetailsDisplayStringQuery : IAlertDetailsDisplayStringQuery
    //{
    //    AutoResetEvent sync = new AutoResetEvent(false);

    //    public IList<string> AlertProperties
    //    {
    //        get;
    //        set;
    //    }

    //    public ICollection<IDataObject> GetPropertyNameAndDisplayNamePairs()
    //    {
    //        if (this.AlertProperties == null)
    //        {
    //            throw new Exception("AlertProperties cannot be null");
    //        }

    //        AlertDisplayStringsQuery query = null;

    //        this.sync.Reset();
    //        Dispatcher threadDispatcher = null;

    //        Thread thread = new Thread(() =>
    //        {
    //            threadDispatcher = Dispatcher.CurrentDispatcher;
    //            SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(threadDispatcher));

    //            // Create an instance of the query
    //            query = new AlertDisplayStringsQuery();
    //            SDKConnectionManager.Current.GetUnityContainer().BuildUp(query.GetType(), query);

    //            // Set the necessary properties
    //            query.ConnectionSessionTicket = SDKConnectionManager.Current.GetConnectionSessionTicket();
    //            query.AlertProperties = this.AlertProperties;

    //            // Hook up notification
    //            query.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(query_PropertyChanged);

    //            query.Notify();

    //            Dispatcher.Run();
    //        });

    //        thread.SetApartmentState(ApartmentState.STA);
    //        thread.Start();

    //        this.sync.WaitOne();

    //        threadDispatcher.InvokeShutdown();

    //        return query.Output;
    //    }

    //    void query_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //    {
    //        Console.WriteLine("AlertDetailsDisplayStringQuery.query_PropertyChanged. PropertyName: " + e.PropertyName);

    //        if (e.PropertyName == "Output")
    //        {
    //            this.sync.Set();
    //        }

    //        if (e.PropertyName == "LastError")
    //        {
    //            this.sync.Set();
    //        }
    //    }
    //}

    //public class AlertDetailsQuery : IAlertDetailsQuery
    //{
    //    AutoResetEvent sync = new AutoResetEvent(false);

    //    public Guid AlertId
    //    {
    //        get;
    //        set;
    //    }

    //    public ICollection<IDataObject> PropertyNameAndDisplayNamePairs
    //    {
    //        get;
    //        set;
    //    }

    //    public IEnumerable<IDataObject> GetAlertDetails()
    //    {
    //        if (this.AlertId == null)
    //        {
    //            throw new Exception("AlertId cannot be null");
    //        }

    //        if (this.PropertyNameAndDisplayNamePairs == null)
    //        {
    //            throw new Exception("PropertyNameAndDisplayNamePairs cannot be null");
    //        }

    //        GenericPaneAlertQuery query  = null;
    //        this.sync.Reset();
    //        Dispatcher threadDispatcher = null;

    //        Thread thread = new Thread(() =>
    //        {
    //            threadDispatcher = Dispatcher.CurrentDispatcher;
    //            SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(threadDispatcher));

    //            // Create a new instance of the query
    //            query = new GenericPaneAlertQuery();
    //            SDKConnectionManager.Current.GetUnityContainer().BuildUp(query.GetType(), query);

    //            // Set the properties
    //            query.ConnectionSessionTicket = SDKConnectionManager.Current.GetConnectionSessionTicket();
    //            query.AlertId = this.AlertId;
    //            query.PropertyNameAndDisplayNamePairCollection = this.PropertyNameAndDisplayNamePairs;

    //            // Hook up notification
    //            query.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(query_PropertyChanged);

    //            query.Notify();

    //            Dispatcher.Run();
    //        });

    //        thread.SetApartmentState(ApartmentState.STA);
    //        thread.Start();

    //        this.sync.WaitOne();

    //        threadDispatcher.InvokeShutdown();

    //        return query.Output;
    //    }

    //    void query_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //    {
    //        Console.WriteLine("AlertDetailsQuery.query_PropertyChanged. PropertyName: " + e.PropertyName);

    //        if (e.PropertyName == "Output")
    //        {
    //            this.sync.Set();
    //        }

    //        if (e.PropertyName == "LastError")
    //        {
    //            this.sync.Set();
    //        }
    //    }
    //}

    public class NodesWithMostAlerts : INodesWithMostAlerts
    {
        AutoResetEvent sync = new AutoResetEvent(false);



        public IEnumerable<IDataObject> GetNodesWithMostAlert()
        {
            NetworkDashBoard.GetCurrentTopNodesByAlertsData query = null;
            this.sync.Reset();
            Dispatcher threadDispatcher = null;

            Thread thread = new Thread(() =>
            {
                threadDispatcher = Dispatcher.CurrentDispatcher;
                SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(threadDispatcher));

                query = new NetworkDashBoard.GetCurrentTopNodesByAlertsData();
                SDKConnectionManager.Current.GetUnityContainer().BuildUp(query.GetType(), query);

                query.ConnectionSessionTicket = SDKConnectionManager.Current.GetConnectionSessionTicket();
                FieldInfo fInfo = query.GetType().BaseType.GetField("dispatcher", BindingFlags.NonPublic | BindingFlags.Instance);
                fInfo.SetValue(query, threadDispatcher);

                query.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.query_PropertyChanged);

                query.Notify();

                Dispatcher.Run();
            });


            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            this.sync.WaitOne();
            threadDispatcher.InvokeShutdown();


            return query.Output;

        }

        void query_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("AlertDetailsQuery.query_PropertyChanged. PropertyName: " + e.PropertyName);

            if (e.PropertyName == "Output")
            {
                this.sync.Set();
            }

            if (e.PropertyName == "LastError")
            {
                this.sync.Set();
            }
        }
    }

    #endregion
}
