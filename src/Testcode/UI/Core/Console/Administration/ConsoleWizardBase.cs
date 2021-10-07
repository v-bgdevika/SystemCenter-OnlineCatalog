// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConsoleWizardBase.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  11-AUG-08   Created.
//  [KellyMor]  13-AUG-08   Modified constructor and Init methods to take a
//                          string parameter for the wizard window title.
//  [KellyMor]  10-SEP-08   Removed Notification-specific navigation links.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IConsoleWizardBase

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConsoleWizardBase, for ConsoleWizardBase.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConsoleWizardBase
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access NavigationPaneItem
        /// </summary>
        StaticControl NavigationPaneItem
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeaderStaticControl
        /// </summary>
        StaticControl HeaderStaticControl
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Base class for all wizards in the Administration space.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ConsoleWizardBase : Dialog, IConsoleWizardBase
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to NavigationPaneItem of type StaticControl
        /// </summary>
        private StaticControl cachedNavigationPaneItem;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderStaticControl;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConsoleWizardBase of type CoreManager.MomConsole
        /// </param>
        /// <param name="wizardTitle">
        /// Wizard window title string.
        /// </param>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public ConsoleWizardBase(ConsoleApp app, string wizardTitle) : 
                base(app, Init(app, wizardTitle))
        {
            // Add Constructor logic here. 
        }

        #endregion
        
        #region IConsoleWizardBase Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual IConsoleWizardBase Controls
        {
            get
            {
                return this;
            }
        }

        #endregion
        
        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IConsoleWizardBase.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = 
                        new Button(
                            this, 
                            ConsoleWizardBase.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IConsoleWizardBase.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = 
                        new Button(
                            this, 
                            ConsoleWizardBase.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IConsoleWizardBase.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = 
                        new Button(
                            this, 
                            ConsoleWizardBase.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IConsoleWizardBase.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = 
                        new Button(
                            this, 
                            ConsoleWizardBase.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NavigationPaneItem control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl IConsoleWizardBase.NavigationPaneItem
        {
            get
            {
                if ((this.cachedNavigationPaneItem == null))
                {
                    this.cachedNavigationPaneItem = 
                        new StaticControl(
                            this, 
                            ConsoleWizardBase.ControlIDs.NavigationPaneItem);
                }
                
                return this.cachedNavigationPaneItem;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl IConsoleWizardBase.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = 
                        new StaticControl(
                            this, 
                            ConsoleWizardBase.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl IConsoleWizardBase.HeaderStaticControl
        {
            get
            {
                if ((this.cachedHeaderStaticControl == null))
                {
                    this.cachedHeaderStaticControl = 
                        new StaticControl(
                            this, 
                            ConsoleWizardBase.ControlIDs.HeaderStaticControl);
                }
                
                return this.cachedHeaderStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickFinish()
        {   
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.FinishButton, ConsoleConstants.DefaultContextMenuTimeout);
            this.Controls.FinishButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on a navigation link in the navigation panel.
        /// </summary>
        /// <param name="linkText">
        /// The text of the link.  Used to identify the link control.
        /// </param>
        /// <history>
        /// 	[KellyMor] 18-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickNavigationLink(string linkText)
        {
            // find the link control
            StaticControl navigationLink =
                new StaticControl(
                    this,
                    linkText,
                    StringMatchSyntax.ExactMatch,
                    "*",
                    StringMatchSyntax.WildCard);

            // click the link
            navigationLink.Click();
        }

        #endregion
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find an instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">
        /// ConsoleApp owning the dialog.
        /// </param>
        /// <param name="wizardTitle">
        /// Wizard window title string.
        /// </param>
        /// <history>
        /// 	[KellyMor]  11-AUG-08   Created
        ///     [KellyMor]  13-AUG-08   Pass in wizard title string.
        /// </history>
        /// -------------------------------------------------------------------
        private static Window Init(ConsoleApp app, string wizardTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                UI.Core.Common.Utilities.LogMessage(
                    "ConsoleWizardBase::Looking for window with title := '" +
                    wizardTitle +
                    "'");

                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    wizardTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                UI.Core.Common.Utilities.LogMessage(
                    "ConsoleWizardBase::Second chance to find window with title := '" +
                    wizardTitle +
                    "'");

                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                wizardTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        UI.Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    UI.Core.Common.Utilities.LogMessage(
                        "Failed to find the dialog with title := '" +
                        wizardTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourcePrevious = 
                ";< &Previous" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";previousButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNext =
                ";&Next >" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";nextButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceFinish = 
                ";&Finish" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";commitButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCancel = 
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework" +
                ";cancelButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceHelp =
                ";Help" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomConsoleResources" +
                ";HelpSubFolderName";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Header
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceHeader =
                ";Header" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardHeaderPanel" +
                ";headerLabel.Text";

            #endregion
            
            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedPrevious;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNext;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedFinish;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCancel;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedHelp;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Header
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedHeader;

            #endregion
            
            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourcePrevious);
                    }
                    
                    return cachedPrevious;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNext);
                    }
                    
                    return cachedNext;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFinish);
                    }
                    
                    return cachedFinish;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCancel);
                    }
                    
                    return cachedCancel;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceHelp);
                    }
                    
                    return cachedHelp;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Header translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Header
            {
                get
                {
                    if ((cachedHeader == null))
                    {
                        cachedHeader = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceHeader);
                    }
                    
                    return cachedHeader;
                }
            }

            #endregion
        }

        #endregion
        
        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for NavigationPaneItem
            /// </summary>
            public const string NavigationPaneItem = "textLinkLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "headerLabel";
        }

        #endregion
    }
}
