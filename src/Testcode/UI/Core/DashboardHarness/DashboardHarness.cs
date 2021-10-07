//-------------------------------------------------------------------
// <copyright file="DashboardHarness.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains DashboardHarness Methods
// </summary>
// 
//  <history>
//  [joelj]     10JAN10:  Added FireManagementPackChangedEvent method
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core
{
    using System;
    using System.Data;
    using Infra.Frmwrk;
    using System.Collections.Generic;
    using System.Threading;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.ServiceLocation;
    //using Microsoft.Practices.Prism.Events;
    using Microsoft.EnterpriseManagement.Presentation.Security;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using System.IO;
    using System.Windows;
    using Microsoft.EnterpriseManagement.Test.ScCommon;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon.Topology;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;

    using System.Xml;
    using System.Text;
    using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling;
    using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling.ErrorHandlers;
    using Microsoft.EnterpriseManagement.Presentation.ErrorHandling;
    using Microsoft.EnterpriseManagement.Presentation.Notification;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess.Cache;
    using Microsoft.EnterpriseManagement.CompositionEngine;
    using System.Configuration;

    public class DashboardHarness : ISetup, ICleanup
    {
        const string recDataProviderName = "DataProviderName";
        const string recQueryComponentName = "QueryComponentName";
        const string recTableName = "TableName";

        private Comparer comparer;

        private string managementServer;

        /// <summary>
        /// Setup should be called once from MCF
        /// </summary>
        /// <param name="ctx"></param>
        public void Setup(IContext ctx)
        {
            Initializer.Initialize(ctx);

            // Get Management Server name only once
            managementServer = Utilities.GetManagementServerName();

            Utilities.LogMessage("Connecting to Ops DB: " + managementServer, true);
            try
            {
                DBUtil.ConnectToMOMDB(managementServer);
            }
            catch (Exception e) // This is not a fatal error since not all tests need to connect and some may connect themselves
            {
                Utilities.LogMessage("Failed to connect to Ops DB due to: " + e.InnerException, true);
            }
            Utilities.LogMessage("Connecting to Data Warehouse: " + managementServer, true);
            try
            {
                DBUtil.ConnectToMOMDW(managementServer);
            }
            catch (Exception e) // This is not a fatal error since not all tests need to connect and some may connect themselves
            {
                Utilities.LogMessage("Failed to connect to Data Warehouse due to: " + e.InnerException, true);
            }
            Context = ctx;
            comparer = new Comparer();
            comparer.Setup();
            SetupInfrastructure();
        }

        private IContext ctx = null;
        public IContext Context
        {
            get
            {
                return ctx;
            }
            set
            {
                Mom.Test.UI.Core.Common.Mcf.FrameworkContext = value;
                ctx = value;
            }
        }

        public void Cleanup(IContext ctx)
        {
            comparer.Cleanup();
        }

        /// <summary>
        /// Fires a ManagementPackChangedEvent on the current Unity Container
        /// </summary>
        /// <remarks>
        /// Used to signal to the ManagmentGroup that an MP has been imported/changed/deleted so any updated assemblies
        /// can be downloaded (eg. a new test DataProvider)
        /// </remarks>
        public void FireManagementPackChangedEvent()
        {
            // Get an instance of the desktop connection manager
            IConnectionSessionManager manager = SDKConnectionManager.Current.GetUnityContainer().Resolve<IConnectionSessionManager>();

            IConnectionSessionManagerSynchronous syncManager = manager as IConnectionSessionManagerSynchronous;

            IConnectionSession session;
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["UserName"]))
            {
                session = syncManager.Connect(OMServiceUriBuilder.CreateServiceUri(managementServer),
                                          ConfigurationManager.AppSettings["UserName"],
                                          ConfigurationManager.AppSettings["Password"], null);
            }
            else
            {
                session = syncManager.Connect(OMServiceUriBuilder.CreateServiceUri(managementServer),
                                          (Microsoft.EnterpriseManagement.Presentation.Security.PropertyCollection)null);
            }

            SDKConnectionManager.Current.GetUnityContainer().RegisterInstance(typeof(IConnectionContext), new ConnectionContext { Session = session },
                                            new ContainerControlledLifetimeManager());

            // Raise the ManagementPack Changed Event on the DataCache itself
            SDKConnectionManager.Current.GetUnityContainer().Resolve<IDataCache>().RaiseManagementPackChangedEvent().Block();
            
        }

        #region Readers
        /// <summary>
        /// Reads values from a Query Component.  The query name, table name, and parameters are passed in function recs. 
        /// e.g.
        /// &lt;fnc ret="queryReturn" name="ReadQueryComponent"&gt;
        ///   &lt;rec key="QueryComponentName"&gt;Microsoft.EnterpriseManagement.Monitoring.Components.ServiceLevelQuery, Microsoft.EnterpriseManagement.Monitoring.Components, Version=7.0.5000.0, Culture=neutral, PublicKeyToken=9396306c2be7fcc4&lt;/rec&gt;
        ///   &lt;rec key="TableName"&gt;query1&lt;/rec&gt;
        ///   &lt;rec key="Parameter"&gt;name=ServiceLevel;type=System.Guid;value=%Guids%;collectiontype=System.Collections.Generic.List`1&lt;/rec&gt;
        ///   &lt;rec key="Parameter"&gt;name=TimeInterval;type=System.String;value=%TimeOffset%&lt;/rec&gt;
        ///   &lt;rec key="Parameter"&gt;name=AggregationType;value=Hourly;type=System.String&lt;/rec&gt;
        /// &lt;/fnc&gt;
        /// </summary>
        /// <param name="fncContext"></param>
        /// <returns></returns>
        public IEnumerable<IDataObject> ReadQueryComponent(IContext fncContext)
        {
            try
            {
                string queryComponentName = fncContext.FncRecords.GetValue(recQueryComponentName);
                string tableName = fncContext.FncRecords.GetValue(recTableName);
                Dictionary<string, object> parameters = McfUtil.ReadParameters(fncContext);

                //It might make sense to move these into QueryComponentReader.Read() if they are always needed
                parameters.Add("ConnectionSessionTicket", SDKConnectionManager.Current.GetConnectionSessionTicket());
                parameters.Add("Gateway", SDKConnectionManager.Current.GetDataGateway());

                IDisplayErrorHandler displayErrorHandler = new DisplayErrorHandler(new ErrorViewService());
                parameters.Add("ErrorService", new DisplayErrorService(new ErrorHandlerCollection(), displayErrorHandler)); // Should this be optional?

                KeyValuePair<string, IEnumerable<IDataObject>> result = QueryComponentReader.Read(queryComponentName, parameters);
                if (result.Value == null)
                {
                    throw new VarFail("Query returned a null result");
                }
                DataTable table = ConvertToDataTable.GenerateTable(result.Value, tableName);
                comparer.AddTable(table);
                if (result.Key == "LastError")
                {
                    comparer.LogTable(tableName, 0);
                    throw new VarFail("Query returned an error message");
                }
                return result.Value;
            }
            catch (VarFail)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new VarAbort("QueryComponentReader failed", e);
            }
        }


        // Calls a Data Provider with parameters passed in from the Varmap, flattens the resulting 
        // IDataObject tree to a DataTable, and stores it for later verification
        public IEnumerable<IDataObject> ReadDataProvider(IContext fncContext)
        {
            try
            {
                string dataProviderName = fncContext.FncRecords.GetValue(recDataProviderName);
                string tableName = fncContext.FncRecords.GetValue(recTableName);
                Dictionary<string, object> parameters = McfUtil.ReadParameters(fncContext);
                IEnumerable<IDataObject> result = DataProviderReader.Read(SDKConnectionManager.Current.GetDataGateway(), SDKConnectionManager.Current.GetConnectionSessionTicket(), dataProviderName, parameters);
                DataTable table = ConvertToDataTable.GenerateTable(result, tableName);
                comparer.AddTable(table);
                return result;
            }
            catch (Exception e)
            {
                throw new VarAbort("DataProviderReader failed", e);
            }
        }

        public void ReadVarmap(IContext ctx)
        {
            //get the table name or make it
            string tableName = "Table" + comparer.NumberOfTables.ToString().Trim();
            if (ctx.FncRecords.FindKey(recTableName))
            {
                tableName = ctx.FncRecords.GetValue(recTableName);
            }
            DataTable dtResult = VarmapReader.Read(this, ctx, tableName);
            comparer.AddTable(dtResult);
        }

        public DataTable ReadSQL(string sourceDB, string query, string resultTableName)
        {
            DataTable dtResult = SQLReader.Read(this, sourceDB, query, resultTableName);
            comparer.AddTable(dtResult);
            return dtResult;
        }

        public string ReadSQLValue(string sourceDB, string query, string resultColumn)
        {
            return SQLReader.ReadFirstValue(this, sourceDB, query, resultColumn);
        }

        #endregion

        #region TableComparison
        /// <summary>
        /// Wrapper function.  See Comparer
        /// </summary>
        public void Compare(string table1, string table2, string xmlCompareData)
        {
            comparer.Compare(table1, table2, xmlCompareData);
        }

        /// <summary>
        /// Wrapper function.  See Comparer
        /// </summary>
        public void Filter(string table, string filterCriteria, string sortOrder, string newName)
        {
            comparer.Filter(table, filterCriteria, sortOrder, newName);
        }

        /// <summary>
        /// Wrapper function.  See Comparer
        /// </summary>
        public void Join(string table1, string column1, string table2, string column2, string newName, bool same)
        {
            comparer.Join(table1, column1, table2, column2, newName, same);
        }

        /// <summary>
        /// Wrapper function.  See Comparer
        /// </summary>
        public void LogTable(string tableName, int numberOfRows)
        {
            comparer.LogTable(tableName, numberOfRows);
        }
        #endregion

        #region BackupRestore
        /// <summary>
        /// Backup the Ops DB
        /// </summary>
        public void BackupMOMDB(string backupName)
        {
            try
            {
                DBUtil.BackupMOMDB(Path.Combine(Directory.GetCurrentDirectory(), backupName), backupName, "BackupMOMDB");
            }
            catch (Exception e)
            {
                if (Context is IGroupContext)
                {
                    throw new GroupAbort(String.Format("Backup of DB Failed"), e);
                }
                else
                {
                    throw new VarAbort(String.Format("Backup of DB Failed"), e);
                }
            }
        }

        /// <summary>
        /// Backup the Data Warehouse
        /// </summary>
        public void BackupMOMDW(string backupName)
        {
            try
            {
                DBUtil.BackupMOMDW(Path.Combine(Directory.GetCurrentDirectory(), backupName), backupName);
            }
            catch (Exception e)
            {
                if (Context is IGroupContext)
                {
                    throw new GroupAbort(String.Format("Backup of DB Failed"), e);
                }
                else
                {
                    throw new VarAbort(String.Format("Backup of DB Failed"), e);
                }
            }
        }

        /// <summary>
        /// Restore the Ops DB to previous state
        /// </summary>
        public void RestoreMOMDB(string backupName)
        {
            try
            {
                DBUtil.RestoreMOMDB(backupName, "BackupDB");
            }
            catch (Exception e)
            {
                // should we always throw a group abort here?
                if (Context is IGroupContext)
                {
                    throw new GroupAbort("Restore of DB Failed", e);
                }
                else
                {
                    throw new VarAbort("Restore of DB Failed", e);
                }
            }
        }

        /// <summary>
        /// Restore the Data Warehouse to previous state
        /// </summary>
        public void RestoreMOMDW(string backupName)
        {
            try
            {
                DBUtil.RestoreMOMDW(backupName);
            }
            catch (Exception e)
            {
                // should we always throw a group abort here?
                if (Context is IGroupContext)
                {
                    throw new GroupAbort("Restore of DW Failed", e);
                }
                else
                {
                    throw new VarAbort("Restore of DW Failed", e);
                }
            }
        }

        /// <summary>
        /// Restores the Ops DB to saved state (or saves it if there is not saved version)
        /// </summary>
        public void CreateOrRestoreDBCheckpoint(string backupName)
        {
            string backupExistsQuery = String.Format("select physical_name from sys.backup_devices where name = '{0}'", backupName);
            Utilities.LogMessage(backupExistsQuery);
            DBUtil.CurrentConnection = DBUtil.DBConnection.MOMDB;
            object backupPhysicalName = DBUtil.ExecuteScalarQuery(backupExistsQuery);
            if (backupPhysicalName != null)
            {
                Utilities.LogMessage("Restoring DB Checkpoint from "+ backupPhysicalName.ToString());
                RestoreMOMDB(backupName);
                Utilities.LogMessage("DB Checkpoint restored", true);
            }
            else
            {
                Utilities.LogMessage("Creating DB checkpoint", true);
                BackupMOMDB(backupName);
                Utilities.LogMessage("DB Checkpoint created", true);
            }
        }

        /// <summary>
        /// Restores the Data Warehouse to saved state (or saves it if there is not saved version)
        /// </summary>
        public void CreateOrRestoreDWCheckpoint(string backupName)
        {
            string backupExistsQuery = String.Format("select physical_name from sys.backup_devices where name = '{0}'", backupName);
            Utilities.LogMessage(backupExistsQuery);
            DBUtil.CurrentConnection = DBUtil.DBConnection.MOMDW;
            object backupPhysicalName = DBUtil.ExecuteScalarQuery(backupExistsQuery);
            if (backupPhysicalName != null)
            {
                Utilities.LogMessage("Restoring DW Checkpoint from " + backupPhysicalName.ToString());
                RestoreMOMDW(backupName);
                Utilities.LogMessage("DW Checkpoint restored", true);
            }
            else
            {
                Utilities.LogMessage("Creating DW checkpoint", true);
                BackupMOMDW(backupName);
                Utilities.LogMessage("DW Checkpoint created", true);
            }
        }


        #endregion

        /// <summary>
        /// Initialize the SDKConnectionManager
        /// </summary>
        public void SetupInfrastructure()
        {
            SDKConnectionManager.Init(managementServer);
        }
    }
}

