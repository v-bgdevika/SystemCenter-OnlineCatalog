// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RevertToDefaultsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Mom.Test.UI.Core.Console.Dialogs.RevertToDefaultsDialog
// </project>
// <summary>
// 	Revert confirm dialog for Personalization and Configuration wizard
// </summary>
// <history>
// 	[v-lileo] 2011/3/5 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using MemComponent = Microsoft.EnterpriseManagement.Monitoring.Components;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - IRevertToDefaultsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRevertToDefaultsDialogControls, for RevertToDefaultsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-lileo] 2011/3/5 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRevertToDefaultsDialogControls
    {
        
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
    }
    #endregion

    public class RevertToDefaultsDialog:Dialog, IRevertToDefaultsDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Revert confirm Dialog class .
        /// </summary>
        /// <param name='app'>
        /// Owner of RevertToDefaultsDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[v-lileo] 2011/3/5 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RevertToDefaultsDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IRevertToDefaultsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-lileo] 2011/3/5 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRevertToDefaultsDialogControls Controls
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
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/3/5 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRevertToDefaultsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RevertToDefaultsDialog.QueryIds.CancelButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/3/5 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRevertToDefaultsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RevertToDefaultsDialog.QueryIds.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/3/5 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    this.Controls.OKButton.Click();
                    break;
                case ProductSkuLevel.Web:
                    this.SendKeys(KeyboardCodes.Tab);
                    this.SendKeys(KeyboardCodes.Enter);
                    break;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-lileo] 2011/3/5 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    this.Controls.CancelButton.Click();
                    break;
                case ProductSkuLevel.Web:
                    this.SendKeys(KeyboardCodes.Enter);
                    break;
            }            
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[v-lileo] 2011/03/05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;

            try
            {
                switch(ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        // Try to locate an existing instance of a dialog
                        tempWindow = tempWindow = new Window(QueryIds.DialogTitle, Constants.DefaultDialogTimeout);
                        break;
                    case ProductSkuLevel.Web:
                        tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, Strings.DialogTitle)), Constants.DefaultDialogTimeout);
                        break;
                }
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;

                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + MemComponent.ComponentResources.ConfigPersonalizeRevertConfirmTitle + "' && Role = 'window'"), Constants.DefaultDialogTimeout);

                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Utilities.LogMessage("Failed to find window with title:  '" +
                        MemComponent.ComponentResources.ConfigPersonalizeRevertConfirmTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }

            return tempWindow;
        }

        #region Strings

        public class Strings
        {
            /// <summary>
            /// Dialog Title
            /// </summary>
            private const string ResourceDialogTitle =
                ";Revert to defaults" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.Monitoring.Components.dll" +
                ";Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources" +
                ";ConfigPersonalizeRevertConfirmTitle";

            /// <summary>
            /// EventViewGuid (Stored in the Views Table)
            /// </summary>
            private static string cachedDialogTitle;

            /// <summary>
            /// Exposes access to HealthView translated resource string
            /// </summary>
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
                }
            }
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
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OK button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOKButton = ";[UIA]AutomationId='1'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Cancel Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId='2'";

            /// <summary>
            /// Contains resource string for Dialog Title query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static readonly string ResourceDialogTitle = ";[VisibleOnly]Name = '" + Strings.DialogTitle + "' && Role = 'window'";

            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedCancelButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedOKButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the Window
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedDialogTitle;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel button translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    if (cachedCancelButton == null)
                    {
                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                cachedCancelButton = new QID(ResourceCancelButton);
                                break;
                            case ProductSkuLevel.Web:
                                cachedOKButton = new QID(";[UIA]ClassName='Button' && Name='Cancel'");
                                break;
                        }
                        
                    }

                    return cachedCancelButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OKButton translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID OKButton
            {
                get
                {
                    if (cachedOKButton == null)
                    {
                        switch(ProductSku.Sku)
                        {
                            case  ProductSkuLevel.Mom:
                                cachedOKButton = new QID(ResourceOKButton);
                                break;
                            case  ProductSkuLevel.Web:
                                cachedOKButton = new QID(";[UIA]ClassName='Button' && Name='OK'");
                                break;
                        }                        
                    }

                    return cachedOKButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Dialog Title translated resource qid string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static QID DialogTitle
            {
                get
                {
                    if(cachedDialogTitle == null)
                    {
                        cachedDialogTitle = new QID(ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
                }
            }

            #endregion
        }
        #endregion
    }
}
