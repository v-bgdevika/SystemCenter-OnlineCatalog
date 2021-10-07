using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Mom.Test.UI.Core.Common
{
    ///<summary>
    /// This class is to be used to create an instance of a DUI composition.
    ///</summary>
    public static class CeComponentFactory
    {
        ///<summary>
        /// This method creates and instance of the DUI composition.
        ///</summary>
        ///<param name="name">Name of the component</param>
        ///<param name="parameters">Input and put put parameters of the component</param>
        ///<param name="globalVariables">Global variables that are needed by the composition</param>
        ///<param name="targetInstance">Target of the component</param>
        ///<param name="creatationTimeoutInMilliSec">Time within which the composition engine should create the component</param>
        ///<param name="serviceChangedEventHandlers">Optional list of service changed evnet handlers for the global vaiables. Can be defaulted to null</param>
        ///<param name="context">The data context object of the composition</param>
        ///<returns>Instance of the component</returns>
        ///<exception cref="Exception">Exception is throw if unity container is not initialized or if there is no implementation 
        /// of the composition engine interface in the unity container or if the composition engine encountered an error while creating the comonent or if the component was nt
        /// created within the allotted time.</exception>
        public static object CreateInstance(string name,
                                            object targetInstance,
                                            Dictionary<string, object> parameters,
                                            Dictionary<string, object> globalVariables,
                                            Dictionary<string, EventHandler<EngineServiceChangedEventArgs>> serviceChangedEventHandlers,
                                            int creatationTimeoutInMilliSec,
                                            out ComponentRequest outRequest,
                                            out SynchronizationContext dataQuerySynchronizationContext,
                                            out Thread dataQueryThread
            )
        {
            var prefix = "CeComponentFactory::CreateInstance ";
            Utilities.LogMessage(prefix + "Start");

            try
            {

                Utilities.LogMessage(prefix + "CeComponentFactory::CreateInstance Creating component:" + name);

                var container = UnityContainerHelpers.GetUnityContainer();
                Utilities.LogMessage(prefix + "Got the UnityContainer.");

                var compositionEngine = UnityContainerHelpers.GetCompositionEngine(container);
                Utilities.LogMessage(prefix + "Got the composition engine.");

                string dataTypeName = null;
                object result = null;
                Exception lastError = null;
                var operationComplete = new ManualResetEvent(false);

               //DataContext dataContext = null;
                ComponentRequest componentRequest = null;

                // Need to do the chunk of the work in a seperate thread or else
                // we wont get the call back from the composition engine when the
                // creation request is complete
                SynchronizationContext threadContext = null;
                Thread thread = null;
                thread = new Thread((_) =>
                                             {
                                                 SubscribeToGlobalServices(globalVariables, serviceChangedEventHandlers, compositionEngine);

                                                 // Create component request
                                                 ComponentRequest request = null;
                                                 try
                                                 {
                                                     request = compositionEngine.CreateRequest(
                                                         name: name,
                                                         dataTypeName: dataTypeName,
                                                         targetInstance: targetInstance,
                                                         container: container);
                                                     threadContext = SynchronizationContext.Current;
                                                 }
                                                 catch (Exception e)
                                                 {
                                                     lastError = e;
                                                 }

                                                 if ((request == null) || (lastError != null))
                                                 {
                                                     lastError = new Exception("Failed to create the component request",
                                                                               lastError);
                                                     operationComplete.Set();
                                                     return;
                                                 }

                                                 Utilities.LogMessage(prefix + "Component request created");

                                                 // populate the data context in the component request with default parameter values
                                                 Utilities.LogMessage(prefix + "Component request populated with the parameters");
                                                 foreach (var key in parameters.Keys)
                                                 {
                                                     var param = request.GetParameter(key.ToString());
                                                     request.SetParameter(key.ToString(), parameters[key]);
                                                 }

                                                 // set up the event handler to handle the completion of the request
                                                 var resetEvent = new ManualResetEvent(false);
                                                 request.RequestCompleted +=
                                                     (sender, args) =>
                                                     {
                                                         Utilities.LogMessage(prefix + "ComponentRequest.RequestCompleted triggered.");

                                                         if (args.Error == null)
                                                         {
                                                             result = args.Result;
                                                             Utilities.LogMessage(prefix + "ComponentRequest.RequestCompleted without errors.");
                                                         }
                                                         else
                                                         {
                                                             lastError = args.Error;
                                                             Utilities.LogMessage(prefix + "ComponentRequest.RequestCompleted with error.");
                                                         }
                                                         resetEvent.Set();
                                                     };

                                                 // Ack composition engine to create the component
                                                 Utilities.LogMessage(prefix + "Requesting the component from the composition engine.");
                                                 compositionEngine.CreateComponent(request);

                                                 // Composition engine has only a fixed time within which it should 
                                                 // create the component
                                                 var eventTriggered = resetEvent.WaitOne(creatationTimeoutInMilliSec);
                                                 if (!eventTriggered)
                                                 {
                                                     lastError = new Exception("Operation timed out");
                                                     Utilities.LogMessage(prefix + "Component request timed out.");
                                                 }

                                                 componentRequest = request;

                                                 // This would show how the bindings are set in the query.
                                                 // and is no longer possible now that the context is hidden
                                                 //DataContextHelpers.DumpContext(componentRequest);

                                                 // Now we are done
                                                 operationComplete.Set();

                                                 thread.Join();
                                             }
                     );

                // Create the thread that would create the component
                Utilities.LogMessage(prefix + "Starting a new thread to create the component.");

                thread.SetApartmentState(ApartmentState.STA);
                
                //thread.IsBackground = false;
                thread.IsBackground = true;

                thread.Start(new object());

                // Wait for the component creation to be successful
                operationComplete.WaitOne();
                Utilities.LogMessage(prefix + "Component creation completed.");

                outRequest = componentRequest;

                var dataContext = componentRequest.GetDataContext();
                dataQuerySynchronizationContext = dataContext.GetSynchronizationContext();

                dataQueryThread = thread;

                // if there was an error creating the component,
                // now is the time to signal it.
                if (lastError != null)
                {
                    throw lastError;
                }

                // return the created component.
                return result;
            }
            finally
            {
                Utilities.LogMessage(prefix + "End");
            }
        }

        /// <summary>
        /// This function sets the global variable values and subscribes to changes to their values.
        /// </summary>
        /// <param name="globalVariables">Global variable name and value</param>
        /// <param name="serviceChangedEventHandlers">Global variable name and the handler for their changes</param>
        /// <param name="compositionEngine"></param>
        private static void SubscribeToGlobalServices(Dictionary<string, object> globalVariables, Dictionary<string, EventHandler<EngineServiceChangedEventArgs>> serviceChangedEventHandlers, ICompositionEngine compositionEngine)
        {
            var prefix = "CeComponentFactory.SubscribeToGlobalServices ";

            Utilities.LogMessage(prefix + "Populate global variables for the composition.");
            foreach (var item in globalVariables)
            {
                // Set the global variable value
                compositionEngine.SetService(item.Key, item.Value);

                // subscribe to changes to their values
                if ((serviceChangedEventHandlers != null) &&
                    (serviceChangedEventHandlers.ContainsKey(item.Key)))
                {
                    compositionEngine.SubscribeToService(item.Key, serviceChangedEventHandlers[item.Key]);
                }
            }
        }

        /// <summary>
        /// This function provide a way to unsubscribe event handle
        /// </summary>
        /// <param name="globalVariables">Global variable name and value</param>
        /// <param name="serviceChangedEventHandlers">Global variable name and the handler for their changes</param>
        /// <param name="compositionEngine"></param>
        public static void UnsubscribeToGlobalServices(Dictionary<string, object> globalVariables, Dictionary<string, EventHandler<EngineServiceChangedEventArgs>> serviceChangedEventHandlers)
        {
            var prefix = "CeComponentFactory.UnsubscribeToGlobalServices ";
            Utilities.LogMessage(prefix + ": Start");

            var container = UnityContainerHelpers.GetUnityContainer();
            Utilities.LogMessage(prefix + "Got the UnityContainer.");

            var compositionEngine = UnityContainerHelpers.GetCompositionEngine(container);
            Utilities.LogMessage(prefix + "Got the composition engine.");

            foreach (var item in globalVariables)
            {
                // subscribe to changes to their values
                if ((serviceChangedEventHandlers != null) &&
                    (serviceChangedEventHandlers.ContainsKey(item.Key)))
                {
                    Utilities.LogMessage(prefix + ": Unsubscribe " + item.Key);
                    compositionEngine.UnsubscribeFromService(item.Key, serviceChangedEventHandlers[item.Key]);
                }
            }
        }

        ///<summary>
        /// This method gives the IDataObject for an instance of the BaseDataType
        ///</summary>
        ///<returns>IDataObject form of the BaseDataType</returns>
        public static IDataObject GetBaseDataType()
        {
            const string type = "BaseDataType";

            var dataModel = new SimpleDataModel();
            var targetType = dataModel.Types.Create(type);

            return dataModel.CreateInstance(targetType);
        }        
    }

    internal static class ComponentRequestHelpers
    {
        public static DataContext GetDataContext(this ComponentRequest request)
        {
            var propertyInfo = request.GetType().GetProperty("Parameters", BindingFlags.Instance | BindingFlags.NonPublic);
            var dataConext = propertyInfo.GetValue(request, null) as DataContext;
            return dataConext;
        }

        public static SynchronizationContext GetSynchronizationContext(this DataContext dataContext)
        {
            var fieldInfo = dataContext.GetType().GetField("synchronizationContext", BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo.GetValue(dataContext) as SynchronizationContext;
        }
    }

}
