// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectClassDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 4/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsProfile.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - ISelectClassDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectClassDialogControls, for SelectClassDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectClassDialogControls
    {
        /// <summary>
        /// Read-only property to access SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
        /// </summary>
        TextBox SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AssociatedClassListView
        /// </summary>
        ListView AssociatedClassListView
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
        /// Read-only property to access EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
        /// </summary>
        StaticControl EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MatchingClassesStaticControl
        /// </summary>
        StaticControl MatchingClassesStaticControl
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
    /// 	[ruhim] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectClassDialog : Dialog, ISelectClassDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire of type TextBox
        /// </summary>
        private TextBox cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire;

        /// <summary>
        /// Cache to hold a reference to AssociatedClassListView of type ListView
        /// </summary>
        private ListView cachedAssociatedClassListView;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to MatchingClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMatchingClassesStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectClassDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectClassDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region ISelectClassDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectClassDialogControls Controls
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
        ///  Routine to set/get the text in control SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequireText
        {
            get
            {
                return this.Controls.SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire.Text;
            }

            set
            {
                this.Controls.SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectClassDialogControls.SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
        {
            get
            {
                if ((this.cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire == null))
                {
                    this.cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire = new TextBox(this, SelectClassDialog.ControlIDs.SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire);
                }
                return this.cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AssociatedClassListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectClassDialogControls.AssociatedClassListView
        {
            get
            {
                if ((this.cachedAssociatedClassListView == null))
                {
                    this.cachedAssociatedClassListView = new ListView(this, SelectClassDialog.ControlIDs.AssociatedClassListView, true, Constants.OneSecond * 2);
                }
                return this.cachedAssociatedClassListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectClassDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectClassDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectClassDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectClassDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectClassDialogControls.EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
        {
            get
            {
                if ((this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl == null))
                {
                    this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl = new StaticControl(this, SelectClassDialog.ControlIDs.EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl);
                }
                return this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchingClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectClassDialogControls.MatchingClassesStaticControl
        {
            get
            {
                if ((this.cachedMatchingClassesStaticControl == null))
                {
                    this.cachedMatchingClassesStaticControl = new StaticControl(this, SelectClassDialog.ControlIDs.MatchingClassesStaticControl);
                }
                return this.cachedMatchingClassesStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
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
        /// 	[ruhim] 4/24/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
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

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
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
            private const string ResourceDialogTitle = 
                ";Select class;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringClassChooser;$this.Text";

             /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Class Chooser dialog Name Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClassChooserNameColumn = 
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringClassChooser;nameColumn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterYourSearchTextBelowThisSearchesBothNameAndDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterYourSearchTextBelowThisSearchesBothNameAndDescription = ";Enter your search text below. This searches both name and description.;ManagedSt" +
                "ring;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.Monit" +
                "oringClassChooser;searchLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MatchingClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchingClasses = ";Matching Classes;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.UI.MonitoringClassChooser;classesLabel.Text";
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
            /// Caches the translated resource Class Chooser dialog Name Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClassChooserNameColumn;

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
            /// Caches the translated resource string for:  EnterYourSearchTextBelowThisSearchesBothNameAndDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MatchingClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMatchingClasses;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
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
            /// Exposes access to the  Class Chooser dialog Name Column Header
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/26/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClassChooserNameColumn
            {
                get
                {
                    if ((cachedClassChooserNameColumn == null))
                    {
                        cachedClassChooserNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceClassChooserNameColumn);
                    }
                    return cachedClassChooserNameColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
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
            /// 	[ruhim] 4/24/2006 Created
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
            /// Exposes access to the EnterYourSearchTextBelowThisSearchesBothNameAndDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterYourSearchTextBelowThisSearchesBothNameAndDescription
            {
                get
                {
                    if ((cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription == null))
                    {
                        cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription = CoreManager.MomConsole.GetIntlStr(ResourceEnterYourSearchTextBelowThisSearchesBothNameAndDescription);
                    }
                    return cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MatchingClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchingClasses
            {
                get
                {
                    if ((cachedMatchingClasses == null))
                    {
                        cachedMatchingClasses = CoreManager.MomConsole.GetIntlStr(ResourceMatchingClasses);
                    }
                    return cachedMatchingClasses;
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
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
            /// </summary>
            public const string SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire = "searchTextBox";

            /// <summary>
            /// Control ID for AssociatedClassListView
            /// </summary>
            public const string AssociatedClassListView = "mainListView";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
            /// </summary>
            public const string EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl = "searchLabel";

            /// <summary>
            /// Control ID for MatchingClassesStaticControl
            /// </summary>
            public const string MatchingClassesStaticControl = "classesLabel";
        }
        #endregion
    }
}
