// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OverridesSummaryViewPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[nathd] 9/13/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IOverridesSummaryViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOverridesSummaryViewPropertiesDialogControls, for OverridesSummaryViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 9/13/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOverridesSummaryViewPropertiesDialogControls
    {
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
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
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
        /// Read-only property to access SelectConditionsStaticControl
        /// </summary>
        StaticControl SelectConditionsStaticControl
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
        /// Read-only property to access Ellipsis0Button
        /// </summary>
        Button Ellipsis0Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis1Button
        /// </summary>
        Button Ellipsis1Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllStaticControl
        /// </summary>
        StaticControl AllStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EntityStaticControl
        /// </summary>
        StaticControl EntityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectConditionsListBox
        /// </summary>
        ListBox SelectConditionsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// </summary>
        StaticControl CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewOverridesStaticControl
        /// </summary>
        StaticControl ViewOverridesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowDataContainedInASpecificGroupStaticControl
        /// </summary>
        StaticControl ShowDataContainedInASpecificGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowDataRelatedToStaticControl
        /// </summary>
        StaticControl ShowDataRelatedToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
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
    /// 	[nathd] 9/13/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OverridesSummaryViewPropertiesDialog : Dialog, IOverridesSummaryViewPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectConditionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectConditionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis1Button of type Button
        /// </summary>
        private Button cachedEllipsis1Button;
        
        /// <summary>
        /// Cache to hold a reference to AllStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAllStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EntityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEntityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectConditionsListBox of type ListBox
        /// </summary>
        private ListBox cachedSelectConditionsListBox;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ViewOverridesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewOverridesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataContainedInASpecificGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowDataRelatedToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataRelatedToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OverridesSummaryViewPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OverridesSummaryViewPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IOverridesSummaryViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOverridesSummaryViewPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridesSummaryViewPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, OverridesSummaryViewPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridesSummaryViewPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OverridesSummaryViewPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IOverridesSummaryViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, OverridesSummaryViewPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IOverridesSummaryViewPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, OverridesSummaryViewPropertiesDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IOverridesSummaryViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectConditionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.SelectConditionsStaticControl
        {
            get
            {
                if ((this.cachedSelectConditionsStaticControl == null))
                {
                    this.cachedSelectConditionsStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.SelectConditionsStaticControl);
                }
                
                return this.cachedSelectConditionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridesSummaryViewPropertiesDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, OverridesSummaryViewPropertiesDialog.ControlIDs.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridesSummaryViewPropertiesDialogControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, OverridesSummaryViewPropertiesDialog.ControlIDs.Ellipsis0Button);
                }
                
                return this.cachedEllipsis0Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis1Button control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridesSummaryViewPropertiesDialogControls.Ellipsis1Button
        {
            get
            {
                if ((this.cachedEllipsis1Button == null))
                {
                    this.cachedEllipsis1Button = new Button(this, OverridesSummaryViewPropertiesDialog.ControlIDs.Ellipsis1Button);
                }
                
                return this.cachedEllipsis1Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.AllStaticControl
        {
            get
            {
                if ((this.cachedAllStaticControl == null))
                {
                    this.cachedAllStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.AllStaticControl);
                }
                
                return this.cachedAllStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EntityStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.EntityStaticControl
        {
            get
            {
                if ((this.cachedEntityStaticControl == null))
                {
                    this.cachedEntityStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.EntityStaticControl);
                }
                
                return this.cachedEntityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectConditionsListBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IOverridesSummaryViewPropertiesDialogControls.SelectConditionsListBox
        {
            get
            {
                if ((this.cachedSelectConditionsListBox == null))
                {
                    this.cachedSelectConditionsListBox = new ListBox(this, OverridesSummaryViewPropertiesDialog.ControlIDs.SelectConditionsListBox);
                }
                
                return this.cachedSelectConditionsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }
                
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewOverridesStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.ViewOverridesStaticControl
        {
            get
            {
                if ((this.cachedViewOverridesStaticControl == null))
                {
                    this.cachedViewOverridesStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.ViewOverridesStaticControl);
                }
                
                return this.cachedViewOverridesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataContainedInASpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.ShowDataContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedShowDataContainedInASpecificGroupStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupStaticControl);
                }
                
                return this.cachedShowDataContainedInASpecificGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataRelatedToStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.ShowDataRelatedToStaticControl
        {
            get
            {
                if ((this.cachedShowDataRelatedToStaticControl == null))
                {
                    this.cachedShowDataRelatedToStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.ShowDataRelatedToStaticControl);
                }
                
                return this.cachedShowDataRelatedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.DescriptionStaticControl);
                }
                
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesSummaryViewPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, OverridesSummaryViewPropertiesDialog.ControlIDs.NameStaticControl);
                }
                
                return this.cachedNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
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
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis1
        /// </summary>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis1()
        {
            this.Controls.Ellipsis1Button.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[nathd] 9/13/2008 Created
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
                        tempWindow = new Window(
                            Strings.DialogTitle, 
                            StringMatchSyntax.ExactMatch,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            app,
                            Timeout);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

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
        /// 	[nathd] 9/13/2008 Created
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
            private const string ResourceDialogTitle = 
                ";Properties;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework;$this.Text";
            
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
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectConditions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectConditions = ";&Select conditions:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.UI.AuthoringDialog;selectConditionsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";&Clear;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Controls.FindBar;clearButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis1 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAll = ";(All);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.Views.SharedResources;AuthoringDialogTargetNull";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Entity
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEntity = "Entity";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit = ";Criteria descri&ption (click the underlined value to edit):;ManagedString;Micros" +
                "oft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Cr" +
                "iteriaControl.CriteriaControlResource;Description";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewOverrides
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewOverrides = ";View overrides;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Views.OverridesViewCriteriaResources;CriteriaDescrip" +
                "tion";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataContainedInASpecificGroup = ";Show data contained in a specific &group:;ManagedString;Microsoft.MOM.UI.Compone" +
                "nts.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataRelatedTo = ";Show data related &to:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Mom.UI.AuthoringDialog;typeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description:;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom." +
                "DiagramTemplateProperties;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;nameLabel" +
                ".Text";
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectConditions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectConditions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Entity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEntity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewOverrides
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewOverrides;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowDataContainedInASpecificGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowDataRelatedTo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
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
            /// 	[nathd] 9/13/2008 Created
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
            /// 	[nathd] 9/13/2008 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
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
            /// Exposes access to the SelectConditions translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectConditions
            {
                get
                {
                    if ((cachedSelectConditions == null))
                    {
                        cachedSelectConditions = CoreManager.MomConsole.GetIntlStr(ResourceSelectConditions);
                    }
                    
                    return cachedSelectConditions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
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
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    if ((cachedEllipsis0 == null))
                    {
                        cachedEllipsis0 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                    }
                    
                    return cachedEllipsis0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis1 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis1
            {
                get
                {
                    if ((cachedEllipsis1 == null))
                    {
                        cachedEllipsis1 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis1);
                    }
                    
                    return cachedEllipsis1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the All translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string All
            {
                get
                {
                    if ((cachedAll == null))
                    {
                        cachedAll = CoreManager.MomConsole.GetIntlStr(ResourceAll);
                    }
                    
                    return cachedAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Entity translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Entity
            {
                get
                {
                    if ((cachedEntity == null))
                    {
                        cachedEntity = CoreManager.MomConsole.GetIntlStr(ResourceEntity);
                    }
                    
                    return cachedEntity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEdit translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CriteriaDescriptionClickTheUnderlinedValueToEdit
            {
                get
                {
                    if ((cachedCriteriaDescriptionClickTheUnderlinedValueToEdit == null))
                    {
                        cachedCriteriaDescriptionClickTheUnderlinedValueToEdit = CoreManager.MomConsole.GetIntlStr(ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit);
                    }
                    
                    return cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewOverrides translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewOverrides
            {
                get
                {
                    if ((cachedViewOverrides == null))
                    {
                        cachedViewOverrides = CoreManager.MomConsole.GetIntlStr(ResourceViewOverrides);
                    }
                    
                    return cachedViewOverrides;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowDataContainedInASpecificGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowDataContainedInASpecificGroup
            {
                get
                {
                    if ((cachedShowDataContainedInASpecificGroup == null))
                    {
                        cachedShowDataContainedInASpecificGroup = CoreManager.MomConsole.GetIntlStr(ResourceShowDataContainedInASpecificGroup);
                    }
                    
                    return cachedShowDataContainedInASpecificGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowDataRelatedTo translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowDataRelatedTo
            {
                get
                {
                    if ((cachedShowDataRelatedTo == null))
                    {
                        cachedShowDataRelatedTo = CoreManager.MomConsole.GetIntlStr(ResourceShowDataRelatedTo);
                    }
                    
                    return cachedShowDataRelatedTo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    
                    return cachedDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 9/13/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    
                    return cachedName;
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
        /// 	[nathd] 9/13/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for SelectConditionsStaticControl
            /// </summary>
            public const string SelectConditionsStaticControl = "selectConditionsLabel";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearGroupButton";
            
            /// <summary>
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "changeTargetButton";
            
            /// <summary>
            /// Control ID for Ellipsis1Button
            /// </summary>
            public const string Ellipsis1Button = "changeTypeButton";
            
            /// <summary>
            /// Control ID for AllStaticControl
            /// </summary>
            public const string AllStaticControl = "targetObjectLabel";
            
            /// <summary>
            /// Control ID for EntityStaticControl
            /// </summary>
            public const string EntityStaticControl = "targetTypeLabel";
            
            /// <summary>
            /// Control ID for SelectConditionsListBox
            /// </summary>
            public const string SelectConditionsListBox = "checkboxes";
            
            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ViewOverridesStaticControl
            /// </summary>
            public const string ViewOverridesStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for ShowDataContainedInASpecificGroupStaticControl
            /// </summary>
            public const string ShowDataContainedInASpecificGroupStaticControl = "label1";
            
            /// <summary>
            /// Control ID for ShowDataRelatedToStaticControl
            /// </summary>
            public const string ShowDataRelatedToStaticControl = "typeLabel";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
        }
        #endregion
    }
}
