//-------------------------------------------------------------------
// <copyright file="BootStrapper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  A Bootstrapper class that loads each module required for access to the Security/Authentication infrastructure.
// </summary>
//  <history>
//  [nathd] 01OCT09:  Created
//  </history>
//-------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.EnterpriseManagement.Presentation.Security;
using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling;
using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling.ErrorHandlers;
using Microsoft.EnterpriseManagement.Presentation.ErrorHandling;
using Microsoft.Practices.Unity;

namespace Mom.Test.UI.Core.Common
{
    /// <summary>
    /// Bootstrapper: Loads each module required for access to the Security/Authentication infrastructure.
    /// </summary>
    public class BootStrapper : UnityBootstrapper
    {
        /// <summary>
        /// List of Modules.
        /// </summary>
        private List<ModuleInfo> modules;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="modules">List of Modules to be loaded into the Unity Container</param>
        public BootStrapper(List<ModuleInfo> modules)
        {
            this.modules = modules;
        }

        /// <summary>
        /// Creates the Shell.
        /// </summary>
        /// <returns></returns>
        protected override System.Windows.DependencyObject CreateShell()
        {
            return null;
        }

        /// <summary>
        /// Gets the an instance of the Module Catalog and load the desired modules.
        /// </summary>
        /// <returns>An instance of IModfuleCatalog.</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog(this.modules);
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
#warning SecurityDataContext class was moved from improvement 161110 from the Core.Security.DLL find a different mechanism or follow up with Nate or AlexNet
            // Global object carryning the current connection session
//            this.Container.RegisterInstance<SecurityDataContext>(new SecurityDataContext(), new ContainerControlledLifetimeManager());

            // Register the Error Handler for displaying errors in the UI
            IErrorHandler handler = new ErrorHandlerCollection();
            IErrorViewService errorViewService = new ErrorViewService();
            IDisplayErrorHandler displayErrorHandler = new DisplayErrorHandler(errorViewService);
            IDisplayErrorService displayErrorService = new DisplayErrorService(handler, displayErrorHandler);
            this.Container.RegisterInstance<IErrorService>(displayErrorService, new ContainerControlledLifetimeManager());
            this.Container.RegisterInstance<IDisplayErrorService>(displayErrorService, new ContainerControlledLifetimeManager());
        }

    }
}
