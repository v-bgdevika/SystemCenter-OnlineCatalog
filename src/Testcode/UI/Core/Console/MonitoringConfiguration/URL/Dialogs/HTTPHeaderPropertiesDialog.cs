// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="HTTPHeaderPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-eryon] 7/30/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IHTTPHeaderPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IHTTPHeaderPropertiesDialogControls, for HTTPHeaderPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHTTPHeaderPropertiesDialogControls
    {
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
        /// Read-only property to access HTTPHeaderValueTextBox
        /// </summary>
        TextBox HTTPHeaderValueTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPHeaderNameTextBox
        /// </summary>
        TextBox HTTPHeaderNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPHeaderValueStaticControl
        /// </summary>
        StaticControl HTTPHeaderValueStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPHeaderNameStaticControl
        /// </summary>
        StaticControl HTTPHeaderNameStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class HTTPHeaderPropertiesDialog : Dialog, IHTTPHeaderPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to InsertParameterButton of type Button
        /// </summary>
        private Button cachedInsertParameterButton;
        
        /// <summary>
        /// Cache to hold a reference to InsertParameterButton2 of type Button
        /// </summary>
        private Button cachedInsertParameterButton2;
        
        /// <summary>
        /// Cache to hold a reference to HTTPHeaderValueTextBox of type TextBox
        /// </summary>
        private TextBox cachedHTTPHeaderValueTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPHeaderNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedHTTPHeaderNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPHeaderValueStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPHeaderValueStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HTTPHeaderNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPHeaderNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of HTTPHeaderPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public HTTPHeaderPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IHTTPHeaderPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IHTTPHeaderPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control HTTPHeaderValue
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HTTPHeaderValueText
        {
            get
            {
                return this.Controls.HTTPHeaderValueTextBox.Text;
            }
            
            set
            {
                this.Controls.HTTPHeaderValueTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control HTTPHeaderName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HTTPHeaderNameText
        {
            get
            {
                return this.Controls.HTTPHeaderNameTextBox.Text;
            }
            
            set
            {
                this.Controls.HTTPHeaderNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InsertParameterButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHTTPHeaderPropertiesDialogControls.InsertParameterButton
        {
            get
            {
                if ((this.cachedInsertParameterButton == null))
                {
                    this.cachedInsertParameterButton = new Button(this, HTTPHeaderPropertiesDialog.ControlIDs.InsertParameterButton);
                }
                
                return this.cachedInsertParameterButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InsertParameterButton2 control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHTTPHeaderPropertiesDialogControls.InsertParameterButton2
        {
            get
            {
                if ((this.cachedInsertParameterButton2 == null))
                {
                    this.cachedInsertParameterButton2 = new Button(this, HTTPHeaderPropertiesDialog.ControlIDs.InsertParameterButton2);
                }
                
                return this.cachedInsertParameterButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPHeaderValueTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IHTTPHeaderPropertiesDialogControls.HTTPHeaderValueTextBox
        {
            get
            {
                if ((this.cachedHTTPHeaderValueTextBox == null))
                {
                    this.cachedHTTPHeaderValueTextBox = new TextBox(this, HTTPHeaderPropertiesDialog.ControlIDs.HTTPHeaderValueTextBox);
                }
                
                return this.cachedHTTPHeaderValueTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPHeaderNameTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IHTTPHeaderPropertiesDialogControls.HTTPHeaderNameTextBox
        {
            get
            {
                if ((this.cachedHTTPHeaderNameTextBox == null))
                {
                    this.cachedHTTPHeaderNameTextBox = new TextBox(this, HTTPHeaderPropertiesDialog.ControlIDs.HTTPHeaderNameTextBox);
                }
                
                return this.cachedHTTPHeaderNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPHeaderValueStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHTTPHeaderPropertiesDialogControls.HTTPHeaderValueStaticControl
        {
            get
            {
                if ((this.cachedHTTPHeaderValueStaticControl == null))
                {
                    this.cachedHTTPHeaderValueStaticControl = new StaticControl(this, HTTPHeaderPropertiesDialog.ControlIDs.HTTPHeaderValueStaticControl);
                }
                
                return this.cachedHTTPHeaderValueStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPHeaderNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHTTPHeaderPropertiesDialogControls.HTTPHeaderNameStaticControl
        {
            get
            {
                if ((this.cachedHTTPHeaderNameStaticControl == null))
                {
                    this.cachedHTTPHeaderNameStaticControl = new StaticControl(this, HTTPHeaderPropertiesDialog.ControlIDs.HTTPHeaderNameStaticControl);
                }
                
                return this.cachedHTTPHeaderNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHTTPHeaderPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, HTTPHeaderPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHTTPHeaderPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, HTTPHeaderPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button InsertParameter
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInsertParameter()
        {
            this.Controls.InsertParameterButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button InsertParameter2
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInsertParameter2()
        {
            this.Controls.InsertParameterButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
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
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for HTTP Header Properties
            /// </summary>
            // HTTP Header Properties
            public const string ResourceDialogTitle = ";HTTP Header Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationR" +
                "esources;HeaderPropertiesEditTitle";
            
            /// <summary>
            /// Resource string for Insert parameter...
            /// </summary>
            // Ins&ert parameter...
            public const string InsertParameter = ";Ins&ert parameter...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.HeaderPropertiesF" +
                "orm;buttonValueParameter.Text";
            
            /// <summary>
            /// Resource string for Insert parameter...
            /// </summary>
            // In&sert parameter...
            public const string InsertParameter2 = ";In&sert parameter...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProperties" +
                "Form;buttonBodyParameter.Text";
            
            /// <summary>
            /// Resource string for HTTP Header value:
            /// </summary>
            // HTTP Header &value:
            public const string HTTPHeaderValue = ";HTTP Header &value:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.HeaderPropertiesFo" +
                "rm;labelValue.Text";
            
            /// <summary>
            /// Resource string for HTTP Header name:
            /// </summary>
            // HTTP Header &name:
            public const string HTTPHeaderName = ";HTTP Header &name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.HeaderPropertiesFor" +
                "m;labelName.Text";
            
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

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

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

            #endregion

        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for InsertParameterButton
            /// </summary>
            public const string InsertParameterButton = "buttonValueParameter";
            
            /// <summary>
            /// Control ID for InsertParameterButton2
            /// </summary>
            public const string InsertParameterButton2 = "buttonNameParameter";
            
            /// <summary>
            /// Control ID for HTTPHeaderValueTextBox
            /// </summary>
            public const string HTTPHeaderValueTextBox = "textBoxValue";
            
            /// <summary>
            /// Control ID for HTTPHeaderNameTextBox
            /// </summary>
            public const string HTTPHeaderNameTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for HTTPHeaderValueStaticControl
            /// </summary>
            public const string HTTPHeaderValueStaticControl = "labelValue";
            
            /// <summary>
            /// Control ID for HTTPHeaderNameStaticControl
            /// </summary>
            public const string HTTPHeaderNameStaticControl = "labelName";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
        }
        #endregion
    }
}
