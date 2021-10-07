// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   class TemplateB
// </summary>
// <history>
//   [v-vijia] 1/31/2011 Created
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
    using Mom.Test.UI.Core.Common;
	
	    /// <summary>
    /// TODO;
    /// </summary>
    public class TemplateB : ITemplate
    {
        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public bool VerifyCustomSettings(Window parentWindow, ICustomPageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public string TemplateLocName
        {
            get { throw new NotImplementedException(); }
        }

        public struct CustomPagesParams : ICustomPageParams
        {
            public string MessageValue;
            public string Part2;
        }
    }
}