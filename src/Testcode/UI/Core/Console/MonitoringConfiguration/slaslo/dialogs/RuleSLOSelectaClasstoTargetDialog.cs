// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RuleSLOSelectaClasstoTargetDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy Class that represents the Select Dialog to select the Rule
// </project>
// <summary>
// 	Proxy Class that represents the Select Dialog to select the Rule
// </summary>
// <history>
// 	[dialac] 9/18/2008 Created
//  [dialac] 10/02/2008 Changing resources string for Dialog TItle. 
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRuleSLOSelectaClasstoTargetDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRuleSLOSelectaClasstoTargetDialogControls, for RuleSLOSelectaClasstoTargetDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRuleSLOSelectaClasstoTargetDialogControls
    {
        /// <summary>
        /// Read-only property to access ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView
        /// </summary>
        ListView ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
        /// </summary>
        StaticControl TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _28TotalTargets28Visible0SelectedStaticControl
        /// </summary>
        StaticControl _28TotalTargets28Visible0SelectedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralTextBox
        /// </summary>
        TextBox GeneralTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
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
        /// Read-only property to access SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        /// </summary>
        StaticControl SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
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
    /// 	[dialac] 9/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RuleSLOSelectaClasstoTargetDialog : Dialog, IRuleSLOSelectaClasstoTargetDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView of type ListView
        /// </summary>
        private ListView cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView;
        
        /// <summary>
        /// Cache to hold a reference to TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin of type StaticControl
        /// </summary>
        private StaticControl cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to _28TotalTargets28Visible0SelectedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_28TotalTargets28Visible0SelectedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralTextBox of type TextBox
        /// </summary>
        private TextBox cachedGeneralTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RuleSLOSelectaClasstoTargetDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RuleSLOSelectaClasstoTargetDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRuleSLOSelectaClasstoTargetDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRuleSLOSelectaClasstoTargetDialogControls Controls
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
        ///  Routine to set/get the text in control General
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GeneralText
        {
            get
            {
                return this.Controls.GeneralTextBox.Text;
            }
            
            set
            {
                this.Controls.GeneralTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IRuleSLOSelectaClasstoTargetDialogControls.ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView
        {
            get
            {
                if ((this.cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView == null))
                {
                    this.cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView = new ListView(this, new QID(";[UIA]AutomationId ='" + RuleSLOSelectaClasstoTargetDialog.ControlIDs.ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView + "'"));
                }
                
                return this.cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRuleSLOSelectaClasstoTargetDialogControls.TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
        {
            get
            {
                if ((this.cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin == null))
                {
                    this.cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin = new StaticControl(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin);
                }
                
                return this.cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRuleSLOSelectaClasstoTargetDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.HelpButton);
                }
                
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRuleSLOSelectaClasstoTargetDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _28TotalTargets28Visible0SelectedStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRuleSLOSelectaClasstoTargetDialogControls._28TotalTargets28Visible0SelectedStaticControl
        {
            get
            {
                if ((this.cached_28TotalTargets28Visible0SelectedStaticControl == null))
                {
                    this.cached_28TotalTargets28Visible0SelectedStaticControl = new StaticControl(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs._28TotalTargets28Visible0SelectedStaticControl);
                }
                
                return this.cached_28TotalTargets28Visible0SelectedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRuleSLOSelectaClasstoTargetDialogControls.GeneralTextBox
        {
            get
            {
                if ((this.cachedGeneralTextBox == null))
                {
                    this.cachedGeneralTextBox = new TextBox(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.GeneralTextBox);
                }
                
                return this.cachedGeneralTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRuleSLOSelectaClasstoTargetDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.LookForStaticControl);
                }
                
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRuleSLOSelectaClasstoTargetDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRuleSLOSelectaClasstoTargetDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRuleSLOSelectaClasstoTargetDialogControls.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        {
            get
            {
                if ((this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                {
                    this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = new StaticControl(this, RuleSLOSelectaClasstoTargetDialog.ControlIDs.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                }
                
                return this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
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
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 9/18/2008 Created
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
        /// 	[dialac] 9/18/2008 Created
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
            private const string ResourceDialogTitle = @";Select a Rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageResources;RuleChooserTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin = @";Targeted class should a containment relationship to the service level target class in order for service level tracking to work. For more information see help.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SloTargetSubControl;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";&Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEd" +
                "itorForm;helpToolStripMenuItem.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";Cl&ear;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.AdvancedAlertSuppressionForm;cle" +
                "arBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _28TotalTargets28Visible0Selected
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_28TotalTargets28Visible0Selected = "28 total Targets, 28 visible, 0 selected";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";&Look for:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;look" +
                "ForLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = @";Select the target you want to use from the list below. You can also use the ""Look for:"" field below to filter down to a specific target or sort the targets by Management Pack.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;infoLabel.Text";
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
            /// Caches the translated resource string for:  TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _28TotalTargets28Visible0Selected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_28TotalTargets28Visible0Selected;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            
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
            /// Caches the translated resource string for:  SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
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
            /// Exposes access to the TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
            {
                get
                {
                    if ((cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin == null))
                    {
                        cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin = CoreManager.MomConsole.GetIntlStr(ResourceTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin);
                    }
                    
                    return cachedTargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Clear
            {
                get
                {
                    if ((cachedClear == null))
                    {
                        cachedClear = CoreManager.MomConsole.GetIntlStr(ResourceClear);
                    }
                    
                    return cachedClear;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _28TotalTargets28Visible0Selected translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _28TotalTargets28Visible0Selected
            {
                get
                {
                    if ((cached_28TotalTargets28Visible0Selected == null))
                    {
                        cached_28TotalTargets28Visible0Selected = CoreManager.MomConsole.GetIntlStr(Resource_28TotalTargets28Visible0Selected);
                    }
                    
                    return cached_28TotalTargets28Visible0Selected;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = CoreManager.MomConsole.GetIntlStr(ResourceLookFor);
                    }
                    
                    return cachedLookFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
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
            /// 	[dialac] 9/18/2008 Created
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
            /// Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            {
                get
                {
                    if ((cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                    {
                        cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                    }
                    
                    return cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
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
        /// 	[dialac] 9/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView
            /// </summary>
            public const string ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateListView = "typeListView";
            
            /// <summary>
            /// Control ID for TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin
            /// </summary>
            public const string TargetedClassShouldAContainmentRelationshipToTheServiceLevelTargetClassInOrderForServiceLevelTrackin = "label1";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "helpBtn";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearSearchButton";
            
            /// <summary>
            /// Control ID for _28TotalTargets28Visible0SelectedStaticControl
            /// </summary>
            public const string _28TotalTargets28Visible0SelectedStaticControl = "selectedItemsLabel";
            
            /// <summary>
            /// Control ID for GeneralTextBox
            /// </summary>
            public const string GeneralTextBox = "searchTextBox";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            public const string SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = "infoLabel";
        }
        #endregion
    }
}
