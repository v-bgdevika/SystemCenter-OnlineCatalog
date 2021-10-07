// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SingleAlertPickerControl.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-lileo] 11/26/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using System.Collections.Generic;
    using System.Reflection;

    #region Interface Definition - IWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISinglePickerControlControls, for Window.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/26/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISinglePickerControlControls
    {
        /// <summary>
        /// Gets read-only property to access MultiObjectPickerComponentStaticControl
        /// </summary>
        StaticControl SingleAlertPickerControlStaticControl
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access AvailableItems9DataGrid
        /// </summary>
        DataGridControl AvailableItemsDataGrid
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ErrorLink
        /// </summary>
        Button ErrorLink
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ProgressIndicator
        /// </summary>
        ProgressBar ProgressIndicator
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access SelectAll button
        /// </summary>
        Button SelectAll
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/26/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SinglePickerControl : ISinglePickerControlControls
    {        
        #region Private Member Variables
        
        private Window Content = null;

        /// <summary>
        /// Cache to hold a reference to AlertPickerControlStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSingleAlertPickerControlStaticControl;

        /// <summary>
        /// Cache to hold a reference to AvailableItemsDataGrid of type DataGridControl
        /// </summary>
        private DataGridControl cachedAvailableItemsDataGrid;

        /// <summary>
        /// Cache to hold a reference to ErrorLink of type button
        /// </summary>
        private Button cachedErrorLinkButton;

        /// <summary>
        /// Cache to hold a reference to ProgressIndicator of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressIndicator;

        /// <summary>
        /// Cache to hold a reference to ProgressIndicator of type ProgressBar
        /// </summary>
        private Button cachedSelectAllButton;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Window class.
        /// </summary>
        /// <param name='app'></param>
        /// <param name='timeOut'></param>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SinglePickerControl(Window KnownWindow)
        {
            this.Content = KnownWindow;
        }

        #endregion

        #region ISingleAlertPickerControl Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the SingleAlertPickerControl's control properties together</value>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISinglePickerControlControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region public Control Properties

        /// <summary>
        /// Filter Control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupandObjectFilterControl Filter
        {
            get
            {
                return new GroupandObjectFilterControl(this.Content);
            }
        }
       
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SingleAlertPickerControlStaticControl control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISinglePickerControlControls.SingleAlertPickerControlStaticControl
        {
            get
            {
                if ((this.cachedSingleAlertPickerControlStaticControl == null))
                {
                    this.cachedSingleAlertPickerControlStaticControl = new StaticControl(this.Content, SinglePickerControl.QueryIds.AvailableItemsText);
                }
                
                return this.cachedSingleAlertPickerControlStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableItemsDataGrid control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridControl ISinglePickerControlControls.AvailableItemsDataGrid
        {
            get
            {
                if ((this.cachedAvailableItemsDataGrid == null))
                {
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            this.cachedAvailableItemsDataGrid = new DataGridControl(this.Content, SinglePickerControl.QueryIds.AvailableItemsDataGrid);
                            break;
                        case ProductSkuLevel.Web:                            
                            this.cachedAvailableItemsDataGrid = new DataGridControl(this.Content, new QID(";[UIA]AutomationId=\'silverlightDataGrid\'"));
                            break;
                    }
                }
                
                return this.cachedAvailableItemsDataGrid;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ErrorLink button
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISinglePickerControlControls.ErrorLink
        {
            get
            {
                if (this.cachedErrorLinkButton == null)
                {
                    //TODO: Need Get right QID
                    this.cachedErrorLinkButton = new Button(this.Content, SinglePickerControl.QueryIds.ErrorLink);
                }
                return this.cachedErrorLinkButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressIndicator ProgressBar
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar ISinglePickerControlControls.ProgressIndicator
        {
            get
            {
                if (this.cachedProgressIndicator == null)
                {
                    this.cachedProgressIndicator = new ProgressBar(this.Content, SinglePickerControl.QueryIds.ProgressBar);
                }
                return this.cachedProgressIndicator;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Select All button
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISinglePickerControlControls.SelectAll
        {
            get
            {
                if (this.cachedSelectAllButton == null)
                {
                    this.cachedSelectAllButton = new Button(this.Content, SinglePickerControl.QueryIds.SelectAll);
                }
                return this.cachedSelectAllButton;
            }
        }

        #endregion
        /// <summary>
        /// Method for select item in AvailableItemsDataGrid view
        /// </summary>
        /// <param name="Properties">Dictionary<string, string> Properties</param>
        public void SelectItem(Dictionary<string, string> Properties)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            if (Properties!= null)
            {
                Utilities.LogMessage(currentMethodName + ":: select items in available items view");
                Utilities.LogMessage(currentMethodName + ":: Column Headers Count is " + this.Controls.AvailableItemsDataGrid.ColumnHeaders.Count);
                Utilities.LogMessage(currentMethodName + ":: Row count is " + this.Controls.AvailableItemsDataGrid.RowsExtended.Count);
                Utilities.LogMessage(currentMethodName + ":: Cells count is "+this.Controls.AvailableItemsDataGrid.RowsExtended[0].CellsExtended.Count);

                int selectRow = this.Controls.AvailableItemsDataGrid.GetRowIndex(Properties);
                Utilities.LogMessage(currentMethodName + ":: Row index to select is " + selectRow);

                if (selectRow == -1)
                {
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("row index to select is -1");
                }

                Sleeper.Delay(1000);
                if (selectRow != null && selectRow != -1)
                {
                    this.Controls.AvailableItemsDataGrid.ScreenElement.EnsureVisible();
                    this.Controls.AvailableItemsDataGrid.RowsExtended[selectRow].CellsExtended[0].Select();
                    Sleeper.Delay(1000);
                }
            }
        }

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// <summary>
            ///  Contains resource string for AvailableItemsText query id
            /// </summary>
            private const string ResourceAvailableItemsText = ";[UIA]AutomationId=\'SinglePickerControlAllItemsText\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItemsDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItemsDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorLinkButton = ";[UIA]AutomationId=\'isErrorHourGlassIsBusyLinkControl\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar = ";[UIA]AutomationId=\'isErrorLineIsBusyProgressBarControl\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAllButton = ";[UIA]AutomationId=\'SelectAll\'";

            #endregion
            
            #region Properties

            public static QID AvailableItemsText
            {
                get
                {
                    return new QID(ResourceAvailableItemsText);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AvailableItemsDataGrid resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/26/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AvailableItemsDataGrid
            {
                get
                {
                    return new QID(ResourceAvailableItemsDataGrid);
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Error link resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ErrorLink
            {
                get
                {
                    return new QID(ResourceErrorLinkButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Progress bar resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar
            {
                get
                {
                    return new QID(ResourceProgressBar);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectAll button resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectAll
            {
                get
                {
                    return new QID(ResourceSelectAllButton);
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
        ///   [v-lileo] 11/26/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for SinglePickerControlTitle
            /// </summary>
            public const string SinglePickerControlTitle = "SinglePickerControl";
            public const string ProgressBarString = "ProgressBar";
        }
        #endregion
    }
}
