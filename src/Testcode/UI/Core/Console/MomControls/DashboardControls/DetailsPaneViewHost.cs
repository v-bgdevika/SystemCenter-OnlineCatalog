namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;
    //using Dump;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;

    //TO Do Move This To SeperateClass called InlinedetailpaneviewHost
    public class InlineDetailsPaneHost : Control
    {
        Window Content = null;

        #region QIDs
        //public Window Content
        //{
        //    get
        //    {
        //        if (this.content == null)
        //        {
        //            this.content = new Maui.Core.WinControls.Control(
        //                new Window(
        //                    this,
        //                    this.GetContentQID(),
        //                    60000)
        //                    );
        //        }

        //        return this.content;
        //    }
        //}
        /// <summary>
        /// This is a list of default QIDs for the controls on the view
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the content
            /// </summary>
            public static QID ContentQID = new QID(";[UIA]ClassName = 'DataGridDetailsPresenter'");

            /// <summary>
            /// QID for the details pane
            /// </summary>
            public static QID DetailsQID = new QID(";[UIA]ClassName = 'GenericPane';[UIA]ClassName = 'ScrollViewer'");

            
        }

        ///// <summary>
        ///// Gets the QID for the Content
        ///// </summary>
        ///// <returns>QID of the content</returns>
        //protected override QID GetContentQID()
        //{
        //    return ControlQIDs.ContentQID;
        //}

        /// <summary>
        /// Gets the QID for the Details
        /// </summary>
        /// <returns>QID of the Details</returns>
        protected  QID GetDetailsQID()
        {
            return ControlQIDs.DetailsQID;
        }

        

        #endregion

        /// <summary>
        /// Initializes a new instance of the DetailsPaneViewHost class
        /// </summary>
        /// <param name="knownWindow"></param>
        public InlineDetailsPaneHost(Window knownWindow)
            : base(knownWindow)
        {
            Content = knownWindow;
        }

        /// <summary>
        /// The property name-value pairs
        /// </summary>
        public virtual Dictionary<string, string> Details
        {
            get
            {
                Dictionary<string, string> details = new Dictionary<string, string>();

                // The property name value pairs are in a stack panel
                AutomationElement automationElement = this.Content.ScreenElement.FindByPartialQueryId(this.GetDetailsQID().QueryID, null).AutomationElement as AutomationElement;

                // Extract the name value pairs
                string propName = "";
                string propValue = "";
                foreach (AutomationElement screenElement in automationElement.FindAll(TreeScope.Children, Condition.TrueCondition))
                {
                    string automationId = screenElement.Current.AutomationId;

                    int childCount = screenElement.FindAll(TreeScope.Children, Condition.TrueCondition).Count;
                   // System.Windows.Forms.MessageBox.Show(automationId + " : " + childCount.ToString());

                    if (automationId.Equals("PropertyDisplayName"))
                    {
                        propName = screenElement.FindFirst(TreeScope.Children, Condition.TrueCondition).Current.Name;
                    }
                    else
                    {
                        if (automationId.Equals("PropertyValue"))
                        {
                            propValue = "";

                            // When the property value is empty, at times, the screen element does not have children
                            // and this is perfectly normal
                            try
                            {
                                propValue = screenElement.FindFirst(TreeScope.Children, Condition.TrueCondition).Current.Name;
                            }
                            catch (Exception)
                            {
                            }

                            // accumalate the propery
                            details.Add(propName, propValue);
                        }
                    }
                }

                return details;
            }
        }
    }
    /// <summary>
    /// This class represnts a view that has the details pane as the content
    /// </summary>
    public class DetailsPaneViewHost : ViewHost
    {
        #region QIDs

        /// <summary>
        /// This is a list of default QIDs for the controls on the view
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the content
            /// </summary>
            public static QID ContentQID = new QID(";[UIA]ClassName = 'ComponentContainer'");

            /// <summary>
            /// QID for the details pane
            /// </summary>
            public static QID DetailsQID = new QID(";[UIA]ClassName = 'GenericPane';[UIA]ClassName = 'ScrollViewer'");

            /// <summary>
            /// QID for the property name
            /// </summary>
            public static QID PropertyNameQID;

            /// <summary>
            /// QID for the property value
            /// </summary>
            public static QID PropertyValueQID;
        }

        /// <summary>
        /// Gets the QID for the Content
        /// </summary>
        /// <returns>QID of the content</returns>
        protected override QID GetContentQID()
        {
            return ControlQIDs.ContentQID;
        }

        /// <summary>
        /// Gets the QID for the Details
        /// </summary>
        /// <returns>QID of the Details</returns>
        protected virtual QID GetDetailsQID()
        {
            return ControlQIDs.DetailsQID;
        }

        /// <summary>
        /// Gets the QID for the PropertyName
        /// </summary>
        /// <returns>QID of the PropertyName</returns>
        protected virtual QID GetPropertyNameQID()
        {
            return ControlQIDs.PropertyNameQID;
        }

        /// <summary>
        /// Gets the QID for the PropertyValue
        /// </summary>
        /// <returns>QID of the PropertyValue</returns>
        protected virtual QID GetPropertyValueQID()
        {
            return ControlQIDs.PropertyValueQID;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the DetailsPaneViewHost class
        /// </summary>
        /// <param name="knownWindow"></param>
        public DetailsPaneViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        /// <summary>
        /// The property name-value pairs
        /// </summary>
        public virtual Dictionary<string, string> Details
        {
            get
            {
                Dictionary<string, string> details = new Dictionary<string, string>();

                // The property name value pairs are in a stack panel
                var queryId = this.GetDetailsQID().QueryID;
                var screenElementOfDetailsPane = this.Content.ScreenElement.FindByPartialQueryId(queryId, null);
                if (screenElementOfDetailsPane == null)
                {
                    throw new Exception("screenElementOfDetailsPane is null");
                }

                var automationElement = screenElementOfDetailsPane.AutomationElement as AutomationElement;
                if (automationElement == null)
                {
                    throw new Exception("automationElement is null");
                }

                // Extract the name value pairs
                string propName = "";
                string propValue = "";
                foreach (AutomationElement screenElement in automationElement.FindAll(TreeScope.Children, Condition.TrueCondition))
                {
                    string automationId = screenElement.Current.AutomationId;

                    if (automationId.Equals("PropertyDisplayName"))
                    {
                        var automationElementOfDisplayName = screenElement.FindFirst(TreeScope.Children, Condition.TrueCondition);
                        if (automationElementOfDisplayName == null)
                        {
                            propName = "";
                        }
                        else
                        {
                            propName = automationElementOfDisplayName.Current.Name;
                        }
                    }
                    else
                    {
                        if (automationId.Equals("PropertyValue"))
                        {
                            propValue = "";

                            // When the property value is empty, at times, the screen element does not have children
                            // and this is perfectly normal
                            try
                            {
                                var automationElementOfValue = screenElement.FindFirst(TreeScope.Children, Condition.TrueCondition);
                                if (automationElementOfValue == null)
                                {
                                    throw new Exception("automationElementOfValue is null");
                                }

                                propValue = automationElementOfValue.Current.Name;
                            }
                            catch (Exception)
                            {
                            }

                            // accumalate the propery
                            if (propName != "")
                            {
                                details.Add(propName, propValue);
                            }
                        }
                    }
                }

                return details;
            }
        }
    }
}