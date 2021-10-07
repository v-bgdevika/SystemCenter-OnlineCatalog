namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;

     public interface IListViewHostControls
    {
        /// <summary>
        /// The ListBox control
        /// </summary>
        ListBox listBox
        {
            get;
        }
    }

     public class ListViewHost : ViewHost, IListViewHostControls
    {
        #region QIDs

        /// <summary>
        /// Thic contains the default QIDs for the controls
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the List Box
            /// </summary>
            public static QID ListBoxQID = new QID(";[UIA,visibleOnly]AutomationId='GridView'");
        }

        /// <summary>
        /// The QID for the List Box
        /// </summary>
        /// <returns>QID for the List Box</returns>
        protected virtual QID GetListBoxQID()
        {
            return ControlQIDs.ListBoxQID;
        }
        #endregion

        #region private variables

        /// <summary>
        /// The ListBox control
        /// </summary>
        private ListBox listBoxControl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ListViewHost class.
        /// </summary>
        /// <param name="knownWindow">Window that is the List view</param>
        public ListViewHost(Window knownWindow)
            : base(knownWindow)
        {
            Core.Common.Utilities.LogMessage("ListViewHost::ListViewHost Constructors");
        }

        #endregion

        #region IListViewHostControls Members

        /// <summary>
        /// The ListBox Control
        /// </summary>
        public ListBox listBox
        {
            get
            {
                if (this.listBoxControl== null)
                {
                    this.listBoxControl = new ListBox(this, this.GetListBoxQID());
                }

                return this.listBoxControl;
            }
        }

        #endregion

    }
}
