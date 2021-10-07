// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SaveToFavoritesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-liqluo] 8/30/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - ISaveToFavoritesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISaveToFavoritesDialogControls, for SaveToFavoritesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-liqluo] 8/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISaveToFavoritesDialogControls
    {
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
        /// Read-only property to access EnterANameForThisReportStaticControl
        /// </summary>
        StaticControl EnterANameForThisReportStaticControl
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
    /// 	[v-liqluo] 8/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SaveToFavoritesDialog : Dialog, ISaveToFavoritesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterANameForThisReportStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterANameForThisReportStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
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
        /// Owner of SaveToFavoritesDialog of type App
        /// </param>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SaveToFavoritesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISaveToFavoritesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISaveToFavoritesDialogControls Controls
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
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
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
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveToFavoritesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SaveToFavoritesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveToFavoritesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SaveToFavoritesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterANameForThisReportStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISaveToFavoritesDialogControls.EnterANameForThisReportStaticControl
        {
            get
            {
                if ((this.cachedEnterANameForThisReportStaticControl == null))
                {
                    this.cachedEnterANameForThisReportStaticControl = new StaticControl(this, SaveToFavoritesDialog.ControlIDs.EnterANameForThisReportStaticControl);
                }
                
                return this.cachedEnterANameForThisReportStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISaveToFavoritesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, SaveToFavoritesDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISaveToFavoritesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, SaveToFavoritesDialog.ControlIDs.NameStaticControl);
                }
                
                return this.cachedNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
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
        /// 	[v-liqluo] 8/30/2009 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 15;

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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("PerformanceDialog.Init :: Attempt " + (numberOfTries + 1) + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
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
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for Save to favorites
            /// </summary>
            private const string ResourceDialogTitle = ";Save to favorites;ManagedString;Microsoft.EnterpriseMan"+
                "agement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favori"+
                "tes.FavoriteReportWizard;$this.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Report"+
                "ing.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favorites.FavoriteRepor"+
                "tWizard;cancelBtn.Text";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            private const string ResourceOK = ";OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;"+
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favorites.FavoriteReportWizard;"+
                "okBtn.Text";

            /// <summary>
            /// Resource string for Enter a name for this report.
            /// </summary>
            private const string ResourceEnterANameForThisReport = ";Enter a name for this report.;ManagedString;Microsof" +
                "t.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting"+
                ".Wizards.Favorites.FavoriteReportWizard;description.Text";

            /// <summary>
            /// Resource string for Name:
            /// </summary>
            private const string ResourceName = ";&Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favorites.FavoriteReportWizard;nameLabel.Text";
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
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ok
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterANameForThisReport
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterANameForThisReport;
          
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
            /// 	[v-liqluo] 8/30/2009 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/30/2009 Created
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
            /// 	[v-liqluo] 8/30/2009 Created
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
            /// Exposes access to the EnterANameForThisReport translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterANameForThisReport
            {
                get
                {
                    if ((cachedEnterANameForThisReport == null))
                    {
                        cachedEnterANameForThisReport = CoreManager.MomConsole.GetIntlStr(ResourceEnterANameForThisReport);
                    }
                    return cachedEnterANameForThisReport;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/30/2009 Created
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
        /// 	[v-liqluo] 8/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okBtn";
            
            /// <summary>
            /// Control ID for EnterANameForThisReportStaticControl
            /// </summary>
            public const string EnterANameForThisReportStaticControl = "description";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "favoriteName";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
        }
        #endregion
    }
}
