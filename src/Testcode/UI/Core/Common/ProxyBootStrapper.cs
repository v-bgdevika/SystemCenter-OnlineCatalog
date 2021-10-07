//-------------------------------------------------------------------
// <copyright file="ProxyBootStrapper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  A Bootstrapper class that loads each module required for access to the Security/Authentication infrastructure.
// </summary>
//  <history>
//  [nathd] 01OCT09:  Created
//  </history>
//-------------------------------------------------------------------using System;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.EnterpriseManagement.Presentation;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.Presentation.DataAccess.Proxy;
using Microsoft.EnterpriseManagement.Presentation.Security.ServiceProxies;
using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;
using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
using Microsoft.EnterpriseManagement.Presentation.Visual;

namespace Mom.Test.UI.Core.Common
{
    /// <summary>
    /// ProxyBootStrapper: Loads each module required for access to the Security/Authentication infrastructure.
    /// </summary>
    public class ProxyBootStrapper : VisualUnityBootstrapper
    {
        /// <summary>
        /// List of Modules
        /// </summary>
        private List<ModuleInfo> modules;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="modules">List of Modules to be loaded into the Unity Container</param>
        public ProxyBootStrapper(List<ModuleInfo> modules)
        {
            this.modules = modules;
        }

        /// <summary>
        /// Create Shell
        /// </summary>
        /// <returns>DependencyObject</returns>
        protected override System.Windows.DependencyObject CreateShell()
        {
            return null;
        }

        /// <summary>
        /// Create the Module Catalog.
        /// </summary>
        /// <returns>A ModuleCatalog instance</returns>
        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog(this.modules);
            return catalog;
        }

        /// <summary>
        /// Configure Container: Register the DataAccess and Logon Services.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            string webServerUrl;


            try
            {
                Initializer.InitializeTopology();
                //Topology.Initialize();
                //string foo = Microsoft.EnterpriseManagement.Test.ScCommon.Topology.TopologyHelper.RootHealthServerName;

                Microsoft.EnterpriseManagement.ManagementGroup mg = Microsoft.EnterpriseManagement.ManagementGroup.Connect(TopologyHelper.RootHealthServerName);
                Microsoft.EnterpriseManagement.Administration.Settings globalSettings = mg.Administration.Settings;
                globalSettings.Refresh();

                webServerUrl = globalSettings.GetDefaultValue(Microsoft.EnterpriseManagement.Administration.Settings.NotificationServer.WebAddresses.WebConsole);

                // Register the DataAccess Service
                this.Container.RegisterType<DataAccessServiceClientConfiguration, DataAccessServiceClientConfiguration>();
                this.Container.RegisterInstance<DataAccessServiceClientConfiguration>(new DataAccessServiceClientConfiguration(new Uri(webServerUrl + "/services/DataAccessService.svc")), new ContainerControlledLifetimeManager());

                // Register the Logon Service
                this.Container.RegisterType<LogonServiceClientConfiguration, LogonServiceClientConfiguration>();
                this.Container.RegisterInstance<LogonServiceClientConfiguration>(new LogonServiceClientConfiguration(new Uri(webServerUrl + "/services/Logon.svc")), new ContainerControlledLifetimeManager());
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Console (SDK) must be installed for tests to work", e);
            }



        }
    }
}
