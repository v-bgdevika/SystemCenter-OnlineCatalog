// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MultiPickerControlDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [asttest] 11/30/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IPickerControlModalDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDialogControls, for Dialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 11/30/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPickerControlModalDialogControls
    {
        /// <summary>
        /// Gets read-only property to access OkButton
        /// </summary>
        Button OkButton
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
    ///   [asttest] 11/30/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class PickerControlModalDialog : Dialog, IPickerControlModalDialogControls
    {   
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OkButton of type Button
        /// </summary>
        private Button cachedOkButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Dialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of Dialog of type Microsoft.SystemCenter.Visualization.Library_Microsoft.SystemCenter.Visualization.MultiAlertPickerComponent_HORNET020D_SystemCenterOperationsManager2012App
        /// </param>
        /// <history>
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PickerControlModalDialog(App app, enumPickerControlModalDialogType PickerControlType) : 
                base(app, Init(app,PickerControlType))
        {
            if (ProductSku.Sku == ProductSkuLevel.Mom)
                base.Move(50, 50);
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IMultiPickerControlDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPickerControlModalDialogControls Controls
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
        ///  Gets access to the OkButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerControlModalDialogControls.OkButton
        {
            get
            {
                if ((this.cachedOkButton == null))
                {
                    this.cachedOkButton = new Button(this, PickerControlModalDialog.QueryIds.OkButton);
                }
                
                return this.cachedOkButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerControlModalDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PickerControlModalDialog.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ok
        /// </summary>
        /// <history>
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOk()
        {
            this.Controls.OkButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [asttest] 11/30/2010 Created
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
        /// <param name="app">Microsoft.SystemCenter.Visualization.Library_Microsoft.SystemCenter.Visualization.MultiAlertPickerComponent_HORNET020D_SystemCenterOperationsManager2012App owning the dialog.</param>
        /// <history>
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app,enumPickerControlModalDialogType PickerControlType )
        {
            // First check if the dialog is already up.
            //Chooose appropiate dialog title depending on type
            string dialogTitle = null;
            // First check if the dialog is already up.

            switch (PickerControlType)
            {
                case enumPickerControlModalDialogType.MultiPickerControl:
                    dialogTitle = Strings.MultiAlertPickerComponentDialogTitle;
                    break;
                case enumPickerControlModalDialogType.SinglerPickerControl:
                    dialogTitle = Strings.SingleAlertPickerComponentDialogTitle;
                    break;
                case enumPickerControlModalDialogType.SingleObjectPicker:
                    dialogTitle = Strings.SingleObjectPickerComponentDialogTitle;
                    break;
            }
            // First check if the dialog is already up.
            Window tempWindow = null;
            int retries = 0 ;
            while (retries <= Constants.DefaultMaxRetry)
            {
                try
                {
                    // Try to locate an existing instance of a dialog
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            tempWindow = new Window(new QID(";[UIA, VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), Constants.DefaultDialogTimeout);
                            break;
                        case ProductSkuLevel.Web:
                            IScreenElement screen = CoreManager.MomConsole.MainWindow.ScreenElement.FindByPartialQueryId(-1, ";[UIA]ClassName ='OkCancelWindow' && Name = '" + dialogTitle + "'", null);
                            tempWindow = new Window(screen);
                            //tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, dialogTitle)), Constants.DefaultDialogTimeout);
                            break;
                    }

                    break;
                }
                catch (Exceptions.WindowNotFoundException)
                {
                    if (retries == Constants.DefaultMaxRetry)
                    {
                        throw;
                    }
                    else
                    {
                        retries++;
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("PickerControlModalDialog.Init:: Failed to find the dialog, try again.");
                    }
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
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OkButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOkButton = ";[UIA]AutomationId=\'OkButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'CancelButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OkButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OkButton
            {
                get
                {
                    return new QID(ResourceOkButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
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
        ///   [asttest] 11/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for 
            /// </summary>
            public const string MultiAlertPickerComponentDialogTitle = "Multi Object Picker Component";

            /// <summary>
            /// Resource string for Single Alert Picker Component
            /// </summary>
            public const string SingleAlertPickerComponentDialogTitle = "Single Alert Picker Component";

            /// <summary>
            /// Resource string for SingleObjectPickerDialogTitle
            /// </summary>
            //TODO: Need to use resource string.
            //public const string SingleObjectPickerComponentDialogTitle = "Select a group or object";
            public static string ResourceSingleObjectPickerComponentDialogTitle = null; //"Select a group or object";

            public static string SingleObjectPickerComponentDialogTitle
            {
                get
                {
                    if (ResourceSingleObjectPickerComponentDialogTitle == null)
                    {
                        LoadObjectPickerColumnNameResourceString objectPickerComponent = new LoadObjectPickerColumnNameResourceString();
                        ResourceSingleObjectPickerComponentDialogTitle = objectPickerComponent.SingleObjectPickerComponentTitle;
                        Utilities.LogMessage("ResourceSingleObjectPickerComponentDialogTitle is " + ResourceSingleObjectPickerComponentDialogTitle);
                    }
                    return ResourceSingleObjectPickerComponentDialogTitle.Replace("'","''");
                }
            }
        }
        #endregion

        #region enum
        /// <summary>
        /// Types of ConfigrationType
        /// </summary>
        public enum enumPickerControlModalDialogType
        {
            /// <summary>
            /// 
            /// </summary>
            MultiPickerControl,

            /// <summary>
            /// 
            /// </summary>
            SinglerPickerControl,

            /// <summary>
            /// 
            /// </summary>
            SingleObjectPicker

        }
        #endregion
    }
}
