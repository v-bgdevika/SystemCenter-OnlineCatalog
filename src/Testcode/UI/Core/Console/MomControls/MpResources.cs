using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.Console.MomControls
{
    public class MpResources
    {
        /// <summary>
        /// ConfigurationLibraryMp to access strings from this MP
        /// </summary>
        public static class ConfigurationLibraryMp 
        {
            private static string managementPackGuid =
                ManagementPackConstants.GUIDSystemCenterVisualizationConfigurationLibraryMP;

            /// <summary>
            /// Strings Class
            /// </summary>
            public static class GetLocalizedResource
            {
                private const string ResourceCreateTemplateInstanceWizardTitle = "Microsoft.SystemCenter.CreateTemplateInstanceWizard.Title";
                private const string ResourceWizardDialogWithCustomPagesTitle = "Microsoft.SystemCenter.WizardDialogWithCustomPages.Title";
                private const string ResourceRevertButtonName = "Microsoft.SystemCenter.AddUpdatePersonalizationWizard.RevertActionName";
                private static string cachedCreateTemplateInstanceWizardTitle;
                private static string cachedWizardDialogWithCustomPagesTitle;
                private static string cachedRevertButtonName;

                /// <summary>
                /// CreateTemplateInstanceWizardTitle localized string
                /// </summary>
                public static String CreateTemplateInstanceWizardTitle
                {
                    get
                    {
                        if (cachedCreateTemplateInstanceWizardTitle == null)
                        {
                            cachedCreateTemplateInstanceWizardTitle = Utilities.GetManagementPackStringResourceDisplayName(managementPackGuid, ResourceCreateTemplateInstanceWizardTitle);
                        }

                        return cachedCreateTemplateInstanceWizardTitle;
                    }
                }

                /// <summary>
                /// WizardDialogWithCustomPagesTitle localized string
                /// </summary>
                public static String WizardDialogWithCustomPagesTitle
                {
                    get
                    {
                        if (cachedWizardDialogWithCustomPagesTitle == null)
                        {
                            cachedWizardDialogWithCustomPagesTitle = Utilities.GetManagementPackStringResourceDisplayName(managementPackGuid, ResourceWizardDialogWithCustomPagesTitle);
                        }

                        return cachedWizardDialogWithCustomPagesTitle;
                    }
                }

                /// <summary>
                /// RevertButtonName localized string
                /// </summary>
                public static String RevertButtonName
                {
                    get
                    {
                        if (cachedRevertButtonName == null)
                        {
                            cachedRevertButtonName = Utilities.GetManagementPackStringResourceDisplayName(managementPackGuid, ResourceRevertButtonName);
                        }

                        return cachedRevertButtonName;
                    }
                }
            }

        }

    }
}
