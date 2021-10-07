//-------------------------------------------------------------------
// <copyright file="DistributeAppCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   MomConsole Application Core Code for manipulating Distributed Applications.
// </summary>
//  <history>
//   [mcorning] 01MAR06: Created
//   [faizalk]  07JUL06: Add support for some basic BVTs
//  </history>
//-------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using Maui.GlobalExceptions;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MomControls;
using Infra.Frmwrk;

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{

    /// <summary>
    /// A service provided by Mom that enables manipulation of the Distributed Applications View.
    /// </summary>
    public partial class DistributedAppCollection : Component
    {
        #region Private fields
        // we use the tests list during test development to programmatically control which tests run
        List<string> tests = new List<string>();
        public const string testDistriAppName = "TestDistriAppName";

        MomConsoleApp app = CoreManager.MomConsole;
        const int defaultTemplateIndex = -1;
        Dictionary<string, DesignSurface> services = new Dictionary<string, DesignSurface>();
        string serviceName = null;
        
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public DistributedAppCollection()
        {
            InitializeComponent();
            tests.Add("Add");
            tests.Add("Close");
            tests.Add("Edit");
            tests.Add("Save");
        }

        /// <summary>
        /// System.ComponentModel-based ctor enables DistributedAppCollection 
        /// to add a constructed component to its container so other clients
        /// of DistributedAppCollection can access it. 
        /// </summary>
        /// <param name="container">System.ComponentModel.IContainer that holds DistributedAppComponents.</param>
        public DistributedAppCollection(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Public Properties and Enums

        /// <summary>
        /// Mechanisms to save a service.
        /// </summary>
        public enum SaveOption
        {
            /// <summary>
            /// Save service using the Service Designer File:Save menu
            /// </summary>
            SaveFromFileSave,
            /// <summary>
            /// Save service using the Service Designer File:Save menu hotkey
            /// </summary>
            SaveWithSaveHotKey,
            /// <summary>
            /// Save service using the Save button on the Service Designer toolbar
            /// </summary>
            SaveWithSaveToolbarButton,
        }

        /// <summary>
        /// Close mechanisms
        /// </summary>
        public enum CloseOption
        {
            /// <summary>
            /// Close Service Designer using Mom's File:Close menu
            /// </summary>
            CloseFromFileClose,
            /// <summary>
            /// Close Service Designer using Mom's File:Close menu hotkey
            /// </summary>
            CloseWithCloseHotKey,
            /// <summary>
            /// Close Service Designer using the standard window close button.
            /// </summary>
            CloseByWindowCloseButton
        }

        /// <summary>
        /// Two actions we can take on a distributed application (Add implies Edit).
        /// </summary>
        public enum Action
        {
            /// <summary>
            /// Delete a distributed application
            /// </summary>
            Delete,
            /// <summary>
            /// Edit a distributed application (Add implies Edit)
            /// </summary>
            Edit
        }

        /// <summary>
        /// Mechanisms for creating a Service.
        /// </summary>
        public enum NewOption
        {
            /// <summary>
            /// Mechanism to create a service will be chosen at random.
            /// </summary>
            Random,
            /// <summary>
            /// Create a service using the Action pane.
            /// </summary>
            Action,
            /// <summary>
            /// Create a service using the maine menu from Mom or the Service Designer.
            /// </summary>
            MainMenu,
            /// <summary>
            /// Create a service using the Mcf.FrameworkContext menu in Mom.
            /// </summary>
            CtxMenu
        }
         #endregion
        
        #region Public Methods
         /// <summary>
        /// Add a distributed application using a random name and template
        /// </summary>
        public void Add()
        {
            if (tests.Contains("Add"))
            {
                AddInternal(null, defaultTemplateIndex, NewOption.Random, null, null);
            }
        }

        /// <summary>
        /// Add a partially specified distributed application using
        /// a random mode of opening New dialog and a random template
        /// </summary>
        /// <param name="name">name of new distributed application</param>
        public DesignSurface Add(string name)
        {
            return AddInternal(name, defaultTemplateIndex, NewOption.Random, null, null);
        }

        /// <summary>
        /// Add a partially specified distributed application 
        /// </summary>
        /// <param name="name">name of new distributed application</param>
        /// <param name="templateIndex">index into list of distributed application templates used to create the distributed app</param>
        public DesignSurface Add(string name, int templateIndex)
        {
            return AddInternal(name, templateIndex, NewOption.Random, null, null);
        }

        /// <summary>
        /// Add a fully specified distributed application 
        /// </summary>
        /// <param name="name">name of new distributed application</param>
        /// <param name="templateIndex">index into list of distributed 
        /// <param name="newOption">mode of opening New dialog</param></param>
        public DesignSurface Add(string name, int templateIndex, NewOption newOption)
        {
            return AddInternal(name, templateIndex, newOption, null, null);
        }

        /// <summary>
        /// Add a fully specified distributed application 
        /// </summary>
        /// <param name="name">name of new distributed application</param>
        /// <param name="templateIndex">index into list of distributed 
        /// <param name="newOption">mode of opening New dialog</param></param>
        /// <param name="description">description text to enter in Description textbox</param>
        public DesignSurface Add(string name, int templateIndex, NewOption newOption, string description)
        {
            return AddInternal(name, templateIndex, newOption, description, null);
        }

        /// <summary>
        /// Add a fully specified distributed application 
        /// </summary>
        /// <param name="name">name of new distributed application</param>
        /// <param name="templateIndex">index into list of distributed 
        /// <param name="newOption">mode of opening New dialog</param></param>
        /// <param name="description">description text</param>
        /// <param name="destinationMP">name of destination MP to select from combo box</param>
        public DesignSurface Add(string name, int templateIndex, NewOption newOption, string description, string destinationMP)
        {
            return AddInternal(name, templateIndex, newOption, description, destinationMP);
        }

        /// <summary>
        /// Close all service design surfaces
        /// </summary>
        public void CloseAllServices()
        {
            Utilities.LogMessage("Closing " + services.Count + " services...");
            DesignSurface dialog = null;
            foreach (KeyValuePair<string, DesignSurface> service in services)
            {
                string serviceCaption = null;
                try
                {
                    serviceCaption = service.Key;
                    Utilities.LogMessage("Closing " + serviceCaption);
                    dialog = (DesignSurface)service.Value;

                    dialog.Extended.SetFocus();
                    UISynchronization.WaitForProcessReady(dialog);
                    UISynchronization.WaitForUIObjectReady(dialog);
                    dialog.WaitForResponse();

                    bool prompt = dialog.Caption.EndsWith("*");
                    app.ExecuteWindowMenuItem(dialog, Strings.MenuBarFileOption, Strings.FileMenuCloseOption);
                    //dialog.SendKeys(KeyboardCodes.Alt + KeyboardCodes.F4);
                    if (prompt)
                    {
                        // don't save any open files at end of test
                        this.CloseSaveServiceDialog(false);
                        while (dialog.Caption.EndsWith("*")) ;

                    }
                }
                catch (Exception x)
                {
                    Utilities.LogMessage("There was a problem closing service, " + serviceCaption + ".");
                    Utilities.LogMessage(x.ToString());
                }
            }
            services.Clear();
            // ensure no empty design surfaces are left up
            while (true)
            {
                try
                {
                    dialog = new DesignSurface(this.app);
                    dialog.SendKeys(KeyboardCodes.Alt + KeyboardCodes.F4);
                }
                catch
                {
                    break;
                }
            }

        }

        /// <summary>
        /// Randomly choose a method to close a window.
        /// </summary>
        public void CloseService()
        {
            if (tests.Contains("Close"))
            {
                string[] CloseOptions = Enum.GetNames(typeof(CloseOption));
                CloseOption CloseOption = (CloseOption)Enum.Parse(typeof(CloseOption),
                    CloseOptions[new Random(Utilities.Seed).Next(0, CloseOptions.Length)]);
                this.CloseServiceInternal(CloseOption);
            }
        }

        /// <summary>
        /// Close service using an explicit close mechanism
        /// </summary>
        /// <param name="CloseOption">Mechanism to close service designer.</param>
        public void CloseService(CloseOption CloseOption)
        {
            this.CloseServiceInternal(CloseOption);
        }

        /// <summary>
        /// Delete a distributed application
        /// </summary>
        public void Delete()
        {
            ChangeRandomGridRow(Action.Delete,serviceName);
        }

        /// <summary>
        /// Open Design surface for specified app
        /// </summary>
        /// TODO: Be able to reedit an open/saved service
        /// 
        public void Edit()
        {
            if (!tests.Contains("Edit"))
            {
                return;
            }
            // select a service to edit
            this.ChangeRandomGridRow(Action.Edit,serviceName);

        }

        /// <summary>
        /// Create a relationship between any two components
        /// </summary>
        public void CreateRelationship()
        {
            this.CreateRelationship(null, null);
        }

        /// <summary>
        /// Create a relationship between any two components
        /// </summary>
        /// <param name="designSurface">surface to use</param>
        public void CreateRelationship(DesignSurface designSurface)
        {
            this.CreateRelationshipInternal(designSurface, null, null);
        }

        /// <summary>
        /// Create a relationship between two particular components
        /// </summary>
        /// <param name="fromComponent">component to start relationship at</param>
        /// <param name="toComponent">component to finish relationship at</param>
        public void CreateRelationship(string fromComponent, string toComponent)
        {
            DesignSurface designSurface = OpenDesignSurfaceInternal();
            // select nodes to use
            this.CreateRelationshipInternal(designSurface, fromComponent, toComponent);
        }

        /// <summary>
        /// Create a relationship between two particular components
        /// </summary>
        /// <param name="designSurface">surface to use</param>
        /// <param name="fromComponent">component to start relationship at</param>
        /// <param name="toComponent">component to finish relationship at</param>
        public void CreateRelationship(DesignSurface designSurface, string fromComponent, string toComponent)
        {
            // select nodes to use
            this.CreateRelationshipInternal(designSurface, fromComponent, toComponent);
        }

        /// <summary>
        /// Saves service using a randomly choosen save mechanism
        /// </summary>
        public void SaveService()
        {
            if (tests.Contains("Save"))
            {
                string[] saveOptions = Enum.GetNames(typeof(SaveOption));
                SaveOption saveOption = (SaveOption)Enum.Parse(typeof(SaveOption),
                    saveOptions[new Random(Utilities.Seed).Next(0, saveOptions.Length)]);
                this.SaveServiceInternal(saveOption);
            }
        }

        /// <summary>
        /// Saves service using an explicit save mechanism
        /// </summary>
        /// <param name="saveOption">Mechanism to save service.</param>
        public void SaveService(SaveOption saveOption)
        {
            this.SaveServiceInternal(saveOption);
        }

        #region Faizal's additional code

        /// <summary>
        /// Creates New DistributedApplication in Default MP
        /// </summary>
        /// <param name="name">name of distributed app</param>
        /// <param name="index">template index for new distributed app</param>
        [Obsolete]
        public DesignSurface CreateNewDistributedApplication(string name, int index)
        {
            return CreateNewDistributedApplication(name, null, index, null);
        }

        /// <summary>
        /// Creates New DistributedApplication in Default MP
        /// </summary>
        /// <param name="name">name of distributed app</param>
        /// <param name="description">description for new distributed app</param>
        /// <param name="index">template index for new distributed app</param>
        [Obsolete]
        public DesignSurface CreateNewDistributedApplication(string name, string description, int index)
        {
            return CreateNewDistributedApplication(name, description, index, null);
        }

        /// <summary>
        /// Creates New DistributedApplication
        /// </summary>
        /// <param name="name">name of distributed app</param>
        /// <param name="description">description for new distributed app</param>
        /// <param name="index">template index for new distributed app</param>
        /// <param name="mp">destination MP to store new distributed app</param>
        [Obsolete]
        public DesignSurface CreateNewDistributedApplication(string name, string description, int index, string mp)
        {
            // create new blank template
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration,
                                Core.Console.NavigationPane.Strings.MonConfigTreeViewServices,
                                Core.Console.NavigationPane.Strings.ActionServices,
                                Core.Console.NavigationPane.Strings.ActionCreateANewService);

            CreateDistributedApplicationDialog newDialog = null;

            // getting a reference to the Create a new service dialog is very tricky.
            // this first try just uses wildcard search and keeps trying until the new
            // window gets a reference to the template dropdown (we can get a window ref and 
            // still not get a control ref, so we keep trying till we get both).
            int tries = 0;
            int maxTries = 10;

            while (tries < maxTries)
            {
                try
                {
                    newDialog = new CreateDistributedApplicationDialog(this.app);
                    break;
                }
                catch
                {
                    Utilities.TakeScreenshot("Attempt " + tries + " to get CreateDistributedApplicationDialog");
                }
                finally
                {
                    Utilities.LogMessage("Trying " + tries + " times to access CreateDistributedApplicationDialog.");
                    tries++;
                }
            }

            if (tries == maxTries || null == newDialog) throw new ApplicationException("Could not find CreateDistributedApplicationDialog  in " + tries + " tries.");

            tries = 0;
            while (tries < maxTries)
            { 
                try
                {
                    int serviceCount = newDialog.Controls.TemplateListBox.Count;
                    break;
                }
                catch
                {
                    Utilities.TakeScreenshot("Attempt " + tries + " to get CreateDistributedApplicationDialog");
                }
                finally
                {   
                    Utilities.LogMessage("Trying " + tries + " times to access TemplateListBox control.");   
                    tries++;
                }
            }

            if (tries == maxTries) throw new ApplicationException("Could not find TemplateListBox control in " + tries + " tries.");

            Utilities.LogMessage(String.Format(
                "New dialog open, and NameTextBox enabled is {0} and is ready for name {1} and Template selection is {2}",
                newDialog.Controls.NameTextBox.IsEnabled,
                name,
                index),true);
            Utilities.TakeScreenshot("ReadyToUpdateCreateNewServiceDialog");

            // enter Name
            if (!String.IsNullOrEmpty(name))
            {
                newDialog.NameText = name;
            }

            // enter description
            if (!String.IsNullOrEmpty(description))
            {
                newDialog.DescriptionOptionalText = description;
            }

            // select Template
            if (index >= 0)
            {
                if (index > newDialog.Controls.TemplateListBox.Count - 1)
                {
                    throw new ArgumentOutOfRangeException(index + " is greater than count: " + newDialog.Controls.TemplateListBox.Count);
                }
                newDialog.Controls.TemplateListBox.SelectItem(index, true);
            }

            // select destination mp
            if (!String.IsNullOrEmpty(mp))
            {
                newDialog.Controls.ManagementPackComboBox.SelectByText(mp);
            }

            // click OK
            newDialog.ClickOK();

            // if name is already used we'll get a confirmation dialog
            tries = 0;
            maxTries = 5;
            while (tries < maxTries)
            {
                try
                {
                    tries++;
                    this.app.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.OK,
                    Strings.MomDialogTitle,
                    StringMatchSyntax.ExactMatch,
                    MomConsoleApp.ActionIfWindowNotFound.Error);
                }
                catch
                {
                    Utilities.LogMessage(name + " created. Test continues.");
                    break;
                }

                Utilities.LogMessage("Name already in use. Regenerating random name .");
                name = @"Service" + new Random(Utilities.Seed).Next(1, 10000).ToString();

                // assign new name and try again to close the dialog
                newDialog.NameText = name;
                newDialog.ClickOK();
            }
            if (tries == maxTries)
            {
                this.app.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.OK,
                    Strings.MomDialogTitle,
                    StringMatchSyntax.ExactMatch,
                    MomConsoleApp.ActionIfWindowNotFound.Ignore);
                Sleeper.Delay(Constants.OneSecond);
                newDialog.ClickCancel();
                throw new ArgumentException("The MCF seed has reused the same service names " + maxTries + " times. Please retry test with a different seed.");
            }

            // we should be left with the design surface window open
            DesignSurface ds = new DesignSurface(app, name);

            // wait for things to settle
            CoreManager.MomConsole.WaitForEnabledDialog(ds, 60);
            // this call tends to fail and cause timing issues during BVTs
            // CoreManager.MomConsole.WaitForForegroundDialog(designSurface, 60);
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(ds, 60);

            return ds;
        }

        /// <summary>
        /// Adds instance object to Component Group on Design Surface
        /// </summary>
        /// <remarks></remarks>
        public void AddToNewComponentGroup(DesignSurface designSurface, string objectType, string objectName, string newComponentGroupName, string objectTypes)
        {
            try
            {
                Utilities.LogMessage("");
                Utilities.LogMessage("Adding service component to distributed application.");

                //designSurface.Controls.

                if (designSurface.Controls.ListViewSCInstances.Items.Count == 0)
                {
                    Utilities.LogMessage("Listview has no items. This is probably not what you expect.");
                    designSurface.Extended.AccessibleObject.Click();
                    Utilities.TakeScreenshot("Empty ListView");
                    throw new ListView.Exceptions.ListViewHasNoItemsException("List view has no items!");
                }
                else
                {
                    int x = -1;
                    try
                    {
                        Utilities.LogMessage("Selecting listview.");
                        designSurface.Controls.ListViewSCInstances.Click();
                        designSurface.Controls.ListViewSCInstances.WaitForResponse();
                        Utilities.LogMessage("Choosing Service " + x);
                        designSurface.Controls.ListViewSCInstances.Items[objectType].Click(MouseClickType.SingleClick, MouseFlags.RightButton);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Cannot click the listview.", ex);
                    }
                    Menu ctxMenu = null;
                    Menu subMenu = null;
                    try
                    {
                        Utilities.LogMessage("Choosing menu item " + Strings.AddTo);
                        ctxMenu = new Menu(Constants.DefaultContextMenuTimeout);
                        ctxMenu.ExecuteMenuItem(Strings.AddTo);
                        subMenu = new Menu(Constants.DefaultContextMenuTimeout);
                        x = new Random(Utilities.Seed).Next(0, subMenu.MenuItems.Count);
                        Utilities.LogMessage("Choosing item " + x + " (" +
                            subMenu.MenuItems[x] + ") from submenu");
                        // now, if there is only one submenu item and it is enabled, then
                        // we need to create a new scg (as if we had clicked the Add Service
                        // Component toolbar button).
                        // else if there are more than two entries, we should accept the default
                        // second entry (which should put the item in the correct scg).
                        // in either case, we should look to that new or added to scg and ensure 
                        // that we have added the item correctly.
                        subMenu.MenuItems[x].Execute();
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        if (null == ctxMenu)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                "Maui can't find context menu.");
                        }
                        else if (null == subMenu)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                "Maui can't find context menu's items.");
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Utilities.LogMessage("Ignore this ArgumentOutOfRangeException, menu has been executed");
                    }

                    if (x == 0)
                    {
                        // look for Create New Service Component Group dialog
                        try
                        {
                            CreateNewComponentGroupDialog dialog = new CreateNewComponentGroupDialog(this.app);
                            dialog.NameYourComponentGroupText = designSurface.Controls.ListViewSCInstances.Items[x].Text + " Group";
                            dialog.ClickOK();
                            try
                            {
                                // check for Replace Visible Object Type dialog
                                ReplaceVisibleObjectTypeDialog dialog2 = new ReplaceVisibleObjectTypeDialog(this.app);
                                // OK, may mean the new scg is not visible in the NavPane.
                                dialog2.ClickOK();
                            }
                            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                            {
                                // continue processing method
                            }

                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                "Clicking the Object's submenu should always produce the Create Component Group dialog; but this time, it didn't.");
                        }
                    }
                    Utilities.LogMessage("Successfully added service component to distributed application.");
                }
            }
            catch (Exception ax)
            {
                throw new ApplicationException("Cannot Add instance to distributed application.\n\nAdditional information:\n", ax);
            }
        }

        /// <summary>
        /// Returns boolean indicating whether a particular Distributed Application exists 
        /// </summary>               
        /// <param name="appName">App name that you want to find</param>                
        /// <returns>bool</returns>        
        /// <history>
        /// [faizalk] 07JUL06 - Created        
        /// </history>
        public bool DistributedAppExists(string appName)
        {
            Utilities.LogMessage("Looking for " + appName);

            bool foundApp = false;
            Maui.Core.WinControls.DataGridViewRow distributedAppRow = null;

            //Go to Monitored component node in navigation pane
            string distributedAppsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewServices;

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            int maxTries = 0;
            //# retry attempts
            while (maxTries < 2)
            {
                navPane.SelectNode(distributedAppsPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                Utilities.LogMessage("DistributedAppExists:: Selected Node "
                    + NavigationPane.Strings.MonConfigTreeViewServices
                    + " in Navigation Pane");
                app.Waiters.WaitForStatusReady();
                distributedAppRow = CoreManager.MomConsole.ViewPane.Grid.FindData(appName, Strings.ServiceNameColumnNumber);
                if (distributedAppRow != null)
                {
                    foundApp = true;
                    distributedAppRow.AccessibleObject.Click();
                    break;
                }
                CoreManager.MomConsole.Refresh();
                app.Waiters.WaitForStatusReady();
                maxTries++;
            }
            return foundApp;
        }

        /// <summary>
        /// Deletes a particular Distributed Application  
        /// </summary>               
        /// <param name="appName">App name that you want to dekete</param>                
        /// <returns>bool</returns>        
        /// <history>
        /// [faizalk] 07JUL06 - Created        
        /// </history>
        public void DeleteApp(string appName)
        {
            Utilities.LogMessage("DeleteApp::Deleting " + appName);

            Maui.Core.WinControls.DataGridViewRow distributedAppRow = null;

            //Go to Monitored component node in navigation pane
            string distributedAppsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewServices;

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            int maxTries = 0;
            //# retry attempts
            while (maxTries < 2)
            {
                navPane.SelectNode(distributedAppsPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                Utilities.LogMessage("DistributedAppExists:: Selected Node "
                    + NavigationPane.Strings.MonConfigTreeViewServices
                    + " in Navigation Pane");
                app.Waiters.WaitForStatusReady();
                distributedAppRow = CoreManager.MomConsole.ViewPane.Grid.FindData(appName, Strings.ServiceNameColumnNumber);
                if (distributedAppRow != null)
                {
                    distributedAppRow.AccessibleObject.Click();
                    break;
                }
                CoreManager.MomConsole.Refresh();
                app.Waiters.WaitForStatusReady();
                maxTries++;
            }

            if (distributedAppRow == null)
            {
                throw new GridControl.Exceptions.DataGridViewRowNotFoundException(appName + " not found in Distributed Apps view!");
            }

            distributedAppRow.AccessibleObject.Click();
            Commands.EditDelete.Execute(app);
            app.ConfirmChoiceDialog(true, Strings.ConfirmServiceDeleteDialogTitle);
            Utilities.LogMessage("Waiting for 'Deleting distributed application...' to disappear...");
            app.Waiters.WaitForWindowIdle(app.MainWindow, 60);
            UISynchronization.WaitForUIObjectReady(app.MainWindow);
            app.MainWindow.WaitForResponse();
            Utilities.LogMessage("Deleted " + serviceName);
            CoreManager.MomConsole.Refresh();
            app.Waiters.WaitForStatusReady();
        }

        #endregion //Faizal's additional code

        #endregion

        #region Internal Methods
        /// <summary>
        /// Adds instance object (from first Object Types list with items) to Component Group on Design Surface
        /// </summary>
        /// <remarks>This test chooses the first Group from the Object Picker (after the "Organize Object Types")
        /// that contains a list of objects. Depending on the state of the distributed application, this test 
        /// randomly picks a list item and randomly picks a destination group for the instance object 
        /// (unless there is only the "New Component Group..." under the "Add To" context menu option)</remarks>
        internal void AddInstanceToComponentGroup(DesignSurface ds)
        {
            try
            {
                Utilities.LogMessage("");
                Utilities.LogMessage("Adding Distributed Application component to distributed application.");
                Window service = null;
                Window tsc = null;
                try
                {
                    // Maximize the designer dialog, so that it will not click system task bar, even if the screen size is small.
                    ds.Extended.State = WindowState.Maximize;

                    Utilities.LogMessage("Getting toolstripcontainer.");
                    // find toolstripContainer 
                    //TODO: double check that the name for toolstripcontainer control is being localized -- it shouldn't be
                    tsc = Utility.GetDialogOrWindow(app, Strings.ToolStripContainer, 1000, true, true);
                    // TODO: right now, object titles are coming from mps and they may not be localized -- this is wrong,
                    // but for now, we're going to look for "Service" objects
                    Utilities.LogMessage("Now getting Distributed Application list.");

                    service = new Window(
                        Utilities.GetEntityName(Microsoft.EnterpriseManagement.Configuration.SystemMonitoringClass.Service) + "*",
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinForms10Window8,
                        StringMatchSyntax.WildCard,
                        tsc,
                        3000);
                    // ensure list is visible.

                    Utilities.LogMessage("Waiting five seconds to click new window...");
                    Sleeper.Delay(5000);
                    service.Extended.AccessibleObject.Click();
                    Utilities.TakeScreenshot("Is Distributed Application clicked?");
                }
                catch (Exception wx)
                {
                    if (null == tsc)
                    {
                        throw new InvalidOperationException("Cannot find " + Strings.ToolStripContainer + ". May be a localization issue.", wx);
                    }
                    else if (null == service)
                    {
                        // all three stock templates include Service as an Object, and Service always has at least one
                        // service instance, Operations Manager Management Group.
                        throw new InvalidOperationException("Cannot find any Distributed Application instances. \nMinimally, we should be able to find Operations Manager Management Group.", wx);
                    }
                }
                ListView list = null;
                int tries = 0;
                int maxTries = 60;

                try
                {
                    //ActiveAccessibility nodes = service.Extended.AccessibleObject;
                    Utilities.LogMessage("Creating listview.");
                    //list = new ListView(tsc, "listViewSCInstances", true, 5000);
                    list = ds.Controls.ListViewSCInstances;
                }
                catch (Exception ex)
                {
                    Utilities.LogMessage("Cannot find listview");
                    Utilities.LogMessage(ex.ToString());
                }

                while (list.Items.Count == 0 && tries < maxTries)
                {
                    list = ds.Controls.ListViewSCInstances;
                    tries++;
                    Sleeper.Delay(Constants.OneSecond);
                    Utilities.LogMessage("Attempt " + tries + " of " + maxTries + " to get populated list view");
                }

                if (list.Items.Count == 0)
                {
                    Utilities.LogMessage("Listview has no items. This is probably not what you expect. Let's try again...");
                    service.Extended.AccessibleObject.Click();
                    Utilities.TakeScreenshot("Empty ListView");
                    list = new ListView(tsc, "listViewSCInstances", true, 5000);
                    if (list.Items.Count == 0)
                    {
                        Utilities.LogMessage("still nothing. hmmm...");
                        Utilities.TakeScreenshot("Empty ListView");
                    }
                }
                else
                {
                    int x = -1;
                    try
                    {
                        Utilities.LogMessage("Choosing Distributed Application " + list.Items[testDistriAppName]);
                        list.Items[testDistriAppName].Click(MouseClickType.SingleClick, MouseFlags.RightButton);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Cannot click the listview.", ex);
                    }
                    Menu ctxMenu = null;
                    Menu subMenu = null;
                    try
                    {
                        Utilities.LogMessage("Choosing menu item " + Strings.AddTo);
                        int retryCount = 0;
                        int maxRetryCount = 5;
                        while (retryCount < maxRetryCount)
                        {
                            retryCount++;
                            try
                            {
                                ctxMenu = new Menu(Constants.DefaultContextMenuTimeout);
                                break;
                            }
                            catch (Maui.Core.WinControls.Menu.Exceptions.ItemNotFoundException notFoundException)
                            {
                                if (retryCount == maxRetryCount)
                                {
                                    Utilities.TakeScreenshot("FailedOpenContentMenu");
                                    throw new VarFail("Open content menu failed lead to select 'AddTo' button fail");
                                }
                                Utilities.LogMessage("Exception in choose content Menu's item 'AddTo' " + notFoundException.ToString());
                                Sleeper.Delay(1000);

                                Utilities.LogMessage("Attempt " + retryCount + " of "+ maxRetryCount +" to right-click distributed application open content Menu.");
                                list.Items[testDistriAppName].Click(MouseClickType.SingleClick, MouseFlags.RightButton);

                                Sleeper.Delay(1000);
                                Utilities.TakeScreenshot("Open Menu failed retry " + retryCount + " ...");
                            }
                        }
                        Utilities.LogMessage("Open the AddTo menu item");
                        ctxMenu.ExecuteMenuItem(Strings.AddTo);
                        Utilities.LogMessage("Open the AddTo submenu item");
                        subMenu = new Menu(Constants.DefaultContextMenuTimeout);
                        Utilities.LogMessage("subMenuItems.Count = " + subMenu.MenuItems.Count);
                        x = new Random(Utilities.Seed).Next(0, subMenu.MenuItems.Count);
                        Utilities.LogMessage("x = " + x);
                        Utilities.LogMessage("Choosing item " + x + " (" +
                            subMenu.MenuItems[x] + ") from submenu");
                        // now, if there is only one submenu item and it is enabled, then
                        // we need to create a new scg (as if we had clicked the Add Service
                        // Component toolbar button).
                        // else if there are more than two entries, we should accept the default
                        // second entry (which should put the item in the correct scg).
                        // in either case, we should look to that new or added to scg and ensure 
                        // that we have added the item correctly.
                        subMenu.MenuItems[x].Execute();

                        /*
                        #region Resource Keys

                        string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm;>>toolStripContainer.BottomToolStripPanel.Parent";
                        #region "toolStripContainer" Class = "WindowsForms10.Window.8.app"
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm;>>toolStripContainer.ContentPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm;>>toolStripContainer.LeftToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm;>>toolStripContainer.Name";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm;>>toolStripContainer.RightToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm;>>toolStripContainer.TopToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.consoleframework.resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm.en;>>toolStripContainer.BottomToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.consoleframework.resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm.en;>>toolStripContainer.ContentPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.consoleframework.resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm.en;>>toolStripContainer.LeftToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.consoleframework.resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm.en;>>toolStripContainer.Name";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.consoleframework.resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm.en;>>toolStripContainer.RightToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.consoleframework.resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ConsoleForm.en;>>toolStripContainer.TopToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;>>toolStripContainer.BottomToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;>>toolStripContainer.ContentPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;>>toolStripContainer.LeftToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;>>toolStripContainer.Name";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;>>toolStripContainer.RightToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;>>toolStripContainer.TopToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor;toolStripContainer.Text";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.BottomToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.ContentPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.LeftToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.Name";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.RightToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.TopToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripContainer.Text";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;>>toolStripContainer.Name";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;>>toolStripContainer.RightToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;>>toolStripContainer.TopToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;toolStripContainer.Text";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;toolStripContainer.Text";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;>>toolStripContainer.BottomToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;>>toolStripContainer.ContentPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl.en;>>toolStripContainer.LeftToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;>>toolStripContainer.BottomToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;>>toolStripContainer.ContentPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;>>toolStripContainer.LeftToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;>>toolStripContainer.Name";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;>>toolStripContainer.RightToolStripPanel.Parent";
                        /// string resKeyToolStripContainer = @"RKB1[Microsoft.MOM.UI.Console];toolStripContainer;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptEditor.en;>>toolStripContainer.TopToolStripPanel.Parent";
                        #endregion
                        string resKeyAddTo = @"RKB1[Microsoft.MOM.UI.Console];Add To;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;ContextMenuAddItemText";
                        #region "Add To" Class = "WindowsForms10.Window.808.app.0.3551b1b" Type = "menu item"
                        /// string resKeyAddTo = @"RKB1[Microsoft.MOM.UI.Console];Add To;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources.en;ContextMenuAddItemText";
                        #endregion
                        string resKeyNewComponent = @"RKB1[Microsoft.MOM.UI.Console];New Component Group...;ManagedString;$.\Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;ContextMenuItemTextNewServiceComponent";
                        #region "New Component Group..." Class = "WindowsForms10.Window.808.app.0.3551b1b" Type = "menu item"
                        /// string resKeyNewComponent = @"RKB1[Microsoft.MOM.UI.Console];New Component Group...;ManagedString;$.\en\microsoft.mom.ui.components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources.en;ContextMenuItemTextNewServiceComponent";
                        #endregion


                        /// LanguageNeutral Strings
                        LanguageNeutralString langNeutralService = new LanguageNeutralString(@"Service");
                        LanguageNeutralString langNeutralDropDown = new LanguageNeutralString(@"DropDown");

                        /// The following strings were not globalized:
                        /// Service
                        /// DropDown

                        #endregion Resource Keys

                        // Left Button Click - "grouping" named "Service" in window "toolStripContainer"
                        screenElement = ScreenElement.FromPartialQueryId(@";Name => '{0}' && ClassName => 'WindowsForms10.Window.8.app';[VisibleOnly]Name = '{1}' && Role = 'grouping'", new string[] { resKeyToolStripContainer, langNeutralService });
                        screenElement.LeftButtonClick(64, 14);

                        // Left Button Click - "list item" named "Operations Manager Management Group" in window "toolStripContainer"
                        screenElement = ScreenElement.FromPartialQueryId(@";Name => '{0}' && ClassName => 'WindowsForms10.Window.8.app';[VisibleOnly]ControlName = 'listViewSCInstances';Role = 'list item'", new string[] { resKeyToolStripContainer });
                        screenElement.LeftButtonClick(95, 10);

                        // Right Button Click - "list item" named "Operations Manager Management Group" in window "toolStripContainer"
                        screenElement = ScreenElement.FromPartialQueryId(@";Name => '{0}' && ClassName => 'WindowsForms10.Window.8.app';[VisibleOnly]ControlName = 'listViewSCInstances';Role = 'list item'", new string[] { resKeyToolStripContainer });
                        screenElement.RightButtonClick(96, 10);

                        // Left Button Click - "menu item" named "Add To" in window ""
                        screenElement = ScreenElement.FromPartialQueryId(@";AccessibleName = '{1}' && Role = 'popup menu';[VisibleOnly]Name = '{0}' && Role = 'menu item'", new string[] { resKeyAddTo, langNeutralDropDown });
                        screenElement.LeftButtonClick(-1, -1);

                        // Left Button Click - "menu item" named "New Component Group..." in window ""
                        screenElement = ScreenElement.FromPartialQueryId(@";AccessibleName = '{1}' && ClassName => 'WindowsForms10.Window.808.app' && Role = 'popup menu';Name = '{0}' && Role = 'menu item';[VisibleOnly]Name = '{2}' && Role = 'menu item'", new string[] { resKeyAddTo, langNeutralDropDown, resKeyNewComponent });
                        screenElement.LeftButtonClick(58, 13);
                        */

                    }
                    catch (VarFail log)
                    {
                        throw new VarFail(log.ToString());
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        if (null == ctxMenu)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                "Maui can't find context menu.");
                        }
                        else if (null == subMenu)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                "Maui can't find context menu's items.");
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Utilities.LogMessage("Ignore this ArgumentOutOfRangeException, menu has been executed");
                    }

                    if (x == 0)
                    {
                        // look for Create New Service Component Group dialog
                        try
                        {
                            CreateNewComponentGroupDialog dialog = new CreateNewComponentGroupDialog(this.app);
                            dialog.NameYourComponentGroupText = list.Items[x].Text + " Group";
                            dialog.ClickOK();
                            try
                            {
                                // check for Replace Visible Object Type dialog
                                ReplaceVisibleObjectTypeDialog dialog2 = new ReplaceVisibleObjectTypeDialog(this.app);
                                // OK, may mean the new scg is not visible in the NavPane.
                                dialog2.ClickOK();
                            }
                            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                            {
                                // continue processing method
                            }

                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                "Clicking the Object's submenu should always produce the Create Component Group dialog; but this time, it didn't.");
                        }
                    }
                    Utilities.LogMessage("Successfully added Distributed Application component to distributed application.");
                }
            }
            catch (VarFail info)
            {
                throw new VarFail(info.ToString());
            }
            catch (Exception ax)
            {
                throw new ApplicationException("Cannot Add instance to distributed application.\n\nAdditional information:\n", ax);
            }
        }

        internal DesignSurface AddInternal(string name, int templateIndex, NewOption newOption, string description, string destinationMP)
        {
            Utilities.LogMessage("");
            Utilities.LogMessage("Entering AddInternal().");
            // open the Create a new distributed application dialog by the given name
            OpenNewDialog(newOption);
            // fill out the dialog and add it to open services list
            serviceName = this.TestNewDialog(name, templateIndex, description, destinationMP);

            DesignSurface ds = new DesignSurface(app, serviceName);

            //add a Service instance to the new app
            //TODO: choice of what component(s) to add is a function of template used
            // and of design goals for that template. add this info to the varmap, and have
            // AddInstanceToComponentGroup() dereference that data
            this.AddInstanceToComponentGroup(ds);

            this.AddServiceToCache(serviceName, ds);
           
            return ds;
        }

        //TODO: generalize by selecting different mechanisms
        //NOTE: Edit main menu has no equivalent to Edit Action or Edit ctx menu
        public string ChangeRandomGridRow(Action action,string instanceName)
        {
            Utilities.LogMessage("");
            Utilities.LogMessage("Entering ChangeRandomGridRow with action, " + action.ToString(), true);
            app.BringToForeground();
            if (!app.ViewPane.Extended.IsActive)
            {
                app.ViewPane.Extended.SetFocus();
                Utilities.TakeScreenshot("ClickViewPane");
            }

            MomControls.GridControl servicesGrid = app.ViewPane.Grid;
            servicesGrid.Click();

            Utilities.LogMessage("Selecting grid value is: " + instanceName);

            DataGridViewRow row = servicesGrid.FindData(instanceName, Strings.ServiceNameColumnNumber);
            if (null == row) throw new ApplicationException("Cannot select " + instanceName);

            row.AccessibleObject.Click();
            Utilities.LogMessage("About to " + action + " " + instanceName + ".");
            DesignSurface designSurface = null;
            switch ((int)action)
            {
                case (int)Action.Delete:
                    designSurface = DeleteServiceInternal(designSurface);
                    break;
                case (int)Action.Edit:
                    designSurface = EditServiceInternal(designSurface);
                    break;
            }
            return instanceName;
        }

        internal void CloseSaveServiceDialog(bool confirm)
        {
            Utilities.LogMessage("");
            Utilities.TakeScreenshot("Entering CloseSaveServiceDialog");
            Window dialogWindow = null;
            string dialogTitle = Strings.ServiceDesigner;
            string caption = null;
            Utilities.LogMessage("CloseSaveServiceDialog::Creating a window to handle the " + dialogTitle + " dialog...");
            try
            {
                dialogWindow = new Maui.Core.Window(
                    dialogTitle,
                    Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                    this.app,
                    10000);
            }
            catch
            {
                Utilities.LogMessage("CloseSaveServiceDialog::waiting 10 seconds for " + dialogTitle + " dialog to appear...");
                Sleeper.Delay(10000);
                int i = 0;
                while (i < 5)
                {
                    Utilities.TakeScreenshot("try " + i);
                    Utilities.LogMessage("Attempting try " + i + " to get save dialog.");
                    try
                    {
                        dialogWindow = new Maui.Core.Window(
                            dialogTitle,
                            Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                            WindowClassNames.Dialog,
                            Maui.Core.Utilities.StringMatchSyntax.WildCard,
                            this.app,
                            1000);
                        break;
                    }
                    catch { }
                    i++;
                }
            }
            if (dialogWindow != null)
            {
                // create the corresponding button and click it
                Maui.Core.WinControls.Button button = null;

                if (confirm == true)
                {
                    // use the "Yes" button
                    caption = Core.Console.ConsoleApp.Strings.SystemYesButton;
                    Core.Common.Utilities.LogMessage("CloseSaveServiceDialog::Looking for a 'Yes' button with caption:  '" + caption);
                }
                else
                {
                    // use the "No" button
                    caption = Core.Console.ConsoleApp.Strings.SystemNoButton;
                    Core.Common.Utilities.LogMessage("CloseSaveServiceDialog::Looking for a 'No' button with caption:  '" + caption);
                }

                Core.Common.Utilities.LogMessage("CloseSaveServiceDialog::Creating a button on window:  '" + dialogWindow.Caption + "'");

                // create and click the button
                button = new Maui.Core.WinControls.Button(
                            dialogWindow,
                            caption,
                            Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                            Maui.Core.WindowClassNames.Button,
                            Maui.Core.Utilities.StringMatchSyntax.ExactMatch);

                button.Click();
            }
            else
            {
                Utilities.LogMessage("Close dialog not found. This may be fine if the service wasn't dirty.");
            }
        }

        internal void CloseServiceInternal(CloseOption closeOption)
        {
            Utilities.LogMessage("");
            Utilities.LogMessage("Entering CloseService using " + closeOption.ToString() + ".",true);

            Mom.Test.UI.Core.Console.ServiceDesigner.DesignSurface designSurface = new
               Mom.Test.UI.Core.Console.ServiceDesigner.DesignSurface(
               this.app);

            if (null != designSurface)
            {
                string serviceName = designSurface.Caption;
                Utilities.LogMessage("Closing " + serviceName);
                bool prompt = designSurface.Caption.EndsWith("*");
                Utilities.LogMessage("The DAD is " + ((prompt) ? "NOT" : "") + " saved.");

                switch (closeOption)
                {
                    case CloseOption.CloseFromFileClose:
                        app.ExecuteWindowMenuItem(designSurface, Strings.MenuBarFileOption, Strings.FileMenuCloseOption);
                        break;
                    // i don't think titlebarclose 
                    case CloseOption.CloseByWindowCloseButton:
                    //designSurface.ClickTitleBarClose();
                    //break;
                        designSurface.Extended.CloseWindow();
                        break;
                    case CloseOption.CloseWithCloseHotKey:
                        designSurface.SendKeys(KeyboardCodes.Alt + KeyboardCodes.F4);
                        break;
                }

                if (prompt)
                {
                    CloseSaveServiceDialog(true);
                    bool closeResult = CoreManager.MomConsole.Waiters.WaitForWindowClose(designSurface as Window, Constants.OneMinute * 10);
                    if (!closeResult)
                    {
                        throw new Infra.Frmwrk.VarFail("Failed to close the DAD in 10 minutes after saving it.");
                    }
                }
                    
                RemoveServiceFromCache(serviceName);
                // ensure the caption contains no * (because that would create an invalid png file name)
                Utilities.TakeScreenshot(serviceName.Replace("*", "") + " Closed");
            }

        }
        
        internal void CloseServiceDialog(string serviceName)
        {
            foreach (KeyValuePair<string, DesignSurface> service in services)
            {
                string serviceCaption = null;
                try
                {
                    serviceCaption = service.Key;
                    if (serviceCaption.Contains(serviceName))
                    {
                        Utilities.LogMessage("Closing " + serviceCaption);
                        DesignSurface dialog = (DesignSurface)service.Value;
                        dialog.Extended.SetFocus();
                        app.ExecuteWindowMenuItem(dialog, Strings.MenuBarFileOption, Strings.FileMenuCloseOption);
                        services.Remove(serviceCaption);
                        break;
                    }
                }
                catch (Exception x)
                {
                    Utilities.LogMessage("There was a problem closing service, " + serviceCaption + ".");
                    Utilities.LogMessage(x.ToString());
                }
            }
        }

        internal DesignSurface DeleteServiceInternal(DesignSurface designSurface)
        {
            Utilities.LogMessage("Deleting " + serviceName + ".");
            try
            {
                // if serviceName is already open, delete it from its own File menu...
                // TODO enable all model-generated tests to ensure we can correctly 
                // delete one of many open dialogs
                designSurface = GetServiceDialogFromCache(serviceName);
                string dialogTitle = null;
                if (null == designSurface)
                {
                    dialogTitle = Strings.ConfirmServiceDeleteDialogTitle;
                    Commands.EditDelete.Execute(app);
                    app.ConfirmChoiceDialog(true, dialogTitle);
                    // note: deleting from grid does not have a modal entity other than hourglass cursor,
                    // and this may be a bug.
                    Utilities.LogMessage("Deleted " + serviceName + " from ViewPane grid.");
                }
                else
                {
                    designSurface.WaitForResponse();
                    app.ExecuteWindowMenuItem(designSurface, Strings.MenuBarFileOption, Strings.FileMenuDeleteOption);
                    app.ConfirmChoiceDialog(true, Strings.ServiceDesigner);
                    Utilities.LogMessage("Waiting for 'Deleting distributed application...' to disappear...");
                    // fix bug 71048 -- wait for designer's modal dialog.
                    // ;Name => 'OperationInProgressForm' && ClassName => 'WindowsForms10.Window.8.app';ControlName = 'panel';Role = 'client'
                    // TODO: this fix is expedient, but may not be best long run strategy (for it assumes
                    // after deleting caption from designer, designer caption is literaly "Service Designer".
                    // also, there's a danger that this loop can be infinite.
                    while (designSurface.Caption != Strings.ServiceDesigner) { }

                    //todo: wire client to listen for this event and call oracle, if they are available.
                    this.OnDistributedApplicationChanged(new ModelEventArgs(Action.Delete, serviceName));

                    Utilities.LogMessage("Designer deleted " + serviceName + ".");
                }
                RemoveServiceFromCache(serviceName);
            }
            catch (Maui.Core.Command.Exceptions.MenuItemNotEnabledException)
            {
                if (serviceName == Strings.MomMgmtGroup)
                {
                    Utilities.LogMessage("Negative test passed. Cannot delete " + Strings.MomMgmtGroup);
                }
            }
            return designSurface;
        }

        internal DesignSurface OpenDesignSurfaceInternal()
        {
            DesignSurface designSurface;

            Utilities.LogMessage("OpenDesignSurfaceInternal- " + serviceName);

            // if serviceName is already open, select it
            // TODO: enable all model-generated tests to test for handling multiple designers.
            designSurface = GetServiceDialogFromCache(serviceName);
            if (null == designSurface)
            {
                // else click Edit link to open service
                this.app.ActionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration,
                    Core.Console.NavigationPane.Strings.MonConfigTreeViewServices,
                    Core.Console.NavigationPane.Strings.ActionServices,
                    Core.Console.NavigationPane.Strings.ActionEditService);
                Utilities.LogMessage("waiting for " + serviceName + "...");
                Utilities.LogMessage("");
                int i = 0;
                int retryLimit = 3;

                while (i < retryLimit)
                {
                    try
                    {
                        // wait for service to load...
                        designSurface = new DesignSurface(app, serviceName);
                        if (null != designSurface && designSurface.Caption.Contains(serviceName))
                        {
                            Utilities.LogMessage(serviceName + " found. Executing menu item...");
                            break;
                        }
                    }
                    catch
                    {
                        i++;
                        Utilities.LogMessage("On try " + i + " to load " + serviceName);
                    }
                }

                if (i == retryLimit) throw new ApplicationException("Cannot find " + serviceName + " in " + retryLimit + " tries.");
                
                // add new designer to cache
                AddServiceToCache(serviceName, designSurface);
            }
            designSurface.Extended.State = WindowState.Maximize;
            designSurface.Extended.App.BringToForeground();
            designSurface.Extended.SetFocus();

            Utilities.TakeScreenshot("OpenDesignSurfaceInternal-" + serviceName);
            Utilities.LogMessage("OpenDesignSurfaceInternal::Ready:" + serviceName);
            return designSurface;
        }

        internal DesignSurface EditServiceInternal(DesignSurface designSurface)
        {
            Utilities.LogMessage("Editing " + serviceName + ".");
            try
            {
                designSurface = OpenDesignSurfaceInternal();
                app.ExecuteWindowMenuItem(designSurface, Strings.MenuBarFileOption, Strings.FileMenuPropertiesOption);
                int retry = 0;
                int maxRetry = 3;
                while (retry < maxRetry)
                {
                    try
                    {
                        retry++;
                        ////TODO: mechanize Edit modality
                        // so change something (either from properties or design surface -- randomly
                        // choose which change mechanism and which tactic to change
                        DistributedApplicationPropertiesDialog dialog = new DistributedApplicationPropertiesDialog(app);
                        Utilities.TakeScreenshot("SuccessGetDistributedApplicationPropertiesDialog");
                        dialog.DistributedApplicationNameText += "-New ";
                        //TODO: alternate between OK and Cancel, and ensure the oracle handles both
                        dialog.ClickOK();
                        break;
                    }
                    catch (Dialog.Exceptions.WindowNotFoundException)
                    {                        
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("FailOpenDistributedApplicationPropertiesDialog");
                            throw new VarFail("Failed to open Distributed Application Properties Dialog after" + maxRetry + "tries by menu bar File->Properties.");
                        }
                        Utilities.LogMessage("Attempt " + retry + " of " + maxRetry + " to open Distributed Application Properties Dialog.");
                        Utilities.TakeScreenshot("Re-openDialogBefore" + retry);

                        Sleeper.Delay(1000);
                        app.ExecuteWindowMenuItem(designSurface, Strings.MenuBarFileOption, Strings.FileMenuPropertiesOption);

                        Sleeper.Delay(1000);
                        Utilities.TakeScreenshot("Re-openDialogAfter" + retry);
                    }
                }

                //todo: wire client to listen for this event and call oracle, if they are available.
                //TODO: tighten down oracle by confirming that the edited service shows 
                // the new name in the grid (assuming a name change is the edit)
                this.OnDistributedApplicationChanged(new ModelEventArgs(Action.Edit, serviceName));

                this.SaveService();
                this.CloseService();
            }
                //TODO: use MCF's ExpectedException attribute instead of oracling inline below.
            catch (Exception x)
            {
                if (serviceName == Strings.MomMgmtGroup)
                {
                    Utilities.LogMessage("Negative test passed. Cannot edit " + Strings.MomMgmtGroup);
                    Utilities.LogMessage(x.ToString());
                }
            }
            return designSurface;
        }

        internal bool CreateRelationshipInternal(DesignSurface designSurface, string fromComponent, string toComponent)
        {
            string serviceName = designSurface.Caption;
            bool relationshipCreated = false;
            Utilities.LogMessage("");
            Utilities.LogMessage("CreateRelationshipInternal::Creating relationship between " + fromComponent + " and " + toComponent + " on " + serviceName);
            Utilities.TakeScreenshot("ReadyToCreateRelationship");

            try
            {
                // relayout nodes
                Utilities.LogMessage("CreateRelationshipInternal:: relayout...");
                ActiveAccessibility relayoutButton = GetToolbarButton(designSurface, DesignSurface.Strings.Relayout);
                relayoutButton.Click();
                UISynchronization.WaitForProcessReady(designSurface);
                UISynchronization.WaitForUIObjectReady(designSurface);
                designSurface.WaitForResponse();

                // get toolbar button
                Utilities.LogMessage("CreateRelationshipInternal:: getting access to CreateRelationship toolbar button...");
                ActiveAccessibility createRelationshipButton = GetToolbarButton(designSurface, DesignSurface.Strings.CreateRelationship);
                
                // TESTING ONLY
                Utilities.LogMessage("CreateRelationshipInternal:: testing active accessibility...");
                ActiveAccessibility aa = designSurface.Extended.AccessibleObject;
                Utilities.LogMessage("CreateRelationshipInternal:: ChildCount = " + aa.ChildCount);
                Utilities.LogMessage("CreateRelationshipInternal:: Name = " + aa.Name);
                Utilities.LogMessage("CreateRelationshipInternal:: ChildID = " + aa.ChildID);
                Utilities.LogMessage("CreateRelationshipInternal:: RoleText = " + aa.RoleText);
                
                /*
                ActiveAccessibilityCollection aaChildren = aa.Children;
                foreach (ActiveAccessibility a in aaChildren)
                {
                    Utilities.LogMessage("");
                    Utilities.LogMessage("CreateRelationshipInternal:: child.Name = " + a.Name);
                    Utilities.LogMessage("CreateRelationshipInternal:: child.RoleText = " + a.RoleText);
                }*/
                
                // get design surface
                Utilities.LogMessage("CreateRelationshipInternal:: getting design surface...");
                //ActiveAccessibility modelingSurfaceParent = designSurface.Extended.AccessibleObject.FindChild(DesignSurface.Strings.ModelingDesignSurface);
                ActiveAccessibility modelingSurfaceParent = designSurface.Extended.AccessibleObject.FindChild((int)MsaaRole.Client);
                
                if(null == modelingSurfaceParent)
                {
                    Utilities.LogMessage("CreateRelationshipInternal:: modelingSurfaceParent is null");
                }
                ActiveAccessibility modelingSurface = modelingSurfaceParent.FindChild((int)MsaaRole.Diagram);

                if (null == modelingSurface)
                {
                    Utilities.LogMessage("CreateRelationshipInternal:: modelingSurface is null");
                }

                // get node collection
                ActiveAccessibilityCollection allNodes = modelingSurface.Children;
                if (null == allNodes)
                {
                    Utilities.LogMessage("CreateRelationshipInternal:: allNodes is null");
                }

                ActiveAccessibilityCollection componentNodes = GetComponentNodes(allNodes);
                Utilities.LogMessage("CreateRelationshipInternal:: number of components/relationships = " + allNodes.Count);
                Utilities.LogMessage("CreateRelationshipInternal:: number of components = " + componentNodes.Count);

                // get indices of nodes to create relationship between
                int fromNode = -1;
                int toNode = -1;

                if (null == fromComponent && null == toComponent)
                {
                    Utilities.LogMessage("CreateRelationshipInternal:: null arguments so choosing random nodes...");
                    if (componentNodes.Count >= 2)
                    {
                        Random random = new Random(Utilities.Seed);
                        // choose any two nodes and randomly create relationship
                        fromNode = random.Next(1, componentNodes.Count);

                        // randomly choose second node until it is not the same as the first node
                        do
                        {
                            toNode = random.Next(1, componentNodes.Count);
                        } while (fromNode == toNode);
                    }
                    else
                    {
                        Utilities.LogMessage("CreateRelationshipInternal:: Two nodes required to create relationship");
                        this.CloseService();
                        return relationshipCreated;
                    }
                }
                else
                {
                    // get node indices
                    fromNode = FindNodeIndex(componentNodes, fromComponent);
                    if (fromNode < 0)
                    {
                        throw new ActiveAccessibility.Exceptions.ChildNotFoundException(fromComponent + " not found");
                    }

                    toNode = FindNodeIndex(componentNodes, toComponent);
                    if (toNode < 0)
                    {
                        throw new ActiveAccessibility.Exceptions.ChildNotFoundException(toComponent + " not found");
                    }
                }

                Utilities.LogMessage("CreateRelationshipInternal:: from node '" + componentNodes[fromNode].Name + "' to '" + componentNodes[toNode].Name + "'"); 

                // push CreateRelationship button to enter mode
                createRelationshipButton.Click();

                // create the relationship!
                componentNodes[fromNode].Click();
                componentNodes[toNode].Click();

                // push CreateRelationship button to undo this mode
                createRelationshipButton.Click();
                    
                this.SaveService();
                this.CloseService();
                Utilities.LogMessage("CreateRelationshipInternal:: new number of components/relationships = " + modelingSurface.Children.Count);
                relationshipCreated = true;
            }
            catch (Exception x)
            {
                Utilities.TakeScreenshot("CreateRelationshipInternal_Exception thrown");
                Utilities.LogMessage(x.ToString());
                throw;
            }
            return relationshipCreated;
        }

        internal ActiveAccessibilityCollection GetComponentNodes(ActiveAccessibilityCollection everyNode)
        {
            ActiveAccessibilityCollection aac = new ActiveAccessibilityCollection();

            foreach(ActiveAccessibility aa in everyNode)
            {
                // only ComponentGroup nodes have Area child
                // relationship lines do not have Area child
                if(null != aa.FindChild(DesignSurface.Strings.Area, (int)MsaaRole.Diagram))
                {
                    // has Area so add this ComponentGroup to return collection
                    aac.Add(aa);
                }
            }

            return aac;
        }

        internal ActiveAccessibility FindNode(ActiveAccessibilityCollection aac, string name)
        {
            foreach (ActiveAccessibility aa in aac)
            {
                if (aa.Name.CompareTo(name) == 0)
                {
                    return aa;
                }
            }

            return null;
        }


        internal int FindNodeIndex(ActiveAccessibilityCollection aac, string name)
        {
            foreach (ActiveAccessibility aa in aac)
            {
                if (aa.Name.CompareTo(name) == 0)
                {
                    return aac.IndexOf(aa);
                }
            }

            return -1;
        }

        internal ActiveAccessibility GetToolbarButton(DesignSurface designSurface, string buttonText)
        {
            ActiveAccessibility toolStripParent = designSurface.Extended.AccessibleObject.FindChild(DesignSurface.Strings.ToolStripContainer, (int)MsaaRole.Client);
            if (null == toolStripParent)
            {
                Utilities.LogMessage("GetToolbarButton:: " + buttonText + " not found in toolstrip");
                return null;
            }
            ActiveAccessibility toolStrip = toolStripParent.FindChild((int)MsaaRole.ToolBar);
            if (null == toolStrip)
            {
                Utilities.LogMessage("GetToolbarButton:: toolbar role " + MsaaRole.ToolBar + " not found in toolstrip");
                return null;
            }
            ActiveAccessibility button = toolStrip.FindChild(buttonText, (int)MsaaRole.PushButton);
            if (null == button)
            {
                Utilities.LogMessage("GetToolbarButton:: " + buttonText + " not found in toolstrip");
            }

            return button;
        }

        /// <summary>
        /// Get specified service designer from cache
        /// </summary>
        internal DesignSurface GetServiceDialogFromCache(string serviceName)
        {
            foreach (KeyValuePair<string, DesignSurface> service in services)
            {
                string serviceCaption = null;
                try
                {
                    serviceCaption = service.Key;
                    if (serviceCaption.Contains(serviceName))
                    {
                        Utilities.LogMessage("Selecting " + serviceCaption);
                        DesignSurface dialog = (DesignSurface)service.Value;
                        if (!dialog.Extended.IsActive)
                        {
                            dialog.Extended.SetFocus();
                        }
                        return (dialog);
                    }
                }
                catch (Exception x)
                {
                    Utilities.LogMessage("There was a problem accessing design surface for service, " + serviceCaption + ".");
                    Utilities.LogMessage(x.ToString());
                }
            }
            return (null);
        }

        /// <summary>
        /// Enables explicit or random creation of New Service.
        /// </summary>
        /// <param name="newOption">option from enum NewOption</param>
        public void OpenNewDialog(NewOption newOption)
        {
            if (newOption == NewOption.Random)
            {
                string[] newOptions = Enum.GetNames(typeof(NewOption));
                newOption = (NewOption)Enum.Parse(typeof(NewOption),
                   newOptions[new Random(Utilities.Seed).Next(0, newOptions.Length)]);
            }
            this.OpenNewDialogInternal(newOption);
        }

        internal void OpenNewDialogInternal(NewOption newOption)
        {

            // at the moment, we only create through Action
            Utilities.LogMessage("Creating service using " + newOption.ToString() + ".");
            // reclicking a link can be a problem sometimes because maui returns an invalid handle exception.
            // so try twice, if necessary.
            for (int i = 1; i < 3; i++)
            {
                try
                {
                    switch (newOption)
                    {
                        case NewOption.Random:
                        case NewOption.CtxMenu:
                        case NewOption.MainMenu:
                        case NewOption.Action:
                            String CreateService = Core.Console.NavigationPane.Strings.ActionCreateANewService.Replace("&", String.Empty);
                            Utilities.LogMessage("Clicking '" + CreateService + "'");
                            this.app.ActionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration,
                                Core.Console.NavigationPane.Strings.MonConfigTreeViewServices,
                                Core.Console.NavigationPane.Strings.ActionServices,
                                CreateService);
                            break;
                        default:
                            throw new ArgumentException("Could not process passed in enum, " + newOption + ".");
                    }
                    break;
                }
                catch (Exception x)
                {
                    Utilities.TakeScreenshot("Consumed exception. Test continues.");
                    Utilities.LogMessage(x.Message);
                }
            }
        }

        [Obsolete]
        internal void OldAddInstanceToComponentGroup()
        {
            // find toolstripContainer then drill into these indexes
            Window tsc = Utility.GetDialogOrWindow(app, Strings.ToolStripContainer, 1000, true, true);
            ActiveAccessibility toolStripContainer = tsc.Extended.AccessibleObject;
            // then drill into these indexes
            int[] steps = { 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 1, 3, 0, 3 };
            ActiveAccessibilityCollection scgs = toolStripContainer.Children;

            foreach (int i in steps)
            {
                //scgs = getSubSteps(scgs, i);
            }
            int x = 0;
            // all other windows s/b roletext grouping
            // service component groups should now all have names
            Utilities.LogMessage("Looking for instance data in objects:");
            foreach (ActiveAccessibility node in scgs)
            {
                if (null == node.Name)
                {
                    Utilities.LogMessage("node Name property is null.");
                    continue;
                }
                Utilities.LogMessage(node.Name);
                if (!node.Name.StartsWith("Organize"))
                {
                    node.Click();
                    try
                    {
                        ListView list = new ListView(tsc, "listViewSCInstances");
                        if (list.Items.Count > 0)
                        {
                            x = new Random(Utilities.Seed).Next(0, list.Items.Count);
                            Utilities.LogMessage("Choosing item " + x + " from " + node.Name);
                            list.Click();
                            list.Items[x].Click(MouseClickType.SingleClick, MouseFlags.RightButton);
                            Menu ctxMenu = new Menu(Constants.DefaultContextMenuTimeout);
                            ctxMenu.ExecuteMenuItem("Add To");
                            Menu subMenu = new Menu(5);//(Constants.DefaultContextMenuTimeout);
                            x = new Random(Utilities.Seed).Next(0, subMenu.MenuItems.Count);
                            Utilities.LogMessage("Choosing item " + x + " (" +
                                subMenu.MenuItems[x] + ") from submenu");
                            // now, if there is only one submenu item and it is enabled, then
                            // we need to create a new scg (as if we had clicked the Add Service
                            // Component toolbar button).
                            // else if there are more than two entries, we should accept the default
                            // second entry (which should put the item in the correct scg).
                            // in either case, we should look to that new or added to scg and ensure 
                            // that we have added the item correctly.
                                subMenu.MenuItems[x].Execute();

                                if (x == 0)
                                {
                                    // look for Create New Service Component Group dialog
                                    try
                                    {
                                        CreateNewComponentGroupDialog dialog = new CreateNewComponentGroupDialog(this.app);
                                        dialog.NameYourComponentGroupText = list.Items[x].Text + " Group";
                                        dialog.ClickOK();
                                        try
                                        {
                                            // check for Replace Visible Object Type dialog
                                            ReplaceVisibleObjectTypeDialog dialog2 = new ReplaceVisibleObjectTypeDialog(this.app);
                                            // OK, may mean the new scg is not visible in the NavPane.
                                            dialog2.ClickOK();
                                        }
                                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                                        {
                                            // continue processing method
                                        }

                                    }
                                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                                    {
                                        throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                                            "Clicking the Object's submenu should always produce the Create Component Group dialog; but this time, it didn't.");
                                    }
                                }
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.LogMessage(node.Name + " has no items");
                        Utilities.LogMessage(ex.ToString());
                    }
                }
            }
        }

        internal int AddServiceToCache(string serviceName, DesignSurface ds)
        {
            if (!String.IsNullOrEmpty(serviceName))
            {
                string myServiceName = serviceName.Replace("*", "");

                if (!services.ContainsKey(myServiceName))
                {
                    Utilities.LogMessage("AddServiceToCache:: adding service to cache: " + myServiceName);
                    services.Add(myServiceName, ds);
                }
            }

            Utilities.LogMessage("These " + services.Count + " services are currently open:");
            foreach (string servName in services.Keys)
            {
                Utilities.LogMessage("\t" + servName);
            }

            return services.Count;
        }

        internal bool RemoveServiceFromCache(string serviceName)
        {
            string serviceCaption = null;
            bool serviceRemoved = false;

            try
            {
                foreach (KeyValuePair<string, DesignSurface> service in services)
                {
                    serviceCaption = service.Key;
                    if (serviceCaption.Contains(serviceName))
                    {
                        Utilities.LogMessage("RemoveServiceFromCache:: removing: " + serviceCaption);
                        services.Remove(serviceCaption);
                        serviceRemoved = true;
                    }
                    else
                    {
                        Utilities.LogMessage("RemoveServiceFromCache:: keeping in cache: " + serviceCaption);
                    }
                }
            }
            catch (Exception x)
            {
                Utilities.LogMessage("There was a problem removing service, " + serviceCaption + " from the services cache.");
                Utilities.LogMessage(x.ToString());
            }
            return serviceRemoved;
        }

        internal void SaveServiceInternal(SaveOption saveOption)
        {
            Utilities.LogMessage("");
            Utilities.LogMessage("Entering SaveService using " + saveOption.ToString() + ".",true);
            // we shouldn't be on just any design surface instance, we should be on the currently focused one, or
            // else the test fails because the focus is not on a design surface.
            Mom.Test.UI.Core.Console.ServiceDesigner.DesignSurface designSurface = new
               Mom.Test.UI.Core.Console.ServiceDesigner.DesignSurface(
               this.app);
            if (null == designSurface)
            {
                throw new NullReferenceException("Cannot create an instance of ServiceDesignerDesignSurface.");
            }

            switch (saveOption)
            {
                case SaveOption.SaveWithSaveHotKey:
                //TODO: add override to ExecuteWindowMenuItem that accepts hotkey param
                //break;
                case SaveOption.SaveWithSaveToolbarButton:
                // simply can't get toolbars to work on debi machines (work fine on dev box)

                //Toolbar toolbar = new Toolbar(designSurface);
                //Sleeper.Delay(2000);
                //Utilities.TakeScreenshot("IsToolbarReady");
                //foreach (ToolbarItem item in toolbar.ToolbarItems)
                //{
                //    Utilities.LogMessage("On toolbar item: "+ item.Text);
                //    if (item.Text == "Save")
                //    {
                //        Utilities.LogMessage("Clicking Save toolbar button");
                //        item.Click(MouseClickType.SingleClick);
                //        break;
                //    }
                //}
                //break;
                case SaveOption.SaveFromFileSave:
                    //Maui4.0: Failed to find (File->)Save, only (File->)New... can not be found. Use other way to save
                    //app.ExecuteWindowMenuItem(designSurface, Strings.MenuBarFileOption, Utilities.RemoveAcceleratorKeys(Strings.FileMenuSaveOption));
                    Button saveButton = new Button(designSurface, new QID(";[UIA, VisibleOnly]Name='" + Strings.FileMenuSaveOption.Replace("&", "") + "' && Role = 'push button'"));
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(saveButton, Constants.OneSecond * 10);
                    saveButton.Extended.Click();
                    break;
            }

            int timeout = 600;
            int retry = 0;

            Utilities.TakeScreenshot("Save Start");
            Utilities.LogMessage("DA Designer is Enabled:'" + designSurface.IsEnabled + "'.");
            // Verify status of DAD's IsEnabled until save completely
            while (retry < timeout)
            {
                retry++;
                Utilities.LogMessage("waited " + retry + " seconds for save to complete..");
                if (designSurface.IsEnabled)
                {
                    if (!designSurface.Caption.EndsWith("*"))
                    {
                        break;
                    }
                    else
                    {
                        Button saveButton = new Button(designSurface, new QID(";[UIA, VisibleOnly]Name='" + Strings.FileMenuSaveOption.Replace("&", "") + "' && Role = 'push button'"));
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(saveButton, Constants.OneSecond * 10);
                        saveButton.Extended.Click();
                    }
                }
                Sleeper.Delay(Constants.OneSecond);
            }
            Utilities.LogMessage("DA Designer is Enabled:'" + designSurface.IsEnabled + "'..");
            Utilities.LogMessage("Current Status:"); 
            Utilities.LogMessage("Current CPU Usage: " + Utilities.CurrentCpuUsage + "%");
            Utilities.LogMessage("    Available RAM: " + Utilities.AvailableRAM + "MB");
            Utilities.TakeScreenshot("Save Over");

            if (!designSurface.IsEnabled)
            {
                throw new Infra.Frmwrk.VarFail("Failed to save Distributed Application Designer in "+timeout +" seconds.");
            }
        }

        /// <summary>
        /// Fills out a new distributed application dialog using the optional serviceName and optional template index.
        /// </summary>
        /// <param name="name">Optional name of service</param>
        /// <param name="templateIndex">Optional index into the template dropdown</param>
        /// <param name="description">Optional description text</param>
        /// <param name="destinationMP">optional destination MP</param>
        /// <returns>name of the new distributed application</returns>
        public string TestNewDialog(string name, int templateIndex, string description, string destinationMP)
        {
            string newName = name;            
            int index = templateIndex;
            CreateDistributedApplicationDialog newDialog = null;
            int serviceCount = 0;
            bool keyBoardOnly = false;

            // getting a reference to the Create a new service dialog is very tricky.
            // this first try just uses wildcard search and keeps trying until the new
            // window gets a reference to the template dropdown (we can get a window ref and 
            // still not get a control ref, so we keep trying till we get both).
            int tries = 0;
            int retries = 10;
            while (tries < retries)
            {
                try
                {
                    newDialog = new CreateDistributedApplicationDialog(this.app);
                    // we have to be able to check that the OK button is enabled even 
                    // when using keyboard input only.
                    // we'll check that we can access the OK button here so we can retry
                    // because sometimes we can get the dialog but will fail when accessing the OK button
                    bool tempBool = newDialog.Controls.OKButton.IsEnabled;
                    break;
                }
                catch
                {
                    Utilities.TakeScreenshot("Trying " + tries + " times to access CreateDistributedApplicationDialog control.");
                }
                finally
                {
                    Utilities.LogMessage("Trying " + tries + " times to access CreateDistributedApplicationDialog control.");
                    tries++;
                }
            }
            if (tries == retries || newDialog == null) throw new ApplicationException("Could not find CreateDistributedApplicationDialog control in " + retries + " tries.");

            tries = 0;
            while (tries < retries)
            {
                try
                {
                    serviceCount = newDialog.Controls.TemplateListBox.Count;
                    break;
                }
                catch
                {
                    Utilities.TakeScreenshot("Trying " + tries + " times to access TemplateListBox control.");
                }
                finally
                {
                    Utilities.LogMessage("Trying " + tries + " times to access TemplateListBox control.");
                    tries++;
                }
            }
            if (tries == retries) 
            {
                //// throw new ApplicationException("Could not find TemplateListBox control in " + retries + " tries.");
                Utilities.LogMessage("Could not find TemplateListBox control in " + retries + " tries.");
                keyBoardOnly = true;
            }

            // if we didn't pass in a template index, choose one at random.
            if (index == -1 || index > serviceCount - 1)
            {
                index = new Random(Utilities.Seed).Next(0, serviceCount);
                Utilities.LogMessage("Calculating random value for index: " + index + ".");
            }

            // if we didn't pass in a serviceName, choose one at random
            string momDialogTitle = null;
            if (string.IsNullOrEmpty(newName))
            {
                Utilities.LogMessage("Generating random name for new service.");
                newName = @"Service" + new Random(Utilities.Seed).Next(1,10000).ToString();
                serviceName = newName;
                // we only need the momDialogTitle if we are creating a new service (because we might
                // randomly choose a name previously used)
                momDialogTitle = Strings.MomDialogTitle;
            }

            if (keyBoardOnly)
            {
                Utilities.LogMessage(String.Format(
                    "New dialog open, using keyboard hot keys only, ready for name {0} and Template selection {1}",
                    newName,
                    index));
            }
            else
            {
                Utilities.LogMessage(String.Format(
                    "New dialog open, and NameTextBox enabled is {0} and is ready for name {1} and Template selection is {2}",
                    newDialog.Controls.NameTextBox.IsEnabled,
                    newName,
                    index),true);
            }
            Utilities.TakeScreenshot("ReadyToUpdateCreateNewServiceDialog");
            // update the dialog

            Utilities.LogMessage("Entering name " + newName);
            if (keyBoardOnly)
            {
                newDialog.SendKeys("%n");
                newDialog.SendKeys(newName);
            }
            else
            {
                newDialog.NameText = newName;
            }
            
            //TODO: enable casting to IVarContext
            //newDialog.DescriptionOptionalText = ((IVarContext)Mcf.FrameworkContext).Set + "." +
            //    ((IVarContext)Mcf.FrameworkContext).Level + "." +
            //    ((IVarContext)Mcf.FrameworkContext).VarID + "(on " + DateTime.Now.ToLocalTime() + ")";

            Utilities.LogMessage("Entering description " + description);
            if (null != description)
            {
                if (keyBoardOnly)
                {
                    newDialog.SendKeys("%d");
                    newDialog.SendKeys(description);
                }
                else
                {
                    newDialog.DescriptionOptionalText = description;
                }
            }
            else
            {
                if (keyBoardOnly)
                {
                    newDialog.SendKeys("%d");
                    newDialog.SendKeys("KEYBOARD ONLY");
                }
                else
                {
                    newDialog.DescriptionOptionalText = "TEST";
                }
            }

            Utilities.LogMessage("Selecting template index " + index);
            if (keyBoardOnly)
            {
                int maximumTries = 30;
                int numTries = 0;

                while (newDialog.Controls.OKButton.IsEnabled && numTries < maximumTries)
                {
                    newDialog.SendKeys("%t");
                    newDialog.SendKeys(Core.Common.KeyboardCodes.Space);
                    Sleeper.Delay(100);
                    numTries++;
                    Utilities.LogMessage("Pushing space highlight template listview...");
                }

                for (int x = 0; x < templateIndex; x++)
                {
                    newDialog.SendKeys(Core.Common.KeyboardCodes.DownArrow);
                    Utilities.LogMessage("Pushing down arrow " + x + " times to select template " + templateIndex);
                }
            }
            else
            {
                try
                {
                    if (newDialog.Controls.TemplateListBox.Count > index)
                    {
                        newDialog.Controls.TemplateListBox.SelectItem(index);
                    }
                } catch (Exception e)
                {
                    Utilities.TakeScreenshot("TestNewDialog thinks the template listbox aint here");
                    Utilities.LogMessage("TestNewDialog thinks the template listbox aint here");
                    Utilities.LogMessage(e.Message);
                }
            }

            Utilities.LogMessage("Entering destinationMP " + destinationMP);
            if (string.IsNullOrEmpty(destinationMP))
            {
                destinationMP = Core.Console.ConsoleConstants.DefaultManagementPackName;
            }

            if (keyBoardOnly)
            {
                newDialog.SendKeys("%m");

                // this probably won't work if we don't have access to the dialog controls
                // int comboIndex = newDialog.Controls.ManagementPackComboBox.GetIndexByText(destinationMP, true);
                // for (int x = 0; x <= comboIndex; x++)
                // {
                //    newDialog.SendKeys(Core.Common.KeyboardCodes.DownArrow);
                // }
            }
            else
            {
                newDialog.Controls.ManagementPackComboBox.SelectByText(destinationMP);
            }
            

            Utilities.LogMessage("Closing dialog");
            if (keyBoardOnly)
            {
                newDialog.SendKeys(Core.Common.KeyboardCodes.Enter);
            }
            else
            {
                try
                {
                    newDialog.ClickOK();
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    newDialog.SendKeys(Core.Common.KeyboardCodes.Enter);
                }
            }

            if (!CoreManager.MomConsole.WaitForDialogClose(newDialog, 60))
            {
                Utilities.LogMessage("TestNewDialog::window didn't close -- calling function recursively");
                //newDialog.SendKeys(Core.Common.KeyboardCodes.Esc);
  //              DesignSurface ds = new DesignSurface(this.app);
    //            ds.App.BringToForeground();
      //          ds.App.Menu.AccessibleObject.Click();
        //        ds.App.Menu.ExecuteMenuItem(Strings.FileMenuNewOption);
                //this.app.ExecuteWindowMenuItem(GetServiceDialogFromCache(serviceName), Strings.MenuBarFileOption, Strings.FileMenuNewOption);
          //      newName = TestNewDialog(name, templateIndex, description, destinationMP);
            }

            // ensure we can get out of New Service dialog by checking for MOM dialog
            int i = 0;
            int maxTries = 5;
            while (i < maxTries)
            {
                try
                {
                    i++;
                    this.app.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.OK,
                    momDialogTitle,
                    StringMatchSyntax.ExactMatch,
                    MomConsoleApp.ActionIfWindowNotFound.Error);
                }
                catch
                {
                    Utilities.LogMessage(newName + " created. Test continues.");
                    break;
                }

                Utilities.LogMessage("Name used. Regenerating random name .");
                newName = @"Service" + new Random(Utilities.Seed).Next(1, 10000).ToString();
                // let's try again to close the dialog
                if (keyBoardOnly)
                {
                    newDialog.SendKeys("%n");
                    newDialog.SendKeys(newName);
                    newDialog.SendKeys(Core.Common.KeyboardCodes.Enter);
                }
                else
                {
                    newDialog.NameText = newName;
                    try
                    {
                        newDialog.ClickOK();
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        newDialog.SendKeys(KeyboardCodes.Enter);
                    }
                }
            }
            if (i == maxTries)
            {
                this.app.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.OK,
                    momDialogTitle,
                    StringMatchSyntax.ExactMatch,
                    MomConsoleApp.ActionIfWindowNotFound.Ignore);
                Sleeper.Delay(2000);
                newDialog.ClickCancel();
                throw new ApplicationException("The MCF seed has reused the same service names " + maxTries + " times. Please retry test with a different seed.");
            }
            return newName;
        }

        #endregion

        #region Oracling code
        /// <summary>
        /// EventArgs for test oracles listening for events.
        /// </summary>
        public class ModelEventArgs : System.ComponentModel.CancelEventArgs
        {
            Action action;
            object actor;

            //new internal static readonly ModelEventArgs Empty = new ModelEventArgs();
            /// <summary>
            /// Event args for events raised in Test Model
            /// </summary>
            /// <param name="action"></param>
            /// <param name="actor"></param>
            public ModelEventArgs(Action action, object actor)
            {
                this.action = action;
                this.actor = actor;
            }

            /// <summary>
            /// How was the Test Model data changed?
            /// </summary>
            public Action Action
            {
                get { return action; }
                set { action = value; }
            }

            /// <summary>
            /// Which object changed the Test Model data?
            /// </summary>
            public object Actor
            {
                get { return actor; }
                set { actor = value; }
            }

        }

        /// <summary>
        /// Event raised when the ViewPane grid loses a service row
        /// </summary>
        public event EventHandler<ModelEventArgs> DistributedApplicationChanged;
        
        /// <summary>
        /// Raises event if some class (usually a test oracle) has subscribed.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDistributedApplicationChanged(ModelEventArgs e)
        {
            EventHandler<ModelEventArgs> handler = DistributedApplicationChanged;
            if (null != this.DistributedApplicationChanged)
            {
                this.DistributedApplicationChanged(this, e);
            }
        }
        #endregion

    }
}