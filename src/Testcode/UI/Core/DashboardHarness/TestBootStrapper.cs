using System.Windows;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.Visual;
using Microsoft.EnterpriseManagement.Presentation.Tuneup;
using Microsoft.EnterpriseManagement.Presentation.Security;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.Presentation.DataProviders;
using Microsoft.EnterpriseManagement.Presentation;
using Microsoft.EnterpriseManagement.Monitoring.Components;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Management.DataProviders;
//using Microsoft.EnterpriseManagement.UI.Console.Common;
//using Microsoft.EnterpriseManagement.Monitoring.Console.Modules;

//-------------------------------------------------------------------
// <copyright file="BootStrapper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  A TestBootstrapper class that loads each module required for access to the CompositionEngine/Components infrastructure.
// *****THIS CODE WAS MOVED TO CORE/COMMOM  Use it there ***************
// </summary>
//  <history>
//  [sunsingh] 01OCT09:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core
{
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.UnityExtensions;
    /// <summary>
    /// TestBootstrapper: Loads each module required for access to the CompositionEngine/Components infrastructure.
    /// </summary>
    public class TestBootStrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the Shell.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return null;
        }
        /// <summary>
        /// Gets the an instance of the Module Catalog and loads the SecurityModule and ConnectionModule.
        /// *****THIS CODE WAS MOVED TO CORE/COMMOM  Use it there ***************
        /// </summary>
        /// <returns>An instance of IModfuleCatalog.</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // Using the Configuration Module Catalog will fetch any module configurations stored in the app.config or web.config.
            // See the Desktop.App.Config for an example of how to form up the right blocks of xml in the configuration file(s).

            string[] dataProviderDependency = new string[] { "CoreModule", "DataAccessModule", "SecurityModule" };
            string[] componentDependency = new string[] { "TuneupModule", "CompositionEngine" };
            string[] securityDependency = new string[] { "CoreModule", "DataAccessModule" };
            string[] tuneupDependency = new string[] { "CoreModule", "SecurityModule", "DataAccessModule", "CompositionEngine" };

            List<ModuleInfo> modules = new List<ModuleInfo>();
            modules.Add(new ModuleInfo("CoreModule", typeof(CoreModule).AssemblyQualifiedName));
            modules.Add(new ModuleInfo("DataAccessModule", typeof(DataAccessModule).AssemblyQualifiedName, "CoreModule"));
            modules.Add(new ModuleInfo("SecurityModule", typeof(SecurityModule).AssemblyQualifiedName, securityDependency));

            modules.Add(new ModuleInfo("CompositionEngine", typeof(CompositionEngineModule).AssemblyQualifiedName));
            modules.Add(new ModuleInfo("TuneupModule", typeof(TuneupModule).AssemblyQualifiedName, tuneupDependency));
            modules.Add(new ModuleInfo("Components", typeof(ComponentsModule).AssemblyQualifiedName, componentDependency));

            modules.Add(new ModuleInfo("DataProviderCommandNotFoundHandlerModule", typeof(DataProviderCommandNotFoundHandlerModule).AssemblyQualifiedName, securityDependency));

            //these are our three shipping providers
            modules.Add(new ModuleInfo("DataProviders", typeof(DataProvidersModule).AssemblyQualifiedName, dataProviderDependency));
            modules.Add(new ModuleInfo("DataProvidersLibrary", typeof(DataProvidersLibraryModule).AssemblyQualifiedName, dataProviderDependency));
            modules.Add(new ModuleInfo("ManagementDataProviders", typeof(ManagementDataProvidersModule).AssemblyQualifiedName, dataProviderDependency));


            ModuleCatalog catalog = new ModuleCatalog(modules);
            // The data provider command not found bootstrapper module has declared dependencies as ModuleAttribute instances. 
            // No need to define the dependencies.
            //catalog.AddModule(typeof(DataProviderCommandNotFoundHandlerModule));


            //catalog.ModulePath = @"..\..\Test_Dependency\Modules";
            //catalog.AddModule("CoreModule", typeof(CoreModule).AssemblyQualifiedName);
            //catalog.AddModule("Security", typeof(SecurityModule).AssemblyQualifiedName);
            //catalog.AddModule("DataAccess", typeof(DataAccessModule).AssemblyQualifiedName);
            //catalog.AddModule("DataProviders", typeof(DataProvidersModule).AssemblyQualifiedName, dataProviderDependency);
            //catalog.AddModule("CompositionEngine", typeof(CompositionEngineModule).AssemblyQualifiedName);
            //catalog.AddModule("Components", typeof(ComponentsModule).AssemblyQualifiedName, componentDependency);

            return catalog;
        }
    }
}