//-----------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Notification support functionality.
// </summary>
// 
//  <history>
//  [KellyMor]  31-JUL-08   Created
//  [KellyMor]  04-AUG-08   Added method to create subscribers
//  [KellyMor]  26-AUG-08   Implemented common methods for creating channels.
//                          Added common channel methods with minimum sets of
//                          parameters to improve discoverability and usability
//  [KellyMor]  08-SEP-08   StyleCop fixes.
//  [KellyMor]  10-SEP-08   Updated to use correct PortNumberText field.
//  [KellyMor]  27-SEP-08   Updated to use correct context menu resources.
//                          Added checks for null or empty subject and message
//                          text in email, IM, and SMS methods.
//  [KellyMor]  29-SEP-08   Initial implementation of SpecifySubscriber.
//  [KellyMor]  01-OCT-08   SpecifySubscriber complete
//  [KellyMor]  10-OCT-08   Initial implementation of CreateSubscrirption.
//  [KellyMor]  11-OCT-08   More implementation work on CreateSubscrirption.
//  [KellyMor]  14-OCT-08   Completed implementation of CreateSubscrirption.
//  [KellyMor]  28-OCT-08   Fixed logic error checking for default message text
//                          constant in CreateEmailChannel.
//  [KellyMor]  29-OCT-08   Added call to SetCriteria in CreateSubscription.
//  </history>
//-----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Administration.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infra.Frmwrk;
    using Mom.Test.UI.Core.Console.Administration.Notifications.Channels;
    using Mom.Test.UI.Core.Console.Notifications.Recipients;
    using Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;

    /// <summary>
    /// Utility class to contain common notification methods.  Note that, all
    /// these methods require SCOM Administrator access.
    /// </summary>
    public sealed class Utilities
    {
        #region Channels

        /// <summary>
        /// Method to create an email notification channel or end-point.
        /// </summary>
        /// <param name="mailServerNetworkName">
        /// The network name of the primary mail server.
        /// </param>
        /// <param name="replyToAddress">
        /// The reply to or return address used for sending mail.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if mailServerNetworkName, replyToAddress are null or empty string.
        /// </exception>
        public static void CreateEmailChannel(
            string mailServerNetworkName,
            string replyToAddress)
        {
            #region Validate Parameters

            // check for valid parameters
            if (String.IsNullOrEmpty(mailServerNetworkName))
            {
                throw new System.ArgumentNullException(
                    "Mail server network name must not be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(replyToAddress))
            {
                throw new System.ArgumentNullException(
                    "Reply to address must not be null or empty string!");
            }
            else
            {
                // check reply to addres for proper email format
                if (false == replyToAddress.Contains(Channels.CommonChannel.Constants.EmailAddressIdentifier))
                {
                    throw new System.ArgumentException(
                        "Reply to address is not in the proper format!");
                }
            }

            #endregion Validate Parameters

            // create an email channel parameters class
            Channels.EmailChannelParams emailChannel =
                new Channels.EmailChannelParams(
                    mailServerNetworkName,
                    replyToAddress);

            // pass the new parameters class to the core method
            CreateEmailChannel(emailChannel);
        }

        /// <summary>
        /// Method to create an email notification channel or end-point.
        /// </summary>
        /// <param name="emailChannel">
        /// An instance of a Channels.EmailChannelParams class.  This instance
        /// contains all the necessary information to create the channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if emailChannel is null.
        /// </exception>
        public static void CreateEmailChannel(
            Channels.EmailChannelParams emailChannel)
        {
            // check for valid email channel
            if (null == emailChannel)
            {
                throw new System.ArgumentNullException(
                    "Email channel parameters instance must not be null!");
            }

            OpenChannelWizardWhenInChannelsViewPane();

            // get a reference to the wizard base class
            Core.Console.Administration.ConsoleWizardBase wizardWindow =
                new ConsoleWizardBase(
                    CoreManager.MomConsole,
                    Channels.Wizards.NameAndDescriptionWindow.Strings.EmailChannelWizardTitle);

            // set name and description
            Channels.CommonChannel.SetNameAndDescription(
                Channels.Wizards.NameAndDescriptionWindow.Strings.EmailChannelWizardTitle,
                emailChannel.ChannelName,
                emailChannel.ChannelDescription);

            // click Next
            wizardWindow.ClickNext();

            #region Settings Step

            // set the email servers
            Channels.CommonChannel.SetEmailServers(
                emailChannel.NotificationServers);

            // get a reference to the wizard window
            Channels.Wizards.EmailSettingsWindow channelSettingsWindow =
                new Channels.Wizards.EmailSettingsWindow(
                    CoreManager.MomConsole);

            // set the return address
            channelSettingsWindow.ReturnAddressText =
                emailChannel.ReturnAddress;

            // set the retry interval
            channelSettingsWindow.RetryPrimaryAfterText =
                emailChannel.RetryInterval.ToString();

            // drop the settings window reference
            channelSettingsWindow = null;

            #endregion Settings Step

            // click Next
            wizardWindow.ClickNext();

            #region Format Step

            // get a reference to the "Format" wizard window
            Channels.Wizards.EmailFormatWindow channelFormatWindow =
                new Channels.Wizards.EmailFormatWindow(
                    CoreManager.MomConsole);

            //Verify the UI control changes when Html checkbox is enabled.
            VerifyHtmlBodyCheckBoxDefaults(channelFormatWindow);
            //Set the bool Value for Html body
            channelFormatWindow.Controls.IsHtmlBody.Checked = emailChannel.IsBodyHtml;

            #region Subject Text

            // check option for using subject text default value
            if (String.IsNullOrEmpty(emailChannel.SubjectText) ||
                emailChannel.SubjectText.Equals(Channels.CommonChannel.Constants.DefaultValue))
            {
                // leave the current subject in place
                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Using default subject text := '" +
                    channelFormatWindow.SubjectText +
                    "'");
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Clearing subject text...'");

                // clear the text box
                channelFormatWindow.Controls.SubjectTextBox.Text =
                    string.Empty;
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Setting subject text to := '" +
                    channelFormatWindow.SubjectText +
                    "'");

                Channels.CommonChannel.ProcessMessageText(
                    emailChannel.SubjectText,
                    channelFormatWindow.Controls.SubjectTextBox,
                    channelFormatWindow.Controls.SubjectAlertParametersButton);

                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Message subject text set to := '" +
                    channelFormatWindow.SubjectText +
                    "'");
            }

            #endregion Subject Text

            Core.Common.Utilities.LogMessage(
                "CreateEmailChannel::Setting override subject encoding option to := '" +
                emailChannel.OverrideSubjectEncoding.ToString() +
                "'");

            // set option overrride subject encoding option
            channelFormatWindow.OverrideSubjectEncoding =
                emailChannel.OverrideSubjectEncoding;

            #region Message Text

            // check option for using message body text default value
            if (String.IsNullOrEmpty(emailChannel.MessageText) ||
                emailChannel.MessageText.Equals(Channels.CommonChannel.Constants.DefaultValue))
            {
                // leave the current message body text in place
                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Using default message text := '" +
                    channelFormatWindow.MessageBodyText +
                    "'");
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Clearing subject text...'");

                // clear the text box
                channelFormatWindow.Controls.MessageBodyTextBox.Text =
                    string.Empty;
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Setting message text to := '" +
                    channelFormatWindow.MessageBodyText +
                    "'");

                Channels.CommonChannel.ProcessMessageText(
                    emailChannel.MessageText,
                    channelFormatWindow.Controls.MessageBodyTextBox,
                    channelFormatWindow.Controls.MessageBodyAlertParametersButton);

                Core.Common.Utilities.LogMessage(
                    "CreateEmailChannel::Message body text set to := '" +
                    channelFormatWindow.MessageBodyText +
                    "'");
            }

            #endregion Message Text

            #region Message Importance

            // click the combobox drop-down button
            channelFormatWindow.Controls.ImportanceLevelComboBox.ClickDropDown();

            // get the translated resource string for importance
            string importanceText = null;
            switch (emailChannel.MessageImportance)
            {
                case Channels.EmailChannelParams.MessageImportanceLevels.High:
                {
                    importanceText =
                        Channels.Wizards.EmailFormatWindow.Strings.HighImportance;
                }

                    break;
                case Channels.EmailChannelParams.MessageImportanceLevels.Medium:
                {
                    importanceText =
                        Channels.Wizards.EmailFormatWindow.Strings.MediumImportance;
                }

                    break;
                case Channels.EmailChannelParams.MessageImportanceLevels.Low:
                {
                    importanceText =
                        Channels.Wizards.EmailFormatWindow.Strings.LowImportance;
                }

                    break;
                default:
                {
                    importanceText =
                        Channels.Wizards.EmailFormatWindow.Strings.MediumImportance;
                }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "CreateEmailChannel::Using importance level text := '" +
                importanceText +
                "'");

            // select the level by the matching, translated text
            channelFormatWindow.Controls.ImportanceLevelComboBox.SelectByText(
                importanceText);

            #endregion Message Importance

            #region Message Encoding

            // click the encoding combo box drop-down button
            channelFormatWindow.Controls.EncodingComboBox.ClickDropDown();

            // set the encoding based on the var-map
            string encodingText = null;
            switch (emailChannel.Encoding)
            {
                case Channels.EmailChannelParams.EmailEncodings.UTF8:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF8;
                }

                    break;
                case Channels.EmailChannelParams.EmailEncodings.US_ASCII:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.US_ASCII;
                }

                    break;
                case Channels.EmailChannelParams.EmailEncodings.UTF16:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF16;
                }

                    break;
                case Channels.EmailChannelParams.EmailEncodings.UTF7:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF7;
                }

                    break;
                default:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF8;
                }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "CreateEmailChannel::Using encoding text value := '" +
                encodingText +
                "'");

            // select the encoding based on the text value
            channelFormatWindow.Controls.EncodingComboBox.SelectByText(
                encodingText);

            #endregion Message Encoding

            #endregion Format Step

            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);

            // save the channel
            wizardWindow.ClickFinish();

            // wait for the channel to finish saving
            Channels.CommonChannel.WaitForChannelSave(
                Channels.Wizards.SummaryWindow.Strings.EmailChannelWizardTitle);

            Core.Common.Utilities.LogMessage(
                "CreateEmailChannel::Closing wizard window...");

            // close the channel wizard window, cancel becomes close on successful save
            wizardWindow.ClickCancel();
        }

        /// <summary>
        /// Method to create an instant message notification channel or 
        /// end-point.
        /// </summary>
        /// <param name="instantMessageServerNetworkName">
        /// The network name of the instant message notification server
        /// </param>
        /// <param name="returnAddress">
        /// The reply to or return address used for instant messages.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if instantMessageServerNetworkName or  returnAddress are null or empty string.
        /// </exception>
        public static void CreateInstantMessageChannel(
            string instantMessageServerNetworkName,
            string returnAddress)
        {
            #region Validate Parameters

            // check for valid parameters
            if (String.IsNullOrEmpty(instantMessageServerNetworkName))
            {
                throw new System.ArgumentNullException(
                    "Mail server network name must not be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(returnAddress))
            {
                throw new System.ArgumentNullException(
                    "Reply to address must not be null or empty string!");
            }
            else
            {
                // check reply to address for proper email format
                if (false == returnAddress.Contains(Channels.CommonChannel.Constants.EmailAddressIdentifier) ||
                    false == returnAddress.StartsWith(Channels.CommonChannel.Constants.InstantMessageReturnAddressPrefix))
                {
                    throw new System.ArgumentException(
                        "Reply to address is not in the proper format!");
                }
            }

            #endregion Validate Parameters

            // create a new instant message channel parameters class
            Channels.InstantMessageChannelParams instantMessageChannel =
                new Channels.InstantMessageChannelParams(
                    instantMessageServerNetworkName,
                    returnAddress);

            // pass the new parameters class to the core method
            CreateInstantMessageChannel(instantMessageChannel);
        }

        /// <summary>
        /// Method to create an instant message notification channel or 
        /// end-point.
        /// </summary>
        /// <param name="instantMessageChannel">
        /// An instance of a Channels.InstantMessageChannelParams class.  
        /// This instance contains all the necessary information to create 
        /// the channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if instantMessageChannel is null.
        /// </exception>
        public static void CreateInstantMessageChannel(
            Channels.InstantMessageChannelParams instantMessageChannel)
        {
            // check for valid email channel
            if (null == instantMessageChannel)
            {
                throw new System.ArgumentNullException(
                    "Instant message channel parameters instance must not be null!");
            }

            // start the email channel wizard
            Channels.CommonChannel.StartWizard(
                Channels.CommonChannel.Constants.StartPoint.ViewContextMenu,
                Channels.CommonChannel.Strings.InstantMessageChannelContextMenu);

            // get a reference to the wizard base class
            Core.Console.Administration.ConsoleWizardBase wizardWindow =
                new ConsoleWizardBase(
                    CoreManager.MomConsole,
                    Channels.Wizards.NameAndDescriptionWindow.Strings.InstantMessageChannelWizardTitle);

            // set name and description
            Channels.CommonChannel.SetNameAndDescription(
                Channels.Wizards.NameAndDescriptionWindow.Strings.InstantMessageChannelWizardTitle,
                instantMessageChannel.ChannelName,
                instantMessageChannel.ChannelDescription);

            // click Next
            wizardWindow.ClickNext();

            #region Settings Step

            Channels.Wizards.InstantMessageSettingsWindow channelSettingsWindow =
                new Channels.Wizards.InstantMessageSettingsWindow(
                    CoreManager.MomConsole);

            // set the server name
            channelSettingsWindow.ServerText =
                instantMessageChannel.NotificationServer.FullyQualifiedName;

            // set the return address =
            channelSettingsWindow.ReturnAddressText =
                instantMessageChannel.ReturnAddress;

            #region Select Protocol Transport Option

            // get the protocol option text
            string protocolOptionText = null;
            switch (instantMessageChannel.NotificationServer.TransportOption)
            {
                case Channels.NotificationServer.TransportOptions.Tcp:
                {
                    protocolOptionText =
                        Channels.Wizards.InstantMessageSettingsWindow.Strings.ProtocolTcp;
                }

                    break;
                case Channels.NotificationServer.TransportOptions.Tls:
                {
                    protocolOptionText =
                        Channels.Wizards.InstantMessageSettingsWindow.Strings.ProtocolTls;
                }

                    break;
                default:
                {
                    protocolOptionText =
                        Channels.Wizards.InstantMessageSettingsWindow.Strings.ProtocolTcp;
                }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Using protocol option := '" +
                protocolOptionText +
                "'");

            // select the option in the combobox
            channelSettingsWindow.Controls.ProtocolOptionsComboBox.ClickDropDown();
            channelSettingsWindow.Controls.ProtocolOptionsComboBox.SelectByText(
                protocolOptionText);

            #endregion Select Protocol Transport Option

            #region Select Authentication Method

            // get the translated authentication method
            string authenticationMethodText = null;
            switch (instantMessageChannel.NotificationServer.AuthenticationMethod)
            {
                case Channels.NotificationServer.AuthenticationMethods.Ntlm:
                {
                    Core.Common.Utilities.LogMessage(
                        "CreateInstantMessageChannel::Using 'NTLM' authentication...'");
                    authenticationMethodText =
                        Channels.Wizards.InstantMessageSettingsWindow.Strings.AuthenticationNtlm;
                }

                    break;
                case Channels.NotificationServer.AuthenticationMethods.Kerberos:
                {
                    Core.Common.Utilities.LogMessage(
                        "CreateInstantMessageChannel::Using 'Kerberos' authentication...'");
                    authenticationMethodText =
                        Channels.Wizards.InstantMessageSettingsWindow.Strings.AuthenticationKerberos;
                }

                    break;
                default:
                {
                    Core.Common.Utilities.LogMessage(
                        "CreateInstantMessageChannel::Using 'NTLM' authentication...'");
                    authenticationMethodText =
                        Channels.Wizards.InstantMessageSettingsWindow.Strings.AuthenticationNtlm;
                }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "SetIMServerOptions::Selecting authentication method with text := '" +
                authenticationMethodText +
                "'");

            // set the authentication method
            channelSettingsWindow.Controls.AuthenticationMethodEditComboBox.ClickDropDown();
            channelSettingsWindow.Controls.AuthenticationMethodEditComboBox.SelectByText(
                authenticationMethodText);

            #endregion Select Authentication Method

            #region Set Port Number

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Setting port number := '" +
                instantMessageChannel.NotificationServer.PortNumber.ToString() +
                "'");

            // set the port number
            channelSettingsWindow.PortNumberText =
                instantMessageChannel.NotificationServer.PortNumber.ToString();

            #endregion Set Port Number

            #endregion Settings Step

            // click Next
            wizardWindow.ClickNext();

            #region Format Step

            Channels.Wizards.InstantMessageFormatWindow channelFormatWindow =
                new Channels.Wizards.InstantMessageFormatWindow(
                    CoreManager.MomConsole);

            #region Set Message Body Text

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Checking for default or custom message...");

            // select the message body text control
            channelFormatWindow.Controls.MessageBodyTextBox.Click();

            if (String.IsNullOrEmpty(instantMessageChannel.MessageText) ||
                instantMessageChannel.MessageText.Equals(Channels.CommonChannel.Constants.DefaultValue))
            {
                // do nothing, use the default text
                Core.Common.Utilities.LogMessage(
                    "CreateInstantMessageChannel::Use default message text := '" +
                    channelFormatWindow.MessageBodyText +
                    "'");
            }
            else
            {
                // clear the text box
                channelFormatWindow.Controls.MessageBodyTextBox.Text =
                    string.Empty;
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                Channels.CommonChannel.ProcessMessageText(
                    instantMessageChannel.MessageText,
                    channelFormatWindow.Controls.MessageBodyTextBox,
                    channelFormatWindow.Controls.MessageBodyAlertParametersButton);

                Core.Common.Utilities.LogMessage(
                    "CreateInstantMessageChannel::Message body text set to := '" +
                    channelFormatWindow.MessageBodyText +
                    "'");
            }

            #endregion Set Message Body Text

            #region Set Encoding

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Using encoding := '" +
                instantMessageChannel.Encoding +
                "'");

            // click the encoding combo box drop-down button
            channelFormatWindow.Controls.EncodingEditComboBox.ClickDropDown();

            // set the encoding based on the var-map
            string encodingText = null;
            switch (instantMessageChannel.Encoding)
            {
                case Channels.InstantMessageChannelParams.InstantMessageEncodings.UTF8:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF8;
                }

                    break;
                case Channels.InstantMessageChannelParams.InstantMessageEncodings.US_ASCII:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.US_ASCII;
                }

                    break;
                case Channels.InstantMessageChannelParams.InstantMessageEncodings.UTF16:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF16;
                }

                    break;
                case Channels.InstantMessageChannelParams.InstantMessageEncodings.UTF7:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF7;
                }

                    break;
                default:
                {
                    encodingText =
                        Channels.CommonChannel.Constants.Encoding.UTF8;
                }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Using encoding text value := '" +
                encodingText +
                "'");

            // select the encoding based on the text value
            channelFormatWindow.Controls.EncodingEditComboBox.SelectByText(
                encodingText);

            #endregion

            #endregion Format Step

            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);
            // save the channel
            wizardWindow.ClickFinish();

            // wait for the channel to finish saving
            Channels.CommonChannel.WaitForChannelSave(
                Channels.Wizards.SummaryWindow.Strings.InstantMessageChannelWizardTitle);

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Closing wizard window...");

            // close the channel wizard window, cancel becomes close on successful save
            wizardWindow.ClickCancel();
        }

        /// <summary>
        /// Method to create a short message service channel or end-point.
        /// </summary>
        public static void CreateShortMessageServiceChannel()
        {
            // create a new short message channel parameters class
            Channels.ShortMessageServiceChannelParams shortMessageServiceChannel =
                new Channels.ShortMessageServiceChannelParams();

            // pass the new parameters class to the core method
            CreateShortMessageServiceChannel(
                shortMessageServiceChannel);
        }

        /// <summary>
        /// Method to create a short message service channel or end-point.
        /// </summary>
        /// <param name="shortMessageServiceChannel">
        /// An instance of a Channels.ShortMessageServiceChannelParams class.  
        /// This instance contains all the necessary information to create 
        /// the channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if shortMessageServiceChannel is null.
        /// </exception>
        public static void CreateShortMessageServiceChannel(
            Channels.ShortMessageServiceChannelParams shortMessageServiceChannel)
        {
            // check for valid email channel
            if (null == shortMessageServiceChannel)
            {
                throw new System.ArgumentNullException(
                    "Instant message channel parameters instance must not be null!");
            }

            // start the email channel wizard
            Channels.CommonChannel.StartWizard(
                Channels.CommonChannel.Constants.StartPoint.ViewContextMenu,
                Channels.CommonChannel.Strings.SmsChannelContextMenu);

            // get a reference to the wizard base class
            Core.Console.Administration.ConsoleWizardBase wizardWindow =
                new ConsoleWizardBase(
                    CoreManager.MomConsole,
                    Channels.Wizards.NameAndDescriptionWindow.Strings.SmsChannelWizardTitle);

            // set name and description
            Channels.CommonChannel.SetNameAndDescription(
                Channels.Wizards.NameAndDescriptionWindow.Strings.SmsChannelWizardTitle,
                shortMessageServiceChannel.ChannelName,
                shortMessageServiceChannel.ChannelDescription);

            // click Next
            wizardWindow.ClickNext();

            #region Format Step

            Channels.Wizards.ShortMessageFormatWindow channelFormatWindow =
                new Channels.Wizards.ShortMessageFormatWindow(
                    CoreManager.MomConsole);

            #region Set Message Body Text

            Core.Common.Utilities.LogMessage(
                "CreateShortMessageServiceChannel::Checking for default or custom message...");

            // select the message body text control
            channelFormatWindow.Controls.MessageBodyTextBox.Click();

            if (String.IsNullOrEmpty(shortMessageServiceChannel.MessageText) ||
                shortMessageServiceChannel.MessageText.Equals(Channels.CommonChannel.Constants.DefaultValue))
            {
                // do nothing, use the default text
                Core.Common.Utilities.LogMessage(
                    "CreateShortMessageServiceChannel::Use default message text := '" +
                    channelFormatWindow.MessageBodyText +
                    "'");
            }
            else
            {
                // clear the text box
                channelFormatWindow.Controls.MessageBodyTextBox.Text =
                    string.Empty;
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                Channels.CommonChannel.ProcessMessageText(
                    shortMessageServiceChannel.MessageText,
                    channelFormatWindow.Controls.MessageBodyTextBox,
                    channelFormatWindow.Controls.MessageBodyAlertParametersButton);

                Core.Common.Utilities.LogMessage(
                    "CreateShortMessageServiceChannel::Message body text set to := '" +
                    channelFormatWindow.Controls.MessageBodyTextBox.Text +
                    "'");
            }

            #endregion Set Message Body Text

            #region Set Encoding

            Core.Common.Utilities.LogMessage(
                "CreateShortMessageServiceChannel::Using encoding := '" +
                shortMessageServiceChannel.Encoding +
                "'");

            // click the encoding combo box drop-down button
            channelFormatWindow.Controls.EncodingEditComboBox.ClickDropDown();

            // set the encoding based on the var-map
            string encodingText = null;
            switch (shortMessageServiceChannel.Encoding)
            {
                case Channels.ShortMessageServiceChannelParams.ShortMessageEncodings.Unicode:
                {
                    encodingText =
                        Channels.Wizards.ShortMessageFormatWindow.Strings.UnicodeEncoding;
                }

                    break;
                case Channels.ShortMessageServiceChannelParams.ShortMessageEncodings.US_ASCII:
                {
                    encodingText =
                        Channels.Wizards.ShortMessageFormatWindow.Strings.DefaultEncoding;
                }

                    break;
                default:
                {
                    encodingText =
                        Channels.Wizards.ShortMessageFormatWindow.Strings.DefaultEncoding;
                }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "SetMessageBody::Using encoding text value := '" +
                encodingText +
                "'");

            // select the encoding based on the text value
            channelFormatWindow.Controls.EncodingEditComboBox.SelectByText(
                encodingText);
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);

            #endregion

            #endregion Format Step

            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);
            // save the channel
            wizardWindow.ClickFinish();

            // wait for the channel to finish saving
            Channels.CommonChannel.WaitForChannelSave(
                Channels.Wizards.SummaryWindow.Strings.SmsChannelWizardTitle);

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Closing wizard window...");

            // close the channel wizard window, cancel becomes close on successful save
            wizardWindow.ClickCancel();
        }

        /// <summary>
        /// Method to create a command channel or end-point.
        /// </summary>
        /// <param name="fullPathToFile">
        /// The full path to the command or executable.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if fullPathToFile is null or empty string.
        /// </exception>
        public static void CreateCommandChannel(
            string fullPathToFile)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(fullPathToFile))
            {
                throw new System.ArgumentNullException(
                    "Full path to file must not be null or emtpy string!");
            }

            // create a new command channel parameters class
            Channels.CommandChannelParams commandChannel =
                new Channels.CommandChannelParams(
                    fullPathToFile);

            // pass the new parameters class to the core method
            CreateCommandChannel(commandChannel);
        }

        /// <summary>
        /// Method to create a command channel or end-point.
        /// </summary>
        /// <param name="commandChannel">
        /// An instance of a Channels.CommandChannelParams class.  
        /// This instance contains all the necessary information to create 
        /// the channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if commandChannel is null.
        /// </exception>
        public static void CreateCommandChannel(
            Channels.CommandChannelParams commandChannel)
        {
            // check for valid email channel
            if (null == commandChannel)
            {
                throw new System.ArgumentNullException(
                    "Instant message channel parameters instance must not be null!");
            }

            // start the email channel wizard
            Channels.CommonChannel.StartWizard(
                Channels.CommonChannel.Constants.StartPoint.ViewContextMenu,
                Channels.CommonChannel.Strings.CommandChannelContextMenu);

            // get a reference to the wizard base class
            Core.Console.Administration.ConsoleWizardBase wizardWindow =
                new ConsoleWizardBase(
                    CoreManager.MomConsole,
                    Channels.Wizards.NameAndDescriptionWindow.Strings.CommandChannelWizardTitle);

            // set name and description
            Channels.CommonChannel.SetNameAndDescription(
                Channels.Wizards.NameAndDescriptionWindow.Strings.CommandChannelWizardTitle,
                commandChannel.ChannelName,
                commandChannel.ChannelDescription);

            // click Next
            wizardWindow.ClickNext();

            #region Settings Step

            Channels.Wizards.CommandSettingsWindow channelSettingsWindow =
                new Channels.Wizards.CommandSettingsWindow(
                    CoreManager.MomConsole);

            channelSettingsWindow.FullPathToFileText =
                commandChannel.FullPathToFile;

            #region Set Command Parameters Text

            // select the message body text control
            channelSettingsWindow.Controls.CommandLineParametersTextBox.Click();

            // clear the text box
            channelSettingsWindow.Controls.CommandLineParametersTextBox.Text =
                string.Empty;
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);

            Channels.CommonChannel.ProcessMessageText(
                commandChannel.Parameters,
                channelSettingsWindow.Controls.CommandLineParametersTextBox,
                channelSettingsWindow.Controls.CommandAlertParametersButton);

            Core.Common.Utilities.LogMessage(
                "SetCommandParameters::Parameters text set to := '" +
                channelSettingsWindow.Controls.CommandLineParametersTextBox.Text +
                "'");

            #endregion Set Command Parameters Text

            channelSettingsWindow.InitialDirectoryText =
                commandChannel.InitialDirectory;

            #endregion Settings Step

            // save the channel
            wizardWindow.ClickFinish();

            // wait for the channel to finish saving
            Channels.CommonChannel.WaitForChannelSave(
                Channels.Wizards.SummaryWindow.Strings.CommandChannelWizardTitle);

            Core.Common.Utilities.LogMessage(
                "CreateInstantMessageChannel::Closing wizard window...");

            // close the channel wizard window, cancel becomes close on successful save
            wizardWindow.ClickCancel();
        }

        #endregion Channels

        #region Subscribers

        /// <summary>
        /// Method to specify a notification subscriber/recipient details.
        /// </summary>
        /// <param name="subscriberId">
        /// The Active Directory or network ID of the subscriber, e.g. 
        /// DOMAIN\username or username@dns.domain.tld
        /// </param>
        /// <param name="commandChannelName">
        /// The name of the command channel used for this subscriber's
        /// delivery address.  This parameter can be an empty string for all
        /// other channel types.  It only needs to be defined for the command
        /// channel.
        /// </param>
        /// <param name="channelType">
        /// The channel type used by the subscriber to receive notifications.  
        /// The types are defined in the class Constants.ChannelType.
        /// </param>
        /// <param name="deliveryAddress">
        /// The delivery address to which notifications are sent.  This can
        /// vary with the channel type, i.e. it can be an email address, or a
        /// phone number or and instant message ID.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if any of the parameters are 
        /// null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if the channelType parameter does
        /// not match one of the known types defined in Constants.ChannelType.
        /// </exception>
        public static void SpecifySubscriber(
            string subscriberId,
            string commandChannelName,
            string channelType,
            string deliveryAddress)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(subscriberId))
            {
                throw new System.ArgumentNullException(
                    "Subscriber ID cannot be null or empty string!");
            }

            if (null == commandChannelName)
            {
                throw new System.ArgumentNullException(
                    "Channel type cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(channelType))
            {
                throw new System.ArgumentNullException(
                    "Channel type cannot be null or empty string!");
            }
            else
            {
                // check for valid channel type
                if (channelType.Equals(Subscribers.CommonSubscriber.Constants.ChannelType.Email) ||
                    channelType.Equals(Subscribers.CommonSubscriber.Constants.ChannelType.InstantMessage) ||
                    channelType.Equals(Subscribers.CommonSubscriber.Constants.ChannelType.ShortMessage) ||
                    channelType.Equals(Subscribers.CommonSubscriber.Constants.ChannelType.Command))
                {
                    Core.Common.Utilities.LogMessage(
                        "Notifications.Utilities.SpecifySubscriber::" +
                        "Using channel type := '" +
                        channelType +
                        "'");
                }
                else
                {
                    throw new System.ArgumentException(
                        "Unknown or unrecognized channel type!  " +
                        "Argument value := '" +
                        channelType +
                        "' is not valid!");
                }
            }

            if (String.IsNullOrEmpty(deliveryAddress))
            {
                throw new System.ArgumentNullException(
                    "Delivery address cannot be null or empty string!");
            }

            // create the subscriber parameters class
            Subscribers.SubscriberParams subscriber =
                new Subscribers.SubscriberParams(
                    subscriberId,
                    deliveryAddress,
                    commandChannelName,
                    channelType);

            // call the appropriate core method
            Utilities.SpecifySubscriber(
                subscriber);
        }

        /// <summary>
        /// Method to specify a notification subscriber/recipient details.
        /// </summary>
        /// <param name="subscriber">
        /// The subscriber parameters class containing the subscriber details.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the subscriber parameter is
        /// null.
        /// </exception>
        public static void SpecifySubscriber(
            Subscribers.SubscriberParams subscriber)
        {
            if (null == subscriber)
            {
                throw new System.ArgumentNullException(
                    "Subscriber parameter must not be null!");
            }

            // check for existing subscriber
            if (false == Subscribers.CommonSubscriber.SubscriberExists(subscriber.SubscriberId))
            {
                Core.Common.Utilities.LogMessage(
                    "SpecifySubscriber::Starting subscriber wizard...");

                // start the subscriber wizard
                Subscribers.CommonSubscriber.StartWizard(
                    Subscribers.CommonSubscriber.Constants.StartPoint.ViewContextMenu,
                    Subscribers.CommonSubscriber.Strings.NewSubscriberContextMenu);

                #region Set Name

                // find subscriber name window
                Subscribers.Wizards.NameAndDescriptionWindow subscriberNameWindow =
                    new Subscribers.Wizards.NameAndDescriptionWindow(
                        CoreManager.MomConsole);

                Core.Common.Utilities.LogMessage(
                    "SpecifySubscriber::Setting subscriber ID := '" +
                    subscriber.SubscriberId +
                    "'");

                // set the name and click "Next"
                subscriberNameWindow.NameText =
                    subscriber.SubscriberId;

                subscriberNameWindow.ClickNext();

                // drop the reference
                subscriberNameWindow = null;

                #endregion

                #region Set Delivery Schedule

                // find the schedule window
                Subscribers.Wizards.NotificationCalendarWindow subscriberScheduleWindow =
                    new Subscribers.Wizards.NotificationCalendarWindow(
                        CoreManager.MomConsole);

                Core.Common.Utilities.LogMessage(
                    "SpecifySubscriber::Setting delivery schedule, Always notify := '" +
                    subscriber.AlwaysNotify.ToString() +
                    "'");

                // set the delivery schedule
                if (subscriber.AlwaysNotify == true)
                {
                    subscriberScheduleWindow.ScheduleOption =
                        Subscribers.Wizards.ScheduleOption.AlwaysSend;
                }
                else
                {
                    subscriberScheduleWindow.ScheduleOption =
                        Subscribers.Wizards.ScheduleOption.SendDuringSpecifiedTimes;

                    Core.Common.Utilities.LogMessage(
                        "SpecifySubscriber::Process schedule items...");

                    // TODO:  Process schedule items
                }

                // click "Next"
                subscriberScheduleWindow.ClickNext();

                // drop the reference
                subscriberScheduleWindow = null;

                #endregion Set Delivery Schedule

                #region Set Subscriber Addresses

                // find the subscriber addresses step
                Subscribers.Wizards.SubscriberAddressesWindow subscriberAddressesWindow =
                    new Subscribers.Wizards.SubscriberAddressesWindow(
                        CoreManager.MomConsole);

                Core.Common.Utilities.LogMessage(
                    "SpecifySubscriber::Setting subscriber addresses...");

                // add the subscriber address
                Subscribers.CommonSubscriber.SetSubscriberAddress(
                    subscriber.Addresses);

                #endregion Set Subscriber Addresses

                #region Save Subscriber

                // save the subscriber
                Subscribers.CommonSubscriber.WaitForSubscriberSave();

                // close the subscriber wizard window, cancel becomes close on successful save
                subscriberAddressesWindow.ClickCancel();

                // drop the reference
                subscriberAddressesWindow = null;

                #endregion
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "SpecifySubscriber::Specified subscriber already exists.");
            }
        }

        #endregion Subscribers

        #region Subscriptions

        /// <summary>
        /// Method to create a notification subscription
        /// </summary>
        /// <param name="subscription">
        /// The subscriber parameters class containing the subscriber details.
        /// </param>
        /// <param name="editExisting">
        /// Flag indicating if this is occuring on a new subscription or an
        /// existing one.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the subscription parameter
        /// is null.
        /// </exception>
        public static void CreateSubscription(
            Subscriptions.SubscriptionParameters subscription,
            bool editExisting)
        {
            CreateSubscription(subscription, editExisting, null);
        }

        /// <summary>
        /// Method to create a notification subscription
        /// </summary>
        /// <param name="subscription">
        /// The subscriber parameters class containing the subscriber details.
        /// </param>
        /// <param name="editExisting">
        /// Flag indicating if this is occuring on a new subscription or an
        /// existing one.
        /// </param>
        /// <param name="alertPath">
        /// The item in the alert view, find it and call context menu to start wizard
        /// If no such item is specified, we can use RMS server, else use whatever the user supplied
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the subscription parameter
        /// is null.
        /// </exception>
        public static void CreateSubscription(
            Subscriptions.SubscriptionParameters subscription,
            bool editExisting,
            string alertPath)
        {
            if (null == subscription)
            {
                throw new System.ArgumentNullException(
                    "Subscription parameter must not be null!");
            }

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Starting subscription wizard...");

            //Bug#201967: Use action pane link instead of executing context to start the wizard.
            subscription.StartPoint = Notifications.Subscriptions.CommonSubscription.Constants.StartPoint.ActionsPaneLink;
            Notifications.Subscriptions.CommonSubscription.StartWizard(
                subscription.StartPoint,
                Notifications.Subscriptions.CommonSubscription.Strings.NewSubscriptionContextMenu,
                subscription.AlertSource,
                subscription.AlertSourceName,
                alertPath);

            #region Set Name and Description

            // get a reference to the wizard window
            Subscriptions.Wizards.NameAndDescriptionWindow subscriptionNameWindow =
                new Subscriptions.Wizards.NameAndDescriptionWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Set name and description...");

            // set the name and description
            Subscriptions.CommonSubscription.SetSubscriptionName(
                subscription.Name,
                subscription.Description);

            // preserve the name and description
            subscription.Name =
                subscriptionNameWindow.SubscriptionNameText;
            subscription.Description =
                subscriptionNameWindow.DescriptionText;

            subscriptionNameWindow.ClickNext();

            #endregion

            #region Set Alert Criteria

            // get a window reference
            Subscriptions.Wizards.SubscriptionCriteriaWindow criteriaWindow =
                new Subscriptions.Wizards.SubscriptionCriteriaWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Set alert matching criteria...");

            // Set alert critiera
            if (null != subscription.AlertCriteria)
            {
                Notifications.Subscriptions.CommonSubscription.SetCriteria(
                    subscription.AlertCriteria, false);
            }

            criteriaWindow.ClickNext();

            #endregion

            #region Set Subscribers

            // get a window reference
            Subscriptions.Wizards.SubscribersWindow subscribersWindow =
                new Subscriptions.Wizards.SubscribersWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Add subscribers...");

            // set subscribers
            Subscriptions.CommonSubscription.AddSubscribers(
                subscription.Subscribers);

            subscribersWindow.ClickNext();

            #endregion

            #region Set Channels

            // get a reference to the window
            Subscriptions.Wizards.ChannelsWindow channelsWindow =
                new Subscriptions.Wizards.ChannelsWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Adding channels...");

            Subscriptions.CommonSubscription.AddChannels(
                subscription.ChannelNames);

            channelsWindow.ClickNext();

            #endregion

            #region View Summary and Enable Subscription

            // get a window reference
            Subscriptions.Wizards.SubscriptionSummaryWindow subscriptionSummaryWindow =
                new Subscriptions.Wizards.SubscriptionSummaryWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Viewing summary and enabling subscription...");

            #region Set Subscription Enabled

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Setting subscription enabled := '" +
                subscription.Enabled.ToString() +
                "'");

            // Check the enable control
            if (subscription.Enabled == true)
            {
                // is the check box checked?
                if (subscriptionSummaryWindow.EnableThisNotificationSubscription == true)
                {
                    // log default value
                    Core.Common.Utilities.LogMessage(
                        "CreateSubscription::Using default value := '" +
                        subscriptionSummaryWindow.EnableThisNotificationSubscription.ToString() +
                        "'");
                }
                else
                {
                    Core.Common.Utilities.LogMessage(
                        "CreateSubscription::Setting checkbox value to checked.");

                    // check the check box
                    subscriptionSummaryWindow.Controls.EnableThisNotificationSubscriptionCheckBox.ButtonState =
                        Maui.Core.ButtonState.Checked;
                }
            }
            else
            {
                // is the check box checked?
                if (subscriptionSummaryWindow.EnableThisNotificationSubscription == true)
                {
                    Core.Common.Utilities.LogMessage(
                        "CreateSubscription::Setting checkbox value to unchecked.");

                    // check the check box
                    subscriptionSummaryWindow.Controls.EnableThisNotificationSubscriptionCheckBox.ButtonState =
                        Maui.Core.ButtonState.UnChecked;
                }
                else
                {
                    // log value
                    Core.Common.Utilities.LogMessage(
                        "CreateSubscription::Using default value := '" +
                        subscriptionSummaryWindow.EnableThisNotificationSubscription.ToString() +
                        "'");
                }
            }

            #endregion Set Subscription Enabled

            subscriptionSummaryWindow.ClickFinish();

            #endregion

            #region Save Subscription

            // get a window reference
            Subscriptions.Wizards.SummaryWindow saveSubscriptionWindow =
                new Subscriptions.Wizards.SummaryWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "CreateSubscription::Saving the new subscription...");

            // wait for subscription save
            Subscriptions.CommonSubscription.WaitForSubscriptionSave(
                editExisting);

            // cancel button becomes 'Close' button on successful save
            saveSubscriptionWindow.ClickCancel();

            #endregion
        }

        /// <summary>
        /// Method to verify the Html related buttons.  
        /// </summary>
        private static void VerifyHTMLBodyButtons(EmailFormatWindow channelFormatWindow)
        {
            Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: Checking copy and paste buttons");

            Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: Click copy button");
            channelFormatWindow.Controls.CopyButton.Click();

            Core.Common.Utilities.LogMessage(
                "VerifyHTMLBodyButtons :: Check clipboard value with message box to check if copy worked");
            if (!channelFormatWindow.Controls.MessageBodyTextBox.Text.Equals(Clipboard.Text))
            {
                Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: MsgText =  " +
                                                 channelFormatWindow.Controls.MessageBodyTextBox.Text);
                Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: ClipText =  " + Clipboard.Text);
                throw new VarAbort("Copy button Failed");
            }
            else
            {
                Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: CopyButton Works");
            }

            Core.Common.Utilities.LogMessage(
                "VerifyHTMLBodyButtons :: Click paste button after setting clipboard to \"someRandomText\"");

            string copiedHtml = Clipboard.Text;

            Clipboard.Text = "SomeRandomText";
            channelFormatWindow.Controls.PasteButton.Click();

            Core.Common.Utilities.LogMessage(
                "VerifyHTMLBodyButtons :: Check clipboard value with message box to check if paste worked");
            if (!channelFormatWindow.Controls.MessageBodyTextBox.Text.Equals(Clipboard.Text))
            {
                Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: MsgText =  " +
                                                 channelFormatWindow.Controls.MessageBodyTextBox.Text);
                Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: ClipText =  " + Clipboard.Text);
                throw new VarAbort("paste button Failed");
            }
            else
            {
                Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: Paste button Works");
            }

            //Set the data back to old value;
            Clipboard.Text = copiedHtml;
            channelFormatWindow.Controls.PasteButton.Click();

            Core.Common.Utilities.LogMessage("VerifyHTMLBodyButtons :: MsgText after reset =  " +
                                             channelFormatWindow.Controls.MessageBodyTextBox.Text);
        }

        /// <summary>
        /// Method to verify copy paste buttons when clipboard is empty.  
        /// </summary>
        private static void VerifyCopyPasteWhenClipboardEmpty(EmailFormatWindow channelFormatWindow)
        {
            Core.Common.Utilities.LogMessage("VerifyCopyPasteWhenClipboardEmpty :: Copying the msg text temporarily.");

            //Store the values to reset at end.
            string msgboxText = channelFormatWindow.Controls.MessageBodyTextBox.Text;
            bool isHtmlCheckboxChecked = channelFormatWindow.Controls.IsHtmlBody.Checked;

            //Enable Html body.
            channelFormatWindow.Controls.IsHtmlBody.Checked = true;
            //Set the clipboard to empty.
            Clipboard.Text = string.Empty;

            channelFormatWindow.Controls.PasteButton.Click();

            //message box should be empty.
            if (!string.IsNullOrEmpty(channelFormatWindow.MessageBodyText))
            {
                Core.Common.Utilities.LogMessage("VerifyCopyPasteWhenClipboardEmpty :: MsgText =  " +
                                                 channelFormatWindow.Controls.MessageBodyTextBox.Text);
                Core.Common.Utilities.LogMessage("VerifyCopyPasteWhenClipboardEmpty :: ClipText =  " + Clipboard.Text);
                throw new VarFail("paste button failed when clipboard is empty");
            }

            //Next/Finish button should be disabled.
            if (channelFormatWindow.Controls.NextButton.IsEnabled != false)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyCopyPasteWhenClipboardEmpty :: Next button should not " +
                    "be enabled when message text is empty.");
                throw new VarFail("Next Button is enabled when message textbox is empty");
            }

            if (channelFormatWindow.Controls.FinishButton.IsEnabled != false)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyCopyPasteWhenClipboardEmpty :: Finish button should not " +
                    "be enabled when message text is empty.");
                throw new VarFail("Finish Button is enabled when message textbox is empty");
            }

            //reset to stored values.
            Clipboard.Text = msgboxText;
            channelFormatWindow.Controls.PasteButton.Click();
            channelFormatWindow.Controls.IsHtmlBody.Checked = isHtmlCheckboxChecked;

        }

        /// <summary>
        /// Method to verify the UI controls related to Html checkbox defaults.
        /// </summary>
        private static void VerifyHtmlBodyCheckBoxDefaults(EmailFormatWindow channelFormatWindow)
        {
            Core.Common.Utilities.LogMessage("VerifyHtmlBodyCheckBoxDefaults ::" +
                                            "Checking if Html checkbox is enabled.");
            // verify Html check box
            if (false == channelFormatWindow.Controls.IsHtmlBody.Checked)
            {
                Core.Common.Utilities.TakeScreenshot("Exception_HtmlBodyNotCheckedByDefault");
                throw new VarFail("IsHtmlBody is not checked by default");
            }

            Core.Common.Utilities.TakeScreenshot("HtmlCheckboxShouldBeEnabled");
            //Verify the buttons when Html checkbox checked...
            //Copy, Paste and Preview buttons should be enabled.
            if (!channelFormatWindow.Controls.CopyButton.IsVisible)
            {
                throw new VarFail("Copy Button is not visible when Html checkbox is enabled");
            }

            if (!channelFormatWindow.Controls.PasteButton.IsVisible)
            {
                throw new VarFail("Paste Button is not visible when Html checkbox is enabled");
            }

            if (!channelFormatWindow.Controls.PreviewButton.IsVisible)
            {
                throw new VarFail("Preview Button is not visible when Html checkbox is enabled");
            }

            if (channelFormatWindow.Controls.MenuButton.IsEnabled)
            {
                throw new VarFail("Menu button should not be enabled when Html checkbox is enabled");
            }

            //Verify defaults when Html unchecked 
            Core.Common.Utilities.LogMessage("VerifyHtmlBodyCheckBoxDefaults ::" +
                                             "Html checkbox is disabled.");

            channelFormatWindow.Controls.IsHtmlBody.Checked = false;
            // Wait for the checkbox to become ready
            UISynchronization.WaitForUIObjectReady(channelFormatWindow.Controls.IsHtmlBody, 
                Core.Common.Constants.OneMinute);

            Core.Common.Utilities.TakeScreenshot("HtmlCheckboxShouldBeDisabled");

            //Copy, Paste and Preview buttons should be Invisible.
            if (channelFormatWindow.Controls.CopyButton.IsVisible)
            {
                throw new VarFail("Copy Button is not invisble when Html checkbox is disabled");
            }

            if (channelFormatWindow.Controls.PasteButton.IsVisible)
            {
                throw new VarFail("Paste Button is not invisible when Html checkbox is disabled");
            }

            if (channelFormatWindow.Controls.PreviewButton.IsVisible)
            {
                throw new VarFail("Preview button is not invisible when Html checkbox is disabled");
            }

            if (!channelFormatWindow.Controls.MenuButton.IsEnabled)
            {
                throw new VarFail("Menu button should not be disabled when Html checkbox is disabled");
            }

            Core.Common.Utilities.LogMessage("VerifyHtmlBodyCheckBoxDefaults :: Html checkbox is re-enabled.");

            channelFormatWindow.Controls.IsHtmlBody.Checked = true;
            Core.Common.Utilities.TakeScreenshot("HtmlCheckboxShouldBeEnabledAgain");

            Core.Common.Utilities.LogMessage("VerifyHtmlBodyCheckBoxDefaults :: Clicking Preview Button.");
            channelFormatWindow.Controls.PreviewButton.Click();

            //Get control of the previewhtml window.
            Window previewWindow = null;
            try
            {
                previewWindow = new Window("HTML email preview",
                       StringMatchSyntax.ExactMatch,
                       WindowClassNames.WinForms10Window8,
                       StringMatchSyntax.ExactMatch,
                       CoreManager.MomConsole.MainWindow, Core.Common.Constants.OneMinute);
            }
            catch (Dialog.Exceptions.WindowNotFoundException)
            {
                try
                {
                    previewWindow =
                                new Window(
                                    "HTML email preview",
                                    StringMatchSyntax.WildCard);

                    // Wait for the window to become ready
                    UISynchronization.WaitForUIObjectReady(
                        previewWindow,
                        6000);
                }
                catch (Dialog.Exceptions.WindowNotFoundException)
                {
                    throw new VarFail("Preview Form is not loaded.");
                }
            }

            Core.Common.Utilities.TakeScreenshot("PreviewWindowShouldBeLoaded");

            Core.Common.Utilities.LogMessage("VerifyHtmlBodyCheckBoxDefaults :: Closing the preview html window.");
            previewWindow.ClickTitleBarClose();

            VerifyHTMLBodyButtons(channelFormatWindow);

            VerifyCopyPasteWhenClipboardEmpty(channelFormatWindow);
        }

        /// <summary>
        /// Method to open channel wizard.  
        /// </summary>
        private static void OpenChannelWizardWhenInChannelsViewPane()
        {
            // start the email channel wizard
            CoreManager.MomConsole.ViewPane.Grid.Click();

            string menuPath = CommonChannel.Strings.CreateNewChannelContextMenu +
                              Core.Common.Constants.PathDelimiter +
                              CommonChannel.Strings.EmailChannelContextMenu;

            Core.Common.Utilities.LogMessage("OpenChannelWizardWhenInChannelsViewPane:: menu path:" + menuPath);
            CoreManager.MomConsole.ExecuteContextMenu(menuPath, true);
        }


        #endregion Subscriptions
    }
}
