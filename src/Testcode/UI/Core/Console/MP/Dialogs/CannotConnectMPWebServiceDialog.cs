// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CannotConnectMPWebServiceDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   OM10 Console
// </project>
// <summary>
//   CannotConnectMPWebServiceDialog
// </summary>
// <history>
//   [v-eachu] 1/21/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ICannotConnectMPWebServiceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICannotConnectMPWebServiceDialogControls, for CannotConnectMPWebServiceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-eachu] 1/21/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICannotConnectMPWebServiceDialogControls
    {
        /// <summary>
        /// Read-only property to access ViewSecurityCertificateTextBox
        /// </summary>
        TextBox ViewSecurityCertificateTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// CannotConnectMPWebServiceDialog
    /// </summary>
    /// <history>
    ///   [v-eachu] 1/21/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class CannotConnectMPWebServiceDialog : Dialog, ICannotConnectMPWebServiceDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ViewSecurityCertificateTextBox of type TextBox
        /// </summary>
        private TextBox cachedViewSecurityCertificateTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor of CannotConnectMPWebService Dialog
        /// </summary>
        /// <param name='app'>
        /// Owner of CannotConnectMPWebServiceDialog of type ConsoleApp
        /// </param>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CannotConnectMPWebServiceDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
             
        }
        #endregion
        
        #region ICannotConnectMPWebServiceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICannotConnectMPWebServiceDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ViewSecurityCertificate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ViewSecurityCertificateText
        {
            get
            {
                return this.Controls.ViewSecurityCertificateTextBox.Text;
            }
            
            set
            {
                this.Controls.ViewSecurityCertificateTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewSecurityCertificateTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICannotConnectMPWebServiceDialogControls.ViewSecurityCertificateTextBox
        {
            get
            {
                if ((this.cachedViewSecurityCertificateTextBox == null))
                {
                    this.cachedViewSecurityCertificateTextBox = new TextBox(this, CannotConnectMPWebServiceDialog.ControlIDs.ViewSecurityCertificateTextBox);
                }
                
                return this.cachedViewSecurityCertificateTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICannotConnectMPWebServiceDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, CannotConnectMPWebServiceDialog.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ViewSecurityCertificateTextBox
            /// </summary>
            public const string ViewSecurityCertificateTextBox = "detailsRichTextBox";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings
        /// </summary>
        /// <history>
        ///   [v-eachu] 1/21/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Cannot Connect Dialog Title
            /// </summary>
            public const string ResourceDialogTitle = ";Cannot Connect;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dl" +
                "l;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndIns" +
                "tall.MPDownloadInstallResources;CatalogServiceNotAvailableTitle";

            /// <summary>
            /// Resource string for Close
            /// </summary>
            public const string ResourceClose = ";Cl&ose;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPD" +
                "ownloadInstallResources;Close";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 1/21/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 1/21/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }
                    return cachedClose;
                }
            }

            #endregion
        }
        #endregion
    }
}
