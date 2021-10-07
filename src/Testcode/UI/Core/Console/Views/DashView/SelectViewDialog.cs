// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectViewDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 6/25/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.DashView
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectViewDialogControls, for SelectViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 6/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectViewDialogControls
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
        /// Read-only property to access LookForTreeView
        /// </summary>
        MomControls.TreeView LookForTreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access XButton
        /// </summary>
        Button XButton
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
        /// Read-only property to access FindNowButton
        /// </summary>
        Button FindNowButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForTextBox
        /// </summary>
        TextBox LookForTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PickAViewToBeShownInTheSelectedPanelStaticControl
        /// </summary>
        StaticControl PickAViewToBeShownInTheSelectedPanelStaticControl
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
    /// 	[dialac] 6/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectViewDialog : Dialog, ISelectViewDialogControls
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
        /// Cache to hold a reference to LookForTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedLookForTreeView;
        
        /// <summary>
        /// Cache to hold a reference to XButton of type Button
        /// </summary>
        private Button cachedXButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to FindNowButton of type Button
        /// </summary>
        private Button cachedFindNowButton;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PickAViewToBeShownInTheSelectedPanelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPickAViewToBeShownInTheSelectedPanelStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectViewDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectViewDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectViewDialogControls Controls
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
        ///  Routine to set/get the text in control LookFor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookForText
        {
            get
            {
                return this.Controls.LookForTextBox.Text;
            }
            
            set
            {
                this.Controls.LookForTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectViewDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectViewDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectViewDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectViewDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTreeView control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        MomControls.TreeView ISelectViewDialogControls.LookForTreeView
        {
            get
            {
                if ((this.cachedLookForTreeView == null))
                {
                    Window wndTemp = this;
                    
                    // Required to navigate to control
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //int i;
                    //for (i = 0; (i <= 1); i = (i + 1))
                    //{
                    //    wndTemp = wndTemp.Extended.NextSibling;
                    //    Mom.Test.UI.Core.Common.Utilities.LogMessage("******DIALAC*****  Window for tmpWnd" + wndTemp.Caption + "   &&&&&   " + wndTemp.ClassName);
                    //}

                    //this.cachedLookForTreeView = new TreeView(wndTemp);
                    WindowParameters windowParameters = new WindowParameters();
                    windowParameters.StartWindow = this;
                    windowParameters.WinFormsID = SelectViewDialog.ControlIDs.LookForTreeView;
                    this.cachedLookForTreeView = new MomControls.TreeView(windowParameters);
                }

                return this.cachedLookForTreeView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the XButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectViewDialogControls.XButton
        {
            get
            {
                if ((this.cachedXButton == null))
                {
                    this.cachedXButton = new Button(this, SelectViewDialog.ControlIDs.XButton);
                }
                
                return this.cachedXButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectViewDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, SelectViewDialog.ControlIDs.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindNowButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectViewDialogControls.FindNowButton
        {
            get
            {
                if ((this.cachedFindNowButton == null))
                {
                    this.cachedFindNowButton = new Button(this, SelectViewDialog.ControlIDs.FindNowButton);
                }
                
                return this.cachedFindNowButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectViewDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, SelectViewDialog.ControlIDs.LookForStaticControl);
                }
                
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectViewDialogControls.LookForTextBox
        {
            get
            {
                if ((this.cachedLookForTextBox == null))
                {
                    this.cachedLookForTextBox = new TextBox(this, SelectViewDialog.ControlIDs.LookForTextBox);
                }
                
                return this.cachedLookForTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PickAViewToBeShownInTheSelectedPanelStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectViewDialogControls.PickAViewToBeShownInTheSelectedPanelStaticControl
        {
            get
            {
                if ((this.cachedPickAViewToBeShownInTheSelectedPanelStaticControl == null))
                {
                    this.cachedPickAViewToBeShownInTheSelectedPanelStaticControl = new StaticControl(this, SelectViewDialog.ControlIDs.PickAViewToBeShownInTheSelectedPanelStaticControl);
                }
                
                return this.cachedPickAViewToBeShownInTheSelectedPanelStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
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
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button X
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickX()
        {
            this.Controls.XButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FindNow
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFindNow()
        {
            this.Controls.FindNowButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
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
        //private static Window Init(MomConsoleApp app)
        //{
        //    // First check if the dialog is already up.
        //    Window tempWindow = null;
        //    try
        //    {
        //        // Try to locate an existing instance of a dialog
        //        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
        //    }
        //    catch (Exceptions.WindowNotFoundException windowNotFound)
        //    {
        //        // Reset the window reference
        //        tempWindow = null;

        //        // Maximum number of tries to find window
        //        int maxTries = 5;

        //        // Try several more times to find the window
        //        for (int numberOfTries = 0; ((null == tempWindow) 
        //                    && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
        //        {
        //            try
        //            {
        //                // Try to locate an existing instance of the window
        //                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

        //                // Wait for the window to become ready
        //                UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
        //            }
        //            catch (Exceptions.WindowNotFoundException )
        //            {
        //                // log the unsuccessful attempt

        //                // wait for a moment before trying again
        //                Maui.Core.Utilities.Sleeper.Delay(Timeout);
        //            }
        //        }
                
        //        // check for success
        //        if ((null == tempWindow))
        //        {
        //            // log the failure

        //            // rethrow the original exception
        //            throw windowNotFound;
        //        }
        //    }
            
        //    return tempWindow;
        //}
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[dialac] 6/25/2008 Created
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
            private const string ResourceDialogTitle = ";Select View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.SelectViewDialog;$this.Text";
            //private const string ResourceDialogTitle = "Select View";
            
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
            /// Contains resource string for:  X
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceX = ";X;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.I" +
                "nternal.UI.Controls.FindBar;hideButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";&Clear;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Controls.FindBar;clearButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FindNow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFindNow = ";&Find Now;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.Controls.FindBar;findButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";&Look for:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;look" +
                "ForLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PickAViewToBeShownInTheSelectedPanel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePickAViewToBeShownInTheSelectedPanel = ";&Pick a view to be shown in the selected panel:;ManagedString;Microsoft.MOM.UI.C" +
                "omponents.dll;Microsoft.EnterpriseManagement.Mom.UI.SelectViewDialog;instruction" +
                "sLabel.Text";
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
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  X
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedX;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FindNow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFindNow;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PickAViewToBeShownInTheSelectedPanel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPickAViewToBeShownInTheSelectedPanel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/25/2008 Created
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
            /// 	[dialac] 6/25/2008 Created
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
            /// 	[dialac] 6/25/2008 Created
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
            /// Exposes access to the X translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string X
            {
                get
                {
                    if ((cachedX == null))
                    {
                        cachedX = CoreManager.MomConsole.GetIntlStr(ResourceX);
                    }
                    
                    return cachedX;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/25/2008 Created
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
            /// Exposes access to the FindNow translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FindNow
            {
                get
                {
                    if ((cachedFindNow == null))
                    {
                        cachedFindNow = CoreManager.MomConsole.GetIntlStr(ResourceFindNow);
                    }
                    
                    return cachedFindNow;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = CoreManager.MomConsole.GetIntlStr(ResourceLookFor);
                    }
                    
                    return cachedLookFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PickAViewToBeShownInTheSelectedPanel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PickAViewToBeShownInTheSelectedPanel
            {
                get
                {
                    if ((cachedPickAViewToBeShownInTheSelectedPanel == null))
                    {
                        cachedPickAViewToBeShownInTheSelectedPanel = CoreManager.MomConsole.GetIntlStr(ResourcePickAViewToBeShownInTheSelectedPanel);
                    }
                    
                    return cachedPickAViewToBeShownInTheSelectedPanel;
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
        /// 	[dialac] 6/25/2008 Created
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
            public const string OKButton = "okbutton";
            
            /// <summary>
            /// Control ID for LookForTreeView
            /// </summary>
            public const string LookForTreeView = "treeView";
            
            /// <summary>
            /// Control ID for XButton
            /// </summary>
            public const string XButton = "hideButton";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearButton";
            
            /// <summary>
            /// Control ID for FindNowButton
            /// </summary>
            public const string FindNowButton = "findButton";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";
            
            /// <summary>
            /// Control ID for LookForTextBox
            /// </summary>
            public const string LookForTextBox = "lookForTextbox";
            
            /// <summary>
            /// Control ID for PickAViewToBeShownInTheSelectedPanelStaticControl
            /// </summary>
            public const string PickAViewToBeShownInTheSelectedPanelStaticControl = "instructionsLabel";
        }
        #endregion
    }
}
