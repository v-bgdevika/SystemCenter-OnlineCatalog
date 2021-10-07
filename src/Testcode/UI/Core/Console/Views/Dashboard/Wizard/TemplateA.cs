// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   class TemplateA
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

    public class TemplateA : ITemplate
    {
        public string TemplateLocName
        {
            // this is test data from the Layout.Test.mp and not localized
            get { return "Template A"; }
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            if (pageParams == null || wizard == null)
                return;

            CustomPagesParams parmas = (CustomPagesParams)pageParams;

            if (wizard is DashboardCreationWizard)
            {
                #region Scoping page
                ScopingPage ScopingPage = new ScopingPage(
                    CoreManager.MomConsole,
                    2000,
                    wizard.WizardTitle);

                Utilities.LogMessage("Template A - Scoping page");

                ScopingPage.WaitForResponse();
                ScopingPage.ScreenElement.BringUp();

                try
                {
                    if (parmas.MessageValue != null)
                        // In Maui 4.0, set text for textbox on New Instance Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                        ScopingPage.Controls.MessageValueTextBox.SendKeys(parmas.MessageValue);
                    if (parmas.Part1 != null)
                        // In Maui 4.0, set text for textbox on New Instance Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                        ScopingPage.Controls.Part1TextBox.SendKeys(parmas.Part1);
                    if (parmas.Part2 != null)
                        // In Maui 4.0, set text for textbox on New Instance Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                        ScopingPage.Controls.Part2TextBox.SendKeys(parmas.Part2);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                {
                    //Work around product bug 223132
                    Utilities.LogMessage("Hit Exception := " + ex.ToString());
                }                


                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                ScopingPage.Controls.NextButton,
                2000);
                ScopingPage.Controls.NextButton.Click();
                #endregion
            }
            else if (wizard is DashboardConfigurationWizard)
            {
                #region Scoping page
                ScopingPage ScopingPage = new ScopingPage(
                    CoreManager.MomConsole,
                    2000,
                    wizard.WizardTitle);

                Utilities.LogMessage("Template A - Scoping page");

                ScopingPage.WaitForResponse();
                ScopingPage.ScreenElement.BringUp();

                try
                {
                    if (parmas.MessageValue != null)
                        // In Maui 4.0, set text for textbox on New Instance Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                        ScopingPage.Controls.MessageValueTextBox.SendKeys(parmas.MessageValue);
                    if (parmas.Part1 != null)
                        // In Maui 4.0, set text for textbox on New Instance Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                        ScopingPage.Controls.Part1TextBox.SendKeys(parmas.Part1);
                    if (parmas.Part2 != null)
                        // In Maui 4.0, set text for textbox on New Instance Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                        ScopingPage.Controls.Part2TextBox.SendKeys(parmas.Part2);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                {
                    //Work around product bug 223132
                    Utilities.LogMessage("Hit Exception := " + ex.ToString());
                }                  


                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                ScopingPage.Controls.FinishButton,
                2000);
                ScopingPage.Controls.FinishButton.Click();
                #endregion
            }
            else if (wizard is DashboardPersonalizationWizard)
            {
                #region Scoping page
                ScopingPage ScopingPage = new ScopingPage(
                    CoreManager.MomConsole,
                    2000,
                    wizard.WizardTitle);

                Utilities.LogMessage("Template A - Scoping page");

                ScopingPage.WaitForResponse();
                ScopingPage.ScreenElement.BringUp();

                if (parmas.MessageValue != null)
                    ScopingPage.Controls.MessageValueTextBox.SendKeys(parmas.MessageValue);//ScopingPage.MessageValueText = parmas.MessageValue;

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                ScopingPage.Controls.FinishButton,
                2000);
                int retrytimes = 0;
                int maxretry = Constants.DefaultMaxRetry;
                while (retrytimes < maxretry)
                {
                    retrytimes++;
                    try
                    {
                        if (ScopingPage.Controls.FinishButton.IsEnabled)
                        {
                            Utilities.TakeScreenshot("Before click Save button");
                            ScopingPage.Controls.FinishButton.Click();
                            Sleeper.Delay(Constants.TenSeconds);
                            Utilities.TakeScreenshot("After click Save button");
                            break;
                        }
                        else
                        {
                            Sleeper.Delay(Constants.TenSeconds);
                        }
                    }
                    catch(Exception ex)
                    {
                        Utilities.LogMessage(ex.ToString());
                        Sleeper.Delay(Constants.TenSeconds);
                    }
                    
                }
                //wait for Scoping page close
                int i = 0;
                try
                {
                    while (ScopingPage.IsVisible && i < Constants.DefaultMaxRetry)
                    {
                        i++;
                        Sleeper.Delay(Constants.OneMinute);
                        if (i == Constants.DefaultMaxRetry && ScopingPage.IsVisible)
                        {
                            Utilities.LogMessage("Scoping page still not close after 5 minutes");
                        }
                    }
                }
                catch
                {
                    Sleeper.Delay(Constants.TenSeconds);
                }
                //ScopingPage.Controls.FinishButton.Click();
                #endregion
            }
        }

        public bool VerifyCustomSettings(Window parentWindow, ICustomPageParams pageParams)
        {
            if (parentWindow == null || pageParams == null)
                throw new System.ArgumentNullException();

            CustomPagesParams param = (CustomPagesParams)pageParams;

            CoreManager.MomConsole.Waiters.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForWindowReady(parentWindow, ConsoleConstants.DefaultWaitForReadyTimeout);

            string actualMessageValue = new TextBox(parentWindow, new QID(";[UIA]AutomationId='lblMessage'")).Text;
            string actualPart1 = new TextBox(parentWindow, new QID(";[UIA]AutomationId='lblMessagePart1'")).Text;
            string actualPart2 = new TextBox(parentWindow, new QID(";[UIA]AutomationId='lblMessagePart2'")).Text;
            Utilities.LogMessage("Actual message value is: " + actualMessageValue);
            Utilities.LogMessage("Parameters message value is: " + param.MessageValue);
            Utilities.LogMessage("Actual part1 value is: " + actualPart1);
            Utilities.LogMessage("Parameters part1 value is: " + param.Part1);
            Utilities.LogMessage("Actual part2 value is: " + actualPart2);
            Utilities.LogMessage("Parameters part2 value is: " + param.Part2);
            if (param.MessageValue != actualMessageValue ||
                param.Part1 != actualPart1 ||
                param.Part2 != actualPart2)
                return false;
            else
                return true;
        }

        public struct CustomPagesParams : ICustomPageParams
        {
            public string MessageValue;
            public string Part1;
            public string Part2;
        }
    }
}