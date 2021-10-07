// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SingleAlertPickerComponent.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//  SingleAlertPickerComponent Controls
// </summary>
// <history>
//   [v-lileo] 11/29/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #region Interface Definition - ISinglePickerComponentControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISinglePickerComponentControls, for Window.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/29/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISinglePickerComponentControls
    {
        /// <summary>
        /// Gets read-only property to access SingleAlertPickerComponentStaticControl
        /// </summary>
        StaticControl SingleAlertPickerComponentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SinglePickerComponentSelectionText
        /// </summary>
        StaticControl SinglePickerComponentSelectionText
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Button
        /// </summary>
        Button LauncherButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add SinglePickerComponent functionality description here.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/29/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SinglePickerComponent : Control, ISinglePickerComponentControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SingleAlertPickerComponentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSingleAlertPickerComponentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SingleAlertPickerComponentTextBox of type StaticControl
        /// </summary>
        private StaticControl cachedSingleAlertPickerComponentTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Button of type Button
        /// </summary>
        private Button cachedLauncherButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Window class.
        /// </summary>
        /// <param name='app'></param>
        /// <param name='timeOut'></param>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SinglePickerComponent(Window KnownWindow, int timeOut) :
            base(Init(KnownWindow, timeOut))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ISinglePickerComponent Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the SingleAlertPickerComponent's control properties together</value>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISinglePickerComponentControls Controls
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
        ///  Gets access to the SingleAlertPickerComponentStaticControl control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISinglePickerComponentControls.SingleAlertPickerComponentStaticControl
        {
            get
            {
                if ((this.cachedSingleAlertPickerComponentStaticControl == null))
                {
                    this.cachedSingleAlertPickerComponentStaticControl = new StaticControl(this, SinglePickerComponent.QueryIds.SingleAlertPickerComponentStaticControl);
                }
                
                return this.cachedSingleAlertPickerComponentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SinglePickerComponentSelection TextBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISinglePickerComponentControls.SinglePickerComponentSelectionText
        {
            get
            {
                if ((this.cachedSingleAlertPickerComponentTextBox == null))
                {

                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            this.cachedSingleAlertPickerComponentTextBox = new StaticControl(this, SinglePickerComponent.QueryIds.SinglePickerComponentSelectionText);
                            break;
                        case ProductSkuLevel.Web:
                            this.cachedSingleAlertPickerComponentTextBox = new StaticControl(this, new QID(";[UIA]AutomationId=\'textBlock\'"));
                            break;
                    }
                }
                
                return this.cachedSingleAlertPickerComponentTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LauncherButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISinglePickerComponentControls.LauncherButton
        {
            get
            {
                if ((this.cachedLauncherButton == null))
                {
                    this.cachedLauncherButton = new Button(this, SinglePickerComponent.QueryIds.LauncherButton);
                }
                
                return this.cachedLauncherButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ClearButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISinglePickerComponentControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, SinglePickerComponent.QueryIds.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Launcher
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLauncherButton()
        {
            this.Controls.LauncherButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="app"></param>
        ///  <param name="timeOut"></param>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Window KnownWindow, int timeOut)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                switch(ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        tempWindow = new Window(KnownWindow, new QID(";[UIA, VisibleOnly]ClassName = '" + Strings.SingleAlertPickerComponentTitle + "'"), timeOut);
                        break;
                    case ProductSkuLevel.Web:
                        tempWindow = KnownWindow;
                        break;
                }                
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(KnownWindow, new QID(";[UIA, VisibleOnly]ClassName = '" + Strings.SingleAlertPickerComponentTitle + "'"), timeOut);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw;
                }
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SingleAlertPickerComponentStaticControl query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSingleAlertPickerComponentStaticControl = ";[UIA]AutomationId=\'SinglePickerComponentTitle\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SinglePickerComponentSelectionText query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSinglePickerComponentSelectionText = ";[UIA]AutomationId=\'SinglePickerComponentSelection\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LauncherButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLauncherButton = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ClearButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClearButton = ";[UIA]AutomationId=\'SinglePickerComponentClearButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SingleAlertPickerComponentStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/29/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SingleAlertPickerComponentStaticControl
            {
                get
                {
                    return new QID(ResourceSingleAlertPickerComponentStaticControl);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SinglePickerComponentSelectionText resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/29/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SinglePickerComponentSelectionText
            {
                get
                {
                    return new QID(ResourceSinglePickerComponentSelectionText);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the LauncherButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/29/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LauncherButton
            {
                get
                {
                    return new QID(ResourceLauncherButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ClearButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/29/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ClearButton
            {
                get
                {
                    return new QID(ResourceClearButton);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for 
            /// </summary>
            public const string SingleAlertPickerComponentTitle = "SinglePickerComponent";
        }
        #endregion
    }
}
