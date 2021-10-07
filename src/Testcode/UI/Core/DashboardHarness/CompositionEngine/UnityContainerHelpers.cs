using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Presentation.Security;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Mom.Test.UI.Core
{
    /// <summary>
    /// THis class contains useful functions to get information from the UnityContainer
    /// </summary>
    public static class UnityContainerHelpers
    {
        /// <summary>
        /// This function gets the connection session ticker that is in the registered 
        /// IConnectionContext service provider
        /// </summary>
        /// <returns>connection session ticket</returns>
        public static string GetConnectionSessionTicket()
        {
            var unityContainer = GetUnityContainer();
            var connectionContext = unityContainer.Resolve<IConnectionContext>();
            if (connectionContext == null)
            {
                throw new Exception("Did not find the IConnectionContext service in the container");
            }

            return connectionContext.Session.Ticket;
        }

        /// <summary>
        /// THis function locates the UnityContainer
        /// </summary>
        /// <returns>unity container</returns>
        public static IUnityContainer GetUnityContainer()
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            if (container == null)
            {
                throw new Exception("Did not find the unity container.");
            }

            return container;
        }


        /// <summary>
        /// This function locates the CompositionEngine service provider 
        /// in the unity container
        /// </summary>
        /// <param name="container">unity container</param>
        /// <returns>composition engine service provider</returns>
        public static ICompositionEngine GetCompositionEngine(IUnityContainer container)
        {
            var compositionEngine = container.Resolve<ICompositionEngine>();
            if (compositionEngine == null)
            {
                throw new Exception("Did not find the composition engine in the unity container.");
            }

            return compositionEngine;
        }

        /// <summary>
        /// This function returns the connection to the management group 
        /// using the information present in the IOMConnectionManager service
        /// </summary>
        /// <returns>connection to management group</returns>
        public static Microsoft.EnterpriseManagement.ManagementGroup GetConnection()
        {
            var unityContainer = GetUnityContainer();
            var connectionManager = unityContainer.Resolve<IOMConnectionManager>();
            if (connectionManager == null)
            {
                throw new Exception("Did not find the IOMConnectionManager service in the container");
            }

            return connectionManager.GetConnection(GetConnectionSessionTicket());
        }
    }
}
