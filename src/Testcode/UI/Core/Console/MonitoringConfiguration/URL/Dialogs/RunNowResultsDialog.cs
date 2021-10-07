// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunNowResultsDialog.cs">
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
    
    #region Interface Definition - IRunNowResultsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunNowResultsDialogControls, for RunNowResultsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunNowResultsDialogControls
    {
        /// <summary>
        /// Read-only property to access TreeView
        /// </summary>
        TreeView TreeView
        {
            get;
        }
        
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
        /// Read-only property to access WebApplicationResponseDataStaticControl
        /// </summary>
        StaticControl WebApplicationResponseDataStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContentHashStaticControl
        /// </summary>
        StaticControl ContentHashStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MillisecondsStaticControl
        /// </summary>
        StaticControl MillisecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DNSResolutionTimeTextBox
        /// </summary>
        TextBox DNSResolutionTimeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DNSResolutionTimeStaticControl
        /// </summary>
        StaticControl DNSResolutionTimeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MillisecondsStaticControl2
        /// </summary>
        StaticControl MillisecondsStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TransactionResponseTimeTextBox
        /// </summary>
        TextBox TransactionResponseTimeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseTimeStaticControl
        /// </summary>
        StaticControl ResponseTimeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailsButton
        /// </summary>
        Button DetailsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RanSuccessfullyStaticControl
        /// </summary>
        StaticControl RanSuccessfullyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RanSuccessfullyTextBox
        /// </summary>
        TextBox RanSuccessfullyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusCodeStaticControl
        /// </summary>
        StaticControl StatusCodeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HttplocalhostStaticControl
        /// </summary>
        StaticControl HttplocalhostStaticControl
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
    public class RunNowResultsDialog : Dialog, IRunNowResultsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TreeView of type TreeView
        /// </summary>
        private TreeView cachedTreeView;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl1 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl1;
        
        /// <summary>
        /// Cache to hold a reference to WebApplicationResponseDataStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWebApplicationResponseDataStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TextBox2 of type TextBox
        /// </summary>
        private TextBox cachedTextBox2;
        
        /// <summary>
        /// Cache to hold a reference to ContentHashStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedContentHashStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MillisecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMillisecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DNSResolutionTimeTextBox of type TextBox
        /// </summary>
        private TextBox cachedDNSResolutionTimeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DNSResolutionTimeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDNSResolutionTimeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MillisecondsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedMillisecondsStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to TransactionResponseTimeTextBox of type TextBox
        /// </summary>
        private TextBox cachedTransactionResponseTimeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ResponseTimeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResponseTimeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DetailsButton of type Button
        /// </summary>
        private Button cachedDetailsButton;
        
        /// <summary>
        /// Cache to hold a reference to RanSuccessfullyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRanSuccessfullyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RanSuccessfullyTextBox of type TextBox
        /// </summary>
        private TextBox cachedRanSuccessfullyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to StatusCodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStatusCodeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HttplocalhostStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHttplocalhostStaticControl;
        
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
        /// Owner of RunNowResultsDialog of type ExtractionRuleFormDialog
        /// </param>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunNowResultsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRunNowResultsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunNowResultsDialogControls Controls
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
        ///  Routine to set/get the text in control TextBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox2Text
        {
            get
            {
                return this.Controls.TextBox2.Text;
            }
            
            set
            {
                this.Controls.TextBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DNSResolutionTime
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DNSResolutionTimeText
        {
            get
            {
                return this.Controls.DNSResolutionTimeTextBox.Text;
            }
            
            set
            {
                this.Controls.DNSResolutionTimeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TransactionResponseTime
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TransactionResponseTimeText
        {
            get
            {
                return this.Controls.TransactionResponseTimeTextBox.Text;
            }
            
            set
            {
                this.Controls.TransactionResponseTimeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RanSuccessfully
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RanSuccessfullyText
        {
            get
            {
                return this.Controls.RanSuccessfullyTextBox.Text;
            }
            
            set
            {
                this.Controls.RanSuccessfullyTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TreeView control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IRunNowResultsDialogControls.TreeView
        {
            get
            {
                if ((this.cachedTreeView == null))
                {
                    this.cachedTreeView = new TreeView(this, RunNowResultsDialog.ControlIDs.TreeView);
                }
                
                return this.cachedTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl1 control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.StaticControl1
        {
            get
            {
                if ((this.cachedStaticControl1 == null))
                {
                    this.cachedStaticControl1 = new StaticControl(this, RunNowResultsDialog.ControlIDs.StaticControl1);
                }
                
                return this.cachedStaticControl1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WebApplicationResponseDataStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.WebApplicationResponseDataStaticControl
        {
            get
            {
                if ((this.cachedWebApplicationResponseDataStaticControl == null))
                {
                    this.cachedWebApplicationResponseDataStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.WebApplicationResponseDataStaticControl);
                }
                
                return this.cachedWebApplicationResponseDataStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox2 control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunNowResultsDialogControls.TextBox2
        {
            get
            {
                if ((this.cachedTextBox2 == null))
                {
                    this.cachedTextBox2 = new TextBox(this, RunNowResultsDialog.ControlIDs.TextBox2);
                }
                
                return this.cachedTextBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContentHashStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.ContentHashStaticControl
        {
            get
            {
                if ((this.cachedContentHashStaticControl == null))
                {
                    this.cachedContentHashStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.ContentHashStaticControl);
                }
                
                return this.cachedContentHashStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MillisecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.MillisecondsStaticControl
        {
            get
            {
                if ((this.cachedMillisecondsStaticControl == null))
                {
                    this.cachedMillisecondsStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.MillisecondsStaticControl);
                }
                
                return this.cachedMillisecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DNSResolutionTimeTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunNowResultsDialogControls.DNSResolutionTimeTextBox
        {
            get
            {
                if ((this.cachedDNSResolutionTimeTextBox == null))
                {
                    this.cachedDNSResolutionTimeTextBox = new TextBox(this, RunNowResultsDialog.ControlIDs.DNSResolutionTimeTextBox);
                }
                
                return this.cachedDNSResolutionTimeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DNSResolutionTimeStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.DNSResolutionTimeStaticControl
        {
            get
            {
                if ((this.cachedDNSResolutionTimeStaticControl == null))
                {
                    this.cachedDNSResolutionTimeStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.DNSResolutionTimeStaticControl);
                }
                
                return this.cachedDNSResolutionTimeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MillisecondsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.MillisecondsStaticControl2
        {
            get
            {
                if ((this.cachedMillisecondsStaticControl2 == null))
                {
                    this.cachedMillisecondsStaticControl2 = new StaticControl(this, RunNowResultsDialog.ControlIDs.MillisecondsStaticControl2);
                }
                
                return this.cachedMillisecondsStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TransactionResponseTimeTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunNowResultsDialogControls.TransactionResponseTimeTextBox
        {
            get
            {
                if ((this.cachedTransactionResponseTimeTextBox == null))
                {
                    this.cachedTransactionResponseTimeTextBox = new TextBox(this, RunNowResultsDialog.ControlIDs.TransactionResponseTimeTextBox);
                }
                
                return this.cachedTransactionResponseTimeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseTimeStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.ResponseTimeStaticControl
        {
            get
            {
                if ((this.cachedResponseTimeStaticControl == null))
                {
                    this.cachedResponseTimeStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.ResponseTimeStaticControl);
                }
                
                return this.cachedResponseTimeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunNowResultsDialogControls.DetailsButton
        {
            get
            {
                if ((this.cachedDetailsButton == null))
                {
                    this.cachedDetailsButton = new Button(this, RunNowResultsDialog.ControlIDs.DetailsButton);
                }
                
                return this.cachedDetailsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RanSuccessfullyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.RanSuccessfullyStaticControl
        {
            get
            {
                if ((this.cachedRanSuccessfullyStaticControl == null))
                {
                    this.cachedRanSuccessfullyStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.RanSuccessfullyStaticControl);
                }
                
                return this.cachedRanSuccessfullyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RanSuccessfullyTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunNowResultsDialogControls.RanSuccessfullyTextBox
        {
            get
            {
                if ((this.cachedRanSuccessfullyTextBox == null))
                {
                    this.cachedRanSuccessfullyTextBox = new TextBox(this, RunNowResultsDialog.ControlIDs.RanSuccessfullyTextBox);
                }
                
                return this.cachedRanSuccessfullyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusCodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.StatusCodeStaticControl
        {
            get
            {
                if ((this.cachedStatusCodeStaticControl == null))
                {
                    this.cachedStatusCodeStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.StatusCodeStaticControl);
                }
                
                return this.cachedStatusCodeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HttplocalhostStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunNowResultsDialogControls.HttplocalhostStaticControl
        {
            get
            {
                if ((this.cachedHttplocalhostStaticControl == null))
                {
                    this.cachedHttplocalhostStaticControl = new StaticControl(this, RunNowResultsDialog.ControlIDs.HttplocalhostStaticControl);
                }
                
                return this.cachedHttplocalhostStaticControl;
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
        Button IRunNowResultsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RunNowResultsDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Details
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDetails()
        {
            this.Controls.DetailsButton.Click();
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

        #region TreeView Methods
        /// <summary>
        /// Select Node in TreeView on Run Now Results Dialog
        /// </summary>
        /// <param name="nodeName">Node Name</param>
        /// <param name="exactMatch">If the node name exact match</param>
        /// <history>
        ///    [v-kayu] 31DEC09 Created
        /// </history>
        public void SelectNode(string nodeName, bool exactMatch)
        {
            TreeNode selectedNode = null;

            Common.Utilities.LogMessage("RunNowResultsDialog.SelectNode:: " +
                "Looking for node whose name match: " + nodeName);

            string[] nodeNames = this.Controls.TreeView.GetAllNodesText();

            foreach (string item in nodeNames)
            {
                if (exactMatch)
                {
                    if (item.Equals(nodeName) == true)
                    {
                        Common.Utilities.LogMessage("RunNowResultsDialog.SelectNode := " +
                            item +
                            ".");
                        selectedNode = this.Controls.TreeView.Find(item);
                    }
                }
                else
                {
                    if (item.Contains(nodeName) == true)
                    {
                        Common.Utilities.LogMessage("RunNowResultsDialog.SelectNode := " +
                            item +
                            ".");
                        selectedNode = this.Controls.TreeView.Find(item) ;
                    }
                }
            }

            if (selectedNode == null)
            {
                throw new TreeNode.Exceptions.NodeNotFoundException(
                    "RunNowResultsDialog.SelectNode:: Failed to find node whose name match:= " +
                    nodeName);
            }
            else
            {
                Common.Utilities.LogMessage("RunNowResultsDialog.SelectNode:: SelectNode successfully.");
                this.Extended.SetFocus();
                selectedNode.Select();
                Common.Utilities.LogMessage("RunNowResultsDialog.SelectNode:: WaitForUIObjectReady");
                UISynchronization.WaitForUIObjectReady(this, Core.Common.Constants.OneSecond * 2);
            }
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ExtractionRuleFormDialog owning the dialog.</param>
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
            /// Resource string for Run Now Results
            /// </summary>
            // Run Now Results
            public const string ResourceDialogTitle = ";Run Now Results;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;$this" +
                ".Text";
            
            /// <summary>
            /// Resource string for Web Application Response Data
            /// </summary>
            // Web Application Response Data
            public const string WebApplicationResponseData = ";Web Application Response Data;ManagedString;Microsoft.EnterpriseManagement.UI.Au" +
                "thoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebAppli" +
                "cationResources;PaneTitleHeaderRunNowMonitoring";
            
            /// <summary>
            /// Resource string for Content Hash:
            /// </summary>
            // Content &Hash:
            public const string ContentHash = ";Content &Hash:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;labelB" +
                "PContentHash.Text";
            
            /// <summary>
            /// Resource string for Milliseconds
            /// </summary>
            // Milliseconds
            public const string Milliseconds = ";Milliseconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;labelDee" +
                "pCheckResponseTimeUnit.Text";
            
            /// <summary>
            /// Resource string for DNS Resolution Time:
            /// </summary>
            // &DNS Resolution Time:
            public const string DNSResolutionTime = ";&DNS Resolution Time:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm" +
                ";labelResourceDNSTime.Text";
            
            /// <summary>
            /// Resource string for Milliseconds
            /// </summary>
            // Milliseconds
            public const string Milliseconds2 = ";Milliseconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;labelDee" +
                "pCheckResponseTimeUnit.Text";
            
            /// <summary>
            /// Resource string for Response Time:
            /// </summary>
            // &Response Time:
            public const string ResponseTime = ";&Response Time:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorFo" +
                "rm;checkBoxErrorResponseTimeR.Text";
            
            /// <summary>
            /// Resource string for Details...
            /// </summary>
            // D&etails...
            public const string Details = ";D&etails...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;buttonBPD" +
                "etails.Text";
            
            /// <summary>
            /// Resource string for Ran successfully
            /// </summary>
            // Ran successfully
            public const string RanSuccessfully = ";Ran successfully;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResourc" +
                "es;StatusResultSuccessMask";
            
            /// <summary>
            /// Resource string for Status Code:
            /// </summary>
            // &Status Code:
            public const string StatusCode = ";&Status Code:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;labelDe" +
                "epCheckStatusCode.Text";
            
            /// <summary>
            /// Resource string for http://localhost
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string Httplocalhost = "http://localhost";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            // OK
            public const string OK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

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
            /// Control ID for TreeView
            /// </summary>
            public const string TreeView = "treeView";
            
            /// <summary>
            /// Control ID for StaticControl1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl1 = "rightLabel";
            
            /// <summary>
            /// Control ID for WebApplicationResponseDataStaticControl
            /// </summary>
            public const string WebApplicationResponseDataStaticControl = "leftLabel";
            
            /// <summary>
            /// Control ID for TextBox2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox2 = "textBoxBPContentHash";
            
            /// <summary>
            /// Control ID for ContentHashStaticControl
            /// </summary>
            public const string ContentHashStaticControl = "labelBPContentHash";
            
            /// <summary>
            /// Control ID for MillisecondsStaticControl
            /// </summary>
            public const string MillisecondsStaticControl = "labelBPDNSTimeUnit";
            
            /// <summary>
            /// Control ID for DNSResolutionTimeTextBox
            /// </summary>
            public const string DNSResolutionTimeTextBox = "textBoxBPDNSTime";
            
            /// <summary>
            /// Control ID for DNSResolutionTimeStaticControl
            /// </summary>
            public const string DNSResolutionTimeStaticControl = "labelBPDNSTime";
            
            /// <summary>
            /// Control ID for MillisecondsStaticControl2
            /// </summary>
            public const string MillisecondsStaticControl2 = "labelBPRTUnit";
            
            /// <summary>
            /// Control ID for TransactionResponseTimeTextBox
            /// </summary>
            public const string TransactionResponseTimeTextBox = "textBoxBPResponseTime";
            
            /// <summary>
            /// Control ID for ResponseTimeStaticControl
            /// </summary>
            public const string ResponseTimeStaticControl = "label1";
            
            /// <summary>
            /// Control ID for DetailsButton
            /// </summary>
            public const string DetailsButton = "buttonBPDetails";
            
            /// <summary>
            /// Control ID for RanSuccessfullyStaticControl
            /// </summary>
            public const string RanSuccessfullyStaticControl = "labelBPStatus";
            
            /// <summary>
            /// Control ID for RanSuccessfullyTextBox
            /// </summary>
            public const string RanSuccessfullyTextBox = "textBoxBPStatusCode";
            
            /// <summary>
            /// Control ID for StatusCodeStaticControl
            /// </summary>
            public const string StatusCodeStaticControl = "labelBPStatusCode";
            
            /// <summary>
            /// Control ID for HttplocalhostStaticControl
            /// </summary>
            public const string HttplocalhostStaticControl = "labelBPDetails";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
        }
        #endregion
    }
}
