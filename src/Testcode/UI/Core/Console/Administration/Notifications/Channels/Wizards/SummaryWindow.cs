// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SummaryWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  11-AUG-08   Created
//  [KellyMor]  13-AUG-08   Updated control ID's and resource strings.
//  [KellyMor]  18-AUG-08   Added control for results text/label.
//                          Updated Email and IM wizard title resources.
//                          Added resources for channel saved, success and
//                          failure.
//  [KellyMor]  22-AUG-08   Updated resource strings
//  [KellyMor]  04-SEP-08   Added control for Error Details link label
//                          Added new resource string for channel save failed
//                          Added method to check for presence of error details
//                          link label to determine if save operation failed.
//                          Updated channel wizard title strings
//  [KellyMor]  06-SEP-08   Updated resource strings for move from Administration
//                          library to components library.
//  [KellyMor]  08-SEP-08   StyleCop fixes.
//  [KellyMor]  10-SEP-08   More updates for resource string move to components
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - ISummaryWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISummaryWindow, for 
    /// SummaryWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISummaryWindow
    {
        /// <summary>
        /// Read-only property to access ChannelCompleteStaticControl
        /// </summary>
        StaticControl ChannelCompleteStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExitWizardStaticControl
        /// </summary>
        StaticControl ExitWizardStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ResultsStaticControl
        /// </summary>
        StaticControl ResultsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ErrorDetailsStaticControl
        /// </summary>
        StaticControl ErrorDetailsStaticControl
        {
            get;
        }
    }

    #endregion Interface Definition - ISummaryWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Name and Description step
    /// in the Create Notification Channel Wizard.  This class is used by all
    /// types of the channel wizard:  email, IM, SMS, and command.
    /// </summary>
    /// <history>
    ///     [KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SummaryWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, ISummaryWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to ChannelCompleteStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedChannelCompleteStaticControl;

        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExitWizardStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedExitWizardStaticControl;

        /// <summary>
        /// Cache to hold a reference to cachedResultsStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedResultsStaticControl;

        /// <summary>
        /// Cache to hold a reference to cachedErrorDetailsStaticControlof type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedErrorDetailsStaticControl;

        #endregion Private Members

        #region Constructors

        /// -----------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of ConsoleWizardBase of type ConsoleApp
        /// </param>
        /// <param name="wizardTitle">
        /// Wizard window title string.
        /// </param>
        /// <history>
        ///     [KellyMor] 11-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public SummaryWindow(ConsoleApp app, string wizardTitle)
            : base(app, wizardTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

        #region Interface Control Properties

        #region ISummaryWindow Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new ISummaryWindow Controls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IConsoleWizardBase Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for the base class of the 
        /// dialog.
        /// </summary>
        /// <value>
        /// An interface that groups all of the base class dialog's control 
        /// properties together.
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion

        #endregion

        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelCompleteStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ChannelCompleteStaticControl
        {
            get
            {
                if (null == this.cachedChannelCompleteStaticControl)
                {
                    this.cachedChannelCompleteStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ChannelCompleteStaticControl);
                }

                return this.cachedChannelCompleteStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.DescriptionStaticControl
        {
            get
            {
                if (null == this.cachedDescriptionStaticControl)
                {
                    this.cachedDescriptionStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.DescriptionStaticControl);
                }

                return this.cachedDescriptionStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExitWizardStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ExitWizardStaticControl
        {
            get
            {
                if (null == this.cachedExitWizardStaticControl)
                {
                    this.cachedExitWizardStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ExitWizardStaticControl);
                }

                return this.cachedExitWizardStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResultsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ResultsStaticControl
        {
            get
            {
                if (null == this.cachedResultsStaticControl)
                {
                    this.cachedResultsStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ResultsStaticControl);
                }

                return this.cachedResultsStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ErrorDetailsStaticControl
        {
            get
            {
                if (this.cachedErrorDetailsStaticControl == null)
                {
                    this.cachedErrorDetailsStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ErrorDetailsStaticControl);
                }

                return this.cachedErrorDetailsStaticControl;
            }
        }

        #endregion Control Properties

        #region SummaryWindow Methods

        /// <summary>
        /// Method to determine of a channel save operation failed.
        /// </summary>
        /// <returns>True if the error details label is visible.</returns>
        public bool ChannelSaveFailed()
        {
            bool hasChannelSaveFailed = false;

            try
            {
                // look for the Error Details label
                if (this.Controls.ErrorDetailsStaticControl.IsEnabled &&
                    this.Controls.ErrorDetailsStaticControl.IsVisible)
                {
                    hasChannelSaveFailed = true;
                }
                else
                {
                    hasChannelSaveFailed = false;
                }

                return hasChannelSaveFailed;
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Core.Common.Utilities.LogMessage(
                    "SummarWindow.ChannelSaveFailed::Failed to find the 'Error Details' link.");

                hasChannelSaveFailed = false;

                return hasChannelSaveFailed;
            }
        }

        #endregion

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceEmailChannelWizardTitle =
                ";E-Mail Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstantMessageChannelWizardTitle =
                ";IM Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";IMChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSmsChannelWizardTitle =
                ";SMS Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCommandChannelWizardTitle =
                ";Command Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";CommandChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ChannelComplete label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceChannelComplete =
                ";Saving notification channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChannelCompletionPage" +
                ";pageSectionLabel.Text";
                        
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Description label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDescription = 
                "You have successfully completed the {0} Notification Channel Wizard.";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ResourceSavingChannel label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSavingChannel =
                ";Saving notification channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChannelCompletionPage" +
                ";pageSectionLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ChannelSavedSuccessfully label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceChannelSavedSuccessfully =
                ";Channel saved successfully." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelSaved";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ChannelSaveFailed label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceChannelSaveFailed =
                ";Failed to save the Notification Channel.{0}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelSaveError";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ErrorLink label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceErrorLink =
                ";Error Details" + 
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChannelCompletionPage" +
                ";errorLinkLabel.Text";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the email channel wizard window 
            /// title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedEmailChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the instant message channel 
            /// wizard window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstantMessageChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the SMS channel wizard window 
            /// title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSmsChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the command channel wizard 
            /// window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCommandChannelWizardTitle;
 
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ChannelComplete label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedChannelComplete;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Description label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDescription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ChannelSavedSuccessfully 
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedChannelSavedSuccessfully;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ChannelSaveFailed 
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedChannelSaveFailed;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ErrorLink label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedErrorLink;

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EmailChannelWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string EmailChannelWizardTitle
            {
                get
                {
                    if ((cachedEmailChannelWizardTitle == null))
                    {
                        cachedEmailChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEmailChannelWizardTitle);
                    }

                    return cachedEmailChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InstantMessageChannelWizardTitle 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string InstantMessageChannelWizardTitle
            {
                get
                {
                    if ((cachedInstantMessageChannelWizardTitle == null))
                    {
                        cachedInstantMessageChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstantMessageChannelWizardTitle);
                    }

                    return cachedInstantMessageChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SmsChannelWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SmsChannelWizardTitle
            {
                get
                {
                    if ((cachedSmsChannelWizardTitle == null))
                    {
                        cachedSmsChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSmsChannelWizardTitle);
                    }

                    return cachedSmsChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommandChannelWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CommandChannelWizardTitle
            {
                get
                {
                    if ((cachedCommandChannelWizardTitle == null))
                    {
                        cachedCommandChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCommandChannelWizardTitle);
                    }

                    return cachedCommandChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChannelComplete translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ChannelComplete
            {
                get
                {
                    if ((cachedChannelComplete == null))
                    {
                        cachedChannelComplete =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceChannelComplete);
                    }

                    return cachedChannelComplete;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDescription);
                    }

                    return cachedDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChannelSavedSuccessfully translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ChannelSavedSuccessfully
            {
                get
                {
                    if ((cachedChannelSavedSuccessfully == null))
                    {
                        cachedChannelSavedSuccessfully =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceChannelSavedSuccessfully);
                    }

                    return cachedChannelSavedSuccessfully;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChannelSaveFailed translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ChannelSaveFailed
            {
                get
                {
                    if ((cachedChannelSaveFailed == null))
                    {
                        cachedChannelSaveFailed =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceChannelSaveFailed);
                    }

                    return cachedChannelSaveFailed;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorLink translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ErrorLink
            {
                get
                {
                    if ((cachedErrorLink == null))
                    {
                        cachedErrorLink =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceErrorLink);
                    }

                    return cachedErrorLink;
                }
            }

            #endregion Properties
        }

        #endregion Strings

        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for ChannelCompleteStaticControl
            /// </summary>
            public const string ChannelCompleteStaticControl = "pageSectionLabel";

            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "label2";

            /// <summary>
            /// Control ID for ExitWizardStaticControl
            /// </summary>
            public const string ExitWizardStaticControl = "label3";

            /// <summary>
            /// Control ID for ResultsStaticControl
            /// </summary>
            public const string ResultsStaticControl = "resultLabel";

            /// <summary>
            /// Control ID for ErrorDetailsStaticControl
            /// </summary>
            public const string ErrorDetailsStaticControl = "errorLinkLabel";
        }

        #endregion Control ID's
    }
}
