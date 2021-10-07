// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Completion.cs">
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
    
    #region Interface Definition - ICompletionControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICompletionControls, for Completion.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICompletionControls
    {
        /// <summary>
        /// Gets read-only property to access CloseButton
        /// </summary>
        Button CloseButton
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
    public partial class Completion : Dialog, ICompletionControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
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
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Completion class.
        /// </summary>
        /// <param name='app'>
        /// Owner of Completion of type App
        /// </param>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Completion(App app, bool created, string poolName = "") :
            base(app, Init(app, created, poolName))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICompletion Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICompletionControls Controls
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
        ///  Gets access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICompletionControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, Completion.QueryIds.CloseButton);
                }
                
                return this.cachedCloseButton;
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
        LinkLabel ICompletionControls.TextLinkLabelLinkLabel
        {
            get
            {
                if ((this.cachedTextLinkLabelLinkLabel == null))
                {
                    this.cachedTextLinkLabelLinkLabel = new LinkLabel(this, Completion.QueryIds.TextLinkLabelLinkLabel);
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
        LinkLabel ICompletionControls.TextLinkLabelLinkLabel2
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
        LinkLabel ICompletionControls.TextLinkLabelLinkLabel3
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
        LinkLabel ICompletionControls.TextLinkLabelLinkLabel4
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
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
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
            /// Contains resource string for CloseButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCloseButton = ";[UIA]AutomationId=\'commitButton\'";
            
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
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CloseButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CloseButton
            {
                get
                {
                    return new QID(ResourceCloseButton);
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
            /// Resource string for Close
            /// </summary>
            public const string Close = "Close";
            
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
        }
        #endregion
    }
}
