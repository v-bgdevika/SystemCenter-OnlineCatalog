// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateDashViewDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[visnara] 12/26/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.DashView
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ICreateDashViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateDashViewDialogControls, for CreateDashViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[visnara] 12/26/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateDashViewDialogControls
    {
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
        /// Read-only property to access SelectTheLayoutTemplateStaticControl
        /// </summary>
        StaticControl SelectTheLayoutTemplateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheLayoutTemplateListView
        /// </summary>
        ListView SelectTheLayoutTemplateListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl
        /// </summary>
        StaticControl SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox
        /// </summary>
        ComboBox SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox
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
    /// 	[visnara] 12/26/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateDashViewDialog : Dialog, ICreateDashViewDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheLayoutTemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheLayoutTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheLayoutTemplateListView of type ListView
        /// </summary>
        private ListView cachedSelectTheLayoutTemplateListView;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox;
        
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
        /// Owner of CreateDashViewDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateDashViewDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateDashViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateDashViewDialogControls Controls
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
        ///  Routine to set/get the text in control SpecifyTheNumberOfViewsToDisplayInTheDashboard
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheNumberOfViewsToDisplayInTheDashboardText
        {
            get
            {
                return this.Controls.SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox.SelectByText(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
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
        /// 	[visnara] 12/26/2006 Created
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
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ICreateDashViewDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, CreateDashViewDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheLayoutTemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDashViewDialogControls.SelectTheLayoutTemplateStaticControl
        {
            get
            {
                if ((this.cachedSelectTheLayoutTemplateStaticControl == null))
                {
                    this.cachedSelectTheLayoutTemplateStaticControl = new StaticControl(this, CreateDashViewDialog.ControlIDs.SelectTheLayoutTemplateStaticControl);
                }
                
                return this.cachedSelectTheLayoutTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheLayoutTemplateListView control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ICreateDashViewDialogControls.SelectTheLayoutTemplateListView
        {
            get
            {
                if ((this.cachedSelectTheLayoutTemplateListView == null))
                {
                    this.cachedSelectTheLayoutTemplateListView = new ListView(this, CreateDashViewDialog.ControlIDs.SelectTheLayoutTemplateListView);
                }
                
                return this.cachedSelectTheLayoutTemplateListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDashViewDialogControls.SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl == null))
                {
                    this.cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl = new StaticControl(this, CreateDashViewDialog.ControlIDs.SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl);
                }
                
                return this.cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDashViewDialogControls.SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox
        {
            get
            {
                if ((this.cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox == null))
                {
                    this.cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox = new ComboBox(this, CreateDashViewDialog.ControlIDs.SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox);
                }
                
                return this.cachedSpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDashViewDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, CreateDashViewDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDashViewDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateDashViewDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDashViewDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, CreateDashViewDialog.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDashViewDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, CreateDashViewDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDashViewDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, CreateDashViewDialog.ControlIDs.DescriptionStaticControl);
                }
                
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDashViewDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, CreateDashViewDialog.ControlIDs.NameStaticControl);
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
        /// 	[visnara] 12/26/2006 Created
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
        /// 	[visnara] 12/26/2006 Created
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
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);
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
                        tempWindow =
                             new Window(
                                 Strings.DialogTitle + "*",
                                 StringMatchSyntax.WildCard,
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
                        Core.Common.Utilities.LogMessage(
                           "Attempt " + numberOfTries + " of " + maxTries);
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
        /// 	[visnara] 12/26/2006 Created
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
            private const string ResourceDialogTitle = ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.DashboardViewAuthoringDialog;$this.Text";
            
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
            /// Contains resource string for:  SelectTheLayoutTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheLayoutTemplate = ";Select the layout template:;ManagedString;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Mom.UI.DashboardViewAuthoringDialog;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheNumberOfViewsToDisplayInTheDashboard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheNumberOfViewsToDisplayInTheDashboard = ";Specify the number of views to display in the dashboard:;ManagedString;Microsoft" +
                ".MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.DashboardViewAuthor" +
                "ingDialog;label1.Text";
            
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
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Com" +
                "mandChannelForm;descriptionLabel.Text";
            
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheLayoutTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheLayoutTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheNumberOfViewsToDisplayInTheDashboard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheNumberOfViewsToDisplayInTheDashboard;
            
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
            /// 	[visnara] 12/26/2006 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 12/26/2006 Created
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
            /// Exposes access to the SelectTheLayoutTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 12/26/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheLayoutTemplate
            {
                get
                {
                    if ((cachedSelectTheLayoutTemplate == null))
                    {
                        cachedSelectTheLayoutTemplate = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheLayoutTemplate);
                    }
                    
                    return cachedSelectTheLayoutTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheNumberOfViewsToDisplayInTheDashboard translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 12/26/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheNumberOfViewsToDisplayInTheDashboard
            {
                get
                {
                    if ((cachedSpecifyTheNumberOfViewsToDisplayInTheDashboard == null))
                    {
                        cachedSpecifyTheNumberOfViewsToDisplayInTheDashboard = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheNumberOfViewsToDisplayInTheDashboard);
                    }
                    
                    return cachedSpecifyTheNumberOfViewsToDisplayInTheDashboard;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 12/26/2006 Created
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
            /// 	[visnara] 12/26/2006 Created
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
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 12/26/2006 Created
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
            /// 	[visnara] 12/26/2006 Created
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
        /// 	[visnara] 12/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabControl1";
            
            /// <summary>
            /// Control ID for SelectTheLayoutTemplateStaticControl
            /// </summary>
            public const string SelectTheLayoutTemplateStaticControl = "label2";
            
            /// <summary>
            /// Control ID for SelectTheLayoutTemplateListView
            /// </summary>
            public const string SelectTheLayoutTemplateListView = "templateListView";
            
            /// <summary>
            /// Control ID for SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl
            /// </summary>
            public const string SpecifyTheNumberOfViewsToDisplayInTheDashboardStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox
            /// </summary>
            public const string SpecifyTheNumberOfViewsToDisplayInTheDashboardComboBox = "numberOfViewsDropdown";
            
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
