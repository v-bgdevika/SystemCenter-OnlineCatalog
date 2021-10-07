using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maui.Core.WinControls;
using System.Windows.Automation;
using Mom.Test.UI.Core.Common;
using System.Windows;
using Maui.Core;

namespace Mom.Test.UI.Core.Console
{
    /// <summary>
    /// This class should contains the common UI operations, and no tight product business logic related
    /// </summary>
    public static class UIUtilities
    {
        /// <summary>
        /// This method set value to all simple controls, like TextBox, Button, RadioButton, ComboBox etc.
        /// </summary>
        /// <param name="control">MAUI Controls, object which is an instance inherit from Control</param>
        /// <param name="value">value to set on thecontrol, default value is null</param>
        public static void SetControlValue(Control control, object value=null)
        {
            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader+"Entering method (...)");

            Utilities.LogMessage(logHeader +"Wait for control enabled and visibled in half minute");
            CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate() { return control.IsEnabled && control.IsVisible; }, Constants.OneMinute / 2);
            control.WaitForResponse();

            UIASupport uiElement = new UIASupport(control.ScreenElement);

            AutomationPattern[] patterns = uiElement.AutomationElement.GetSupportedPatterns();
            string supportedPatterns = string.Empty;
            foreach (AutomationPattern pattern in patterns)
            {
                supportedPatterns += (supportedPatterns == string.Empty) ? pattern.ProgrammaticName : ", " + pattern.ProgrammaticName;
            }
            Utilities.LogMessage(logHeader +"The control support patterns "+supportedPatterns);

            Exception exception=null;

            #region Variables
            Point point = uiElement.AutomationElement.GetClickablePoint();
            int pointX = (int)point.X;
            int pointY = (int)point.Y;

            bool boolValue = true;
            string stringValue = string.Empty;
            int intValue = 0;

            if (value is bool)
            {
                boolValue = (bool)value;
                Utilities.LogMessage(logHeader +"Value is boolean type and its value is "+boolValue.ToString());
            }
            else if (value is string)
            {
                stringValue = (string)value;
                Utilities.LogMessage(logHeader +"Value is string type and its value is "+stringValue);
            }
            else if (value is int)
            {
                intValue = (int)value;
                Utilities.LogMessage(logHeader +"Value is int type and its value is "+intValue);
            }
            else if (value == null)
            {
                Utilities.LogMessage(logHeader+"Value is null");
            }
            #endregion

            if (control is TextBox)
            {
                #region TextBox
                TextBox textbox = (TextBox)control;
                Utilities.LogMessage(logHeader+"Control is TextBox");
                bool isPassword = textbox.IsPasswordType;

                if (Array.IndexOf(patterns, ValuePattern.Pattern) != -1)
                {
                    ValuePattern valuePattern = (ValuePattern)uiElement.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                    if ((!isPassword&&!string.Equals(valuePattern.Current.Value, stringValue)) || isPassword)
                    {
                        Utilities.LogMessage(logHeader + "Calling ValuePattern.SetValue");
                        valuePattern.SetValue(stringValue);
                    }
                }
                else if (Array.IndexOf(patterns, TextPattern.Pattern) != -1)
                {
                    if ((!isPassword&&!string.Equals(textbox.Text, stringValue)) || isPassword)
                    {
                        Utilities.LogMessage(logHeader + "Set value by Text property");
                        textbox.Text = stringValue;
                    }
                }
                else
                {
                    uiElement.AutomationElement.SetFocus();

                    // Erase existing text
                    while (textbox.Text.Length != 0)
                    {
                        textbox.SendKeys(KeyboardCodes.Delete);
                    }

                    // Set new value
                    Utilities.LogMessage(logHeader + "Set value by SendKeys");
                    control.SendKeys(stringValue);
                }

                if (!isPassword)
                {
                    CoreManager.MomConsole.Waiters.WaitForObjectPropertyChanged(textbox, "@Text", PropertyOperator.Equals, stringValue);
                }
                #endregion
            }
            else if (control is Button)
            {
                #region Button
                Button button = (Button)control;
                Utilities.LogMessage(logHeader + "Control type is Button");

                if (Array.IndexOf(patterns, InvokePattern.Pattern) != -1)
                {
                    InvokePattern invokePattern = (InvokePattern)uiElement.AutomationElement.GetCurrentPattern(InvokePattern.Pattern);
                    Utilities.LogMessage(logHeader+"Calling InvokePattern.Invoke");
                    invokePattern.Invoke();
                }
                else
                {
                    try
                    {
                        Utilities.LogMessage(logHeader+"Calling Button.Click");
                        button.Click();
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        Utilities.LogMessage(logHeader +string.Format("Exception occured, Click button via Mouse.Click({0},{1})",pointX,pointY));
                        Mouse.Click(pointX, pointY);
                    }
                }
                #endregion
            }
            else if (control is RadioButton)
            {
                #region RadioButton
                RadioButton radioButton = (RadioButton)control;
                Utilities.LogMessage(logHeader + "Control type is Button");
                ButtonState expectedButtonState = boolValue ? ButtonState.Checked : ButtonState.UnChecked;

                if (Array.IndexOf(patterns, SelectionItemPattern.Pattern) != -1)
                {
                    SelectionItemPattern selectionItemPattern = (SelectionItemPattern)uiElement.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                    if (boolValue != selectionItemPattern.Current.IsSelected)
                    {
                        Utilities.LogMessage(logHeader + string.Format ("Is selected: {0}, select it via Mouse.Click({1},{2})",!boolValue, pointX, pointY));
                        Mouse.Click(pointX, pointY);
                    }
                }
                else
                {
                    if (radioButton.ButtonState != expectedButtonState)
                    {
                        try
                        {
                            Utilities.LogMessage(logHeader + string.Format("Button state: {0}, set RadioButton.ButtonState to {1}", radioButton.ButtonState, expectedButtonState));
                            radioButton.ButtonState = expectedButtonState;
                        }
                        catch(Exception ex)
                        {
                            exception = ex;
                            Utilities.LogMessage(logHeader + string.Format("Exception occured, set Radio Button state via Mouse.Click({0},{1})", pointX, pointY));
                            Mouse.Click(pointX, pointY);
                        }
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForObjectPropertyChanged(radioButton, "@ButtonState", PropertyOperator.Equals, expectedButtonState);
                #endregion
            }
            else if (control is CheckBox)
            {
                #region CheckBox
                CheckBox checkbox = (CheckBox)control;
                Utilities.LogMessage(logHeader + "Control is CheckBox");
                ToggleState expectedToggleState = boolValue ? ToggleState.On : ToggleState.Off;

                if (Array.IndexOf(patterns, TogglePattern.Pattern) != -1)
                {
                    TogglePattern togglePattern = (TogglePattern)uiElement.AutomationElement.GetCurrentPattern(TogglePattern.Pattern);
                    if (togglePattern.Current.ToggleState != expectedToggleState)
                    {
                        Utilities.LogMessage(logHeader + string.Format("Toggle state: {0}, set TogglePattern.Toggle to {1}", togglePattern.Current.ToggleState, expectedToggleState));
                        togglePattern.Toggle();
                    }
                }
                else
                {
                    if (checkbox.Checked != boolValue)
                    {
                        try
                        {
                            Utilities.LogMessage(logHeader+"Set CheckBox.Checked to "+boolValue);
                            checkbox.Checked = boolValue;
                        }
                        catch (Exception ex)
                        {
                            exception = ex;
                            Utilities.LogMessage(logHeader + string.Format("Exception occured, set CheckBox state via Mouse.Click({0},{1})", pointX, pointY));
                            Mouse.Click(pointX, pointY);
                        }
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForObjectPropertyChanged(checkbox, "@Checked", PropertyOperator.Equals, boolValue);
                #endregion
            }
            else if (control is EditComboBox)
            {
                #region EditComboBox
                EditComboBox editComboBox = (EditComboBox)control;
                Utilities.LogMessage(logHeader+"Control is EditComboBox");

                if (Array.IndexOf(patterns, ValuePattern.Pattern) != -1)
                {
                    ValuePattern valuePattern = (ValuePattern)uiElement.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                    if (!string.Equals(valuePattern.Current.Value, stringValue))
                    {
                        Utilities.LogMessage(logHeader + "Calling ValuePattern.SetValue");
                        valuePattern.SetValue(stringValue);
                    }
                }
                else
                {
                    try
                    {
                        if (!string.Equals(editComboBox.Text, stringValue))
                        {
                            Utilities.LogMessage(logHeader + "Set EditComboBox.Text to " + stringValue);
                            editComboBox.Text = stringValue;
                        }
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        uiElement.AutomationElement.SetFocus();

                        // Erase previous text
                        while (editComboBox.Text.Length != 0)
                        {
                            editComboBox.SendKeys(KeyboardCodes.Delete);
                        }

                        // Set new value
                        Utilities.LogMessage(logHeader + "Set value by SendKeys");
                        control.SendKeys(stringValue);
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate() { return string.Equals(editComboBox.Text, stringValue); });
                #endregion
            }
            else if (control is ComboBox)
            {
                #region ComboBox
                ComboBox combobox = (ComboBox)control;
                Utilities.LogMessage(logHeader+"Control is ComboBox");

                if (value is string)
                {
                    Utilities.LogMessage(logHeader + "Calling ComboBox.SelectByText");
                    combobox.SelectByText(stringValue);
                    CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate() { return string.Equals(combobox.Text, stringValue); });
                }
                else if (value is int)
                {
                    Utilities.LogMessage(logHeader+"Calling ComboBox.SelectByIndex");
                    combobox.SelectByIndex(intValue);
                    CoreManager.MomConsole.Waiters.WaitForObjectPropertyChanged(combobox, "@SelectedIndex", PropertyOperator.Equals, intValue);
                }
                #endregion
            }
            else if (control is ListBox)
            {
                #region ListBox
                throw new NotSupportedException();
                #endregion
            }
            else if (control is Spinner || control is NumericUpDown)
            {
                #region Spinner
                Spinner spinner = control as Spinner;
                NumericUpDown numericUpDown = control as NumericUpDown;
                Utilities.LogMessage(logHeader + "Control is " + ((spinner == null) ? "NumericUpDown" : "Spinner"));

                if (Array.IndexOf(patterns, RangeValuePattern.Pattern) != -1)
                {
                    RangeValuePattern rangeValuePattern = (RangeValuePattern)uiElement.AutomationElement.GetCurrentPattern(RangeValuePattern.Pattern);
                    if (rangeValuePattern.Current.Value != intValue)
                    {
                        Utilities.LogMessage(logHeader + "Calling RangeValuePattern.SetValue");
                        rangeValuePattern.SetValue(intValue);
                    }
                }
                else if(control is NumericUpDown)
                {
                    try
                    {
                        Utilities.LogMessage(logHeader + "Set range value by NumericUpDown.Value property");
                        numericUpDown.Value = intValue;
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        uiElement.AutomationElement.SetFocus();
                        Utilities.LogMessage(logHeader + "Exception occured, Set range value via Click up or down button, current value is " + numericUpDown.Value);
                        while (numericUpDown.Value < intValue)
                        {
                            numericUpDown.ClickUp();
                        }
                        while (numericUpDown.Value > intValue)
                        {
                            numericUpDown.ClickDown();
                        }
                    }
                }
                else if (control is Spinner)
                {
                    try
                    {
                        Utilities.LogMessage(logHeader + "Calling Spinner.SpinToPos");
                        spinner.SpinToPos(intValue);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        uiElement.AutomationElement.SetFocus();

                        // Erase existing text
                        while(!string.IsNullOrEmpty(spinner.Value.ToString()))
                        {
                            control.SendKeys(KeyboardCodes.Backspace);
                        }

                        Utilities.LogMessage(logHeader + "Exception occured, Set range value via SendKeys");
                        control.SendKeys(stringValue);
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate()
                {
                    if (spinner == null) return numericUpDown.Value == intValue;
                    else return spinner.Value == intValue;
                });
                #endregion
            }

            #region Analyze exception here if it is not null
            if (exception != null)
            {
                Utilities.LogMessage(logHeader + "Exception message is "+exception.Message);
            }
            #endregion
        }
    }
}
