// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DcmConnectToServerDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   DCM Console
// </project>
// <summary>
//   Temporary Code to handle DCM Connection Dialog
// </summary>
// <history>
//   [BillHodg] 11/25/2009 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IDcmConnectToServerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDcmConnectToServerDialogControls, for DcmConnectToServerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [BillHodg] 11/25/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDcmConnectToServerDialogControls
    {
        /// <summary>
        /// Gets read-only property to access ServerTextBox
        /// </summary>
        TextBox ServerTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ConnectButton
        /// </summary>
        Button ConnectButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    ///   [BillHodg] 11/25/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DcmConnectToServerDialog : Dialog, IDcmConnectToServerDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ServerTextBox of type TextBox
        /// </summary>
        private TextBox cachedServerTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectButton of type Button
        /// </summary>
        private Button cachedConnectButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the DcmConnectToServerDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of DcmConnectToServerDialog of type ConsoleApp
        /// </param>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DcmConnectToServerDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDcmConnectToServerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDcmConnectToServerDialogControls Controls
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
        ///  Gets or sets the text in control Server
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServerText
        {
            get
            {
                return this.Controls.ServerTextBox.Text;
            }
            
            set
            {
                this.Controls.ServerTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ServerTextBox control
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDcmConnectToServerDialogControls.ServerTextBox
        {
            get
            {
                if ((this.cachedServerTextBox == null))
                {
                    this.cachedServerTextBox = new TextBox(this, DcmConnectToServerDialog.ControlIDs.ServerTextBox);
                }
                
                return this.cachedServerTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ConnectButton control
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDcmConnectToServerDialogControls.ConnectButton
        {
            get
            {
                if ((this.cachedConnectButton == null))
                {
                    this.cachedConnectButton = new Button(this, DcmConnectToServerDialog.ControlIDs.ConnectButton);
                }
                
                return this.cachedConnectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDcmConnectToServerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DcmConnectToServerDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Connect
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConnect()
        {
            this.Controls.ConnectButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
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
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, "Window", StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                if (tempWindow != null) Mom.Test.UI.Core.Common.Utilities.LogMessage("Found DCM Connect Dialog on first try");
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
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch);
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
                if (tempWindow != null)
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Found DCM Connect Dialog on a later try.");
            }
            
            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ServerTextBox
            /// </summary>
            public const string ServerTextBox = "hostname";
            
            /// <summary>
            /// Control ID for ConnectButton
            /// </summary>
            public const string ConnectButton = "connect";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancel";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [BillHodg] 11/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Connect to Server
            /// </summary>
            public const string DialogTitle = "Connect to Server";
            
            /// <summary>
            /// Resource string for Connect
            /// </summary>
            public const string Connect = "Connect";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
        }
        #endregion
    }
}
