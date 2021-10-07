namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using Directives
    using System;
    using Maui.Core;
    using Maui.Core.WinControls;
    using System.Collections;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// v-vijia: not test the generic pane yet, it maybe not wrok.
    /// Sunita mentioned that she had an implementation of the GenericView class, 
    /// if it can work on the data grid, will use her code, if not, v-vijia will contiue to work on the generic pane
    /// </summary>
    public class GenericPane : Control
    {
        #region Constructors
        /// <summary>
        /// Constructor of Generic Pane
        /// </summary>
        /// <param name="parent">parent</param>
        public GenericPane(Window parent)
            : base(parent)
        {
        }

        /// <summary>
        ///  Constructor of Generic Pane
        /// </summary>
        /// <param name="viewPaneDataGrid">parent control</param>
        /// <param name="queryId">QID</param>
        /// <param name="timeout">time out</param>
        public GenericPane(DataGridControl viewPaneDataGrid, QID queryId, int timeout)
            : base(viewPaneDataGrid, queryId, timeout)
        {
        }

        #endregion

        #region Public method

        /// <summary>
        /// Values of the Generic Pane
        /// </summary>
        /// <returns></returns>
        public ReadOnlyDictionary<string, string> Values()
        {
            ReadOnlyDictionary<string, string> rows = new ReadOnlyDictionary<string, string>();

            Maui.Core.MauiCollection<IScreenElement> PropertyDisplayNames = default(MauiCollection<IScreenElement>);
            Maui.Core.MauiCollection<IScreenElement> PropertyValues = default(MauiCollection<IScreenElement>);
            PropertyDisplayNames = this.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId = 'PropertyDisplayName';AutomationId = 'SCOMLabel'", null);
            PropertyValues = this.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId = 'PropertyValue';AutomationId = 'SCOMLabel'", null);

            //Get each row
            foreach (IScreenElement name in PropertyDisplayNames)
            {
                Window windowName = new Window(name);
                foreach (IScreenElement value in PropertyValues)
                {
                    Window windowValue = new Window(value);
                    
                    //same y-coordiline will be a key-value pair
                    if (windowName.ScreenElement.GetBoundingRectangle().Bottom == windowValue.ScreenElement.GetBoundingRectangle().Bottom)
                    {
                        TextBox txtName = windowName as TextBox;
                        TextBox txtValue = windowValue as TextBox;
                        rows.Add(txtName.Text, txtValue.Text);

                        break;
                    }
                }
            }

            return rows;
        }

        /// <summary>
        /// temp for test Values()
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string getValue(string name)
        {
            ReadOnlyDictionary<string, string> rows = Values();
            string result = rows[name];

            return result;
        }

        #endregion
    }
}