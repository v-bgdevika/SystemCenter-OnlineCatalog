// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   IT Pro Dashboards
// </project>
// <summary>
//   Base class of Template
// </summary>
// <history>
//   [v-dayow] 7/30/2010 Created
//   [v-lileo] 1/6/2011 Add an AlertConfig class
//   [v-vijia] 1/31/2011 Split classes TemplateA, TemplateB, TemplateFlowLayoutDashboard and TemplateGridLayoutDashboard to specific files.
//   [v-kantao] 3/1/2011 Split class PerformanceChart to TemplatePerformancheChart.cs
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.Dialogs;
    using System.Linq;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using MomAlertComponent = Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
    using System.Reflection;

    using Mom.Test.UI.Core.Console.Views.PerformanceChart;
    using MomConsole = Mom.Test.UI.Core.Console;

    public interface ICustomPageParams
    { }

    public interface ITemplate
    {
        void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams);

        bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams);

        string TemplateLocName { get; }
    }


}
