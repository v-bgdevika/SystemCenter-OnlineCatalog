// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BuildConnectionStringDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 8/5/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.OleDb.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IBuildConnectionStringDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBuildConnectionStringDialogControls, for BuildConnectionStringDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 8/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBuildConnectionStringDialogControls
    {
        /// <summary>
        /// Read-only property to access StaticControl1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl1
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox
        /// </summary>
        CheckBox UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProviderComboBox
        /// </summary>
        ComboBox ProviderComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProviderStaticControl
        /// </summary>
        StaticControl ProviderStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameTextBox
        /// </summary>
        TextBox IPAddressOrDeviceNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameStaticControl
        /// </summary>
        StaticControl IPAddressOrDeviceNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataBaseTextBox
        /// </summary>
        TextBox DataBaseTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DatabaseStaticControl
        /// </summary>
        StaticControl DatabaseStaticControl
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
    /// 	[dialac] 8/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BuildConnectionStringDialog : Dialog, IBuildConnectionStringDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to StaticControl1 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl1;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ProviderComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedProviderComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ProviderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProviderStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedIPAddressOrDeviceNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIPAddressOrDeviceNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DataBaseTextBox of type TextBox
        /// </summary>
        private TextBox cachedDataBaseTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DatabaseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDatabaseStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of BuildConnectionStringDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public BuildConnectionStringDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IBuildConnectionStringDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBuildConnectionStringDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction
        {
            get
            {
                return this.Controls.UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Summary
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProviderText
        {
            get
            {
                return this.Controls.ProviderComboBox.Text;
            }
            
            set
            {
                this.Controls.ProviderComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IPAddressOrDeviceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IPAddressOrDeviceNameText
        {
            get
            {
                return this.Controls.IPAddressOrDeviceNameTextBox.Text;
            }
            
            set
            {
                this.Controls.IPAddressOrDeviceNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control QueryExecutionTimeoutInSeconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DataBaseText
        {
            get
            {
                return this.Controls.DataBaseTextBox.Text;
            }
            
            set
            {
                this.Controls.DataBaseTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl1 control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildConnectionStringDialogControls.StaticControl1
        {
            get
            {
                if ((this.cachedStaticControl1 == null))
                {
                    this.cachedStaticControl1 = new StaticControl(this, BuildConnectionStringDialog.ControlIDs.StaticControl1);
                }
                
                return this.cachedStaticControl1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildConnectionStringDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, BuildConnectionStringDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBuildConnectionStringDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, BuildConnectionStringDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IBuildConnectionStringDialogControls.UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox
        {
            get
            {
                if ((this.cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox == null))
                {
                    this.cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox = new CheckBox(this, BuildConnectionStringDialog.ControlIDs.UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox);
                }
                
                return this.cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProviderComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IBuildConnectionStringDialogControls.ProviderComboBox
        {
            get
            {
                if ((this.cachedProviderComboBox == null))
                {
                    this.cachedProviderComboBox = new ComboBox(this, BuildConnectionStringDialog.ControlIDs.ProviderComboBox);
                }
                
                return this.cachedProviderComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProviderStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildConnectionStringDialogControls.ProviderStaticControl
        {
            get
            {
                if ((this.cachedProviderStaticControl == null))
                {
                    this.cachedProviderStaticControl = new StaticControl(this, BuildConnectionStringDialog.ControlIDs.ProviderStaticControl);
                }
                
                return this.cachedProviderStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IBuildConnectionStringDialogControls.IPAddressOrDeviceNameTextBox
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameTextBox == null))
                {
                    this.cachedIPAddressOrDeviceNameTextBox = new TextBox(this, BuildConnectionStringDialog.ControlIDs.IPAddressOrDeviceNameTextBox);
                }
                
                return this.cachedIPAddressOrDeviceNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildConnectionStringDialogControls.IPAddressOrDeviceNameStaticControl
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameStaticControl == null))
                {
                    this.cachedIPAddressOrDeviceNameStaticControl = new StaticControl(this, BuildConnectionStringDialog.ControlIDs.IPAddressOrDeviceNameStaticControl);
                }
                
                return this.cachedIPAddressOrDeviceNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataBaseTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IBuildConnectionStringDialogControls.DataBaseTextBox
        {
            get
            {
                if ((this.cachedDataBaseTextBox == null))
                {
                    this.cachedDataBaseTextBox = new TextBox(this, BuildConnectionStringDialog.ControlIDs.DataBaseTextBox);
                }
                
                return this.cachedDataBaseTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DatabaseStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildConnectionStringDialogControls.DatabaseStaticControl
        {
            get
            {
                if ((this.cachedDatabaseStaticControl == null))
                {
                    this.cachedDatabaseStaticControl = new StaticControl(this, BuildConnectionStringDialog.ControlIDs.DatabaseStaticControl);
                }
                
                return this.cachedDatabaseStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction()
        {
            this.Controls.UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {

            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

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
            //// First check if the dialog is already up.
            //Window tempWindow = null;
            //try
            //{
            //    // Try to locate an existing instance of a dialog
            //    tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            //}
            //catch (Exceptions.WindowNotFoundException windowNotFound)
            //{
            //    // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
            //    // 
            //    // app.DTE.ExecuteCmd(Commands.COMMAND_NAME_HERE);
            //    // 
            //    // tempWindow = new Window(Strings.DialogTitle, Utilities.StringMatchSyntax.ExactMatch, strDialogClass, Utilities.StringMatchSyntax.ExactMatch, app.MainWindow, timeOut);
            //    // if (tempWindow != null)
            //    //     return tempWindow;
            //    // 
            //    // throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + ".");
            //    // 
            //}
            
            //return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
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
            //private const string ResourceDialogTitle = "Build Connection String";
            private const string ResourceDialogTitle = @";Build Connection String;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;$this.Text";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction = @";Use Simple Authentication RunAs Profile created for this OLEDB data source transaction;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;runAsProfileChkBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Provider
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProvider = ";P&rovider:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;lblP" +
                "rovider.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIPAddressOrDeviceName = ";&IP address or device name:;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServerNameA" +
                "ndPortPage;labelIPAddress.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Database
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDatabase = ";&Database:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;lblD" +
                "atabase.Text";
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
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Provider
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProvider;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIPAddressOrDeviceName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Database
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDatabase;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction
            {
                get
                {
                    if ((cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction == null))
                    {
                        cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction = CoreManager.MomConsole.GetIntlStr(ResourceUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction);
                    }
                    
                    return cachedUseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransaction;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Provider translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Provider
            {
                get
                {
                    if ((cachedProvider == null))
                    {
                        cachedProvider = CoreManager.MomConsole.GetIntlStr(ResourceProvider);
                    }
                    
                    return cachedProvider;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IPAddressOrDeviceName translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IPAddressOrDeviceName
            {
                get
                {
                    if ((cachedIPAddressOrDeviceName == null))
                    {
                        cachedIPAddressOrDeviceName = CoreManager.MomConsole.GetIntlStr(ResourceIPAddressOrDeviceName);
                    }
                    
                    return cachedIPAddressOrDeviceName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Database translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Database
            {
                get
                {
                    if ((cachedDatabase == null))
                    {
                        cachedDatabase = CoreManager.MomConsole.GetIntlStr(ResourceDatabase);
                    }
                    
                    return cachedDatabase;
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
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for StaticControl1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl1 = "controlSectionLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox
            /// </summary>
            public const string UseSimpleAuthenticationRunAsProfileCreatedForThisOLEDBDataSourceTransactionCheckBox = "runAsProfileChkBox";
            
            /// <summary>
            /// Control ID for ProviderComboBox
            /// </summary>
            public const string ProviderComboBox = "comboBoxProvider";
            
            /// <summary>
            /// Control ID for ProviderStaticControl
            /// </summary>
            public const string ProviderStaticControl = "lblProvider";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameTextBox
            /// </summary>
            public const string IPAddressOrDeviceNameTextBox = "textBoxServerName";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameStaticControl
            /// </summary>
            public const string IPAddressOrDeviceNameStaticControl = "lblIPAddress";
            
            /// <summary>
            /// Control ID for DataBaseTextBox
            /// </summary>
            public const string DataBaseTextBox = "textBoxDatabase";
            
            /// <summary>
            /// Control ID for DatabaseStaticControl
            /// </summary>
            public const string DatabaseStaticControl = "lblDatabase";
        }
        #endregion
    }
}
