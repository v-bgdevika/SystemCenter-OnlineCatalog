// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DashboardWizards.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   IT Pro Dashboard Wizard
// </project>
// <summary>
//   Base class of dashboard wizard.
// </summary>
// <history>
//   [v-dayow] 7/30/2010 Created
//   [v-lileo] 1/6/2011 Add a class for updateAlertConfigurationWizard
//   [v-vijia] 1/31/2011 Split classes DashboardCreationWizard, DashboardPersonalizationWizard and  DashboardConfigurationWizard to specific files.
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    using System.Xml.Linq;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;

    public delegate void CustomPagesHandler(DashboardWizardBase wizard, ICustomPageParams pageParams);
           
    /// <summary>
    /// Do not use
    /// This class is used by DashboardWizardBase to put the wizard in the right place on the screen.     
    /// </summary>
    public class BaseDashboardWindow : Window
    {
        
        /// <summary>
        /// We need to make sure the wizard is placed high enough on the screen so the buttons aren't missing.
        /// </summary>
        /// <param name="WizardTitle"></param>
        public BaseDashboardWindow(string WizardTitle) :
            //base(new QID(";[VisibleOnly, UIA]Name = '" + WizardTitle + "' && Role = 'window'"), ConsoleConstants.DefaultDialogTimeout)
            base(InitQID(WizardTitle), ConsoleConstants.DefaultDialogTimeout)
        {
            Utilities.LogMessage("BaseDashboardWindow:: Constructor");
            //if (ProductSku.Sku == ProductSkuLevel.Mom)
            //{
            //    base.Move(100, 100);
            //}
            Utilities.LogMessage("BaseDashboardWindow:: finish");
        }
                
        private static QID InitQID(string dialogTitle)
        {
            Utilities.LogMessage("InitQID... ");
            QID dialogTitleQID = null;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    dialogTitleQID = new QID(";[UIA]Name = '" + dialogTitle + "' && Role = 'window'");
                    Utilities.LogMessage("dialogTitle " + dialogTitle);
                    break;
                case ProductSkuLevel.Web:
                    dialogTitleQID = new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, dialogTitle));
                    Utilities.LogMessage("dialogTitleWeb " + dialogTitle);
                    break;
                default:
                    break;
            }

            return dialogTitleQID;            
        }
    }

    public abstract class DashboardWizardBase
    {
        public DashboardWizardBase()
        {
            this.LoadDisplayStringsFromMP();

            int retries = 0;
            while (retries < Mom.Test.UI.Core.Common.Constants.DefaultMaxRetry)
            {
                try
                {                   
                    WizardWindow = new BaseDashboardWindow(this.WizardTitle);                    
                    break;
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("DashboardWizardBase:: Failed to find the window. Attempt " + retries + " of " + Mom.Test.UI.Core.Common.Constants.DefaultMaxRetry);
                    retries++;
                    Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond);

                    if (retries == Mom.Test.UI.Core.Common.Constants.DefaultMaxRetry)
                        throw;
                }
            }
        }

        protected Window WizardWindow = null;

        protected CustomPagesHandler CustomPagesHandler = null;

        protected ITemplate Template = null;

        public abstract string WizardTitle { get; }

        public abstract void SettingWizard(DashboardParams settings);

        public class Strings
        {
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel wizard title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancelWizardTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Cancel wizard title        
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelWizardTitle =
                ";Operations Manager" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.WizardFramework.dll" +
                ";Microsoft.EnterpriseManagement.UI.WizardFramework.Resources" +
                ";CancelWizardDialogCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel Wizard Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string CancelWizardTitle
            {
                get
                {
                    if (cachedCancelWizardTitle == null)
                    {
                        cachedCancelWizardTitle = CoreManager.MomConsole.GetIntlStr(ResourceCancelWizardTitle);
                    }

                    return cachedCancelWizardTitle;
                }
            }
        }

        private void LoadDisplayStringsFromMP()
        {
            // Added some log messages due to many bugs coming from this method

            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader);

            Utilities.LogMessage(logHeader + "Checking if Topology is Initialized...");
            if(Topology.MomServersInfo == null)
            {
                Utilities.LogMessage(logHeader + "Topology.MomServersInfo was NULL - now calling Topology.Initialize()");
                Topology.Initialize();
            }

            Utilities.LogMessage(logHeader + "Calling SDKConnectionManager.Init");
            Core.Common.SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);

            Utilities.LogMessage(logHeader + "Assigning ResourceLoader.Connection");
            Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);

            Utilities.LogMessage(logHeader + "Calling GetDefaultResourceFile to load DashboardWizardResources");
            XDocument dashboardWizardDocument = ResourceLoader.ResourceLoader.GetDefaultResourceFile("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.DashboardWizardResource.xml");

            Utilities.LogMessage(logHeader + "Calling ResourceLoader.GetSection 'WizardComponent'");
            XElement wizardSection = ResourceLoader.ResourceLoader.GetSection("WizardComponent", dashboardWizardDocument);

            Utilities.LogMessage(logHeader + "Calling ResourceLoader.LoadResources");
            ResourceLoader.ResourceLoader.LoadResources(this, wizardSection);

            Utilities.LogMessage(logHeader + "Done");
        }
    }

    /// <summary>
    /// used to fill in the General Properties Page
    /// and to hold the custom template info for the custom page
    /// of the Dashboard View wizard
    /// </summary>
    public struct DashboardParams
    {
        public string Name;
        public string Description;
        public string ManagementPack;
        public ITemplate Template;
        public ICustomPageParams CustomPageParams;
    }
}

