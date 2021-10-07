// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectTargetTypeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 7/13/2006 Created
//  [ruhim]  4/12/07 Adding resource string for Target Header
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;
    using Microsoft.EnterpriseManagement.Mom.Internal;

    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[dialac] 7/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// ViewAllTargets = 0
        /// </summary>
        ViewAllTargets = 0,

        /// <summary>
        /// ViewCommonTargets = 1
        /// </summary>
        ViewCommonTargets = 1,
    }
    #endregion

    #region Interface Definition - ISelectTargetTypeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectTargetTypeDialogControls, for SelectTargetTypeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 7/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectTargetTypeDialogControls
    {
        /// <summary>
        /// Read-only property to access ViewAllTargetsRadioButton
        /// </summary>
        RadioButton ViewAllTargetsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewCommonTargetsRadioButton
        /// </summary>
        RadioButton ViewCommonTargetsRadioButton
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
        /// Read-only property to access _111TotalTargets24Visible1SelectedStaticControl
        /// </summary>
        StaticControl _111TotalTargets24Visible1SelectedStaticControl
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

        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ListView0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListView ListView0
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
        /// Read-only property to access SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        /// </summary>
        StaticControl SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
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
    /// 	[dialac] 7/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectTargetTypeDialog : Dialog, ISelectTargetTypeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ViewAllTargetsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedViewAllTargetsRadioButton;

        /// <summary>
        /// Cache to hold a reference to ViewCommonTargetsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedViewCommonTargetsRadioButton;

        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;

        /// <summary>
        /// Cache to hold a reference to _111TotalTargets24Visible1SelectedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_111TotalTargets24Visible1SelectedStaticControl;

        /// <summary>
        /// Cache to hold a reference to LookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;

        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;

        /// <summary>
        /// Cache to hold a reference to ListView0 of type ListView
        /// </summary>
        private ListView cachedListView0;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectTargetTypeDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectTargetTypeDialog(MomConsoleApp app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.ViewAllTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.ViewAllTargets;
                }

                if ((this.Controls.ViewCommonTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.ViewCommonTargets;
                }

                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == RadioGroup0.ViewAllTargets))
                {
                    this.Controls.ViewAllTargetsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.ViewCommonTargets))
                    {
                        this.Controls.ViewCommonTargetsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region ISelectTargetTypeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectTargetTypeDialogControls Controls
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
        /// 	[dialac] 7/13/2006 Created
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
                UIUtilities.SetControlValue(this.Controls.LookForTextBox, value);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllTargetsRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISelectTargetTypeDialogControls.ViewAllTargetsRadioButton
        {
            get
            {
                if ((this.cachedViewAllTargetsRadioButton == null))
                {
                    this.cachedViewAllTargetsRadioButton = new RadioButton(this, SelectTargetTypeDialog.ControlIDs.ViewAllTargetsRadioButton);
                }

                return this.cachedViewAllTargetsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewCommonTargetsRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISelectTargetTypeDialogControls.ViewCommonTargetsRadioButton
        {
            get
            {
                if ((this.cachedViewCommonTargetsRadioButton == null))
                {
                    this.cachedViewCommonTargetsRadioButton = new RadioButton(this, SelectTargetTypeDialog.ControlIDs.ViewCommonTargetsRadioButton);
                }

                return this.cachedViewCommonTargetsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTargetTypeDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, SelectTargetTypeDialog.ControlIDs.ClearButton);
                }

                return this.cachedClearButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _111TotalTargets24Visible1SelectedStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTargetTypeDialogControls._111TotalTargets24Visible1SelectedStaticControl
        {
            get
            {
                if ((this.cached_111TotalTargets24Visible1SelectedStaticControl == null))
                {
                    this.cached_111TotalTargets24Visible1SelectedStaticControl = new StaticControl(this, SelectTargetTypeDialog.ControlIDs._111TotalTargets24Visible1SelectedStaticControl);
                }

                return this.cached_111TotalTargets24Visible1SelectedStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectTargetTypeDialogControls.LookForTextBox
        {
            get
            {
                if ((this.cachedLookForTextBox == null))
                {
                    this.cachedLookForTextBox = new TextBox(this, SelectTargetTypeDialog.ControlIDs.LookForTextBox);
                }

                return this.cachedLookForTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTargetTypeDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, SelectTargetTypeDialog.ControlIDs.LookForStaticControl);
                }

                return this.cachedLookForStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListView0 control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectTargetTypeDialogControls.ListView0
        {
            get
            {
                if ((this.cachedListView0 == null))
                {
                    this.cachedListView0 = new ListView(this, SelectTargetTypeDialog.ControlIDs.ListView0);
                }

                return this.cachedListView0;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTargetTypeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectTargetTypeDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTargetTypeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectTargetTypeDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTargetTypeDialogControls.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        {
            get
            {
                if ((this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                {
                    this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = new StaticControl(this,SelectTargetTypeDialog.ControlIDs.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                }

                return this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 7/13/2006 Created
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
        /// 	[dialac] 7/13/2006 Created
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
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Utilities.LogMessage("Try to find dialog with title '" + Strings.DialogTitle + "'");

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
        /// 	[dialac] 7/13/2006 Created
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
            //private const string ResourceDialogTitle = "Select a Target Type";
            private const string ResourceDialogTitle =
                ";Select Items to Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;SelectTargetCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewAllTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllTargets = ";View &all targets;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;allTargetsRBt" +
                "n.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewCommonTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewCommonTargets = ";View c&ommon targets;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;commonTarg" +
                "etsRBtn.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";Clear;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;clearSearchButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _111TotalTargets24Visible1Selected
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_111TotalTargets24Visible1Selected = "111 total Targets, 24 visible, 1 selected";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";&Look for:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;lookForLabel.Text";

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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = @";Select the target you want to use from the list below. You can also use the ""Look for:"" field below to filter down to a specific target or sort the targets by Management Pack.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;infoLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Target Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetColumnHeader =
                    ";Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;targetHeader.Text";

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
            /// Caches the translated resource string for:  ViewAllTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllTargets;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewCommonTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewCommonTargets;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _111TotalTargets24Visible1Selected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_111TotalTargets24Visible1Selected;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;

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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetColumnHeader
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetColumnHeader;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
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
            /// Exposes access to the ViewAllTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllTargets
            {
                get
                {
                    if ((cachedViewAllTargets == null))
                    {
                        cachedViewAllTargets = CoreManager.MomConsole.GetIntlStr(ResourceViewAllTargets);
                    }

                    return cachedViewAllTargets;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewCommonTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewCommonTargets
            {
                get
                {
                    if ((cachedViewCommonTargets == null))
                    {
                        cachedViewCommonTargets = CoreManager.MomConsole.GetIntlStr(ResourceViewCommonTargets);
                    }

                    return cachedViewCommonTargets;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
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
            /// Exposes access to the _111TotalTargets24Visible1Selected translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _111TotalTargets24Visible1Selected
            {
                get
                {
                    if ((cached_111TotalTargets24Visible1Selected == null))
                    {
                        cached_111TotalTargets24Visible1Selected = CoreManager.MomConsole.GetIntlStr(Resource_111TotalTargets24Visible1Selected);
                    }

                    return cached_111TotalTargets24Visible1Selected;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
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
            /// 	[dialac] 7/13/2006 Created
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
            /// Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            {
                get
                {
                    if ((cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                    {
                        cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                    }

                    return cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Target Column Header translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/12/07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetColumnHeader
            {
                get
                {
                    if ((cachedTargetColumnHeader == null))
                    {
                        cachedTargetColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTargetColumnHeader);
                    }
                    return cachedTargetColumnHeader;
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
        /// 	[dialac] 7/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ViewAllTargetsRadioButton
            /// </summary>
            public const string ViewAllTargetsRadioButton = "allTargetsRBtn";

            /// <summary>
            /// Control ID for ViewCommonTargetsRadioButton
            /// </summary>
            public const string ViewCommonTargetsRadioButton = "commonTargetsRBtn";

            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearSearchButton";

            /// <summary>
            /// Control ID for _111TotalTargets24Visible1SelectedStaticControl
            /// </summary>
            public const string _111TotalTargets24Visible1SelectedStaticControl = "selectedItemsLabel";

            /// <summary>
            /// Control ID for LookForTextBox
            /// </summary>
            public const string LookForTextBox = "searchTextBox";

            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";

            /// <summary>
            /// Control ID for ListView0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ListView0 = "typeListView";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            public const string SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = "infoLabel";
        }
        #endregion
    }
}
