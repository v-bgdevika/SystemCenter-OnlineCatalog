// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerfViewPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	Properties Performance View Dialog
// </project>
// <summary>
// 	This is the Properties Dialog that is used when you are creating a new PerfView 
//  editing a property. 
// </summary>
// <history>
// 	[dialac] 7/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    
    #region Interface Definition - IPerfViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerfViewPropertiesDialogControls, for PerfViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerfViewPropertiesDialogControls
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
        /// Read-only property to access ShowDataContainedInASpecificGroupStaticControl
        /// </summary>
        StaticControl ShowDataContainedInASpecificGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis2Button
        /// </summary>
        Button Ellipsis2Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis3Button
        /// </summary>
        Button Ellipsis3Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoneStaticControl
        /// </summary>
        StaticControl NoneStaticControl
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
        /// Read-only property to access ShowDataRelatedToStaticControl
        /// </summary>
        StaticControl ShowDataRelatedToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoneListBox
        /// </summary>
        ListBox NoneListBox
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
        /// Read-only property to access ViewPerformanceStaticControl
        /// </summary>
        StaticControl ViewPerformanceStaticControl
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
    /// 	[dialac] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerfViewPropertiesDialog : Dialog, IPerfViewPropertiesDialogControls
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
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataContainedInASpecificGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis2Button of type Button
        /// </summary>
        private Button cachedEllipsis2Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis3Button of type Button
        /// </summary>
        private Button cachedEllipsis3Button;
        
        /// <summary>
        /// Cache to hold a reference to NoneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoneStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EntityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEntityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowDataRelatedToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataRelatedToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoneListBox of type ListBox
        /// </summary>
        private ListBox cachedNoneListBox;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ViewPerformanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewPerformanceStaticControl;
        
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
        /// Owner of PerfViewPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerfViewPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPerfViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerfViewPropertiesDialogControls Controls
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
        /// 	[dialac] 7/21/2006 Created
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
        /// 	[dialac] 7/21/2006 Created
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
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerfViewPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PerfViewPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerfViewPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerfViewPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerfViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, PerfViewPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerfViewPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, PerfViewPropertiesDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IPerfViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, PerfViewPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataContainedInASpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.ShowDataContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedShowDataContainedInASpecificGroupStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupStaticControl);
                }
                
                return this.cachedShowDataContainedInASpecificGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis2Button control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerfViewPropertiesDialogControls.Ellipsis2Button
        {
            get
            {
                if ((this.cachedEllipsis2Button == null))
                {
                    this.cachedEllipsis2Button = new Button(this, PerfViewPropertiesDialog.ControlIDs.Ellipsis2Button);
                }
                
                return this.cachedEllipsis2Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis3Button control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerfViewPropertiesDialogControls.Ellipsis3Button
        {
            get
            {
                if ((this.cachedEllipsis3Button == null))
                {
                    this.cachedEllipsis3Button = new Button(this, PerfViewPropertiesDialog.ControlIDs.Ellipsis3Button);
                }
                
                return this.cachedEllipsis3Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.NoneStaticControl
        {
            get
            {
                if ((this.cachedNoneStaticControl == null))
                {
                    this.cachedNoneStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.NoneStaticControl);
                }
                
                return this.cachedNoneStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EntityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.EntityStaticControl
        {
            get
            {
                if ((this.cachedEntityStaticControl == null))
                {
                    this.cachedEntityStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.EntityStaticControl);
                }
                
                return this.cachedEntityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataRelatedToStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.ShowDataRelatedToStaticControl
        {
            get
            {
                if ((this.cachedShowDataRelatedToStaticControl == null))
                {
                    this.cachedShowDataRelatedToStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.ShowDataRelatedToStaticControl);
                }
                
                return this.cachedShowDataRelatedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoneListBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IPerfViewPropertiesDialogControls.NoneListBox
        {
            get
            {
                if ((this.cachedNoneListBox == null))
                {
                    this.cachedNoneListBox = new ListBox(this, PerfViewPropertiesDialog.ControlIDs.NoneListBox);
                }
                
                return this.cachedNoneListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }
                
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewPerformanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.ViewPerformanceStaticControl
        {
            get
            {
                if ((this.cachedViewPerformanceStaticControl == null))
                {
                    this.cachedViewPerformanceStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.ViewPerformanceStaticControl);
                }
                
                return this.cachedViewPerformanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.DescriptionStaticControl);
                }
                
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerfViewPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, PerfViewPropertiesDialog.ControlIDs.NameStaticControl);
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
        /// 	[dialac] 7/21/2006 Created
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
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis2
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis2()
        {
            this.Controls.Ellipsis2Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis3
        /// </summary>
        /// <history>
        /// 	[dialac] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis3()
        {
            this.Controls.Ellipsis3Button.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[dialac] 7/21/2006 Created
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
            
            catch (Exceptions.WindowNotFoundException ex)
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
                                 Strings.DialogTitle + "*",
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
                         Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                         
                         // wait for a moment before trying again
                         Maui.Core.Utilities.Sleeper.Delay(Timeout);
                     }
                 }
                 
                 // check for success
                 if (tempWindow == null)
                 {
                     // log the failure
                 
                     // throw the existing WindowNotFound exception
                     throw ex;
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
        /// 	[dialac] 7/21/2006 Created
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
            private const string ResourceDialogTitle = ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";

            
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
            /// Contains resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataContainedInASpecificGroup = ";Show data contained in a specific group;ManagedString;Microsoft.MOM.UI.Component" +
                "s.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis2 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis3 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  None
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNone = ";(None);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Views.SharedResources;AuthoringDialogTargetNull";
            
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
            /// Contains resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataRelatedTo = ";Show data related to:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.UI.AuthoringDialog;typeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit = ";Criteria description (click the underlined value to edit):;ManagedString;Microso" +
                "ft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Cri" +
                "teriaControl.CriteriaControlResource;Description";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewPerformance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewPerformance = ";View performance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.PerformanceViewCriteriaResource;CriteriaDesc" +
                "ription";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.UI.AuthoringDialog;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.AuthoringDialog;nameLabel.Text";
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
            /// Caches the translated resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowDataContainedInASpecificGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  None
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNone;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Entity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEntity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowDataRelatedTo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewPerformance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewPerformance;
            
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
            /// 	[dialac] 7/21/2006 Created
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
            /// 	[dialac] 7/21/2006 Created
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
            /// 	[dialac] 7/21/2006 Created
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
            /// 	[dialac] 7/21/2006 Created
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
            /// Exposes access to the ShowDataContainedInASpecificGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
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
            /// Exposes access to the Ellipsis2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis2
            {
                get
                {
                    if ((cachedEllipsis2 == null))
                    {
                        cachedEllipsis2 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis2);
                    }
                    
                    return cachedEllipsis2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis3 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis3
            {
                get
                {
                    if ((cachedEllipsis3 == null))
                    {
                        cachedEllipsis3 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis3);
                    }
                    
                    return cachedEllipsis3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the None translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string None
            {
                get
                {
                    if ((cachedNone == null))
                    {
                        cachedNone = CoreManager.MomConsole.GetIntlStr(ResourceNone);
                    }
                    
                    return cachedNone;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Entity translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
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
            /// Exposes access to the ShowDataRelatedTo translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
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
            /// Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEdit translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
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
            /// Exposes access to the ViewPerformance translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewPerformance
            {
                get
                {
                    if ((cachedViewPerformance == null))
                    {
                        cachedViewPerformance = CoreManager.MomConsole.GetIntlStr(ResourceViewPerformance);
                    }
                    
                    return cachedViewPerformance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/21/2006 Created
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
            /// 	[dialac] 7/21/2006 Created
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
        /// 	[dialac] 7/21/2006 Created
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
            /// Control ID for ShowDataContainedInASpecificGroupStaticControl
            /// </summary>
            public const string ShowDataContainedInASpecificGroupStaticControl = "label1";
            
            /// <summary>
            /// Control ID for Ellipsis2Button
            /// </summary>
            public const string Ellipsis2Button = "changeTargetButton";
            
            /// <summary>
            /// Control ID for Ellipsis3Button
            /// </summary>
            public const string Ellipsis3Button = "changeTypeButton";
            
            /// <summary>
            /// Control ID for NoneStaticControl
            /// </summary>
            public const string NoneStaticControl = "targetObjectLabel";
            
            /// <summary>
            /// Control ID for EntityStaticControl
            /// </summary>
            public const string EntityStaticControl = "targetTypeLabel";
            
            /// <summary>
            /// Control ID for ShowDataRelatedToStaticControl
            /// </summary>
            public const string ShowDataRelatedToStaticControl = "typeLabel";
            
            /// <summary>
            /// Control ID for NoneListBox
            /// </summary>
            public const string NoneListBox = "checkboxes";
            
            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ViewPerformanceStaticControl
            /// </summary>
            public const string ViewPerformanceStaticControl = "labelHeader";
            
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
