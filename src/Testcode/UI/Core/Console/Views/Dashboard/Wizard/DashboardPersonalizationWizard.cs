// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DashboardPersonalizationWizard.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <summary>
//   Class for Dashboard Personalization Wizard.
// </summary>
// <history>
//   [v-vijia] 1/31/2011 Created
// </history>
// ------------------------------------------------------------------------------

using Mom.Test.UI.Core.Console.MomControls;

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


    public class DashboardPersonalizationWizard : DashboardWizardBase
    {
        [Resource(ID = "PersonalizeWizardTitle")]
        private string wizardTitle;

        public DashboardPersonalizationWizard()
            : base()
        { }

        #region Common pages in the wizard
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

        public static DashboardPersonalizationWizard Launch(string dashboardInstanceName)
        {
            CoreManager.MomConsole.Waiters.WaitForReady();

            CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate() { return CoreManager.MomConsole.NavigationPane.NodeExists(dashboardInstanceName); });
            CoreManager.MomConsole.NavigationPane.SelectNode(dashboardInstanceName, NavigationPane.NavigationTreeView.Monitoring);


            return DashboardPersonalizationWizard.Launch(dashboardInstanceName, null);
        }

        public static DashboardPersonalizationWizard Launch(string dashboardInstanceName, Button personalizationButton)
        {
            if (personalizationButton == null)
            {
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        personalizationButton = new Button(CoreManager.MomConsole.ViewPane, new QID(";[UIA]AutomationId='button'"));                        break;
                    case ProductSkuLevel.Web:
                        personalizationButton = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='button'"));                        break;
                }                 
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(personalizationButton, Constants.DefaultContextMenuTimeout);
            personalizationButton.Click();
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.Personalize);
            Sleeper.Delay(2000);
            CoreManager.MomConsole.Waiters.WaitForReady();            

            return new DashboardPersonalizationWizard();
        }

        public void Revert()
        {
            string logHeader = MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader);

            string revertButton = Strings.RevertActionNameDisplayString;

            Utilities.LogMessage(logHeader + "Looking for the '" + revertButton + "' button on the Personalization wizard");
            Button revertBtn = new Button(this.WizardWindow, QueryIds.RevertButtonQID);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(revertBtn);

            Utilities.LogMessage(logHeader + "Now clicking the '" + revertButton + "' button");
            revertBtn.Click();

            Utilities.LogMessage(logHeader + "Confirming Personalization settings reverted");
            var revertToDefaultDialog = new Core.Console.Dialogs.RevertToDefaultsDialog(CoreManager.MomConsole);
            revertToDefaultDialog.ClickOK();

            Utilities.LogMessage(logHeader + "Done");
        }

        public override void SettingWizard(DashboardParams settings)
        {
            Template = settings.Template;
            if (Template != null)
            {
                this.CustomPagesHandler = new CustomPagesHandler(this.Template.SettingWizardCustomPages);
            }

            #region  Custom instance Properties Page

            if (CustomPagesHandler != null)
                CustomPagesHandler(this, settings.CustomPageParams);

            #endregion

            #region Completion page
            try
            {
                Utilities.TakeScreenshot("start CompletionPage.WaitForResponse() ....");
                this.CompletionPage.WaitForResponse();
                Sleeper.Delay(30000);  //wait for personalize window close
                Utilities.TakeScreenshot("start WaitForWindowClose ....");
                CoreManager.MomConsole.Waiters.WaitForWindowClose(CompletionPage, Constants.OneMinute * 3);
            }
            catch (Exception e)
            {
                Utilities.LogMessage("Exception:" + e.ToString());
                Utilities.LogMessage(" Skip Competion Page "); // workarround for the bug
            }
            #endregion

            CoreManager.MomConsole.Waiters.WaitForReady();
            CoreManager.MomConsole.BringToForeground();
            Utilities.TakeScreenshot("SettingWizard ....");
        }

        public override string WizardTitle
        {
            get { return this.wizardTitle; }
        }


        public class Strings
        {
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedRevertActionName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRevertActionName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Revert" button String
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string RevertActionNameDisplayString
            {
                get
                {
                    if ((cachedRevertActionName == null))
                    {
                        cachedRevertActionName =
                            MpResources.ConfigurationLibraryMp.GetLocalizedResource.RevertButtonName;
                    }

                    return cachedRevertActionName;
                }
            }

        } // end of Strings

        public class QueryIds
        {
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Cached Revert Button QID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedRevertButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Revert Button QID Resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static readonly string ResourceRevertButton = ";[UIA]Name='" + Strings.RevertActionNameDisplayString + "'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Revert Button QID
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID RevertButtonQID
            {
                get
                {
                    if(cachedRevertButton == null)
                    {
                        cachedRevertButton = new QID(ResourceRevertButton);
                    }
                    
                    return cachedRevertButton;
                }
            }
        } // end of QueryIds
    }

}
