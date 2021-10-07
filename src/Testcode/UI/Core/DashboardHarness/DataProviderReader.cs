namespace Mom.Test.UI.Core
{
    using System;
    using System.Data;
    using Infra.Frmwrk;
    using System.Collections.Generic;
    using MomCommon = Mom.Test.UI.Core.Common;
    using System.Threading;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.EnterpriseManagement.Presentation.Security;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using System.IO;
    using System.Windows;

    using System.Xml;
    using System.Text;

    public class DataProviderReader
    {
        // Calls a Data Provider with parameters stored in a dictionary
        public static IEnumerable<IDataObject> Read(IDataGateway gateway, string sessionTicket, string dataProviderName, Dictionary<string, object> parameters/*, string tableName*/)
        {
            IEnumerable<IDataObject> returnValue = null;

            AsyncDataCommand<IDataObject> dataProviderCommand = new AsyncDataCommand<IDataObject>(dataProviderName
                    , sessionTicket
                    , new ObservableDataModel());

            foreach(KeyValuePair<string, object> kvp in parameters)
            {
                dataProviderCommand.Parameters.Add(kvp.Key, kvp.Value);
            }
            
            ManualResetEvent dataProviderComplete = new ManualResetEvent(false);
            Exception asyncException = null;

            // set EventHandler for Async DataCommand
            dataProviderCommand.CommandCompleted += delegate(object sender, AsyncDataCommandCompletedEventArgs<IEnumerable<IDataObject>> e)
            {
                // The Error object always contains any exception if one was thrown by the engine or the data provider.
                if (e.Error != null)
                {
                    MomCommon.Utilities.LogMessage("Data Provider returned error: " + e.Error.Message, true);
                    asyncException = e.Error;
                }
                else
                {
                    returnValue = e.Result;
                }
                dataProviderComplete.Set();
            };

            // Execute the command Async
            gateway.ExecuteAsync(dataProviderCommand);

            // wait for response 
            const int timeOutInMs = 5*60*1000;
            bool success = dataProviderComplete.WaitOne(timeOutInMs, false);
            if(!success)
                throw new VarAbort("Timed out waiting for data provider after " + timeOutInMs /1000 + " seconds");

            if (asyncException != null)
                throw new VarAbort("Async execution of data provider: " + dataProviderName + " failed", asyncException);
            return returnValue;
        }
    }
}

