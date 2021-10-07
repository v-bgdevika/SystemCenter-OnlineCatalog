// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MPGeneralPropertyDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 11/18/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IMPGeneralPropertyDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMPGeneralPropertyDialogControls, for MPGeneralPropertyDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 11/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMPGeneralPropertyDialogControls
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
        /// Read-only property to access IDTextBox
        /// </summary>
        TextBox IDTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IDStaticControl
        /// </summary>
        StaticControl IDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ForExample1000StaticControl
        /// </summary>
        StaticControl ForExample1000StaticControl
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
        /// Read-only property to access ManagementPackGeneralPropertiesStaticControl
        /// </summary>
        StaticControl ManagementPackGeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access VersionTextBox
        /// </summary>
        TextBox VersionTextBox
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
        /// Read-only property to access VersionStaticControl
        /// </summary>
        StaticControl VersionStaticControl
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
    /// 	[zhihaoq] 11/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MPGeneralPropertyDialog : Dialog, IMPGeneralPropertyDialogControls
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
        /// Cache to hold a reference to IDTextBox of type TextBox
        /// </summary>
        private TextBox cachedIDTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ForExample1000StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedForExample1000StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackGeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to VersionTextBox of type TextBox
        /// </summary>
        private TextBox cachedVersionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to VersionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedVersionStaticControl;
        
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
        /// <param name="mpName">Management Pack Name</param>
        /// Owner of MPGeneralPropertyDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MPGeneralPropertyDialog(ConsoleApp app, string mpName) : 
                base(app, Init(app, mpName))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IMPGeneralPropertyDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMPGeneralPropertyDialogControls Controls
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
        ///  Routine to set/get the text in control ID
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IDText
        {
            get
            {
                return this.Controls.IDTextBox.Text;
            }
            
            set
            {
                this.Controls.IDTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
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
        ///  Routine to set/get the text in control Version
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string VersionText
        {
            get
            {
                return this.Controls.VersionTextBox.Text;
            }
            
            set
            {
                this.Controls.VersionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPGeneralPropertyDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, MPGeneralPropertyDialog.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPGeneralPropertyDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MPGeneralPropertyDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPGeneralPropertyDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, MPGeneralPropertyDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IMPGeneralPropertyDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, MPGeneralPropertyDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IDTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMPGeneralPropertyDialogControls.IDTextBox
        {
            get
            {
                if ((this.cachedIDTextBox == null))
                {
                    this.cachedIDTextBox = new TextBox(this, MPGeneralPropertyDialog.ControlIDs.IDTextBox);
                }
                return this.cachedIDTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IDStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPGeneralPropertyDialogControls.IDStaticControl
        {
            get
            {
                if ((this.cachedIDStaticControl == null))
                {
                    this.cachedIDStaticControl = new StaticControl(this, MPGeneralPropertyDialog.ControlIDs.IDStaticControl);
                }
                return this.cachedIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ForExample1000StaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPGeneralPropertyDialogControls.ForExample1000StaticControl
        {
            get
            {
                if ((this.cachedForExample1000StaticControl == null))
                {
                    this.cachedForExample1000StaticControl = new StaticControl(this, MPGeneralPropertyDialog.ControlIDs.ForExample1000StaticControl);
                }
                return this.cachedForExample1000StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMPGeneralPropertyDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, MPGeneralPropertyDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackGeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPGeneralPropertyDialogControls.ManagementPackGeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedManagementPackGeneralPropertiesStaticControl == null))
                {
                    this.cachedManagementPackGeneralPropertiesStaticControl = new StaticControl(this, MPGeneralPropertyDialog.ControlIDs.ManagementPackGeneralPropertiesStaticControl);
                }
                return this.cachedManagementPackGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VersionTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMPGeneralPropertyDialogControls.VersionTextBox
        {
            get
            {
                if ((this.cachedVersionTextBox == null))
                {
                    this.cachedVersionTextBox = new TextBox(this, MPGeneralPropertyDialog.ControlIDs.VersionTextBox);
                }
                return this.cachedVersionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMPGeneralPropertyDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, MPGeneralPropertyDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPGeneralPropertyDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, MPGeneralPropertyDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VersionStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPGeneralPropertyDialogControls.VersionStaticControl
        {
            get
            {
                if ((this.cachedVersionStaticControl == null))
                {
                    this.cachedVersionStaticControl = new StaticControl(this, MPGeneralPropertyDialog.ControlIDs.VersionStaticControl);
                }
                return this.cachedVersionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPGeneralPropertyDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, MPGeneralPropertyDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
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
        /// 	[zhihaoq] 11/18/2008 Created
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
        /// 	[zhihaoq] 11/18/2008 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>
        ///  <param name="mpName">Management Pack Name</param>
        /// <history>
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, string mpName)
        {
            // Choose appropriate dialog title based on MP name
            string dialogTitle = mpName;

            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(dialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.WildCard, app, Timeout);
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
                                dialogTitle + "*",
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
                        Core.Common.Utilities.LogMessage(
                            "Attempt "+numberOfTries+" of " + MaxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title: '" +
                        dialogTitle + "'");
                
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
        /// 	[zhihaoq] 11/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

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
            /// Contains resource string for:  ID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceID = ";I&D :;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.MPPages.MPPropertiesPage;idLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ForExample1000
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceForExample1000 = ";For example,  1.0.0.0;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.MPPages.MPPropertiesPage;versionSampleLabel.T" +
                "ext";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPackGeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPackGeneralProperties = ";Management Pack General Properties ;ManagedString;Microsoft.MOM.UI.Components.dl" +
                "l;Microsoft.EnterpriseManagement.Mom.Internal.UI.MPPages.MPPropertiesPage;proper" +
                "tiesSection.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";De&scription :;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dl" +
                "l;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndIns" +
                "tall.Dialogs.CatalogMPPropertiesDialog;descriptionLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Version
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceVersion = ";&Version : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.MPPages.MPPropertiesPage;versionLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me :;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Di" +
                "alogs.CatalogMPPropertiesDialog;nameLabel.Text";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedID;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ForExample1000
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedForExample1000;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPackGeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPackGeneralProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Version
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedVersion;

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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
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
            /// Exposes access to the ID translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ID
            {
                get
                {
                    if ((cachedID == null))
                    {
                        cachedID = CoreManager.MomConsole.GetIntlStr(ResourceID);
                    }
                    return cachedID;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ForExample1000 translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ForExample1000
            {
                get
                {
                    if ((cachedForExample1000 == null))
                    {
                        cachedForExample1000 = CoreManager.MomConsole.GetIntlStr(ResourceForExample1000);
                    }
                    return cachedForExample1000;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPackGeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPackGeneralProperties
            {
                get
                {
                    if ((cachedManagementPackGeneralProperties == null))
                    {
                        cachedManagementPackGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceManagementPackGeneralProperties);
                    }
                    return cachedManagementPackGeneralProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
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
            /// Exposes access to the Version translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Version
            {
                get
                {
                    if ((cachedVersion == null))
                    {
                        cachedVersion = CoreManager.MomConsole.GetIntlStr(ResourceVersion);
                    }
                    return cachedVersion;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 11/19/2008 Created
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
        /// 	[zhihaoq] 11/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for IDTextBox
            /// </summary>
            public const string IDTextBox = "idTextBox";
            
            /// <summary>
            /// Control ID for IDStaticControl
            /// </summary>
            public const string IDStaticControl = "idLabel";
            
            /// <summary>
            /// Control ID for ForExample1000StaticControl
            /// </summary>
            public const string ForExample1000StaticControl = "versionSampleLabel";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for ManagementPackGeneralPropertiesStaticControl
            /// </summary>
            public const string ManagementPackGeneralPropertiesStaticControl = "propertiesSection";
            
            /// <summary>
            /// Control ID for VersionTextBox
            /// </summary>
            public const string VersionTextBox = "versionTextBox";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for VersionStaticControl
            /// </summary>
            public const string VersionStaticControl = "versionLabel";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
        }
        #endregion
    }
}
