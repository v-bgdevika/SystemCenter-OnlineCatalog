// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   class TemplateGridLayoutDashboard
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



    public class TemplateFlowLayoutDashboard : ITemplate
    {
        [Resource(ID = "FlowLayout")]
        private string templateLocName;

        public TemplateFlowLayoutDashboard()
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            XDocument dashboardWizardDocument = ResourceLoader.GetDefaultResourceFile("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.DashboardWizardResource.xml");
            XElement templateSection = ResourceLoader.GetSection("TemplateComponent", dashboardWizardDocument);
            ResourceLoader.LoadResources(this, templateSection);
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            ColumnCountPagesParams param = (ColumnCountPagesParams)pageParams;

            if (wizard is DashboardCreationWizard)
            {
                Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.ColumnCountDialog columnCountDialog = new MomControls.Dashboards.Dialogs.ColumnCountDialog(CoreManager.MomConsole, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout, Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.ColumnCountDialog.Strings.DialogTitle);
                columnCountDialog.ColumnCountText = param.ColumnCount.ToString();
                columnCountDialog.ClickNext();
            }
            else if (wizard is DashboardConfigurationWizard)
            {
                Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.ColumnCountDialog columnCountDialog = new MomControls.Dashboards.Dialogs.ColumnCountDialog(CoreManager.MomConsole, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout, Mom.Test.UI.Core.Console.MomControls.Dashboards.Dialogs.ColumnCountDialog.Strings.DialogTitleUpdateDialog);
                columnCountDialog.ColumnCountText = param.ColumnCount.ToString();
                Utilities.TakeScreenshot("TemplateFlowLayoutDashboard.UpdateColumns");
                columnCountDialog.ClickFinish();
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

        public struct ColumnCountPagesParams : ICustomPageParams
        {
            public int ColumnCount;
        }
    }
}