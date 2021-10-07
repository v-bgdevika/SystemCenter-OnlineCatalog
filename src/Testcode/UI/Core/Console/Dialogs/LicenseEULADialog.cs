// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="LicenseEULADialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Accepting the license page
// </project>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - ILicenseEULADialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ILicenseEULADialogControls, for LicenseEULADialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILicenseEULADialogControls
    {
        /// <summary>
        /// Read-only property to access CheckBoxLicense Checkbox
        /// </summary>
        CheckBox CheckBoxLicense
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AcceptButton
        /// </summary>
        Button AcceptButton
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
    /// TODO: Accept or cancel the license agreement page
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class LicenseEULADialog : Dialog, ILicenseEULADialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CheckBoxLicense of type CheckBox
        /// </summary>
        private CheckBox cachedCheckBoxLicense;

        /// <summary>
        /// Cache to hold a reference to AcceptButton of type Button
        /// </summary>
        private Button cachedAcceptButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Opening a new dialog for the License EULA dialog
        /// </summary>
        /// <param name='app'>
        /// Owner of LicenseDialog of type ConsoleApp
        /// </param>
        /// -----------------------------------------------------------------------------
        public LicenseEULADialog(ConsoleApp app) :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion

        #region ILicenseEULADialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// -----------------------------------------------------------------------------
        public virtual ILicenseEULADialogControls Controls
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
        ///  Property to handle checkbox LicenseCheckBox
        /// </summary>      
        /// -----------------------------------------------------------------------------
        public virtual bool LicenseCheckBox
        {
            get
            {
                return this.Controls.CheckBoxLicense.Checked;
            }

            set
            {
                this.Controls.CheckBoxLicense.Checked = value;
            }
        }
       
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the checkbox license control
        /// </summary>
        /// -----------------------------------------------------------------------------
        CheckBox ILicenseEULADialogControls.CheckBoxLicense
        {
            get
            {
                if ((this.cachedCheckBoxLicense == null))
                {
                    this.cachedCheckBoxLicense = new CheckBox(this, LicenseEULADialog.QueryIds.CheckBoxLicense);
                }
                return this.cachedCheckBoxLicense;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AcceptButton
        /// </summary>
        /// -----------------------------------------------------------------------------
        Button ILicenseEULADialogControls.AcceptButton
        {
            get
            {
                if ((this.cachedAcceptButton == null))
                {
                    this.cachedAcceptButton = new Button(this, LicenseEULADialog.QueryIds.AcceptButton); 
                }
                return this.cachedAcceptButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// -----------------------------------------------------------------------------
        Button ILicenseEULADialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, LicenseEULADialog.QueryIds.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Accept
        /// </summary>      
        /// -----------------------------------------------------------------------------
        public virtual void ClickAccept()
        {
            this.Controls.AcceptButton.Click();
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on checkbox checkBoxLicense
        /// </summary>     
        /// -----------------------------------------------------------------------------
        public virtual void ClickCheckBoxLicense()
        {
            this.Controls.CheckBoxLicense.Click();
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
                tempWindow = new Window(
                    app.MainWindow,
                    QueryIds.LicenseEULADialog,
                    Core.Common.Constants.DefaultDialogTimeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                Utilities.LogMessage("Window not found excpetion::" + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("exception occured::" + ex.Message);
                throw ex;
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
            private const string ResourceDialogTitle = "Please read this license agreement";
          
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: check box license
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckBox = "I _have read, understood, and agree with the terms of the license agreement";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Activate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAccept = ";AcceptButtonText;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.LicenseEULAPage;AcceptButtonText.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.LicenseEULAPage;CancelButtonText.Text";

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
            /// Caches the translated resource string for:  Checkbox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckBox;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Accept
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccept;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
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
            /// Exposes access to the Checkbox translated resource string
            /// </summary>     
            /// -----------------------------------------------------------------------------
            public static string CheckBoxLicense
            {
                get
                {
                    if ((cachedCheckBox == null))
                    {
                        cachedCheckBox = CoreManager.MomConsole.GetIntlStr(ResourceCheckBox);
                    }
                    return cachedCheckBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Accept translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string Accept
            {
                get
                {
                    if ((cachedAccept == null))
                    {
                        cachedAccept = CoreManager.MomConsole.GetIntlStr(ResourceAccept);
                    }
                    return cachedAccept;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
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
            /// Control ID for CheckBoxLicense
            /// </summary>
            public const string CheckBoxLicense = "checkBoxLicense";

            /// <summary>
            /// Control ID for ContinueButton
            /// </summary>
            public const string AcceptButton = "acceptButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Automation ID for License EULA Dialog
            /// </summary>           
            public const string LicenseEULADialogAutomationID = "License EULA Page";

            /// <summary>
            /// Control Name for License EULA Dialog
            /// </summary>
            public const string LicenseEULADialogName = "Please read this license agreement";
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
            /// Contains resource string for License EULA Dialog query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLicenseEULADialog =
                ";[UIA]AutomationId='License EULA Page'";

            /// <summary>
            /// Contains resource string for ResourceLicenseCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLicenseCheckBox = ";[UIA]AutomationId='checkBoxLicense'";

            /// <summary>
            /// Contains resource string for ResourceAcceptButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAcceptButton = ";[UIA]AutomationId='acceptButton'";

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
            private static QID cachedLicenseEULADialog;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedLicenseCheckBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedAcceptButton;

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
            /// Exposes access to the LicenseEULADialog translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID LicenseEULADialog
            {
                get
                {
                    if (cachedLicenseEULADialog == null)
                    {
                        cachedLicenseEULADialog = new QID(ResourceLicenseEULADialog);
                    }

                    return cachedLicenseEULADialog;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckBoxLicense translated resource qid string
            /// </summary>           
            /// -----------------------------------------------------------------------------
            public static QID CheckBoxLicense
            {
                get
                {
                    if (cachedLicenseCheckBox == null)
                    {
                        cachedLicenseCheckBox = new QID(ResourceLicenseCheckBox);
                    }

                    return cachedLicenseCheckBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AcceptButton translated resource qid string
            /// </summary>           
            /// -----------------------------------------------------------------------------
            public static QID AcceptButton
            {
                get
                {
                    if (cachedAcceptButton == null)
                    {
                        cachedAcceptButton = new QID(ResourceAcceptButton);
                    }

                    return cachedAcceptButton;
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
