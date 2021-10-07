// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="FindNodeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3 UI Automation
// </project>
// <summary>
// 	Automate the find dialog in the diagram view.
// </summary>
// <history>
// 	[KellyMor] 09APR07 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.ServiceDiagram
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IFindNodeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IFindNodeDialogControls, for FindNodeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/9/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFindNodeDialogControls
    {
        /// <summary>
        /// Read-only property to access MatchCaseCheckBox
        /// </summary>
        CheckBox MatchCaseCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserWildcardsAndCheckBox
        /// </summary>
        CheckBox UserWildcardsAndCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FindWhatTextBox
        /// </summary>
        TextBox FindWhatTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FindWhatStaticControl
        /// </summary>
        StaticControl FindWhatStaticControl
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
        /// Read-only property to access FindButton
        /// </summary>
        Button FindButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the find dialog in the diagram
    /// view.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 09APR07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FindNodeDialog : Dialog, IFindNodeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MatchCaseCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMatchCaseCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to UserWildcardsAndCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUserWildcardsAndCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to FindWhatTextBox of type TextBox
        /// </summary>
        private TextBox cachedFindWhatTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FindWhatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFindWhatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to FindButton of type Button
        /// </summary>
        private Button cachedFindButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of FindNodeDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public FindNodeDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IFindNodeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IFindNodeDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MatchCase
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MatchCase
        {
            get
            {
                return this.Controls.MatchCaseCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MatchCaseCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox UserWildcardsAnd
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UserWildcardsAnd
        {
            get
            {
                return this.Controls.UserWildcardsAndCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UserWildcardsAndCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FindWhat
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FindWhatText
        {
            get
            {
                return this.Controls.FindWhatTextBox.Text;
            }
            
            set
            {
                this.Controls.FindWhatTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchCaseCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IFindNodeDialogControls.MatchCaseCheckBox
        {
            get
            {
                if ((this.cachedMatchCaseCheckBox == null))
                {
                    this.cachedMatchCaseCheckBox = new CheckBox(this, FindNodeDialog.ControlIDs.MatchCaseCheckBox);
                }
                
                return this.cachedMatchCaseCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserWildcardsAndCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IFindNodeDialogControls.UserWildcardsAndCheckBox
        {
            get
            {
                if ((this.cachedUserWildcardsAndCheckBox == null))
                {
                    this.cachedUserWildcardsAndCheckBox = new CheckBox(this, FindNodeDialog.ControlIDs.UserWildcardsAndCheckBox);
                }
                
                return this.cachedUserWildcardsAndCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindWhatTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IFindNodeDialogControls.FindWhatTextBox
        {
            get
            {
                if ((this.cachedFindWhatTextBox == null))
                {
                    this.cachedFindWhatTextBox = new TextBox(this, FindNodeDialog.ControlIDs.FindWhatTextBox);
                }
                
                return this.cachedFindWhatTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindWhatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindNodeDialogControls.FindWhatStaticControl
        {
            get
            {
                if ((this.cachedFindWhatStaticControl == null))
                {
                    this.cachedFindWhatStaticControl = new StaticControl(this, FindNodeDialog.ControlIDs.FindWhatStaticControl);
                }
                
                return this.cachedFindWhatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindNodeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, FindNodeDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindNodeDialogControls.FindButton
        {
            get
            {
                if ((this.cachedFindButton == null))
                {
                    this.cachedFindButton = new Button(this, FindNodeDialog.ControlIDs.FindButton);
                }
                
                return this.cachedFindButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MatchCase
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMatchCase()
        {
            this.Controls.MatchCaseCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UserWildcardsAnd
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUserWildcardsAnd()
        {
            this.Controls.UserWildcardsAndCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Find
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFind()
        {
            this.Controls.FindButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                Core.Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.DialogTitle +
                    "'...");

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
                                Strings.DialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
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
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title '" +
                        Strings.DialogTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09APR07 Created
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
            private const string ResourceDialogTitle = ";Find;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.SearchForm;$this.Text";
             //;Find;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;FindText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MatchCase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchCase = ";Match case;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;MatchCaseText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserWildcardsAnd
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserWildcardsAnd = ";User wildcards (* and ?);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;UseWildCardText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FindWhat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFindWhat = ";Find what:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.SearchForm;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Find
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFind = ";Find;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;FindText"; 
                //";Find;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.SearchForm;$this.Text";
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
            /// Caches the translated resource string for:  MatchCase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMatchCase;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserWildcardsAnd
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserWildcardsAnd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FindWhat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFindWhat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Find
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFind;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/9/2007 Created
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
            /// Exposes access to the MatchCase translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/9/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchCase
            {
                get
                {
                    if ((cachedMatchCase == null))
                    {
                        cachedMatchCase = CoreManager.MomConsole.GetIntlStr(ResourceMatchCase);
                    }
                    
                    return cachedMatchCase;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserWildcardsAnd translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/9/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserWildcardsAnd
            {
                get
                {
                    if ((cachedUserWildcardsAnd == null))
                    {
                        cachedUserWildcardsAnd = CoreManager.MomConsole.GetIntlStr(ResourceUserWildcardsAnd);
                    }
                    
                    return cachedUserWildcardsAnd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FindWhat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/9/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FindWhat
            {
                get
                {
                    if ((cachedFindWhat == null))
                    {
                        cachedFindWhat = CoreManager.MomConsole.GetIntlStr(ResourceFindWhat);
                    }
                    
                    return cachedFindWhat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/9/2007 Created
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
            /// Exposes access to the Find translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/9/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Find
            {
                get
                {
                    if ((cachedFind == null))
                    {
                        cachedFind = CoreManager.MomConsole.GetIntlStr(ResourceFind);
                    }
                    
                    return cachedFind;
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
        /// 	[KellyMor] 4/9/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for MatchCaseCheckBox
            /// </summary>
            public const string MatchCaseCheckBox = "chbMatchCase";
            
            /// <summary>
            /// Control ID for UserWildcardsAndCheckBox
            /// </summary>
            public const string UserWildcardsAndCheckBox = "chbUserRegEx";
            
            /// <summary>
            /// Control ID for FindWhatTextBox
            /// </summary>
            public const string FindWhatTextBox = "tbFindWhat";
            
            /// <summary>
            /// Control ID for FindWhatStaticControl
            /// </summary>
            public const string FindWhatStaticControl = "label1";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "btnCancel";
            
            /// <summary>
            /// Control ID for FindButton
            /// </summary>
            public const string FindButton = "btnFind";
        }
        #endregion
    }
}
