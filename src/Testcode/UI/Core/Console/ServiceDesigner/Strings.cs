using System;
using System.Collections.Generic;
using System.Text;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    /// <summary>
    /// Service Designer strings
    /// </summary>
    public class Strings
    {            /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for string, Service Designer.
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedServiceDesigner;
        private static string cachedFileMenuSaveOption;
        private static string cachedFileMenuCloseOption;
        private static string cachedFileMenuDeleteOption;
        private static string cachedFileMenuPropertiesOption;
        private static string cachedMenuBarFileOption;
        private static string cachedConfirmServiceDeleteDialogTitle;
        private static string cachedMomDialogTitle;
        private static string cachedDesignerConfirmingFileMenuDelete;
        private static string cachedtoolStripContainer;
        private static string cachedFileMenuNewOption;
        private static string cachedService;
        private static string cachedAddTo;
        private static string cachedRemove;
        private static string cachedAddComponent;
        private static string cachedFileMenuSaveasTemplateOption;
        

        private const string ResourceFileMenuSaveasTemplateOption = ";SaveasT&emplate;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm.en;toolStripMenuItemExportAsTemplate.Text";
        private const string ResourceServiceDesigner = ";Distributed Application Designer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;ServiceDesigner";
        //private const string ResourceMenuBarFileOption = ";&File;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditorForm;fileToolStripMenuItem.Text";
        private const string ResourceMenuBarFileOption = ";&File;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;fileToolStripMenuItem.Text";
        //private const string ResourceFileMenuSaveOption = ";&Save;ManagedString;Microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceDesignerEditorForm.en;saveToolStripMenuItem.Text";
        private const string ResourceFileMenuSaveOption = ";&Save;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;saveToolStripMenuItem.Text";
        //private const string ResourceFileMenuCloseOption = ";&Close;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceDesignerEditorForm;closeToolStripMenuItem.Text";
        private const string ResourceFileMenuCloseOption = ";&Close;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;closeToolStripMenuItem.Text";
        //private const string ResourceFileMenuDeleteOption = ";&Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceDesignerEditorForm;deleteToolStripMenuItem.Text";
        private const string ResourceFileMenuDeleteOption = ";&Delete;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;deleteToolStripMenuItem.Text";
        //private const string ResourceFileMenuPropertiesOption = ";&Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripButtonProperties.Text";
        private const string ResourceFileMenuPropertiesOption = ";&Properties;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;toolStripMenuItemProperties.Text";
        private const string ResourceFileMenuNewOption = ";&New...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;newToolStripMenuItem.Text";

        //private const string ResourceConfirmServiceDeleteDialogTitle = ";Confirm Distributed Application Delete;ManagedString;Microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources.en;ConfirmDeleteCaption";
	    //private const string ResourceConfirmServiceDeleteDialogTitle = ";Distributed Application Designer;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm;$this.Text";
        private const string ResourceConfirmServiceDeleteDialogTitle = ";Confirm Distributed Application Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ConfirmDeleteCaption";


        //private const string ResourceMomDialogTitle = ";Microsoft Operations Manager;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;ControlErrorMessageBoxCaption";
        private const string ResourceMomDialogTitle = @";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

        // fix bug 71048
        private const string ResourceDesignerConfirmingFileMenuDelete = ";Deleting distributed application...;ManagedString;Microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;OperationDeleting";

        // fix bug 71xxx
        private const string ResourceToolStripContainer = ";toolStripContainer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;>>toolStripContainer.Name";

        // temporary fix bug 83795
        private const string ResourceService = "*Service*";

        // fix bug 83795
        private const string ResourceAddTo = ";Add To;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;ContextMenuAddItemText";

        private const string ResourceRemove = ";Remo&ve;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripButtonRemove.Text";
        private const string ResourceAddComponent = ";Add &Component;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripButtonAddServiceComponent.Text";

        /// <summary>
        /// Remove toolbar button
        /// </summary>
        public static string RemoveToolbarButton
        {
            get
            {
                if ((Strings.cachedRemove == null))
                {
                    cachedRemove = CoreManager.MomConsole.GetIntlStr(
                        ResourceRemove);
                }
                return Strings.cachedRemove;
            }
        }

        /// <summary>
        /// Add new component toolbar button
        /// </summary>
        public static string AddComponentToolbarButton
        {
            get
            {
                if ((Strings.cachedAddComponent == null))
                {
                    cachedAddComponent = CoreManager.MomConsole.GetIntlStr(
                        ResourceAddComponent);
                }
                return Strings.cachedAddComponent;
            }
        }
        
        /// <summary>
        /// Service Designer's Delete Service modal dialog title
        /// </summary>
        public static string DesignerConfirmingFileMenuDelete
        {
            get
            {
                if ((Strings.cachedDesignerConfirmingFileMenuDelete == null))
                {
                    cachedDesignerConfirmingFileMenuDelete = CoreManager.MomConsole.GetIntlStr(
                        ResourceDesignerConfirmingFileMenuDelete);
                }
                return Strings.cachedDesignerConfirmingFileMenuDelete;
            }
        }

        /// <summary>
        /// Service Designer's Delete Service dialog title
        /// </summary>
        public static string MomDialogTitle
        {
            get
            {
                if ((Strings.cachedMomDialogTitle == null))
                {
                    cachedMomDialogTitle = CoreManager.MomConsole.GetIntlStr(
                        ResourceMomDialogTitle);
                }
                return Strings.cachedMomDialogTitle;
            }
        }        /// <summary>
        /// Service Designer's Delete Service dialog title
        /// </summary>
        public static string ConfirmServiceDeleteDialogTitle
        {
            get
            {
                if ((Strings.cachedConfirmServiceDeleteDialogTitle == null))
                {
                    cachedConfirmServiceDeleteDialogTitle = CoreManager.MomConsole.GetIntlStr(
                        ResourceConfirmServiceDeleteDialogTitle);
                }
                return Strings.cachedConfirmServiceDeleteDialogTitle;
            }
        }        /// <summary>
        /// Service Designer dialog title
        /// </summary>
        public static string ServiceDesigner
        {
            get
            {
                if ((Strings.cachedServiceDesigner == null))
                {
                    cachedServiceDesigner = CoreManager.MomConsole.GetIntlStr(
                        ResourceServiceDesigner);
                }
                return Strings.cachedServiceDesigner;
            }
        }
        /// <summary>
        /// Service Designer Design Surface Menubar's File option
        /// </summary>
        public static string MenuBarFileOption
        {
            get
            {
                if ((Strings.cachedMenuBarFileOption == null))
                {
                    cachedMenuBarFileOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceMenuBarFileOption);
                }
                return Strings.cachedMenuBarFileOption;
            }
            set { Strings.cachedMenuBarFileOption = value; }
        }
        /// <summary>
        /// Service Designer File menu Save option
        /// </summary>
        public static string FileMenuSaveOption
        {
            get
            {
                if ((Strings.cachedFileMenuSaveOption == null))
                {
                    cachedFileMenuSaveOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceFileMenuSaveOption);
                }
                return Strings.cachedFileMenuSaveOption;
            }
        }
        /// <summary>
        /// Service Designer File menu Close option
        /// </summary>
        public static string FileMenuCloseOption
        {
            get
            {
                if ((Strings.cachedFileMenuCloseOption == null))
                {
                    cachedFileMenuCloseOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceFileMenuCloseOption);
                }
                return Strings.cachedFileMenuCloseOption;
            }
        }
        /// <summary>
        /// Service Designer File menu Properties option
        /// </summary>
        public static string FileMenuPropertiesOption
        {
            get
            {
                if ((Strings.cachedFileMenuPropertiesOption == null))
                {
                    cachedFileMenuPropertiesOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceFileMenuPropertiesOption);
                }
                return Strings.cachedFileMenuPropertiesOption;
            }
        }
        /// <summary>
        /// Service Designer File menu Save as Template option
        /// </summary>
        public static string FileMenuSaveasTemplateOption
        {
            get
            {
                if ((Strings.cachedFileMenuSaveasTemplateOption == null))
                {
                    cachedFileMenuSaveasTemplateOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceFileMenuSaveasTemplateOption);
                }
                return Strings.cachedFileMenuSaveasTemplateOption;
            }
        }

        /// <summary>
        /// Service Designer File menu Properties option
        /// </summary>
        public static string FileMenuDeleteOption
        {
            get
            {
                if ((Strings.cachedFileMenuDeleteOption == null))
                {
                    cachedFileMenuDeleteOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceFileMenuDeleteOption);
                }
                return Strings.cachedFileMenuDeleteOption;
            }
        }

        /// <summary>
        /// Service Designer File menu New option
        /// </summary>
        public static string FileMenuNewOption
        {
            get
            {
                if ((Strings.cachedFileMenuNewOption == null))
                {
                    cachedFileMenuNewOption = CoreManager.MomConsole.GetIntlStr(
                        ResourceFileMenuNewOption);
                }
                return Strings.cachedFileMenuNewOption;
            }
        } 

        /// <summary>
        /// Name of non-editable service 
        /// </summary>
        /// TODO: do we need to localize this string?
        public readonly static string MomMgmtGroup = "Operations Manager Management Group";
        /// <summary>
        /// Grid view's column number for the Service name value
        /// </summary>
        public readonly static int ServiceNameColumnNumber = 0;
        /// <summary>
        /// toolStripContainer used by Object Picker in Service Designer
        /// </summary>
        public static string ToolStripContainer
        {
            get
            {
                if ((Strings.cachedtoolStripContainer == null))
                {
                    cachedtoolStripContainer = CoreManager.MomConsole.GetIntlStr(
                        ResourceToolStripContainer);
                }
                return Strings.cachedtoolStripContainer;
            }
        } 

        /// <summary>
        /// Service in Object Picker in Service Designer
        /// </summary>
        public static string Service
        {
            get
            {
                if ((Strings.cachedService == null))
                {
                    cachedService = CoreManager.MomConsole.GetIntlStr(
                        ResourceService);
                }
                return Strings.cachedService;
            }
        }

        /// <summary>
        /// Add To menu item in Object Picker in Service Designer
        /// </summary>
        public static string AddTo
        {
            get
            {
                if ((Strings.cachedAddTo == null))
                {
                    cachedAddTo = CoreManager.MomConsole.GetIntlStr(
                        ResourceAddTo);
                }
                return Strings.cachedAddTo;
            }
        }

        #region Get Strings from MP

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  AdministrationItem
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedAdministrationItem;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  GlobalSettings
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedGlobalSettings;
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  Object
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedObject;

        /// <summary>
        /// Administration Item Guid(
        /// </summary>
        private static Guid AdministrationItemGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemAdminItemLibraryMP, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SysemAdminItemName);

        // <summary>
        /// Global Settings Guid
        /// </summary>
        private static Guid GlobalSettingsGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemAdminItemLibraryMP, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.GlobalSettingsName);

        // <summary>
        /// Object Guid
        /// </summary>
        private static Guid ObjectGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ObjectName);

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the AdministrationItem translated resource string
        /// </summary>
        /// <history>
        /// 	
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string AdministrationItem
        {
            get
            {
                if ((cachedAdministrationItem == null))
                {
                    cachedAdministrationItem = Common.Utilities.GetEntityName(Convert.ToString(AdministrationItemGuid));
                }
                return cachedAdministrationItem;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the GlobalSettings translated resource string
        /// </summary>
        /// <history>
        /// 	
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string GlobalSettings
        {
            get
            {
                if ((cachedGlobalSettings == null))
                {
                    cachedGlobalSettings = Common.Utilities.GetEntityName(Convert.ToString(GlobalSettingsGuid));
                }
                return cachedGlobalSettings;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Object translated resource string
        /// </summary>
        /// <history>
        /// 	
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string Object
        {
            get
            {
                if ((cachedObject == null))
                {
                    cachedObject = Common.Utilities.GetEntityName(Convert.ToString(ObjectGuid));
                }
                return cachedObject;
            }
        }
        #endregion
    }
}
