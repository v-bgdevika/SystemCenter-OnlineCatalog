// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BinaryAccountProperties.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOM Project
// </project>
// <summary>
// 	Binary Account Property Dialog
// </summary>
// <history>
// 	[v-linch] 6/25/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IBinaryAccountPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBinaryAccountPropertiesControls, for BinaryAccountProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-linch] 6/25/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBinaryAccountPropertiesControls
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
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideAccountCredentialsTextBox
        /// </summary>
        TextBox ProvideAccountCredentialsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BinaryAccountFileStaticControl
        /// </summary>
        StaticControl BinaryAccountFileStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideCredentialsForThisBinaryRunAsAccountStaticControl
        /// </summary>
        StaticControl ProvideCredentialsForThisBinaryRunAsAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideAccountCredentialsStaticControl
        /// </summary>
        StaticControl ProvideAccountCredentialsStaticControl
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
    /// 	[v-linch] 6/25/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BinaryAccountProperties : Dialog, IBinaryAccountPropertiesControls
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideAccountCredentialsTextBox of type TextBox
        /// </summary>
        private TextBox cachedProvideAccountCredentialsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to BinaryAccountFileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBinaryAccountFileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideCredentialsForThisBinaryRunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideCredentialsForThisBinaryRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideAccountCredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideAccountCredentialsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of BinaryAccountProperties of type App
        /// </param>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public BinaryAccountProperties(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IBinaryAccountProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBinaryAccountPropertiesControls Controls
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
        ///  Routine to set/get the text in control ProvideAccountCredentials
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProvideAccountCredentialsText
        {
            get
            {
                return this.Controls.ProvideAccountCredentialsTextBox.Text;
            }
            
            set
            {
                this.Controls.ProvideAccountCredentialsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBinaryAccountPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, BinaryAccountProperties.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBinaryAccountPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, BinaryAccountProperties.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBinaryAccountPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, BinaryAccountProperties.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IBinaryAccountPropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, BinaryAccountProperties.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideAccountCredentialsTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IBinaryAccountPropertiesControls.ProvideAccountCredentialsTextBox
        {
            get
            {
                if ((this.cachedProvideAccountCredentialsTextBox == null))
                {
                    this.cachedProvideAccountCredentialsTextBox = new TextBox(this, BinaryAccountProperties.ControlIDs.ProvideAccountCredentialsTextBox);
                }
                
                return this.cachedProvideAccountCredentialsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBinaryAccountPropertiesControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, BinaryAccountProperties.ControlIDs.BrowseButton);
                }
                
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BinaryAccountFileStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBinaryAccountPropertiesControls.BinaryAccountFileStaticControl
        {
            get
            {
                if ((this.cachedBinaryAccountFileStaticControl == null))
                {
                    this.cachedBinaryAccountFileStaticControl = new StaticControl(this, BinaryAccountProperties.ControlIDs.BinaryAccountFileStaticControl);
                }
                
                return this.cachedBinaryAccountFileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideCredentialsForThisBinaryRunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBinaryAccountPropertiesControls.ProvideCredentialsForThisBinaryRunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedProvideCredentialsForThisBinaryRunAsAccountStaticControl == null))
                {
                    this.cachedProvideCredentialsForThisBinaryRunAsAccountStaticControl = new StaticControl(this, BinaryAccountProperties.ControlIDs.ProvideCredentialsForThisBinaryRunAsAccountStaticControl);
                }
                
                return this.cachedProvideCredentialsForThisBinaryRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideAccountCredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBinaryAccountPropertiesControls.ProvideAccountCredentialsStaticControl
        {
            get
            {
                if ((this.cachedProvideAccountCredentialsStaticControl == null))
                {
                    this.cachedProvideAccountCredentialsStaticControl = new StaticControl(this, BinaryAccountProperties.ControlIDs.ProvideAccountCredentialsStaticControl);
                }
                
                return this.cachedProvideAccountCredentialsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
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
        /// 	[v-linch] 6/25/2009 Created
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
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }

        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Run As Account Properties -;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountPropertiesCaption";

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

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
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
            /// 	[v-linch] 2009/6/17  Created
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
            /// 	[v-linch] 2009/6/17  Created
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

            #endregion
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/25/2009 Created
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for ProvideAccountCredentialsTextBox
            /// </summary>
            public const string ProvideAccountCredentialsTextBox = "textBoxBinary";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "buttonBrowse";
            
            /// <summary>
            /// Control ID for BinaryAccountFileStaticControl
            /// </summary>
            public const string BinaryAccountFileStaticControl = "labelBinry";
            
            /// <summary>
            /// Control ID for ProvideCredentialsForThisBinaryRunAsAccountStaticControl
            /// </summary>
            public const string ProvideCredentialsForThisBinaryRunAsAccountStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for ProvideAccountCredentialsStaticControl
            /// </summary>
            public const string ProvideAccountCredentialsStaticControl = "labelTitle";
        }
        #endregion
    }
}
