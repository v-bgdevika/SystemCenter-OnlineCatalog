// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestPropertiesDialogExtraRuleTab.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-eryon] 7/29/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IRequestPropertiesDialogExtraRuleTabControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRequestPropertiesDialogExtraRuleTabControls, for RequestPropertiesDialogExtraRuleTab.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/29/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRequestPropertiesDialogExtraRuleTabControls
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
        /// Read-only property to access Tab6TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab6TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView
        /// </summary>
        PropertyGridView ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DeleteButton
        /// </summary>
        Button DeleteButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditButton
        /// </summary>
        Button EditButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureExtractionRulesStaticControl
        /// </summary>
        StaticControl ConfigureExtractionRulesStaticControl
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
    /// 	[v-eryon] 7/29/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RequestPropertiesDialogExtraRuleTab : Dialog, IRequestPropertiesDialogExtraRuleTabControls
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
        /// Cache to hold a reference to Tab6TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab6TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to DeleteButton of type Button
        /// </summary>
        private Button cachedDeleteButton;
        
        /// <summary>
        /// Cache to hold a reference to EditButton of type Button
        /// </summary>
        private Button cachedEditButton;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureExtractionRulesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureExtractionRulesStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RequestPropertiesDialogExtraRuleTab of type ExtractionRuleFormDialog
        /// </param>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RequestPropertiesDialogExtraRuleTab(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRequestPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRequestPropertiesDialogExtraRuleTabControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogExtraRuleTabControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogExtraRuleTabControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogExtraRuleTabControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab6TabControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRequestPropertiesDialogExtraRuleTabControls.Tab6TabControl
        {
            get
            {
                if ((this.cachedTab6TabControl == null))
                {
                    this.cachedTab6TabControl = new TabControl(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.Tab6TabControl);
                }
                
                return this.cachedTab6TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IRequestPropertiesDialogExtraRuleTabControls.ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView
        {
            get
            {
                if ((this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView == null))
                {
                    this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView = new PropertyGridView(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView);
                }
                
                return this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeleteButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogExtraRuleTabControls.DeleteButton
        {
            get
            {
                if ((this.cachedDeleteButton == null))
                {
                    this.cachedDeleteButton = new Button(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.DeleteButton);
                }
                
                return this.cachedDeleteButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogExtraRuleTabControls.EditButton
        {
            get
            {
                if ((this.cachedEditButton == null))
                {
                    this.cachedEditButton = new Button(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.EditButton);
                }
                
                return this.cachedEditButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestPropertiesDialogExtraRuleTabControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureExtractionRulesStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestPropertiesDialogExtraRuleTabControls.ConfigureExtractionRulesStaticControl
        {
            get
            {
                if ((this.cachedConfigureExtractionRulesStaticControl == null))
                {
                    this.cachedConfigureExtractionRulesStaticControl = new StaticControl(this, RequestPropertiesDialogExtraRuleTab.ControlIDs.ConfigureExtractionRulesStaticControl);
                }
                
                return this.cachedConfigureExtractionRulesStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
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
        /// 	[v-eryon] 7/29/2009 Created
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
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Delete
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDelete()
        {
            this.Controls.DeleteButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.EditButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ExtractionRuleFormDialog owning the dialog.</param>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
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
        /// 	[v-eryon] 7/29/2009 Created
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
            /// Resource string for Tab6
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string Tab6 = "Tab6";
            
            /// <summary>
            /// Resource string for Delete
            /// </summary>
            // Dele&te
            public const string Delete = ";Dele&te;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Controls.FormulaBuilder.FormulaGridRe" +
                "sources;MenuDelete";
            
            /// <summary>
            /// Resource string for Edit...
            /// </summary>
            // &Edit...
            public const string Edit = ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Grooming" +
                ";buttonEditGrooming.Text";
            
            /// <summary>
            /// Resource string for Add...
            /// </summary>
            // A&dd...
            public const string Add = ";A&dd...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfi" +
                "leAssociationsPage;addButton.Text";
            
            /// <summary>
            /// Resource string for Configure extraction rules
            /// </summary>
            // Configure extraction rules
            public const string ConfigureExtractionRules = ";Configure extraction rules;ManagedString;Microsoft.EnterpriseManagement.UI.Autho" +
                "ring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestProp" +
                "ertiesForm;extractionRuleTitle.Text";

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
        /// 	[v-eryon] 7/29/2009 Created
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
            /// Control ID for Tab6TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab6TabControl = "tabControl";
            
            /// <summary>
            /// Control ID for ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView
            /// </summary>
            public const string ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedPropertyGridView = "extractionRuleGridView";
            
            /// <summary>
            /// Control ID for DeleteButton
            /// </summary>
            public const string DeleteButton = "extractionRuleDeleteButton";
            
            /// <summary>
            /// Control ID for EditButton
            /// </summary>
            public const string EditButton = "extractionRuleEditButton";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "extractionRuleAddButton";
            
            /// <summary>
            /// Control ID for ConfigureExtractionRulesStaticControl
            /// </summary>
            public const string ConfigureExtractionRulesStaticControl = "extractionRuleTitle";
        }
        #endregion
    }
}
