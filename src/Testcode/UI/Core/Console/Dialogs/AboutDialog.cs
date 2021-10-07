// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AboutDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 07OCT05 Created
//  [a-joelj] 07MAY10 Added QueryIds class to correctly get handle to About window and OK button
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - IAboutDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAboutDialogControls, for AboutDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 07OCT05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAboutDialogControls
    {
        /// <summary>
        /// Read-only property to access TheProductIsLicensedToStaticControl
        /// </summary>
        StaticControl TheProductIsLicensedToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access VersionStaticControl
        /// </summary>
        StaticControl VersionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProductIDStaticControl
        /// </summary>
        StaticControl ProductIDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MicrosoftStaticControl
        /// </summary>
        StaticControl MicrosoftStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MicrosoftUserStaticControl
        /// </summary>
        StaticControl MicrosoftUserStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ActivateButton
        /// </summary>
        Button ActivateButton
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
    /// 	[mbickle] 07OCT05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AboutDialog : Dialog, IAboutDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TheProductIsLicensedToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheProductIsLicensedToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to VersionStaticControlof type StaticControl
        /// </summary>
        private StaticControl cachedVersionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProductIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProductIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MicrosoftStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMicrosoftStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MicrosoftUserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMicrosoftUserStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to ActivateButton of type Button
        /// </summary>
        private Button cachedActivateButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AboutDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AboutDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAboutDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAboutDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheProductIsLicensedToStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAboutDialogControls.TheProductIsLicensedToStaticControl
        {
            get
            {
                if ((this.cachedTheProductIsLicensedToStaticControl == null))
                {
                    this.cachedTheProductIsLicensedToStaticControl = new StaticControl(this, AboutDialog.ControlIDs.TheProductIsLicensedToStaticControl);
                }
                return this.cachedTheProductIsLicensedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VersionStaticControlcontrol
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAboutDialogControls.VersionStaticControl
        {
            get
            {
                if ((this.cachedVersionStaticControl== null))
                {
                    this.cachedVersionStaticControl= new StaticControl(this, AboutDialog.ControlIDs.VersionStaticControl);
                }
                return this.cachedVersionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProductIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAboutDialogControls.ProductIDStaticControl
        {
            get
            {
                if ((this.cachedProductIDStaticControl == null))
                {
                    this.cachedProductIDStaticControl = new StaticControl(this, AboutDialog.ControlIDs.ProductIDStaticControl);
                }
                return this.cachedProductIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MicrosoftStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAboutDialogControls.MicrosoftStaticControl
        {
            get
            {
                if ((this.cachedMicrosoftStaticControl == null))
                {
                    this.cachedMicrosoftStaticControl = new StaticControl(this, AboutDialog.ControlIDs.MicrosoftStaticControl);
                }
                return this.cachedMicrosoftStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MicrosoftUserStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAboutDialogControls.MicrosoftUserStaticControl
        {
            get
            {
                if ((this.cachedMicrosoftUserStaticControl == null))
                {
                    this.cachedMicrosoftUserStaticControl = new StaticControl(this, AboutDialog.ControlIDs.MicrosoftUserStaticControl);
                }
                return this.cachedMicrosoftUserStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// 	[a-joelj] 07MAY10 Updated to use a Query ID
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAboutDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AboutDialog.QueryIds.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ActivateButton control
        /// </summary>      
        /// -----------------------------------------------------------------------------
        Button IAboutDialogControls.ActivateButton
        {
            get
            {
                if ((this.cachedActivateButton == null))
                {
                    this.cachedActivateButton = new Button(this, AboutDialog.QueryIds.ActivateButton);
                }
                return this.cachedActivateButton;
            }
        }


        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Activate
        /// </summary>
        /// -----------------------------------------------------------------------------
        public virtual void ClickActivate()
        {
            this.Controls.ActivateButton.Click();
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// 	[a-joelj] 07MAY10 Updated Init to use Query ID rather than Winforms control ID
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                 //Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    app.MainWindow, 
                    QueryIds.AboutDialog, 
                    Core.Common.Constants.DefaultDialogTimeout);
                                
                ////SCE window
                ////The workaround with the bug#172123
                //tempWindow = new Window(app.MainWindow, new QID(";[UIA, VisibleOnly]Name = '" + "SCE About" + "' && Role = 'window'"), Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                // 
                // app.DTE.ExecuteCmd(Commands.COMMAND_NAME_HERE);
                // 
                // tempWindow = new Window(Strings.DialogTitle, Utilities.StringMatchSyntax.ExactMatch, strDialogClass, Utilities.StringMatchSyntax.ExactMatch, app.MainWindow, timeOut);
                // if (tempWindow != null)
                //     return tempWindow;
                // 
                // throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + ".");
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";HelpAboutForm;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.HelpAboutForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheProductIsLicensedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheProductIsLicensedTo = ";The product is licensed to:;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft" +
                ".EnterpriseManagement.Mom.Internal.UI.Console.HelpAboutForm;licenseLabel.Text";
            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProductID
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceProductID = "Product ID: ";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Microsoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMicrosoft = ";Microsoft;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Console.HelpAboutForm;licOrgLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MicrosoftUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMicrosoftUser = ";Microsoft User;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.HelpAboutForm;licUserLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Activate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceActivate = ";Activate;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.HelpAboutForm;HelpAboutFormActivateButtonText.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";

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
            /// Caches the translated resource string for:  TheProductIsLicensedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheProductIsLicensedTo;
            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProductID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProductID;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Microsoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMicrosoft;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MicrosoftUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMicrosoftUser;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Activate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActivate;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 07OCT05 Created
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
            /// Exposes access to the TheProductIsLicensedTo translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 07OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheProductIsLicensedTo
            {
                get
                {
                    if ((cachedTheProductIsLicensedTo == null))
                    {
                        cachedTheProductIsLicensedTo = CoreManager.MomConsole.GetIntlStr(ResourceTheProductIsLicensedTo);
                    }
                    return cachedTheProductIsLicensedTo;
                }
            }
            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProductID translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 07OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProductID
            {
                get
                {
                    if ((cachedProductID == null))
                    {
                        cachedProductID = CoreManager.MomConsole.GetIntlStr(ResourceProductID);
                    }
                    return cachedProductID;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Microsoft translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 07OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Microsoft
            {
                get
                {
                    if ((cachedMicrosoft == null))
                    {
                        cachedMicrosoft = CoreManager.MomConsole.GetIntlStr(ResourceMicrosoft);
                    }
                    return cachedMicrosoft;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MicrosoftUser translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 07OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MicrosoftUser
            {
                get
                {
                    if ((cachedMicrosoftUser == null))
                    {
                        cachedMicrosoftUser = CoreManager.MomConsole.GetIntlStr(ResourceMicrosoftUser);
                    }
                    return cachedMicrosoftUser;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 07OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Activate translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string Activate
            {
                get
                {
                    if ((cachedActivate == null))
                    {
                        cachedActivate = CoreManager.MomConsole.GetIntlStr(ResourceActivate);
                    }
                    return cachedActivate;
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
        /// 	[mbickle] 07OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TheProductIsLicensedToStaticControl
            /// </summary>
            public const string TheProductIsLicensedToStaticControl = "licenseLabel";
            
            /// <summary>
            /// Control ID for Version6031250StaticControl
            /// </summary>
            public const string VersionStaticControl= "versionLabel";
            
            /// <summary>
            /// Control ID for ProductIDStaticControl
            /// </summary>
            public const string ProductIDStaticControl = "licProductIdLabel";
            
            /// <summary>
            /// Control ID for MicrosoftStaticControl
            /// </summary>
            public const string MicrosoftStaticControl = "licOrgLabel";
            
            /// <summary>
            /// Control ID for MicrosoftUserStaticControl
            /// </summary>
            public const string MicrosoftUserStaticControl = "licUserLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "closeButton";

            /// <summary>
            /// Automation ID for About Dialog
            /// </summary>
            /// <remarks>
            /// "SCOM About Dialog"
            /// </remarks>
            public const string AboutDialogAutomationID = "SCOM About Dialog";

            /// <summary>
            /// Control Name for About Dialog
            /// </summary>
            /// <remarks>
            /// "System Center Operations Manager About"
            /// </remarks>
            public const string AboutDialogName = "Operations Manager About";
        }
        #endregion

        #region QueryIds
        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///     [a-joelj]   07MAY10 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants
            /// <summary>
            /// Contains resource string for TaskPane query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAboutDialog = 
                ";[UIA]AutomationId='" + ControlIDs.AboutDialogAutomationID + "' && Name='" + ControlIDs.AboutDialogName + "'";
            
            /// <summary>
            /// Contains resource string for Splitter query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOKButton = ";[UIA]AutomationId='Button_1'";

            /// <summary>
            /// Contains resource string for Splitter query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceActivateButton = ";[UIA]AutomationId='ActivateButton'";


            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedAboutDialog;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedOKButton;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedActivateButton;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AboutDialog translated resource qid string
            /// </summary>
            /// <history>
            ///     [a-joelj]   07MAY10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AboutDialog
            {
                get
                {
                    if (cachedAboutDialog == null)
                    {
                        cachedAboutDialog = new QID(ResourceAboutDialog);
                    }

                    return cachedAboutDialog;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OKButton translated resource qid string
            /// </summary>
            /// <history>
            ///     [a-joelj]   07MAY10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OKButton
            {
                get
                {
                    if (cachedOKButton == null)
                    {
                        cachedOKButton = new QID(ResourceOKButton);
                    }

                    return cachedOKButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ActivateButton translated resource qid string
            /// </summary>           
            /// -----------------------------------------------------------------------------
            public static QID ActivateButton
            {
                get
                {
                    if (cachedActivateButton == null)
                    {
                        cachedActivateButton = new QID(ResourceActivateButton);
                    }

                    return cachedActivateButton;
                }
            }

            #endregion
        }
        #endregion
    }
}
