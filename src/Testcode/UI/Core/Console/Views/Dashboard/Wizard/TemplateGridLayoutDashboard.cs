// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   IT Pro Dashboard Wizard
// </project>
// <summary>
//   class TemplateFlowLayoutDashboard
// </summary>
// <history>
//   [v-vijia] 1/31/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    using System;
    using System.Linq;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.ResourceLoader;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using System.Reflection;
    using System.IO;
    using System.Xml.Linq;

    public class TemplateGridLayoutDashboard : ITemplate
    {
        [Resource(ID = "Microsoft.SystemCenter.Visualization.GridLayout")]
        private string templateLocName;

        public TemplateGridLayoutDashboard()
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            XDocument dashboardWizardDocument = ResourceLoader.GetDefaultResourceFile("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.DashboardWizardResource.xml");
            XElement templateSection = ResourceLoader.GetSection("TemplateComponent", dashboardWizardDocument);
            ResourceLoader.LoadResources(this, templateSection);
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            LayoutPagesParams param = (LayoutPagesParams)pageParams;

            if (wizard is DashboardCreationWizard)
            {
                Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.LayoutDialog layoutDialog = new Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.LayoutDialog(CoreManager.MomConsole, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout, Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.LayoutDialog.Strings.DialogTitle);
                //Add retry to select layout
                int i = 0;
                Utilities.LogMessage("Select Layout....");

                while (!layoutDialog.Controls.SpecifyTheLayoutOfTheDashboardComboBox.SelectedIndex.ToString().Contains(param.LayoutIndex.ToString()) && i < 10)
                {
                    try
                   {
                        i++;
                        layoutDialog.Controls.SpecifyTheLayoutOfTheDashboardComboBox.SelectByIndex(param.LayoutIndex);
                        Utilities.LogMessage("Retry to select layout..." + i);
                        Maui.Core.Utilities.Sleeper.Delay(1000);

                    }
                    catch (Exception e)
                    {
                        Utilities.LogMessage("Fail to select layout " + e.ToString());
                    }


                }
                layoutDialog.SelectLayoutTemplateItem(param.layoutTemplate);
                layoutDialog.ClickNext();
            }
            else if (wizard is DashboardConfigurationWizard)
            {
                Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.LayoutDialog layoutDialog = new Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.LayoutDialog(CoreManager.MomConsole, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout, Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.LayoutDialog.Strings.DialogTitleUpdateDialog);
                layoutDialog.SelectLayoutTemplateItem(param.layoutTemplate);
                layoutDialog.ClickFinish();
            }
        }

        public bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public string TemplateLocName
        {
            get 
            {
                return this.templateLocName;
            }
        }

        public struct LayoutPagesParams : ICustomPageParams
        {
            public int LayoutIndex;
            public string layoutTemplate;
        }
    }
}