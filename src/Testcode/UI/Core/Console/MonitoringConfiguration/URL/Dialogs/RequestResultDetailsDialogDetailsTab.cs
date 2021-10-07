// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestResultDetailsDialogDetailsTab.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRequestResultDetailsDialogDetailsTabControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRequestResultDetailsDialogDetailsTabControls, for RequestResultDetailsDialogDetailsTab.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRequestResultDetailsDialogDetailsTabControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServerCertificateExpirationDaysTextBox
        /// </summary>
        TextBox ServerCertificateExpirationDaysTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServerCertificateExpirationDaysStaticControl
        /// </summary>
        StaticControl ServerCertificateExpirationDaysStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseBodySizeTextBox
        /// </summary>
        TextBox ResponseBodySizeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseBodySizeStaticControl
        /// </summary>
        StaticControl ResponseBodySizeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPResponseCodeTextBox
        /// </summary>
        TextBox HTTPResponseCodeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPResponseCodeStaticControl
        /// </summary>
        StaticControl HTTPResponseCodeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TotalResponseTimeMillisecondsTextBox
        /// </summary>
        TextBox TotalResponseTimeMillisecondsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TotalResponseTimeMillisecondsStaticControl
        /// </summary>
        StaticControl TotalResponseTimeMillisecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DNSResolutionTimeMillisecondsTextBox
        /// </summary>
        TextBox DNSResolutionTimeMillisecondsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DNSResolutionTimeMillisecondsStaticControl
        /// </summary>
        StaticControl DNSResolutionTimeMillisecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestProcessedSuccessfullyTextBox
        /// </summary>
        TextBox RequestProcessedSuccessfullyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResultStaticControl
        /// </summary>
        StaticControl ResultStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access URLTextBox
        /// </summary>
        TextBox URLTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access URLStaticControl
        /// </summary>
        StaticControl URLStaticControl
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
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RequestResultDetailsDialogDetailsTab : Dialog, IRequestResultDetailsDialogDetailsTabControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ServerCertificateExpirationDaysTextBox of type TextBox
        /// </summary>
        private TextBox cachedServerCertificateExpirationDaysTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ServerCertificateExpirationDaysStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServerCertificateExpirationDaysStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResponseBodySizeTextBox of type TextBox
        /// </summary>
        private TextBox cachedResponseBodySizeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ResponseBodySizeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResponseBodySizeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HTTPResponseCodeTextBox of type TextBox
        /// </summary>
        private TextBox cachedHTTPResponseCodeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPResponseCodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPResponseCodeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TotalResponseTimeMillisecondsTextBox of type TextBox
        /// </summary>
        private TextBox cachedTotalResponseTimeMillisecondsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TotalResponseTimeMillisecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTotalResponseTimeMillisecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DNSResolutionTimeMillisecondsTextBox of type TextBox
        /// </summary>
        private TextBox cachedDNSResolutionTimeMillisecondsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DNSResolutionTimeMillisecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDNSResolutionTimeMillisecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyTextBox of type TextBox
        /// </summary>
        private TextBox cachedRequestProcessedSuccessfullyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ResultStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResultStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to URLTextBox of type TextBox
        /// </summary>
        private TextBox cachedURLTextBox;
        
        /// <summary>
        /// Cache to hold a reference to URLStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedURLStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RequestResultDetailsDialogDetailsTab of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RequestResultDetailsDialogDetailsTab(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRequestResultDetailsDialogDetailsTab Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRequestResultDetailsDialogDetailsTabControls Controls
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
        ///  Routine to set/get the text in control ServerCertificateExpirationDays
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServerCertificateExpirationDaysText
        {
            get
            {
                return this.Controls.ServerCertificateExpirationDaysTextBox.Text;
            }
            
            set
            {
                this.Controls.ServerCertificateExpirationDaysTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ResponseBodySize
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResponseBodySizeText
        {
            get
            {
                return this.Controls.ResponseBodySizeTextBox.Text;
            }
            
            set
            {
                this.Controls.ResponseBodySizeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control HTTPResponseCode
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HTTPResponseCodeText
        {
            get
            {
                return this.Controls.HTTPResponseCodeTextBox.Text;
            }
            
            set
            {
                this.Controls.HTTPResponseCodeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TotalResponseTimeMilliseconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TotalResponseTimeMillisecondsText
        {
            get
            {
                return this.Controls.TotalResponseTimeMillisecondsTextBox.Text;
            }
            
            set
            {
                this.Controls.TotalResponseTimeMillisecondsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DNSResolutionTimeMilliseconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DNSResolutionTimeMillisecondsText
        {
            get
            {
                return this.Controls.DNSResolutionTimeMillisecondsTextBox.Text;
            }
            
            set
            {
                this.Controls.DNSResolutionTimeMillisecondsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RequestProcessedSuccessfully
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RequestProcessedSuccessfullyText
        {
            get
            {
                return this.Controls.RequestProcessedSuccessfullyTextBox.Text;
            }
            
            set
            {
                this.Controls.RequestProcessedSuccessfullyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control URL
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string URLText
        {
            get
            {
                return this.Controls.URLTextBox.Text;
            }
            
            set
            {
                this.Controls.URLTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestResultDetailsDialogDetailsTabControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, RequestResultDetailsDialogDetailsTab.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRequestResultDetailsDialogDetailsTabControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerCertificateExpirationDaysTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.ServerCertificateExpirationDaysTextBox
        {
            get
            {
                if ((this.cachedServerCertificateExpirationDaysTextBox == null))
                {
                    this.cachedServerCertificateExpirationDaysTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.ServerCertificateExpirationDaysTextBox);
                }
                return this.cachedServerCertificateExpirationDaysTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerCertificateExpirationDaysStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.ServerCertificateExpirationDaysStaticControl
        {
            get
            {
                if ((this.cachedServerCertificateExpirationDaysStaticControl == null))
                {
                    this.cachedServerCertificateExpirationDaysStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.ServerCertificateExpirationDaysStaticControl);
                }
                return this.cachedServerCertificateExpirationDaysStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseBodySizeTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.ResponseBodySizeTextBox
        {
            get
            {
                if ((this.cachedResponseBodySizeTextBox == null))
                {
                    this.cachedResponseBodySizeTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.ResponseBodySizeTextBox);
                }
                return this.cachedResponseBodySizeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseBodySizeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.ResponseBodySizeStaticControl
        {
            get
            {
                if ((this.cachedResponseBodySizeStaticControl == null))
                {
                    this.cachedResponseBodySizeStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.ResponseBodySizeStaticControl);
                }
                return this.cachedResponseBodySizeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPResponseCodeTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.HTTPResponseCodeTextBox
        {
            get
            {
                if ((this.cachedHTTPResponseCodeTextBox == null))
                {
                    this.cachedHTTPResponseCodeTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.HTTPResponseCodeTextBox);
                }
                return this.cachedHTTPResponseCodeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPResponseCodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.HTTPResponseCodeStaticControl
        {
            get
            {
                if ((this.cachedHTTPResponseCodeStaticControl == null))
                {
                    this.cachedHTTPResponseCodeStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.HTTPResponseCodeStaticControl);
                }
                return this.cachedHTTPResponseCodeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TotalResponseTimeMillisecondsTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.TotalResponseTimeMillisecondsTextBox
        {
            get
            {
                if ((this.cachedTotalResponseTimeMillisecondsTextBox == null))
                {
                    this.cachedTotalResponseTimeMillisecondsTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.TotalResponseTimeMillisecondsTextBox);
                }
                return this.cachedTotalResponseTimeMillisecondsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TotalResponseTimeMillisecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.TotalResponseTimeMillisecondsStaticControl
        {
            get
            {
                if ((this.cachedTotalResponseTimeMillisecondsStaticControl == null))
                {
                    this.cachedTotalResponseTimeMillisecondsStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.TotalResponseTimeMillisecondsStaticControl);
                }
                return this.cachedTotalResponseTimeMillisecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DNSResolutionTimeMillisecondsTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.DNSResolutionTimeMillisecondsTextBox
        {
            get
            {
                if ((this.cachedDNSResolutionTimeMillisecondsTextBox == null))
                {
                    this.cachedDNSResolutionTimeMillisecondsTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.DNSResolutionTimeMillisecondsTextBox);
                }
                return this.cachedDNSResolutionTimeMillisecondsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DNSResolutionTimeMillisecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.DNSResolutionTimeMillisecondsStaticControl
        {
            get
            {
                if ((this.cachedDNSResolutionTimeMillisecondsStaticControl == null))
                {
                    this.cachedDNSResolutionTimeMillisecondsStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.DNSResolutionTimeMillisecondsStaticControl);
                }
                return this.cachedDNSResolutionTimeMillisecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.RequestProcessedSuccessfullyTextBox
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyTextBox == null))
                {
                    this.cachedRequestProcessedSuccessfullyTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.RequestProcessedSuccessfullyTextBox);
                }
                return this.cachedRequestProcessedSuccessfullyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResultStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.ResultStaticControl
        {
            get
            {
                if ((this.cachedResultStaticControl == null))
                {
                    this.cachedResultStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.ResultStaticControl);
                }
                return this.cachedResultStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the URLTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogDetailsTabControls.URLTextBox
        {
            get
            {
                if ((this.cachedURLTextBox == null))
                {
                    this.cachedURLTextBox = new TextBox(this, RequestResultDetailsDialogDetailsTab.ControlIDs.URLTextBox);
                }
                return this.cachedURLTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the URLStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogDetailsTabControls.URLStaticControl
        {
            get
            {
                if ((this.cachedURLStaticControl == null))
                {
                    this.cachedURLStaticControl = new StaticControl(this, RequestResultDetailsDialogDetailsTab.ControlIDs.URLStaticControl);
                }
                return this.cachedURLStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw;
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
        /// 	[faizalk] 4/24/2006 Created
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
            private const string ResourceDialogTitle = ";Request Result Details;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RequestResultForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";&Close;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.PageFrameworks.SheetFramework;menuExit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServerCertificateExpirationDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServerCertificateExpirationDays = ";Server certificate &expiration (days):;ManagedString;Microsoft.MOM.UI.Components" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.PagesURLTemplate" +
                "Page.RequestResultForm;labelCertExpiration.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResponseBodySize
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResponseBodySize = ";Response &body size:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.PagesURLTemplatePage.RequestResult" +
                "Form;labelResponseBodySize.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HTTPResponseCode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHTTPResponseCode = ";&HTTP response code:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.PagesURLTemplatePage.RequestResult" +
                "Form;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TotalResponseTimeMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTotalResponseTimeMilliseconds = ";&Total response time (milliseconds):;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.PagesURLTemplatePa" +
                "ge.RequestResultForm;labelTotalResponse.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DNSResolutionTimeMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDNSResolutionTimeMilliseconds = ";D&NS resolution time (milliseconds):;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.PagesURLTemplatePa" +
                "ge.RequestResultForm;labelDNS.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Result
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResult = ";&Result:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.PagesURLTemplatePage.RequestResultForm;labelRe" +
                "sult.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  URL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceURL = ";&URL:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseURLPage;labelUrl.Text";
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
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServerCertificateExpirationDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServerCertificateExpirationDays;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResponseBodySize
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResponseBodySize;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HTTPResponseCode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHTTPResponseCode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TotalResponseTimeMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTotalResponseTimeMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DNSResolutionTimeMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDNSResolutionTimeMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Result
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResult;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  URL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedURL;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServerCertificateExpirationDays translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServerCertificateExpirationDays
            {
                get
                {
                    if ((cachedServerCertificateExpirationDays == null))
                    {
                        cachedServerCertificateExpirationDays = CoreManager.MomConsole.GetIntlStr(ResourceServerCertificateExpirationDays);
                    }
                    return cachedServerCertificateExpirationDays;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResponseBodySize translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResponseBodySize
            {
                get
                {
                    if ((cachedResponseBodySize == null))
                    {
                        cachedResponseBodySize = CoreManager.MomConsole.GetIntlStr(ResourceResponseBodySize);
                    }
                    return cachedResponseBodySize;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HTTPResponseCode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HTTPResponseCode
            {
                get
                {
                    if ((cachedHTTPResponseCode == null))
                    {
                        cachedHTTPResponseCode = CoreManager.MomConsole.GetIntlStr(ResourceHTTPResponseCode);
                    }
                    return cachedHTTPResponseCode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TotalResponseTimeMilliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TotalResponseTimeMilliseconds
            {
                get
                {
                    if ((cachedTotalResponseTimeMilliseconds == null))
                    {
                        cachedTotalResponseTimeMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceTotalResponseTimeMilliseconds);
                    }
                    return cachedTotalResponseTimeMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DNSResolutionTimeMilliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DNSResolutionTimeMilliseconds
            {
                get
                {
                    if ((cachedDNSResolutionTimeMilliseconds == null))
                    {
                        cachedDNSResolutionTimeMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceDNSResolutionTimeMilliseconds);
                    }
                    return cachedDNSResolutionTimeMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Result translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Result
            {
                get
                {
                    if ((cachedResult == null))
                    {
                        cachedResult = CoreManager.MomConsole.GetIntlStr(ResourceResult);
                    }
                    return cachedResult;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the URL translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string URL
            {
                get
                {
                    if ((cachedURL == null))
                    {
                        cachedURL = CoreManager.MomConsole.GetIntlStr(ResourceURL);
                    }
                    return cachedURL;
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
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "buttonClose";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabControl";
            
            /// <summary>
            /// Control ID for ServerCertificateExpirationDaysTextBox
            /// </summary>
            public const string ServerCertificateExpirationDaysTextBox = "textBoxSSLExpiration";
            
            /// <summary>
            /// Control ID for ServerCertificateExpirationDaysStaticControl
            /// </summary>
            public const string ServerCertificateExpirationDaysStaticControl = "labelCertExpiration";
            
            /// <summary>
            /// Control ID for ResponseBodySizeTextBox
            /// </summary>
            public const string ResponseBodySizeTextBox = "textBoxResponseBodySize";
            
            /// <summary>
            /// Control ID for ResponseBodySizeStaticControl
            /// </summary>
            public const string ResponseBodySizeStaticControl = "labelResponseBodySize";
            
            /// <summary>
            /// Control ID for HTTPResponseCodeTextBox
            /// </summary>
            public const string HTTPResponseCodeTextBox = "textBoxHTTPResponseCode";
            
            /// <summary>
            /// Control ID for HTTPResponseCodeStaticControl
            /// </summary>
            public const string HTTPResponseCodeStaticControl = "label2";
            
            /// <summary>
            /// Control ID for TotalResponseTimeMillisecondsTextBox
            /// </summary>
            public const string TotalResponseTimeMillisecondsTextBox = "textBoxTotalResponse";
            
            /// <summary>
            /// Control ID for TotalResponseTimeMillisecondsStaticControl
            /// </summary>
            public const string TotalResponseTimeMillisecondsStaticControl = "labelTotalResponse";
            
            /// <summary>
            /// Control ID for DNSResolutionTimeMillisecondsTextBox
            /// </summary>
            public const string DNSResolutionTimeMillisecondsTextBox = "textBoxDNS";
            
            /// <summary>
            /// Control ID for DNSResolutionTimeMillisecondsStaticControl
            /// </summary>
            public const string DNSResolutionTimeMillisecondsStaticControl = "labelDNS";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyTextBox
            /// </summary>
            public const string RequestProcessedSuccessfullyTextBox = "textBoxResult";
            
            /// <summary>
            /// Control ID for ResultStaticControl
            /// </summary>
            public const string ResultStaticControl = "labelResult";
            
            /// <summary>
            /// Control ID for URLTextBox
            /// </summary>
            public const string URLTextBox = "textBoxURL";
            
            /// <summary>
            /// Control ID for URLStaticControl
            /// </summary>
            public const string URLStaticControl = "labelURL";
        }
        #endregion
    }
}
