using System;
using System.Collections.Generic;
using System.Text;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Console.MomControls;
using Maui.Core;
using Maui.Core.Utilities;
using Mom.Test.UI.Core.Common;
using Maui.Core.WinControls;
using Infra.Frmwrk;

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Distributed application helper class
    /// </summary>
    /// <history>
    /// 	[a-mujtch] 10MAY2009 Created
    /// 	[nathd]    14OCT2009 Overloaded AddEntityToComponent to take an additional
    /// 	           string parameter path and modified the code to support this new
    /// 	           parameter. Added a path property to the EntityTargetParam 
    /// 	           class.
    ///    [v-brucec]  07DEC09 Added some retry logic to avoid timing issue.
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DistributedApplicationHelper
    {
        #region Private Members
        /// <summary>
        /// Entity path index in ListViewItem.SubItems collection.
        /// </summary>
        private const int ENTITY_PATH_INDEX = 0;

        /// <summary>
        /// Create Distributed Application Dialog
        /// </summary>
        private CreateDistributedApplicationDialog cachedCreateDistributedApplicationDialog;

        /// <summary>
        /// Service Designer Window
        /// </summary>
        private DesignSurface cachedDesignSurface;

        /// <summary>
        /// Create New Component Group Dialog
        /// </summary>
        private CreateNewComponentGroupDialog cachedCreateNewComponentGroupDialog;

        /// <summary>
        /// Modeling Surface
        /// </summary>
        private ActiveAccessibility modelingSurface;


        /// <summary>
        /// Confirmation dialog
        /// </summary>
        private ServiceDesignerConfirmationDialog cachedServiceDesignerConfirmationDialog;

        /// <summary>
        /// DistributedApplicationPropertiesDialog
        /// </summary>
        private DistributedApplicationPropertiesDialog cachedDistributedApplicationPropertiesDialog;

        /// <summary>
        /// Path of Desktop
        /// </summary>
        private const string PathDesktop="%Desktop%";

        #endregion

        #region Private Cached Properties

        /// <summary>
        /// Modeling Surface ActiveAccessibility object
        /// </summary>
        private ActiveAccessibility ModelingSurface
        {
            get
            {
                if (null == modelingSurface)
                {
                    DesignSurfaceWindow.WaitForResponse();

                    //ActiveAccessibility modelingSurfaceParent = DesignSurfaceWindow.Extended.AccessibleObject.FindChild(DesignSurface.Strings.ModelingDesignSurface);
                    ActiveAccessibility modelingSurfaceParent = DesignSurfaceWindow.Extended.AccessibleObject.FindChild((int)MsaaRole.Client);

                    if (null == modelingSurfaceParent)
                    {
                        throw new ActiveAccessibility.Exceptions.ChildNotFoundException("ModelingSurface:: modelingSurfaceParent is null");
                    }

                    modelingSurface = modelingSurfaceParent.FindChild((int)MsaaRole.Diagram);

                    if (null == modelingSurface)
                    {
                        throw new ActiveAccessibility.Exceptions.ChildNotFoundException("ModelingSurface:: modelingSurface is null");
                    }
                }

                return modelingSurface;
            }
        }

        /// <summary>
        /// Cached ServiceDesignerConfirmationDialog
        /// </summary>
        private ServiceDesignerConfirmationDialog ServiceDesignerConfirmationDialogWindow
        {
            get
            {
                if (this.cachedServiceDesignerConfirmationDialog == null)
                {
                    this.cachedServiceDesignerConfirmationDialog = new ServiceDesignerConfirmationDialog(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this.cachedServiceDesignerConfirmationDialog, Constants.OneMinute);
                }

                return this.cachedServiceDesignerConfirmationDialog;
            }
        }

        /// <summary>
        /// Cached Create New Component Group Dialog
        /// </summary>
        private CreateNewComponentGroupDialog CreateNewComponentGroupDialogWindow
        {
            get
            {
                if (this.cachedCreateNewComponentGroupDialog == null)
                {
                    this.cachedCreateNewComponentGroupDialog = new CreateNewComponentGroupDialog(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this.cachedCreateNewComponentGroupDialog, Constants.OneMinute);
                }

                return this.cachedCreateNewComponentGroupDialog;
            }
        }

        /// <summary>
        /// Cached Create Distributed Application Dialog
        /// </summary>
        private CreateDistributedApplicationDialog CreateDistributedApplicationDialogWindow
        {
            get
            {
                if (this.cachedCreateDistributedApplicationDialog == null)
                {
                    this.cachedCreateDistributedApplicationDialog = new CreateDistributedApplicationDialog(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this.cachedCreateDistributedApplicationDialog, Constants.OneMinute);
                }

                return this.cachedCreateDistributedApplicationDialog;
            }
        }

        /// <summary>
        /// Cached Create Distributed Application Properties Dialog
        /// </summary>
        private DistributedApplicationPropertiesDialog DistributedApplicationPropertiesDialogWindow
        {
            get
            {
                if (this.cachedDistributedApplicationPropertiesDialog == null)
                {
                    this.cachedDistributedApplicationPropertiesDialog = new DistributedApplicationPropertiesDialog(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this.cachedDistributedApplicationPropertiesDialog, Constants.OneMinute);
                }

                return this.cachedDistributedApplicationPropertiesDialog;
            }
        }

        /// <summary>
        /// Cached Service Designer
        /// </summary>
        private DesignSurface DesignSurfaceWindow
        {
            get
            {
                if (this.cachedDesignSurface == null)
                {
                    this.cachedDesignSurface = new DesignSurface(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this.cachedDesignSurface, Constants.OneMinute);
                }

                return this.cachedDesignSurface;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new distributed application template
        /// </summary>
        /// <param name="distributedApplicationParameters">Distributed application parameters</param>
        /// <param name="newComponent">Add Component Name</param>
        /// <param name="newMPName">Save as Template Name</param>
        public void CreateDistributedApplicationTemplate(DistributedApplicationParameters distributedApplicationParameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            //prepare distributed application
            Utilities.LogMessage(currentMethod + ":: Create Distributed Application");
            PrepareDistributedApplication(distributedApplicationParameters.Name,
                distributedApplicationParameters.Description,
                distributedApplicationParameters.Template,
                distributedApplicationParameters.ManagementPackName);

            //create component group
            string newComponentName = distributedApplicationParameters.ComponentGroup[0];
            Utilities.LogMessage(currentMethod + ":: Add Component:" + newComponentName);
            AddComponentGroup(newComponentName);
            Relayout();

            //add entity to component
            Utilities.LogMessage(currentMethod + ":: Add Entity to Component");
            foreach (EntityTargetParam entityTargetParam in distributedApplicationParameters.LinkEntityComponent)
            {
                AddEntityToComponent(entityTargetParam.Entity, entityTargetParam.Target, entityTargetParam.Path);
                Relayout();
            }

            //add entity to component (Then remove the entities)
            Utilities.LogMessage(currentMethod + ":: Add Entity to Component just for deleting later");
            foreach (EntityTargetParam entityTargetParam in distributedApplicationParameters.RemoveEntityFromComponent)
            {
                AddEntityToComponent(entityTargetParam.Entity, entityTargetParam.Target, entityTargetParam.Path);
                Relayout();
            }

            //remove entity
            Utilities.LogMessage(currentMethod + ":: Remove Entity");
            RemoveEntityFromComponent(newComponentName);

            //change object type
            Utilities.LogMessage(currentMethod + ":: Change Object Type");
            ChangeComponentObjectType(newComponentName);

            //remove object type
            Utilities.LogMessage(currentMethod + ":: Remove Object Type");
            RemoveComponentObjectType(newComponentName);

            //remove component
            RemoveComponentGroup(newComponentName);

            Utilities.TakeScreenshot("CreateDistributedApplication");

            //save as template
            Utilities.LogMessage(currentMethod + ":: Save DA As a Template");
            SaveAsTemplate(distributedApplicationParameters.NewMPName, PathDesktop);

            //change ID to an vaild value in new MP
            Utilities.LogMessage(currentMethod + ":: Change ID same as the MP's name for template MP");
            string saveTemplateMPPath=Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+distributedApplicationParameters.NewMPName+".xml";
            ChangeTemplateID(saveTemplateMPPath, distributedApplicationParameters.NewMPName);

            //Save and Close
            Utilities.LogMessage(currentMethod + ":: Save and Close");
            SaveAndClose();
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Create a new distributed application by new template
        /// </summary>
        /// <param name="distributedApplicationParameters"></param>
        public void CreateDistributedApplicationByNewTemplate(DistributedApplicationParameters distributedApplicationParameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            //Import Template MP
            Utilities.LogMessage(currentMethod + ":: Import MP if not exists");
            if (!Core.Common.Utilities.ManagementPackExists(distributedApplicationParameters.ManagementPackName))
            {
                Utilities.LogMessage("CreateDistributedApplicationByNewTemplate:: Importing MP: " + distributedApplicationParameters.ManagementPackName);
                string newTemplateMP = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + distributedApplicationParameters.ManagementPackName + ".xml";
                Core.Common.Utilities.ImportManagementPack(newTemplateMP);
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 30);
            }
            else
            {
                Utilities.LogMessage("Did not Import " + distributedApplicationParameters.ManagementPackName + "; already exists");
            }

            //prepare distributed application
            Utilities.LogMessage(currentMethod + ":: Create Distributed Application");
            PrepareDistributedApplication(distributedApplicationParameters.Name,
                distributedApplicationParameters.Description,
                distributedApplicationParameters.Template,
                distributedApplicationParameters.ManagementPackName);

            Utilities.LogMessage(currentMethod + ":: Save DA As a Template");
            SaveAndClose();

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Creates a new distributed application
        /// </summary>
        /// <param name="distributedApplicationParameters">Distributed application parameters</param>
        public void CreateDistributedApplication(DistributedApplicationParameters distributedApplicationParameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            //prepare distributed application
            PrepareDistributedApplication(distributedApplicationParameters.Name,
                distributedApplicationParameters.Description,
                distributedApplicationParameters.Template,
                distributedApplicationParameters.ManagementPackName);

            //delete existing relationships
            foreach (RelationshipParam relationshipParam in distributedApplicationParameters.RemoveRelationship)
            {
                DeleteRelationship(relationshipParam);
            }

            //create component group
            foreach (string componentName in distributedApplicationParameters.ComponentGroup)
            {
                AddComponentGroup(componentName);
            }
            Sleeper.Delay(Constants.DefaultDialogTimeout);

            //create relationship
            foreach (RelationshipParam relationshipParam in distributedApplicationParameters.CreateRelationship)
            {
                CreateRelationship(relationshipParam);
                DesignSurfaceWindow.WaitForResponse(Constants.OneSecond * 5);
                Relayout();
            }

            //add entity to component
            foreach (EntityTargetParam entityTargetParam in distributedApplicationParameters.LinkEntityComponent)
            {
                AddEntityToComponent(entityTargetParam.Entity, entityTargetParam.Target, entityTargetParam.Path);
                Relayout();
            }

            Utilities.TakeScreenshot("CreateDistributedApplication");
            SaveAndClose();

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Deletes distributed application
        /// </summary>
        /// <param name="name">distributed application name</param>
        public void DeleteDistributedApplication(string name)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            if (null == name)
            {
                throw new ArgumentNullException("Distributed Application name cannot be null");
            }

            Maui.Core.WinControls.DataGridViewRow distributedApplicationRow = GetDistributedApplicationRow(name);

            if (null == distributedApplicationRow)
            {
                throw new DistributedApplicationHelper.Exceptions.DistributedApplicationNotExistException(
                    currentMethod + ":: Distributed application not found: " + name);
            }

            Utilities.LogMessage(currentMethod + ":: distributed application found:"+name);
            distributedApplicationRow.AccessibleObject.Click();
            Utilities.LogMessage(currentMethod + ":: click delete");
            CoreManager.MomConsole.MainWindow.Extended.SetFocus();
            Commands.EditDelete.Execute(CoreManager.MomConsole);
            Utilities.LogMessage(currentMethod + ":: clicking yes on confirm dialog");
            CoreManager.MomConsole.ConfirmChoiceDialog(true, Strings.ConfirmServiceDeleteDialogTitle);
            CoreManager.MomConsole.MainWindow.WaitForResponse();
            CoreManager.MomConsole.Refresh();
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Delete Management Pack
        /// </summary>
        /// <param name="name">management pack name</param>
        public void DeleteManagementPack(string name)
        {
            Utilities.LogMessage("DeleteManagementPack ::(...)");
            if (Utilities.ManagementPackExists(name))
            {
                Utilities.LogMessage("DeleteManagementPack :: Uninstall Management Packe: '"+name+"'");
                Utilities.UninstallManagementPack(name);
                if (!Utilities.VerifyManagementPackDeleted(name))
                {
                    throw new GroupAbort("Management pack "+name+" was not deleted properly");
                }
            }
            Utilities.LogMessage("DeleteManagementPack :: end");
        }

        /// <summary>
        /// Delete Management Pack File
        /// </summary>
        /// <param name="mpName">MP name</param>
        public void DeleteManagementPackFile(string mpFileName)
        {
            Utilities.LogMessage("DeleteManagementPackFile ::(...)");
            string mpFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + mpFileName + ".xml";
            if (System.IO.File.Exists(mpFilePath))
            {
                Utilities.LogMessage("DeleteManagementPack :: Delete File: '" + mpFilePath + "'");
                System.IO.File.Delete(mpFilePath);
            }
            Utilities.LogMessage("DeleteManagementPackFile :: end");
        }

        /// <summary>
        /// Change distributed application
        /// </summary>
        /// <param name="rename">new name</param>
        public void ChangeDistributedApplicationName(string rename)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Distributed application to be renamed as: " + rename);

            if (null == rename)
            {
                throw new ArgumentNullException(currentMethod + ":: original or rename value is null");
            }

            //change name in properties dialog
            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();
            CoreManager.MomConsole.ExecuteWindowMenuItem(DesignSurfaceWindow, Strings.MenuBarFileOption, Strings.FileMenuPropertiesOption);

            //Verify if dialog is found
            int maxTries = 5, tries = 0;
            while (null == DistributedApplicationPropertiesDialogWindow && tries++ < maxTries)
            {
                CoreManager.MomConsole.ExecuteWindowMenuItem(DesignSurfaceWindow, Strings.MenuBarFileOption, Strings.FileMenuPropertiesOption);
                CoreManager.MomConsole.Waiters.WaitForWindowForeground(DistributedApplicationPropertiesDialogWindow, Constants.OneSecond * 2);
                Utilities.LogMessage(currentMethod + ":: try " + tries + " of " + maxTries + " to executed file->properties.");
            }

            if (null == DistributedApplicationPropertiesDialogWindow)
            {
                Utilities.TakeScreenshot("PropertiesDialogNotFound");
                throw new VarAbort("DistributedApplicationPropertiesDialogWindow not found after 5 retries.");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Properties Dialog is found.");
            }

            DistributedApplicationPropertiesDialogWindow.DistributedApplicationNameText = rename;
            DistributedApplicationPropertiesDialogWindow.ClickOK();

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Add new Component Group
        /// </summary>
        /// <param name="name">Component Group Name</param>
        /// <history>
        /// [v-brucec] 04DEC09 Add logic to retry after failure.
        /// </history>
        public void AddComponentGroup(string name)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            if (name == null)
            {
                throw new System.ArgumentNullException("Component name cannot be null");
            }

            if (name.Trim() == string.Empty)
            {
                throw new System.ArgumentException("No component name specified");
            }

            VerifyDesignerSurfaceIsOpen();
            CoreManager.MomConsole.WaitForForegroundDialog(this.DesignSurfaceWindow, Constants.DefaultDialogTimeout);
            
            try
            {
                //Utilities.BringDialogForeground(this.DesignSurfaceWindow);
                Utilities.LogMessage(currentMethod + ":: opening dialog 'Create New Component Group'.");
                ActiveAccessibility toolbar = GetToolbarButton(ServiceDesigner.Strings.AddComponentToolbarButton);

                if (toolbar != null)
                {
                    Utilities.LogMessage(currentMethod + ":: clicking toolbar to open 'Create New Component Group' dialog.");
                    //toolbar.Click();
                    ClickToolbarButton(toolbar);
                    
                    CreateNewComponentGroupDialog createNewComponentGroupDialog = this.CreateNewComponentGroupDialogWindow;
                    createNewComponentGroupDialog.NameYourComponentGroupText = name;
                    createNewComponentGroupDialog.ClickOK();
                    CoreManager.MomConsole.WaitForDialogClose(createNewComponentGroupDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                    createNewComponentGroupDialog = null;
                    toolbar = null;
                    Sleeper sleeper = new Sleeper(Constants.OneMinute);
                    while (sleeper.IsNotExpired)
                    {
                        try
                        {
                            Utilities.LogMessage(currentMethod + ":: Find 'Replace Visible Object Type' dialog and close it");
                            ReplaceVisibleObjectTypeDialog replaceVisibleObjectTypeDialog = new ReplaceVisibleObjectTypeDialog(CoreManager.MomConsole);
                            replaceVisibleObjectTypeDialog.ClickOK();
                        }
                        catch (Dialog.Exceptions.WindowNotFoundException)
                        {
                            Utilities.LogMessage(currentMethod + ":: 'Replace Visible Object Type' dialog not found, complete to close it and quit 'while' loop");
                            break;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        sleeper.Sleep();
                    }
                    DesignSurfaceWindow.WaitForResponse();
                }
                else
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException(currentMethod + ":: Cound not find toolbar '" + ServiceDesigner.Strings.AddComponentToolbarButton + "'.");
                }
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
            {
                Utilities.LogMessage(currentMethod + ":: Could not found dialog 'Create New Component Group', message: '" + ex);
                throw;
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Failed to add component group, message: '" + ex);
                throw;
            }
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Remove Component Group
        /// </summary>
        /// <param name="componentName">component group name</param>
        private void RemoveComponentGroup(string componentName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: remove component group name: " + componentName);

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            if (null == componentName)
            {
                throw new ArgumentNullException("Component Group Name cannot be null");
            }

            ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);
            int findIndex = -1;
            if ((findIndex = FindNodeIndex(componentNodes, componentName)) < 0)
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException("Unable to find component: " + componentName);
            }

            componentNodes[findIndex].Click();

            Utilities.LogMessage(currentMethod + ":: removing component group: " + componentName);
            ClickToolbarButton(GetToolbarButton(ServiceDesigner.Strings.RemoveToolbarButton));

            Utilities.LogMessage(currentMethod + ":: getting confirm dialog and click 'Yes' button");
            CoreManager.MomConsole.ConfirmChoiceDialog(ConsoleApp.ButtonCaption.Yes, "", StringMatchSyntax.WildCard, ConsoleApp.ActionIfWindowNotFound.Ignore);

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Delete relationship between two components
        /// </summary>
        /// <param name="relationshipParam">To and From RelationshipParam</param>
        public void DeleteRelationship(RelationshipParam relationshipParam)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            VerifyDesignerSurfaceIsOpen();
            ActiveAccessibility relationship = GetRelationships(relationshipParam.From, relationshipParam.To);

            if (null != relationship)
            {
                DeleteRelationship(relationship);
            }
            else
            {
                throw new DistributedApplicationHelper.Exceptions.RelationshipNotExistException(
                    "Relationship not found between \"" + relationshipParam.From + "\" to \"" + relationshipParam.To + "\" and hence cannot be deleted");
            }

            DesignSurfaceWindow.WaitForResponse();
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Create New Relationship
        /// </summary>
        /// <param name="relationshipParam">To and from component</param>
        /// <history>
        /// [v-brucec] 22DEC09 Add logic to retry after failure.
        /// </history>
        public void CreateRelationship(RelationshipParam relationshipParam)
        {
            int retry = 0;
            int maxRetry = 5;
            int fromNodeIndex = -1;
            int toNodeIndex = -1;

            ActiveAccessibility fromNode = null;
            ActiveAccessibility toNode = null;

            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: creating relationship between " + relationshipParam.From + " and " + relationshipParam.To + " on " + DesignSurfaceWindow.Caption);

            while ((fromNodeIndex == -1 || toNodeIndex == -1) && retry < maxRetry)
            {
                VerifyDesignerSurfaceIsOpen();
                DesignSurfaceWindow.WaitForResponse();
                ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);

                fromNodeIndex = FindNodeIndex(componentNodes, relationshipParam.From);
                toNodeIndex = FindNodeIndex(componentNodes, relationshipParam.To);

                if (fromNodeIndex >= 0)
                {
                    fromNode = componentNodes[fromNodeIndex] as ActiveAccessibility;
                    Utilities.LogMessage(currentMethod + ":: Found component '" + relationshipParam.From + "' at index " + fromNodeIndex);
                }

                if (toNodeIndex >= 0)
                {
                    toNode = componentNodes[toNodeIndex] as ActiveAccessibility;
                    Utilities.LogMessage(currentMethod + ":: Found component '" + relationshipParam.To + "' at index " + toNodeIndex);
                }

                retry++;
            }

            if (fromNodeIndex < 0 || fromNode == null)
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException(relationshipParam.From + " not found");
            }

            if (toNodeIndex < 0 || toNode == null)
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException(relationshipParam.To + " not found");
            }

            ActiveAccessibility createRelationshipButton = GetToolbarButton(DesignSurface.Strings.CreateRelationship);

            // CreateRelationship
            //createRelationshipButton.Click();
            ClickToolbarButton(createRelationshipButton);

            DesignSurfaceWindow.WaitForResponse();        // It might fail to draw line if runs too fast
            Utilities.LogMessage(currentMethod + ":: Clicking node '" + relationshipParam.From + "'.");
            fromNode.Click();
            
            DesignSurfaceWindow.WaitForResponse();
            Utilities.LogMessage(currentMethod + ":: Clicking node '" + relationshipParam.To + "'.");
            toNode.Click();

            DesignSurfaceWindow.WaitForResponse();
            createRelationshipButton.Click();

            CoreManager.MomConsole.Waiters.WaitForWindowReady(DesignSurfaceWindow, Constants.DefaultDialogTimeout);
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Opens designer surface window
        /// </summary>
        /// <param name="distributedApplicationName">Distributed Application Name</param>
        public void OpenDesignerSurface(string distributedApplicationName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            if (null == distributedApplicationName)
            {
                throw new ArgumentNullException("Distributed Application name cannot be null");
            }

            if (cachedDesignSurface == null)
            {
                Maui.Core.WinControls.DataGridViewRow distributedApplicationRow = GetDistributedApplicationRow(distributedApplicationName);
                try //Add try logic to avoid test bug #542858
                {
                    if (null == distributedApplicationRow)
                    {
                        throw new DistributedApplicationHelper.Exceptions.DistributedApplicationNotExistException(
                            currentMethod + ":: Distributed application not found: " + distributedApplicationName);
                    }

                    //click to open distributed application
                    Utilities.LogMessage(currentMethod + ":: distributed application found. Opening and renaming it");
                    distributedApplicationRow.Click();
                    //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();
                    new Menu(ContextMenuAccessMethod.ShiftF10).ExecuteMenuItem(Utilities.RemoveAcceleratorKeys(NavigationPane.Strings.EditServiceContextMenu));
                    DesignSurfaceWindow.WaitForResponse();
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
                {
                    Utilities.LogMessage(currentMethod + ":: DesignSurfaceWindow.WaitForResponse hit exception:" + e.Message);
                    Utilities.TakeScreenshot("OpenDesignerSurface_WindowNotFoundException");
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                    System.Threading.Thread.Sleep(Constants.OneSecond*5);
                    Utilities.TakeScreenshot("OpenDesignerSurface_After_Send_ESC");

                    distributedApplicationRow.Click();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();
                    new Menu(ContextMenuAccessMethod.ShiftF10).ExecuteMenuItem(Utilities.RemoveAcceleratorKeys(NavigationPane.Strings.EditServiceContextMenu));
                    DesignSurfaceWindow.WaitForResponse();
                }
            }
            else
            {
                DesignSurfaceWindow.WaitForResponse();
            }
        }

        /// <summary>
        /// Save and close designer workspace
        /// </summary>
        public void SaveAndClose()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            ClickToolbarButton(GetToolbarButton(ServiceDesigner.Strings.FileMenuSaveOption));
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(DesignSurfaceWindow, Constants.OneMinute);

            int retry = 0;
            int maxRetry = 120;
            while (retry < maxRetry)
            {
                if(!DesignSurfaceWindow.Controls.AlertViewStaticControl.IsEnabled)
                {
                    Utilities.LogMessage(currentMethod + ":: Still in saving process... / "+retry);
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                }
                else
                    break;
            }
            Utilities.LogMessage(currentMethod + ":: Click Close");
            DesignSurfaceWindow.ClickTitleBarClose();
            CoreManager.MomConsole.WaitForDialogClose(cachedDesignSurface, Constants.DefaultDialogTimeout / Constants.OneSecond);
            cachedDesignSurface = null;
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Check if distributed application exists
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>true if found</returns>
        public bool DistributedApplicationExists(string name)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            return GetDistributedApplicationRow(name) != null ? true : false;
        }

        /// <summary>
        /// Check if entity is part of component
        /// </summary>
        /// <param name="entityTarget">entity target param.</param>
        /// <returns>true if success</returns>
        public bool EntityInComponentExists(EntityTargetParam entityTarget)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);

            ActiveAccessibility node = FindNode(componentNodes, entityTarget.Target);

            if (null == node)
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException("Unable to find component: \"" + entityTarget.Target + "\"");
            }

            ActiveAccessibility aa = node.FindChild(entityTarget.Entity + "*");

            if (null == aa)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verify if component Exists
        /// </summary>
        /// <param name="name">name of component</param>
        /// <returns>true if exists</returns>
        public bool ComponentExists(string name)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            if (name == null)
            {
                throw new System.ArgumentNullException("Component name cannot be null");
            }

            if (name.Trim() == string.Empty)
            {
                throw new System.ArgumentException("No component name specified");
            }


            if (cachedDesignSurface == null)
            {
                throw new DistributedApplicationHelper.Exceptions.DialogNotOpenException(
                    currentMethod + " :: Design Surface must be opened. Use OpenDesignSurface(...) method to open Design Surface.");
            }

            ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);

            ActiveAccessibility node = FindNode(componentNodes, name);

            if (null == node)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verify if relationship exists
        /// </summary>
        /// <param name="relationship">relationship param.</param>
        /// <returns>true if exists</returns>
        public bool RelationshipExists(RelationshipParam relationship)
        {
            return GetRelationships(relationship.From, relationship.To) == null ? false : true;
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Get distributed application row
        /// </summary>
        /// <param name="name">name of distributed application</param>
        /// <returns>distributed application row</returns>
        private Maui.Core.WinControls.DataGridViewRow GetDistributedApplicationRow(string name)
        {
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
            CoreManager.MomConsole.Waiters.WaitForStatusReady();

            CoreManager.MomConsole.NavigationPane.SelectNode(
                NavigationPane.Strings.Authoring
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewServices,
                NavigationPane.NavigationTreeView.Authoring);

            CoreManager.MomConsole.Waiters.WaitForStatusReady();

            Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            return viewGrid.FindData(name, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);
        }

        /// <summary>
        /// Add entity to component
        /// </summary>
        /// <param name="entity">entity name (case sensitive)</param>
        /// <param name="component">component name (case sensitive)</param>
        private void AddEntityToComponent(string entity, string component)
        {
            this.AddEntityToComponent(entity, component, null);
        }

        /// <summary>
        /// Add entity to component
        /// </summary>
        /// <param name="entity">entity name (case sensitive)</param>
        /// <param name="path">path (case insensitive)</param>
        /// <param name="component">component name (case sensitive) - contains match</param>
        private void AddEntityToComponent(string entity, string component, string path)
        {
            int retry = 0;
            int maxretry = 10;
            bool entityFound = false;
            int componentIndex = -1;
            List<ListViewItem> entityItemList = new List<ListViewItem>();
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Parameter: Entity: " + entity);
            Utilities.LogMessage(currentMethod + ":: Parameter: component: " + component);

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            // Find all entities that match the name provided. 
            while (!entityFound && retry < maxretry)
            {
                retry++;

                // Using Home key and Shift+End to select all text, because Ctrl+A doesn't work in some languages
                DesignSurfaceWindow.Controls.SearchForObjectsTextBox.Click();
                DesignSurfaceWindow.Controls.SearchForObjectsTextBox.SendKeys(KeyboardCodes.Home);
                DesignSurfaceWindow.Controls.SearchForObjectsTextBox.SendKeys(KeyboardCodes.Shift + KeyboardCodes.End);

                // Using search to cut off time of find listitem, related bug 175007
                DesignSurfaceWindow.Controls.SearchForObjectsTextBox.SendKeys(entity);
                DesignSurfaceWindow.Controls.ButtonGo.Click();

                ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);

                if ((componentIndex = FindNodeIndex(componentNodes, component)) < 0)
                {
                    throw new ActiveAccessibility.Exceptions.ChildNotFoundException("Unable to find component: " + component);
                }

                ListViewItemCollection entities = DesignSurfaceWindow.Controls.ListViewSCInstances.FindAllByText(entity, false);

                // If the entities list is empty, delay and get the list again.
                if (entities.Count != 0)
                {
                    // If the path provided is *not* null or empty then
                    // match on path else return the first entity found.
                    if (!String.IsNullOrEmpty(path))
                    {
                        foreach (ListViewItem item in entities)
                        {
                            if (item.SubItems.Count > 0 && item.SubItems[0].Text.ToLower().Contains(path.ToLower()))
                            {
                                entityFound = true;
                                entityItemList.Add(item);
                            }
                        }
                    }
                    else
                    {
                        entityFound = true;

                        foreach (ListViewItem item in entities)
                        {
                            entityItemList.Add(item);
                        }
                        
                    }
                }

                if (!entityFound)
                {
                    Sleeper.Delay(5 * Constants.OneSecond * retry);
                    string logMsg = String.IsNullOrEmpty(path) ?
                        currentMethod + ":: Entity '" + entity + "' not found. Retrying " + retry + " of " + maxretry :
                        currentMethod + ":: Entity '" + entity + "' with path '" + path + "' not found. Retrying " + retry + " of " + maxretry;
                    Utilities.LogMessage(logMsg);
                }
            }

            if (!entityFound)
            {
                string logMsg = String.IsNullOrEmpty(path) ?
                    currentMethod + ":: Entity '" + entity + "' not found." :
                    currentMethod + ":: Entity '" + entity + "' with path '" + path + "' not found.";
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException(logMsg);
            }


            // Adding retry logic here in case launching menu timeout and to make automation more stable
            foreach (ListViewItem entityItem in entityItemList)
            {
                retry = 0;
                while (retry < maxretry)
                {
                    try
                    {
                        entityItem.Click();
                        Menu contextMenu = new Menu(ContextMenuAccessMethod.ShiftF10);
                        Sleeper.Delay(Constants.OneSecond);
                        contextMenu.ExecuteMenuItem(ServiceDesigner.Strings.AddTo);
                        Sleeper.Delay(Constants.OneSecond);
                        MenuItem componentMenuItem = new MenuItem(contextMenu, component);
                        componentMenuItem.Execute();

                        DesignSurfaceWindow.WaitForResponse();
                        break;
                    }
                    catch
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: Attempt " + retry + " of " + maxretry);
                        retry++;
                        DesignSurfaceWindow.Controls.ListViewSCInstances.SendKeys(KeyboardCodes.Esc);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                }
            }

            Utilities.LogMessage(currentMethod + ":: End");
        }

        /// <summary>
        /// Remove entity from component
        /// </summary>
        /// <param name="component">component name (case sensitive) - contains match</param>
        private void RemoveEntityFromComponent(string component)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string componentGroupItem = "Component Group Item";

            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Parameter: component: " + component);

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            if (ComponentExists(component))
            {
                //Find all children of <component>
                ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);
                ActiveAccessibilityCollection entityNodes0 = FindNode(componentNodes, component).Children;
                ActiveAccessibilityCollection entityNodes1 = FindNode(entityNodes0, componentGroupItem).Children;
                ActiveAccessibilityCollection entityNodes = FindNode(entityNodes1, componentGroupItem).Children;

                if (null == entityNodes || 0 >= entityNodes.Count)
                {
                    throw new ActiveAccessibility.Exceptions.ChildNotFoundException("No entity in component: " + component);
                }

                for (int i = 0; i < entityNodes.Count; i++)
                {
                    Utilities.LogMessage(currentMethod + ":: clicking entity: " + entityNodes[i].Name);
                    entityNodes[i].Click();
                    Utilities.LogMessage(currentMethod + ":: removing entity: " + entityNodes[i].Name);
                    ClickToolbarButton(GetToolbarButton(ServiceDesigner.Strings.RemoveToolbarButton));
                    Utilities.LogMessage(currentMethod + ":: get confirm dialog and click Yes button." );
                    ServiceDesignerConfirmationDialog serviceDesignerConfirmationDialog = this.ServiceDesignerConfirmationDialogWindow;
                    serviceDesignerConfirmationDialog.WaitForResponse();
                    serviceDesignerConfirmationDialog.ClickYes();
                    CoreManager.MomConsole.WaitForDialogClose(serviceDesignerConfirmationDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                    serviceDesignerConfirmationDialog = null;
                }
            }
            else
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException("Unable to find component: " + component);
            }
            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Change component type 
        /// </summary>
        /// <param name="component">component name</param>
        private void ChangeComponentObjectType(string component)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Parameter: component: " + component);

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            if (null == component)
            {
                throw new ArgumentNullException("Component Group Name cannot be null");
            }

            ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);
            int findIndex = -1;
            if ((findIndex = FindNodeIndex(componentNodes, component)) < 0)
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException("Unable to find component: " + component);
            }

            Utilities.LogMessage(currentMethod + ":: Click 'Properties' and open 'Component Group Dialog' Window");
            componentNodes[findIndex].Click();
            ClickToolbarButton(GetToolbarButton(ServiceDesigner.Strings.FileMenuPropertiesOption));
            ComponentGroupPropertiesDialog componentGroupPropertiesDialog = new ComponentGroupPropertiesDialog(CoreManager.MomConsole);
            CoreManager.MomConsole.Waiters.WaitForWindowAppeared(DesignSurfaceWindow, new QID(";[UIA]Name = '" + ServiceDesigner.ComponentGroupPropertiesDialog.Strings.DialogTitle + "'"), Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.TreeView cgTreeView = componentGroupPropertiesDialog.Controls.ObjectsThatCanBeAddedToThisComponentGroupTreeView;

            Utilities.LogMessage(currentMethod + ":: Uncheck 'Object' node");
            cgTreeView.Find(Strings.Object).Checked = false;
            Utilities.LogMessage(currentMethod + ":: Check 'Object'->'Administration Item' node");
            cgTreeView.Find(Strings.Object).Find(Strings.AdministrationItem).Checked = true;

            componentGroupPropertiesDialog.ClickOK();

            Utilities.LogMessage(currentMethod + ":: Click OK to close 'Replace Visible Object Type' dialog(s)");

            Sleeper sleeper=new Sleeper(Constants.OneMinute);
            while (sleeper.IsNotExpired)
            {
                try
                {
                    Utilities.LogMessage(currentMethod + ":: Find 'Replace Visible Object Type' dialog and close it");
                    ReplaceVisibleObjectTypeDialog replaceVisibleObjectTypeDialog = new ReplaceVisibleObjectTypeDialog(CoreManager.MomConsole);
                    replaceVisibleObjectTypeDialog.ClickOK();
                }
                catch (Dialog.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: 'Replace Visible Object Type' dialog not found, complete to close it and quit 'while' loop");
                    break;
                }
                catch (Exception)
                {
                    throw;
                }
                sleeper.Sleep();
            }
            

            CoreManager.MomConsole.WaitForDialogClose(componentGroupPropertiesDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            componentGroupPropertiesDialog = null;
            DesignSurfaceWindow.WaitForResponse();

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Remove component type 
        /// </summary>
        /// <param name="component">component name</param>
        private void RemoveComponentObjectType(string component)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Parameter: component: " + component);

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            if (null == component)
            {
                throw new ArgumentNullException("Component Group Name cannot be null");
            }

            ActiveAccessibilityCollection componentNodes = GetAllComponents(ModelingSurface.Children);
            int findIndex = -1;
            if ((findIndex = FindNodeIndex(componentNodes, component)) < 0)
            {
                throw new ActiveAccessibility.Exceptions.ChildNotFoundException("Unable to find component: " + component);
            }

            Utilities.LogMessage(currentMethod + ":: open Component Group Dialog Window");
            componentNodes[findIndex].Click();
            ClickToolbarButton(GetToolbarButton(ServiceDesigner.Strings.FileMenuPropertiesOption));
            ComponentGroupPropertiesDialog componentGroupPropertiesDialog = new ComponentGroupPropertiesDialog(CoreManager.MomConsole);
            CoreManager.MomConsole.Waiters.WaitForWindowAppeared(DesignSurfaceWindow, new QID(";[UIA]Name = '" + ServiceDesigner.ComponentGroupPropertiesDialog.Strings.DialogTitle + "'"), Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.TreeView cgTreeView = componentGroupPropertiesDialog.Controls.ObjectsThatCanBeAddedToThisComponentGroupTreeView;

            Utilities.LogMessage(currentMethod + ":: Uncheck 'Object'->'Administration Item' node");
            cgTreeView.Find(Strings.Object).Find(Strings.AdministrationItem).Checked = false;
            Utilities.LogMessage(currentMethod + ":: Check 'Object'->'Administration Item'->'Global Settings' node");
            cgTreeView.Find(Strings.Object).Find(Strings.AdministrationItem).Find(Strings.GlobalSettings).Checked = true;
            
            componentGroupPropertiesDialog.ClickOK();

            Utilities.LogMessage(currentMethod + ":: Click OK to close 'Replace Visible Object Type' dialog(s)");
            Sleeper sleeper = new Sleeper(Constants.OneMinute);
            while (sleeper.IsNotExpired)
            {
                try
                {
                    Utilities.LogMessage(currentMethod + ":: Find 'Replace Visible Object Type' dialog and close it");
                    ReplaceVisibleObjectTypeDialog replaceVisibleObjectTypeDialog = new ReplaceVisibleObjectTypeDialog(CoreManager.MomConsole);
                    replaceVisibleObjectTypeDialog.ClickOK();
                }
                catch (Dialog.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: 'Replace Visible Object Type' dialog not found, quit 'while' loop");
                    break;
                }
                catch (Exception)
                {
                    throw;
                }
                sleeper.Sleep();
            }

            CoreManager.MomConsole.WaitForDialogClose(componentGroupPropertiesDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            componentGroupPropertiesDialog = null;
            DesignSurfaceWindow.WaitForResponse();

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Save Distributed Application as Tamplate 
        /// </summary>
        /// <param name="distributedApplication">distributedApplication</param>
        private void SaveAsTemplate(string distributedApplication, string path)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Parameter: DistributedApplication: " + distributedApplication);

            string importMPFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + distributedApplication + ".xml";
            if (System.IO.File.Exists(importMPFile))
            {
                Utilities.LogMessage(currentMethod + ":: Deleting the old xml file");
                System.IO.File.Delete(importMPFile);
            }

            VerifyDesignerSurfaceIsOpen();
            DesignSurfaceWindow.WaitForResponse();

            CoreManager.MomConsole.ExecuteWindowMenuItem(DesignSurfaceWindow, Strings.MenuBarFileOption, Strings.FileMenuSaveasTemplateOption.Replace("&", ""));

            Utilities.LogMessage(currentMethod + ":: Get 'Save as Template' Dialog");
            Mom.Test.UI.Core.Console.ServiceDesigner.SaveasTemplateDialog saveasTemplate = new SaveasTemplateDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);

            Utilities.LogMessage(currentMethod + ":: get save path:"+path);
            switch (path)
            {
                case PathDesktop:
                    importMPFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + distributedApplication + ".xml";
                    break;
                default:
                    importMPFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + distributedApplication + ".xml";
                    break;
            }

            Utilities.LogMessage(currentMethod + ":: enter file name:" + importMPFile);
            saveasTemplate.FileNameText = importMPFile;

            Utilities.LogMessage(currentMethod + ":: clikc button 'Save'");
            saveasTemplate.Controls.SaveButton.Click();
            
            CoreManager.MomConsole.Waiters.WaitForWindowClose(saveasTemplate, Constants.DefaultDialogTimeout / Constants.OneSecond);

            //click "OK" in confirm dialog
            Utilities.LogMessage(currentMethod + ":: Click OK button in confirm dialog");
            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK, "", StringMatchSyntax.WildCard, MomConsoleApp.ActionIfWindowNotFound.Ignore);

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Change Template's ID to an Valid Value
        /// </summary>
        /// <param name="path">template path</param>
        /// <param name="id">valid id value</param>
        private void ChangeTemplateID(string path, string id)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: Parameter: template path: " + path);
            Utilities.LogMessage(currentMethod + ":: Parameter: valid id value: " + id);

            Utilities.LogMessage(currentMethod + ":: Open template xml file");
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();
            document.Load(path);

            //<ManagementPack><Manifest><Identity><ID>Value</ID>...
            Utilities.LogMessage(currentMethod + ":: Change ID's value");
            document.SelectSingleNode("ManagementPack").FirstChild.FirstChild.FirstChild.InnerText = id;
            document.Save(path);

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Prepares distributed application
        /// </summary>
        /// <param name="name">distributed application name</param>
        /// <param name="description">distributed application description</param>
        /// <param name="template">Template</param>
        /// <param name="managementPack">Management Pack name</param>
        /// <history>
        /// [v-brucec] 04DEC09 Add logic to bring window/dialog to foregound .
        /// </history>
        private void PrepareDistributedApplication(string name, string description, string template, string managementPack)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            if (null == name)
            {
                throw new ArgumentNullException("Distributed Application name cannot be null");
            }

            if (null == template)
            {
                throw new ArgumentNullException("Template name cannot be null");
            }

            if (null == managementPack)
            {
                throw new ArgumentNullException("MP cannot be null");
            }

            ClickCreateNewDistributedApplication();
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond*3);
            CreateDistributedApplicationDialog createDistributedApplicationDialog = this.CreateDistributedApplicationDialogWindow;
            
            if (createDistributedApplicationDialog != null)
            {
                Utilities.LogMessage(currentMethod + ":: Distributed Application Dialog found.");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Distributed Application Dialog not found.");
            }
            //wait for TextBox Name
            CoreManager.MomConsole.Waiters.WaitForWindowAppeared(createDistributedApplicationDialog, new QID(";[UIA]AutomationID=\'" + CreateDistributedApplicationDialog.ControlIDs.NameTextBox + "\'"), Constants.OneMinute);

            //Sometimes maui get textboxs of name and description failed, so add retry logic.
            int retryIndex=0,maxRetry=5; 
            while (retryIndex++ < maxRetry)
            {
                try
                {
                    Utilities.LogMessage(currentMethod + ":: Fill basic DA information, retryIndex=" + retryIndex + ", maxRetry="+maxRetry);
                    Utilities.LogMessage(currentMethod + ":: Entering name in DA inital screen: " + name);
                    createDistributedApplicationDialog.NameText = name;

                    Utilities.LogMessage(currentMethod + ":: Entering description in DA inital screen: " + description);
                    createDistributedApplicationDialog.DescriptionOptionalText = description;

                    Utilities.LogMessage(currentMethod + ":: Selecting template in DA inital screen: " + template);
                    createDistributedApplicationDialog.Controls.TemplateListBox.SelectItem(template);

                    //setting management pack in parameter class is optional
                    if (null != managementPack)
                    {
                        Utilities.LogMessage(currentMethod + ":: Selecting Management Pack in DA inital screen: " + managementPack);
                        createDistributedApplicationDialog.ManagementPackText = managementPack;
                    }
                    break;
                }
                catch(Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                {
                    Utilities.LogMessage(currentMethod + "-retry-" + retryIndex);
                    Utilities.LogMessage(currentMethod + " :: Fill basic DA information hit exception:" + ex.Message);
                    
                    if (retryIndex == maxRetry)
                    {
                        throw ex;
                    }

                    Utilities.LogMessage(currentMethod + " :: Will re catch the DA main dialog again, and then sleep 10 secons to continue.");
                    
                    this.cachedCreateDistributedApplicationDialog = new CreateDistributedApplicationDialog(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowReady(this.cachedCreateDistributedApplicationDialog, Constants.OneMinute);
                    createDistributedApplicationDialog.Controls.NameStaticControl.Click();
                    System.Threading.Thread.Sleep(Constants.OneSecond * 10);
                }

            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(createDistributedApplicationDialog.Controls.OKButton, Constants.OneMinute);
            Utilities.LogMessage(currentMethod + ":: Clicking OK button ");
            createDistributedApplicationDialog.ClickOK();

            //close dialog and wait for distributed application window to appear
            CoreManager.MomConsole.WaitForDialogClose(createDistributedApplicationDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            createDistributedApplicationDialog = null;
            CoreManager.MomConsole.Waiters.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForWindowReady(this.DesignSurfaceWindow, Constants.OneMinute);

            Utilities.BringDialogForeground(this.DesignSurfaceWindow);
            this.DesignSurfaceWindow.Extended.Click();
            CoreManager.MomConsole.Waiters.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForWindowReady(this.DesignSurfaceWindow, Constants.OneMinute);
            this.DesignSurfaceWindow.Extended.State = WindowState.Maximize;
        }
        /// <summary>
        /// Click on Create New Distributed Application context menu from Authoring panel 
        /// </summary>
        private void ClickCreateNewDistributedApplication()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            Utilities.LogMessage(currentMethod + ":: Selecting DA in Authoring space");
            CoreManager.MomConsole.NavigationPane.SelectNode(
                NavigationPane.Strings.Authoring
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewServices,
                NavigationPane.NavigationTreeView.Authoring);

            CoreManager.MomConsole.Waiters.WaitForReady();

            Utilities.LogMessage(currentMethod + ":: Launching DA from context menu");
            Boolean isLaunched = false;
            Int32 retryCount = 0;
            Int32 maxRetry = 3;
            Menu menu = null;
            while (!isLaunched && retryCount < maxRetry)
            {
                Utilities.LogMessage("Attempt  to Launch context menu:: " + (retryCount + 1).ToString());
                try
                {
                    menu = new Menu(ContextMenuAccessMethod.ShiftF10);
                    Utilities.TakeScreenshot("LaunchContextMenuSuccessfully");
                    isLaunched = true;
                }
                catch (Exception e)
                {
                    Utilities.LogMessage("Launch context menu exception::" + e.Message);
                    retryCount++;
                }
            }
            menu.ExecuteMenuItem(NavigationPane.Strings.ContextMenuCreateNewDistributedApplication);
        }



        private void VerifyDesignerSurfaceIsOpen()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            if (cachedDesignSurface == null)
            {
                throw new DistributedApplicationHelper.Exceptions.DialogNotOpenException(
                    currentMethod + " :: Design Surface must be opened. Use OpenDesignSurface(...) method to open Design Surface.");
            }
        }

        /// <summary>
        /// Delete relationship
        /// </summary>
        /// <param name="relationship">relationship</param>
        private void DeleteRelationship(ActiveAccessibility relationship)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
           
            Utilities.LogMessage(currentMethod + ":: start");

            if (null == relationship)
            {
                throw new System.ArgumentNullException("Relationship specified to be deleted cannot be null");
            }

            relationship.Click();
            Utilities.LogMessage(currentMethod + ":: removing relationship: " + relationship.Name);
            ClickToolbarButton(GetToolbarButton(ServiceDesigner.Strings.RemoveToolbarButton));
            
            ServiceDesignerConfirmationDialog serviceDesignerConfirmationDialog = this.ServiceDesignerConfirmationDialogWindow;
            serviceDesignerConfirmationDialog.WaitForResponse();
            serviceDesignerConfirmationDialog.ClickYes();
            CoreManager.MomConsole.WaitForDialogClose(serviceDesignerConfirmationDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            serviceDesignerConfirmationDialog = null;

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Relayout designer surface
        /// </summary>
        private void Relayout()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            DesignSurfaceWindow.WaitForResponse();
            ClickToolbarButton(GetToolbarButton(DesignSurface.Strings.Relayout));

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Get all relationships
        /// </summary>
        /// <param name="allNodes">all nodes collection</param>
        /// <returns>all relationship nodes</returns>
        private ActiveAccessibilityCollection GetAllRelationship(ActiveAccessibilityCollection allNodes)
        {
            ActiveAccessibilityCollection aac = new ActiveAccessibilityCollection();

            foreach (ActiveAccessibility aa in allNodes)
            {
                if (null == aa.FindChild(DesignSurface.Strings.Area, (int)MsaaRole.Diagram))
                {
                    aac.Add(aa);
                }
            }

            return aac;
        }

        /// <summary>
        /// Get relationship ActiveAccessibility object between from and to components
        /// </summary>
        /// <param name="from">from component</param>
        /// <param name="to">to component</param>
        /// <returns>ActiveAccessibility node object</returns>
        private ActiveAccessibility GetRelationships(string from, string to)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (cachedDesignSurface == null)
            {
                throw new DistributedApplicationHelper.Exceptions.DialogNotOpenException(
                    currentMethod + " :: Design Surface must be opened. Use OpenDesignSurface(...) method to open Design Surface.");
            }

            DesignSurfaceWindow.WaitForResponse();
            ActiveAccessibilityCollection relationships = GetAllRelationship(ModelingSurface.Children);

            from = from.ToLowerInvariant();
            to = to.ToLowerInvariant();

            foreach (ActiveAccessibility relationship in relationships)
            {
                string relationshipName = relationship.Name.ToLowerInvariant();

                if (relationshipName.EndsWith(to) && relationshipName.Contains(from))
                {
                    Utilities.LogMessage(currentMethod + ":: relationship exists between " + from + ", " + to);
                    return relationship;
                }
            }

            Utilities.LogMessage(currentMethod + ":: no relationship exists between " + from + ", " + to);

            return null;
        }

        /// <summary>
        /// Get all component nodes
        /// </summary>
        /// <param name="allNodes">all nodes collection</param>
        /// <returns>all component nodes</returns>
        private ActiveAccessibilityCollection GetAllComponents(ActiveAccessibilityCollection allNodes)
        {
            ActiveAccessibilityCollection aac = new ActiveAccessibilityCollection();

            foreach (ActiveAccessibility aa in allNodes)
            {
                if (null != aa.FindChild((int)MsaaRole.Diagram))
                {
                    aac.Add(aa);
                }
            }

            return aac;
        }

        /// <summary>
        /// Get toolbar button
        /// </summary>
        /// <param name="buttonText">text to find</param>
        /// <returns>toolbar button</returns>
        private ActiveAccessibility GetToolbarButton(string buttonText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            ActiveAccessibility toolStripParent = DesignSurfaceWindow.Extended.AccessibleObject.FindChild(DesignSurface.Strings.ToolStripContainer, (int)MsaaRole.Client);
            if (null == toolStripParent)
            {
                Utilities.LogMessage(currentMethod + ":: " + buttonText + " not found in toolstrip");
                return null;
            }
            ActiveAccessibility toolStrip = toolStripParent.FindChild((int)MsaaRole.ToolBar);
            if (null == toolStrip)
            {
                Utilities.LogMessage(currentMethod + ":: toolbar role " + MsaaRole.ToolBar + " not found in toolstrip");
                return null;
            }
            ActiveAccessibility button = toolStrip.FindChild(buttonText, (int)MsaaRole.PushButton);
            if (null == button)
            {
                Utilities.LogMessage(currentMethod + ":: " + buttonText + " not found in toolstrip");
            }

            Utilities.LogMessage(currentMethod + ":: end");
            return button;
        }

        /// <summary>
        /// Click toolbar button
        /// </summary>
        /// <param name="buttonText">text to find</param>
        private void ClickToolbarButton(ActiveAccessibility toolbarButton)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            int maxRetry = 5;
            int loop = 0;
            while (loop++ < maxRetry)
            {
                if (!toolbarButton.Visible)
                {
                    Utilities.LogMessage(currentMethod + ":: Click toolbar options button at loop: " + loop);
                    ActiveAccessibility ToolbarOptionsButton = GetToolbarButton(Console.MomControls.ViewToolbar.Strings.ToolbarMenus.ToolbarOptions);
                    ToolbarOptionsButton.Click();
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Click button.");
                    toolbarButton.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Find node index by name
        /// </summary>
        /// <param name="aac">ActiveAccessibilityCollection</param>
        /// <param name="name">name to find</param>
        /// <returns>node index</returns>
        private int FindNodeIndex(ActiveAccessibilityCollection aac, string name)
        {
            ActiveAccessibility aa = FindNode(aac, name);
            return aa == null ? -1 : aac.IndexOf(aa);
        }

        /// <summary>
        /// Find node by name
        /// </summary>
        /// <param name="aac">ActiveAccessibilityCollection</param>
        /// <param name="name">name to find</param>
        /// <returns>ActiveAccessibility object</returns>
        private ActiveAccessibility FindNode(ActiveAccessibilityCollection aac, string name)
        {
            foreach (ActiveAccessibility aa in aac)
            {
                if (aa.Name == name)
                {
                    return aa;
                }
            }

            return null;
        }

        #endregion

        #region Exception Class
        /// <summary>
        /// Distributed Application Exception Class
        /// </summary>
        public class Exceptions
        {

            #region DialogNotOpenException Class

            /// <summary>
            /// DialogNotOpenException
            /// </summary>
            public class DialogNotOpenException : Exception
            {
                /// <summary>
                /// DialogNotOpenException exception.
                /// </summary>
                public DialogNotOpenException() : base() { }

                /// <summary>
                /// DialogNotOpenException exception with a specified exception.
                /// </summary>
                /// <param name="message">
                /// The error message that explains the reason 
                /// for the exception.
                /// </param>
                public DialogNotOpenException(string message)
                    : base(message) { }

                /// <summary>
                /// DialogNotOpenException exception with a specified 
                /// error message and a reference to the inner exception that 
                /// is the cause of this exception.
                /// </summary>
                /// <param name="message">
                /// The error message that explains the reason for the exception. 
                /// </param>
                /// <param name="inner">
                /// The exception that is the cause of the current exception. 
                /// If the innerException parameter is not a null reference, 
                /// the current exception is raised in a catch block that handles 
                /// the inner exception.
                /// </param>
                public DialogNotOpenException(string message, Exception inner)
                    : base(message, inner) { }
            }

            #endregion

            #region DistributedApplicationNotExistException Class

            /// <summary>
            /// DistributedApplicationNotExistException
            /// </summary>
            public class DistributedApplicationNotExistException : Exception
            {
                /// <summary>
                /// DistributedApplicationNotExistException exception.
                /// </summary>
                public DistributedApplicationNotExistException() : base() { }

                /// <summary>
                /// DistributedApplicationNotExistException exception with a specified exception.
                /// </summary>
                /// <param name="message">
                /// The error message that explains the reason 
                /// for the exception.
                /// </param>
                public DistributedApplicationNotExistException(string message)
                    : base(message) { }

                /// <summary>
                /// DistributedApplicationNotExistException exception with a specified 
                /// error message and a reference to the inner exception that 
                /// is the cause of this exception.
                /// </summary>
                /// <param name="message">
                /// The error message that explains the reason for the exception. 
                /// </param>
                /// <param name="inner">
                /// The exception that is the cause of the current exception. 
                /// If the innerException parameter is not a null reference, 
                /// the current exception is raised in a catch block that handles 
                /// the inner exception.
                /// </param>
                public DistributedApplicationNotExistException(string message, Exception inner)
                    : base(message, inner) { }
            }

            #endregion

            #region RelationshipNotExistException Class

            /// <summary>
            /// RelationshipNotExistException
            /// </summary>
            public class RelationshipNotExistException : Exception
            {
                /// <summary>
                /// RelationshipNotExistException exception.
                /// </summary>
                public RelationshipNotExistException() : base() { }

                /// <summary>
                /// RelationshipNotExistException exception with a specified exception.
                /// </summary>
                /// <param name="message">
                /// The error message that explains the reason 
                /// for the exception.
                /// </param>
                public RelationshipNotExistException(string message)
                    : base(message) { }

                /// <summary>
                /// RelationshipNotExistException exception with a specified 
                /// error message and a reference to the inner exception that 
                /// is the cause of this exception.
                /// </summary>
                /// <param name="message">
                /// The error message that explains the reason for the exception. 
                /// </param>
                /// <param name="inner">
                /// The exception that is the cause of the current exception. 
                /// If the innerException parameter is not a null reference, 
                /// the current exception is raised in a catch block that handles 
                /// the inner exception.
                /// </param>
                public RelationshipNotExistException(string message, Exception inner)
                    : base(message, inner) { }
            }

            #endregion
        }

        #endregion
    }

    #region Distributed Application Parameter Classes

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Distributed application parameters
    /// </summary>
    /// <history>
    /// 	[a-mujtch] 5/10/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DistributedApplicationParameters
    {
        #region members

        /// <summary>
        /// Distributed App. name
        /// </summary>
        private string name;

        /// <summary>
        /// Distributed App. description
        /// </summary>
        private string description;

        /// <summary>
        /// Create Relationship
        /// </summary>
        private List<RelationshipParam> relationship;

        /// <summary>
        /// Remove Relationship
        /// </summary>
        private List<RelationshipParam> relationshipDelete;

        /// <summary>
        /// Link entity to component
        /// </summary>
        private List<EntityTargetParam> linkEntityComponent;

        /// <summary>
        /// Remove Link entity from component
        /// </summary>
        private List<EntityTargetParam> removeEntityFromComponent;

        /// <summary>
        /// Create new Component Group
        /// </summary>
        private List<string> componentGroup;

        /// <summary>
        /// Template
        /// </summary>
        private string template;

        /// <summary>
        /// Management Pack Name
        /// </summary>
        private string managementPackName;

        /// <summary>
        /// Name of New DA created by new template
        /// </summary>
        private string newName;

        /// <summary>
        /// Description of New DA created by new template
        /// </summary>
        private string newDescription;

        /// <summary>
        /// MP Name ( New Template File)
        /// </summary>
        private string newMPName;

        #endregion

        #region constructor

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public DistributedApplicationParameters()
        {
        }

        #endregion

        #region properties

        /// <summary>
        /// Distributed Application Name
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Distributed Application Description
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

        /// <summary>
        /// Create Relationship
        /// </summary>
        public List<RelationshipParam> CreateRelationship
        {
            get
            {
                if (null == relationship)
                {
                    relationship = new List<RelationshipParam>();
                }

                return relationship;
            }

            set
            {
                relationship = value;
            }
        }
        
        /// <summary>
        /// Remove Relationship
        /// </summary>
        public List<RelationshipParam> RemoveRelationship
        {
            get
            {
                if (null == relationshipDelete)
                {
                    relationshipDelete = new List<RelationshipParam>();
                }

                return relationshipDelete;
            }

            set
            {
                relationshipDelete = value;
            }
        }

        //TODO: change name to ....
        /// <summary>
        /// Link Entity to Component
        /// </summary>
        public List<EntityTargetParam> LinkEntityComponent
        {
            get
            {
                if (null == linkEntityComponent)
                {
                    linkEntityComponent = new List<EntityTargetParam>();
                }

                return linkEntityComponent;
            }

            set
            {
                linkEntityComponent = value;
            }
        }

        /// <summary>
        /// Remove Link Entity From Component
        /// </summary>
        public List<EntityTargetParam> RemoveEntityFromComponent
        {
            get
            {
                if (null == removeEntityFromComponent)
                {
                    removeEntityFromComponent = new List<EntityTargetParam>();
                }

                return removeEntityFromComponent;
            }

            set
            {
                removeEntityFromComponent = value;
            }
        }
        

        /// <summary>
        /// Create Component Group
        /// </summary>
        public List<string> ComponentGroup
        {
            get
            {
                if (null == componentGroup)
                {
                    componentGroup = new List<string>();
                }

                return componentGroup;
            }

            set
            {
                componentGroup = value;
            }
        }

        /// <summary>
        /// Template
        /// </summary>
        public string Template
        {
            get
            {
                return template;
            }

            set
            {
                template = value;
            }
        }

        /// <summary>
        /// Management Pack Name
        /// </summary>
        public string ManagementPackName
        {
            get
            {
                return managementPackName;
            }

            set
            {
                managementPackName = value;
            }
        }
        
        /// <summary>
        /// Name of New DA created by new template
        /// </summary>
        public string NewName
        {
            get { return newName; }
            set { newName = value; }
        }

        /// <summary>
        /// Description of New DA created by new template
        /// </summary>
        public string NewDescription
        {
            get { return newDescription; }
            set { newDescription = value; }
        }

        /// <summary>
        /// MP Name ( New Template File)
        /// </summary>
        public string NewMPName
        {
            get { return newMPName; }
            set { newMPName = value; }
        }

        #endregion
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// RelationshipParam class used in creating/deleting relationship
    /// </summary>
    /// <history>
    /// 	[a-mujtch] 5/10/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RelationshipParam
    {
        #region members
        
        /// <summary>
        /// from string
        /// </summary>
        private string from;

        /// <summary>
        /// to string
        /// </summary>
        private string to;

        #endregion

        #region constructor

        /// <summary>
        /// RelationshipParam default constructor
        /// </summary>
        public RelationshipParam()
        {
        }

        /// <summary>
        /// RelationshipParam constructor
        /// </summary>
        /// <param name="from">from node</param>
        /// <param name="to">to node</param>
        public RelationshipParam(string from, string to)
        {
            this.from = VerifyParameter(from);
            this.to = VerifyParameter(to);
        }

        #endregion

        #region properties

        /// <summary>
        /// From string property
        /// </summary>
        public string From
        {
            get
            {
                return from;
            }

            set
            {
                from = VerifyParameter(value);
            }
        }

        /// <summary>
        /// To string property
        /// </summary>
        public string To
        {
            get
            {
                return to;
            }

            set
            {
                to = VerifyParameter(value);
            }
        }

        #endregion

        #region Verify

        /// <summary>
        /// Verify input parameter
        /// </summary>
        /// <param name="value">input value</param>
        /// <returns>formatted value</returns>
        private string VerifyParameter(string value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("Value cannot be null");
            }

            value = value.Trim();

            if (value.Length <= 1)
            {
                throw new ArgumentException("Value must be atleast one character");
            }

            return value;
        }

        #endregion
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// EntityTargetParam class used in adding entity to target node
    /// </summary>
    /// <history>
    /// 	[a-mujtch] 5/10/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------    
    public class EntityTargetParam
    {
        #region members

        /// <summary>
        /// entity string
        /// </summary>
        private string entity;

        /// <summary>
        /// target string
        /// </summary>
        private string target;

        /// <summary>
        /// Entity Path String
        /// </summary>
        private string path;

        #endregion

        #region constructor

        /// <summary>
        /// RelationshipParam default constructor
        /// </summary>
        public EntityTargetParam()
        {
        }

        /// <summary>
        /// RelationshipParam constructor
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="target">target node</param>
        public EntityTargetParam(string entity, string target)
        {
            this.entity = VerifyParameter(entity);
            this.target = VerifyParameter(target);
            this.path = null;
        }

        /// <summary>
        /// RelationshipParam constructor
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="target">target node</param>
        /// <param name="path">entity path</param>
        public EntityTargetParam(string entity, string target, string path)
        {
            this.entity = VerifyParameter(entity);
            this.target = VerifyParameter(target);
            this.path = path;       // no need to verify as path can be null
        }
        #endregion

        #region properties

        /// <summary>
        /// Entity property
        /// </summary>
        public string Entity
        {
            get
            {
                return entity;
            }

            set
            {
                entity = VerifyParameter(value);
            }
        }

        /// <summary>
        /// Target property
        /// </summary>
        public string Target
        {
            get
            {
                return target;
            }

            set
            {
                target = VerifyParameter(value);
            }
        }

        /// <summary>
        /// Path property
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        #endregion properties

        #region Verify

        /// <summary>
        /// Verify input parameter
        /// </summary>
        /// <param name="value">input value</param>
        /// <returns>formatted value</returns>
        private string VerifyParameter(string value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("Value cannot be null");
            }

            value = value.Trim();

            if (value.Length <= 1)
            {
                throw new ArgumentException("Value must be atleast one character");
            }

            return value;
        }

        #endregion
    }

    #endregion

    #region Test Focus Enumeration

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Test Focus as negative or positive
    /// </summary>
    /// <history>
    /// 	[a-mujtch] 5/10/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum TestFocus
    {
        /// <summary>
        /// Positive Test
        /// </summary>
        Positive,

        /// <summary>
        /// Negative Test
        /// </summary>
        Negative
    }

    #endregion
}
