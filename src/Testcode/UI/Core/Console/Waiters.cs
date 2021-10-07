// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Waiters.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   ConsoleFramework
// </project>
// <summary>
//   Waiters
// </summary>
// <history>
//   [mbickle] 7/31/2008 Created
// </history>
// ---------------------------------------------------------------------------

using System.Reflection;

namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    #endregion

    /// <summary>
    /// WaitForReady Robustness Level
    ///  0 Off
    ///  1 Default
    /// -1 Verify Background thread states.
    /// -2 Verify all threads in system.
    /// </summary>
    /// <remarks>
    /// Read the RPFHelp.chm file on 'WaitForReady' to learn more about
    /// setting the Robustness Level.  Currently only support the simple
    /// case.
    /// </remarks>
    public enum RobustnessLevel
    {
        /// <summary>
        /// Default = 1
        /// </summary>
        Default = 1,
        
        /// <summary>
        /// Verify background thread states. -1
        /// </summary>
        BackgroundThread = -1,

        /// <summary>
        /// Verify all thread states. -2
        /// </summary>
        AllThreads = -2,

        /// <summary>
        /// Disable WaitForReady
        /// </summary>
        Disable = 0,

        /// <summary>
        /// Quantum 2
        /// </summary>
        Two = 2,

        /// <summary>
        /// Quantum 3
        /// </summary>
        Three = 3,

        /// <summary>
        /// Quantum 4
        /// </summary>
        Four = 4,

        /// <summary>
        /// Quantum 5
        /// </summary>
        Five = 5,

        /// <summary>
        /// Quantum 6
        /// </summary>
        Six = 6,

        /// <summary>
        /// Quantum 7
        /// </summary>
        Seven = 7,

        /// <summary>
        /// Quantum 8
        /// </summary>
        Eight = 8,

        /// <summary>
        /// Quantum 9
        /// </summary>
        Nine = 9,

        /// <summary>
        /// Quantum 10
        /// </summary>
        Ten = 10
    }


    /// <summary>
    /// Property enumeration for method WaitForObjectPropertyChanged
    /// </summary>
    public enum PropertyOperator
    {
        // Strings
        Contains,
        EqualsIgnoreCase,
        ContainsIgnoreCase,
        // Number
        GreaterThan,
        GreaterThanOrEquals,
        LessThan,
        LessThanOrEquals,
        // Shared
        NotEquals,
        Equals
    }

    /// <summary>
    /// Waiter Methods
    /// </summary>
    public class Waiters
    {
        /// <summary>
        /// ConsoleWindow 
        /// </summary>
        private ConsoleApp console;
        private Window consoleWindow;

        /// <summary>
        /// Waiters 
        /// </summary>
        /// <remarks>
        /// Using this constructor will set the local consoleWindow reference
        /// to the Main Console Instance only, use Waiters(ConsoleWindow) if 
        /// you are instantiating this class yourself and want to reference a
        /// ConsoleWindow other than the main App instance.  
        /// </remarks>
        public Waiters()
        {
            if (null == this.consoleWindow)
            {
                this.consoleWindow = CoreManager.MomConsole.MainWindow;
                this.console = CoreManager.MomConsole;
            }
        }

        /// <summary>
        /// Waiters 
        /// </summary>
        /// <param name="consoleWindow">ConsoleWindow reference.</param>
        /// <remarks>
        /// Need reference to ConsoleWindow to ensure WaitForReady()
        /// points to the correct instance.  For cases when you may open 
        /// a new ConsoleWindow (ie: view pivoting). 
        /// In most cases you should use the ConsoleWindow.Waiters property
        /// reference on your new ConsoleWindow instance.
        /// </remarks>
        public Waiters(ConsoleApp console)
        {
            this.console = console;
        }

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the specifed button to be enabled.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// button becoming enabled.</remarks>
        /// <param name="button">Button object to wait for.</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// ------------------------------------------------------------------        
        public virtual void WaitForButtonEnabled(Button button)
        {
            WaitForWindowEnabled(button as Window, Constants.TenSeconds);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the specifed button to be enabled.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// button becoming enabled.</remarks>
        /// <param name="button">Button object to wait for.</param>
        /// <param name="timeout">timeout to wait</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        public virtual void WaitForButtonEnabled(Button button, int timeout)
        {
            WaitForWindowEnabled(button as Window, timeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the specifed window to be enabled.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// button becoming enabled.</remarks>
        /// <param name="window">Window object to wait for.</param>
        /// <param name="timeout">Timeout in milliseconds.</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// ------------------------------------------------------------------
        public virtual void WaitForWindowEnabled(Window window, int timeout)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window", "Waiters.WaitForWindowEnabled:: window is null");
            }

            Sleeper sleeper = new Sleeper(timeout);
            DateTime startTime = DateTime.Now;

            // Wait for installation process to complete
            while (sleeper.IsNotExpired)
            {
                if (window.IsEnabled)
                {
                    Utilities.LogMessage("Waiters.WaitForWindowEnabled:: " +
                        window.Caption + " window was enabled after " +
                        Utilities.ElapsedTime(startTime).TotalSeconds + " seconds.");

                    window.ScreenElement.WaitForReady();

                    // Control is enabled end the wait
                    break;
                }

                sleeper.Sleep();
            }

            // If the control is not enabled after the maximum
            //  number of tries, throw an exception.
            if (!window.IsEnabled)
            {
                throw new System.TimeoutException("Waiters.WaitForWindowEnabled:: Timed out before window was" +
                    " enabled after " + Utilities.ElapsedTime(startTime).TotalSeconds + " seconds.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait for Wizard Navigation Item Count to have at least the number specified.
        /// </summary>
        /// <param name="wizardDialog">Wizard Dialog Window</param>
        /// <param name="navigationItemCount">Number of Navigation Items to wait for.</param>
        /// <param name="timeout">Timeout value in milliseconds to wait.</param>
        /// <returns>true/false</returns>
        /// <history>
        /// [mbickle] 18JUL07 Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool WaitForWizardNavigationItemCount(Window wizardDialog, int navigationItemCount, int timeout)
        {
            DateTime startTime = DateTime.Now;
            Sleeper sleeper = new Sleeper(timeout);

            bool navigationItemCountExpected = false;
            int countNavigationItem = 0;

            // Do some tasks...
            while (sleeper.IsNotExpired && navigationItemCountExpected == false)
            {
                countNavigationItem = 0;
                WindowCollection winCollect = new WindowCollection("*", StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.WildCard, wizardDialog);
                foreach (Window win in winCollect)
                {
                    if (win.Extended.AccessibleObject.Name == "NavigationItem")
                    {
                        countNavigationItem++;
                    }
                }

                if (countNavigationItem == navigationItemCount)
                {
                    navigationItemCountExpected = true;
                }

                sleeper.Sleep();
            }

            Utilities.LogMessage("Waiters.WaitForNavigationItemCount:: Elapsed Time:= " + Utilities.ElapsedTime(startTime));

            return navigationItemCountExpected;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait for Dialog to close/not be visible.
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// <returns>True/False</returns>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <history>
        /// [mbickle] 26MAR06 Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool WaitForWindowClose(Window window, int timeout)
        {
            Utilities.LogMessage("Waiters.WaitForWindowClose:: Waiting for window to close.");
            bool windowClosed = false;
            int interval = 1000; // How often to check

            // Verify dialogWindow isn't null.
            if (window == null)
            {
                throw new ArgumentNullException("window", "Waiters.WaitForWindowClose:: Window cannot be NULL.");
            }

            try
            {
                window.ScreenElement.WaitForGone(timeout, interval);
                windowClosed = true;
            }
            catch (System.InvalidOperationException)
            {
                Utilities.LogMessage(String.Format("Waiters.WaitForWindowClose:: Window still opened after timeout: {0}", timeout));
            }

            if (!windowClosed)
            {
                Utilities.TakeScreenshot("Waiters.WaitForWindowClose.Failed");
            }

            return windowClosed;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Waits for the specified window to have focus.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// window having focus.</remarks>
        /// <param name="window">Window to wait for.</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.TimeoutException">System.TimeoutException</exception>
        /// -------------------------------------------------------------------
        public virtual void WaitForWindowFocus(Window window, int timeout)
        {
            DateTime startTime = DateTime.Now;
            Sleeper sleeper = new Sleeper(timeout);

            // check for null
            if (window == null)
            {
                throw new ArgumentNullException("window", "Waiters.WaitForWindowFocus:: window is null");
            }

            while (sleeper.IsNotExpired)
            {
                if (window.Extended.HasFocus == true)
                {
                    Utilities.LogMessage("Waiters.WaitForWindowFocus: " +
                        window.Caption + " object has focus after " +
                        Utilities.ElapsedTime(startTime).TotalSeconds + " seconds.");

                    // Control has focus end the wait
                    break;
                }

                sleeper.Sleep();
            }

            // If the control does have focus after the maximum
            //  number of tries, throw an exception.
            if (window.Extended.HasFocus == false)
            {
                throw new System.TimeoutException("Waiters.WaitForWindowFocus:: " +
                    "Timed out before object has" +
                    " focus after " + Utilities.ElapsedTime(startTime).TotalSeconds + " seconds.");
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Waits for the specified window to be in the foreground.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// window appearing in the foreground.</remarks>
        /// <param name="window">Window to wait for.</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// -------------------------------------------------------------------
        public virtual void WaitForWindowForeground(Window window, int timeout)
        {
            DateTime startTime = DateTime.Now;
            Sleeper sleeper = new Sleeper(timeout);

            // check for null
            if (window == null)
            {
                throw new ArgumentNullException("window", "Waiters.WaitForWindowForeground:: window is null");
            }

            while (sleeper.IsNotExpired)
            {
                if (window.Extended.IsForeground == true)
                {
                    Utilities.LogMessage("Waiters.WaitForWindowForeground:: " +
                        window.Caption + " object was in foreground after " +
                        Utilities.ElapsedTime(startTime).TotalSeconds + " seconds.");

                    // Object is in the foreground, end the wait
                    break;
                }

                Utilities.LogMessage("Waiters.WaitForWindowForeground:: " +
                    window.Caption + " object was NOT in foreground after " +
                    Utilities.ElapsedTime(startTime).TotalSeconds + " seconds.");

                sleeper.Sleep();
            }

            // If the control is not enabled after the maximum
            //  number of tries, throw an exception.
            if (window.Extended.IsForeground == false)
            {
                throw new System.TimeoutException("Waiters.WaitForWindowForeground:: " +
                    "Timed out before object was" +
                    " in the foreground after " + sleeper.ToString() + " milliseconds.");
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// WaitForWindowIdle -- Obsolete, renamed to WaitForWindowReady()
        /// </summary>
        /// <param name="window">Window to wait for to be Idle</param>
        /// <param name="timeout">Timeout to wait in milliseconds</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>true/false</returns>
        /// <history>
        /// [mbickle] 18JUL06 Created
        /// </history>
        /// -------------------------------------------------------------------
        [Obsolete("Use WaitForWindowReady()")]
        public virtual bool WaitForWindowIdle(Window window, int timeout)
        {
            bool ready = false;
            this.WaitForWindowReady(window, timeout);
            ready = true;

            return ready;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// WaitForWindowReady, default Robustness Level checks forground thread.
        /// </summary>
        /// <param name="window">Window to wait for to be ready</param>
        /// <param name="timeout">Timeout to wait in milliseconds</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <history>
        /// [mbickle] 18FEB10 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void WaitForWindowReady(Window window, int timeout)
        {
            this.WaitForWindowReady(window, timeout, ConsoleConstants.DefaultRobustnessLevel);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// WaitForWindowReady
        /// </summary>
        /// <param name="window">Window to wait for to be ready.</param>
        /// <param name="timeout">Timeout to wait in milliseconds.</param>
        /// <param name="robustnessLevel">Robustness Level.</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.InvalidOperationException">System.InvalidOperationException</exception>
        /// <history>
        /// [mbickle] 18FEB10 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void WaitForWindowReady(Window window, int timeout, RobustnessLevel robustnessLevel)
        {
            DateTime startTime = DateTime.Now;

            // check for null
            if (window == null)
            {
                throw new ArgumentNullException("window", "Waiters.WaitForWindowReady:: window is null");
            }

            // Set WFR Timeout
            RPFSupport.RPF.SetWFRTimeout(timeout*3);
            RPFSupport.RPF.SetRobustnessLevel((int)robustnessLevel);

            try
            {
                window.ScreenElement.WaitForReady();
            }
            catch (System.InvalidOperationException ex)
            {
                Utilities.LogMessage(String.Format("Waiters.WaitForWindowReady:: Exception: {0}", ex.Message));
                
                // TODO: Should we throw a timeout exception here instead?  
                //       Sometimes exception can be due to an invalid HWND, 
                //       otherwise it's due to the timout expiring.  Unfortunately 
                //       no easy way to tell which one happened.
                throw;
            }
            finally
            {
                // Set WFR Timeout back to default
                RPFSupport.RPF.SetWFRTimeout(ConsoleConstants.DefaultWaitForReadyTimeout);
                RPFSupport.RPF.SetRobustnessLevel((int)ConsoleConstants.DefaultRobustnessLevel);
                Utilities.LogMessage(String.Format("Waiters.WaitForWindowReady:: Elapsed Time: {0}", Utilities.ElapsedTime(startTime)));
            }
        }

        /// <summary>
        /// It will check if can find the window matched with the QID in period specified by timeout parameter
        /// </summary>
        /// <returns>Window matched with the QID, if not found, will return null</returns>
        /// <param name="qid">QID</param>
        /// <param name="timeout">in seconds</param>
        public virtual Window WaitForWindowAppeared(Window parent, QID qid, int timeout)
        {
            string logHeader = MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader+"Start");

            #region Validate parameters
            if (parent == null)
            {
                throw new ArgumentNullException("parent cannot be null");
            }

            if (qid == null || string.IsNullOrEmpty(qid.QueryID))
            {
                throw new ArgumentException("qid cannot be null or with empty query string");
            }

            if (timeout <= 0)
            {
                throw new ArgumentException("timeout cannot equal or less than zero");
            }
            #endregion
            DateTime startDate = DateTime.Now;
            Window wnd = null;
            while (startDate.AddMilliseconds(timeout) > DateTime.Now)
            {
                try
                {
                    wnd = new Window(parent, qid, Window.DefaultWaitTimeout);   // Window.DefaultTimeout = 3000
                    return wnd;
                }
                catch
                {
                    // ignore all the exception here
                }
                Utilities.LogMessage(logHeader + "did not find window, trying again");
            }
            return wnd;
        }

        /// <summary>
        /// Waits until the current mouse cursor type changes from the specified one. Max wait is 2 mins
        /// </summary>
        /// <param name="cursorType">MouseCursorType that you want to wait on</param> 
        /// <param name="timeout">Maximum time in milliseconds to wait for the cursor state to change</param>
        /// <history>
        ///     [ruhim] 10Jul06 - Created        
        /// </history>        
        public virtual void WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType cursorType, int timeout)
        {
            Sleeper sleeper = new Sleeper(timeout);

            Utilities.LogMessage("Waiters.WaitUntilCursorType:: Current Cursor type: "
                + Mouse.CurrentCursorType.ToString());

            while (sleeper.IsNotExpired && Mouse.CurrentCursorType.Equals(cursorType))
            {
                sleeper.Sleep();
            }

            Utilities.LogMessage("Waiters.WaitUntilCursorType:: Done waiting, Current Cursor type: "
                + Mouse.CurrentCursorType.ToString());
        }

        /// <summary>
        /// Wait for object property changed as expected
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="propertyChangedExpression">an expression to tell what's the expected property change on the object
        /// e.g., you pass a Button instance as object, then the expression may be "@IsEnabled == true",
        /// or you pass a Window instance as object, then the expression may be "@IsVisible == false",
        /// Two notes here, 1) expression should start with @ to indicate the following is a property, the property is case sensitive
        /// 2) property and property value should be separated by operator and quoted with space character</param>
        /// <param name="timeout">timeout, in ms</param>
        public virtual void WaitForObjectPropertyChanged(object obj, string property, PropertyOperator propertyOperator, object expectedValue, int timeout = Constants.OneSecond * 30)
        {
            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader + "Entering method (...)");

            #region parameter check
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "object cannot be null");
            }

            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentNullException("property", "property cannot be null or empty");
            }

            if (!property.StartsWith("@"))
            {
                throw new ArgumentException("property", "property should start with @");
            }

            if (expectedValue == null)
            {
                throw new ArgumentNullException("expectedValue", "expectedValue cannot be null");
            }

            if (timeout <= 0)
            {
                throw new ArgumentException("timeout", "timeout value should greater than zero");
            }
            #endregion

            #region output parameters
            Utilities.LogMessage(logHeader + "property is " + property);
            Utilities.LogMessage(logHeader + "property operator is " + propertyOperator.ToString());
            Utilities.LogMessage(logHeader + "expected property value is " + expectedValue);
            #endregion

            #region polling check if property value changed to expected value
            bool propertyValueChangedAsExpected = false;
            string actualValueString;
            int actualValueNumber;
            string expectedValueString;
            int expectedValueNumber;
            int propertyOperatorIndicator = -1; // -1: value not set, 0: string operator, 1: int operator, 2: Not supported property type

            object propertyValue = null;

            Sleeper sleeper = new Sleeper(timeout);
            while (sleeper.IsNotExpired && !propertyValueChangedAsExpected)
            {
                if ((propertyValue = GetObjectProperty(obj, property)) == null)
                {
                    Utilities.LogMessage(logHeader + "Actual property value is null, skip this round property value check");
                    propertyValue = null;
                    sleeper.Sleep();
                    continue;
                }

                Utilities.LogMessage(logHeader + "Actual property value is " + propertyValue.ToString());

                #region Evaluate if property changed as expected
                if (propertyOperatorIndicator == -1)
                {
                    propertyOperatorIndicator = (propertyValue is string || propertyValue is bool || propertyValue.GetType().IsEnum) ? 0 : ((propertyValue is int) ? 1 : 2); // -1: value not set, 0: string operator, 1: int operator, 2: Not supported property type
                }

                if (propertyOperatorIndicator == 0)
                {
                    actualValueString = propertyValue.ToString();
                    expectedValueString = expectedValue.ToString();
                    propertyValue = null;

                    switch (propertyOperator)
                    {
                        case PropertyOperator.Equals:   // exact match
                            propertyValueChangedAsExpected = string.Equals(actualValueString, expectedValueString);
                            break;

                        case PropertyOperator.Contains: // contains
                            propertyValueChangedAsExpected = actualValueString.IndexOf(expectedValueString) != -1;
                            break;

                        case PropertyOperator.EqualsIgnoreCase: // case insensitive
                            propertyValueChangedAsExpected = string.Equals(actualValueString, expectedValueString, StringComparison.InvariantCultureIgnoreCase);
                            break;

                        case PropertyOperator.ContainsIgnoreCase: // contains and case insensitive
                            propertyValueChangedAsExpected = actualValueString.ToLowerInvariant().IndexOf(expectedValueString.ToLowerInvariant()) != -1;
                            break;

                        case PropertyOperator.NotEquals: // not equals
                            propertyValueChangedAsExpected = !string.Equals(actualValueString, expectedValueString);
                            break;

                        default:
                            throw new Exception("Unrecongnized property operator " + propertyOperator);
                    }
                }
                else if (propertyOperatorIndicator == 1)
                {
                    if (!Int32.TryParse(propertyValue.ToString(), out actualValueNumber))
                    {
                        Utilities.LogMessage(logHeader + "Actual property value is " + propertyValue.ToString() + ", parse it as number failed, will skip this round property value check");
                        propertyValue = null;
                        sleeper.Sleep();
                        continue;
                    }

                    propertyValue = null;
                    expectedValueNumber = int.Parse(expectedValue.ToString());

                    switch (propertyOperator)
                    {
                        case PropertyOperator.Equals:   // equals
                            propertyValueChangedAsExpected = actualValueNumber == expectedValueNumber;
                            break;

                        case PropertyOperator.GreaterThan: // greater than
                            propertyValueChangedAsExpected = actualValueNumber > expectedValueNumber;
                            break;

                        case PropertyOperator.GreaterThanOrEquals: // equals or greater than
                            propertyValueChangedAsExpected = actualValueNumber >= expectedValueNumber;
                            break;

                        case PropertyOperator.LessThan: // less than
                            propertyValueChangedAsExpected = actualValueNumber < expectedValueNumber;
                            break;

                        case PropertyOperator.LessThanOrEquals: // equals or less than
                            propertyValueChangedAsExpected = actualValueNumber <= expectedValueNumber;
                            break;

                        case PropertyOperator.NotEquals: // not equals
                            propertyValueChangedAsExpected = actualValueNumber != expectedValueNumber;
                            break;

                        default:
                            throw new Exception("Unrecongnized property operator " + propertyOperator);
                    }
                }
                else
                {
                    throw new NotSupportedException("Only support property type of string and int, not support type " + propertyValue.GetType().Name);
                }
                #endregion

                sleeper.Sleep();
            }

            if (!propertyValueChangedAsExpected)
            {
                Utilities.TakeScreenshot(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception("Property not changed as expected in " + timeout + " ms");
            }
            #endregion
        }

        /// <summary>
        /// Wait for the property value of current object changed
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="property">property name of current object, starts with @</param>
        public virtual void WaitForObjectPropertyChanged(object obj, string property, int timeout = Constants.OneSecond * 10)
        {
            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader + "Entering method (...)");

            #region parameter check
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "object cannot be null");
            }

            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentNullException("property", "property cannot be null or empty");
            }

            if (!property.StartsWith("@"))
            {
                throw new ArgumentException("property", "property should start with @");
            }
            #endregion

            #region output parameters
            Utilities.LogMessage(logHeader + "property is " + property);
            #endregion

            #region polling check if property value changed to expected value
            object originalPropertyValue = null;
            object currentPropertyValue = null;
            bool propertyValueChanged = false;

            // get the orginal value
            originalPropertyValue = GetObjectProperty(obj, property);
            Utilities.LogMessage(logHeader + "Original property value is "+(originalPropertyValue==null ? "<null>" : originalPropertyValue.ToString()));

            Sleeper sleeper = new Sleeper(timeout);
            while (sleeper.IsNotExpired)
            {
                currentPropertyValue = GetObjectProperty(obj, property);
                propertyValueChanged = !object.Equals(currentPropertyValue, originalPropertyValue);
                if (propertyValueChanged)
                {
                    Utilities.LogMessage(logHeader + "Property value changed, current value is " + (currentPropertyValue == null ? "<null>" : currentPropertyValue.ToString()));
                    break;
                }

                sleeper.Sleep();
            }

            if (!propertyValueChanged)
            {
                Utilities.TakeScreenshot(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception("Property value not changed as expected in " + timeout + " ms");
            }
            #endregion
        }

        /// <summary>
        /// Get property of current object
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="property">property name of current object, if nested, separate it with dot, like @Name.Length</param>
        /// <returns>object, property value of current object</returns>
        private object GetObjectProperty(object obj, string property)
        {
            string[] mayNestedProperties = property.Remove(0, 1).Split('.');

            object originalObject = obj;    // store the orginal object passed in this method
            object recycleUsedObject = null;    // private object instance recycle used
            bool isFirstProperty = true;

            foreach (string propertyName in mayNestedProperties)
            {
                try
                {
                    Type t = isFirstProperty ? originalObject.GetType() : recycleUsedObject.GetType();
                    recycleUsedObject = t.GetProperty(propertyName).GetValue(isFirstProperty ? originalObject : recycleUsedObject, null);
                    isFirstProperty = false;
                }
                catch (System.Reflection.TargetInvocationException)
                {
                    Utilities.LogMessage("got System.Reflection.TargetInvocationException exception, sleep a second");
                    //avoid product UI obj properties changing thread conflict
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    Type t = isFirstProperty ? originalObject.GetType() : recycleUsedObject.GetType();
                    recycleUsedObject = t.GetProperty(propertyName).GetValue(isFirstProperty ? originalObject : recycleUsedObject, null);
                    isFirstProperty = false;
                }
            }

            return recycleUsedObject;
        }

        /// <summary>
        /// Just a call to WaitForObjectPropertyChanged, got exception return false, else return true
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="propertyChangedExpression">an expression to tell what's the expected property change on the object
        /// e.g., you pass a Button instance as object, then the expression may be "@IsEnabled = true",
        /// or you pass a Window instance as object, then the expression may be "@IsVisible = false",
        /// Two notes here, 1) expression should start with @ to indicate the following is a property, the property is case sensitive
        /// 2) property and property value should be separated by operator and quoted with space character</param>
        /// <param name="timeout">timeout, in ms</param>
        /// <returns>got exception return false, else return true</returns>
        public virtual bool WaitForObjectPropertyChangedSafe(object obj, string property, PropertyOperator propertyOperator, object expectedValue, int timeout = Constants.OneSecond * 10)
        {
            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader + "Entering method (...)");
            
            try
            {
                WaitForObjectPropertyChanged(obj, property, propertyOperator, expectedValue, timeout);
                return true;
            }
            catch (ArgumentNullException e1)
            {
                Utilities.LogMessage(logHeader + e1.Message);
                return false;
            }
            catch (ArgumentException e2)
            {
                Utilities.LogMessage(logHeader + e2.Message);
                return false;
            }
            catch (Exception e3)
            {
                Utilities.LogMessage(logHeader + e3.Message);
                return false;
            }
        }

        /// <summary>
        /// Just a call to WaitForObjectPropertyChanged, got exception return false, else return true
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="property">property name of current object, starts with @</param>
        /// <param name="timeout">time out, in ms</param>
        /// <returns>got exception return false, else return true</returns>
        public virtual bool WaitForObjectPropertyChangedSafe(object obj, string property, int timeout = Constants.OneSecond * 10)
        {
            try
            {
                WaitForObjectPropertyChanged(obj, property, timeout);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public delegate bool ConditionCheck();

        /// <summary>
        /// Wait for condition check success
        /// </summary>
        /// <param name="conditionCheck">a delegate instance, the function has no parameters, and has a return value of type boolean</param>
        /// <param name="timeout">timeout, in ms</param>
        public virtual void WaitForConditionCheckSuccess(ConditionCheck conditionCheck, int timeout = Constants.OneSecond * 10)
        {
            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader + "Entering method (...)");

            #region parameter check
            if (conditionCheck == null)
            {
                throw new ArgumentNullException("conditionCheck", "conditionCheck cannot be null");
            }
            #endregion

            #region polling invoke conditioncheck until success
            Sleeper sleeper = new Sleeper(timeout);
            bool checkSuccess = false;

            while (sleeper.IsNotExpired && !checkSuccess)
            {
                if (checkSuccess = conditionCheck())
                {
                    break;
                }

                sleeper.Sleep();
            }

            if (!checkSuccess)
            {
                throw new Exception(logHeader +"condition check failed in "+timeout+" ms");
            }
            #endregion
        }

        /// <summary>
        /// Just a simple call to Wait for condition check success
        /// </summary>
        /// <param name="conditionCheck">a delegate instance, the function has no parameters, and has a return value of type boolean</param>
        /// <param name="timeout">timeout, in ms</param>
        /// <returns>got exception return false, else return true</returns>
        public virtual bool WaitForConditionCheckSuccessSafe(ConditionCheck conditionCheck, int timeout = Constants.OneSecond * 10)
        {
            try
            {
                WaitForConditionCheckSuccess(conditionCheck, timeout);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region WaitForReady
        /// <summary>
        /// WaitForReady
        /// This checks the ConsoleWindow and ViewPane of the ConsoleWindow for
        /// it's ReadyState with a RobustnessLevel of 1 and 
        /// timeout of ConsoleConstants.DefaultWaitForReadyTimeout
        /// </summary>
        public virtual void WaitForReady()
        {
            this.WaitForReady(ConsoleConstants.DefaultWaitForReadyTimeout);
        }

        /// <summary>
        /// This checks the ConsoleWindow and ViewPane of the ConsoleWindow for
        /// rediness with ConsoleConstants.DefaultRobustnessLevel.
        /// </summary>
        /// <param name="timeout">Timeout in milliseconds.</param>
        public virtual void WaitForReady(int timeout)
        {
            this.WaitForReady(this.console.MainWindow, timeout, ConsoleConstants.DefaultRobustnessLevel);
        }

        /// <summary>
        /// This checks the ConsoleWindow and ViewPane of the ConsoleWindow for readiness.
        /// </summary>
        /// <param name="timeout">Timeout in milliseconds.</param>
        /// <param name="robustnessLevel">Robustness Level</param>
        public virtual void WaitForReady(int timeout, RobustnessLevel robustnessLevel)
        {
            this.WaitForReady(this.console.MainWindow, timeout, robustnessLevel);
        }

        /// <summary>
        /// This checks the ConsoleWindow and ViewPane of the ConsoleWindow for readiness.
        /// </summary>
        /// <remarks>
        /// This method has the potential for waiting up to 2x the timeout value
        /// since it's checking multiple windows with the timeout value
        /// that is passed in.  The subsequent checks won't get called if the first
        /// timeout isn't met as an exception will be thrown.
        /// </remarks>
        /// <param name="consoleWindow">ConsoleWindow reference.</param>
        /// <param name="timeout">Timeout in milliseconds.</param>
        /// <param name="robustnessLevel">Robustness Level.</param>
        public virtual void WaitForReady(Window consoleWindow, int timeout, RobustnessLevel robustnessLevel)
        {
            DateTime startTime = DateTime.Now;

            this.WaitForWindowReady(consoleWindow, timeout, robustnessLevel);
            
            try
            {
                this.WaitForWindowReady(console.ViewPane, timeout, robustnessLevel);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                // ViewPane should typically always exist, unless code is ran against
                // Something that isn't the ConsoleFramework.  So we'll just catch 
                // the exception and ignore it.
            }

            Utilities.LogMessage("Waiters.WaitForReady:: Elapsed Time: " + Utilities.ElapsedTime(startTime));
        }
        #endregion

        #region WaitForStatusReady
        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For StatusBar Ready Message.
        /// Default Timeout: StatusTimeout
        /// </summary>
        /// <returns>Found message on status bar (True/False)</returns>
        /// ------------------------------------------------------------------
        [Obsolete("Use WaitForReady()")]
        public virtual bool WaitForStatusReady()
        {
            return this.WaitForStatusReady(ConsoleConstants.DefaultWaitForReadyTimeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For StatusBar Ready Message w/Timeout
        /// </summary>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// <returns>Found message on status bar (True/False)</returns>
        /// ------------------------------------------------------------------
        [Obsolete("Use WaitForReady()")]
        public virtual bool WaitForStatusReady(int timeout)
        {
            bool ready = false;
            DateTime startTime = DateTime.Now;

            ////ready = this.WaitForStatusText(
            ////    SCControls.ConsoleStatusBar.Strings.Ready,
            ////    timeout);

            this.WaitForReady(timeout);
            ready = true;
            return ready;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For Status Text to appear.
        /// Default Timeout: StatusTimeout
        /// </summary>
        /// <param name="statusMessage">Status Message to Look for.</param>
        /// <returns>Found message on status bar (True/False)</returns>
        /// ------------------------------------------------------------------
        public virtual bool WaitForStatusText(string statusMessage)
        {
            return this.WaitForStatusText(statusMessage, ConsoleConstants.DefaultWaitForReadyTimeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For Status Text to appear w/Timeout.
        /// </summary>
        /// <param name="statusMessage">Status Message to look for</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// <returns>Found message on status bar (True/False)</returns>
        /// ------------------------------------------------------------------
        public virtual bool WaitForStatusText(string statusMessage, int timeout)
        {
            if (ProductSku.Sku != ProductSkuLevel.Mom)
                return true;

            try
            {
                return this.console.Controls.StatusBar.WaitForText(
                    statusMessage,
                    timeout);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("Waiters.WaitForStatusText:: Could not find Status Bar, returning false.");
                return false;
            }
        }
        #endregion

        #endregion
    }

}
