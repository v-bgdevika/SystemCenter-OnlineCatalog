// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PoolMembership.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [asttest] 11/8/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ResourcePool
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IPoolMembershipControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPoolMembershipControls, for PoolMembership.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPoolMembershipControls
    {
        /// <summary>
        /// Gets read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel2
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel3
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel3
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TextLinkLabelLinkLabel4
        /// </summary>
        LinkLabel TextLinkLabelLinkLabel4
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PoolMembersList
        /// </summary>
        DataGrid PoolMembersList
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ToolStrip
        /// </summary>
        Menu ToolStrip
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access RemoveButtonButton
        /// </summary>
        Button RemoveButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AddButtonButton
        /// </summary>
        Button AddButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HelpLinkLinkLabel
        /// </summary>
        LinkLabel HelpLinkLinkLabel
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
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class PoolMembership : Dialog, IPoolMembershipControls
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel2 of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel2;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel3 of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel3;
        
        /// <summary>
        /// Cache to hold a reference to TextLinkLabelLinkLabel4 of type LinkLabel
        /// </summary>
        private LinkLabel cachedTextLinkLabelLinkLabel4;
        
        /// <summary>
        /// Cache to hold a reference to PoolMembersList of type DataGrid
        /// </summary>
        private DataGrid cachedPoolMembersList;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip of type Menu
        /// </summary>
        private Menu cachedToolStrip;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButtonButton of type Button
        /// </summary>
        private Button cachedRemoveButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to AddButtonButton of type Button
        /// </summary>
        private Button cachedAddButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpLinkLinkLabel of type LinkLabel
        /// </summary>
        private LinkLabel cachedHelpLinkLinkLabel;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the PoolMembership class.
        /// </summary>
        /// <param name='app'>
        /// Owner of PoolMembership of type App
        /// </param>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PoolMembership(App app, bool created, string poolName = "") :
            base(app, Init(app, created, poolName))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPoolMembership Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPoolMembershipControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPoolMembershipControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PoolMembership.QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPoolMembershipControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PoolMembership.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPoolMembershipControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, PoolMembership.QueryIds.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPoolMembershipControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PoolMembership.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        LinkLabel IPoolMembershipControls.TextLinkLabelLinkLabel
        {
            get
            {
                if ((this.cachedTextLinkLabelLinkLabel == null))
                {
                    this.cachedTextLinkLabelLinkLabel = new LinkLabel(this, PoolMembership.QueryIds.TextLinkLabelLinkLabel);
                }
                
                return this.cachedTextLinkLabelLinkLabel;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel2 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel IPoolMembershipControls.TextLinkLabelLinkLabel2
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedTextLinkLabelLinkLabel2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextLinkLabelLinkLabel2 = new LinkLabel(wndTemp);
                }
                
                return this.cachedTextLinkLabelLinkLabel2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel3 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel IPoolMembershipControls.TextLinkLabelLinkLabel3
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedTextLinkLabelLinkLabel3 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextLinkLabelLinkLabel3 = new LinkLabel(wndTemp);
                }
                
                return this.cachedTextLinkLabelLinkLabel3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TextLinkLabelLinkLabel4 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel IPoolMembershipControls.TextLinkLabelLinkLabel4
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedTextLinkLabelLinkLabel4 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextLinkLabelLinkLabel4 = new LinkLabel(wndTemp);
                }
                
                return this.cachedTextLinkLabelLinkLabel4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PoolMembersList control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IPoolMembershipControls.PoolMembersList
        {
            get
            {
                if ((this.cachedPoolMembersList == null))
                {
                    this.cachedPoolMembersList = new DataGrid(this, PoolMembership.QueryIds.PoolMembersList);
                }
                
                return this.cachedPoolMembersList;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ToolStrip control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (ToolStrip) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Menu IPoolMembershipControls.ToolStrip
        {
            get
            {
                if ((this.cachedToolStrip == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedToolStrip = new Menu(wndTemp);
                }
                
                return this.cachedToolStrip;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RemoveButtonButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (RemoveButtonButton) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IPoolMembershipControls.RemoveButtonButton
        {
            get
            {
                if ((this.cachedRemoveButtonButton == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedRemoveButtonButton = new Button(wndTemp);
                }
                
                return this.cachedRemoveButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddButtonButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (AddButtonButton) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IPoolMembershipControls.AddButtonButton
        {
            get
            {
                if ((this.cachedAddButtonButton == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedAddButtonButton = new Button(wndTemp);
                }
                
                return this.cachedAddButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HelpLinkLinkLabel control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        LinkLabel IPoolMembershipControls.HelpLinkLinkLabel
        {
            get
            {
                if ((this.cachedHelpLinkLinkLabel == null))
                {
                    this.cachedHelpLinkLinkLabel = new LinkLabel(this, PoolMembership.QueryIds.HelpLinkLinkLabel);
                }
                
                return this.cachedHelpLinkLinkLabel;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RemoveButton
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemoveButton()
        {
            this.Controls.RemoveButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddButton
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddButton()
        {
            this.Controls.AddButtonButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, bool created, string poolName)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            string dialogTitle;

            if (created == true)
            {
                dialogTitle = GeneralProperties.Strings.CreatedDialogTitle;
            }
            else
            {
                dialogTitle = string.Format(GeneralProperties.Strings.EditDialogTitle, poolName);
            }
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[UIA, VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), Timeout);
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
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.WildCard);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw;
                }
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId=\'previousButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId=\'nextButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CreateButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateButton = ";[UIA]AutomationId=\'commitButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'cancelButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel2 = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel3 = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TextLinkLabelLinkLabel4 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextLinkLabelLinkLabel4 = ";[UIA]AutomationId=\'textLinkLabel\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PoolMembersList query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePoolMembersList = ";[UIA]AutomationId=\'poolMembersList\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ToolStrip query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip = ";[UIA]AutomationId=\'toolStrip\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for HelpLinkLinkLabel query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelpLinkLinkLabel = ";[UIA]AutomationId=\'helpLink\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PreviousButton
            {
                get
                {
                    return new QID(ResourcePreviousButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NextButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NextButton
            {
                get
                {
                    return new QID(ResourceNextButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CreateButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CreateButton
            {
                get
                {
                    return new QID(ResourceCreateButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel2
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel3 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel3
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel3);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TextLinkLabelLinkLabel4 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TextLinkLabelLinkLabel4
            {
                get
                {
                    return new QID(ResourceTextLinkLabelLinkLabel4);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PoolMembersList resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PoolMembersList
            {
                get
                {
                    return new QID(ResourcePoolMembersList);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ToolStrip resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ToolStrip
            {
                get
                {
                    return new QID(ResourceToolStrip);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the HelpLinkLinkLabel resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HelpLinkLinkLabel
            {
                get
                {
                    return new QID(ResourceHelpLinkLinkLabel);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {                       
            /// <summary>
            /// Resource string for < Previous
            /// </summary>
            public const string Previous = "< Previous";
            
            /// <summary>
            /// Resource string for Next >
            /// </summary>
            public const string Next = "Next >";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            public const string Create = "Create";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel = "textLinkLabel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel2 = "textLinkLabel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel3 = "textLinkLabel";
            
            /// <summary>
            /// Resource string for textLinkLabel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// textLinkLabel
            /// textLinkLabel
            /// textLinkLabel
            /// </remark>
            public const string TextLinkLabel4 = "textLinkLabel";
            
            /// <summary>
            /// Resource string for PoolMembersList
            /// </summary>
            public const string PoolMembersList = "PoolMembersList";
            
            /// <summary>
            /// Resource string for ToolStrip
            /// </summary>
            public const string ToolStrip = "ToolStrip";
            
            /// <summary>
            /// Resource string for removeButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Resource string for AddButton
            /// </summary>
            public const string AddButton = "AddButton";
            
            /// <summary>
            /// Resource string for helpLink
            /// </summary>
            public const string HelpLink = "helpLink";
        }
        #endregion
    }
}
