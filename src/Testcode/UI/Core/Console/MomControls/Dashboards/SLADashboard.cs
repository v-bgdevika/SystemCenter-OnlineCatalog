//-------------------------------------------------------------------
// <copyright file="SLADashboard.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   SLADB UI Access
// </summary>
//  <history>
//  [starrpar] 20OCT10:  Created
//  </history>
//-------------------------------------------------------------------
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Data;
using System.Collections.Generic;
using Maui.Core.Utilities;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.EnterpriseManagement.Presentation.Security;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Monitoring.Components;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation;
using Infra.Frmwrk;
using Maui.Core;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using Mom.Test.UI.Core.Common;
using Microsoft.EnterpriseManagement.Test.ScCommon;

using Constants = Mom.Test.UI.Core.Common.Constants;

#region unnecessary using statements
//using Mom.Test.UI.Core.Console;
//using Mom.Test.UI.Core.Console.MomControls;
//using Microsoft.EnterpriseManagement;
//using Microsoft.EnterpriseManagement.Warehouse;
//using System.Collections.ObjectModel;
//using Maui.Core.Utilities;
//using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
#endregion

namespace Mom.Test.UI.Core.Console.MomControls
{
    public interface IServiceLevelDashboardQuery
    {
        DataTable GetServiceLevels();

        DataTable GetServiceLevelObjectives();
    }

    public class ServiceLevelDashboardQuery : IServiceLevelDashboardQuery
    {
        # region Member Variables

        public const int INTERFACESPERNODE = 31;

        public struct WAMLGTCommandArgument
        {
            public string FieldName;
            public string Value;

            public WAMLGTCommandArgument(string p_field, string p_value)
            {
                FieldName = p_field;
                Value = p_value;
            }
        };
        public List<List<WAMLGTCommandArgument>> Combinations;

        public static String connectionString;

        private ICollection<IDataObject> providerResults = new List<IDataObject>();

        public static string DW_Account;
        public static string DW_Password;
        #endregion

        #region Constructors
        /// <summary>
        /// This is never used and is there only to hide the constructor
        /// </summary>        
        public ServiceLevelDashboardQuery()
        {
        }

        public static IServiceLevelDashboardQuery CurrentInstance
        {
            get;
            set;
        }
        #endregion

        public DataTable GetServiceLevels()
        {
            DataTable slas = new DataTable();

            return slas;
        }

        public DataTable GetServiceLevelObjectives()
        {
            DataTable slos = new DataTable();

            return slos;
        }
    }

    public class SLADashboardTest
    {
        private SLADashboard dashboard;
        private string dbName;
        internal static IContext context;

        public SLADashboardTest(string dbName, IContext ctx)
        {
            this.dbName = dbName;
            context = ctx;
        }

        public void OpenDashboard(MomConsoleApp consoleApp, IContext ctx)
        {
            NavigationPane navPane = consoleApp.NavigationPane;
            navPane.SelectNode(this.dbName, NavigationPane.NavigationTreeView.Monitoring);
            CoreManager.MomConsole.Waiters.WaitForReady();

            //get reference to dashboard window
            dashboard = new SLADashboard(CoreManager.MomConsole.MainWindow);
        }

        public void VerifyDashboardContents(IContext ctx)
        {
            dashboard.VerifyDashboardContents();
        }
    }

    public class SLADashboard : Mom.Test.UI.Core.Console.MomControls.DashboardControls.Dashboard
    {
        public class QIDs
        {
            public static QID ViewTitleQID = new QID(";[UIA]AutomationId='ViewTitle'");
            //public static QID SLAViewQID = new QID(";[UIA]AutomationId='SCOMViewHost' && Instance='1'");
            //public static QID SLOViewQID = new QID(";[UIA]AutomationId='SCOMViewHost' && Instance='2'");
            public static QID SLsGridQID = new QID(";[UIA]AutomationId='ServiceLevelsDataGrid'");
            public static QID SLOsGridQID = new QID(";[UIA]AutomationId='ServiceLevelObjectivesDataGrid'");

            public static QIDs SLOInstanceViewQIDs = new QIDs();
        }

        private IServiceLevelDashboardQuery query;
            
        private const string RESOURCE_FILE = "ServiceLevelDBResources.xml";
        XElement slaDBResourceElement = ResourceLoader.ResourceLoader.GetSection("SLADashboard", RESOURCE_FILE);

        SLAView slaView;
        SLOView sloView;

        public SLAView SLAView
        {
            get
            {
                return slaView;
            }
        }

        public SLADashboard(Window knownWindow)
            : base(knownWindow)
        {
            this.query = ServiceLevelDashboardQuery.CurrentInstance;

            //slaView = new SLAView(SLAViewHost, this.query, this.slaDBResourceElement);
            //sloView = new SLOView(SLOViewHost, this.query, this.slaDBResourceElement);
            slaView = new SLAView(ServiceLevelsGrid, this.query, this.slaDBResourceElement);
            sloView = new SLOView(ServiceLevelObjectivesGrid, this.query, this.slaDBResourceElement);
        }

        public void VerifyDashboardContents()
        {
            slaView.Verify();
        }

        private XDocument LoadResources(string fileName)
        {
            return XDocument.Load(fileName);
        }

        //internal Window SLAViewHost
        //{
        //    get
        //    {
        //        return new Window(this, QIDs.SLAViewQID, TIME_OUT * 5);
        //    }
        //}

        //internal Window SLOViewHost
        //{
        //    get
        //    {
        //        return new Window(this, QIDs.SLOViewQID, TIME_OUT * 5);
        //    }
        //}

        internal Window ServiceLevelsGrid
        {
            get
            {
                return new Window(this, QIDs.SLsGridQID, TIME_OUT * 5);
            }
        }

        internal Window ServiceLevelObjectivesGrid
        {
            get
            {
                return new Window(this, QIDs.SLOsGridQID, TIME_OUT * 5);
            }
        }
    }

    public class SLAView : Mom.Test.UI.Core.Console.MomControls.DashboardControls.DataGridViewHost
    {
        private IServiceLevelDashboardQuery query;
        static List<SLOView> observers;
        string slaName;
        string timeInterval;
        private string expectedSLATitle;
        IDataGateway gateway;
        public IUnityContainer Container
        {
            get;
            set;
        }
        public string sessionTicket
        {
            get;
            set;
        }

        #region Resources
        [ResourceLoader.Resource(ID = "ExpectedSLATitle")]
        private List<string> ExpectedSLATitle;

        [ResourceLoader.Resource(ID = "Groups")]
        private List<string> Groups;

        [ResourceLoader.Resource(ID = "HealthyState")]
        private List<string> HealthyState;

        [ResourceLoader.Resource(ID = "WarningState")]
        private List<string> WarningState;

        [ResourceLoader.Resource(ID = "CriticalState")]
        private List<string> CriticalState;

        [ResourceLoader.Resource(ID = "UnmonitoredState")]
        private List<string> UnmonitoredState;

        [ResourceLoader.Resource(ID = "Computer")]
        private List<string> Computer;

        [ResourceLoader.Resource(ID = "ColumnMapping")]
        public List<KeyValuePair<string, string>> columnMapping;
        #endregion

        #region Constructor
        public SLAView(Window knownWindow, IServiceLevelDashboardQuery query, XElement resource)
            : base(knownWindow)
        {
            //TODO: make sure resources work for localized
            ResourceLoader.ResourceLoader.LoadResources(this, resource);
            this.query = query;
            observers = new List<SLOView>();
        }
        #endregion

        #region Verify
        public void Verify()
        {
            verifyTitle();
            

            //this.WaitForReady();
            //verifyTitle();

            //Dictionary<string, object> parameters;
            //List<string> titles = GetIDOTitles();

            //BuildupContainer();
            //this.gateway = Container.Resolve<IDataGateway>();

            //parameters = prepareParametersList(dbName, false);
            //ICollection<IDataObject> dpResults = callDataProviderReader(parameters);
            //SortedDictionary<string, KeyValuePair<Type, object>> idoDPValues = Utilities.UnwindIDataObjectCollection(dpResults, titles);
            //Utilities.OutputDataObjectContents(idoDPValues);
            //parameters = null; //reset

            //DataTable slaDPData = Mom.Test.UI.Core.ConvertToDataTable.GenerateTable(dpResults, LocalConstants.slaDPTable);

            //parameters = prepareParametersList(dbName, true);
            //KeyValuePair<string, IEnumerable<IDataObject>> qcResults = callQueryComponentReader(parameters);
            //SortedDictionary<string, KeyValuePair<Type, object>> idoQCValues = Utilities.UnwindIDataObjectCollection(qcResults.Value, titles);
            //Utilities.OutputDataObjectContents(idoQCValues);

            //DataTable slaQueryData = Mom.Test.UI.Core.ConvertToDataTable.GenerateTable(qcResults.Value, LocalConstants.slaQueryTable);
            
            //currently blocked on using GridReader on grouped datagrid
            //DataTable slaGridData = callGridReader();

            //Workaround: for now will compare results from Data Provider against Query Component in place of DataGrid
            //Mom.Test.UI.Core.Comparer compareObj = new Mom.Test.UI.Core.Comparer();
            //compareObj.AddTable(slaDPData); 
            //compareObj.AddTable(slaQueryData);
            //compareObj.AddTable(slaGridData);
            //compareObj.LogTable(LocalConstants.slaDPTable, 0);
            //compareObj.LogTable(LocalConstants.slaQueryTable, 0);
            //compareObj.LogTable(LocalConstants.slaGridTable, 0);

            //compareObj.Filter(LocalConstants.slaDPTable, "filterCriteria", null, "filteredSlaDPTable");
            //compareObj.Compare("filteredSlaDPTable", "filteredSlaQueryTable");

            //compareObj.Filter(LocalConstants.slaQueryTable, "filterCriteria", null, "filteredSlaQueryTable");
            //compareObj.Filter(LocalConstants.slaGridTable, "filterCriteria", null, "filteredSlaGridTable");
            //compareObj.Compare("filteredSlaQueryTable", "filteredSlaGridTable");

            VerifySlaGridContentsAndNavigateToSloGrid();
        }
        #endregion

        #region observer methods
        public static void attach(SLOView slo)
        {
            observers.Add(slo);
        }

        public static void detach(SLOView slo)
        {
            observers.Remove(slo);
        }
        
        public void notify()
        {
            foreach (SLOView slo in observers)
            {
                slo.Update(this);
            }
        }

        public string getSLName()
        {
            string retVal = "";

            //pass information that can be used by SLO to perform validation
            retVal = this.slaName;

            return retVal;
        }
        public string getTimeInterval()
        {
            string retVal = "";

            //pass information that can be used by SLO to perform validation
            retVal = this.timeInterval;

            return retVal;
        }
        #endregion

        #region call Readers

        private ICollection<IDataObject> callDataProviderReader(Dictionary<string, object> parameters)
        {
            ICollection<Microsoft.EnterpriseManagement.Presentation.DataAccess.IDataObject> dataProviderDataObjectCollection =
                (ICollection<Microsoft.EnterpriseManagement.Presentation.DataAccess.IDataObject>)
                Mom.Test.UI.Core.DataProviderReader.Read(this.gateway, this.sessionTicket, Constants.ServiceLevelDataProvider, parameters);
            return dataProviderDataObjectCollection;
        }

        private KeyValuePair<string, IEnumerable<IDataObject>> callQueryComponentReader(Dictionary<string, object> parameters)
        {
            //ServiceLevelQuery SLQ = new ServiceLevelQuery();
            //SLQ.ConnectionSessionTicket = this.sessionTicket;
            //KeyValuePair<string, IEnumerable<IDataObject>> slaObjects = Mom.Test.UI.Core.QueryComponentReader.Read(SLQ, parameters);
            KeyValuePair<string, IEnumerable<IDataObject>> slaObjects = new KeyValuePair<string, IEnumerable<IDataObject>>();
            return slaObjects;
        }

        private DataTable callGridReader()
        {
            Dictionary<string, string> columnTypes = new Dictionary<string,string>();
            DataTable slaGridTable = GridReader.Read(this.DataGrid, LocalConstants.slaGridTable, columnTypes);

            return slaGridTable;
        }

        private void VerifySlaGridContentsAndNavigateToSloGrid()
        {
            Utilities.LogMessage("NOTE: next line logs multiple \'column header Name\' entries");
            var grid = this.DataGrid;

            if (grid == null)
            {
                throw new VarAbort("SLAView grid is null");
            }
            //verify SLA grid IS grouped
            if (!grid.HasGroups)
            {
                //for now (temporary workaround) wait 5 minutes and try SLA grid again - 
                //stored proc might not yet be in place - permanent fix is to add check for SP present
                Sleeper.Delay(300000);

                if (!grid.HasGroups)
                {
                    throw new VarAbort("SLAView grid expected to be grouped, appears to not be...");
                }
            }

            //need to know NameExtended value for each DataGridGroup expected to be in DataGroupGroups collection, in order to access

            //Note: Should be able to enumerate through list of groups, rather than having to explicitly specify each group
            //TODO: Need an enumerator for DataGroupGroups type - alternatively, use a counter for now

            //get first group information
            //(grid.FirstLevelGroups)[0].Select();
            //(grid.FirstLevelGroups)[0].Collapse();

            int retry = 0;
            DataGroupGroups groups = grid.FirstLevelGroups;
            while (retry < 3)
            {
                try
                {
                    retry++;
                    Utilities.LogMessage("Number of top level groups: " + groups.Count);
                    break;
                }
                catch
                {
                    Sleeper.Delay(5000);
                    groups = grid.FirstLevelGroups;
                }
            }
            //foreach (var dataGroupGroup in groups)
            //{
            //    //dataGroupGroup.Select();
            //    dataGroupGroup.Collapse();
            //}

            var counter = 0;
            foreach (var dataGroupGroup in groups)
            {
                if (dataGroupGroup.Name.Contains(Groups[counter]))
                {
                    //TODO: Can't Select group before parsing row contents because row.Select() fails
                    ////verify group can be collapsed and expanded
                    //dataGroupGroup.Select(); 
                    //dataGroupGroup.Collapse();
                    //dataGroupGroup.Expand();

                    //wait for group contents to be reinserted for accessibility
                    //Sleeper.Delay(15000);

                    //verify contents of group row(s)
                    var rowCollection = dataGroupGroup.Rows();
                    Utilities.LogMessage("Number of SLA instances in current SLA Group: " + rowCollection.Count);
                    this.Computer = new List<string>
                                        {
                                            System.Environment.GetEnvironmentVariable("COMPUTERNAME") + "." +
                                            System.Environment.GetEnvironmentVariable("FQDN")
                                        };
                    for (int i = 1; i < rowCollection.Count; i++ )
                    {
                        //row.Select(); //doesn't work

                        //set current SLA name to be used by SLO grid via observer pattern
                        //TODO: verify this...
                        this.slaName = dataGroupGroup.NameExtended;
                        Utilities.LogMessage("Group[" + counter + "]: " + slaName);

                        var cellCollection = rowCollection[i].CellsExtended;
                        foreach (var cell in cellCollection)
                        {
                            //verify cell name
                            //(need values from query component to verify)
                            var cellName = cell.NameExtended;
                            Utilities.LogMessage("Cell name: " + cellName);
                            cell.Select();

                            if (CriticalState != null && cellName.Equals(CriticalState[0]))
                                Utilities.LogMessage("Found SLA State: " + cellName);
                            else if (Computer != null && cellName.Equals(Computer[0]))
                                Utilities.LogMessage("Found SLA Instance Name: " + cellName);
                            else
                                Utilities.LogMessage("Found Unrecognized SLA value: " + cellName);

                            //need to add verification against resources file input (instance name) and query component results (state)
                        }

                        //move to SLO grid using observer pattern
                        this.notify();
                    }
                    //Utilities.LogMessage("Collapsing group: " + this.slaName);
                    //dataGroupGroup.Collapse();
                    
                    //Verifying SLAView, Title Text: Service Levels
                    //Titles match
                    //GetIDOTitles_Started...
                    //BuildupContainer_started
                    //Found SLA State: 3
                    //Found SLA Instance Name: NEB-136199-1.smx.net
                    //Found SLA State: 3
                    //Found SLA Instance Name: NEB-136199-1.smx.net
                    //Verifying SLOView, Title Text: Service Level Objectives
                    //Titles match
                    //GetIDOTitles_Started...
                    //Found SLO State: 3
                    //Found SLO Instance Name: HSAvailability
                    //Found Unrecognized SLO value: Windows Computer
                    //Found SLO State: 1
                    //Found SLO State: 3
                    //Found SLO Instance Name: HSWorkflows
                    //Found Unrecognized SLO value: Health Service
                    //Found SLO State: 1
                    //Found SLA State: 3
                    //Found SLA Instance Name: NEB-136199-1.smx.net
                    //Verifying SLOView, Title Text: Service Level Objectives
                    //Titles match
                    //GetIDOTitles_Started...
                    //Found SLO State: 3
                    //Found SLO Instance Name: HSAvailability
                    //Found Unrecognized SLO value: Windows Computer
                    //Found SLO State: 1
                    //Found SLO State: 3
                    //Found SLO Instance Name: HSWorkflows
                    //Found Unrecognized SLO value: Health Service
                    //Found SLO State: 1
                    //Found SLA State: 3
                    //Found SLA Instance Name: NEB-136199-1.smx.net
                    //Verifying SLOView, Title Text: Service Level Objectives
                    //Titles match
                    //GetIDOTitles_Started...
                    //Found SLO State: 3
                    //Found SLO Instance Name: HSAvailability
                    //Found Unrecognized SLO value: Windows Computer
                    //Found SLO State: 1
                    //Found SLO State: 3
                    //Found SLO Instance Name: HSWorkflows
                    //Found Unrecognized SLO value: Health Service
                    //Found SLO State: 1
                    //Selecting group: Name: HSSLA (2)
                    
                }
                else
                {
                    Utilities.LogMessage("Unexpected group found: " + dataGroupGroup.Name + ", skipping...");
                }
                counter++;
            }

            /*
            //get next group information
            DataGridGroup group2 = grid.FirstLevelGroups.Item(Groups[1]);

            //TODO: Can't Select group before parsing row contents because row.Select() fails
            ////verify group can be collapsed and expanded
            //group2.Select();
            //group2.Collapse();
            //group2.Expand();

            //verify contents of group row(s)
            rowCollection = group2.Rows();
            foreach (DataGridRowExtended row in rowCollection)
            {
                //row.Select(); //doesn't work

                //set current SLA name to be used by SLO grid via observer pattern
                this.slaName = group2.NameExtended;

                DataGridCellCollectionExtended cellCollection = row.CellsExtended;
                string cellName;
                foreach (DataGridCellExtended cell in cellCollection)
                {
                    //verify cell name
                    //(need values from query component to verify)
                    cellName = cell.NameExtended;
                    cell.Select();

                    if (cellName.Equals(UnmonitoredState[0]))
                        Utilities.LogMessage("Found SLA State: " + cellName);
                    else if (cellName.Equals(WKSTNN1[0]))
                        Utilities.LogMessage("Found SLA Instance Name: " + cellName);
                    else
                        Utilities.LogMessage("Found Unrecognized SLA value: " + cellName);

                    //need to add verification against resources file input (instance name) and query component results (state)
                }

                //move to SLO grid using observer pattern
                this.notify();
            }

            //verify group can be collapsed and expanded
            Utilities.LogMessage("Selecting group: " + Groups[1]);
            group2.Select();
            Utilities.LogMessage("Collapsing group: " + Groups[1]);
            group2.Collapse();
            Utilities.LogMessage("Expanding group: " + Groups[1]);
            group2.Expand();
             */
        }
        #endregion

        #region additional methods
        private void verifyTitle()
        {
            //verify titles match
            string actTitleText = this.Title.Text;
            Utilities.LogMessage("Verifying SLAView, Title Text: " + actTitleText);
            if (String.Compare(ExpectedSLATitle[0], actTitleText) == 0)
                Utilities.LogMessage("Titles match");
            else
                Utilities.LogMessage("Titles do NOT match, expected title: " + ExpectedSLATitle[0] +
                    ", actual title: " + actTitleText);
        }

        private Dictionary<string, object> prepareParametersList(int numDays, bool forQC)
        {
            //71ab9a60-64b4-2067-5e6e-995bcdac75a4,8bbd06fa-b9f9-18b5-4e0d-f58b9111163a
            List<Guid> slas = GetServiceLevelAgreements(Convert.ToDouble(numDays));
            this.timeInterval = LocalConstants.timeIntervalFirstPart + "-" + numDays.ToString() + LocalConstants.timeIntervalSecondPart;
            string aggregationType = "Hourly";
            const string TIMEINTERVAL = "TimeInterval";
            const string AGGREGATIONTYPE = "AggregationType";
            string serviceLevelName;
            if(forQC)
                serviceLevelName = "ServiceLevel";
            else
                serviceLevelName = "ServiceLevelId";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(serviceLevelName, slas);
            parameters.Add(TIMEINTERVAL, this.timeInterval);
            parameters.Add(AGGREGATIONTYPE, aggregationType);

            return parameters;
        }
        internal static List<Guid> GetServiceLevelAgreements(double numDaysBack)
        {
            Mom.Test.UI.Core.Common.Topology.Initialize();
            DBUtil.ConnectToMOMDW(Mom.Test.UI.Core.Common.Topology.RootMomSdkServerName);

            System.Data.DataView slaQueryResults = null;
            string slaQuery = "select ServiceLevelAgreementGuid from vServiceLevelAgreement";
            slaQueryResults = DBUtil.ExecuteQueryWithResults(slaQuery);

            List<Guid> rtnGuids = new List<Guid>();

            if (slaQueryResults != null && slaQueryResults.Count > 0)
            {
                for (int i = 0; i < slaQueryResults.Count; i++)
                {
                    Guid tempSLAGuid = new Guid((slaQueryResults[i].Row[0]).ToString());
                    Utilities.LogMessage("SLAGuid: " + tempSLAGuid.ToString());
                    rtnGuids.Add(tempSLAGuid);
                }
            }

            return rtnGuids;
        }

        /// <summary>
        /// populate List<string> of titles expected in SLA IDataObject collection
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> GetIDOTitles()
        {
            //passing IDO Collection for use in future of getting titles via reflection

            string currentMethodName = string.Empty;

            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Utilities.LogMessage(currentMethodName + "_Started...");

                List<string> names = new List<string>();

                names.Add("ServiceLevelMEId");
                names.Add("ServiceLevelMEName");
                names.Add("ServiceLevelId");
                names.Add("ServiceLevelName");
                names.Add("ServiceLevelMEState");
                names.Add("ServiceLevelObjective");
                names.Add("ServiceLevelObjectiveId");
                names.Add("ServiceLevelObjectiveGuid");
                names.Add("ServiceLevelObjectiveName");
                names.Add("ServiceLevelObjectiveTargetId");
                names.Add("ServiceLevelObjectiveTargetName");
                names.Add("ServiceLevelObjectiveState");
                names.Add("ServiceLevelObjectiveMeCount");

                return names;
            }
            #region Catch/Finally
            catch (VarFail)
            {
                throw;
            }
            catch (VarAbort)
            {
                throw;
            }
            catch (Exception e)
            {
                Utilities.TakeScreenshot(currentMethodName + "_Exception");
                throw new VarAbort(currentMethodName + "_Exception", e);
            }
            finally
            {
                //Utilities.TakeScreenshot(currentMethodName);
            }
            #endregion
        }


        public void BuildupContainer()
        {
            string currentMethodName = string.Empty;

            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Utilities.LogMessage(currentMethodName + "_started");
                
                List<ModuleInfo> modules = new List<ModuleInfo>();

                modules.Add(new ModuleInfo("CoreModule", typeof(CoreModule).AssemblyQualifiedName));
                modules.Add(new ModuleInfo("SecurityModule", typeof(SecurityModule).AssemblyQualifiedName, "DataAccessModule", "CoreModule"));
                modules.Add(new ModuleInfo("DataAccessModule", typeof(DataAccessModule).AssemblyQualifiedName));
                modules.Add(new ModuleInfo("DataProviders", typeof(DataProvidersModule).AssemblyQualifiedName, "DataAccessModule", "SecurityModule"));
                modules.Add(new ModuleInfo("CompositionEngine", typeof(CompositionEngineModule).AssemblyQualifiedName));
                modules.Add(new ModuleInfo("Components", typeof(ComponentsModule).AssemblyQualifiedName, "DataAccessModule", "CompositionEngine"));

                Common.BootStrapper bootStrapper = new Common.BootStrapper(modules);
                bootStrapper.Run();

                //Giving a Unity.ResolutionFailedException here indicating DataContext is null and 
                //that IDataCommandContext is an interface and cannot be constructed when BuildUp(this) is called
                this.Container = ServiceLocator.Current.GetService(typeof(IUnityContainer)) as IUnityContainer;
                this.Container.BuildUp(this);

                // Get an instance of the desktop connection manager
                IConnectionSessionManager manager = this.Container.Resolve<IConnectionSessionManager>();

                // Cast the desktop connection manager as a Synchronous connection manager
                IConnectionSessionManagerSynchronous syncManager = manager as IConnectionSessionManagerSynchronous;

                //TODO: Get valid servername
                IConnectionSession session = syncManager.Connect(OMServiceUriBuilder.CreateServiceUri(Topology.RootMomSdkServerName),
                    (Microsoft.EnterpriseManagement.Presentation.Security.PropertyCollection)null);

                // Get the Ticket (to be used with your data commands as the ConnectionSessionTicket
                this.sessionTicket = session.Ticket;
            }
            #region Catch/Finally
            catch (Exception e)
            {
                Utilities.TakeScreenshot(currentMethodName + "_Exception");
                throw new VarAbort(currentMethodName + "_Failed to get StatusBar StatusMessage", e);
            }
            finally
            {
            }
            #endregion
        }
        #endregion
    }

    public class SLOView : Mom.Test.UI.Core.Console.MomControls.DashboardControls.DataGridViewHost
    {
        private IServiceLevelDashboardQuery query;
        string slaName;
        string timeInterval;
        int TIME_OUT = 5000;
        private string expectedSLOTitle;
        IDataGateway gateway;
        protected ManagementGroup mg = null;

        public string sessionTicket
        {
            get;
            set;
        }

        #region Resources
        [ResourceLoader.Resource(ID = "ExpectedSLOTitle")]
        private List<string> ExpectedSLOTitle;

        [ResourceLoader.Resource(ID = "State")]
        private List<string> State;

        [ResourceLoader.Resource(ID = "Name")]
        private List<string> Name;

        [ResourceLoader.Resource(ID = "TargetClass")]
        private List<string> TargetClass;

        [ResourceLoader.Resource(ID = "NumInstances")]
        private List<string> NumInstances;

        [ResourceLoader.Resource(ID = "HealthyState")]
        private List<string> HealthyState;

        [ResourceLoader.Resource(ID = "WarningState")]
        private List<string> WarningState;

        [ResourceLoader.Resource(ID = "CriticalState")]
        private List<string> CriticalState;

        [ResourceLoader.Resource(ID = "UnmonitoredState")]
        private List<string> UnmonitoredState;

        [ResourceLoader.Resource(ID = "SLO1")]
        private List<string> SLO1;

        [ResourceLoader.Resource(ID = "SLO2")]
        private List<string> SLO2;

        [ResourceLoader.Resource(ID = "Target1")]
        private List<string> Target1;

        [ResourceLoader.Resource(ID = "Target2")]
        private List<string> Target2;

        [ResourceLoader.Resource(ID = "Zero")]
        private List<string> Zero;

        [ResourceLoader.Resource(ID = "One")]
        private List<string> One;

        [ResourceLoader.Resource(ID = "Two")]
        private List<string> Two;

        [ResourceLoader.Resource(ID = "Three")]
        private List<string> Three;

        [ResourceLoader.Resource(ID = "Four")]
        private List<string> Four;

        [ResourceLoader.Resource(ID = "Groups")]
        private List<string> Groups;
        #endregion

        public static List<string> titles = SLOView.GetIdoTitles();

        #region Constructor
        public SLOView(Window knownWindow, IServiceLevelDashboardQuery query, XElement resource)
            : base(knownWindow)
        {
            MachineInfo momServer = (MachineInfo)Topology.MomServersInfo[0];
            mg= Utilities.ConnectToManagementServer(momServer.DNSMachineName);

            ResourceLoader.ResourceLoader.LoadResources(this, resource);
            this.query = query;

            SLAView.attach(this);
        }
        #endregion

        #region Verify
        public void Verify(string mpName, string title, string[] resourceIds)
        {
            this.WaitForReady();

            //get grid title and column names from call to GetStringResource()
            VerifyTitle(mpName, title);

            //NOTE: this section is currently being refactored

            // Get the display name from the MP
            //string[] convertedResourceIds = null;
            //var managementPack = mg.ManagementPacks.GetManagementPacks().Where(mp => mp.Name.Equals(mpName)).FirstOrDefault();

            //for (int i = 0; i < resourceIds.Count(); i++)
            //{
            //    convertedResourceIds[i] = managementPack.GetStringResource(resourceIds[i]).DisplayName;
            //}

            List<string> columnNames = new List<string>();
            List<List<string>> expectedGridContents = new List<List<string>>();

            //temp workaround
            columnNames.Add("State");
            columnNames.Add("Name");
            columnNames.Add("Target Class");
            columnNames.Add("Instances");

            List<string> firstRowGridContents = new List<string>();
            List<string> secondRowGridContents = new List<string>();

            firstRowGridContents.Add("3");
            firstRowGridContents.Add("Health Service Availability SLO");
            firstRowGridContents.Add("Windows Computer");
            firstRowGridContents.Add("1");

            secondRowGridContents.Add("3");
            secondRowGridContents.Add("Health Service Workflow SLO");
            secondRowGridContents.Add("Health Service");
            secondRowGridContents.Add("0");

            expectedGridContents.Add(firstRowGridContents);
            expectedGridContents.Add(secondRowGridContents);

            verifyGridContents(columnNames, expectedGridContents);

            #region delete following
            //get expected grid contents from varmap

            //var parameters = prepareParametersList();
            //List<string> titles = GetIdoTitles();

            //ICollection<IDataObject> dpResults = callDataProviderReader(parameters);
            //SortedDictionary<string, KeyValuePair<Type, object>> idoDPValues = Utilities.UnwindIDataObjectCollection(dpResults, titles);
            //OutputDataObjectContents(idoDPValues);

            //KeyValuePair<string, IEnumerable<IDataObject>> qcResults = callQueryComponentReader(parameters);
            //SortedDictionary<string, KeyValuePair<Type, object>> idoQCValues = Utilities.UnwindIDataObjectCollection(qcResults.Value, titles);
            //Utilities.OutputDataObjectContents(idoQCValues);

            //DataTable sloQueryData = Mom.Test.UI.Core.ConvertToDataTable.GenerateTable(qcResults.Value, LocalConstants.sloQueryTable);
            //DataTable sloGridData = callGridReader();

            //Mom.Test.UI.Core.Comparer compareObj = new Mom.Test.UI.Core.Comparer();
            //compareObj.LogTable(LocalConstants.sloQueryTable, 0);
            //compareObj.LogTable(LocalConstants.sloGridTable, 0);

            //compareObj.Filter(LocalConstants.sloQueryTable, "filterCriteria", null, "filteredSloQueryTable");
            //compareObj.Filter(LocalConstants.sloGridTable, "filterCriteria", null, "filteredSloGridTable");
            //compareObj.Compare("filteredSloQueryTable", "filteredSloGridTable");
            #endregion
        }

        #endregion

        #region observer methods
        public void Update(SLAView sla)
        {
            //get information from SLAView object to use in verifying SLOs
            //TODO: either rename getState or wrap all info in single call
            this.slaName = sla.getSLName();
            this.timeInterval = sla.getTimeInterval();
            
            string mpName = null;
            string title = null;
            string[] resourceIds = null;

            //short term fix/workaround
            mpName = "Microsoft.SystemCenter.Visualization.ServiceLevelComponents";
            title = "Service Level Objectives";
            this.Verify(mpName, title, resourceIds);
        }
        #endregion

        #region call Readers

        private ICollection<IDataObject> callDataProviderReader(Dictionary<string, object> parameters)
        {
            ICollection<Microsoft.EnterpriseManagement.Presentation.DataAccess.IDataObject> dataProviderDataObjectCollection =
                (ICollection<Microsoft.EnterpriseManagement.Presentation.DataAccess.IDataObject>)
                Mom.Test.UI.Core.DataProviderReader.Read(this.gateway, this.sessionTicket, Constants.ServiceLevelObjectiveDataProvider, parameters);
            return dataProviderDataObjectCollection;
        }

        private KeyValuePair<string, IEnumerable<IDataObject>> callQueryComponentReader(Dictionary<string, object> parameters)
        {
            //ServiceLevelObjectiveQuery SLOQ = new ServiceLevelObjectiveQuery();
            //KeyValuePair<string, IEnumerable<IDataObject>> sloObjects = Mom.Test.UI.Core.QueryComponentReader.Read(SLOQ, parameters);
            KeyValuePair<string, IEnumerable<IDataObject>> sloObjects = new KeyValuePair<string, IEnumerable<IDataObject>>();
            return sloObjects;
        }

        private DataTable callGridReader()
        {
            Dictionary<string, string> columnTypes = new Dictionary<string, string>();
            DataTable sloGridTable = GridReader.Read(this.DataGrid, LocalConstants.sloGridTable, columnTypes);

            return sloGridTable;
        }

        private void verifyGridContents(List<string> columnNames, List<List<string>> expectedGridContents )
        {
            Utilities.LogMessage("NOTE: multiple \'column header Name\' entries logged by DataGrid constructor");
            var grid = this.DataGrid;

            //verify SLO grid is NOT grouped
            if (grid.HasGroups)
            {
                throw new VarAbort("SLAView grid expected to be grouped, reported as not so...");
            }

            List<string> columnHeaders = DataGridControlExtensions.GetColumHeaders(grid);

            for (int i = 0; i < columnHeaders.Count; i++)
            {
                if(columnNames[i] != columnHeaders[i])
                    throw new VarFail("Column Names do not match - actual: " + columnHeaders[i] + "; expected: " + columnNames[i]);
            }
            
            //need values for:
            //              State
            //(SLO) Name
            //              Target Class
            //         #  Instances

            List<List<string>> gridRowData = DataGridControlExtensions.GetRowData(grid);

            Utilities.LogMessage("Number of SLOs for given SLA: " + gridRowData.Count);
            
            //go through each row in expected grid contents, by column, and verify vs actual grid contents


            //State: Healthy, Critical
            //Name: (SLO Name)
            //Target Class: 
            //#Instances: 

            //verify contents of datagrid match values returned by query component
            foreach (List<string> lStr in gridRowData)
            {
                foreach (string s in lStr)
                {                    
                    //Example of cell contents:
                    //"3", "Health Service Availability SLO", "Windows Computer", "1"
                    //"1", "Health Service Workflow SLO", "Health Service", "0"

                    //ToDo: need to be able to enumerate over Groups (type DataGroupGroups)
                    if ((this.slaName).Contains(Groups[0]))
                    {
                        //SlaMonitor case
                        if (s.Equals(HealthyState[0]))
                            Utilities.LogMessage("Found SLO State: " + s);
                        else if (s.Equals(CriticalState[0]))
                            Utilities.LogMessage("Found SLO State: " + s);
                        else if (s.Equals(SLO1[0]))
                            Utilities.LogMessage("Found SLO Instance Name: " + s);
                        else if (s.Equals(SLO2[0]))
                            Utilities.LogMessage("Found SLO Instance Name: " + s);
                        else if (s.Equals(Target1[0]))
                            Utilities.LogMessage("Found SLO Target class: " + s);
                        else if (s.Equals(Target2[0]))
                            Utilities.LogMessage("Found SLO Target class: " + s);
                        else if (s.Equals(Zero[0]))
                            Utilities.LogMessage("Found # SLO Instances: " + s);
                        else if (s.Equals(One[0]))
                            Utilities.LogMessage("Found # SLO Instances: " + s);
                        else if (s.Equals(Two[0]))
                            Utilities.LogMessage("Found # SLO Instances: " + s);
                        else
                            Utilities.LogMessage("Found Unrecognized SLO value: " + s);
                    }
                    else
                    {
                        //invalid case
                        //for now Log as incorrect to debug
                        Utilities.LogMessage("Invalid case: " + s);
                        //eventually throw instead
                        //throw new Exception("Invalid case: " + s);
                    }

                    //need to add verification against resources file input (SLO Name & Target class) and query component results (State & #Instances)
                }
            }
        }
        #endregion

        #region additional methods
        private void VerifyTitle(string mpName, string title)
        {
            var managementPack = mg.ManagementPacks.GetManagementPacks().Where(mp => mp.Name.Equals(mpName)).FirstOrDefault();
            
            if (managementPack != null)
            {
                string expectedTitle = null;
                //expectedTitle = managementPack.GetStringResource(title).DisplayName;
                //temporary workaround
                expectedTitle = "Service Level Objectives";

                //verify titles match
                string actTitleText = this.Title.Text;
                Utilities.LogMessage("Verifying SLOView, Title Text: " + actTitleText);
                if (String.Compare(expectedTitle, actTitleText) == 0)
                    Utilities.LogMessage("Titles match");
                else
                    Utilities.LogMessage("Titles do NOT match, expected title: " + expectedTitle +
                                         ", actual title: " + actTitleText);
            }
            else
            {
                throw new VarAbort("Failed to get management pack: " + mpName);
            }
        }

/*
        private Dictionary<string, object> PrepareParametersList()
        {
            List<Guid> slaList = new List<Guid>();

            int slaMEId = 1636; //meaningless default (just so can build)
            Guid sloGuid = new Guid("f5831083-2649-74ec-066b-6cc83a8a8f0a");

            //TODO: Add looping on all SLA ME Ids and SLO Guids

            //For reference:
            //slas -
            //71ab9a60-64b4-2067-5e6e-995bcdac75a4
            //8bbd06fa-b9f9-18b5-4e0d-f58b9111163a
            //slos -
            //F5831083-2649-74EC-066B-6CC83A8A8F0A
            //C76FF7C6-8539-5CC0-6F8F-C6F3BC1F6492
            //3FAC3727-F0FA-C8B6-F582-B6DAD0F57A45
            //E48AB955-9CBD-63A3-7A32-C61F65529426
            //6CF7787D-FD77-0952-5639-630AC7CDFF2D
            //7CA83BEF-B04E-0E8B-D9FD-C2C57FE38B01
            //4B8E4E6F-B521-A6F9-9374-3CD3ECF31D8D
            //1610132D-EB67-0B9E-6113-890F85EF7747
            //BFF6C80A-9E24-34EA-E1E5-700ADBFF5536

            string aggregationType = "Hourly";
            const string AGGREGATIONTYPE = "AggregationType";
            const string TIMEINTERVAL = "TimeInterval";
            const string SERVICELEVELOBJECTIVEGUID = "ServiceLevelObjectiveGuid";
            const string SERVICELEVELAGREEMENTMANAGEDENTITYID = "ServiceLevelAgreementManagedEntityId";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(TIMEINTERVAL, this.timeInterval);
            parameters.Add(AGGREGATIONTYPE, aggregationType);

            //use SLAView.slaDataTable to parse through slaMEs -> slaMEId

            parameters.Add(SERVICELEVELAGREEMENTMANAGEDENTITYID, slaMEId);

            //for each slaMEId, parse SLOs -> sloGuid

            parameters.Add(SERVICELEVELOBJECTIVEGUID, sloGuid.ToString());

            return parameters;
        }
*/

/*
        private List<Guid> GetServiceLevelObjectives(double numDaysBack)
        {
            Mom.Test.UI.Core.Common.Topology.Initialize();
            DBUtil.ConnectToMOMDW(Mom.Test.UI.Core.Common.Topology.RootMomSdkServerName);

            System.Data.DataView slaQueryResults = null;
            string slaQuery = "select ServiceLevelAgreementGuid from vServiceLevelAgreement";
            slaQueryResults = DBUtil.ExecuteQueryWithResults(slaQuery);

            List<Guid> rtnGuids = new List<Guid>();

            if (slaQueryResults != null && slaQueryResults.Count > 0)
            {
                for (int i = 0; i < slaQueryResults.Count; i++)
                {
                    Guid tempSLAGuid = new Guid((slaQueryResults[i].Row[0]).ToString());
                    Utilities.LogMessage("SLAGuid: " + tempSLAGuid.ToString());
                    rtnGuids.Add(tempSLAGuid);
                }
            }

            return rtnGuids;
        }
*/

        /// <summary>
        /// populate List<string> of titles expected in SLA IDataObject collection
        /// </summary>
        /// <returns>List<string></returns>
        public static List<string> GetIdoTitles()
        {
            string currentMethodName = string.Empty;

            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Utilities.LogMessage(currentMethodName + "_Started...");

                List<string> names = new List<string>();

                names.Add("ServiceLevelMEId");
                names.Add("ServiceLevelMEName");
                names.Add("ServiceLevelId");
                names.Add("ServiceLevelName");
                names.Add("ServiceLevelMEState");
                names.Add("ServiceLevelObjective");
                names.Add("ServiceLevelObjectiveId");
                names.Add("ServiceLevelObjectiveGuid");
                names.Add("ServiceLevelObjectiveName");
                names.Add("ServiceLevelObjectiveTargetId");
                names.Add("ServiceLevelObjectiveTargetName");
                names.Add("ServiceLevelObjectiveState");
                names.Add("ServiceLevelObjectiveMeCount");

                return names;
            }
            #region Catch/Finally
            catch (VarFail)
            {
                throw;
            }
            catch (VarAbort)
            {
                throw;
            }
            catch (Exception e)
            {
                Utilities.TakeScreenshot(currentMethodName + "_Exception");
                throw new VarAbort(currentMethodName + "_Exception", e);
            }
            finally
            {
                //Utilities.TakeScreenshot(currentMethodName);
            }
            #endregion
        }
        #endregion
    }

    #region Constants
    internal class LocalConstants
    {
        internal const string slaDPTable = "slaDPTable";
        internal const string slaQueryTable = "slaQueryTable";
        internal const string slaGridTable = "slaGridTable";
        internal const string sloDPTable = "sloDPTable";
        internal const string sloQueryTable = "sloQueryTable";
        internal const string sloGridTable = "sloGridTable";
        internal const string SERVICELEVELTRACKING = "Service Level Tracking";
        internal const string SERVICELEVELDB_FIRST = "Service Level Dashboard (Last ";
        internal const string SERVICELEVELDB_SECOND = " Days)";

        internal const string timeIntervalFirstPart =
            "<Interval>" +
            " <Title>TemporaryTitle</Title>" +
            " <Start>" +
            " <Base>Present</Base>" +
            " <Offset Type='Day'>";

        internal const string timeIntervalSecondPart =
            "</Offset>" +
            " </Start>" +
            " <End>" +
            " <Base>Present</Base>" +
            " <Offset Type='None'>0</Offset>" +
            " </End>" +
            "</Interval>";
    }
    #endregion
}
