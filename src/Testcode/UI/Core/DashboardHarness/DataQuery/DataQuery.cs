using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Monitoring.UnitComponents.Data;
using Microsoft.EnterpriseManagement.Presentation.Controls;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;
using System.Data;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    /// <summary>
    /// This is the base class of all the data queries. This class provides
    /// all the common functionality needed by all the data queries
    /// </summary>
    public abstract class DataQuery : IDisposable
    {

        #region Global Variable Names

        private class GlobalVariableNames
        {
            public const string ConnectionSessionTicket = "ConnectionSessionTicket";
            public const string IsBusy = "IsBusy";
            public const string LastError = "LastError";
        }

        #endregion

        #region Property Names

        public class PropertyNames
        {
            public const string Output = "Output";
        }

        #endregion

        protected const int componentCreationTimeOut = 1*60*1000; // One minute
        protected Thread dataQueryThread = null;
        protected SynchronizationContext dataQuerySynchronizationContext = null;
        protected ComponentRequest compRequest; // this is used to interact with the underlying components
        protected Exception lastError; // this has the exception object that might have occured during the last operation
        protected Dictionary<string, object> queryParameters; // collection of parameters set on the query during the query creation
        protected object composition = null; // the instantiated DUI composition
        private bool isBusy = false; // the current readiness of the composition
        private DataQueryBusyIndicator busyIndicator = new DataQueryBusyIndicator();
        private DataQueryOutputReadinessIndicator outputReadinessIndicator = null;
        private bool isDisposed = false;
        protected Guid dataQueryGuid = Guid.NewGuid(); // use a Guid value to track release status for each data query instance.

        /// <summary>
        /// This bootstraps the UnityContainer, CompositionEngine and all the dependencies
        /// </summary>
        static DataQuery()
        {
            var ceInitializer = new CeComponentCreationBootStrapper();
            ceInitializer.Initialize(Utilities.MomServerName, true, CeComponentCreationBootStrapper.DesktopModules);
        }
        /// <summary>
        /// This is to be implemented by all the derived classes. The derived classes
        /// should provide the query parameter values that will be used during the
        /// creation of the composition.
        /// </summary>
        protected virtual Dictionary<string, object> GetDefaultQueryParameters()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is to be implemented by the derived classes. This is to be used
        /// to indicate whethere the query would process any requests. Queries fetch
        /// the data when some/all of their parameters are initialized. In order to 
        /// implement this correctly, you need to look at the product code and check
        /// implementations such as IsReadyToFetchData. Not implementing this correctly
        /// could result in infinite waits while attempting to fetch the output value.
        /// </summary>
        protected abstract bool ShouldWait 
        { 
            get; 
        }

        /// <summary>
        /// Fully qualified name of the query. example: Microsoft.SystemCenter.Visualization.Library!GetAlertsForEntitiesQuery
        /// </summary>
        protected abstract string QueryName { get; }

        /// <summary>
        /// The global variables used by the composition engine while processing the composition
        /// </summary>
        protected virtual Dictionary<string, object> GlobalVariables
        {
            get
            {
                return new Dictionary<string, object>
                           {
                               {GlobalVariableNames.ConnectionSessionTicket, UnityContainerHelpers.GetConnectionSessionTicket()},
                               {GlobalVariableNames.IsBusy, false},
                               {GlobalVariableNames.LastError, GetDefaultLastError()}
                           };
            }
        }

        /// <summary>
        /// This is the list of handlers that receive notifications on changes to the global variables
        /// </summary>
        protected virtual Dictionary<string, EventHandler<EngineServiceChangedEventArgs>> ServiceChangeHandlers
        {
            get
            {
                return new Dictionary<string, EventHandler<EngineServiceChangedEventArgs>>
                           {
                               {GlobalVariableNames.IsBusy, busyIndicator.IsBusyEventHandler},
                               {GlobalVariableNames.LastError, this.ServiceChangedEventHandler}
                           };
            }
        }

        private bool IsBusy
        {
            get
            {
                return busyIndicator.IsBusy || outputReadinessIndicator.IsBusy;
            }
        }

        /// <summary>
        /// This is the default value set while creating the query
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<IDataObject> GetDefaultInput()
        {
            return new List<IDataObject>();
        }

        /// <summary>
        /// The exception object that might have occured during the last operation. This value 
        /// is not reset.
        /// </summary>
        public Exception LastError
        {
            get { return lastError; }
        }

        /// <summary>
        /// Initializes a new istances of the data query component. This instantiates the 
        /// actual product query component.
        /// </summary>
        protected DataQuery() : this(5, 5)
        {
            
        }

        /// <summary>
        /// Initializes a new istances of the data query component. This instantiates the 
        /// actual product query component.
        /// </summary>
        protected DataQuery(int timeoutMinutes, int sleepSeconds)
        {
            Utilities.LogMessage(this.LogParameters(), true);
            Utilities.LogMessage("Create Data query instance: " + dataQueryGuid.ToString());

            composition = CeComponentFactory.CreateInstance(
                name: QueryName,
                targetInstance: CeComponentFactory.GetBaseDataType(),
                parameters: this.GetDefaultQueryParameters(),
                globalVariables: this.GlobalVariables,
                creatationTimeoutInMilliSec: componentCreationTimeOut,
                serviceChangedEventHandlers: this.ServiceChangeHandlers,
                outRequest: out compRequest,
                dataQuerySynchronizationContext: out dataQuerySynchronizationContext,
                dataQueryThread: out dataQueryThread);

            if (composition == null)
            {
                throw new Exception("Did not create the query component.");
            }

            outputReadinessIndicator = new DataQueryOutputReadinessIndicator(compRequest);

            if (ShouldWait)
            {
                WaitUntilReady(timeoutMinutes, sleepSeconds); // We need to wait so as to return a component that is ready for interaction
            }

            // Check if there was error during component creation.
            lastError = DataObjectHelpers.GetLastError(compRequest.GetParameter("LastError") as IDataObject);
            if (lastError != null)
            {
                throw lastError;
            }

            // Listen to changes to the data context. This is primary used to know if there was any error 
            // in the composition and the busy state of the component.
            compRequest.ParameterChanged += 
                new EventHandler<ComponentRequestParameterChangedEventArgs>(DataContextPropertyChanged);            
        }

        // The default handler prints out the name of the data context property that has changed.
        protected virtual void DataContextPropertyChanged(object sender, ComponentRequestParameterChangedEventArgs e)
        {
            Utilities.LogMessage(string.Format("DataQuery - {0}::DataContextPropertyChanged PropertyName: {1}", dataQueryGuid.ToString(), e.ParameterName));
        }

        /// <summary>
        /// Use this method to change the value of the input to the data query
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="value"></param>
        public void SetProperty(string propName, object value)
        {
            this.SetProperty(propName, value, false);
        }

        /// <summary>
        /// Use this method to change the value of the input to the data query
        /// </summary>
        /// <param name="propertyName">name of the property to be changed</param>
        /// <param name="value">new value of the property</param>
        /// <param name="isSynchronous">
        /// true - change the property and wait till the composition is ready.
        /// false - change the property and return immediately.
        /// </param>
        public void SetProperty(string propertyName, object value, bool isSynchronous)
        {
            // Ask the derived classes to do the actual setting of the property
            SetPropertyInternal(propertyName, value);

            if (!isSynchronous)
            {
                return;
            }

            if (lastError != null)
            {
                throw lastError;
            }
        }

        /// <summary>
        /// This function is used to listen to changes to the global variables.
        /// </summary>
        protected void ServiceChangedEventHandler(object sender, EngineServiceChangedEventArgs eventArgs)
        {
            var prefix = "ServiceChangedEventHandler ";
            switch (eventArgs.ServiceName)
            {
                case GlobalVariableNames.LastError:
                    {
                        // there was an error in the composition
                        var lastErrorValue = DataObjectHelpers.GetLastError(eventArgs.Value as IDataObject);
                        lock(this)
                        {
                            lastError = lastErrorValue;
                        }

                        if (lastError != null)
                        {
                            Utilities.LogMessage(prefix + eventArgs.ServiceName + ": " + lastError.Message);
                        }
                        
                        break;
                    }

                default:
                    {
                        // just print out the name
                        Utilities.LogMessage(eventArgs.ServiceName + " has changed.");
                        break;
                    }
            }
        }

        /// <summary>
        /// This function uses a heuristic to claculate the busy-ness of the the composition.
        /// Min sleep time is 2 seconds. Max time is 5 minutes
        /// </summary>
        public virtual void WaitUntilReady()
        {
            WaitUntilReady(5, 5); //5 minutes is default
        }
        
        public virtual void WaitUntilReady(int timeoutMinutes, int sleepSeconds)
        {
            var prefix = string.Format("DataQuery - {0}.WaitUntilReady: timeoutMinutes: {1}, sleepSeconds: {2} ", dataQueryGuid.ToString(), timeoutMinutes, sleepSeconds);
            Utilities.LogMessage(prefix + "Start");
            try
            {
                var busyIndicator = new ManualResetEvent(false);

                // Use a separate thread to control the upper bound on the wait time
                var busyWaitThread = new Thread((_) =>
                {
                    Utilities.LogMessage(prefix + "Busy Wait thread started");
                    do
                    {
                        if (this.IsBusy)
                        {
                            Utilities.LogMessage(prefix + "Sleeping for " + sleepSeconds +" sec");
                            Thread.Sleep(sleepSeconds * 1000);
                        }
                        else
                        {
                            Utilities.LogMessage(prefix + "Sleeping for " + sleepSeconds + " sec");
                            Thread.Sleep(sleepSeconds * 1000);
                            if (!this.IsBusy)
                            {
                                Utilities.LogMessage(prefix + "Query is not busy!!");
                                busyIndicator.Set();
                                break;
                            }

                            if (lastError != null)
                            {
                                Utilities.LogMessage(prefix + "Query is in error!!");
                                busyIndicator.Set();
                                break;
                            }
                        }

                    } while (true);
                });

                busyWaitThread.Start();

                var timeOut = timeoutMinutes * 60 * 1000; 
                var eventTriggered = busyIndicator.WaitOne(timeOut);
                if (!eventTriggered)
                {
                    busyWaitThread.Abort();
                    Utilities.LogMessage("Component is busy even after (minutes): " + timeoutMinutes);
                    Utilities.LogMessage("Will go on with verifying logic....");
                }

                busyIndicator.Close();
            }
            finally
            {
                Utilities.LogMessage(prefix + "End");
            }
            return;
        }

        /// <summary>
        /// Derived classes should implement this to log information about the current
        /// set of parameter values being used by the query
        /// </summary>
        /// <returns></returns>
        public virtual string LogParameters()
        {
            return null;
        }

        /// <summary>
        /// Get the value of the property from the data context of the composition
        /// </summary>
        public virtual object GetProperty(string propertyName)
        {
            return GetPropertyValueFromContext(propertyName);
        }

        /// <summary>
        /// Dispose DataQuery if not use any more
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///  Clear unused resource, unsubscribe global event handles 
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    if (dataQueryThread != null)
                    {
                        dataQueryThread.Abort();
                    }

                    compRequest.ParameterChanged -= new EventHandler<ComponentRequestParameterChangedEventArgs>(DataContextPropertyChanged);
                    this.compRequest = null;
                    
                    //Unsubscribe global event handler if finished
                    CeComponentFactory.UnsubscribeToGlobalServices(this.GlobalVariables, this.ServiceChangeHandlers);
                    isDisposed = true;
                }
            }
        }

        /// <summary>
        /// Finalize
        /// </summary>
        ~DataQuery()
        {
           // Simply call Dispose(false).
           Dispose (false);
        }

        /// <summary>
        /// The default sort properties used in composition creation.
        /// </summary>
        /// <returns>default set is empty list</returns>
        protected IEnumerable<SortValueDefinitionType> GetDefaultSortProperties()
        {
            return new List<SortValueDefinitionType>();
        }

        /// <summary>
        /// Get the default output object that is set on the data query composition
        /// at the time of creation.
        /// </summary>
        /// <returns>default output</returns>
        protected static IDataObjectCollection GetDefaultOutput()
        {
            var dataModel = new DynamicObservableDictionaryDataModel<string>(
                AlertProperty.PropertyNames.Id,
                AlertProperty.PropertyNames.Id,
                AlertProperty.PropertyNames.Id
                );

            return dataModel.CreateCollection();
        }

        /// <summary>
        /// The default error object that is used while creating the data query
        /// </summary>
        /// <returns>default error object</returns>
        protected IDataObject GetDefaultLastError()
        {
            return null;
        }

        /// <summary>
        /// The default display string object that is used while creatinf the data query
        /// </summary>
        /// <returns></returns>
        protected IDataObject GetDefaultDisplayStrings()
        {
            return null;
        }

        /// <summary>
        /// This is used to calculate the list of columns based on the existing set ot columns
        /// and the list of new columns. 
        /// If the operation is inclusion, then returned list contains the
        /// existing columns + new list of items. 
        /// If the operation is exclusion, then the returned
        /// list contains existing items - nuew list of items
        /// to the 
        /// </summary>
        /// <param name="existingItems">existing set of columns</param>
        /// <param name="list">new list of columns</param>
        /// <param name="isInclusion">true - inclusion, false - exclusion</param>
        /// <returns></returns>
        public static IEnumerable<ValueDefinitionType> CalculateNewColumnList(
            IEnumerable<ValueDefinitionType> existingItems,
            List<ValueDefinitionType> list, 
            bool isInclusion)
        {
            var netProperties = new List<ValueDefinitionType>();
            netProperties.AddRange(existingItems);

            // You dont check if the column is duplicated. This is the responsibility of the caller. 
            // Having it this way, is useful for negative cases.
            if (isInclusion)
            {
                netProperties.AddRange(list);
            }
            else
            {
                // While removing, you remove all instances of the column
                foreach (var valueDefinitionType in list)
                {
                    if (netProperties.Contains(valueDefinitionType))
                    {
                        netProperties.Remove(valueDefinitionType);
                    }
                }
            }

            return netProperties;
        }

        /// <summary>
        /// Derived classes should implement the specifics of setting the property values.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected abstract void SetPropertyInternal(string propertyName, object value);

        protected object GetPropertyValueFromContext(string propertyName)
        {
            object retVal = null;
            if (dataQuerySynchronizationContext == null)
            {
                retVal = compRequest.GetParameter(propertyName);
            }
            else
            {
                dataQuerySynchronizationContext.Send((_) =>
                {
                    retVal = compRequest.GetParameter(propertyName);
                },
                    null);
            }
            return retVal;
        }

    }
}
