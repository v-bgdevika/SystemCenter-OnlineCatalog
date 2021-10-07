// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceNameDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 3/3/2006 Created
//  [faizalk] 4/17/2006 Update to use resource string for dialog title
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;

    #region Interface Definition - IServiceNameDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceNameDialogControls, for ServiceNameDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceNameDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access ComponentTypeStaticControl
        /// </summary>
        StaticControl ComponentTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServiceNameStaticControl
        /// </summary>
        StaticControl ServiceNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServiceNameStaticControl2
        /// </summary>
        StaticControl ServiceNameStaticControl2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServiceNameStaticControl3
        /// </summary>
        StaticControl ServiceNameStaticControl3
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServiceNameTextBox
        /// </summary>
        TextBox ServiceNameTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button BrowseButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl
        /// </summary>
        StaticControl EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl
        {
            get;
        }        

        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServiceNameStaticControl4
        /// </summary>
        StaticControl ServiceNameStaticControl4
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
    /// 	[ruhim] 3/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceNameDialog : Dialog, IServiceNameDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to ComponentTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComponentTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to ServiceNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;

        /// <summary>
        /// Cache to hold a reference to ServiceNameStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedServiceNameStaticControl2;

        /// <summary>
        /// Cache to hold a reference to ServiceNameStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedServiceNameStaticControl3;

        /// <summary>
        /// Cache to hold a reference to ServiceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceNameTextBox;

        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;

        /// <summary>
        /// Cache to hold a reference to EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl;        

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to ServiceNameStaticControl4 of type StaticControl
        /// </summary>
        private StaticControl cachedServiceNameStaticControl4;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceNameDialog of type App
        /// </param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceNameDialog(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);  
        }
        #endregion

        #region IServiceNameDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceNameDialogControls Controls
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
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceNameText
        {
            get
            {
                return this.Controls.ServiceNameTextBox.Text;
            }

            set
            {
                this.Controls.ServiceNameTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceNameDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ServiceNameDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceNameDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ServiceNameDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceNameDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ServiceNameDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceNameDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceNameDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComponentTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.ComponentTypeStaticControl
        {
            get
            {
                if ((this.cachedComponentTypeStaticControl == null))
                {
                    this.cachedComponentTypeStaticControl = new StaticControl(this, ServiceNameDialog.ControlIDs.ComponentTypeStaticControl);
                }
                return this.cachedComponentTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.ServiceNameStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedServiceNameStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedServiceNameStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedServiceNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.ServiceNameStaticControl2
        {
            get
            {
                if ((this.cachedServiceNameStaticControl2 == null))
                {
                    this.cachedServiceNameStaticControl2 = new StaticControl(this, ServiceNameDialog.ControlIDs.ServiceNameStaticControl2);
                }
                return this.cachedServiceNameStaticControl2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.ServiceNameStaticControl3
        {
            get
            {
                if ((this.cachedServiceNameStaticControl3 == null))
                {
                    this.cachedServiceNameStaticControl3 = new StaticControl(this, ServiceNameDialog.ControlIDs.ServiceNameStaticControl3);
                }
                return this.cachedServiceNameStaticControl3;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceNameDialogControls.ServiceNameTextBox
        {
            get
            {
                if ((this.cachedServiceNameTextBox == null))
                {
                    this.cachedServiceNameTextBox = new TextBox(this, ServiceNameDialog.ControlIDs.ServiceNameTextBox);
                }
                return this.cachedServiceNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceNameDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, ServiceNameDialog.ControlIDs.BrowseButton);
                }
                return this.cachedBrowseButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl
        {
            get
            {
                if ((this.cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl == null))
                {
                    this.cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl = new StaticControl(this, ServiceNameDialog.ControlIDs.EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl);
                }
                return this.cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl;
            }
        }               

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ServiceNameDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameStaticControl4 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNameDialogControls.ServiceNameStaticControl4
        {
            get
            {
                if ((this.cachedServiceNameStaticControl4 == null))
                {
                    this.cachedServiceNameStaticControl4 = new StaticControl(this, ServiceNameDialog.ControlIDs.ServiceNameStaticControl4);
                }
                return this.cachedServiceNameStaticControl4;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button BrowseButton
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowseButton()
        {
            this.Controls.BrowseButton.Click();
        }
                
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
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
                        DialogTitle + "'");

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
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComponentType = ";Component Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceName = ";Service Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ServiceStateProbePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceName2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceName2 = ";Service Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ServiceStateProbePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceName3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceName3 = ";&Service name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.ServiceStateProbePage;serviceNameLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser = ";Enter the name of the service you want to monitor or choose from a service brows" +
                "er.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement" +
                ".Internal.UI.Authoring.Pages.ServiceStateProbePage;infoLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceName4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceName4 = ";Service Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ServiceStateProbePage;$this.TabName";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComponentType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceName2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceName2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceName3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceName3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceName4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceName4;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    return cachedPrevious;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    return cachedCreate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the ComponentType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComponentType
            {
                get
                {
                    if ((cachedComponentType == null))
                    {
                        cachedComponentType = CoreManager.MomConsole.GetIntlStr(ResourceComponentType);
                    }
                    return cachedComponentType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceName
            {
                get
                {
                    if ((cachedServiceName == null))
                    {
                        cachedServiceName = CoreManager.MomConsole.GetIntlStr(ResourceServiceName);
                    }
                    return cachedServiceName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    return cachedGeneralProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceName2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceName2
            {
                get
                {
                    if ((cachedServiceName2 == null))
                    {
                        cachedServiceName2 = CoreManager.MomConsole.GetIntlStr(ResourceServiceName2);
                    }
                    return cachedServiceName2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceName3 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceName3
            {
                get
                {
                    if ((cachedServiceName3 == null))
                    {
                        cachedServiceName3 = CoreManager.MomConsole.GetIntlStr(ResourceServiceName3);
                    }
                    return cachedServiceName3;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser
            {
                get
                {
                    if ((cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser == null))
                    {
                        cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser = CoreManager.MomConsole.GetIntlStr(ResourceEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser);
                    }
                    return cachedEnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowser;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the ServiceName4 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceName4
            {
                get
                {
                    if ((cachedServiceName4 == null))
                    {
                        cachedServiceName4 = CoreManager.MomConsole.GetIntlStr(ResourceServiceName4);
                    }
                    return cachedServiceName4;
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
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";

            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for ComponentTypeStaticControl
            /// </summary>
            public const string ComponentTypeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ServiceNameStaticControl
            /// </summary>
            public const string ServiceNameStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ServiceNameStaticControl2
            /// </summary>
            public const string ServiceNameStaticControl2 = "pageSectionLabel1";

            /// <summary>
            /// Control ID for ServiceNameStaticControl3
            /// </summary>
            public const string ServiceNameStaticControl3 = "serviceNameLabel";

            /// <summary>
            /// Control ID for ServiceNameTextBox
            /// </summary>
            public const string ServiceNameTextBox = "serviceNameTextBox";

            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string BrowseButton = "browseButton";

            /// <summary>
            /// Control ID for EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl
            /// </summary>
            public const string EnterTheNameOfTheServiceYouWantToMonitorOrChooseFromAServiceBrowserStaticControl = "infoLabel";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for ServiceNameStaticControl4
            /// </summary>
            public const string ServiceNameStaticControl4 = "headerLabel";
        }
        #endregion
    }
}
