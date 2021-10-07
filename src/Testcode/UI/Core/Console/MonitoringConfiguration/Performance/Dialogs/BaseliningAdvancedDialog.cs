// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BaseliningAdvancedDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 29APR06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IBaselining_AdvancedDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBaselining_AdvancedDialogControls, for Baselining_AdvancedDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBaselining_AdvancedDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OkButton
        /// </summary>
        Button OkButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighStaticControl
        /// </summary>
        StaticControl HighStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowStaticControl
        /// </summary>
        StaticControl LowStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceCounterTrackBar
        /// </summary>
        TrackBar PerformanceCounterTrackBar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeVariabilityStaticControl
        /// </summary>
        StaticControl TimeVariabilityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighStaticControl2
        /// </summary>
        StaticControl HighStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowStaticControl2
        /// </summary>
        StaticControl LowStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowTrackBar
        /// </summary>
        TrackBar LowTrackBar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LearningRateStaticControl
        /// </summary>
        StaticControl LearningRateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl
        /// </summary>
        StaticControl EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl
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
    /// 	[mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class Baselining_AdvancedDialog : Dialog, IBaselining_AdvancedDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OkButton of type Button
        /// </summary>
        private Button cachedOkButton;
        
        /// <summary>
        /// Cache to hold a reference to HighStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHighStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LowStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLowStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceCounterTrackBar of type TrackBar
        /// </summary>
        private TrackBar cachedPerformanceCounterTrackBar;
        
        /// <summary>
        /// Cache to hold a reference to TimeVariabilityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeVariabilityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HighStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedHighStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to LowStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedLowStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to LowTrackBar of type TrackBar
        /// </summary>
        private TrackBar cachedLowTrackBar;
        
        /// <summary>
        /// Cache to hold a reference to LearningRateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLearningRateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of Baselining_AdvancedDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Baselining_AdvancedDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IBaselining_AdvancedDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBaselining_AdvancedDialogControls Controls
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
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaselining_AdvancedDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, Baselining_AdvancedDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OkButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaselining_AdvancedDialogControls.OkButton
        {
            get
            {
                if ((this.cachedOkButton == null))
                {
                    this.cachedOkButton = new Button(this, Baselining_AdvancedDialog.ControlIDs.OkButton);
                }
                return this.cachedOkButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.HighStaticControl
        {
            get
            {
                if ((this.cachedHighStaticControl == null))
                {
                    this.cachedHighStaticControl = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.HighStaticControl);
                }
                return this.cachedHighStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.LowStaticControl
        {
            get
            {
                if ((this.cachedLowStaticControl == null))
                {
                    this.cachedLowStaticControl = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.LowStaticControl);
                }
                return this.cachedLowStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceCounterTrackBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TrackBar IBaselining_AdvancedDialogControls.PerformanceCounterTrackBar
        {
            get
            {
                if ((this.cachedPerformanceCounterTrackBar == null))
                {
                    this.cachedPerformanceCounterTrackBar = new TrackBar(this, Baselining_AdvancedDialog.ControlIDs.PerformanceCounterTrackBar);
                }
                return this.cachedPerformanceCounterTrackBar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeVariabilityStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.TimeVariabilityStaticControl
        {
            get
            {
                if ((this.cachedTimeVariabilityStaticControl == null))
                {
                    this.cachedTimeVariabilityStaticControl = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.TimeVariabilityStaticControl);
                }
                return this.cachedTimeVariabilityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.HighStaticControl2
        {
            get
            {
                if ((this.cachedHighStaticControl2 == null))
                {
                    this.cachedHighStaticControl2 = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.HighStaticControl2);
                }
                return this.cachedHighStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.LowStaticControl2
        {
            get
            {
                if ((this.cachedLowStaticControl2 == null))
                {
                    this.cachedLowStaticControl2 = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.LowStaticControl2);
                }
                return this.cachedLowStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowTrackBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TrackBar IBaselining_AdvancedDialogControls.LowTrackBar
        {
            get
            {
                if ((this.cachedLowTrackBar == null))
                {
                    this.cachedLowTrackBar = new TrackBar(this, Baselining_AdvancedDialog.ControlIDs.LowTrackBar);
                }
                return this.cachedLowTrackBar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LearningRateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.LearningRateStaticControl
        {
            get
            {
                if ((this.cachedLearningRateStaticControl == null))
                {
                    this.cachedLearningRateStaticControl = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.LearningRateStaticControl);
                }
                return this.cachedLearningRateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaselining_AdvancedDialogControls.EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl
        {
            get
            {
                if ((this.cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl == null))
                {
                    this.cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl = new StaticControl(this, Baselining_AdvancedDialog.ControlIDs.EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl);
                }
                return this.cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ok
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOk()
        {
            this.Controls.OkButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                // 
                // app.DTE.ExecuteCmd(Commands.COMMAND_NAME_HERE);
                // 
                // tempWindow = new Window(Strings.DialogTitle, Utilities.StringMatchSyntax.ExactMatch, strDialogClass, Utilities.StringMatchSyntax.ExactMatch, app.MainWindow, timeOut);
                // if (tempWindow != null)
                //     return tempWindow;
                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + "." + ex);
            }

            return tempWindow;
        }       
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
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
            private const string ResourceDialogTitle = ";Baselining - Advanced;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedPage;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ok
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOk = ";Ok;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursForm;" +
                "submitButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  High
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHigh = ";High;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.Cache.AlertTranslator;PriorityHigh";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Low
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLow = ";Low;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom" +
                ".Internal.UI.Cache.AlertTranslator;PriorityLow";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TimeVariability
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeVariability = "Time Variability:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  High2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHigh2 = ";High;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.Cache.AlertTranslator;PriorityHigh";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Low2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLow2 = ";Low;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom" +
                ".Internal.UI.Cache.AlertTranslator;PriorityLow";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LearningRate
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceLearningRate = "Learning rate:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EstablishTheLearningRateAndTheTimeVariabilityForYourBaseline
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEstablishTheLearningRateAndTheTimeVariabilityForYourBaseline = "Establish the learning rate and the time variability for your baseline.";
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
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ok
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOk;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  High
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHigh;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Low
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLow;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TimeVariability
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeVariability;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  High2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHigh2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Low2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLow2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LearningRate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLearningRate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EstablishTheLearningRateAndTheTimeVariabilityForYourBaseline
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaseline;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ok translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ok
            {
                get
                {
                    if ((cachedOk == null))
                    {
                        cachedOk = CoreManager.MomConsole.GetIntlStr(ResourceOk);
                    }
                    return cachedOk;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the High translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string High
            {
                get
                {
                    if ((cachedHigh == null))
                    {
                        cachedHigh = CoreManager.MomConsole.GetIntlStr(ResourceHigh);
                    }
                    return cachedHigh;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Low translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Low
            {
                get
                {
                    if ((cachedLow == null))
                    {
                        cachedLow = CoreManager.MomConsole.GetIntlStr(ResourceLow);
                    }
                    return cachedLow;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeVariability translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeVariability
            {
                get
                {
                    if ((cachedTimeVariability == null))
                    {
                        cachedTimeVariability = CoreManager.MomConsole.GetIntlStr(ResourceTimeVariability);
                    }
                    return cachedTimeVariability;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the High2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string High2
            {
                get
                {
                    if ((cachedHigh2 == null))
                    {
                        cachedHigh2 = CoreManager.MomConsole.GetIntlStr(ResourceHigh2);
                    }
                    return cachedHigh2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Low2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Low2
            {
                get
                {
                    if ((cachedLow2 == null))
                    {
                        cachedLow2 = CoreManager.MomConsole.GetIntlStr(ResourceLow2);
                    }
                    return cachedLow2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LearningRate translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LearningRate
            {
                get
                {
                    if ((cachedLearningRate == null))
                    {
                        cachedLearningRate = CoreManager.MomConsole.GetIntlStr(ResourceLearningRate);
                    }
                    return cachedLearningRate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EstablishTheLearningRateAndTheTimeVariabilityForYourBaseline translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EstablishTheLearningRateAndTheTimeVariabilityForYourBaseline
            {
                get
                {
                    if ((cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaseline == null))
                    {
                        cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaseline = CoreManager.MomConsole.GetIntlStr(ResourceEstablishTheLearningRateAndTheTimeVariabilityForYourBaseline);
                    }
                    return cachedEstablishTheLearningRateAndTheTimeVariabilityForYourBaseline;
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
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "Cancelbutton";
            
            /// <summary>
            /// Control ID for OkButton
            /// </summary>
            public const string OkButton = "Okbutton";
            
            /// <summary>
            /// Control ID for HighStaticControl
            /// </summary>
            public const string HighStaticControl = "label5";
            
            /// <summary>
            /// Control ID for LowStaticControl
            /// </summary>
            public const string LowStaticControl = "label6";
            
            /// <summary>
            /// Control ID for PerformanceCounterTrackBar
            /// </summary>
            public const string PerformanceCounterTrackBar = "TimeVariability_trackbar";
            
            /// <summary>
            /// Control ID for TimeVariabilityStaticControl
            /// </summary>
            public const string TimeVariabilityStaticControl = "label7";
            
            /// <summary>
            /// Control ID for HighStaticControl2
            /// </summary>
            public const string HighStaticControl2 = "label4";
            
            /// <summary>
            /// Control ID for LowStaticControl2
            /// </summary>
            public const string LowStaticControl2 = "label3";
            
            /// <summary>
            /// Control ID for LowTrackBar
            /// </summary>
            public const string LowTrackBar = "LearningRate_trackBar";
            
            /// <summary>
            /// Control ID for LearningRateStaticControl
            /// </summary>
            public const string LearningRateStaticControl = "label2";
            
            /// <summary>
            /// Control ID for EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl
            /// </summary>
            public const string EstablishTheLearningRateAndTheTimeVariabilityForYourBaselineStaticControl = "label1";
        }
        #endregion
    }
}
