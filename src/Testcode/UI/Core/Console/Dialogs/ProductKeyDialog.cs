// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ProductKeyDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Setting the product licence page
// </project>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{

    #region Using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #endregion

    #region Interface Definition - IProductKeyDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IProductKeyDialogControls, for ProductKeyDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IProductKeyDialogControls
    {
        /// <summary>
        /// Read-only property to access ProductKey Textbox
        /// </summary>
        TextBox ProductKey
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ErrorImage StaticControl
        /// </summary>
        StaticControl ErrorImage
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ContinueButton
        /// </summary>
        Button ContinueButton
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
    }

    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Set the product key and continue to the next page.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class ProductKeyDialog : Dialog, IProductKeyDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ProductKey of type TextBox
        /// </summary>
        private TextBox cachedProductKey;

        /// <summary>
        /// Cache to hold a reference to ErrorImageLabel of type StaticControl
        /// </summary>
        private StaticControl cachedErrorImage;

        /// <summary>
        /// Cache to hold a reference to ContinueButton of type Button
        /// </summary>
        private Button cachedContinueButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Opening a new dialog for the product key
        /// </summary>
        /// <param name='app'>
        /// Owner of ProductDialog of type ConsoleApp
        /// </param>
        /// -----------------------------------------------------------------------------
        public ProductKeyDialog(ConsoleApp app) :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion

        #region IProductKeyDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// -----------------------------------------------------------------------------
        public virtual IProductKeyDialogControls Controls
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
        ///  Routine to set/get the text in control completion
        /// </summary>     
        /// -----------------------------------------------------------------------------
        public virtual string ProductKeyText
        {
            get
            {
                return this.Controls.ProductKey.Text;
            }

            set
            {
                this.Controls.ProductKey.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProductKey control
        /// </summary>
        /// -----------------------------------------------------------------------------
        TextBox IProductKeyDialogControls.ProductKey
        {
            get
            {
                if ((this.cachedProductKey == null))
                {
                    this.cachedProductKey = new TextBox(this, ProductKeyDialog.QueryIds.ProductKeyTextBox, Constants.DefaultDialogTimeout);
                }
                return this.cachedProductKey;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorImage control
        /// </summary>
        /// -----------------------------------------------------------------------------
        StaticControl IProductKeyDialogControls.ErrorImage
        {
            get
            {
                if ((this.cachedErrorImage == null))
                {
                    this.cachedErrorImage = new StaticControl(this, ProductKeyDialog.QueryIds.ErrorImageLabel);
                }
                return this.cachedErrorImage;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContinueButton
        /// </summary>
        /// -----------------------------------------------------------------------------
        Button IProductKeyDialogControls.ContinueButton
        {
            get
            {
                if ((this.cachedContinueButton == null))
                {
                    this.cachedContinueButton = new Button(this, ProductKeyDialog.QueryIds.ContinueButton);
                }
                return this.cachedContinueButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// -----------------------------------------------------------------------------
        Button IProductKeyDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ProductKeyDialog.QueryIds.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Continue
        /// </summary>      
        /// -----------------------------------------------------------------------------
        public virtual void ClickContinue()
        {
            this.Controls.ContinueButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>)      
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                //Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    app.MainWindow,
                    QueryIds.ProductKeyDialog,
                    Core.Common.Constants.DefaultDialogTimeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + ".");
            }
            return tempWindow;
        }

        #region Strings Class
      
        public class Strings
        {
            
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Dialog Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "Enter Product Key";     

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Activate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContinue = ";Continue;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.ProductKeyPage;ContinueButtonText.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.ProductKeyPage;CancelButtonText.Text";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Continue
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContinue;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>     
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
            /// Exposes access to the Continue translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string Continue
            {
                get
                {
                    if ((cachedContinue == null))
                    {
                        cachedContinue = CoreManager.MomConsole.GetIntlStr(ResourceContinue);
                    }
                    return cachedContinue;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Activate translated resource string
            /// </summary>
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

            #endregion
        }

        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>      
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ProductKey
            /// </summary>
            public const string ProductKey = "textBoxProductKey";

            /// <summary>
            /// Control ID for ContinueButton
            /// </summary>
            public const string ContinueButton = "continueButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Automation ID for Product Key Dialog
            /// </summary>
            /// <remarks>
            /// "Product Key Page"
            /// </remarks>
            public const string ProductKeyDialogAutomationID = "Product Key Page";

            /// <summary>
            /// Control Name for Product Key Dialog
            /// </summary>
            /// <remarks>
            /// "Enter Product Key"
            /// </remarks>
            public const string ProductKeyDialogName = "Enter Product Key";
        }

        #endregion

        #region QueryIds

        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// ------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants

            /// <summary>
            /// Contains resource string for ResourceProductKeyDialog query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProductKeyDialog =
                ";[UIA]AutomationId='" + ControlIDs.ProductKeyDialogAutomationID + "' && Name='" + ControlIDs.ProductKeyDialogName + "'";

            /// <summary>
            /// Contains resource string for ResourceProductKeyTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProductKeyTextBox = ";[UIA]AutomationId='textBoxProductKey'";

            /// <summary>
            /// Contains resource string for ResourceErrorImageLabel query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorImageLabel = ";[UIA]AutomationId='ErrorImageLabel'";

            /// <summary>
            /// Contains resource string for ResourceContinueButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContinueButton = ";[UIA]AutomationId='continueButton'";

            /// <summary>
            /// Contains resource string for ResourceCancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId='cancelButton'";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedProductKeyDialog;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedProductKeyTextBox;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedErrorImageLabel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedContinueButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedCancelButton;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProductKeyDialog translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID ProductKeyDialog
            {
                get
                {
                    if (cachedProductKeyDialog == null)
                    {
                        cachedProductKeyDialog = new QID(ResourceProductKeyDialog);
                    }

                    return cachedProductKeyDialog;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProductKeyTextBox translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID ProductKeyTextBox
            {
                get
                {
                    if (cachedProductKeyTextBox == null)
                    {
                        cachedProductKeyTextBox = new QID(ResourceProductKeyTextBox);
                    }

                    return cachedProductKeyTextBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorImage translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID ErrorImageLabel
            {
                get
                {
                    if (cachedErrorImageLabel == null)
                    {
                        cachedErrorImageLabel = new QID(ResourceErrorImageLabel);
                    }

                    return cachedErrorImageLabel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContinueButton translated resource qid string
            /// </summary>           
            /// -----------------------------------------------------------------------------
            public static QID ContinueButton
            {
                get
                {
                    if (cachedContinueButton == null)
                    {
                        cachedContinueButton = new QID(ResourceContinueButton);
                    }

                    return cachedContinueButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CancelButton translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    if (cachedCancelButton == null)
                    {
                        cachedCancelButton = new QID(ResourceCancelButton);
                    }

                    return cachedCancelButton;
                }
            }

            #endregion
        }

        #endregion
    }
}
