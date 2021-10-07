// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ChoosescaleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 5/31/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    
    #region Interface Definition - IChoosescaleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IChoosescaleDialogControls, for ChoosescaleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IChoosescaleDialogControls
    {
        /// <summary>
        /// Read-only property to access _1xStaticControl
        /// </summary>
        StaticControl _1xStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheScaleFactorForThisCounterStaticControl
        /// </summary>
        StaticControl SelectTheScaleFactorForThisCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AndBeforeSlider
        /// </summary>
        TrackBar AndBeforeSlider
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ChoosescaleDialog : Dialog, IChoosescaleDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to _1xStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_1xStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheScaleFactorForThisCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheScaleFactorForThisCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to AndBeforeSlider of type Slider
        /// </summary>
        private TrackBar cachedAndBeforeSlider;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ChoosescaleDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ChoosescaleDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IChoosescaleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IChoosescaleDialogControls Controls
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
        ///  Exposes access to the _1xStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChoosescaleDialogControls._1xStaticControl
        {
            get
            {
                if ((this.cached_1xStaticControl == null))
                {
                    this.cached_1xStaticControl = new StaticControl(this, ChoosescaleDialog.ControlIDs._1xStaticControl);
                }
                
                return this.cached_1xStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheScaleFactorForThisCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChoosescaleDialogControls.SelectTheScaleFactorForThisCounterStaticControl
        {
            get
            {
                if ((this.cachedSelectTheScaleFactorForThisCounterStaticControl == null))
                {
                    this.cachedSelectTheScaleFactorForThisCounterStaticControl = new StaticControl(this, ChoosescaleDialog.ControlIDs.SelectTheScaleFactorForThisCounterStaticControl);
                }
                
                return this.cachedSelectTheScaleFactorForThisCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChoosescaleDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ChoosescaleDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChoosescaleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ChoosescaleDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndBeforeSlider control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TrackBar IChoosescaleDialogControls.AndBeforeSlider
        {
            get
            {
                if ((this.cachedAndBeforeSlider == null))
                {
                    this.cachedAndBeforeSlider = new TrackBar(this, ChoosescaleDialog.ControlIDs.AndBeforeSlider);
                }
                
                return this.cachedAndBeforeSlider;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                
                 tempWindow = null;
                 int numberOfTries = 0;
                 const int MaxTries = 5;
                 while (tempWindow == null && numberOfTries < MaxTries)
                 {
                     numberOfTries++;
                     try
                     {
                         // look for the window again using wildcards
                         tempWindow =
                             new Window(
                                 Strings.DialogTitle + "*",
                                 StringMatchSyntax.WildCard,
                                 WindowClassNames.WinForms10Window8,
                                 StringMatchSyntax.WildCard,
                                 app,
                                 Timeout);
                 
                         // wait for the window to report ready
                         UISynchronization.WaitForUIObjectReady(
                             tempWindow,
                             Timeout);
                     }
                     catch (Exceptions.WindowNotFoundException)
                     {
                         // log the unsuccessful attempt
                         Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                         
                         // wait for a moment before trying again
                         Maui.Core.Utilities.Sleeper.Delay(Timeout);
                     }
                 }
                 
                 // check for success
                 if (tempWindow == null)
                 {
                     // log the failure
                 
                     // throw the existing WindowNotFound exception
                     throw ex;
                 }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Choose scale;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceScalePicker;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _1x
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_1x = ";1x;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement." +
                "Mom.UI.PerformanceScalePicker;scaleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheScaleFactorForThisCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheScaleFactorForThisCounter = ";Select the scale factor for this counter;ManagedString;Microsoft.MOM.UI.Componen" +
                "ts.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceScalePicker;captionLabel" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _1x
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_1x;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheScaleFactorForThisCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheScaleFactorForThisCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _1x translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _1x
            {
                get
                {
                    if ((cached_1x == null))
                    {
                        cached_1x = CoreManager.MomConsole.GetIntlStr(Resource_1x);
                    }
                    
                    return cached_1x;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheScaleFactorForThisCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheScaleFactorForThisCounter
            {
                get
                {
                    if ((cachedSelectTheScaleFactorForThisCounter == null))
                    {
                        cachedSelectTheScaleFactorForThisCounter = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheScaleFactorForThisCounter);
                    }
                    
                    return cachedSelectTheScaleFactorForThisCounter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    
                    return cachedCancel;
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
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for _1xStaticControl
            /// </summary>
            public const string _1xStaticControl = "scaleLabel";
            
            /// <summary>
            /// Control ID for SelectTheScaleFactorForThisCounterStaticControl
            /// </summary>
            public const string SelectTheScaleFactorForThisCounterStaticControl = "captionLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for AndBeforeSlider
            /// </summary>
            public const string AndBeforeSlider = "scaleSlider";
        }
        #endregion
    }
}
