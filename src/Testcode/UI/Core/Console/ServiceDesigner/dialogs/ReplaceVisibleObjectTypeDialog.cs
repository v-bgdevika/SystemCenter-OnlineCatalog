// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ReplaceVisibleObjectTypeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mcorning] 5/9/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[mcorning] 5/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum VisibleObjectsRadioGroup
    {
        /// <summary>
        /// ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOne = 0
        /// </summary>
        ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOne = 0,
        
        /// <summary>
        /// LeaveTheNewObjectTypeNotVisible = 1
        /// </summary>
        LeaveTheNewObjectTypeNotVisible = 1,
    }
    #endregion
    
    #region Interface Definition - IReplaceVisibleObjectTypeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IReplaceVisibleObjectTypeDialogControls, for ReplaceVisibleObjectTypeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mcorning] 5/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IReplaceVisibleObjectTypeDialogControls
    {
        /// <summary>
        /// Read-only property to access ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton
        /// </summary>
        RadioButton ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LeaveTheNewObjectTypeNotVisibleRadioButton
        /// </summary>
        RadioButton LeaveTheNewObjectTypeNotVisibleRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataWarehouseConnectionServerStaticControl
        /// </summary>
        StaticControl DataWarehouseConnectionServerStaticControl
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
        /// Read-only property to access WhatActionDoYouWantToTakeStaticControl
        /// </summary>
        StaticControl WhatActionDoYouWantToTakeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectTypeToBeDisplayedStaticControl
        /// </summary>
        StaticControl ObjectTypeToBeDisplayedStaticControl
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
        /// Read-only property to access WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF
        /// </summary>
        StaticControl WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF
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
    /// 	[mcorning] 5/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ReplaceVisibleObjectTypeDialog : Dialog, IReplaceVisibleObjectTypeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to LeaveTheNewObjectTypeNotVisibleRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedLeaveTheNewObjectTypeNotVisibleRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DataWarehouseConnectionServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDataWarehouseConnectionServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
        /// <summary>
        /// Cache to hold a reference to WhatActionDoYouWantToTakeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWhatActionDoYouWantToTakeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectTypeToBeDisplayedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectTypeToBeDisplayedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF of type StaticControl
        /// </summary>
        private StaticControl cachedWhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ReplaceVisibleObjectTypeDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ReplaceVisibleObjectTypeDialog(MomConsoleApp app) : 
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
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual VisibleObjectsRadioGroup VisibleObjectsRadioGroup
        {
            get
            {
                if ((this.Controls.ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton.ButtonState == ButtonState.Checked))
                {
                    return VisibleObjectsRadioGroup.ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOne;
                }
                
                if ((this.Controls.LeaveTheNewObjectTypeNotVisibleRadioButton.ButtonState == ButtonState.Checked))
                {
                    return VisibleObjectsRadioGroup.LeaveTheNewObjectTypeNotVisible;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == VisibleObjectsRadioGroup.ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOne))
                {
                    this.Controls.ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == VisibleObjectsRadioGroup.LeaveTheNewObjectTypeNotVisible))
                    {
                        this.Controls.LeaveTheNewObjectTypeNotVisibleRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IReplaceVisibleObjectTypeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IReplaceVisibleObjectTypeDialogControls Controls
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
        /// 	[mcorning] 5/9/2006 Created
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
        ///  Exposes access to the ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IReplaceVisibleObjectTypeDialogControls.ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton
        {
            get
            {
                if ((this.cachedReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton == null))
                {
                    this.cachedReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton = new RadioButton(this, ReplaceVisibleObjectTypeDialog.ControlIDs.ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton);
                }
                return this.cachedReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LeaveTheNewObjectTypeNotVisibleRadioButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IReplaceVisibleObjectTypeDialogControls.LeaveTheNewObjectTypeNotVisibleRadioButton
        {
            get
            {
                if ((this.cachedLeaveTheNewObjectTypeNotVisibleRadioButton == null))
                {
                    this.cachedLeaveTheNewObjectTypeNotVisibleRadioButton = new RadioButton(this, ReplaceVisibleObjectTypeDialog.ControlIDs.LeaveTheNewObjectTypeNotVisibleRadioButton);
                }
                return this.cachedLeaveTheNewObjectTypeNotVisibleRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataWarehouseConnectionServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IReplaceVisibleObjectTypeDialogControls.DataWarehouseConnectionServerStaticControl
        {
            get
            {
                if ((this.cachedDataWarehouseConnectionServerStaticControl == null))
                {
                    this.cachedDataWarehouseConnectionServerStaticControl = new StaticControl(this, ReplaceVisibleObjectTypeDialog.ControlIDs.DataWarehouseConnectionServerStaticControl);
                }
                return this.cachedDataWarehouseConnectionServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IReplaceVisibleObjectTypeDialogControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, ReplaceVisibleObjectTypeDialog.ControlIDs.ComboBox0);
                }
                return this.cachedComboBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhatActionDoYouWantToTakeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IReplaceVisibleObjectTypeDialogControls.WhatActionDoYouWantToTakeStaticControl
        {
            get
            {
                if ((this.cachedWhatActionDoYouWantToTakeStaticControl == null))
                {
                    this.cachedWhatActionDoYouWantToTakeStaticControl = new StaticControl(this, ReplaceVisibleObjectTypeDialog.ControlIDs.WhatActionDoYouWantToTakeStaticControl);
                }
                return this.cachedWhatActionDoYouWantToTakeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectTypeToBeDisplayedStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IReplaceVisibleObjectTypeDialogControls.ObjectTypeToBeDisplayedStaticControl
        {
            get
            {
                if ((this.cachedObjectTypeToBeDisplayedStaticControl == null))
                {
                    this.cachedObjectTypeToBeDisplayedStaticControl = new StaticControl(this, ReplaceVisibleObjectTypeDialog.ControlIDs.ObjectTypeToBeDisplayedStaticControl);
                }
                return this.cachedObjectTypeToBeDisplayedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IReplaceVisibleObjectTypeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ReplaceVisibleObjectTypeDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IReplaceVisibleObjectTypeDialogControls.WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF
        {
            get
            {
                if ((this.cachedWhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF == null))
                {
                    this.cachedWhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF = new StaticControl(this, ReplaceVisibleObjectTypeDialog.ControlIDs.WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF);
                }
                return this.cachedWhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Window tempWindow = Utility.GetDialogOrWindow(app, Strings.DialogTitle, 1000, false, true);
            return tempWindow;

        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for Replace Visible Object Type
            /// </summary>
            public const string ResourceDialogTitle = ";Replace Visible Object Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ReplaceDisplayedNavPaneItemsForm;$this.Text";
            
            /// <summary>
            /// Resource string for Replace the selected visible Object Type button with the new one:
            /// </summary>
            public const string ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOne = "Replace the selected visible Object Type button with the new one:";
            
            /// <summary>
            /// Resource string for Leave the new object type not visible.
            /// </summary>
            public const string LeaveTheNewObjectTypeNotVisible = "Leave the new object type not visible.";
            
            /// <summary>
            /// Resource string for Data Warehouse Connection Server
            /// </summary>
            public const string DataWarehouseConnectionServer = "Data Warehouse Connection Server";
            
            /// <summary>
            /// Resource string for What action do you want to take?
            /// </summary>
            public const string WhatActionDoYouWantToTake = "What action do you want to take?";
            
            /// <summary>
            /// Resource string for Object type to be displayed:
            /// </summary>
            public const string ObjectTypeToBeDisplayed = "Object type to be displayed:";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            public const string OK = "OK";
            
            /// <summary>
            /// Resource string for While making a new object type button visible, the allowed limit was reached. Resolve the conflict by choosing one of the following options.
            /// </summary>
            public const string WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF = "While making a new object type button visible, the allowed limit was reached. Res" +
                "olve the conflict by choosing one of the following options.";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 7/6/2006 Created
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
        /// 	[mcorning] 5/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton
            /// </summary>
            public const string ReplaceTheSelectedVisibleObjectTypeButtonWithTheNewOneRadioButton = "radioButtonReplace";
            
            /// <summary>
            /// Control ID for LeaveTheNewObjectTypeNotVisibleRadioButton
            /// </summary>
            public const string LeaveTheNewObjectTypeNotVisibleRadioButton = "radioButtonDoNothing";
            
            /// <summary>
            /// Control ID for DataWarehouseConnectionServerStaticControl
            /// </summary>
            public const string DataWarehouseConnectionServerStaticControl = "labelNewItem";
            
            /// <summary>
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "comboBox";
            
            /// <summary>
            /// Control ID for WhatActionDoYouWantToTakeStaticControl
            /// </summary>
            public const string WhatActionDoYouWantToTakeStaticControl = "labelAction";
            
            /// <summary>
            /// Control ID for ObjectTypeToBeDisplayedStaticControl
            /// </summary>
            public const string ObjectTypeToBeDisplayedStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF
            /// </summary>
            public const string WhileMakingANewObjectTypeButtonVisibleTheAllowedLimitWasReachedResolveTheConflictByChoosingOneOfTheF = "labelWarning";
        }
        #endregion
    }
}
