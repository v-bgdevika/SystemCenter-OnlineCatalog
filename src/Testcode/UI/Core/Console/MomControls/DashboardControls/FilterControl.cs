using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maui.Core;
using Maui.Core.WinControls;
namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{

    // To Do Need to move to a new Class
    public class FilterControl// : ViewHost
    {
        new public class ControlQIDs
        {

            /// <summary>
            /// QID for the filter linked with data grid
            /// </summary>
            public static QID FilterGridQID = new QID(";[UIA]AutomationId = 'SCOMWatermarkTextBox'");


            /// <summary>
            /// QID for the filter close button linked with data grid
            /// </summary>
            public static QID FilterCloseButtonQID = new QID(";[UIA]AutomationId = 'SCOMFilterControlCloseButton'");

            /// <summary>
            ///  QID for the filter Search button linked with data grid
            /// </summary>
            public static QID FilterSearchButtonQID = new QID(";[UIA]AutomationId = 'SCOMFilterControlSearchButton'");


        }
        Window Content = null;
        /// <summary>
        /// The QID for the Search Close button
        /// </summary>
        /// <returns>QID for the content</returns>
        protected QID GetFilterCloseButtonQID()
        {
            return ControlQIDs.FilterCloseButtonQID;
        }
        /// <summary>
        /// The QID for the Search Search button
        /// </summary>
        /// <returns>QID for the content</returns>
        protected QID GetFilterSearchBUttonQID()
        {
            return ControlQIDs.FilterSearchButtonQID;
        }
        /// <summary>
        /// The QID for the Search
        /// </summary>
        /// <returns>QID for the content</returns>
        protected QID GetFilterGridQID()
        {
            return ControlQIDs.FilterGridQID;
        }


        public FilterControl(Window knownWindow)
        // : base(knownWindow)
        {
            Content = knownWindow;
        }
        private TextBox filterTextBox;

        private Button filterCloseButton;
        private Button filterSearchButton;
        ///// <summary>
        ///// The QID for the content
        ///// </summary>
        ///// <returns>QID for the content</returns>
        //protected override QID GetContentQID()
        //{
        //    return ControlQIDs.ContentQID;
        //}

        /// <summary>
        /// The DataGrid Filter 
        /// </summary>
        public TextBox FilterTextBox
        {
            get
            {
              //  if (this.filterTextBox == null)
                {
                    this.filterTextBox = new TextBox(Content, this.GetFilterGridQID());
                }

                return this.filterTextBox;
            }
            set
            {
              //  if (this.filterTextBox == null)
                {
                    this.filterTextBox = new TextBox(Content, this.GetFilterGridQID());
                }

                this.filterTextBox = value;
            }
        }

        /// <summary>
        /// The DataGrid Filter 
        /// </summary>
        public Button FilterCloseButton
        {
            get
            {
                //if (this.filterCloseButton == null)
                {
                    this.filterCloseButton = new Button(this.Content, this.GetFilterCloseButtonQID());
                }

                return this.filterCloseButton;
            }

        }

        /// <summary>
        /// The DataGrid Filter 
        /// </summary>
        public Button FilterSearchButton
        {
            get
            {
                this.filterSearchButton = new Button(this.Content, this.GetFilterSearchBUttonQID());
                return this.filterSearchButton;
            }
        }

        /// <summary>
        /// Set Filter TextBox
        /// </summary>
        /// <param name="text">value to set</param>
        /// <returns>if the textbox text is expected</returns>
        public bool SetFilterTextBoxText(string text)
        {
            bool result = CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(
                  delegate()
                  {
                      //Reset text box
                      if (this.FilterTextBox.Text != string.Empty)
                      {
                          Mom.Test.UI.Core.Common.Utilities.TakeScreenshot("SetFilterTextBoxText");
                          this.FilterTextBox.Text = string.Empty;
                      }

                      //Set text box
                      this.FilterTextBox.ScreenElement.WaitForReady();
                      this.FilterTextBox.SetValueWithPaste(text);
                      Mom.Test.UI.Core.Common.Utilities.LogMessage("SetFilterTextBoxText:: Current text is " + this.FilterTextBox.Text);
                      return this.FilterTextBox.Text == text;
                  },
                  Mom.Test.UI.Core.Common.Constants.OneMinute
                  );

            return result;
        }

    }
}
