// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ChooseMonitoringTemplate.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ravipr] 16-Aug-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Templates
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IChooseMonitoringTemplateControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IChooseMonitoringTemplateControls, for ChooseMonitoringTemplate.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ravipr] 16-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IChooseMonitoringTemplateControls
    {
        /// <summary>
        /// Read-only property to access TextBox3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectATemplateTypeBelowTreeView
        /// </summary>
        TreeView SelectATemplateTypeBelowTreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectATemplateTypeBelowStaticControl
        /// </summary>
        StaticControl SelectATemplateTypeBelowStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BackButton
        /// </summary>
        Button BackButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseAMonitoringTemplateStaticControl
        /// </summary>
        StaticControl ChooseAMonitoringTemplateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl
        /// </summary>
        StaticControl YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[ravipr] 16-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ChooseMonitoringTemplate : Dialog, IChooseMonitoringTemplateControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TextBox3 of type TextBox
        /// </summary>
        private TextBox cachedTextBox3;
        
        /// <summary>
        /// Cache to hold a reference to SelectATemplateTypeBelowTreeView of type TreeView
        /// </summary>
        private TreeView cachedSelectATemplateTypeBelowTreeView;
        
        /// <summary>
        /// Cache to hold a reference to SelectATemplateTypeBelowStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectATemplateTypeBelowStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to BackButton of type Button
        /// </summary>
        private Button cachedBackButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ChooseAMonitoringTemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseAMonitoringTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ChooseMonitoringTemplate of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ChooseMonitoringTemplate(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IChooseMonitoringTemplate Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IChooseMonitoringTemplateControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox3Text
        {
            get
            {
                return this.Controls.TextBox3.Text;
            }
            
            set
            {
                this.Controls.TextBox3.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox3 control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IChooseMonitoringTemplateControls.TextBox3
        {
            get
            {
                if ((this.cachedTextBox3 == null))
                {
                    this.cachedTextBox3 = new TextBox(this, ChooseMonitoringTemplate.ControlIDs.TextBox3);
                }
                return this.cachedTextBox3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectATemplateTypeBelowTreeView control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IChooseMonitoringTemplateControls.SelectATemplateTypeBelowTreeView
        {
            get
            {
                if ((this.cachedSelectATemplateTypeBelowTreeView == null))
                {
                    //Window tempTree = new Window("Select a template type below", StringMatchSyntax.WildCard);

                    this.cachedSelectATemplateTypeBelowTreeView = new TreeView(this, ChooseMonitoringTemplate.ControlIDs.SelectATemplateTypeBelowTreeView);
                  //  this.cachedSelectATemplateTypeBelowTreeView = new TreeView(tempTree, ChooseMonitoringTemplate.ControlIDs.SelectATemplateTypeBelowTreeView);
                }
                return this.cachedSelectATemplateTypeBelowTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectATemplateTypeBelowStaticControl control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseMonitoringTemplateControls.SelectATemplateTypeBelowStaticControl
        {
            get
            {
                if ((this.cachedSelectATemplateTypeBelowStaticControl == null))
                {
                    this.cachedSelectATemplateTypeBelowStaticControl = new StaticControl(this, ChooseMonitoringTemplate.ControlIDs.SelectATemplateTypeBelowStaticControl);
                }
                return this.cachedSelectATemplateTypeBelowStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseMonitoringTemplateControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ChooseMonitoringTemplate.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseMonitoringTemplateControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, ChooseMonitoringTemplate.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BackButton control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseMonitoringTemplateControls.BackButton
        {
            get
            {
                if ((this.cachedBackButton == null))
                {
                    this.cachedBackButton = new Button(this, ChooseMonitoringTemplate.ControlIDs.BackButton);
                }
                return this.cachedBackButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseMonitoringTemplateControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ChooseMonitoringTemplate.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseMonitoringTemplateControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ChooseMonitoringTemplate.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseAMonitoringTemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseMonitoringTemplateControls.ChooseAMonitoringTemplateStaticControl
        {
            get
            {
                if ((this.cachedChooseAMonitoringTemplateStaticControl == null))
                {
                    this.cachedChooseAMonitoringTemplateStaticControl = new StaticControl(this, ChooseMonitoringTemplate.ControlIDs.ChooseAMonitoringTemplateStaticControl);
                }
                return this.cachedChooseAMonitoringTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl control
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseMonitoringTemplateControls.YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl
        {
            get
            {
                if ((this.cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl == null))
                {
                    this.cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl = new StaticControl(this, ChooseMonitoringTemplate.ControlIDs.YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl);
                }
                return this.cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Back
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBack()
        {
            this.Controls.BackButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8 , StringMatchSyntax.WildCard, app, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException ex)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                   //     tempWindow =
                   //         new Window(
                   //             app.GetIntlStr(Strings.DialogTitle) + "*",
                   //             StringMatchSyntax.WildCard);

                     tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.WildCard, app, Timeout);
                               
                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                        tempWindow.Extended.SetFocus();
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                       
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains resource string for: Launch Monitor an Application Wizard 
            /// </summary>
            private const string ResourceLaunchApplicationWizard =
                ";Launch Monitor an Application Wizard;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Monitoring.Commands.CommandResources;ApplicationMonitoringWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "Monitor an Application Wizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectATemplateTypeBelow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectATemplateTypeBelow = ";S&elect a template type below:;ManagedString;Microsoft.MOM.UI.Components.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Wizards.MonitorAppWizard.TemplateLis" +
                "tPage;chooseRuleTypeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";&Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.M" +
                "om.Internal.UI.PageFrameworks.WizardFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Back
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBack = ";< &Back;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonBack.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseAMonitoringTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseAMonitoringTemplate = ";Choose a Monitoring Template;ManagedString;Microsoft.MOM.UI.Components.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Wizards.MonitorAppWizard.TemplateListP" +
                "age;$this.Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent = ";You can choose a template to set up monitoring for an application or component.;" +
                "ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom" +
                ".Internal.UI.Wizards.MonitorAppWizard.TemplateListPage;$this.Subtitle";

            /// <summary>
            /// Contains GUID for: System.Windows.Service.Template 
            /// </summary>            
            private const string GUIDWindowsServiceTemplate = "AF172B63-2D46-CDB8-21C1-0FEB2F922909";

            /// <summary>
            /// Contains GUID for: Microsoft.Mom.WebPage.Template 
            /// </summary>            
            private const string GUIDWebPageTemplate = "75AD3477-1759-8307-C96D-1367CE1AB6A2";

            /// <summary>
            /// Contains GUID for: System.Mom.InstanceGroup.Template 
            /// </summary>            
            private const string GUIDInstanceGroupTemplate = "19C5852A-D89C-BF1E-B2FA-854805CFAFC4";

            /// <summary>
            /// Contains GUID for: Microsoft.Mom.HttpUrlMonitoring.Template 
            /// </summary>            
            private const string GUIDHttpUrlMonitoringTemplate = "BACBB9DD-D9D5-B1F3-D3F9-C23478CFD20F";

            /// <summary>
            /// Contains GUID for: System.Windows.Service.SharedProcess.Template 
            /// </summary>            
            private const string GUIDWindowsServiceSharedProcessTemplate = "F94455AE-BB9D-2DC4-75CE-D3C0CDC3DAE7";

            #endregion
            
            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Launch Monitor an Application Wizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLaunchApplicationWizard;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectATemplateTypeBelow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectATemplateTypeBelow;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Back
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseAMonitoringTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseAMonitoringTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.Service.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsServiceTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.Mom.WebPage.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Mom.InstanceGroup.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstanceGroupTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.Mom.HttpUrlMonitoring.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttpUrlMonitoringTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.Service.SharedProcess.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsServiceSharedProcessTemplate;

            #endregion
            
            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Launch Monitor an Application Wizard 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 28JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LaunchApplicationWizard
            {
                get
                {
                    if ((cachedLaunchApplicationWizard == null))
                    {
                        cachedLaunchApplicationWizard = CoreManager.MomConsole.GetIntlStr(ResourceLaunchApplicationWizard);
                    }

                    return cachedLaunchApplicationWizard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectATemplateTypeBelow translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectATemplateTypeBelow
            {
                get
                {
                    if ((cachedSelectATemplateTypeBelow == null))
                    {
                        cachedSelectATemplateTypeBelow = CoreManager.MomConsole.GetIntlStr(ResourceSelectATemplateTypeBelow);
                    }
                    return cachedSelectATemplateTypeBelow;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Back translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Back
            {
                get
                {
                    if ((cachedBack == null))
                    {
                        cachedBack = CoreManager.MomConsole.GetIntlStr(ResourceBack);
                    }
                    return cachedBack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseAMonitoringTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseAMonitoringTemplate
            {
                get
                {
                    if ((cachedChooseAMonitoringTemplate == null))
                    {
                        cachedChooseAMonitoringTemplate = CoreManager.MomConsole.GetIntlStr(ResourceChooseAMonitoringTemplate);
                    }
                    return cachedChooseAMonitoringTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent
            {
                get
                {
                    if ((cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent == null))
                    {
                        cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent = CoreManager.MomConsole.GetIntlStr(ResourceYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent);
                    }
                    return cachedYouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponent;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.Service.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsServiceTemplate
            {
                get
                {
                    if ((cachedWindowsServiceTemplate == null))
                    {
                        cachedWindowsServiceTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDWindowsServiceTemplate);
                    }

                    return cachedWindowsServiceTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.Mom.WebPage.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageTemplate
            {
                get
                {
                    if ((cachedWebPageTemplate == null))
                    {
                        cachedWebPageTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDWebPageTemplate);
                    }

                    return cachedWebPageTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Mom.InstanceGroup.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstanceGroupTemplate
            {
                get
                {
                    if ((cachedInstanceGroupTemplate == null))
                    {
                        cachedInstanceGroupTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDInstanceGroupTemplate);
                    }

                    return cachedInstanceGroupTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.Mom.HttpUrlMonitoring.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HttpUrlMonitoringTemplate
            {
                get
                {
                    if ((cachedHttpUrlMonitoringTemplate == null))
                    {
                        cachedHttpUrlMonitoringTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDHttpUrlMonitoringTemplate);
                    }

                    return cachedHttpUrlMonitoringTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.Service.SharedProcess.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsServiceSharedProcessTemplate
            {
                get
                {
                    if ((cachedWindowsServiceSharedProcessTemplate == null))
                    {
                        cachedWindowsServiceSharedProcessTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDWindowsServiceSharedProcessTemplate);
                    }

                    return cachedWindowsServiceSharedProcessTemplate;
                }
            }

            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ravipr] 16-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TextBox3
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox3 = "descriptionBox";
            
            /// <summary>
            /// Control ID for SelectATemplateTypeBelowTreeView
            /// </summary>
            public const string SelectATemplateTypeBelowTreeView = "templatesTreeView";
            
            /// <summary>
            /// Control ID for SelectATemplateTypeBelowStaticControl
            /// </summary>
            public const string SelectATemplateTypeBelowStaticControl = "chooseRuleTypeLabel";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "buttonFinish";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "buttonHelp";
            
            /// <summary>
            /// Control ID for BackButton
            /// </summary>
            public const string BackButton = "buttonBack";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "buttonNext";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for ChooseAMonitoringTemplateStaticControl
            /// </summary>
            public const string ChooseAMonitoringTemplateStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl
            /// </summary>
            public const string YouCanChooseATemplateToSetUpMonitoringForAnApplicationOrComponentStaticControl = "labelSubtitle";
        }
        #endregion
    }
}
