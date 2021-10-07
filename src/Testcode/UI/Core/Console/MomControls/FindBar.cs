// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="FindBar.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  FindBar Control
// </summary>
// <history>
//  [mbickle] 27MAR06 Created
//  [mbickle] 18JUL06 Added LookForItem method.
//                    Changed LookForText property to use SendKeys as the other way was causing
//                    issues Authoring views.
//  [kellymor]21JUL06 Modified while logic to prevent repeating the
//                    search term over and over in the 'Find' text box
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - IFindBarControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IFindBarControls, for FindBar.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///  [mbickle] 27MAR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFindBarControls
    {
        /// <summary>
        /// Read-only property to access XButton
        /// </summary>
        Button XButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FindNowButton
        /// </summary>
        Button FindNowButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForTextBox
        /// </summary>
        TextBox LookForTextBox
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
    ///  [mbickle] 27MAR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FindBar : Control, IFindBarControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to XButton of type Button
        /// </summary>
        private Button cachedXButton;

        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;

        /// <summary>
        /// Cache to hold a reference to FindNowButton of type Button
        /// </summary>
        private Button cachedFindNowButton;

        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;

        /// <summary>
        /// Cache to hold a reference to LookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='startWindow'>Window</param>
        /// <param name="winformsId">WinformsID</param>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public FindBar(Window startWindow, string winformsId)
            : base(Init(startWindow, winformsId))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IFindBar Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IFindBarControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LookFor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookForText
        {
            get
            {
                return this.Controls.LookForTextBox.Text;
            }

            set
            {
                this.Controls.LookForTextBox.SendKeys(Keyboard.EscapeSpecialCharacters(value));
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the XButton control
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindBarControls.XButton
        {
            get
            {
                if ((this.cachedXButton == null))
                {
                    this.cachedXButton = new Button(this, FindBar.ControlIDs.XButton);
                }

                return this.cachedXButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindBarControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, FindBar.ControlIDs.ClearButton);
                }

                return this.cachedClearButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindNowButton control
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindBarControls.FindNowButton
        {
            get
            {
                if ((this.cachedFindNowButton == null))
                {
                    this.cachedFindNowButton = new Button(this, FindBar.ControlIDs.FindNowButton);
                }

                return this.cachedFindNowButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindBarControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, FindBar.ControlIDs.LookForStaticControl);
                }

                return this.cachedLookForStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTextBox control
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IFindBarControls.LookForTextBox
        {
            get
            {
                if ((this.cachedLookForTextBox == null))
                {
                    this.cachedLookForTextBox = new TextBox(this, FindBar.ControlIDs.LookForTextBox);
                }

                return this.cachedLookForTextBox;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button X
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickX()
        {
            this.Controls.XButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            //Workaround for bug#184525
            //Clear button is disabled if a single character is used as input for filtering
            if (!this.Controls.ClearButton.IsEnabled && this.LookForText.Length ==1)
            {
                //Input another character 'a' to make ClearButton Enable
                this.LookForText = "a";
            }

            this.Controls.ClearButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FindNow
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFindNow()
        {
            this.Controls.FindNowButton.Click();
        }
        #endregion

        /// -------------------------------------------------------------------
        /// <summary>
        /// Uses the FindBar to Look For specified Item.
        /// </summary>
        /// <param name="findItem">Find Item</param>
        /// <history>
        /// [mbickle] 18JUL06 Created
        /// [kellymor]21JUL06 Modified while logic to prevent repeating the
        ///                   search term over and over in the 'Find' text box
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void LookForItem(string findItem)
        {
            int timeout = 60000;
            FindBar find = this;
            int retry = 0;
            int maxretry = 5;

            // Clear LookForText.
            find.ClickClear();
            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, timeout);

            //Refresh the view first
            CoreManager.MomConsole.Refresh();

            Utilities.LogMessage("FindBar.LookForItem:: '" + findItem + "'");
            Utilities.TakeScreenshot("FindBar.LookForItem.Before");

            // set LookForText
            // workaround for bug 219971
            UIUtilities.SetControlValue(find.Controls.LookForTextBox, findItem);

            // wait for the text field to update
            Utilities.LogMessage(
                "FindBar.LookForItem:: Waiting for text field to update...");
            while (find.LookForText != findItem && retry <= maxretry)
            {
                // increment the counter and log the attempt
                retry++;
                Utilities.LogMessage(
                    "FindBar.LookForItem:: Waiting 30 seconds, " +
                    "Attempt " +
                    retry +
                    " of " +
                    maxretry);

                // wait for 30 seconds
                find.WaitForResponse(30000);

                // Bug#205239: If the LookForText is still not as expected after waiting 30 seconds, set it again.
                if (find.LookForText != findItem)
                {
                    find.ClickClear();
                    CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, timeout);
                    CoreManager.MomConsole.Refresh();
                    find.LookForText = findItem;
                }
            }

            // verify find text is updated
            if (true == find.LookForText.Equals(findItem))
            {
                // force the grid to filter by the search term
                find.ClickFindNow();
                CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, timeout);

                //Wait 'Find Now' button enable to make sure the grid view finished loading
                int maxCheckTimes = Constants.DefaultViewLoadTimeout / Constants.OneSecond;
                for (int i = 0; i < maxCheckTimes; i++)
                {
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    if (CoreManager.MomConsole.ViewPane.Find.Controls.FindNowButton.IsEnabled)
                    {
                        Utilities.LogMessage("FindBar.LookForItem:: Finish loading.");
                        break;
                    }
                    Utilities.LogMessage("FindBar.LookForItem::Find Now button is disabled. View is loading.");
                    Utilities.LogMessage("FindBar.LookForItem::Attempt " + i + " of " + maxCheckTimes);
                }
            }
            else
            {
                // the LookForText field did not update with the search term
                throw new Maui.GlobalExceptions.MauiException(
                    "Failed to update the 'Find' text field with search term:  '" +
                    findItem +
                    "'");
            }
            
            Utilities.TakeScreenshot("FindBar.LookForItem.After");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>Control.</returns>
        /// <param name="startWindow">Window that hosts this control (ie: ViewPane)</param>)
        /// <param name="winformsId">WinformsID</param>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Control Init(Window startWindow, string winformsId)
        {                
            // First check if the window is already up.
            Control tempControl = null;
            try
            {
                Utilities.LogMessage("FindBar.Init:: Init FindBar");

                // Try to locate an existing instance of a window
                tempControl = new Control(startWindow, winformsId, true, Constants.OneMinute);
                tempControl.Extended.Click();

                Utilities.LogMessage("FindBar.Init:: Found Control Reference");
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                throw new Control.Exceptions.WindowNotFoundException("Init function could not find the Control. " + ex);
            }
            catch (System.Exception e)
            {
                Utilities.LogMessage("FindBar.Init:: "+e.Message);
            }

            return tempControl;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class Strings
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
            private const string ResourceWindowTitle = "*";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  X
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceX = ";X;ManagedString;Microsoft.Mom.Modules.ClientMonitoring.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Modules.ClientMonitoring.Resources;InvalidUrlWordReplacementCharac" +
                "ter";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";&Clear;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Controls.FindBar;clearButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FindNow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFindNow = ";&Find Now;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.Controls.FindBar;findButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";&Look For:;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Controls.FindBar;lookForLabel.Text";
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
            /// Caches the translated resource string for:  X
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedX;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FindNow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFindNow;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 27MAR06 Created
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
            /// Exposes access to the X translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 27MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string X
            {
                get
                {
                    if ((cachedX == null))
                    {
                        cachedX = CoreManager.MomConsole.GetIntlStr(ResourceX);
                    }

                    return cachedX;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 27MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Clear
            {
                get
                {
                    if ((cachedClear == null))
                    {
                        cachedClear = CoreManager.MomConsole.GetIntlStr(ResourceClear);
                    }

                    return cachedClear;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FindNow translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 27MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FindNow
            {
                get
                {
                    if ((cachedFindNow == null))
                    {
                        cachedFindNow = CoreManager.MomConsole.GetIntlStr(ResourceFindNow);
                    }

                    return cachedFindNow;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 27MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = CoreManager.MomConsole.GetIntlStr(ResourceLookFor);
                    }

                    return cachedLookFor;
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
        ///  [mbickle] 27MAR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class ControlIDs
        {
            /// <summary>
            /// Control ID for XButton
            /// </summary>
            public const string XButton = "hideButton";

            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearButton";

            /// <summary>
            /// Control ID for FindNowButton
            /// </summary>
            public const string FindNowButton = "findButton";

            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";

            /// <summary>
            /// Control ID for LookForTextBox
            /// </summary>
            public const string LookForTextBox = "lookForTextbox";
        }
        #endregion
    }
}
