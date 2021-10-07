// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestPropertiesDialogGeneralTab.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-eryon] 7/24/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IRequestPropertiesDialogGeneralTabControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRequestPropertiesDialogGeneralTabControls, for RequestPropertiesDialogGeneralTab.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/24/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRequestPropertiesDialogGeneralTabControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
        /// Read-only property to access InsertParameterButton
        /// </summary>
        Button InsertParameterButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InsertParameterButton2
        /// </summary>
        Button InsertParameterButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPVersionComboBox
        /// </summary>
        ComboBox HTTPVersionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPVersionStaticControl
        /// </summary>
        StaticControl HTTPVersionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestBodyTextBox
        /// </summary>
        TextBox RequestBodyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestBodyStaticControl
        /// </summary>
        StaticControl RequestBodyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPMethodComboBox
        /// </summary>
        ComboBox HTTPMethodComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPMethodStaticControl
        /// </summary>
        StaticControl HTTPMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestURLComboBox
        /// </summary>
        ComboBox RequestURLComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestURLTextBox
        /// </summary>
        TextBox RequestURLTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestURLStaticControl
        /// </summary>
        StaticControl RequestURLStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheRequestURLSettingsStaticControl
        /// </summary>
        StaticControl SelectTheRequestURLSettingsStaticControl
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
    /// 	[v-eryon] 7/24/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RequestPropertiesDialogGeneralTab : Dialog, IRequestPropertiesDialogGeneralTabControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to InsertParameterButton of type Button
        /// </summary>
        private Button cachedInsertParameterButton;
        
        /// <summary>
        /// Cache to hold a reference to InsertParameterButton2 of type Button
        /// </summary>
        private Button cachedInsertParameterButton2;
        
        /// <summary>
        /// Cache to hold a reference to HTTPVersionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedHTTPVersionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPVersionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPVersionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestBodyTextBox of type TextBox
        /// </summary>
        private TextBox cachedRequestBodyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RequestBodyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestBodyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HTTPMethodComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedHTTPMethodComboBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestURLComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRequestURLComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RequestURLTextBox of type TextBox
        /// </summary>
        private TextBox cachedRequestURLTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RequestURLStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestURLStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheRequestURLSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheRequestURLSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of RequestPropertiesDialogGeneralTab of type RequestPropertiesDialogGeneralTab
        /// </param>
        /// <param name="isCreateNewRequest">Flag whether to create new request dialog</param>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RequestPropertiesDialogGeneralTab(MomConsoleApp app, bool isCreateNewRequest) :
            base(app, Init(app, isCreateNewRequest))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IRequestPropertiesDialogGeneralTab Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRequestPropertiesDialogGeneralTabControls Controls
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
        ///  Routine to set/get the text in control HTTPVersion
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HTTPVersionText
        {
            get
            {
                return this.Controls.HTTPVersionComboBox.Text;
            }
            
            set
            {
                this.Controls.HTTPVersionComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RequestBody
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RequestBodyText
        {
            get
            {
                return this.Controls.RequestBodyTextBox.Text;
            }
            
            set
            {
                this.Controls.RequestBodyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control HTTPMethod
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HTTPMethodText
        {
            get
            {
                return this.Controls.HTTPMethodComboBox.Text;
            }
            
            set
            {
                this.Controls.HTTPMethodComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RequestURL
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RequestURLText
        {
            get
            {
                return this.Controls.RequestURLComboBox.Text;
            }
            
            set
            {
                this.Controls.RequestURLComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RequestURL2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RequestURL2Text
        {
            get
            {
                return this.Controls.RequestURLTextBox.Text;
            }
            
            set
            {
                this.Controls.RequestURLTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogGeneralTabControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RequestPropertiesDialogGeneralTab.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogGeneralTabControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RequestPropertiesDialogGeneralTab.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogGeneralTabControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RequestPropertiesDialogGeneralTab.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRequestPropertiesDialogGeneralTabControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, RequestPropertiesDialogGeneralTab.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InsertParameterButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogGeneralTabControls.InsertParameterButton
        {
            get
            {
                if ((this.cachedInsertParameterButton == null))
                {
                    this.cachedInsertParameterButton = new Button(this, RequestPropertiesDialogGeneralTab.ControlIDs.InsertParameterButton);
                }
                
                return this.cachedInsertParameterButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InsertParameterButton2 control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogGeneralTabControls.InsertParameterButton2
        {
            get
            {
                if ((this.cachedInsertParameterButton2 == null))
                {
                    this.cachedInsertParameterButton2 = new Button(this, RequestPropertiesDialogGeneralTab.ControlIDs.InsertParameterButton2);
                }
                
                return this.cachedInsertParameterButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPVersionComboBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRequestPropertiesDialogGeneralTabControls.HTTPVersionComboBox
        {
            get
            {
                if ((this.cachedHTTPVersionComboBox == null))
                {
                    this.cachedHTTPVersionComboBox = new ComboBox(this, RequestPropertiesDialogGeneralTab.ControlIDs.HTTPVersionComboBox);
                }
                
                return this.cachedHTTPVersionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPVersionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogGeneralTabControls.HTTPVersionStaticControl
        {
            get
            {
                if ((this.cachedHTTPVersionStaticControl == null))
                {
                    this.cachedHTTPVersionStaticControl = new StaticControl(this, RequestPropertiesDialogGeneralTab.ControlIDs.HTTPVersionStaticControl);
                }
                
                return this.cachedHTTPVersionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestBodyTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestPropertiesDialogGeneralTabControls.RequestBodyTextBox
        {
            get
            {
                if ((this.cachedRequestBodyTextBox == null))
                {
                    this.cachedRequestBodyTextBox = new TextBox(this, RequestPropertiesDialogGeneralTab.ControlIDs.RequestBodyTextBox);
                }
                
                return this.cachedRequestBodyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestBodyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogGeneralTabControls.RequestBodyStaticControl
        {
            get
            {
                if ((this.cachedRequestBodyStaticControl == null))
                {
                    this.cachedRequestBodyStaticControl = new StaticControl(this, RequestPropertiesDialogGeneralTab.ControlIDs.RequestBodyStaticControl);
                }
                
                return this.cachedRequestBodyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPMethodComboBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRequestPropertiesDialogGeneralTabControls.HTTPMethodComboBox
        {
            get
            {
                if ((this.cachedHTTPMethodComboBox == null))
                {
                    this.cachedHTTPMethodComboBox = new ComboBox(this, RequestPropertiesDialogGeneralTab.ControlIDs.HTTPMethodComboBox);
                }
                
                return this.cachedHTTPMethodComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogGeneralTabControls.HTTPMethodStaticControl
        {
            get
            {
                if ((this.cachedHTTPMethodStaticControl == null))
                {
                    this.cachedHTTPMethodStaticControl = new StaticControl(this, RequestPropertiesDialogGeneralTab.ControlIDs.HTTPMethodStaticControl);
                }
                
                return this.cachedHTTPMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestURLComboBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRequestPropertiesDialogGeneralTabControls.RequestURLComboBox
        {
            get
            {
                if ((this.cachedRequestURLComboBox == null))
                {
                    this.cachedRequestURLComboBox = new ComboBox(this, RequestPropertiesDialogGeneralTab.ControlIDs.RequestURLComboBox);
                }
                
                return this.cachedRequestURLComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestURLTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestPropertiesDialogGeneralTabControls.RequestURLTextBox
        {
            get
            {
                if ((this.cachedRequestURLTextBox == null))
                {
                    this.cachedRequestURLTextBox = new TextBox(this, RequestPropertiesDialogGeneralTab.ControlIDs.RequestURLTextBox);
                }
                
                return this.cachedRequestURLTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestURLStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogGeneralTabControls.RequestURLStaticControl
        {
            get
            {
                if ((this.cachedRequestURLStaticControl == null))
                {
                    this.cachedRequestURLStaticControl = new StaticControl(this, RequestPropertiesDialogGeneralTab.ControlIDs.RequestURLStaticControl);
                }
                
                return this.cachedRequestURLStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheRequestURLSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogGeneralTabControls.SelectTheRequestURLSettingsStaticControl
        {
            get
            {
                if ((this.cachedSelectTheRequestURLSettingsStaticControl == null))
                {
                    this.cachedSelectTheRequestURLSettingsStaticControl = new StaticControl(this, RequestPropertiesDialogGeneralTab.ControlIDs.SelectTheRequestURLSettingsStaticControl);
                }
                
                return this.cachedSelectTheRequestURLSettingsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button InsertParameter
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInsertParameterBody()
        {
            this.Controls.InsertParameterButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button InsertParameter2
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInsertParameterUrl()
        {
            this.Controls.InsertParameterButton2.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">RequestPropertiesDialogGeneralTab owning the dialog.</param>
        /// <param name="isCreateNewRequest">Whether to Create New Request</param>
        /// <history>
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, bool isCreateNewRequest)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;

            string dialogTitle = null;
            if (!isCreateNewRequest)
                dialogTitle = Strings.DialogTitle1;
            else
                dialogTitle = Strings.DialogTitle2;

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(dialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(app.GetIntlStr(dialogTitle), StringMatchSyntax.WildCard);

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
                    // log the failureD:\enlistment\MOM10.146284\private\Testcode\UI\Core\Console\MonitoringConfiguration\URL\Dialogs\RequestPropertiesDialogMonitoringTab.cs

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Request Properties
            /// </summary>
            // Request Properties
            public const string ResourceDialogTitle1 = ";Request Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResou" +
                "rces;RequestPropertiesEditTitle";

            /// <summary>
            /// Resource string for Request Properties
            /// </summary>
            // Request Properties
            public const string ResourceDialogTitle2 = ";Create New Request;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources" +
                ";RequestPropertiesNewTitle";

            /// <summary>
            /// Resource string for Apply
            /// </summary>
            // &Apply
            public const string Apply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            // &Cancel
            public const string Cancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            // &OK
            public const string OK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// <summary>
            /// Resource string for Tab0
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string Tab0 = "Tab0";
            
            /// <summary>
            /// Resource string for Insert parameter...
            /// </summary>
            // In&sert parameter...
            public const string InsertParameter = ";In&sert parameter...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProperties" +
                "Form;buttonBodyParameter.Text";
            
            /// <summary>
            /// Resource string for Insert parameter...
            /// </summary>
            // I&nsert parameter...
            public const string InsertParameter2 = ";I&nsert parameter...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProperties" +
                "Form;buttonUrlParameter.Text";
            
            /// <summary>
            /// Resource string for HTTP version:
            /// </summary>
            // HTTP &version:
            public const string HTTPVersion = ";HTTP &version:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;l" +
                "abelVersion.Text";
            
            /// <summary>
            /// Resource string for Request Body:
            /// </summary>
            // Request &Body:
            public const string RequestBody = ";Request &Body:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;l" +
                "abelBody.Text";
            
            /// <summary>
            /// Resource string for HTTP method:
            /// </summary>
            // HTTP &method:
            public const string HTTPMethod = ";HTTP &method:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;la" +
                "belVerb.Text";
            
            /// <summary>
            /// Resource string for Request URL:
            /// </summary>
            // Request &URL:
            public const string RequestURL = ";Request &URL:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;la" +
                "belURL.Text";
            
            /// <summary>
            /// Resource string for Select the request URL settings
            /// </summary>
            // Select the request URL settings
            public const string SelectTheRequestURLSettings = ";Select the request URL settings;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.Reques" +
                "tPropertiesForm;pageSectionLabelURLDesc.Text";

            /// <summary>
            /// Resource string for HTTP Header
            /// </summary>
            //  HTTP Header
            public const string ResourceTabHTTPHeader = ";HTTP Headers;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll"+
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm"+
                ";tabPageHeaders.Text";

            /// <summary>
            /// Resource string for Monitoring
            /// </summary>
            //  Monitoring
            public const string ResourceTabMonitoring = ";Monitoring;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll"+
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm"+
                ";tabPageMonitor.Text";

            /// <summary>
            /// Resource string for Extraction Rules
            /// </summary>
            //  Extraction Rules
            public const string ResourceTabExtractionRules = ";Extraction Rules;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll"+
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm"+
                ";tabPageExtractionRules.Text";
            
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the HTTP Header tab name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTabHTTPHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Monitoring tab name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTabMonitoring;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Extraction Rules tab name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTabExtractionRules;


            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle1
            {
                get
                {
                    if ((cachedDialogTitle1 == null))
                    {
                        cachedDialogTitle1 = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle1);
                    }

                    return cachedDialogTitle1;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle2
            {
                get
                {
                    if ((cachedDialogTitle2 == null))
                    {
                        cachedDialogTitle2 = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle2);
                    }

                    return cachedDialogTitle2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HTTP Header Tab Title 
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TabHTTPHeader
            {
                get
                {
                    if ((cachedTabHTTPHeader == null))
                    {
                        cachedTabHTTPHeader = CoreManager.MomConsole.GetIntlStr(ResourceTabHTTPHeader);
                    }
                    return cachedTabHTTPHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Tab Title 
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TabMonitoring
            {
                get
                {
                    if ((cachedTabMonitoring == null))
                    {
                        cachedTabMonitoring = CoreManager.MomConsole.GetIntlStr(ResourceTabMonitoring);
                    }
                    return cachedTabMonitoring;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Extraction Rules Tab Title 
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TabExtractionsRules
            {
                get
                {
                    if ((cachedTabExtractionRules == null))
                    {
                        cachedTabExtractionRules = CoreManager.MomConsole.GetIntlStr(ResourceTabExtractionRules);
                    }
                    return cachedTabExtractionRules;
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
        /// 	[v-eryon] 7/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "buttonApply";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabControl";
            
            /// <summary>
            /// Control ID for InsertParameterButton
            /// </summary>
            public const string InsertParameterButton = "buttonBodyParameter";
            
            /// <summary>
            /// Control ID for InsertParameterButton2
            /// </summary>
            public const string InsertParameterButton2 = "buttonUrlParameter";
            
            /// <summary>
            /// Control ID for HTTPVersionComboBox
            /// </summary>
            public const string HTTPVersionComboBox = "comboBoxVersion";
            
            /// <summary>
            /// Control ID for HTTPVersionStaticControl
            /// </summary>
            public const string HTTPVersionStaticControl = "labelVersion";
            
            /// <summary>
            /// Control ID for RequestBodyTextBox
            /// </summary>
            public const string RequestBodyTextBox = "textBoxBody";
            
            /// <summary>
            /// Control ID for RequestBodyStaticControl
            /// </summary>
            public const string RequestBodyStaticControl = "labelBody";
            
            /// <summary>
            /// Control ID for HTTPMethodComboBox
            /// </summary>
            public const string HTTPMethodComboBox = "comboBoxVerb";
            
            /// <summary>
            /// Control ID for HTTPMethodStaticControl
            /// </summary>
            public const string HTTPMethodStaticControl = "labelVerb";
            
            /// <summary>
            /// Control ID for RequestURLComboBox
            /// </summary>
            public const string RequestURLComboBox = "comboBoxScheme";
            
            /// <summary>
            /// Control ID for RequestURLTextBox
            /// </summary>
            public const string RequestURLTextBox = "textBoxUrl";
            
            /// <summary>
            /// Control ID for RequestURLStaticControl
            /// </summary>
            public const string RequestURLStaticControl = "labelURL";
            
            /// <summary>
            /// Control ID for SelectTheRequestURLSettingsStaticControl
            /// </summary>
            public const string SelectTheRequestURLSettingsStaticControl = "pageSectionLabelURLDesc";
        }
        #endregion
    }
}
