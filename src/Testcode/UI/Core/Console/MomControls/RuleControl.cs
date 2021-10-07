// ---------------------------------------------------------------------------
// <copyright company="Microsoft" file="RuleControl.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  WPF GridView Filter Rule Control class.
// </summary>
// <history>
//  [mbickle] 23JUN08 Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Maui.GlobalExceptions;
    #endregion

    #region Interface Definition - IRuleControlControls

    /// ----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRuleControlControls, for RuleControl.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [mbickle] 18AUG08 Created
    /// </history>
    /// ----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRuleControlControls
    {
        /// <summary>
        /// Read-only property to access DeleteRowButton
        /// </summary>
        Button DeleteRowButton
        {
            get;
        }

        /// <summary>
        /// Search Criteria Text Box
        /// </summary>
        TextBox SearchCriteriaTextBox
        {
            get;
        }

        /// <summary>
        /// Operator Label
        /// </summary>
        StaticControl OperatorLabel
        {
            get;
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// RuleControl Class
    /// </summary>
    /// <history>
    /// [mbickle] 18AUG08 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class RuleControl : Window, IRuleControlControls
    {
        #region Member Variables
        /// <summary>
        /// NoIndex
        /// </summary>
        private const int NoIndex = -1;

        /// <summary>
        /// RuleControl ScreenElement
        /// </summary>
        private IScreenElement ruleControlScreenElement;

        /// <summary>
        /// GridView Window
        /// </summary>
        private Window gridViewWindow;
        #endregion

        #region Constructor
        /// --------------------------------------------------------------
        /// <summary>
        /// RuleControl
        /// </summary>
        /// <param name="window">GridView Window</param>
        /// --------------------------------------------------------------
        public RuleControl(Window window)
            : base(window)
        {
            this.Init(window, NoIndex, null);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// RuleControl
        /// </summary>
        /// <param name="screenElement">ScreenElement</param>
        /// --------------------------------------------------------------
        public RuleControl(IScreenElement screenElement)
            : base(screenElement)
        {
            this.Init(CoreManager.MomConsole.ViewPane, NoIndex, screenElement);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// RuleControl
        /// </summary>
        /// <param name="window">GridView Window</param>
        /// <param name="itemIndex">Item Index</param>
        /// --------------------------------------------------------------
        public RuleControl(Window window, int itemIndex)
            : base(window)
        {
            this.Init(window, itemIndex, null);
        }
        #endregion

        #region Enums
        /// <summary>
        /// Rule Operators
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1717:OnlyFlagsEnumsShouldHavePluralNames", Justification = "Singular conflicts with reserved keyword.")]
        public enum Operators
        {
            /// <summary>
            /// Begins With
            /// </summary>
            BeginsWith,

            /// <summary>
            /// Contains
            /// </summary>
            Contains,

            /// <summary>
            /// Does not Contain
            /// </summary>
            DoesNotContain,

            /// <summary>
            /// Does not Equal
            /// </summary>
            DoesNotEqual,

            /// <summary>
            /// Ends With
            /// </summary>
            EndsWith,

            /// <summary>
            /// Equals
            /// </summary>
            Equals,

            /// <summary>
            /// Is Empty
            /// </summary>
            IsEmpty,

            /// <summary>
            /// Is not Empty
            /// </summary>
            IsNotEmpty,
             
            /// <summary>
            /// Starts with
            /// </summary>
            StartsWith
        }
        #endregion

        #region IRuleControl Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this Control
        /// </summary>
        /// <value>An interface that groups all of this control properties together</value>
        /// <history>
        ///   [mbickle] 18AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRuleControlControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Properties
        /// --------------------------------------------------------------
        /// <summary>
        /// Owner GridViewFilter for this item.
        /// </summary>
        /// --------------------------------------------------------------
        public Window ParentGridViewFilter
        {
            get
            {
                return this.gridViewWindow;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Returns the 0 based index for a given RuleControl.
        /// </summary>
        /// <exception cref="WunderBar.Exceptions.WunderBarItemNotFoundException">
        /// WunderBar.Exceptions.WunderBarItemNotFoundException
        /// </exception>
        /// --------------------------------------------------------------
        public int Index
        {
            get
            {
                IScreenElement parentElement;
                int tempIndex = 0;

                parentElement = this.gridViewWindow.ScreenElement;
                foreach (IScreenElement childElement in parentElement.FindAllDescendants(-1, ";[UIA]AutomationId = ~'RuleControl*'", null))
                {
                    if (this.ruleControlScreenElement.Equals(childElement))
                    {
                        return tempIndex;
                    }
                    else
                    {
                        tempIndex += 1;
                    }
                }

                throw new System.InvalidOperationException("Could not find matching RuleControl item retrieving RuleControl.Index property");
            }
        }

        /// <summary>
        /// Search Criteria Text Box
        /// </summary>
        /// <history>
        ///     [2008-12-19] nathnovi: Added work-around for focus issue.
        ///     [2009-03-18] nathnovi: Removed work-around for focus issue
        /// </history>
        public string SearchCriteria
        {
            get
            {
                // Get current value of Text Box.
                return this.Controls.SearchCriteriaTextBox.Text;
            }

            set
            {
                // Set the current text box
                this.Controls.SearchCriteriaTextBox.Text = value;
            }
        }

        /// <summary>
        /// Operator Label
        /// </summary>
        public string OperatorLabel
        {
            get
            {
                // Get current value of Text Box.
                return this.Controls.OperatorLabel.Text;
            }
        }
        #endregion

        #region Control Properties
        /// --------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Operator Label
        /// </summary>
        /// <history>
        ///   [mbickle] 8/13/2008 Created
        /// </history>
        /// --------------------------------------------------------------
        StaticControl IRuleControlControls.OperatorLabel
        {
            get
            {
                Utilities.LogMessage(string.Format("Looking for OperatorLabel text"));
                return new StaticControl(this, QueryIds.Operator);
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeleteButton control
        /// </summary>
        /// <history>
        ///   [mbickle] 8/13/2008 Created
        /// </history>
        /// --------------------------------------------------------------
        Button IRuleControlControls.DeleteRowButton
        {
            get
            {
                return new Button(this, QueryIds.DeleteRowButton);
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Search Criteria TextBox control
        /// </summary>
        /// <history>
        ///   [mbickle] 8/13/2008 Created
        /// </history>
        /// --------------------------------------------------------------
        TextBox IRuleControlControls.SearchCriteriaTextBox
        {
            get
            {
                return new TextBox(this, QueryIds.SearchCriteria);
            }
        }
        #endregion

        #region Public Static
        /// <summary>
        /// Gets the Text value of Operator Enum
        /// </summary>
        /// <param name="operatorEnum">Operators Enum</param>
        /// <returns>Operator Enum String</returns>
        public static string GetTextOperatorName(Operators operatorEnum)
        {
            switch (operatorEnum)
            {
                case Operators.BeginsWith:
                    return Strings.BeginsWith;
                case Operators.Contains:
                    return Strings.Contains;
                case Operators.DoesNotContain:
                    return Strings.DoesNotContain;
                case Operators.DoesNotEqual:
                    return Strings.DoesNotEqual;
                case Operators.EndsWith:
                    return Strings.EndsWith;
                case Operators.Equals:
                    return Strings.EqualsText;
                case Operators.IsEmpty:
                    return Strings.IsEmpty;
                case Operators.IsNotEmpty:
                    return Strings.IsNotEmpty;
                case Operators.StartsWith:
                    return Strings.StartsWith;
                default:
                    throw new System.InvalidOperationException("RuleControl.GetTextOperatorName:: Invalid Enum: " + operatorEnum.ToString());
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Sets the Rule Operator
        /// </summary>
        /// <param name="ruleOperator">Operator</param>            
        public void SetOperator(Operators ruleOperator)
        {
            // AutomationId = PART_SelectedLabel = Operator Link. 
            //                Should allow setting, and if it's already set to specified value, do nothing.
            //                Otherwise, brings up Window with ListBox of Items.  AutomationId =
            //                PART_ListControl and select desired item.
            const string MethodName = "RuleControl.SetOperator";
            Utilities.LogMessage(string.Format("RuleControl.SetOperator:: Looking for Operator drop down list"));
            string ruleOperatorText = GetTextOperatorName(ruleOperator);
            IScreenElement currentOperatorControl = CoreManager.MomConsole.MainWindow.ScreenElement.FindByPartialQueryId(";[UIA]AutomationId => 'OperatorDropDownButton'", null);

            Utilities.LogMessage("RuleControl.SetOperator:: OperatorLabel: '" + currentOperatorControl.Name + "'");
            Utilities.LogMessage("RuleControl.SetOperator:: ruleOperatorText: '" + ruleOperatorText + "'");

            if (currentOperatorControl.Name != ruleOperatorText)
            {
                currentOperatorControl.LeftButtonClick(-1, -1);
                Sleeper.Delay(1000);
                Utilities.LogMessage("RuleControl.SetOperator:: QID: " + ";[UIA, VisibleOnly]Name => '" + ruleOperatorText + "'");

                ////IScreenElement element = currentOperatorControl.FindByPartialQueryId(";[UIA, VisibleOnly]Name => '" + ruleOperatorText + "'", null);
                MauiCollection<IScreenElement> elements = currentOperatorControl.FindAllDescendants(1, ";[UIA, VisibleOnly, FindAll]Role = 'list item'", null);
                bool found = false;
                Utilities.LogMessage(String.Format("{0}:Elements {1}", MethodName, elements.Count));
                foreach (IScreenElement el in elements)
                {
                    // Utilities.LogMessage("{0}::Element - {1} - x:{2} y:{3}", MethodName, el.Name, el.GetClickablePoint().X, el.GetClickablePoint().Y);
                    Utilities.LogMessage(String.Format("{0}::Element - {1}", MethodName, el.Name));
                    if (el.Name.Equals(ruleOperatorText))
                    {
                        // LeftButtonClick() isn't working for some reason 
                        // on .NET 4 RC, so using Select().
                        el.Select();
                        
                        // Close dropdown.
                        el.SendKeys(KeyboardCodes.Esc);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Utilities.LogMessage("RuleControl.SetOperator::rule operator not found");
                }
            }

            // Sleeper.Delay(500);

            // retry code
            ////int count = 0;
            ////while ((currentOperatorControl.Name != ruleOperatorText) && (count < 3))
            ////{
            ////    currentOperatorControl.LeftButtonClick(-1, -1);
            ////    Sleeper.Delay(1000);

            ////    IScreenElement element = currentOperatorControl.FindByPartialQueryId(";[UIA, VisibleOnly]Name => '" + ruleOperatorText + "'", null);
            ////    MauiCollection<IScreenElement> elements = currentOperatorControl.FindAllDescendants(1, ";[UIA, FindAll]", null);
            ////    Utilities.LogMessage("{0}:Elements {1}", MethodName, elements.Count);
            ////    bool found = false;
            ////    foreach (IScreenElement el in elements)
            ////    {
            ////        // Utilities.LogMessage("{0}::Element - {1} - x:{2} y:{3}", MethodName, el.Name, el.GetClickablePoint().X, el.GetClickablePoint().Y);
            ////        Utilities.LogMessage("{0}::Element - {1}", MethodName, el.Name);
            ////        if (el.Name.Equals(ruleOperatorText))
            ////        {
            ////            el.LeftButtonClick(-1, -1);
            ////            found = true;
            ////            break;
            ////        }
            ////    }
 
            ////    if (!found)
            ////    {
            ////        Utilities.LogMessage("RuleControl.SetOperator::rule operator not found");
            ////    }

            ////    Sleeper.Delay(500);
            ////    count++;
            ////}

            if (currentOperatorControl.Name != ruleOperatorText)
            {
                Utilities.TakeScreenshot("RuleControl_SetOperator_CouldNotSetOperator");
                throw new RuleControl.Exceptions.RuleNotSetException(string.Format("Could not set the rule operator.  Current is {0}. Attempted to set to {1}", currentOperatorControl.Name, ruleOperatorText));
            }
        }

        /// <summary>
        /// Delete Rule
        /// </summary>
        public void ClickDelete()
        {
            // Click Delete Button
            this.Controls.DeleteRowButton.Click();
        }

        #endregion

        #region Private Methods
        /// --------------------------------------------------------------
        /// <summary>
        /// Initialize the Rule Control
        /// </summary>
        /// <param name="parentWindow">GridView Window</param>
        /// <param name="itemIndex">Item Index</param>
        /// <param name="screenElement">ScreenElement</param>
        /// <exception cref="System.InvalidOperationException">System.InvalidOperationException</exception>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// --------------------------------------------------------------
        private void Init(
            Window parentWindow,
            int itemIndex,
            IScreenElement screenElement)
        {
            IScreenElement parentElement;
            int searchIndex;

            if (!(parentWindow == null))
            {
                this.gridViewWindow = parentWindow;
                if (!(screenElement == null))
                {
                    // we have a known ScreenElement object and WunderBar
                    this.ruleControlScreenElement = screenElement;
                }
                else
                {
                    // we must be searching RuleControls
                    parentElement = parentWindow.ScreenElement;
                    try
                    {
                        if (itemIndex > -1)
                        {
                            searchIndex = itemIndex;
                            foreach (IScreenElement childElement in parentElement.FindAllDescendants(-1, QueryIds.RuleControls.ToString(), null))
                            {
                                // make sure we're the correct visible state, we are not 0-height or 0 width
                                if (searchIndex == 0)
                                {
                                    // found it
                                    this.ruleControlScreenElement = childElement;
                                    return;
                                }
                                else
                                {
                                    // we just skipped over one valid item
                                    searchIndex = (searchIndex - 1);
                                }
                            }

                            throw new System.InvalidOperationException(
                                "RuleControl.Init:: Could not find item as index " + itemIndex +
                                " in the set of children");
                        }
                    }
                    catch (System.InvalidOperationException except)
                    {
                        throw new System.InvalidOperationException(
                            "RuleControl.Init:: Can not find the RuleControl item",
                            except);
                    }
                }
            }
            else
            {
                throw new System.ArgumentException(
                    "RuleControl.Init:: You must provide a valid GridViewFilter object as the parent");
            }
        }
        #endregion

        #region Exceptions

        /// <summary>
        /// Rule control exceptions
        /// </summary>
        public static new class Exceptions
        {
            /// <summary>
            /// Rule not set exception
            /// </summary>
            [Serializable()]
            public class RuleNotSetException : MauiException
            {
                /// <summary>
                /// Default rule not set constructor
                /// </summary>
                public RuleNotSetException()
                    : base()
                {
                }

                /// <summary>
                /// Rule not set constructor with message
                /// </summary>
                /// <param name="message">Error message</param>
                public RuleNotSetException(string message)
                    : base(message)
                {
                }

                /// <summary>
                /// Rule not set constructor with message and inner exception
                /// </summary>
                /// <param name="message">Error message</param>
                /// <param name="innerException">Inner exception</param>
                public RuleNotSetException(string message, Exception innerException)
                    : base(message, innerException)
                {
                }

                /// <summary>
                /// Rule not set exception constructor
                /// </summary>
                /// <param name="info">serialization info</param>
                /// <param name="context">streaming context</param>
                protected RuleNotSetException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
        }

        #endregion Exceptions
        
        #region Strings
        /// <summary>
        /// Strings Class
        /// </summary>
        public static class Strings
        {
            #region Constants
            /// <summary>
            /// Resource String for 'begins with'
            /// </summary>
            ////private const string ResourceBeginsWith = ";begins with;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_BEGINSWITH";
            private const string ResourceBeginsWith = "begins with";

            /// <summary>
            /// Resource String for 'starts with'
            /// </summary>
            ////private const string ResourceStartsWith = ";begins with;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_TextStartsWith";
            private const string ResourceStartsWith = ";starts with;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_TextStartsWith";

            /// <summary>
            /// Resource String for 'contains'
            /// </summary>
            ////private const string ResourceContains = ";contains;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_CONTAINS";
            private const string ResourceContains = ";contains;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_Contains";

            /// <summary>
            /// Resource String for 'does not contain'
            /// </summary>
            /// 
            ////private const string ResourceDoesNotContain = ";does not contain;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.resources.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_DoesNotContain";
            private const string ResourceDoesNotContain = ";does not contain;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_DoesNotContain";                                
            
            /// <summary>
            /// Resource String for 'does not equal'
            /// </summary>
            ////private const string ResourceDoesNotEqual = ";does not equal;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_DOESNOTEQUAL";
            private const string ResourceDoesNotEqual = ";does not equal;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_DoesNotEqual";
            
            /// <summary>
            /// Resource String for 'ends with'
            /// </summary>
            ////private const string ResourceEndsWith = ";ends with;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_ENDSWITH";
            private const string ResourceEndsWith = ";ends with;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_TextEndsWith";

            /// <summary>
            /// Resource String for 'equals'
            /// </summary>
            ////private const string ResourceEquals = ";equals;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_EQUALS";
            private const string ResourceEquals = ";equals;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_Equals";

            /// <summary>
            /// Resource String for 'is empty'
            /// </summary>
            ////private const string ResourceIsEmpty = ";is empty;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_ISEMPTY";
            private const string ResourceIsEmpty = ";is empty;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_IsEmpty";

            /// <summary>
            /// Resource String for 'is not empty'
            /// </summary>
            ////private const string ResourceIsNotEmpty = ";is not empty;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;ID_TEXT_ISNOTEMPTY";
            private const string ResourceIsNotEmpty = ";is not empty;ManagedString;Microsoft.EnterpriseManagement.UI.Controls.dll;Microsoft.EnterpriseManagement.UI.Controls.MuxShared.UICultureResources;FilterRule_IsNotEmpty";
            #endregion

            #region Member Variables
            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedBeginsWith;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedContains;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedDoesNotContain;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedDoesNotEqual;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedEndsWith;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedEquals;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedIsEmpty;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedIsNotEmpty;

            /// <summary>
            /// Cached Resource
            /// </summary>
            private static string cachedStartsWith;
            #endregion

            #region Properties
            /// <summary>
            /// Resource 'begins with'
            /// </summary>
            public static string BeginsWith
            {
                get
                {
                    if (null == cachedBeginsWith)
                    {
                        cachedBeginsWith = CoreManager.MomConsole.GetIntlStr(ResourceBeginsWith);
                    }

                    return cachedBeginsWith;
                }
            }

            /// <summary>
            /// Resource 'starts with'
            /// </summary>
            public static string StartsWith
            {
                get
                {
                    if (null == cachedStartsWith)
                    {
                        cachedStartsWith = CoreManager.MomConsole.GetIntlStr(ResourceStartsWith);
                    }

                    return cachedStartsWith;
                }
            }

            /// <summary>
            /// Resource 'contains'
            /// </summary>
            public static string Contains
            {
                get
                {
                    if (null == cachedContains)
                    {
                        cachedContains = CoreManager.MomConsole.GetIntlStr(ResourceContains);
                    }

                    return cachedContains;
                }
            }

            /// <summary>
            /// Resource 'does not contain'
            /// </summary>
            public static string DoesNotContain
            {
                get
                {
                    if (null == cachedDoesNotContain)
                    {
                        cachedDoesNotContain = CoreManager.MomConsole.GetIntlStr(ResourceDoesNotContain);
                    }

                    return cachedDoesNotContain;
                }
            }

            /// <summary>
            /// Resource 'does not equal'
            /// </summary>
            public static string DoesNotEqual
            {
                get
                {
                    if (null == cachedDoesNotEqual)
                    {
                        cachedDoesNotEqual = CoreManager.MomConsole.GetIntlStr(ResourceDoesNotEqual);
                    }

                    return cachedDoesNotEqual;
                }
            }

            /// <summary>
            /// Resource 'ends with'
            /// </summary>
            public static string EndsWith
            {
                get
                {
                    if (null == cachedEndsWith)
                    {
                        cachedEndsWith = CoreManager.MomConsole.GetIntlStr(ResourceEndsWith);
                    }

                    return cachedEndsWith;
                }
            }

            /// <summary>
            /// Resource 'equals'
            /// </summary>
            public static string EqualsText
            {
                get
                {
                    if (null == cachedEquals)
                    {
                        cachedEquals = CoreManager.MomConsole.GetIntlStr(ResourceEquals);
                    }

                    return cachedEquals;
                }
            }

            /// <summary>
            /// Resource 'is empty'
            /// </summary>
            public static string IsEmpty
            {
                get
                {
                    if (null == cachedIsEmpty)
                    {
                        cachedIsEmpty = CoreManager.MomConsole.GetIntlStr(ResourceIsEmpty);
                    }

                    return cachedIsEmpty;
                }
            }

            /// <summary>
            /// Resource 'is not empty'
            /// </summary>
            public static string IsNotEmpty
            {
                get
                {
                    if (null == cachedIsNotEmpty)
                    {
                        cachedIsNotEmpty = CoreManager.MomConsole.GetIntlStr(ResourceIsNotEmpty);
                    }

                    return cachedIsNotEmpty;
                }
            }
            #endregion
        }
        #endregion

        #region QueryIds
        /// <summary>
        /// Query Ids
        /// </summary>
        public static class QueryIds
        {
            #region Constants
            /// <summary>
            /// QID for Rule Controls
            /// </summary>
            private const string QueryIdRuleControls = ";[UIA, FindAll]AutomationId = 'FilterRulePanelItem'";

            /// <summary>
            /// QID for Logical Operator Label
            /// </summary>
            private const string QueryIdLogicalOperatorLabel = ";[UIA]AutomationId = 'logicalOperatorLabel'";

            /// <summary>
            /// QID for Operators
            /// </summary>
            ////private const string QueryIdOperator = ";[UIA]AutomationId = 'PART_SelectedLabel'";
            private const string QueryIdOperator = ";[UIA]AutomationId = 'OperatorDropDownButton'";

            /// <summary>
            /// QID for Operator ListBox
            /// </summary>
            ////private const string QueryIdOperatorListBox = ";[UIA]AutomationId = 'PART_ListControl'";
            private const string QueryIdOperatorListBox = ";[UIA]AutomationId = 'OperatorDropDownButton'";

            /// <summary>
            /// QID for Search Criteria Text Box
            /// </summary>
            private const string QueryIdSearchCriteria = ";[UIA]AutomationId = 'InputField'";

            /// <summary>
            /// QID for Delete Row Button
            /// </summary>
            private const string QueryIdDeleteButton = ";[UIA]AutomationId = 'RemoveFilterRulePanelItemButton'";
            #endregion

            #region Properties
            /// <summary>
            /// QID Rule Controls (FindAll)
            /// </summary>
            public static QID RuleControls
            {
                get
                {
                    return new QID(QueryIdRuleControls);
                }
            }

            /// <summary>
            /// QID Logical Operator Label
            /// </summary>
            public static QID LogicalOperator
            {
                get
                {
                    return new QID(QueryIdLogicalOperatorLabel);
                }
            }

            /// <summary>
            /// QID Operator
            /// </summary>
            public static QID Operator
            {
                get
                {
                    return new QID(QueryIdOperator);
                }
            }

            /// <summary>
            /// QID Operator ListBox
            /// </summary>
            public static QID OperatorListBox
            {
                get
                {
                    return new QID(QueryIdOperatorListBox);
                }
            }

            /// <summary>
            /// QID Search Criteria
            /// </summary>
            public static QID SearchCriteria
            {
                get
                {
                    return new QID(QueryIdSearchCriteria);
                }
            }

            /// <summary>
            /// QID Delete Row Button
            /// </summary>
            public static QID DeleteRowButton
            {
                get
                {
                    return new QID(QueryIdDeleteButton);
                }
            }
            #endregion
        }
        #endregion

        #region RuleControlCollection Class
        /// ------------------------------------------------------------------
        /// <summary>
        /// RuleControlCollection Class
        /// </summary>
        /// <history>
        /// [mbickle] 18AUG08 Created
        /// </history>
        /// ------------------------------------------------------------------
        [Serializable()]
        public class RuleControlCollection : Collection<RuleControl>
        {
            #region Member Variables
            /// <summary>
            /// NoIndex
            /// </summary>
            private const int NoIndex = -1;
            #endregion

            #region Constructors
            /// --------------------------------------------------------------
            /// <summary>
            /// WunderBarItemCollection Constructor
            /// </summary>
            /// --------------------------------------------------------------
            public RuleControlCollection()
                : base()
            {
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// RuleControlCollection
            /// </summary>
            /// <param name="parentFilter">Window</param>
            /// --------------------------------------------------------------
            public RuleControlCollection(Window parentFilter)
                : base(new Collection<RuleControl>())
            {
                IScreenElement parentElement;
                MauiCollection<IScreenElement> childElements;
                Utilities.LogMessage(string.Format("Getting rule collection"));
                if (!(parentFilter == null))
                {
                    // we must be searching RuleControls
                    parentElement = parentFilter.ScreenElement;
                    
                    childElements = parentElement.FindAllDescendants(-1, QueryIds.RuleControls.ToString(), null);
                    Utilities.LogMessage(string.Format("There are {0} rules", childElements.Count));
                    try
                    {
                        foreach (IScreenElement childElement in childElements)
                        {
                            this.Add(new RuleControl(childElement));
                        }
                    }
                    catch (System.InvalidOperationException except)
                    {
                        throw new System.InvalidOperationException(
                            "RuleControl.Init:: Can not find the RuleControl item",
                            except);
                    }

                    Utilities.LogMessage(string.Format("Done retrieving rule collection"));
                }
                else
                {
                    throw new System.ArgumentException(
                        "RuleControl.Init:: You must provide a valid GridViewFilter object as the parent");
                }
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// RuleControlCollection Constructor
            /// </summary>
            /// <param name="value">RuleControl[]</param>
            /// --------------------------------------------------------------
            public RuleControlCollection(RuleControl[] value)
                : base()
            {
                this.AddRange(value);
            }
            #endregion

            #region Properties
            #endregion

            #region Methods
            /// --------------------------------------------------------------
            /// <summary>
            /// Copies the elements of an array to the end of the 
            /// RuleControlCollection 
            /// </summary>
            /// <param name="value">Value</param>
            /// --------------------------------------------------------------
            public void AddRange(RuleControl[] value)
            {
                int i = 0;

                while (i < value.Length)
                {
                    this.Add(value[i]);
                    i = (i + 1);
                }
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Adds contents of another RuleControlCollection to the end 
            /// of the collection
            /// </summary>
            /// <param name="value">RuleControlCollection</param>
            /// --------------------------------------------------------------
            public void AddRange(RuleControlCollection value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "RuleControl.AddRange:: value is null");
                }

                int i = 0;

                while (i < value.Count)
                {
                    this.Add(value[i]);
                    i = (i + 1);
                }
            }
            #endregion
        }
        #endregion
    }
}
