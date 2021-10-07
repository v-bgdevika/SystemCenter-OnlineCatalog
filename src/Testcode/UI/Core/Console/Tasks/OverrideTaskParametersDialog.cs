// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OverrideTaskParametersDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	Mom.Test.UI.Core.Console.Tasks
// </project>
// <summary>
// 	Contains Helper class to provide accessiblity to the "Override Task Parameters Dialog" 
//  for tasks automation
// </summary>
// <history>
// 	[jefftow] 12/6/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IOverrideTaskParametersDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOverrideTaskParametersDialogControls, for OverrideTaskParametersDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[asttest] 12/6/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOverrideTaskParametersDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OverrideButton
        /// </summary>
        Button OverrideButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OverrideTheTaskParametersWithTheNewValuesPropertyGridView
        /// </summary>
        PropertyGridView OverrideTheTaskParametersWithTheNewValuesPropertyGridView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ComboBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox0
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OverrideTheTaskParametersWithTheNewValuesStaticControl
        /// </summary>
        StaticControl OverrideTheTaskParametersWithTheNewValuesStaticControl
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
    /// 	[asttest] 12/6/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OverrideTaskParametersDialog : Dialog, IOverrideTaskParametersDialogControls
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
        /// Cache to hold a reference to OverrideButton of type Button
        /// </summary>
        private Button cachedOverrideButton;

        /// <summary>
        /// Cache to hold a reference to OverrideTheTaskParametersWithTheNewValuesPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedOverrideTheTaskParametersWithTheNewValuesPropertyGridView;

        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;

        /// <summary>
        /// Cache to hold a reference to OverrideTheTaskParametersWithTheNewValuesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOverrideTheTaskParametersWithTheNewValuesStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OverrideTaskParametersDialog of type App
        /// </param>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OverrideTaskParametersDialog(App app)
            :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IOverrideTaskParametersDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOverrideTaskParametersDialogControls Controls
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
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox0Text
        {
            get
            {
                return this.Controls.ComboBox0.Text;
            }

            set
            {
                this.Controls.ComboBox0.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverrideTaskParametersDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OverrideTaskParametersDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverrideButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverrideTaskParametersDialogControls.OverrideButton
        {
            get
            {
                if ((this.cachedOverrideButton == null))
                {
                    this.cachedOverrideButton = new Button(this, OverrideTaskParametersDialog.ControlIDs.OverrideButton);
                }

                return this.cachedOverrideButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverrideTheTaskParametersWithTheNewValuesPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IOverrideTaskParametersDialogControls.OverrideTheTaskParametersWithTheNewValuesPropertyGridView
        {
            get
            {
                if ((this.cachedOverrideTheTaskParametersWithTheNewValuesPropertyGridView == null))
                {
                    this.cachedOverrideTheTaskParametersWithTheNewValuesPropertyGridView = new PropertyGridView(this, OverrideTaskParametersDialog.ControlIDs.OverrideTheTaskParametersWithTheNewValuesPropertyGridView);
                }

                return this.cachedOverrideTheTaskParametersWithTheNewValuesPropertyGridView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOverrideTaskParametersDialogControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedComboBox0 = new ComboBox(wndTemp);
                }

                return this.cachedComboBox0;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverrideTheTaskParametersWithTheNewValuesStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverrideTaskParametersDialogControls.OverrideTheTaskParametersWithTheNewValuesStaticControl
        {
            get
            {
                if ((this.cachedOverrideTheTaskParametersWithTheNewValuesStaticControl == null))
                {
                    this.cachedOverrideTheTaskParametersWithTheNewValuesStaticControl = new StaticControl(this, OverrideTaskParametersDialog.ControlIDs.OverrideTheTaskParametersWithTheNewValuesStaticControl);
                }

                return this.cachedOverrideTheTaskParametersWithTheNewValuesStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Override
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOverride()
        {
            this.Controls.OverrideButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle + "*", 
                                        StringMatchSyntax.WildCard, 
                                        WindowClassNames.WinForms10Window8, 
                                        StringMatchSyntax.WildCard, 
                                        app.MainWindow, 
                                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                         Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                         // wait for a moment before trying again
                         Maui.Core.Utilities.Sleeper.Delay(Timeout);
                     }
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
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Override Task Parameters
            /// </summary>

            #region Constants
            public const string ResourceDialogTitle = ";Override Task Parameters;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.TaskOverridesDialog;$this.Text";


            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";

            /// <summary>
            /// Resource string for Override
            /// </summary>
            public const string Override = "&Override";

            /// <summary>
            /// Resource string for Override the task parameters with the new values
            /// </summary>
            public const string OverrideTheTaskParametersWithTheNewValues = "Override the t&ask parameters with the new values";
            #endregion 

            #region Private Members
            private static string cachedDialogTitle;
            #endregion 

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            #endregion

        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[asttest] 12/6/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for OverrideButton
            /// </summary>
            public const string OverrideButton = "overrideButton";

            /// <summary>
            /// Control ID for OverrideTheTaskParametersWithTheNewValuesPropertyGridView
            /// </summary>
            public const string OverrideTheTaskParametersWithTheNewValuesPropertyGridView = "overridesView";

            /// <summary>
            /// Control ID for OverrideTheTaskParametersWithTheNewValuesStaticControl
            /// </summary>
            public const string OverrideTheTaskParametersWithTheNewValuesStaticControl = "overridesLabel";
        }
        #endregion
    }
}
