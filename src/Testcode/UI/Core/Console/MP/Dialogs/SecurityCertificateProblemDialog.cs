// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SecurityCertificateProblemDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 4/13/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISecurityCertificateProblemDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISecurityCertificateProblemDialogControls, for SecurityCertificateProblemDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 4/13/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISecurityCertificateProblemDialogControls
    {
        /// <summary>
        /// Read-only property to access SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh
        /// </summary>
        TextBox SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewSecurityCertificateStaticControl
        /// </summary>
        StaticControl ViewSecurityCertificateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl
        /// </summary>
        StaticControl ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl
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
        
        /// <summary>
        /// Read-only property to access ContinueNotRecommendedButton
        /// </summary>
        Button ContinueNotRecommendedButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 4/13/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SecurityCertificateProblemDialog : Dialog, ISecurityCertificateProblemDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh of type TextBox
        /// </summary>
        private TextBox cachedSomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh;
        
        /// <summary>
        /// Cache to hold a reference to ViewSecurityCertificateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewSecurityCertificateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to ContinueNotRecommendedButton of type Button
        /// </summary>
        private Button cachedContinueNotRecommendedButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SecurityCertificateProblemDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SecurityCertificateProblemDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISecurityCertificateProblemDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISecurityCertificateProblemDialogControls Controls
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
        ///  Routine to set/get the text in control SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchThText
        {
            get
            {
                return this.Controls.SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh.Text;
            }
            
            set
            {
                this.Controls.SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISecurityCertificateProblemDialogControls.SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh
        {
            get
            {
                if ((this.cachedSomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh == null))
                {
                    this.cachedSomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh = new TextBox(this, SecurityCertificateProblemDialog.ControlIDs.SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh);
                }
                return this.cachedSomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewSecurityCertificateStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISecurityCertificateProblemDialogControls.ViewSecurityCertificateStaticControl
        {
            get
            {
                if ((this.cachedViewSecurityCertificateStaticControl == null))
                {
                    this.cachedViewSecurityCertificateStaticControl = new StaticControl(this, SecurityCertificateProblemDialog.ControlIDs.ViewSecurityCertificateStaticControl);
                }
                return this.cachedViewSecurityCertificateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISecurityCertificateProblemDialogControls.ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl
        {
            get
            {
                if ((this.cachedThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl == null))
                {
                    this.cachedThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl = new StaticControl(this, SecurityCertificateProblemDialog.ControlIDs.ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl);
                }
                return this.cachedThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISecurityCertificateProblemDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, SecurityCertificateProblemDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContinueNotRecommendedButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISecurityCertificateProblemDialogControls.ContinueNotRecommendedButton
        {
            get
            {
                if ((this.cachedContinueNotRecommendedButton == null))
                {
                    this.cachedContinueNotRecommendedButton = new Button(this, SecurityCertificateProblemDialog.ControlIDs.ContinueNotRecommendedButton);
                }
                return this.cachedContinueNotRecommendedButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ContinueNotRecommended
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickContinueNotRecommended()
        {
            this.Controls.ContinueNotRecommendedButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Security Certificate Problem;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;CertificateFailureTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewSecurityCertificate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewSecurityCertificate = ";&View security certificate;ManagedString;Microsoft.EnterpriseManagement.UI.Admin" +
                "istration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDo" +
                "wnloadAndInstall.Dialogs.CatalogConnectionDialog;certificateLink.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThereIsAProblemWithTheSecurityCertificateForThisCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThereIsAProblemWithTheSecurityCertificateForThisCatalog = @";There is a problem with the security certificate for this catalog.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;CertificateFailureHeader";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Cl&ose;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPD" +
                "ownloadInstallResources;Close";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ContinueNotRecommended
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContinueNotRecommended = ";Co&ntinue (not recommended);ManagedString;Microsoft.EnterpriseManagement.UI.Admi" +
                "nistration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPD" +
                "ownloadAndInstall.Dialogs.CatalogConnectionDialog;confirmationButton.Text";
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
            /// Caches the translated resource string for:  ViewSecurityCertificate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewSecurityCertificate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThereIsAProblemWithTheSecurityCertificateForThisCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThereIsAProblemWithTheSecurityCertificateForThisCatalog;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContinueNotRecommended
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContinueNotRecommended;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 4/13/2009 Created
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
            /// Exposes access to the ViewSecurityCertificate translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 4/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewSecurityCertificate
            {
                get
                {
                    if ((cachedViewSecurityCertificate == null))
                    {
                        cachedViewSecurityCertificate = CoreManager.MomConsole.GetIntlStr(ResourceViewSecurityCertificate);
                    }
                    return cachedViewSecurityCertificate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThereIsAProblemWithTheSecurityCertificateForThisCatalog translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 4/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThereIsAProblemWithTheSecurityCertificateForThisCatalog
            {
                get
                {
                    if ((cachedThereIsAProblemWithTheSecurityCertificateForThisCatalog == null))
                    {
                        cachedThereIsAProblemWithTheSecurityCertificateForThisCatalog = CoreManager.MomConsole.GetIntlStr(ResourceThereIsAProblemWithTheSecurityCertificateForThisCatalog);
                    }
                    return cachedThereIsAProblemWithTheSecurityCertificateForThisCatalog;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 4/13/2009 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContinueNotRecommended translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 4/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContinueNotRecommended
            {
                get
                {
                    if ((cachedContinueNotRecommended == null))
                    {
                        cachedContinueNotRecommended = CoreManager.MomConsole.GetIntlStr(ResourceContinueNotRecommended);
                    }
                    return cachedContinueNotRecommended;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 4/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh
            /// </summary>
            public const string SomeOfTheManagementPacksYouSelectMayHaveDependenciesThatCannotBeLocatedLocallyWouldYouLikeToSearchTh = "detailsRichTextBox";
            
            /// <summary>
            /// Control ID for ViewSecurityCertificateStaticControl
            /// </summary>
            public const string ViewSecurityCertificateStaticControl = "certificateLink";
            
            /// <summary>
            /// Control ID for ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl
            /// </summary>
            public const string ThereIsAProblemWithTheSecurityCertificateForThisCatalogStaticControl = "statusLabel";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
            
            /// <summary>
            /// Control ID for ContinueNotRecommendedButton
            /// </summary>
            public const string ContinueNotRecommendedButton = "confirmationButton";
        }
        #endregion
    }
}
