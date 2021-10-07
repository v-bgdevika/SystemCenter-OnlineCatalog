// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestPropertiesDialogMonitoringTab.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Web Application Monitor Base Class.
// </summary>
// <history>
// 	[v-eryon] 8/12/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRequestPropertiesDialogMonitoringTabControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRequestPropertiesDialogMonitoringTabControls, for RequestPropertiesDialogMonitoringTab.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 8/12/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRequestPropertiesDialogMonitoringTabControls
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
        /// Read-only property to access Tab3TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab3TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl
        /// </summary>
        StaticControl ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseBodyCollectionComboBox
        /// </summary>
        ComboBox ResponseBodyCollectionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProcessResponseBodyCheckBox
        /// </summary>
        CheckBox ProcessResponseBodyCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectResourceHeadersCheckBox
        /// </summary>
        CheckBox CollectResourceHeadersCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectLinkHeadersCheckBox
        /// </summary>
        CheckBox CollectLinkHeadersCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectHeadersCheckBox
        /// </summary>
        CheckBox CollectHeadersCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdditionalCollectionStaticControl
        /// </summary>
        StaticControl AdditionalCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseBodyCollectionStaticControl
        /// </summary>
        StaticControl ResponseBodyCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContentHashCheckBox
        /// </summary>
        CheckBox ContentHashCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LevelsStaticControl
        /// </summary>
        StaticControl LevelsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkTraversalNumberOfClicksFromTheBasePageComboBox
        /// </summary>
        ComboBox LinkTraversalNumberOfClicksFromTheBasePageComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox
        /// </summary>
        CheckBox EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox
        /// </summary>
        CheckBox EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkTraversalNumberOfClicksFromTheBasePageStaticControl
        /// </summary>
        StaticControl LinkTraversalNumberOfClicksFromTheBasePageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox
        /// </summary>
        CheckBox EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorSSLHealthOnSecureSitesCheckBox
        /// </summary>
        CheckBox MonitorSSLHealthOnSecureSitesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureProcessingOfTheRequestResponseBodyStaticControl
        /// </summary>
        StaticControl ConfigureProcessingOfTheRequestResponseBodyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureTheFollowingMonitoringOptionsStaticControl
        /// </summary>
        StaticControl ConfigureTheFollowingMonitoringOptionsStaticControl
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
    /// 	[v-eryon] 8/12/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RequestPropertiesDialogMonitoringTab : Dialog, IRequestPropertiesDialogMonitoringTabControls
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
        /// Cache to hold a reference to Tab3TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab3TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResponseBodyCollectionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedResponseBodyCollectionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ProcessResponseBodyCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedProcessResponseBodyCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to CollectResourceHeadersCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCollectResourceHeadersCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to CollectLinkHeadersCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCollectLinkHeadersCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to CollectHeadersCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCollectHeadersCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to AdditionalCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdditionalCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResponseBodyCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResponseBodyCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ContentHashCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedContentHashCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to TextBox0 of type TextBox
        /// </summary>
        private TextBox cachedTextBox0;
        
        /// <summary>
        /// Cache to hold a reference to LevelsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLevelsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LinkTraversalNumberOfClicksFromTheBasePageComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedLinkTraversalNumberOfClicksFromTheBasePageComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to LinkTraversalNumberOfClicksFromTheBasePageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLinkTraversalNumberOfClicksFromTheBasePageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitorSSLHealthOnSecureSitesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMonitorSSLHealthOnSecureSitesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureProcessingOfTheRequestResponseBodyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureProcessingOfTheRequestResponseBodyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheFollowingMonitoringOptionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheFollowingMonitoringOptionsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RequestPropertiesDialogMonitoringTab of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RequestPropertiesDialogMonitoringTab(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRequestPropertiesDialogMonitoringTab Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRequestPropertiesDialogMonitoringTabControls Controls
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
        ///  Property to handle checkbox ProcessResponseBody
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ProcessResponseBody
        {
            get
            {
                return this.Controls.ProcessResponseBodyCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ProcessResponseBodyCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox CollectResourceHeaders
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool CollectResourceHeaders
        {
            get
            {
                return this.Controls.CollectResourceHeadersCheckBox.Checked;
            }
            
            set
            {
                this.Controls.CollectResourceHeadersCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox CollectLinkHeaders
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool CollectLinkHeaders
        {
            get
            {
                return this.Controls.CollectLinkHeadersCheckBox.Checked;
            }
            
            set
            {
                this.Controls.CollectLinkHeadersCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox CollectHeaders
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool CollectHeaders
        {
            get
            {
                return this.Controls.CollectHeadersCheckBox.Checked;
            }
            
            set
            {
                this.Controls.CollectHeadersCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ContentHash
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ContentHash
        {
            get
            {
                return this.Controls.ContentHashCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ContentHashCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox EnableHealthEvaluationAndPerformanceCollectionForExternalLinks
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnableHealthEvaluationAndPerformanceCollectionForExternalLinks
        {
            get
            {
                return this.Controls.EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox EnableHealthEvaluationAndPerformanceCollectionForInternalLinks
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnableHealthEvaluationAndPerformanceCollectionForInternalLinks
        {
            get
            {
                return this.Controls.EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox EnableHealthEvaluationAndPerformanceCollectionForResources
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnableHealthEvaluationAndPerformanceCollectionForResources
        {
            get
            {
                return this.Controls.EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MonitorSSLHealthOnSecureSites
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MonitorSSLHealthOnSecureSites
        {
            get
            {
                return this.Controls.MonitorSSLHealthOnSecureSitesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MonitorSSLHealthOnSecureSitesCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ResponseBodyCollection
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResponseBodyCollectionText
        {
            get
            {
                return this.Controls.ResponseBodyCollectionComboBox.Text;
            }
            
            set
            {
                this.Controls.ResponseBodyCollectionComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox0Text
        {
            get
            {
                return this.Controls.TextBox0.Text;
            }
            
            set
            {
                this.Controls.TextBox0.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LinkTraversalNumberOfClicksFromTheBasePage
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LinkTraversalNumberOfClicksFromTheBasePageText
        {
            get
            {
                return this.Controls.LinkTraversalNumberOfClicksFromTheBasePageComboBox.Text;
            }
            
            set
            {
                this.Controls.LinkTraversalNumberOfClicksFromTheBasePageComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogMonitoringTabControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogMonitoringTabControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RequestPropertiesDialogMonitoringTab.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogMonitoringTabControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RequestPropertiesDialogMonitoringTab.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab3TabControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRequestPropertiesDialogMonitoringTabControls.Tab3TabControl
        {
            get
            {
                if ((this.cachedTab3TabControl == null))
                {
                    this.cachedTab3TabControl = new TabControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.Tab3TabControl);
                }
                
                return this.cachedTab3TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl
        {
            get
            {
                if ((this.cachedProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl == null))
                {
                    this.cachedProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl);
                }
                
                return this.cachedProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseBodyCollectionComboBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRequestPropertiesDialogMonitoringTabControls.ResponseBodyCollectionComboBox
        {
            get
            {
                if ((this.cachedResponseBodyCollectionComboBox == null))
                {
                    this.cachedResponseBodyCollectionComboBox = new ComboBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ResponseBodyCollectionComboBox);
                }
                
                return this.cachedResponseBodyCollectionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessResponseBodyCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.ProcessResponseBodyCheckBox
        {
            get
            {
                if ((this.cachedProcessResponseBodyCheckBox == null))
                {
                    this.cachedProcessResponseBodyCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ProcessResponseBodyCheckBox);
                }
                
                return this.cachedProcessResponseBodyCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectResourceHeadersCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.CollectResourceHeadersCheckBox
        {
            get
            {
                if ((this.cachedCollectResourceHeadersCheckBox == null))
                {
                    this.cachedCollectResourceHeadersCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.CollectResourceHeadersCheckBox);
                }
                
                return this.cachedCollectResourceHeadersCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectLinkHeadersCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.CollectLinkHeadersCheckBox
        {
            get
            {
                if ((this.cachedCollectLinkHeadersCheckBox == null))
                {
                    this.cachedCollectLinkHeadersCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.CollectLinkHeadersCheckBox);
                }
                
                return this.cachedCollectLinkHeadersCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectHeadersCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.CollectHeadersCheckBox
        {
            get
            {
                if ((this.cachedCollectHeadersCheckBox == null))
                {
                    this.cachedCollectHeadersCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.CollectHeadersCheckBox);
                }
                
                return this.cachedCollectHeadersCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.AdditionalCollectionStaticControl
        {
            get
            {
                if ((this.cachedAdditionalCollectionStaticControl == null))
                {
                    this.cachedAdditionalCollectionStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.AdditionalCollectionStaticControl);
                }
                
                return this.cachedAdditionalCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseBodyCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.ResponseBodyCollectionStaticControl
        {
            get
            {
                if ((this.cachedResponseBodyCollectionStaticControl == null))
                {
                    this.cachedResponseBodyCollectionStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ResponseBodyCollectionStaticControl);
                }
                
                return this.cachedResponseBodyCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContentHashCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.ContentHashCheckBox
        {
            get
            {
                if ((this.cachedContentHashCheckBox == null))
                {
                    this.cachedContentHashCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ContentHashCheckBox);
                }
                
                return this.cachedContentHashCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox0 control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestPropertiesDialogMonitoringTabControls.TextBox0
        {
            get
            {
                if ((this.cachedTextBox0 == null))
                {
                    this.cachedTextBox0 = new TextBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.TextBox0);
                }
                
                return this.cachedTextBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LevelsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.LevelsStaticControl
        {
            get
            {
                if ((this.cachedLevelsStaticControl == null))
                {
                    this.cachedLevelsStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.LevelsStaticControl);
                }
                
                return this.cachedLevelsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkTraversalNumberOfClicksFromTheBasePageComboBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRequestPropertiesDialogMonitoringTabControls.LinkTraversalNumberOfClicksFromTheBasePageComboBox
        {
            get
            {
                if ((this.cachedLinkTraversalNumberOfClicksFromTheBasePageComboBox == null))
                {
                    this.cachedLinkTraversalNumberOfClicksFromTheBasePageComboBox = new ComboBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.LinkTraversalNumberOfClicksFromTheBasePageComboBox);
                }
                
                return this.cachedLinkTraversalNumberOfClicksFromTheBasePageComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox
        {
            get
            {
                if ((this.cachedEnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox == null))
                {
                    this.cachedEnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox);
                }
                
                return this.cachedEnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox
        {
            get
            {
                if ((this.cachedEnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox == null))
                {
                    this.cachedEnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox);
                }
                
                return this.cachedEnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkTraversalNumberOfClicksFromTheBasePageStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.LinkTraversalNumberOfClicksFromTheBasePageStaticControl
        {
            get
            {
                if ((this.cachedLinkTraversalNumberOfClicksFromTheBasePageStaticControl == null))
                {
                    this.cachedLinkTraversalNumberOfClicksFromTheBasePageStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.LinkTraversalNumberOfClicksFromTheBasePageStaticControl);
                }
                
                return this.cachedLinkTraversalNumberOfClicksFromTheBasePageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox
        {
            get
            {
                if ((this.cachedEnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox == null))
                {
                    this.cachedEnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox);
                }
                
                return this.cachedEnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorSSLHealthOnSecureSitesCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRequestPropertiesDialogMonitoringTabControls.MonitorSSLHealthOnSecureSitesCheckBox
        {
            get
            {
                if ((this.cachedMonitorSSLHealthOnSecureSitesCheckBox == null))
                {
                    this.cachedMonitorSSLHealthOnSecureSitesCheckBox = new CheckBox(this, RequestPropertiesDialogMonitoringTab.ControlIDs.MonitorSSLHealthOnSecureSitesCheckBox);
                }
                
                return this.cachedMonitorSSLHealthOnSecureSitesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureProcessingOfTheRequestResponseBodyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.ConfigureProcessingOfTheRequestResponseBodyStaticControl
        {
            get
            {
                if ((this.cachedConfigureProcessingOfTheRequestResponseBodyStaticControl == null))
                {
                    this.cachedConfigureProcessingOfTheRequestResponseBodyStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ConfigureProcessingOfTheRequestResponseBodyStaticControl);
                }
                
                return this.cachedConfigureProcessingOfTheRequestResponseBodyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheFollowingMonitoringOptionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogMonitoringTabControls.ConfigureTheFollowingMonitoringOptionsStaticControl
        {
            get
            {
                if ((this.cachedConfigureTheFollowingMonitoringOptionsStaticControl == null))
                {
                    this.cachedConfigureTheFollowingMonitoringOptionsStaticControl = new StaticControl(this, RequestPropertiesDialogMonitoringTab.ControlIDs.ConfigureTheFollowingMonitoringOptionsStaticControl);
                }
                
                return this.cachedConfigureTheFollowingMonitoringOptionsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
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
        /// 	[v-eryon] 8/12/2009 Created
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
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ProcessResponseBody
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickProcessResponseBody()
        {
            this.Controls.ProcessResponseBodyCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CollectResourceHeaders
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCollectResourceHeaders()
        {
            this.Controls.CollectResourceHeadersCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CollectLinkHeaders
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCollectLinkHeaders()
        {
            this.Controls.CollectLinkHeadersCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CollectHeaders
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCollectHeaders()
        {
            this.Controls.CollectHeadersCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ContentHash
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickContentHash()
        {
            this.Controls.ContentHashCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EnableHealthEvaluationAndPerformanceCollectionForExternalLinks
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnableHealthEvaluationAndPerformanceCollectionForExternalLinks()
        {
            this.Controls.EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EnableHealthEvaluationAndPerformanceCollectionForInternalLinks
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnableHealthEvaluationAndPerformanceCollectionForInternalLinks()
        {
            this.Controls.EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EnableHealthEvaluationAndPerformanceCollectionForResources
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnableHealthEvaluationAndPerformanceCollectionForResources()
        {
            this.Controls.EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MonitorSSLHealthOnSecureSites
        /// </summary>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMonitorSSLHealthOnSecureSites()
        {
            this.Controls.MonitorSSLHealthOnSecureSitesCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[v-eryon] 8/12/2009 Created
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
                    catch (Exceptions.WindowNotFoundException)
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
        /// 	[v-eryon] 8/12/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Request Properties
            /// </summary>
            // Request Properties
            public const string ResourceDialogTitle = ";Request Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResou" +
                "rces;RequestPropertiesEditTitle";
            
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
            /// Resource string for Tab3
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string Tab3 = "Tab3";
            
            /// <summary>
            /// Resource string for Processing the request body is required for content match and parameter extraction
            /// </summary>
            // Processing the request body is required for content match and parameter extraction
            public const string ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtraction = @";Processing the request body is required for content match and parameter extraction;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;labelProcessResponseWarning.Text";
            
            /// <summary>
            /// Resource string for Process response body
            /// </summary>
            // &Process response body
            public const string ProcessResponseBody = ";&Process response body;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProperti" +
                "esForm;checkBoxProcessResponse.Text";
            
            /// <summary>
            /// Resource string for Collect resource headers
            /// </summary>
            // Collect reso&urce headers
            public const string CollectResourceHeaders = ";Collect reso&urce headers;ManagedString;Microsoft.EnterpriseManagement.UI.Author" +
                "ing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPrope" +
                "rtiesForm;checkBoxCollectResourceHeader.Text";
            
            /// <summary>
            /// Resource string for Collect link headers
            /// </summary>
            // Collect lin&k headers
            public const string CollectLinkHeaders = ";Collect lin&k headers;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertie" +
                "sForm;checkBoxCollectLinkHeader.Text";
            
            /// <summary>
            /// Resource string for Collect headers
            /// </summary>
            // Collect &headers
            public const string CollectHeaders = ";Collect &headers;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm" +
                ";checkBoxCollectHeader.Text";
            
            /// <summary>
            /// Resource string for Additional collection:
            /// </summary>
            // Additional collection:
            public const string AdditionalCollection = ";Additional collection:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProperti" +
                "esForm;labelAdditionalCollection.Text";
            
            /// <summary>
            /// Resource string for Response body collection:
            /// </summary>
            // Response &body collection:
            public const string ResponseBodyCollection = ";Response &body collection:;ManagedString;Microsoft.EnterpriseManagement.UI.Autho" +
                "ring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProp" +
                "ertiesForm;labelBodyCollection.Text";
            
            /// <summary>
            /// Resource string for Content Hash:
            /// </summary>
            // Con&tent Hash:
            public const string ContentHash = ";Con&tent Hash:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;c" +
                "heckBoxContentHash.Text";
            
            /// <summary>
            /// Resource string for levels
            /// </summary>
            // levels
            public const string Levels = ";levels;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;labelLeve" +
                "ls.Text";
            
            /// <summary>
            /// Resource string for Enable health evaluation and performance collection for External links
            /// </summary>
            // Enable health evaluation and performance collection for &External links
            public const string EnableHealthEvaluationAndPerformanceCollectionForExternalLinks = ";Enable health evaluation and performance collection for &External links;ManagedS" +
                "tring;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.WebApp.RequestPropertiesForm;checkBoxExternalLinks.Te" +
                "xt";
            
            /// <summary>
            /// Resource string for Enable health evaluation and performance collection for Internal links
            /// </summary>
            // Enable health evaluation and performance collection for &Internal links
            public const string EnableHealthEvaluationAndPerformanceCollectionForInternalLinks = ";Enable health evaluation and performance collection for &Internal links;ManagedS" +
                "tring;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.WebApp.RequestPropertiesForm;checkBoxInternalLinks.Te" +
                "xt";
            
            /// <summary>
            /// Resource string for Link traversal (number of clicks from the base page):
            /// </summary>
            // Link tra&versal (number of clicks from the base page):
            public const string LinkTraversalNumberOfClicksFromTheBasePage = ";Link tra&versal (number of clicks from the base page):;ManagedString;Microsoft.E" +
                "nterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." +
                "Authoring.WebApp.RequestPropertiesForm;labelDepth.Text";
            
            /// <summary>
            /// Resource string for Enable health evaluation and performance collection for Resources
            /// </summary>
            // Enable health evaluation and performance collection for &Resources
            public const string EnableHealthEvaluationAndPerformanceCollectionForResources = ";Enable health evaluation and performance collection for &Resources;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.WebApp.RequestPropertiesForm;checkBoxResources.Text";
            
            /// <summary>
            /// Resource string for Monitor SSL health on secure sites
            /// </summary>
            // Monitor &SSL health on secure sites
            public const string MonitorSSLHealthOnSecureSites = ";Monitor &SSL health on secure sites;ManagedString;Microsoft.EnterpriseManagement" +
                ".UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.Re" +
                "questPropertiesForm;checkBoxMonitorSSL.Text";
            
            /// <summary>
            /// Resource string for Configure processing of the request response body
            /// </summary>
            // Configure processing of the request response body
            public const string ConfigureProcessingOfTheRequestResponseBody = ";Configure processing of the request response body;ManagedString;Microsoft.Enterp" +
                "riseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Autho" +
                "ring.WebApp.RequestPropertiesForm;pageSectionLabel.Text";
            
            /// <summary>
            /// Resource string for Configure the following monitoring options
            /// </summary>
            // Configure the following monitoring options
            public const string ConfigureTheFollowingMonitoringOptions = ";Configure the following monitoring options;ManagedString;Microsoft.EnterpriseMan" +
                "agement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.We" +
                "bApp.RequestPropertiesForm;pageSectionLabelDetails.Text";

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
        /// 	[v-eryon] 8/12/2009 Created
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
            /// Control ID for Tab3TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab3TabControl = "tabControl";
            
            /// <summary>
            /// Control ID for ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl
            /// </summary>
            public const string ProcessingTheRequestBodyIsRequiredForContentMatchAndParameterExtractionStaticControl = "labelProcessResponseWarning";
            
            /// <summary>
            /// Control ID for ResponseBodyCollectionComboBox
            /// </summary>
            public const string ResponseBodyCollectionComboBox = "comboBoxBodyCollection";
            
            /// <summary>
            /// Control ID for ProcessResponseBodyCheckBox
            /// </summary>
            public const string ProcessResponseBodyCheckBox = "checkBoxProcessResponse";
            
            /// <summary>
            /// Control ID for CollectResourceHeadersCheckBox
            /// </summary>
            public const string CollectResourceHeadersCheckBox = "checkBoxCollectResourceHeader";
            
            /// <summary>
            /// Control ID for CollectLinkHeadersCheckBox
            /// </summary>
            public const string CollectLinkHeadersCheckBox = "checkBoxCollectLinkHeader";
            
            /// <summary>
            /// Control ID for CollectHeadersCheckBox
            /// </summary>
            public const string CollectHeadersCheckBox = "checkBoxCollectHeader";
            
            /// <summary>
            /// Control ID for AdditionalCollectionStaticControl
            /// </summary>
            public const string AdditionalCollectionStaticControl = "labelAdditionalCollection";
            
            /// <summary>
            /// Control ID for ResponseBodyCollectionStaticControl
            /// </summary>
            public const string ResponseBodyCollectionStaticControl = "labelBodyCollection";
            
            /// <summary>
            /// Control ID for ContentHashCheckBox
            /// </summary>
            public const string ContentHashCheckBox = "checkBoxContentHash";
            
            /// <summary>
            /// Control ID for TextBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox0 = "textBoxContentHash";
            
            /// <summary>
            /// Control ID for LevelsStaticControl
            /// </summary>
            public const string LevelsStaticControl = "labelLevels";
            
            /// <summary>
            /// Control ID for LinkTraversalNumberOfClicksFromTheBasePageComboBox
            /// </summary>
            public const string LinkTraversalNumberOfClicksFromTheBasePageComboBox = "numericUpDownDepth";
            
            /// <summary>
            /// Control ID for EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox
            /// </summary>
            public const string EnableHealthEvaluationAndPerformanceCollectionForExternalLinksCheckBox = "checkBoxExternalLinks";
            
            /// <summary>
            /// Control ID for EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox
            /// </summary>
            public const string EnableHealthEvaluationAndPerformanceCollectionForInternalLinksCheckBox = "checkBoxInternalLinks";
            
            /// <summary>
            /// Control ID for LinkTraversalNumberOfClicksFromTheBasePageStaticControl
            /// </summary>
            public const string LinkTraversalNumberOfClicksFromTheBasePageStaticControl = "labelDepth";
            
            /// <summary>
            /// Control ID for EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox
            /// </summary>
            public const string EnableHealthEvaluationAndPerformanceCollectionForResourcesCheckBox = "checkBoxResources";
            
            /// <summary>
            /// Control ID for MonitorSSLHealthOnSecureSitesCheckBox
            /// </summary>
            public const string MonitorSSLHealthOnSecureSitesCheckBox = "checkBoxMonitorSSL";
            
            /// <summary>
            /// Control ID for ConfigureProcessingOfTheRequestResponseBodyStaticControl
            /// </summary>
            public const string ConfigureProcessingOfTheRequestResponseBodyStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for ConfigureTheFollowingMonitoringOptionsStaticControl
            /// </summary>
            public const string ConfigureTheFollowingMonitoringOptionsStaticControl = "pageSectionLabelDetails";
        }
        #endregion
    }
}
