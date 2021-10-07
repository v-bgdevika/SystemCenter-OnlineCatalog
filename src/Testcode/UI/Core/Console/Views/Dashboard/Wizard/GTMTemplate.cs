// -----------------------------------------------------------------------------
// <copyright file="GTMTemplate.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation 2011
// </copyright>
//
// <summary>
// Interface exposing the methods that will be implemented for Testing GTMTemplate Dashboard view 
// in MOMv3 Console.  
// </summary>
// 
// <note>
// 
// </note>
// 
// <history>
//		[v-johnx]	1JU11	Created.
// </history>
// -----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion


    public class GTMTemplate : ITemplate
    {
        #region ITemplate Members

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            //TODO
        }

        public bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams)
        {
            bool isPass = false;
            return isPass;
            //TODO
        }

        public string TemplateLocName
        {
            get { return "Summary Dashboard"; }
        }

        #endregion
    }
}
