using System.Collections.Generic;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling;
using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling.ErrorHandlers;
using Microsoft.EnterpriseManagement.Management.DataProviders;
using Microsoft.EnterpriseManagement.Monitoring.Components;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataProviders;
using Microsoft.EnterpriseManagement.Presentation;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.Presentation.ErrorHandling;
using Microsoft.EnterpriseManagement.Presentation.Security;
using Microsoft.EnterpriseManagement.Presentation.Visual;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.EnterpriseManagement;

namespace Mom.Test.UI.Core.Common
{
    public class SDKConnectionManager : VisualUnityBootstrapper
    {
        private static string managementServerName;
        private static SDKConnectionManager instance = null;
               
        public static void Init(string mgmtServerName)
        {
            managementServerName = mgmtServerName;
        }

        public static SDKConnectionManager Current
        {
            get
            {
                if (instance == null)
                {
                    lock (new object())
                    {
                        instance = new SDKConnectionManager();
                        instance.Run();
                    }
                }

                return instance;
            }
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            return null;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // Using the Configuration Module Catalog will fetch any module configurations stored in the app.config or web.config.
            // See the Desktop.App.Config for an example of how to form up the right blocks of xml in the configuration file(s).

            string[] dataProviderDependency = new string[] { "CoreModule", "DataAccessModule", "SecurityModule" };
            string[] componentDependency = new string[] { "DataAccessModule", "CompositionEngine" };
            string[] securityDependency = new string[] { "CoreModule", "DataAccessModule" };
            string[] tuneupDependency = new string[] { "CoreModule", "SecurityModule", "DataAccessModule", "CompositionEngine" };


            List<ModuleInfo> modules = new List<ModuleInfo>();
            modules.Add(new ModuleInfo("CoreModule", typeof(CoreModule).AssemblyQualifiedName));
            modules.Add(new ModuleInfo("DataAccessModule", typeof(DataAccessModule).AssemblyQualifiedName));
            modules.Add(new ModuleInfo("SecurityModule", typeof(SecurityModule).AssemblyQualifiedName, securityDependency));
            modules.Add(new ModuleInfo("DataProviders", typeof(DataProvidersModule).AssemblyQualifiedName, dataProviderDependency));
            modules.Add(new ModuleInfo("ManagementDataProviders", typeof(ManagementDataProvidersModule).AssemblyQualifiedName, dataProviderDependency));
            modules.Add(new ModuleInfo("CompositionEngine", typeof(CompositionEngineModule).AssemblyQualifiedName));
            // Added the Fully Qualified TuneupModule instead of a using statement because of class collision for IDUtil
            // TODO: Add this module back in when the bug 196907 is fixed and re-add a reference to Tuneup dll
            // modules.Add(new ModuleInfo("TuneupModule", typeof(Microsoft.EnterpriseManagement.Presentation.Tuneup.TuneupModule).AssemblyQualifiedName, tuneupDependency));
            modules.Add(new ModuleInfo("Components", typeof(ComponentsModule).AssemblyQualifiedName, componentDependency));
            modules.Add(new ModuleInfo("DataProvidersLibraryModule", typeof(DataProvidersLibraryModule).AssemblyQualifiedName, dataProviderDependency));

            ModuleCatalog catalog = new ModuleCatalog(modules);

            // The data provider command not found bootstrapper module has declared dependencies as ModuleAttribute instances. 
            // No need to define the dependencies.  
            catalog.AddModule(typeof(DataProviderCommandNotFoundHandlerModule));
            
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Register the Error Handler for displaying errors in the UI
            IErrorHandler handler = new ErrorHandlerCollection();
            IErrorViewService errorViewService = new ErrorViewService();
            IDisplayErrorHandler displayErrorHandler = new DisplayErrorHandler(errorViewService);
            IDisplayErrorService displayErrorService = new DisplayErrorService(handler, displayErrorHandler);
            this.Container.RegisterInstance<IErrorService>(displayErrorService, new ContainerControlledLifetimeManager());
            this.Container.RegisterInstance<IDisplayErrorService>(displayErrorService, new ContainerControlledLifetimeManager());

        }

        #region IConnectionManager Members

        public IDataGateway GetDataGateway()
        {
            return this.Container.Resolve<IDataGateway>();
        }

        public string GetConnectionSessionTicket()
        {
            IConnectionSessionManager manager = this.Container.Resolve<IConnectionSessionManager>();
            IConnectionSessionManagerSynchronous syncManager = manager as IConnectionSessionManagerSynchronous;
            IConnectionSession session = syncManager.Connect(OMServiceUriBuilder.CreateServiceUri(managementServerName), (PropertyCollection)null);

            return session.Ticket;
        }

        public ManagementGroup GetManagementGroup()
        {
            IOMConnectionManager connectionManager = this.Container.Resolve<IOMConnectionManager>();

            return connectionManager.GetConnection(GetConnectionSessionTicket());
        }

        #endregion

        #region IUnityContainerProvider Members

        public IUnityContainer GetUnityContainer()
        {
            return this.Container as IUnityContainer;
        }

        #endregion
    }
}
