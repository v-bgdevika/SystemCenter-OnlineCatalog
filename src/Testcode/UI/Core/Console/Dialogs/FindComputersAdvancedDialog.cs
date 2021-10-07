// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="FindComputersAdvancedDialog.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3 UI Test Automation
// </project>
// <summary>
//  MOMv3 UI Test Automation
// </summary>
// <history>
//  [KellyMor] 08-Aug-05 Created
//  [KellyMor] 13-Feb-06 Updated DialogTitle to concatenate the title string properly
//  [KellyMor] 20-Nov-06 Fixed issue in Init where loop didn't delay properly
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IFindComputersAdvancedDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IFindComputersAdvancedDialogControls, for FindComputersAdvancedDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 08-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFindComputersAdvancedDialogControls
    {
        /// <summary>
        /// Read-only property to access FieldButton
        /// </summary>
        Button FieldButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OwnerTextBox
        /// </summary>
        TextBox OwnerTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConditionStaticControl
        /// </summary>
        StaticControl ConditionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConditionComboBox
        /// </summary>
        ComboBox ConditionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ValueStaticControl
        /// </summary>
        StaticControl ValueStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ValueTextBox
        /// </summary>
        TextBox ValueTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConditionListStaticControl
        /// </summary>
        StaticControl ConditionListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConditionList
        /// </summary>
        ListView ConditionList
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
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the LDAP query builder, "Find Computers" dialog.
    /// This class manages the advanced functions for complex LDAP queries.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 08-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FindComputersAdvancedDialog : Dialog, IFindComputersAdvancedDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to FieldButton of type Button
        /// </summary>
        private Button cachedFieldButton;
        
        /// <summary>
        /// Cache to hold a reference to OwnerTextBox of type TextBox
        /// </summary>
        private TextBox cachedOwnerTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConditionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConditionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConditionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedConditionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ValueStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedValueStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ValueTextBox of type TextBox
        /// </summary>
        private TextBox cachedValueTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to ConditionListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConditionListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConditionList of type ListView
        /// </summary>
        private ListView cachedConditionList;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of FindComputersAdvancedDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public FindComputersAdvancedDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IFindComputersAdvancedDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IFindComputersAdvancedDialogControls Controls
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
        ///  Routine to set/get the text in control Owner
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OwnerText
        {
            get
            {
                return this.Controls.OwnerTextBox.Text;
            }
            
            set
            {
                this.Controls.OwnerTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Condition
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConditionText
        {
            get
            {
                return this.Controls.ConditionComboBox.Text;
            }
            
            set
            {
                this.Controls.ConditionComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Value
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ValueText
        {
            get
            {
                return this.Controls.ValueTextBox.Text;
            }
            
            set
            {
                this.Controls.ValueTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FieldButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersAdvancedDialogControls.FieldButton
        {
            get
            {
                if ((this.cachedFieldButton == null))
                {
                    this.cachedFieldButton = new Button(this, FindComputersAdvancedDialog.ControlIDs.FieldButton);
                }
                return this.cachedFieldButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OwnerTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IFindComputersAdvancedDialogControls.OwnerTextBox
        {
            get
            {
                if ((this.cachedOwnerTextBox == null))
                {
                    this.cachedOwnerTextBox = new TextBox(this, FindComputersAdvancedDialog.ControlIDs.OwnerTextBox);
                }
                return this.cachedOwnerTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConditionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindComputersAdvancedDialogControls.ConditionStaticControl
        {
            get
            {
                if ((this.cachedConditionStaticControl == null))
                {
                    this.cachedConditionStaticControl = new StaticControl(this, FindComputersAdvancedDialog.ControlIDs.ConditionStaticControl);
                }
                return this.cachedConditionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConditionComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IFindComputersAdvancedDialogControls.ConditionComboBox
        {
            get
            {
                if ((this.cachedConditionComboBox == null))
                {
                    this.cachedConditionComboBox = new ComboBox(this, FindComputersAdvancedDialog.ControlIDs.ConditionComboBox);
                }
                return this.cachedConditionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindComputersAdvancedDialogControls.ValueStaticControl
        {
            get
            {
                if ((this.cachedValueStaticControl == null))
                {
                    this.cachedValueStaticControl = new StaticControl(this, FindComputersAdvancedDialog.ControlIDs.ValueStaticControl);
                }
                return this.cachedValueStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IFindComputersAdvancedDialogControls.ValueTextBox
        {
            get
            {
                if ((this.cachedValueTextBox == null))
                {
                    this.cachedValueTextBox = new TextBox(this, FindComputersAdvancedDialog.ControlIDs.ValueTextBox);
                }
                return this.cachedValueTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersAdvancedDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, FindComputersAdvancedDialog.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersAdvancedDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, FindComputersAdvancedDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConditionListStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindComputersAdvancedDialogControls.ConditionListStaticControl
        {
            get
            {
                if ((this.cachedConditionListStaticControl == null))
                {
                    this.cachedConditionListStaticControl = new StaticControl(this, FindComputersAdvancedDialog.ControlIDs.ConditionListStaticControl);
                }
                return this.cachedConditionListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConditionList control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IFindComputersAdvancedDialogControls.ConditionList
        {
            get
            {
                if ((this.cachedConditionList == null))
                {
                    this.cachedConditionList = new ListView(this, FindComputersAdvancedDialog.ControlIDs.ConditionList);
                }
                return this.cachedConditionList;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersAdvancedDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, FindComputersAdvancedDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersAdvancedDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, FindComputersAdvancedDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IFindComputersAdvancedDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, FindComputersAdvancedDialog.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Field
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickField()
        {
            this.Controls.FieldButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
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
        /// 	[KellyMor] 08-Aug-05 Created
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
        /// <param name="app">Maui.Core.App owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
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
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.Dialog,
                                StringMatchSyntax.ExactMatch,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);

                        Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        ///     [KellyMor] 13-Feb-06 Updated resources
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitlePrefix = ";Find %s;Win32String;dsquery.dll;3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix = ";Computers;Win32String;dsquery.dll;163";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Field
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceField = "Fie&ld";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Condition
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCondition = "Condi&tion:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceValue = "Val&ue:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = "&Add";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = "&Remove";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConditionList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConditionList = "C&ondition List:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConditionList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConditionList1 = "Condition List:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;Win32DialogItemString;dsquery.dll;1013;1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
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
            /// Caches the translated resource string for:  Field
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedField;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Condition
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCondition;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValue;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConditionList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConditionList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConditionList1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConditionList1;
            
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            ///     [KellyMor] 13-Feb-06 Updated to concatenate the title string properly
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        // get the prefix
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitlePrefix);

                        // search and replace %s with the suffix
                        cachedDialogTitle =
                            cachedDialogTitle.Replace(
                                "%s",
                                CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleSuffix));
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Field translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Field
            {
                get
                {
                    if ((cachedField == null))
                    {
                        cachedField = CoreManager.MomConsole.GetIntlStr(ResourceField);
                    }
                    return cachedField;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Condition translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Condition
            {
                get
                {
                    if ((cachedCondition == null))
                    {
                        cachedCondition = CoreManager.MomConsole.GetIntlStr(ResourceCondition);
                    }
                    return cachedCondition;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Value translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Value
            {
                get
                {
                    if ((cachedValue == null))
                    {
                        cachedValue = CoreManager.MomConsole.GetIntlStr(ResourceValue);
                    }
                    return cachedValue;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConditionList translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConditionList
            {
                get
                {
                    if ((cachedConditionList == null))
                    {
                        cachedConditionList = CoreManager.MomConsole.GetIntlStr(ResourceConditionList);
                    }
                    return cachedConditionList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConditionList1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConditionList1
            {
                get
                {
                    if ((cachedConditionList1 == null))
                    {
                        cachedConditionList1 = CoreManager.MomConsole.GetIntlStr(ResourceConditionList1);
                    }
                    return cachedConditionList1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
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
            /// 	[KellyMor] 08-Aug-05 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
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
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for FieldButton
            /// </summary>
            public const int FieldButton = 1237;
            
            /// <summary>
            /// Control ID for OwnerTextBox
            /// </summary>
            public const int OwnerTextBox = 1236;
            
            /// <summary>
            /// Control ID for ConditionStaticControl
            /// </summary>
            public const int ConditionStaticControl = 1238;
            
            /// <summary>
            /// Control ID for ConditionComboBox
            /// </summary>
            public const int ConditionComboBox = 1235;
            
            /// <summary>
            /// Control ID for ValueStaticControl
            /// </summary>
            public const int ValueStaticControl = 1239;
            
            /// <summary>
            /// Control ID for ValueTextBox
            /// </summary>
            public const int ValueTextBox = 1234;
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const int AddButton = 1215;
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const int RemoveButton = 1214;
            
            /// <summary>
            /// Control ID for ConditionListStaticControl
            /// </summary>
            public const int ConditionListStaticControl = -1;
            
            /// <summary>
            /// Control ID for ConditionList
            /// </summary>
            public const int ConditionList = 1233;
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 1;
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
            
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int Tab1TabControl = 1024;
        }
        #endregion
    }
}
