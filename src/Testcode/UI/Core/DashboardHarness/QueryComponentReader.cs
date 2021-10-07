namespace Mom.Test.UI.Core
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Threading;

    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using Microsoft.EnterpriseManagement.CompositionEngine;

    using MomCommon = Mom.Test.UI.Core.Common;
    using Infra.Frmwrk;
    
    public class QueryComponentReader
    {
        // Calls a Query Component with parameters stored in a dictionary
        public static KeyValuePair<string, IEnumerable<IDataObject>> Read(string queryComponentAssemblyQualifiedName, Dictionary<string, object> parameters)
        {
             Type queryType = Type.GetType(queryComponentAssemblyQualifiedName);
             if (queryType == null)
                 throw new ArgumentException("Unknown query type: " + queryType);
        
             if(queryType.GetInterface("INotifyInitialized") == null)
                 throw new InvalidCastException("Query '" + queryType.ToString() + "' does not support INotifyInitialized");
                 
             // create query using default constructor
             INotifyInitialized query = Activator.CreateInstance(queryType, null) as INotifyInitialized;
             if (query == null)
                 throw new ArgumentException("Unable to create instance of query: " + queryType.ToString());
        
             // Ensure it supports the minimum interfaces we need
             if (!(query is INotifyPropertyChanged))
                 throw new InvalidCastException("Query '" + queryType.ToString() + "' does not support INotifyPropertyChanged");
             return Read(query, parameters);
         }

        // Calls a Query Component with parameters stored in a dictionary
        public static KeyValuePair<string, IEnumerable<IDataObject>> Read(INotifyInitialized query, Dictionary<string, object> parameters)
        {
            // Set the query parameters
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                PropertyInfo property = query.GetType().GetProperty(parameter.Key);
                if (property == null)
                    throw new ArgumentException(String.Format("Field '{0}' does not exist in query type '{1}'", parameter.Key, query.GetType()));
                try
                {
                    property.SetValue(query, parameter.Value, null);
                }
                catch (MethodAccessException e)
                {
                    throw new MethodAccessException("Attempt to set a non-public query property: " + parameter.Key, e);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(String.Format("Unable to convert query parameter '{0}' from '{1}' to '{2}'"
                        , parameter.Key, parameter.Value.GetType(), property.PropertyType), e);
                }
            }
            (query as INotifyPropertyChanged).PropertyChanged += On_PropertyChanged;
            QueryResult qr = new QueryResult();
            using (qr.queryComplete = new ManualResetEvent(false))
            {
                queryResults.Add(query, qr);

                // Create a thread to tell the query that initialization is complete so it can get the data
                Dispatcher threadDispatcher = null;
                
                Thread thread = new Thread(() =>
                {
                    FieldInfo fInfo = query.GetType().BaseType.GetField("dispatcher", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (fInfo != null)
                    {
                        MomCommon.Utilities.LogMessage("Setting dispatacher for query.");
                        threadDispatcher = Dispatcher.CurrentDispatcher;
                        SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(threadDispatcher));
                        fInfo.SetValue(query, threadDispatcher);
                    }
                    else
                    {
                        MomCommon.Utilities.LogMessage("No dispatacher found in query");

                    }
                    query.Notify();

                    Dispatcher.Run();                    
                });


                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                // wait for response 
                const int timeOutInMs = 1 * 10 * 1000;
                MomCommon.Utilities.LogMessage("waiting for signal");
                bool success = qr.queryComplete.WaitOne(timeOutInMs, false);
                if (threadDispatcher != null) 
                    threadDispatcher.InvokeShutdown();

                if (!success)
                {
                    throw new TimeoutException("Timed out waiting for query PropertyChanged after " + timeOutInMs / 1000 + " seconds");
                }
                if (qr.error != null)
                {
                    throw qr.error;
                }
            }
            return new KeyValuePair<string, IEnumerable<IDataObject>>(qr.propertyName, qr.propertyValue);
        }

        class QueryResult
        {
            // input
            internal ManualResetEvent queryComplete = null;
            internal string[] watchedPropertyNames = { "Output", "LastError" };
            // output
            internal string propertyName;
            internal IEnumerable<IDataObject> propertyValue =null;
            internal Exception error = null;
        }
        static Dictionary<object, QueryResult> queryResults = new Dictionary<object, QueryResult>();

        static void On_PropertyChanged(object query, PropertyChangedEventArgs e)
        {
            MomCommon.Utilities.LogMessage("query is a : " + query.GetType());
            if (e == null)
                throw new ArgumentNullException("On_PropertyChanged called with null PropertyChangedEventArgs");
            if (query == null)
                throw new ArgumentNullException("On_PropertyChanged called with null query");
            MomCommon.Utilities.LogMessage("Query returned property: " + e.PropertyName, true);
            QueryResult qr = queryResults[query];
            if (qr == null)
            {
                MomCommon.Utilities.LogMessage("Unable to look up queryResult -- a valid response may have already been processed.", true);
                return;
            }
            if (!(qr.watchedPropertyNames as IList<string>).Contains(e.PropertyName))
            {
                MomCommon.Utilities.LogMessage("Ignoring property changed event since it is not one of our watched properties");
                return;
            }

            PropertyInfo property = query.GetType().GetProperty(e.PropertyName);
            if (property == null)
                MomCommon.Utilities.LogMessage("Unable to look up PropertyInfo for: " + e.PropertyName);
            else
                MomCommon.Utilities.LogMessage("Looked up PropertyInfo for: " + e.PropertyName);

            object queryResponse;
            try
            {
                queryResponse = property.GetValue(query, null);
                if(queryResponse != null)
                    MomCommon.Utilities.LogMessage("Query returned property: " + e.PropertyName + " = " + queryResponse.ToString(), true);
                else
                    MomCommon.Utilities.LogMessage("Unable to read query property: " + e.PropertyName, true);
                qr.propertyName = e.PropertyName;
                qr.propertyValue = queryResponse as IEnumerable<IDataObject>;
                if(qr.propertyValue == null)
                    MomCommon.Utilities.LogMessage("Unable to convert query response to IEnumerable<IDataObject>", true);
            }
            catch (Exception ex)
            {
                qr.error = new InvalidOperationException("Unable to read query response: " + e.PropertyName, ex);
            }
            queryResults.Remove(query);
            qr.queryComplete.Set();
        }
    }
}

