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
// 	[KellyMor]  22-AUG-08   Created
//  [KellyMor]  09-SEP-08   Modified string references for subsriber saved text
//  [KellyMor]  23-SEP-08   Updated control ID's.
//                          Updated resource strings.
//                          Added ChannelSaveFailed method
//  [KellyMor}  27-SEP-08   Updated resource string for wizard window title
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers.Wizards
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
    public class SummaryWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        ISummaryWindow
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
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberAddressWizardTitle =
                ";Subscriber Address" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";DeviceWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberWizardTitle =
                ";Notification Subscriber Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriberWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SubscriberComplete label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberComplete = 
                "izard complete!";
                        
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Description label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDescription = 
                "You have successfully completed the %1 Wizard.";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ExitEmailChannelWizard label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceExitSubscriberWizard =
                ";To exit the wizard click Close." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SMTPChannelCompletionPage" +
                ";label3.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the 
            /// ExitInstantMessageChannelWizard label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceExitSubscriberAddressWizard =
                ";To exit the wizard click Close." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.IMChannelCompletionPage" +
                ";label3.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SavingSubscriber label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSavingSubscriber =
                ";Saving recipient..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SavingRecipientText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SubscriberSavedSuccessfully
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberSavedSuccessfully =
                ";Recipient saved successfully." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";RecipientSaved";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SubscriberSaveFailed label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberSaveFailed =
                ";Failed to save the Notification Recipient.\n\n{0}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";RecipientSaveError";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the email channel wizard window 
            /// title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the instant message channel 
            /// wizard window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberAddressWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the SubscriberComplete label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberComplete;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Description label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDescription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ExitEmailChannelWizard label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedExitSubscriberWizard;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// ExitInstantMessageChannelWizard label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedExitSubscriberAddressWizard;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the SubscriberSavedSuccessfully 
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberSavedSuccessfully;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the SubscriberSaveFailed label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberSaveFailed;

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
            public static string SubscriberWizardTitle
            {
                get
                {
                    if ((cachedSubscriberWizardTitle == null))
                    {
                        cachedSubscriberWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberWizardTitle);
                    }

                    return cachedSubscriberWizardTitle;
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
            public static string SubscriberAddressWizardTitle
            {
                get
                {
                    if ((cachedSubscriberAddressWizardTitle == null))
                    {
                        cachedSubscriberAddressWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberAddressWizardTitle);
                    }

                    return cachedSubscriberAddressWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriberComplete translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriberComplete
            {
                get
                {
                    if ((cachedSubscriberComplete == null))
                    {
                        cachedSubscriberComplete =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberComplete);
                    }

                    return cachedSubscriberComplete;
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
            /// Exposes access to the ExitEmailChannelWizard translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ExitSubscriberWizard
            {
                get
                {
                    if ((cachedExitSubscriberWizard == null))
                    {
                        cachedExitSubscriberWizard =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceExitSubscriberWizard);
                    }

                    return cachedExitSubscriberWizard;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExitInstantMessageChannelWizard 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ExitSubscriberAddressWizard
            {
                get
                {
                    if ((cachedExitSubscriberAddressWizard == null))
                    {
                        cachedExitSubscriberAddressWizard =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceExitSubscriberAddressWizard);
                    }

                    return cachedExitSubscriberAddressWizard;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriberSavedSuccessfully translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriberSavedSuccessfully
            {
                get
                {
                    if ((cachedSubscriberSavedSuccessfully == null))
                    {
                        cachedSubscriberSavedSuccessfully =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberSavedSuccessfully);
                    }

                    return cachedSubscriberSavedSuccessfully;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriberSaveFailed translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriberSaveFailed
            {
                get
                {
                    if ((cachedSubscriberSaveFailed == null))
                    {
                        cachedSubscriberSaveFailed =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberSaveFailed);
                    }

                    return cachedSubscriberSaveFailed;
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
