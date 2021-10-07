//-------------------------------------------------------------------
// <copyright file="UIASupport.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
// UIA Support Class.  Support methods to go directly to UIA 
// when RPF/MAUI just won't get us there.
// </summary>
//
// <history>
//  [mbickle] 25FEB09: Created
//  [mbickle] 24JUN09: Added IUIAElement Interface, exposed more AutomationElement properties.
// </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Automation;
    using Maui.Core;
    #endregion

    #region Interface
    /// <summary>
    /// IUIAElement Interface
    /// </summary>
    public interface IUIAElement
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// RuntimeId
        /// </summary>
        ReadOnlyCollection<int> RuntimeId
        {
            get;
        }

        /// <summary>
        /// AutomationId
        /// </summary>
        string AutomationId
        {
            get;
        }

        /// <summary>
        /// FrameworkId
        /// </summary>
        string FrameworkId
        {
            get;
        }

        /// <summary>
        /// IsOffscreen
        /// </summary>
        bool IsOffscreen
        {
            get;
        }

        /// <summary>
        /// IsEnabled
        /// </summary>
        bool IsEnabled
        {
            get;
        }

        /// <summary>
        /// ItemStatus
        /// </summary>
        string ItemStatus
        {
            get;
        }

        /// <summary>
        /// AcceleratorKey
        /// </summary>
        string AcceleratorKey
        {
            get;
        }

        /// <summary>
        /// HasKeyboardFocus
        /// </summary>
        bool HasKeyboardFocus
        {
            get;
        }

        /// <summary>
        /// CanSelectMultiple
        /// </summary>
        bool CanSelectMultiple
        {
            get;
        }

        /// <summary>
        /// RangeValueMaxMaximum
        /// </summary>
        int RangeValueMaximum
        {
            get;
        }

        /// <summary>
        /// RangeValueMinimum
        /// </summary>
        int RangeValueMinimum
        {
            get;
        }

        /// <summary>
        /// RangeValueCurrentValue
        /// </summary>
        int RangeValueCurrentValue
        {
            get;
        }

        /// <summary>
        /// RangeValueLargeChange
        /// </summary>
        int RangeValueLargeChange
        {
            get;
        }

        /// <summary>
        /// RangeValueSmallChange
        /// </summary>
        int RangeValueSmallChange
        {
            get;
        }

        /// <summary>
        /// TextSelectionStartPosition
        /// </summary>
        int TextSelectionStartPosition
        {
            get;
        }

        /// <summary>
        /// TextSelectionEndPosition
        /// </summary>
        int TextSelectionEndPosition
        {
            get;
        }

        /// <summary>
        /// TextSelectionSelectedText
        /// </summary>
        string TextSelectionSelectedText
        {
            get;
        }

        /// <summary>
        /// IsRightToLeftText
        /// </summary>
        bool IsRightToLeftText
        {
            get;
        }

        /// <summary>
        /// ToggleState
        /// </summary>
        ToggleState ToggleState
        {
            get;
            set;
        }

        /// <summary>
        /// SupportsRangeValue
        /// </summary>
        bool SupportsRangeValue
        {
            get;
        }

        /// <summary>
        /// SupportsToggle
        /// </summary>
        bool SupportsToggle
        {
            get;
        }

        /// <summary>
        /// SupportsExpandCollapse
        /// </summary>
        bool SupportsExpandCollapse
        {
            get;
        }

        /// <summary>
        /// SupportsSelection
        /// </summary>
        bool SupportsSelection
        {
            get;
        }

        /// <summary>
        /// GetColumnHeaderName
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>string</returns>
        string GetColumnHeaderName(int index);

        /// <summary>
        /// GetSelectedElement
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>IUIAElement</returns>
        IUIAElement GetSelectedElement(int index);

        /// <summary>
        /// SetRangeValue
        /// </summary>
        /// <param name="value">value</param>
        void SetRangeValue(int value);

        /// <summary>
        /// SetTextSelection
        /// </summary>
        /// <param name="selectionStart">selection start</param>
        /// <param name="selectionLength">selection length</param>
        void SetTextSelection(int selectionStart, int selectionLength);

        /// <summary>
        /// ExpandAll
        /// </summary>
        void ExpandAll();

        /// <summary>
        /// Expand
        /// </summary>
        void Expand();

        /// <summary>
        /// ScrollIntoView
        /// </summary>
        void ScrollIntoView();
    }
    #endregion

    /// <summary>
    /// UIA Support Class
    /// Helper methods mainly for AutomationElement from ScreenElements when
    /// need to use UIA directly.
    /// </summary>
    public sealed class UIASupport : IUIAElement
    {
        /// <summary>
        /// Automation Element
        /// </summary>
        private AutomationElement automationElement;

        #region Constructor
        /// <summary>
        /// UISupport Constructor
        /// </summary>
        /// <param name="automationElement">AutomationElement</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public UIASupport(AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                throw new ArgumentNullException("automationElement");
            }

            this.automationElement = automationElement;
        }

        /// <summary>
        /// UISupport Constructor
        /// </summary>
        /// <param name="screenElement">IScreenElement</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public UIASupport(IScreenElement screenElement)
        {
            if (screenElement == null)
            {
                throw new ArgumentNullException("screenElement");
            }

            this.automationElement = AutomationElementFromScreenElement(screenElement);
        }
        #endregion

        /// <summary>
        /// Gets the Automation Id for the UIA Element
        /// </summary>
        public string AutomationId
        {
            get
            {
                return this.automationElement.Current.AutomationId;
            }
        }

        /// <summary>
        /// Gets the Runtime Id for the UIA Element
        /// </summary>
        public ReadOnlyCollection<int> RuntimeId
        {
            get
            {
                return new ReadOnlyCollection<int>(this.automationElement.GetRuntimeId());
            }
        }

        /// <summary>
        /// Gets the Framework Id for the UIA Element.
        /// </summary>
        public string FrameworkId
        {
            get
            {
                return GetProperty<string>(AutomationElement.FrameworkIdProperty);
            }
        }

        /// <summary>
        /// Gets value indicating whether the UIA Element is off screen.
        /// </summary>
        public bool IsOffscreen
        {
            get
            {
                return GetProperty<bool>(AutomationElement.IsOffscreenProperty);
            }
        }

        /// <summary>
        /// Gets value indicating whether the UIA Element is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return GetProperty<bool>(AutomationElement.IsEnabledProperty);
            }
        }

        /// <summary>
        /// Gets the item status for the UIA Element
        /// </summary>
        public string ItemStatus
        {
            get
            {
                return GetProperty<string>(AutomationElement.ItemStatusProperty);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIA Element supports multiple item selection.
        /// </summary>
        public bool CanSelectMultiple
        {
            get
            {
                return GetPattern<SelectionPattern>(SelectionPattern.Pattern).Current.CanSelectMultiple;
            }
        }

        /// <summary>
        /// Gets the maximum value that can be set for a UIAElement that supports ranges.
        /// </summary>
        public int RangeValueMaximum
        {
            get
            {
                return (int)RangeValuePattern.Current.Maximum;
            }
        }

        /// <summary>
        /// Gets the minimum value that can be set for a UIAElement that supports ranges.
        /// </summary>
        public int RangeValueMinimum
        {
            get
            {
                return (int)RangeValuePattern.Current.Minimum;
            }
        }

        /// <summary>
        /// Gets the current value for the UIAElement that supports ranges.
        /// </summary>
        public int RangeValueCurrentValue
        {
            get
            {
                return (int)RangeValuePattern.Current.Value;
            }
        }

        /// <summary>
        /// Gets the "large change" value that can be set for a UIAElement that supports ranges.
        /// </summary>
        public int RangeValueLargeChange
        {
            get
            {
                return (int)RangeValuePattern.Current.LargeChange;
            }
        }

        /// <summary>
        /// Gets the "small change" value that can be set for a UIAElement that supports ranges.
        /// </summary>
        public int RangeValueSmallChange
        {
            get
            {
                return (int)RangeValuePattern.Current.SmallChange;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIAElement supports value ranges.
        /// </summary>
        public bool SupportsRangeValue
        {
            get
            {
                return SupportsPattern(RangeValuePattern.Pattern);
            }
        }

        /// <summary>
        /// Gets the value of the UIAElement
        /// </summary>
        public string Value
        {
            get
            {
                if (SupportsPattern(ValuePattern.Pattern))
                {
                    return GetPattern<ValuePattern>(ValuePattern.Pattern).Current.Value;
                }

                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the position where text selection starts for the UIA Element.
        /// </summary>
        public int TextSelectionStartPosition
        {
            get
            {
                int startPosition;
                TextPattern pattern = GetPattern<TextPattern>(TextPattern.Pattern);
                System.Windows.Automation.Text.TextPatternRange[] selection = pattern.GetSelection();
                if (selection == null)
                {
                    startPosition = -1;
                }
                else
                {
                    // Always get the first selection
                    System.Windows.Automation.Text.TextPatternRange selectionRange = selection[0].Clone();

                    // When text is inserted, it will always be inserted at the index corresponds to the index of selection start point. By getting the number of 
                    // characters the selection start point can move back to the start of the text, we can calculate the index of the insertion point
                    startPosition = Math.Abs(selectionRange.MoveEndpointByUnit(System.Windows.Automation.Text.TextPatternRangeEndpoint.Start, System.Windows.Automation.Text.TextUnit.Character, -this.Value.Length));
                }

                return startPosition;
            }
        }

        /// <summary>
        /// Gets the position where text selection ends for the UIA Element.
        /// </summary>
        public int TextSelectionEndPosition
        {
            get
            {
                TextPattern pattern = GetPattern<TextPattern>(TextPattern.Pattern);
                System.Windows.Automation.Text.TextPatternRange[] selection = pattern.GetSelection();
                System.Windows.Automation.Text.TextPatternRange selectionRange = selection[0].Clone();

                // By getting the number of characters the selection end point can move back to the start of the text, we can calculate 
                // the index of the selection end point
                return Math.Abs(selectionRange.MoveEndpointByUnit(System.Windows.Automation.Text.TextPatternRangeEndpoint.End, System.Windows.Automation.Text.TextUnit.Character, -this.Value.Length));
            }
        }

        /// <summary>
        /// Gets the selected text for the UIA Element.
        /// </summary>
        public string TextSelectionSelectedText
        {
            get
            {
                string selectedText;
                TextPattern pattern = GetPattern<TextPattern>(TextPattern.Pattern);
                System.Windows.Automation.Text.TextPatternRange[] selection = pattern.GetSelection();

                if (selection.Length == 0)
                {
                    selectedText = string.Empty;
                }
                else
                {
                    System.Windows.Automation.Text.TextPatternRange selectionRange = selection[0];
                    selectedText = selectionRange.GetText(-1);
                }

                return selectedText;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIA Element has mirred text.
        /// </summary>
        public bool IsRightToLeftText
        {
            get
            {
                bool rightToLeft = false;
                TextPattern pattern = GetPattern<TextPattern>(TextPattern.Pattern);
                System.Windows.Automation.Text.HorizontalTextAlignment horizontalTextAlignment = (System.Windows.Automation.Text.HorizontalTextAlignment)pattern.DocumentRange.GetAttributeValue(TextPattern.HorizontalTextAlignmentAttribute);

                if (horizontalTextAlignment == System.Windows.Automation.Text.HorizontalTextAlignment.Right)
                {
                    rightToLeft = true;
                }

                return rightToLeft;                    
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIA Element supports state toggling.
        /// </summary>
        public bool SupportsToggle
        {
            get
            {
                return GetProperty<bool>(AutomationElement.IsTogglePatternAvailableProperty);
            }
        }

        /// <summary>
        /// Gets the toggle state of the UIA Element.
        /// </summary>
        public ToggleState ToggleState
        {
            get
            {
                return GetPattern<TogglePattern>(TogglePattern.Pattern).Current.ToggleState;
            }

            set
            {
                if (SupportsPattern(TogglePattern.Pattern))
                {
                    TogglePattern togglePattern = GetPattern<TogglePattern>(TogglePattern.Pattern);

                    // If element is already in expected Toggle state do nothing,
                    // else Toggle.
                    if (!togglePattern.Current.ToggleState.Equals(value))
                    {
                        togglePattern.Toggle();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the accelerator key for the UIA Element.
        /// </summary>
        public string AcceleratorKey
        {
            get
            {
                return GetProperty<string>(AutomationElement.AcceleratorKeyProperty);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIA Element supports expand and collapse.
        /// </summary>
        public bool SupportsExpandCollapse
        {
            get
            {
                return GetProperty<bool>(AutomationElement.IsExpandCollapsePatternAvailableProperty);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIA Element has keyboard focus.
        /// </summary>
        public bool HasKeyboardFocus
        {
            get
            {
                return GetProperty<bool>(AutomationElement.HasKeyboardFocusProperty);
            }
        }

        /// <summary>
        /// Gets the name of the UIA Element.
        /// </summary>
        public string Name
        {
            get
            {
                return this.automationElement.Current.Name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the UIA Element supports selection.
        /// </summary>
        public bool SupportsSelection
        {
            get
            {
                return GetProperty<bool>(AutomationElement.IsSelectionItemPatternAvailableProperty);
            }
        }

        /// <summary>
        /// Gets the underling AutomationElement that is wrapped.
        /// </summary>
        public AutomationElement AutomationElement
        {
            get
            {
                return this.automationElement;
            }
        }

        /// <summary>
        /// Gets the ClassName of the UIA Element.
        /// </summary>
        public string ClassName
        {
            get
            {
                return this.automationElement.Current.ClassName;
            }
        }

        /// <summary>
        /// Gets the RangeValuePattern of the UIAElement
        /// </summary>
        private RangeValuePattern RangeValuePattern
        {
            get
            {
                return GetPattern<RangeValuePattern>(RangeValuePattern.Pattern);
            }
        }

        #region Public Static Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Get Current ToggleState for AutomationElement
        /// </summary>
        /// <param name="element">AutomationElement</param>
        /// <exception cref="System.InvalidOperationException">InvalidOperationException</exception>
        /// <returns>Toggle State</returns>
        /// <history>
        /// [mbickle] 25FEB09: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetToggleState(AutomationElement element)
        {
            string toggleState = string.Empty;

            if (SupportsPattern(element, TogglePattern.Pattern))
            {
                TogglePattern togglePattern = (TogglePattern)element.GetCurrentPattern(TogglePattern.Pattern);
                toggleState = togglePattern.Current.ToggleState.ToString();
            }
            else
            {
                throw new System.InvalidOperationException("Element does not support TogglePattern.");
            }

            return toggleState;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Toggle Element that supports TogglePattern On/Off
        /// </summary>
        /// <param name="element">AutomationElement to toggle</param>
        /// <param name="toggleState">ToggleState to set.</param>
        /// <history>
        /// [mbickle] 25FEB09: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void Toggle(AutomationElement element, ToggleState toggleState)
        {
            if (SupportsPattern(element, TogglePattern.Pattern))
            {
                TogglePattern togglePattern = (TogglePattern)element.GetCurrentPattern(TogglePattern.Pattern);

                // If element is already in expected Toggle state do nothing,
                // else Toggle.
                if (!togglePattern.Current.ToggleState.Equals(toggleState))
                {
                    togglePattern.Toggle();
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets all the Supported Patterns for Element.
        /// </summary>
        /// <param name="element">AutomatoinElement to get.</param>
        /// <returns>AutomatoinPatern[] collection</returns>
        /// <history>
        /// [mbickle] 25FEB09: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static AutomationPattern[] GetSupportedPatterns(AutomationElement element)
        {
            return element.GetSupportedPatterns();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Helper to report whether an AutomationElement supports a given pattern.
        /// </summary>
        /// <param name="element">AutomationElement to check</param>
        /// <param name="pattern">AutomationPattern desired</param>
        /// <returns>True if the Pattern is supported, False otherwise</returns>
        /// <history>
        /// [mbickle] 25FEB09: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool SupportsPattern(AutomationElement element, AutomationPattern pattern)
        {
            bool supported = false;

            // Get all supported patterns for element
            AutomationPattern[] patterns = element.GetSupportedPatterns();

            // Loop through all the Patterns to see if we match.
            foreach (AutomationPattern p in patterns)
            {
                if (p.Equals(pattern))
                {
                    supported = true;
                    break;
                }
            }

            return supported;
        }
        #endregion

        /// <summary>
        /// Expands the UIA element if it supports ExpandCollapsePattern. 
        /// </summary>
        public void Expand()
        {
            if (this.SupportsExpandCollapse)
            {
                ExpandCollapsePattern pattern = GetPattern<ExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
                if ((pattern.Current.ExpandCollapseState == ExpandCollapseState.Collapsed))
                {
                    pattern.Expand();
                }
            }
        }

        /// <summary>
        /// Expands all decendants of the UIA Element that support Expand collapse pattern. 
        /// </summary>
        public void ExpandAll()
        {
            this.Expand();
            TreeWalker w = TreeWalker.ControlViewWalker;
            AutomationElement child = w.GetFirstChild(this.AutomationElement);
            while (!(child == null))
            {
                UIASupport wrapper = new UIASupport(child);
                wrapper.ExpandAll();
                child = w.GetNextSibling(child);
            }
        }

        /// <summary>
        /// Scrolls the UIAElement into view. 
        /// </summary>
        public void ScrollIntoView()
        {
            this.GetPattern<ScrollItemPattern>(ScrollItemPattern.Pattern).ScrollIntoView();
        }

        /// <summary>
        /// Sets the range value of the UIAElement. 
        /// </summary>
        /// <param name="value">Value</param>
        public void SetRangeValue(int value)
        {
            this.RangeValuePattern.SetValue(value);
        }

        /// <summary>
        /// Sets the selected text frame of the UIAElement. 
        /// </summary>
        /// <param name="selectionStart">Selection Start</param>
        /// <param name="selectionLength">Length of Selection</param>
        public void SetTextSelection(int selectionStart, int selectionLength)
        {
            int textLength = this.Value.Length;
            TextPattern pattern = this.GetPattern<TextPattern>(TextPattern.Pattern);
            System.Windows.Automation.Text.TextPatternRange[] selection = pattern.GetSelection();
            if ((selectionStart == -1))
            {
                if ((selection == null))
                {
                    return;
                }
                else
                {
                    if ((selection == null))
                    {
                        return;
                    }
                    else
                    {
                        System.Windows.Automation.Text.TextPatternRange selectionRange = selection[0];
                        selectionRange.RemoveFromSelection();
                    }
                }
            }
            else
            {
                if (((selectionStart == 0)
                            && ((selectionLength < 0)
                            || (selectionLength >= textLength))))
                {
                    // select everything
                    System.Windows.Automation.Text.TextPatternRange selectionRange = pattern.DocumentRange.Clone();
                    selectionRange.MoveEndpointByUnit(System.Windows.Automation.Text.TextPatternRangeEndpoint.Start, System.Windows.Automation.Text.TextUnit.Character, textLength);
                    selectionRange.MoveEndpointByUnit(System.Windows.Automation.Text.TextPatternRangeEndpoint.End, System.Windows.Automation.Text.TextUnit.Character, textLength);
                    selectionRange.Select();
                }
                else
                {
                    System.Windows.Automation.Text.TextPatternRange selectionRange = pattern.DocumentRange.Clone();
                    selectionRange.MoveEndpointByUnit(System.Windows.Automation.Text.TextPatternRangeEndpoint.Start, System.Windows.Automation.Text.TextUnit.Character, selectionStart);
                    selectionRange.MoveEndpointByUnit(System.Windows.Automation.Text.TextPatternRangeEndpoint.End, System.Windows.Automation.Text.TextUnit.Character, (selectionStart + (selectionLength - textLength)));
                    selectionRange.Select();
                }
            }
        }

        /// <summary>
        /// Gets the selected UIA Element for the given index. 
        /// </summary>
        /// <param name="index">Selected element index.</param>
        /// <returns>IUIAElement</returns>
        public IUIAElement GetSelectedElement(int index)
        {
            SelectionPattern pattern = this.GetPattern<SelectionPattern>(SelectionPattern.Pattern);
            AutomationElement[] elements = pattern.Current.GetSelection();
            if ((index < elements.Length))
            {
                return new UIASupport(elements[index]);
            }

            return null;
        }

        /// <summary>
        /// Gets the name of the specified column header.
        /// </summary>
        /// <param name="index">Column index</param>
        /// <returns>Column Name</returns>
        public string GetColumnHeaderName(int index)
        {
            AutomationElement[] headerProperties = this.GetProperty<AutomationElement[]>(TableItemPatternIdentifiers.ColumnHeaderItemsProperty);
            return headerProperties[index].Current.Name;
        }

        #region Private Static Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to determine whether RuntimeIds match for two IScreenElements.
        /// </summary>
        /// <param name="left">First RuntimeId to compare</param>
        /// <param name="right">Second RuntimeId to compare</param>
        /// <returns>True or False</returns>
        /// ------------------------------------------------------------------
        private static bool RuntimeIdsEqual(int[] left, int[] right)
        {
            if ((left == null))
            {
                return false;
            }

            if ((right == null))
            {
                return false;
            }

            if ((left.Length != right.Length))
            {
                return false;
            }

            for (int i = 0; (i <= (left.Length - 1)); i++)
            {
                if ((left[i] != right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the AutomationElement associated with the given IScreenElement
        /// </summary>
        /// <param name="screenElement">IScreenElement</param>
        /// <returns>AutomationElement</returns>
        /// <exception cref="Window.Exceptions.AutomationElementNotFoundException">Window.Exceptions.AutomationElementNotFoundException</exception>
        /// ------------------------------------------------------------------
        private static AutomationElement AutomationElementFromScreenElement(IScreenElement screenElement)
        {
            object directElement = screenElement.AutomationElement;
            if (!(directElement == null))
            {
                return ((AutomationElement)(directElement));
            }
            else
            {
                AutomationElement automationElement = AutomationElement.FromHandle(screenElement.HWnd);
                int[] screenElementRuntimeId = automationElement.GetRuntimeId();
                int[] automationElementRuntimeId = screenElement.RuntimeId;

                // If RuntimeId of the ScreenElement is nothing, the AutomationElement is the correct one (Win32/Winform)
                if (!(screenElementRuntimeId == null))
                {
                    if (!(automationElementRuntimeId == null))
                    {
                        // Otherwise check if the RuntimeId of the AutomationElement is the same as the RuntimeId of the ScreenElement.
                        if (!RuntimeIdsEqual(screenElementRuntimeId, automationElementRuntimeId))
                        {
                            // If not then search for the AutomationElement within it's decendants matching the RuntimeId (WPF)
                            automationElement = new TreeWalker(new PropertyCondition(AutomationElement.RuntimeIdProperty, screenElement.RuntimeId)).GetFirstChild(automationElement);
                        }
                    }
                    else
                    {
                        // if RuntimeId is nothing, let's see if we can pin-point the related AE a little better
                        // we will get the AE from the screen coordinates of the target SE and then we will compare 
                        // some properties to see if we have a 'correct' AE for this SE
                        System.Windows.Point point = new System.Windows.Point(screenElement.GetBoundingRectangle().X, screenElement.GetBoundingRectangle().Y);
                        AutomationElement tempAutomationElement = AutomationElement.FromPoint(point);
                        System.Windows.Rect rect = ((System.Windows.Rect)(tempAutomationElement.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty)));
                        string name = ((string)(tempAutomationElement.GetCurrentPropertyValue(AutomationElement.NameProperty)));
                        if (((name == screenElement.Name) && CompareRects(rect, screenElement.GetBoundingRectangle())))
                        {
                            // if the Name is the same AND the BoundingRect is the same then we 'assume' that we found a more-correct match
                            automationElement = tempAutomationElement;
                        }
                    }
                }

                if ((automationElement == null))
                {
                    string message = ("Couldn\'t find AutomationElement corresponds to this ScreenElement."
                                + ("\r\n"
                                + ("    Seeking:" + "\r\n")));
                    message = (message
                                + ("        hWnd  = "
                                + (screenElement.HWnd.ToString() + "\r\n")));

                    throw new Window.Exceptions.AutomationElementNotFoundException(message);
                }

                return automationElement;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Helper method to compare a RECT return from an AutomationElement.GetBoundingRectangle to
        /// that returned from ScreenElement.GetBoundingRectangle
        /// </summary>
        /// <param name="rect1">First RECT</param>
        /// <param name="rect2">Second RECT</param>
        /// <returns>True if RECTs have same Location(X/Y) and Size(X/Y)</returns>
        /// ------------------------------------------------------------------
        private static bool CompareRects(System.Windows.Rect rect1, System.Drawing.Rectangle rect2)
        {
            if (((int)rect1.Location.X != rect2.Location.X) || ((int)rect1.Location.Y != rect2.Location.Y))
            {
                return false;
            }

            if (((int)rect1.Size.Width != rect2.Size.Width) || ((int)rect1.Size.Height != rect2.Size.Height))
            {
                return false;
            }

            return true;
        }
        #endregion

        /// <summary>
        /// Gets the value of the specified property for the UIA Element.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="automationProperty">Automation property to get.</param>
        /// <returns>Property</returns>
        private T GetProperty<T>(AutomationProperty automationProperty)
        {
            return (T)this.automationElement.GetCurrentPropertyValue(automationProperty);
        }

        /// <summary>
        /// Gets the specified automation pattern for the UIA Element.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="automationPattern">AutomationPattern</param>
        /// <returns>Pattern</returns>
        private T GetPattern<T>(AutomationPattern automationPattern)
        {
            return (T)this.automationElement.GetCurrentPattern(automationPattern);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets a value indicating if the specified pattern is supported by the UIA Element.
        /// </summary>
        /// <param name="pattern">AutomationPattern</param>
        /// <returns>True or False</returns>
        /// ------------------------------------------------------------------
        private bool SupportsPattern(AutomationPattern pattern)
        {
            AutomationPattern[] patterns = this.automationElement.GetSupportedPatterns();
            bool supported = false;

            foreach (AutomationPattern p in patterns)
            {
                if (p.Equals(pattern))
                {
                    supported = true;
                    break;
                }
            }

            return supported;
        }
    }
}
