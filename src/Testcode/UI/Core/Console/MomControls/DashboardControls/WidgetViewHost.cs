namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard;
    using Maui.Core.Utilities;
    using System.Threading;

    public interface IWidgetViewHost
    {
        /// <summary>
        /// The widget the view hosts
        /// </summary>
        Window Widget
        {
            get;
        }

        /// <summary>
        /// Indicates if there is widget hacked in view host
        /// </summary>
        bool HasWidget
        {
            get;
        }

        /// <summary>
        /// Method to move view host left
        /// </summary>
        void MoveViewLeft();

        /// <summary>
        /// Method to move view host right
        /// </summary>
        void MoveViewRight();

        /// <summary>
        /// Method to add widget
        /// </summary>
        void AddWidget(DashboardParams settings);

        /// <summary>
        /// Mehthod to configure widget
        /// </summary>
        void ConfigureWidget(string name, string description, ICustomPageParams param);

        /// <summary>
        /// Method to delete widget
        /// </summary>
        void DeleteWidget();
    }

    /// <summary>
    /// The class represents the view that has a widget as then content
    /// </summary>
    public class WidgetViewHost : ViewHost, IWidgetViewHost
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the WidgetViewHost class.
        /// </summary>
        /// <param name="knownWindow">Window that is the widget hosting view</param>
        public WidgetViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region QIDs

        /// <summary>
        /// Thic contains the default QIDs for the controls
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the Move left task button
            /// </summary>
            public static QID MoveLeftQID = new QID(";[UIA]Name='Swap with previous widget'");

            /// <summary>
            /// QID for the Move right task button
            /// </summary>
            public static QID MoveRightQID = new QID(";[UIA]Name='Swap with next widget'");

            /// <summary>
            /// QID for the Delete content task button
            /// <remarks>
            /// Due to in  grid layout dashboard, this button's Name is 'Clear Contents' and in flow layout dashboard is 'Delete Contents',
            /// so still use origianl qid to find the button.
            /// </remarks>
            /// </summary>
            public static QID DeleteContentQID = new QID(";[UIA]ClassName='Button' && Role='push button' && Instance='1'");

            /// <summary>
            /// QID for the Configuration task button
            /// </summary>
            public static QID ConfigurationQID = new QID(";[UIA]Name='Configure'");

            /// <summary>
            /// QID for the Personalization task button
            /// </summary>
            public static QID PersonalizationQID = new QID(";[UIA]Name='Personalize'");

            /// <summary>
            /// QID of Click to add widget link
            /// </summary>
            public static QID AddWidgetLinkQID = new QID(";[UIA]AutomationId='AddWidgetButton'"); //Bug#203047: Use 'AddWidgetButton' instead of 'AddWidgetText' to find the Add widget link.
        }

        /// <summary>
        /// Gets the QID of Move left task button
        /// </summary>
        /// <returns>QID for the Move left task button</returns>
        protected virtual QID GetMoveLeftQID()
        {
            return ControlQIDs.MoveLeftQID;
        }

        /// <summary>
        /// Gets the QID of Move right task button
        /// </summary>
        /// <returns>QID for the Move right task buton</returns>
        protected virtual QID GetMoveRightQID()
        {
            return ControlQIDs.MoveRightQID;
        }

        /// <summary>
        /// Gets the QID of Delete content task button
        /// Delete button of Grid Layout dashboard.
        /// </summary>
        /// <returns>QID for the Delete content task button</returns>
        protected virtual QID GetDeleteContentQID()
        {
            return ControlQIDs.DeleteContentQID;
        }

        /// <summary>
        /// Gets the QID of Configuration task button
        /// </summary>
        /// <returns>QID for the Configuration task button</returns>
        protected virtual QID GetConfigurationQID()
        {
            return ControlQIDs.ConfigurationQID;
        }

        /// <summary>
        /// Gets the QID of Personalization task button
        /// </summary>
        /// <returns>QID for the Personalization task button</returns>
        protected virtual QID GetPersonalizationQID()
        {
            return ControlQIDs.PersonalizationQID;
        }

        /// <summary>
        /// Gets the QID of Click to add widget link
        /// </summary>
        /// <returns>QID for Click to add widget link</returns>
        protected virtual QID GetAddWidgetLinkQID()
        {
            return ControlQIDs.AddWidgetLinkQID;
        }

        #endregion

        #region private variables



        /// <summary>
        /// Used in latching on to the inner controls
        /// </summary>
        private const int TIME_OUT = MomCommon.Constants.OneSecond * 5;

        /// <summary>
        /// The Move left task button control
        /// </summary>
        private Button moveLeftButton;

        /// <summary>
        /// The Move right task button control
        /// </summary>
        private Button moveRightButton;

        /// <summary>
        /// The Delete content task button control
        /// </summary>
        private Button deleteContentButton;

        /// <summary>
        /// The DropDown task button control
        /// </summary>
        private Button dropDownButton;

        protected Button DropDownButton
        {
            get
            {
                if (this.dropDownButton==null)
                {
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            this.dropDownButton = new Button(this, new QID(";[UIA]AutomationId='TaskHostButton'"), TIME_OUT);
                            break;
                        case ProductSkuLevel.Web:
                            this.dropDownButton = new Button(this, new QID(";[UIA]AutomationId='button'"), TIME_OUT);
                            break;
                    } 
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.dropDownButton, Constants.DefaultContextMenuTimeout);
                return this.dropDownButton;
            }
        }
        
        /// <summary>
        /// The Configuration task button control
        /// </summary>
        private Button configurationButton;

        protected Button ConfigurationButton
        {
            get {
                if (this.configurationButton == null)
                {
                    this.configurationButton = new Button(
                        new Window(
                            this,
                            this.GetConfigurationQID(),
                            TIME_OUT));
                } 
                return this.configurationButton;
            }
            set { this.configurationButton = value; }
        }

        /// <summary>
        /// The Personalization task button control
        /// </summary>
        private Button personalizationButton;

        protected Button PersonalizationButton
        {
            get
            {
                if (this.personalizationButton == null)
                {
                    this.personalizationButton = new Button(
                        new Window(
                            this,
                            this.GetPersonalizationQID(),
                            TIME_OUT));
                }
                return this.personalizationButton;
            }
            set { this.personalizationButton = value; }
        }

        /// <summary>
        /// The add widget link control
        /// </summary>
        private Button addWidgetLink;

        /// <summary>
        /// Widget type
        /// </summary>
        private string widgetType;

        #endregion

        #region IWidgetViewHost Members

        /// <summary>
        /// The widget as the content of the view
        /// </summary>
        public Window Widget
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Indicates if there is widget hacked in view host
        /// </summary>
        public bool HasWidget
        {
            get
            {
                try
                {
                    Button addWidgetLink = new Button(this,
                        this.GetAddWidgetLinkQID(),
                        TIME_OUT);
                    if (addWidgetLink == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    // No personalizeButton found, which means it's a view host with widget
                    return true;
                }
            }
        }

        /// <summary>
        /// Indicates which type of widget the view hosts
        /// </summary>
        public string WidgetType
        {
            get
            {
                if (!this.HasWidget)
                {
                    return WidgetTypes.NoWidget;
                }
                else
                {
                    return this.widgetType;
                }
            }
            set
            {
                this.widgetType = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to move the widget view host left
        /// </summary>
        public void MoveViewLeft()
        {
            this.DropDownButton.ScreenElement.LeftButtonClick(-1, -1);
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.SwapWithPreviousWidget);
            this.WaitForReady();
        }

        /// <summary>
        /// Method to move the widget view host right
        /// </summary>
        public void MoveViewRight()
        {
            this.DropDownButton.ScreenElement.LeftButtonClick(-1, -1);
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.SwapWithNextWidget);
            this.WaitForReady();
        }

        /// <summary>
        /// Method to delete the widget from the view host
        /// </summary>
        public void DeleteWidget()
        {
            this.DropDownButton.ScreenElement.LeftButtonClick(-1, -1);
            try
            {
                //Delete GridLay out widget
                CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.ClearContents);
            }
            catch (Exception) //Found win
            {
                //Delete FlowLayout widget
                CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.DeleteContents);
            }
            try
            {
                //Select "OK" in the remove widget confirmation dialog (grid layout)
                CoreManager.MomConsole.ConfirmChoiceDialog(
                            MomConsoleApp.ButtonCaption.OK,
                            ConsoleApp.Strings.RemoveWidgetConfirmationDialogTitle,
                            StringMatchSyntax.WildCard,
                            MomConsoleApp.ActionIfWindowNotFound.Error);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(string.Format("WidgetViewHost.DeleteWidget: {0} not found. Try to find {1}",
                                                   ConsoleApp.Strings.RemoveWidgetConfirmationDialogTitle,
                                                   ConsoleApp.Strings.RemoveWidgetColumnDialogTitle));

                //Select "OK" in the remove column confirmation dialog (flow layout)
                CoreManager.MomConsole.ConfirmChoiceDialog(
                            MomConsoleApp.ButtonCaption.OK,
                            ConsoleApp.Strings.RemoveWidgetColumnDialogTitle,
                            StringMatchSyntax.WildCard,
                            MomConsoleApp.ActionIfWindowNotFound.Error);
            }


            //this.WaitForReady();
            Thread.Sleep(6000);
        }

        public void AddWidget(DashboardParams settings)
        {
            // Launch dialog
            if (this.HasWidget)
                throw new InvalidOperationException("AddWidget:: View host already has widget.");

            if (this.addWidgetLink == null)
            {
                this.addWidgetLink = new Button(
                   new Window(
                        this.Parent,
                        this.GetAddWidgetLinkQID(),
                        TIME_OUT));
            }
            // Bug#204888 
            this.addWidgetLink.SendKeys(KeyboardCodes.Enter);

            // Add widget
            DashboardCreationWizard layoutDashboardCreatetionWizard = null;
            try
            {
                layoutDashboardCreatetionWizard = new DashboardCreationWizard();
            }
            catch(Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("Cannot found the widget wizard, use Accelerate key TAB+ENTER to open it");
                this.Click();
                for (int i = 0; i < 5; i++)
                {
                    this.SendKeys(KeyboardCodes.Tab);
                }
                this.SendKeys(KeyboardCodes.Enter);
                layoutDashboardCreatetionWizard = new DashboardCreationWizard();
            }
            layoutDashboardCreatetionWizard.SettingWizard(settings);

            Utilities.LogMessage("Template Type = " + settings.Template.ToString());
            this.WidgetType = settings.Template.ToString();
        }

        /// <summary>
        /// Method to configure widget
        /// </summary>
        public void ConfigureWidget(string name, string description, ICustomPageParams param)
        {
            if (!this.HasWidget)
                throw new InvalidOperationException("AddWidget:: View host hasn't widget, so cannot be configured.");

            DashboardParams settings = new DashboardParams();
            settings.Name = name;
            settings.Description = description;
            settings.CustomPageParams = param;
            settings.Template = (ITemplate)Activator.CreateInstance(param.GetType().DeclaringType);

            // Launch Configuration Wizard
            DashboardConfigurationWizard dashboardConfigurationWizard = DashboardConfigurationWizard.Launch(this.DropDownButton);
            
            // Config widget       
            dashboardConfigurationWizard.SettingWizard(settings);
        }

        #region Personalize Widgets methods
        // Different types of widgets might have different Personalization dialog options

        /// <summary>
        /// Method to personalized Alert Widget, for Alert Widget only
        /// </summary>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ColumnsDisplayIndex">Columns Position where to sort in Alerts view</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        /// <param name="NeedUpdateSortBy">bool if true, update the SortBy config</param>
        /// <param name="sortColumnsName">List string for show columns in sort view</param>
        /// <param name="ColumnsSortIndex">Columns Position where to sort in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        /// <param name="NeedUpdateGroupBy">bool if true, update the GroupBy config</param>
        /// <param name="GroupColumnsName">List string for show columns in group view</param>
        /// <param name="ColumnsGroupIndex">Columns Position where to sort in Group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public void PersonalizeWidget(List<string> DisplayColumnsName, List<int> ColumnsDisplayIndex, bool ShowAllColumnsToDisplay, bool NeedUpdateSortBy, List<string> sortColumnsName, List<int> ColumnsSortIndex, List<string> SortType, bool NeedUpdateGroupBy, List<string> GroupColumnsName, List<int> ColumnsGroupIndex, List<string> GroupType)
        {
            if (!this.HasWidget)
                throw new InvalidOperationException("AddWidget:: View host hasn't widget, so cannot be personalized.");

            // Click the Personalize button on the Alert Widget view host
            DashboardPersonalizationWizard.Launch(this.Title.Caption, this.DropDownButton);  


            // Click the Personalize button on the Alert Widget view host
            this.personalizationButton.Click();

            // Personalize the Alert Widget
            MomControls.DashboardGadgets.AlertComponent.Personalization.Personalization alertPersonalization = new DashboardGadgets.AlertComponent.Personalization.Personalization(
            Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.Personalization.AlertPersonalizationDialog.Strings.PersonalizationDialogTitle);
            alertPersonalization.updatePersonalization(false, DisplayColumnsName, ColumnsDisplayIndex, ShowAllColumnsToDisplay, NeedUpdateSortBy, sortColumnsName, ColumnsSortIndex, SortType, NeedUpdateGroupBy, GroupColumnsName, ColumnsGroupIndex, GroupType);
        }

       /// <summary>
       /// 
       /// </summary>
        public void LaunchPersonalizeWidget()
        {
            // DashboardPersonalizationWizard.Launch(this.Title.Caption, PersonalizationButton); 
            this.DropDownButton.ScreenElement.LeftButtonClick(-1, -1);
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.Personalize);
        }

        /// <summary>
        /// 
        /// </summary>
        public void LaunchConfigurationWidget()
        {
            //DashboardConfigurationWizard.Launch(name, ConfigurationButton);
            this.DropDownButton.ScreenElement.LeftButtonClick(-1, -1);
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.Configure);
        }

        /// <summary>
        /// Method to personalize Template A widget only
        /// </summary>
        /// <param name="param">params for custome page</param>
        public void PersonalizeWidget(ICustomPageParams param)
        {
            DashboardParams settings = new DashboardParams();
            settings.CustomPageParams = param;
            Utilities.LogMessage("PersonalizeWidget: " + param.GetType().DeclaringType.ToString());
            settings.Template = (ITemplate)Activator.CreateInstance(param.GetType().DeclaringType);
            Utilities.LogMessage("settings: " + settings.Template.ToString());
            // Click the Personalize button
            if (!this.HasWidget)
                throw new InvalidOperationException("AddWidget:: View host hasn't widget, so cannot be personalized.");

            DashboardPersonalizationWizard dashboardPersonalizationWizard = DashboardPersonalizationWizard.Launch(this.Title.Caption, this.DropDownButton);                

            // Personalize widget
            dashboardPersonalizationWizard.SettingWizard(settings);
        }

        #endregion

        #endregion

        public class WidgetTypes
        {
            public const string NoWidget = "No Widget";

            public const string TemplateAWidget = "Template A";

            /// <summary>
            /// host a grid layout 
            /// </summary>
            public const string GridLayoutNestedWidget = "Grid Layout Nested Widget";

            /// <summary>
            /// host a flow layout 
            /// </summary>
            public const string FlowLayoutNestedWidget = "Flow Layout Nested Widget";

            // TODO: Add consts below if there are new widgets. EX: AlertWidget
            public const string AlertWidget = "Alert Widget";

            public const string PerfWidget = "Performance Widget";

            public const string StateWidget = "State Widget";

            public const string TopNWidget = "Objects by Performance";
        }
    }

    /// <summary>
    /// This class is used to get resource strings
    /// </summary>
    public class Strings
    {
        #region Constants

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Configure
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourceConfigure = ";Configure;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources;ConfigureTaskDisplayName";
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Personalize
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourcePersonalize = ";Personalize;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources;PersonalizeTaskDisplayName";

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Clear Contents
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourceClearContents = ";Clear Contents;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources;ClearTaskDisplayName";

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Delete Contents
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourceDeleteContents = ";Delete Contents;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources;DeleteTaskDisplayName";

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Swap with previous widget
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourceSwapWithPreviousWidget = ";Swap with previous widget;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources;SwapLeftTaskDisplayName";

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Swap with next widget
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourceSwapWithNextWidget = ";Swap with next widget;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources;SwapRightTaskDisplayName";

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the Add Cell
        /// </summary>
        /// -----------------------------------------------------------------------------
        private const string ResourceAddCell = ";Add Cell;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources;AddTaskDisplayName";

        #endregion

        #region Private Members

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the Configure
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedConfigure;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the Personalize
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedPersonalize;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the ClearContents
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedClearContents;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the Delete Contents
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedDeleteContents;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the Swap With Previous Widget
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedSwapWithPreviousWidget;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the Swap With Next Widget
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedSwapWithNextWidget;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for the Add Cell
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedAddCell;

        #endregion


        #region Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Configure translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string Configure
        {
            get
            {
                if (cachedConfigure ==null)
                {
                    cachedConfigure = CoreManager.MomConsole.GetIntlStr(ResourceConfigure);
                }
                return cachedConfigure;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Personalize translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string Personalize
        {
            get
            {
                if (cachedPersonalize == null)
                {
                    cachedPersonalize = CoreManager.MomConsole.GetIntlStr(ResourcePersonalize);
                }
                return cachedPersonalize;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Clear Contents translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string ClearContents
        {
            get
            {
                if (cachedClearContents == null)
                {
                    cachedClearContents = CoreManager.MomConsole.GetIntlStr(ResourceClearContents);
                }
                return cachedClearContents;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Delete Contents translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string DeleteContents
        {
            get
            {
                if (cachedDeleteContents == null)
                {
                    cachedDeleteContents = CoreManager.MomConsole.GetIntlStr(ResourceDeleteContents);
                }
                return cachedDeleteContents;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Swap With Previous Widget translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string SwapWithPreviousWidget
        {
            get
            {
                if (cachedSwapWithPreviousWidget ==null)
                {
                    cachedSwapWithPreviousWidget = CoreManager.MomConsole.GetIntlStr(ResourceSwapWithPreviousWidget);
                }
                return cachedSwapWithPreviousWidget;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Swap With Next Widget translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string SwapWithNextWidget
        {
            get
            {
                if (cachedSwapWithNextWidget == null)
                {
                    cachedSwapWithNextWidget = CoreManager.MomConsole.GetIntlStr(ResourceSwapWithNextWidget);
                }
                return cachedSwapWithNextWidget;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Add Cell translated resource string
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/08/19 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string AddCell
        {
            get
            {
                if (cachedAddCell == null)
                {
                    cachedAddCell = CoreManager.MomConsole.GetIntlStr(ResourceAddCell);
                }
                return cachedAddCell;
            }
        }
        #endregion
    }
}
