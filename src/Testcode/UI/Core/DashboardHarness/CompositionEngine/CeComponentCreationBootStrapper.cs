using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Management.DataProviders;
using Microsoft.EnterpriseManagement.Monitoring.Components;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.Presentation.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.Security;
using Microsoft.EnterpriseManagement.Presentation.Tuneup;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace Mom.Test.UI.Core.Common
{
    ///<summary>
    /// This class boot straps the composition engine and the composition engine registry. After the boot strap process,
    /// you can start requesting the composition engine to create instances of the compositions defined in the DUI.
    ///</summary>
    public class CeComponentCreationBootStrapper
    {
        ///<summary>
        /// This is a reference to the component registry
        ///</summary>
        [Dependency]
        public IComponentRegistry Registry
        {
            get;
            set;
        }

        /// <summary>
        /// TypeSystem service in the container
        /// </summary>
        [Dependency]
        public ITypeSystem TypeSystem
        {
            get; 
            set;
        }

        /// <summary>
        /// Desktop modules
        /// </summary>
        public static List<ModuleInfo> DesktopModules
        {
            get 
            {
                    return new List<ModuleInfo>
                    {
                        new ModuleInfo("CoreModule", typeof(CoreModule).AssemblyQualifiedName),
                        new ModuleInfo("DataAccessModule", typeof(DataAccessModule).AssemblyQualifiedName, "CoreModule"),
                        new ModuleInfo("SecurityModule", typeof(SecurityModule).AssemblyQualifiedName, "CoreModule"),
                        new ModuleInfo("ce", typeof(CompositionEngineModule).AssemblyQualifiedName),
                        new ModuleInfo("TuneupModule", typeof(TuneupModule).AssemblyQualifiedName, "CoreModule", "SecurityModule", "DataAccessModule", "ce"),
                        new ModuleInfo("com", typeof(ComponentsModule).AssemblyQualifiedName, "ce", "TuneupModule"),
                        new ModuleInfo("DataProviders", typeof(DataProvidersModule).AssemblyQualifiedName, "DataAccessModule"),
                        new ModuleInfo("ManagementDataProvidersModule", typeof(ManagementDataProvidersModule).AssemblyQualifiedName, "CoreModule", "SecurityModule", "DataAccessModule"),
                        new ModuleInfo("DataProvidersLibraryModule", typeof(DataProvidersLibraryModule).AssemblyQualifiedName, "CoreModule", "SecurityModule", "DataAccessModule"),
                        new ModuleInfo("ServiceLevelDataProviders", typeof(Microsoft.EnterpriseManagement.ServiceLevel.DataProviders.DataProvidersModule).AssemblyQualifiedName, "DataAccessModule"),
                    };
                }
        }

        public static List<ModuleInfo> WebModules
        {
            get
            {
                return new List<ModuleInfo>
                {
                    new ModuleInfo("CoreModule", typeof (CoreModule).AssemblyQualifiedName),
                    new ModuleInfo("CoreProxyModule", typeof (CoreProxyModule).AssemblyQualifiedName, "CoreModule"),
                    new ModuleInfo("DataAccessModule", typeof(DataAccessProxyModule).AssemblyQualifiedName, "CoreModule"),
                    new ModuleInfo("SecurityModule", typeof(SecurityProxyModule).AssemblyQualifiedName, "CoreModule"),
                    new ModuleInfo("com", typeof(ComponentsModule).AssemblyQualifiedName, "ce"),
                    new ModuleInfo("ce", typeof(CompositionEngineModule).AssemblyQualifiedName)
                };
            }
        }

        ///<summary>
        /// This method bootstraps the composition engine and the component registry
        ///</summary>
        ///<param name="sdkServerName">Name of the SDK Server machine</param>
        ///<param name="desktop">
        /// true = Use the Desktop boot strapper and the DataAccessModule
        /// false = Use the Proxy boot strapper and the ProxyDataAccessModule
        /// </param>
        ///<param name="modules">List of modules to be registered with the unity container.</param>
        ///<exception cref="NotSupportedException">Exception thrown if the implementation of the IConnectionSessionManagerSynchronous is 
        /// not found in the unity container.</exception>
        public void Initialize(string sdkServerName, bool desktop, List<ModuleInfo> modules)
        {
            string prefix = "CeComponentCreationBootStrapper::Initialize ";

            Utilities.LogMessage(prefix + "Start. SDK Server Name:" + sdkServerName);

            try
            {
                UnityBootstrapper bootstrapper = null;

                // Get the bootstrapper
                if (desktop)
                {
                    Utilities.LogMessage(prefix + "Instantiating the desktop bootstrapper.");
                    bootstrapper = new BootStrapper(modules);
                }
                else
                {
                    Utilities.LogMessage(prefix + "Instantiating the proxy bootstrapper.");
                    bootstrapper = new ProxyBootStrapper(modules);
                }

                // run the bootstrapper
                Utilities.LogMessage(prefix + "Starting to run the boot strapper.");
                bootstrapper.Run();

                var unityContainer = ServiceLocator.Current.GetService(typeof (IUnityContainer)) as IUnityContainer;

                // Initialize composition engine
                CompositionEngine.InitializeEngineCore(unityContainer);
                CompositionEngine.InitializeEngine(unityContainer);

                // Initialize the type system
                unityContainer.RegisterType<ITypeCache, TypeCache>(new ContainerControlledLifetimeManager());
                unityContainer.RegisterType<IComponentRegistry, ComponentRegistry>(new ContainerControlledLifetimeManager());
                unityContainer.RegisterType<ITypeSystem, BaseTypeSystem>(new ContainerControlledLifetimeManager());
                unityContainer.RegisterType<ITypeCache, TypeCache>(new ContainerControlledLifetimeManager());

                // Register the composition engine factory assembly
                var factoryRegistry = unityContainer.Resolve<IComponentFactoryRegistry>();
                if (factoryRegistry != null)
                {
                    factoryRegistry.RegisterAssembly(typeof (CompositionEngineFactory).Assembly);
                }

                // Initialize protocol resolver
                var resolverRegistry = unityContainer.Resolve<IProtocolResolverRegistry>();
                if (resolverRegistry != null)
                {
                    resolverRegistry.RegisterAssembly(typeof (CompositionEngineFactory).Assembly);
                }

                // Initialize component registry
                if (!unityContainer.IsInterfaceRegistered<IComponentRegistry>())
                {
                    unityContainer.RegisterType<IComponentRegistry, ComponentRegistry>(new ContainerControlledLifetimeManager());
                }

                // Build up the bootstapper
                unityContainer.BuildUp(GetType(), this);

                // Get an instance of the desktop connection manager
                var manager = unityContainer.Resolve<IConnectionSessionManager>() as IConnectionSessionManagerSynchronous;
                if (manager == null)
                {
                    throw new NotSupportedException("The Connection Session Manager does not support synchronous operations");
                }

                #region Sign in to OM

                IConnectionSession session;
                var connectionParameters = new PropertyCollection();
                connectionParameters["privateSession"] = true; 

                if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["UserName"]))
                {
                    session = manager.Connect(OMServiceUriBuilder.CreateServiceUri(sdkServerName),
                                              ConfigurationManager.AppSettings["UserName"],
                                              ConfigurationManager.AppSettings["Password"], connectionParameters);
                }
                else
                {
                    session = manager.Connect(OMServiceUriBuilder.CreateServiceUri(sdkServerName), connectionParameters);
                }

                unityContainer.RegisterInstance(typeof (IConnectionContext), new ConnectionContext {Session = session},
                                                new ContainerControlledLifetimeManager());

                #endregion

                // This loads all the types from the DUI MPs in the sysytem.
                ((BaseTypeSystem) TypeSystem).Init(session.Ticket);
                if (desktop)
                {
                    Registry.Init(CompositionPlatform.WpfPlatform).BlockOn(new AutoResetEvent(false));
                }
                else
                {
                    Registry.Init(CompositionPlatform.SilverlightPlatform).BlockOn(new AutoResetEvent(false));
                }

                Utilities.LogMessage(prefix + "Registry initialization complete.");
            }
            finally
            {
                Utilities.LogMessage(prefix + "End.");
            }
        }
    }

    /// <summary>
    /// Extension methods on IObservable 
    /// </summary>
    public static class ObservableExtension
    {
        /// <summary>
        /// Idle wait till the blocker is triggered
        /// </summary>
        /// <typeparam name="T">type of the observable</typeparam>
        /// <param name="observable">observable instance</param>
        /// <param name="blocker">eevnt that marks the completion of an action</param>
        public static void BlockOn<T>(this IObservable<T> observable, AutoResetEvent blocker)
        {
            BlockOn<T>(observable, blocker, null);
        }

        /// <summary>
        /// Idle wait till the blocker is triggered
        /// </summary>
        /// <typeparam name="T">type of the observable</typeparam>
        /// <param name="observable">observable instance</param>
        /// <param name="blocker">eevnt that marks the completion of an action</param>
        /// <param name="action">asynchronous action that sets the event when it is complete</param>
        public static void BlockOn<T>(this IObservable<T> observable, AutoResetEvent blocker, Action<T> action)
        {
            Exception exception = null;
            observable.Subscribe(_ =>
            {
                if (action != null) action(_);
                blocker.Set();
            }, ex => { exception = ex; blocker.Set(); });
            blocker.WaitOne();
            if (exception != null)
            {
                throw exception;
            }
        }
    }

}
