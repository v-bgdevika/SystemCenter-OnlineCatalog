// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="IncorrectFormulaWindow.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 20-Aug-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IIncorrectFormulaWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IIncorrectFormulaWindowControls, for IncorrectFormulaWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 20-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IIncorrectFormulaWindowControls
    {
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl
        /// </summary>
        StaticControl FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Formula Incorrect" warning window 
    /// for the Expression Builder dialog in the Create Monitor Wizard.
    /// </summary>
    /// <history>
    /// 	[ruhim] 20-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class IncorrectFormulaWindow : Window, IIncorrectFormulaWindowControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>        
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public IncorrectFormulaWindow() : 
                base(Init())
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IIncorrectFormulaWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IIncorrectFormulaWindowControls Controls
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
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIncorrectFormulaWindowControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, IncorrectFormulaWindow.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIncorrectFormulaWindowControls.FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl
        {
            get
            {
                if ((this.cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl == null))
                {
                    this.cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl = new StaticControl(this, IncorrectFormulaWindow.ControlIDs.FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl);
                }
                return this.cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>       
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init()
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.WindowTitle
                    + "*",
                    StringMatchSyntax.WildCard);
                // These additional parameters were generated by DialogMaker
                // , however; they are not necessary and often cause the
                // window constructor to fail.
                // , WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, ownerWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the wizard dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 10;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.WindowTitle + "'");
                //app.LogMessage("Looking for window with title:  '"
                //    + Strings.WindowTitle + "'");
                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the window again using wildcard matching
                        tempWindow = new Window(
                            Strings.WindowTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                        //app.LogMessage("Attempt "
                        //    + numberOfTries
                        //    + " of "
                        //    + MAXTRIES
                        //    + "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.WindowTitle
                        + "'.\n\n" + ex.Message);
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowTitle = "Microsoft Operations Manager";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = "OK";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FormulaIncorrectPleaseCorrectTheFormulaAndTryAgain
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaIncorrectPleaseCorrectTheFormulaAndTryAgain = "Formula incorrect. Please correct the formula and try again.";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FormulaIncorrectPleaseCorrectTheFormulaAndTryAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgain;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 20-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 20-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FormulaIncorrectPleaseCorrectTheFormulaAndTryAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 20-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaIncorrectPleaseCorrectTheFormulaAndTryAgain
            {
                get
                {
                    if ((cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgain == null))
                    {
                        cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgain = CoreManager.MomConsole.GetIntlStr(ResourceFormulaIncorrectPleaseCorrectTheFormulaAndTryAgain);
                    }
                    return cachedFormulaIncorrectPleaseCorrectTheFormulaAndTryAgain;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 20-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 2;
            
            /// <summary>
            /// Control ID for FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl
            /// </summary>
            public const int FormulaIncorrectPleaseCorrectTheFormulaAndTryAgainStaticControl = 65535;
        }
        #endregion
    }
}
