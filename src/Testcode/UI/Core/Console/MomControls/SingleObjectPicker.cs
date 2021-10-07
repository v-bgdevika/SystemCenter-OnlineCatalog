// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SingleObjectPicker.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//  This class contains helper functions for automation of the configuration of SingleObjectPicker. 
// </summary>
// <history>
//   [v-lileo] 12/15/2010 Created
// </history>
// ------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using System.Collections.Generic;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Infra.Frmwrk;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Class to assist test automation related to Single Object Picker Control.
    /// </summary>
    public class SingleObjectPicker
    {
        private Window content = null;
        private SinglePickerComponent singlePickerComponent = null;

        private PickerControlModalDialog singleObjectPickerComponentDialog = null;

        private SinglePickerControl singleObjectPickerControlView = null;

        private GroupandObjectFilterControl groupAndObjectFilterControl = null;

        #region Constructors
        /// <summary>
        /// Constructor for SingleObjectPicker class.
        /// </summary>
        public SingleObjectPicker(Window KnownWindow)
        {
            this.content = KnownWindow;
        }
        #endregion

        //public FilterControl filter;
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="FilterText"></param>
        //public void Filtercontrol(string FilterText)
        //{
        //    filter = new FilterControl(this.content);
        //    if (this.filter.FilterTextBox.IsVisible)
        //    {
        //        this.filter.FilterTextBox.Text = FilterText;
        //    }
        //}
        
        /// <summary>
        /// Method to add Item to Single Picker Component View
        /// </summary>
        /// <param name="Properties">Dictionary<string, string> type for item </param>
        /// <param name="SinglePickerViewPath">string type for object picker path</param>
        /// <param name="LuanchDialogType">PickerControlModalDialog.enumPickerControlModalDialogType</param>
        public void AddItemToSinglePickerComponentView(Dictionary<string, string> Properties, PickerControlModalDialog.enumPickerControlModalDialogType LuanchDialogType)
        {
            this.AddItemToSinglePickerComponentView(Properties, LuanchDialogType, true, null);
        }

        public void AddItemToSinglePickerComponentView(Dictionary<string, string> Properties,PickerControlModalDialog.enumPickerControlModalDialogType LuanchDialogType, bool GroupOrObjectFilterOption, string FilterString)
        {
            this.AddItemToSinglePickerComponentView(Properties, LuanchDialogType, true, FilterString, null);
        }

        /// <summary>
        /// Method to add item to Single Picker Component View
        /// </summary>
        /// <param name="Properties">Dictionary<string, string> type for searching item</param>
        /// <param name="SinglePickerViewPath">string type for object picker path</param>
        /// <param name="LuanchDialogType">PickerControlModalDialog.enumPickerControlModalDialogType</param>
        /// <param name="GroupOrObjectFilterOption">bool </param>
        /// <param name="FilterString">string type for Fitler string</param>
        public void AddItemToSinglePickerComponentView(Dictionary<string, string> Properties,PickerControlModalDialog.enumPickerControlModalDialogType LuanchDialogType, bool GroupOrObjectFilterOption, string FilterString, Button launchButton)
        {
            if (Properties != null && LuanchDialogType != null)
            {
                CoreManager.MomConsole.Waiters.WaitForReady();
                singlePickerComponent = new SinglePickerComponent(this.content, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
                Utilities.LogMessage("LaunchSingleObjectPickerComponentDialog:: Launching Single Picker Component Dialog");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(singlePickerComponent.Controls.LauncherButton, Mom.Test.UI.Core.Common.Constants.OneMinute);
                if (launchButton == null)
                {
                    singlePickerComponent.ClickLauncherButton();
                }
                else
                {
                    launchButton.Click();
                }
                
                singleObjectPickerComponentDialog = new PickerControlModalDialog(CoreManager.MomConsole, LuanchDialogType);
                Utilities.LogMessage("LaunchSingleObjectPickerComponentDialog:: Launched Single Object Picker Component Dialog");
                //if (LuanchDialogType == PickerControlModalDialog.enumPickerControlModalDialogType.SingleObjectPicker)
                //{
                groupAndObjectFilterControl = new GroupandObjectFilterControl(singleObjectPickerComponentDialog);
                Utilities.LogMessage("AddItemToSingleObjectPickerComponentView:: Selecting a groups type ");
                this.groupAndObjectFilterControl.SelectGroupsOrObjectAndGroups(GroupOrObjectFilterOption, FilterString);
                //Sleeper.Delay(2000);
                //}

                // Wait for grid row loaded
                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate()
                {
                    singleObjectPickerControlView = new SinglePickerControl(singleObjectPickerComponentDialog);
                    Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond);
                    this.singleObjectPickerControlView.Controls.AvailableItemsDataGrid.ScreenElement.WaitForReady();
                    int rowCount = this.singleObjectPickerControlView.Controls.AvailableItemsDataGrid.RowsExtended.Count;
                    Utilities.LogMessage("AddItemToSinglePickerComponentView:: AvailableItemsDataGrid: rowCount:" + rowCount);
                    return rowCount != 0;
                }, Mom.Test.UI.Core.Common.Constants.OneSecond * 15);

                this.singleObjectPickerControlView.SelectItem(Properties);
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(singleObjectPickerComponentDialog.Controls.OkButton, Mom.Test.UI.Core.Common.Constants.TenSeconds);
                this.singleObjectPickerComponentDialog.ClickOk();
                CoreManager.MomConsole.WaitForDialogClose(singleObjectPickerComponentDialog, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
            }
            else
            {
                Utilities.LogMessage("AddItemToSinglePickerComponentView:: The Properties or LuanchDialogType is null,throw VarAboart");
                throw new VarAbort("AddItemToSinglePickerComponentView:: The Properties or LuanchDialogType is null");
            }

        }

        /// <summary>
        /// Method to verify item added
        /// </summary>
        /// <param name="SinglePickerViewPath">string type for single picker path</param>
        /// <param name="expectedName">string type for expect name</param>
        /// <returns>return true or false</returns>
        public bool VerifyItemAdded(string expectedName)
        {
            singlePickerComponent = new SinglePickerComponent(this.content, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
            bool result = false;
            if (singlePickerComponent.Controls.SinglePickerComponentSelectionText.ScreenElement.Name.ToLower() == expectedName.ToLower())
            {
                Utilities.LogMessage("VerifyItemAdded:: The item successfully added to view");
                result = true;
            }
            else
            {
                Utilities.LogMessage("VerifyItemAdded:: Data Error. Expected: " + expectedName + " Actual: " + singlePickerComponent.Controls.SinglePickerComponentSelectionText.Text);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Method to removew item from single picker component view
        /// </summary>
        /// <param name="SinglePickerViewPath">string type for single picker path</param>
        /// <param name="expectedName">string type for expect name</param>
        public void RemoveItemFromSinglePickerComponentView()
        {
            singlePickerComponent = new SinglePickerComponent(this.content, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
            Utilities.LogMessage("RemoveItemFromSinglePickerComponentView:: Clicking on clear button");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(singlePickerComponent.Controls.ClearButton, Mom.Test.UI.Core.Common.Constants.TenSeconds);
            singlePickerComponent.ClickClear();
            Sleeper.Delay(1000);            
        }

        /// <summary>
        /// Verify item if not removed
        /// </summary>
        /// <param name="expectedName">string remove item Name</param>
        /// <returns>true or false</returns>
        public bool VerifyItemRemoved(string expectedName)
        {
            bool result = false;
            Utilities.LogMessage("VerifyItemRemoved::...");

            singlePickerComponent = new SinglePickerComponent(this.content, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);

            if (singlePickerComponent.Controls.SinglePickerComponentSelectionText.ScreenElement.Name == expectedName)
            {
                Utilities.LogMessage("RemoveItemFromSinglePickerComponentView:: Clear item failed");
                return false;
            }
            else
            {
                Utilities.LogMessage("RemoveItemFromSinglePickerComponentView:: The item removed");
                result = true;
            }

            return result;
        }
    }

    public class LoadObjectPickerColumnNameResourceString
    {
        #region Private variable        

        [Resource(ID = "Name")]
        private string NameColumn = null;
        [Resource(ID = "Path")]
        private string PathColumn = null;
        [Resource(ID = "Type")]
        private string TypeColumn = null;
        [Resource(ID = "Title")]
        private string SingleObjectPickerComponent = null;

        #endregion

        public string Name
        {
            get
            {
                return this.NameColumn;
            }
        }

        public string Path
        {
            get
            {
                return this.PathColumn;
            }
        }

        public string Type
        {
            get
            {
                return this.TypeColumn;
            }
        }

        public string SingleObjectPickerComponentTitle
        {
            get
            {
                return this.SingleObjectPickerComponent;
            }
        }

        #region Constructors
        /// <summary>
        /// Constructor for SingleObjectPicker class.
        /// </summary>
        public LoadObjectPickerColumnNameResourceString()
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            XDocument ObjectPickerColumnDocument = ResourceLoader.GetDefaultResourceFile("Mom.Test.UI.Core.Console.MomControls.ObjectPickerResource.xml");
            XElement ObjectPickerColumnSection = ResourceLoader.GetSection("ObjectPickerComponent", ObjectPickerColumnDocument);
            ResourceLoader.LoadResources(this, ObjectPickerColumnSection);
        }
        #endregion
    }
}
