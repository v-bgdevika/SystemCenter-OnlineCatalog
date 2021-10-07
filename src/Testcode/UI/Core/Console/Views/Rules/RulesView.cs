//-------------------------------------------------------------------
// <copyright file="RulesView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Rules Views related code (Storing Constants for Rules View Guids and Resource strings)
// </summary>
//  <history>
//   [ruhim] 16NOV05: Created
//  </history>
//-------------------------------------------------------------------


#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using Microsoft.EnterpriseManagement.Mom.Internal;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using System.ComponentModel;
using System;
#endregion


namespace Mom.Test.UI.Core.Console.Views.Rules
{
    /// <summary>
    /// Class to add general methods for Rules view under Monitoring Configuration
    /// </summary>
    public class RulesView
    {

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Rules View
        /// </summary>
        /// <history> 	
        ///   [ruhim]  16NOV05: Adding resource strings for Rules View Headers and 
        ///                     GUIDS for Rules targeted to NT Service
        ///   [a-joelj] 19MAR09 Added GUID for AEM: Error Alert Rule
        ///   [v-waltli] 18JUN09 Added resource strings for 
        ///                      Properties context menu item in Rules View
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains resource string for: Category Column header under Rules View        
            /// </summary>
            private const string ResourceCategoryColumnHeader =
            ";Category;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView;CategoryColumn";

            /// <summary>
            /// Contains resource string for: Name Column header under Rules View        
            /// </summary>
            private const string ResourceNameColumnHeader =
            ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView;NameColumn";

            /// <summary>
            /// Contains resource string for: Properties Context Menu
            /// </summary>
            private const string ResourceContextMenuProperties =
                ";Propert&ies;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PropertiesMenuText";


            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectStateChangeAlert Rule
            /// </summary>            
            private const string NTCollectStateChangeAlertRuleGUID = "FEB23522-B5E0-A444-0706-79247CD9F082";

            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectPerfAlert Rule
            /// </summary>            
            private const string NTCollectPerfAlertRuleGUID = "B9E13EBA-D353-2B73-81B6-8D69721ABFDA";

            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectSCMEvent Rule
            /// </summary>            
            private const string NTCollectSCMEventRuleGUID = "89C3C79E-278D-2F6E-52E0-C7FEA7F3C2F0";

            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectHandleCount Rule
            /// </summary>            
            private const string NTCollectHandleCountRuleGUID = "483EA957-AD22-1698-65EE-0290CCEC2230";

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.CollectProcessorTimeSignature Rule
            /// </summary>            
            private const string NTCollectProcessorTimeSignatureRuleGUID = "54C81223-FDCC-DAA6-61A0-049356B12689";

            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectWorkingSet Rule
            /// </summary>            
            private const string NTCollectWorkingSetRuleGUID = "D821F828-80C7-74C2-21A2-2A8F50B49BCF";

            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectPercentProcessorTime Rule
            /// </summary>            
            private const string NTCollectPercentProcessorTimeRuleGUID = "1C5FF1E3-5237-2D93-CC68-542126B7DA81";

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.CollectHandleCountSignature Rule
            /// </summary>            
            private const string NTCollectHandleCountSignatureRuleGUID = "6421FF2D-D350-29BA-DE4A-60C323F8FF43";

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.CollectThreadCountSignature Rule
            /// </summary>            
            private const string NTCollectThreadCountSignatureRuleGUID = "38230A90-155A-DABD-CE73-8B8123DECF82";

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.CollectWorkingSetSignature Rule
            /// </summary>            
            private const string NTCollectWorkingSetSignatureRuleGUID = "AB621FBC-2E5F-00D1-966D-9899B27CBFEA";

            /// <summary>
            /// Contains GUID for: System.Windows.NTService.CollectThreadCount Rule
            /// </summary>            
            private const string NTCollectThreadCountRuleGUID = "35510E7C-62D3-9A04-AAF0-FF8C2C5428E0";
            
            #endregion

            #region Private GUIDs

            /// <summary>
            /// AEM: File Share Error AlertMessage Guid
            /// </summary>
            private static Guid AEMFileShareErrorAlertMessageGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenter2007MPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.AEMFileShareErrorAlert);

            #endregion
            
            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Category Column header under Rules View 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCategoryColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Column header under Rules View 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Properties Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.NTService.CollectStateChangeAlert Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectStateChangeAlertRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.NTService.CollectPerfAlert Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectPerfAlertRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.NTService.CollectSCMEvent Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectSCMEventRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.NTService.CollectHandleCount Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectHandleCountRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.CollectProcessorTimeSignature Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectProcessorTimeSignatureRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for:System.Windows.NTService.CollectWorkingSet Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectWorkingSetRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.NTService.CollectPercentProcessorTime Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectPercentProcessorTimeRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.CollectHandleCountSignature Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectHandleCountSignatureRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.CollectThreadCountSignature Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectThreadCountSignatureRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.CollectWorkingSetSignature Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectWorkingSetSignatureRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.NTService.CollectThreadCount Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTCollectThreadCountRule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.CM.AEM.FileShareError.Alert Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAEMFileShareErrorAlertRule;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category Column header under Rules View translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CategoryColumnHeader
            {
                get
                {
                    if ((cachedCategoryColumnHeader == null))
                    {
                        cachedCategoryColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceCategoryColumnHeader);
                    }

                    return cachedCategoryColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name Column header under Rules View translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NameColumnHeader
            {
                get
                {
                    if ((cachedNameColumnHeader == null))
                    {
                        cachedNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceNameColumnHeader);
                    }

                    return cachedNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties context menu item in Rules View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 18JUN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuProperties
            {
                get
                {
                    if ((cachedContextMenuProperties == null))
                    {
                        cachedContextMenuProperties = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuProperties);
                    }
                    return cachedContextMenuProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectStateChangeAlert Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectStateChangeAlertRule
            {
                get
                {
                    if ((cachedNTCollectStateChangeAlertRule == null))
                    {
                        cachedNTCollectStateChangeAlertRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDNTServiceManagedType, NTCollectStateChangeAlertRuleGUID);
                    }

                    return cachedNTCollectStateChangeAlertRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectPerfAlert Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectPerfAlertRule
            {
                get
                {
                    if ((cachedNTCollectPerfAlertRule == null))
                    {
                        cachedNTCollectPerfAlertRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDNTServiceManagedType, NTCollectPerfAlertRuleGUID);
                    }

                    return cachedNTCollectPerfAlertRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectSCMEvent Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectSCMEventRule
            {
                get
                {
                    if ((cachedNTCollectSCMEventRule == null))
                    {
                        cachedNTCollectSCMEventRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDNTServiceManagedType, NTCollectSCMEventRuleGUID);
                    }

                    return cachedNTCollectSCMEventRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectHandleCount Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectHandleCountRule
            {
                get
                {
                    if ((cachedNTCollectHandleCountRule == null))
                    {
                        cachedNTCollectHandleCountRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectHandleCountRuleGUID);
                    }

                    return cachedNTCollectHandleCountRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.CollectProcessorTimeSignature Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectProcessorTimeSignatureRule
            {
                get
                {
                    if ((cachedNTCollectProcessorTimeSignatureRule == null))
                    {
                        cachedNTCollectProcessorTimeSignatureRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectProcessorTimeSignatureRuleGUID);
                    }

                    return cachedNTCollectProcessorTimeSignatureRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectWorkingSet Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectWorkingSetRule
            {
                get
                {
                    if ((cachedNTCollectWorkingSetRule == null))
                    {
                        cachedNTCollectWorkingSetRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectWorkingSetRuleGUID);
                    }

                    return cachedNTCollectWorkingSetRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectPercentProcessorTime Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectPercentProcessorTimeRule
            {
                get
                {
                    if ((cachedNTCollectPercentProcessorTimeRule == null))
                    {
                        cachedNTCollectPercentProcessorTimeRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectPercentProcessorTimeRuleGUID);
                    }

                    return cachedNTCollectPercentProcessorTimeRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.CollectHandleCountSignature Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectHandleCountSignatureRule
            {
                get
                {
                    if ((cachedNTCollectHandleCountSignatureRule == null))
                    {
                        cachedNTCollectHandleCountSignatureRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectHandleCountSignatureRuleGUID);
                    }

                    return cachedNTCollectHandleCountSignatureRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.CollectThreadCountSignature Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectThreadCountSignatureRule
            {
                get
                {
                    if ((cachedNTCollectThreadCountSignatureRule == null))
                    {
                        cachedNTCollectThreadCountSignatureRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectThreadCountSignatureRuleGUID);
                    }

                    return cachedNTCollectThreadCountSignatureRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.CollectWorkingSetSignature Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectWorkingSetSignatureRule
            {
                get
                {
                    if ((cachedNTCollectWorkingSetSignatureRule == null))
                    {
                        cachedNTCollectWorkingSetSignatureRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectWorkingSetSignatureRuleGUID);
                    }

                    return cachedNTCollectWorkingSetSignatureRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.NTService.CollectThreadCount Rule
            /// </summary>
            /// <history>
            /// 	[ruhim] 16NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTCollectThreadCountRule
            {
                get
                {
                    if ((cachedNTCollectThreadCountRule == null))
                    {
                        cachedNTCollectThreadCountRule = Common.Utilities.GetMonitoringRuleName(Constants.GUIDOwnProcessNTServiceManagedType, NTCollectThreadCountRuleGUID);
                    }

                    return cachedNTCollectThreadCountRule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.CM.AEM.FileShareError.Alert Rule
            /// </summary>
            /// <history>
            /// 	[a-joelj] 18MAR09: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AEMFileShareErrorAlertRule
            {
                get
                {
                    if ((cachedAEMFileShareErrorAlertRule == null))
                    {
                        cachedAEMFileShareErrorAlertRule = Utilities.GetMonitoringRuleAlertName(AEMFileShareErrorAlertMessageGuid);
                    }

                    return cachedAEMFileShareErrorAlertRule;
                }
            }
            #endregion
            
        }
        #endregion

    } //end of class RulesView

}//end of namespace