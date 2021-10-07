// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EventTextInputViewCriteriaDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 08/11/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Events
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IEventTextInputViewCriteriaDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEventTextInputViewCriteriaDialogControls, for EventTextInputViewCriteriaDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 08/11/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEventTextInputViewCriteriaDialogControls
    {
        /// <summary>
        /// Read-only property to access EnterASemiColonDelimitedListOfNumbersTextBox
        /// </summary>
        TextBox EnterASemiColonDelimitedListOfNumbersTextBox
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
        /// Read-only property to access EnterASemiColonDelimitedListOfNumbersStaticControl
        /// </summary>
        StaticControl EnterASemiColonDelimitedListOfNumbersStaticControl
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
    /// 	[lucyra] 08/11/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EventTextInputViewCriteriaDialog : Dialog, IEventTextInputViewCriteriaDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to EnterASemiColonDelimitedListOfNumbersTextBox of type TextBox
        /// </summary>
        private TextBox cachedEnterASemiColonDelimitedListOfNumbersTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterASemiColonDelimitedListOfNumbersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterASemiColonDelimitedListOfNumbersStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This is a constructor for multiple text input dialogs.
        /// </summary>
        /// <param name='app'>
        /// Owner of EventTextInputViewCriteriaDialog of type App
        /// </param>
        /// <param name="windowCaption">Properties dialog title.</param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EventTextInputViewCriteriaDialog(Mom.Test.UI.Core.Console.MomConsoleApp app, Views.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, UI.Core.Common.Constants.DefaultDialogTimeout);
        }

        #endregion
        
        #region IEventTextInputViewCriteriaDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEventTextInputViewCriteriaDialogControls Controls
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
        ///  Routine to set/get the text in control EnterASemiColonDelimitedListOfNumbers
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EnterASemiColonDelimitedListOfNumbersText
        {
            get
            {
                return this.Controls.EnterASemiColonDelimitedListOfNumbersTextBox.Text;
            }
            
            set
            {
                this.Controls.EnterASemiColonDelimitedListOfNumbersTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterASemiColonDelimitedListOfNumbersTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventTextInputViewCriteriaDialogControls.EnterASemiColonDelimitedListOfNumbersTextBox
        {
            get
            {
                if ((this.cachedEnterASemiColonDelimitedListOfNumbersTextBox == null))
                {
                    this.cachedEnterASemiColonDelimitedListOfNumbersTextBox = new TextBox(this, EventTextInputViewCriteriaDialog.ControlIDs.EnterASemiColonDelimitedListOfNumbersTextBox);
                }
                
                return this.cachedEnterASemiColonDelimitedListOfNumbersTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventTextInputViewCriteriaDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EventTextInputViewCriteriaDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventTextInputViewCriteriaDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, EventTextInputViewCriteriaDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterASemiColonDelimitedListOfNumbersStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventTextInputViewCriteriaDialogControls.EnterASemiColonDelimitedListOfNumbersStaticControl
        {
            get
            {
                if ((this.cachedEnterASemiColonDelimitedListOfNumbersStaticControl == null))
                {
                    this.cachedEnterASemiColonDelimitedListOfNumbersStaticControl = new StaticControl(this, EventTextInputViewCriteriaDialog.ControlIDs.EnterASemiColonDelimitedListOfNumbersStaticControl);
                }
                
                return this.cachedEnterASemiColonDelimitedListOfNumbersStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
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
        /// 	[lucyra] 08/11/2007 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>
        ///  <param name="windowCaption">Window Caption Dialog Title.</param>
        /// <history>
        /// 	[lucyra] 8/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, Views.WindowCaptions windowCaption)
        {
            string DialogTitle = Views.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
                    app.MainWindow,
                    Timeout);

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
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);

                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "EventTextInputViewCriteriaDialog:: Attempt " +
                            numberOfTries +
                            " of " +
                            MaxTries);

                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "EventTextInputViewCriteriaDialog:: " +
                        "Failed to find window with title:  '" +
                        DialogTitle +
                        "'");

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
        /// 	[lucyra] 08/11/2007 Created
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
            private const string ResourceDialogTitle = "Event number";
            
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
            /// Contains resource string for:  EnterASemiColonDelimitedListOfNumbers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterASemiColonDelimitedListOfNumbers = ";Enter a semi-colon delimited list of numbers;ManagedString;Microsoft.MOM.UI.Comm" +
                "on.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.NumberListEditDia" +
                "log;captionLabel.Text";
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
            /// Caches the translated resource string for:  EnterASemiColonDelimitedListOfNumbers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterASemiColonDelimitedListOfNumbers;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
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
            /// 	[lucyra] 08/11/2007 Created
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
            /// 	[lucyra] 08/11/2007 Created
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
            /// Exposes access to the EnterASemiColonDelimitedListOfNumbers translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterASemiColonDelimitedListOfNumbers
            {
                get
                {
                    if ((cachedEnterASemiColonDelimitedListOfNumbers == null))
                    {
                        cachedEnterASemiColonDelimitedListOfNumbers = CoreManager.MomConsole.GetIntlStr(ResourceEnterASemiColonDelimitedListOfNumbers);
                    }
                    
                    return cachedEnterASemiColonDelimitedListOfNumbers;
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
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for EnterASemiColonDelimitedListOfNumbersTextBox
            /// </summary>
            public const string EnterASemiColonDelimitedListOfNumbersTextBox = "inputTextbox";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for EnterASemiColonDelimitedListOfNumbersStaticControl
            /// </summary>
            public const string EnterASemiColonDelimitedListOfNumbersStaticControl = "captionLabel";
        }
        #endregion
    }
}
