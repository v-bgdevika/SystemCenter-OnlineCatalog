// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DashboardConfigurationWizard.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <summary>
//   Class for Dashboard Configuration Wizard.
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
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using Mom.Test.UI.Core.ResourceLoader;
    using Mom.Test.UI.Core.Common;
    using System.Reflection;
	
	public class DashboardConfigurationWizard : DashboardWizardBase
    {
        [Resource(ID = "UpdateInstanceWizardTitle")]
        private string wizardTitle;

        public DashboardConfigurationWizard()
            : base()
        { }

        #region Common gauges in the wizard

        private Dialogs.GeneralPropertiesPage cachedGeneralPage = null;
        public Dialogs.GeneralPropertiesPage GeneralPropertiesPage
        {
            get
            {
                if (cachedGeneralPage == null)
                {
                    cachedGeneralPage = new Dialogs.GeneralPropertiesPage(CoreManager.MomConsole, Common.Constants.DefaultDialogTimeout, WizardTitle);
                }
                return cachedGeneralPage;
            }
        }

        private Dialogs.CompletionPage cachedCompletionPage = null;
        public Dialogs.CompletionPage CompletionPage
        {
            get
            {
                if (cachedCompletionPage == null)
                {
                    cachedCompletionPage = new Dialogs.CompletionPage(CoreManager.MomConsole, Common.Constants.DefaultDialogTimeout, WizardTitle);
                }
                return cachedCompletionPage;
            }
        }

        #endregion

        public static DashboardConfigurationWizard Launch(string dashboardInstanceName)
        {
            CoreManager.MomConsole.NavigationPane.SelectNode(dashboardInstanceName, NavigationPane.NavigationTreeView.Monitoring);
            Button configurationButton = null;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    configurationButton = new Button(CoreManager.MomConsole.ViewPane, Dashboard.ControlQIDs.taskHostQID, Dashboard.DefaultTimeout);
                    break;
                case ProductSkuLevel.Web:                    
                    configurationButton = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='button'"), Dashboard.DefaultTimeout);
                    break;
                default:
                    break;
            }
            return Launch(configurationButton);
        }

        public static DashboardConfigurationWizard Launch(Button configurationButton)
        {
            configurationButton.ScreenElement.LeftButtonClick(-1, -1);
            //wait for 3 seconds for context menu enable
            Sleeper.Delay(3000);
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.Configure);
            try
            {
                Core.Console.Dialogs.SystemCenterErrorDialog errorDialog = new Core.Console.Dialogs.SystemCenterErrorDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                errorDialog.ClickClose();
                CoreManager.MomConsole.Waiters.WaitForWindowClose(errorDialog, Constants.DefaultDialogTimeout);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("Not found Error dialog, ingore it");
            }

            return new DashboardConfigurationWizard();
        }

        public override void SettingWizard(DashboardParams settings)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            Template = settings.Template;
            if (Template != null)
                this.CustomPagesHandler = new CustomPagesHandler(this.Template.SettingWizardCustomPages);

            #region  General page
            this.GeneralPropertiesPage.WaitForResponse();

            if (settings.Name != null)
            {
                DeleteAllText(this.GeneralPropertiesPage.Controls.NameTextBox);
                Utilities.LogMessage(currentMethodName+":: Set name "+settings.Name);
                // In Maui 4.0, set text for textbox on New Dashboard and Widget Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                this.GeneralPropertiesPage.Controls.NameTextBox.SendKeys(settings.Name);
            }

            if (settings.Description != null)
            {
                DeleteAllText(this.GeneralPropertiesPage .Controls.DescriptionTextBox);
                Utilities.LogMessage(currentMethodName+":: Set description "+settings.Description);
                // In Maui 4.0, set text for textbox on New Dashboard and Widget Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                this.GeneralPropertiesPage.Controls.DescriptionTextBox.SendKeys(settings.Description);
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
             GeneralPropertiesPage.Controls.NextButton,
             2000);
            GeneralPropertiesPage.Controls.NextButton.Click();
            #endregion

            #region  Custom instance Properties Page

            if (this.CustomPagesHandler != null)
                CustomPagesHandler(this, settings.CustomPageParams);

            #endregion

            #region Completion page
            try
            {
                this.CompletionPage.WaitForResponse();
                CoreManager.MomConsole.Waiters.WaitForWindowClose(CompletionPage, 60000 * 8);  //extend try times from 3 to 8 for workarround bug 371378
            }
            catch (Exception e)
            {
                Utilities.LogMessage(currentMethodName+":: Skip Completion Page "); // workarround for the bug
            }
            #endregion

            CoreManager.MomConsole.Waiters.WaitForReady();
            CoreManager.MomConsole.BringToForeground();
        }

        private static void DeleteAllText(TextBox textbox)
        {
            if (textbox == null)
            {
                throw new ArgumentNullException("textbox");
            }

            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            Utilities.LogMessage(currentMethodName+":: Delete all text "+textbox.Text+" in textobx "+textbox.Caption);
            while (textbox.Text.Length !=0)
            {
                textbox.SendKeys(Core.Common.KeyboardCodes.Delete);
            }
        }

        public override string WizardTitle
        {
            get { return this.wizardTitle; }
        }
    }
}
