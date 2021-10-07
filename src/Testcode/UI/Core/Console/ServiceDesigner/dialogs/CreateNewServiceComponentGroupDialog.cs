// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNewComponentGroupDialog2.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mcorning] 03-Apr-06 Created
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
    /// 	[mcorning] 03-Apr-06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum NewObjectsRadioGroup
    {
        /// <summary>
        /// ObjectsOfTheFollowingClasses = 0
        /// </summary>
        ObjectsOfTheFollowingClasses = 0,
        
        /// <summary>
        /// AllObjects = 1
        /// </summary>
        AllObjects = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateNewComponentGroupDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNewComponentGroupDialogControls, for CreateNewComponentGroupDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mcorning] 03-Apr-06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNewComponentGroupDialogControls
    {
        /// <summary>
        /// Read-only property to access TreeView0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TreeView TreeView0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsOfTheFollowingClassesRadioButton
        /// </summary>
        RadioButton ObjectsOfTheFollowingClassesRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllObjectsRadioButton
        /// </summary>
        RadioButton AllObjectsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl
        /// </summary>
        StaticControl WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameYourComponentGroupTextBox
        /// </summary>
        TextBox NameYourComponentGroupTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameYourComponentGroupStaticControl
        /// </summary>
        StaticControl NameYourComponentGroupStaticControl
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
    /// 	[mcorning] 03-Apr-06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateNewComponentGroupDialog : Dialog, ICreateNewComponentGroupDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TreeView0 of type TreeView
        /// </summary>
        private TreeView cachedTreeView0;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsOfTheFollowingClassesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedObjectsOfTheFollowingClassesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AllObjectsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllObjectsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWhatObjectsDoYouWantToAddToThisComponentGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameYourComponentGroupTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameYourComponentGroupTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameYourComponentGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameYourComponentGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateNewComponentGroupDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNewComponentGroupDialog(MomConsoleApp app) : 
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
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual NewObjectsRadioGroup NewObjectsRadioGroup
        {
            get
            {
                if ((this.Controls.ObjectsOfTheFollowingClassesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return NewObjectsRadioGroup.ObjectsOfTheFollowingClasses;
                }
                
                if ((this.Controls.AllObjectsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return NewObjectsRadioGroup.AllObjects;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == NewObjectsRadioGroup.ObjectsOfTheFollowingClasses))
                {
                    this.Controls.ObjectsOfTheFollowingClassesRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == NewObjectsRadioGroup.AllObjects))
                    {
                        this.Controls.AllObjectsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateNewComponentGroupDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNewComponentGroupDialogControls Controls
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
        ///  Routine to set/get the text in control NameYourComponentGroup
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameYourComponentGroupText
        {
            get
            {
                return this.Controls.NameYourComponentGroupTextBox.Text;
            }
            
            set
            {
                this.Controls.NameYourComponentGroupTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TreeView0 control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView ICreateNewComponentGroupDialogControls.TreeView0
        {
            get
            {
                if ((this.cachedTreeView0 == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTreeView0 = new TreeView(wndTemp);
                }
                return this.cachedTreeView0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsOfTheFollowingClassesRadioButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNewComponentGroupDialogControls.ObjectsOfTheFollowingClassesRadioButton
        {
            get
            {
                if ((this.cachedObjectsOfTheFollowingClassesRadioButton == null))
                {
                    this.cachedObjectsOfTheFollowingClassesRadioButton = new RadioButton(this, CreateNewComponentGroupDialog.ControlIDs.ObjectsOfTheFollowingClassesRadioButton);
                }
                return this.cachedObjectsOfTheFollowingClassesRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllObjectsRadioButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNewComponentGroupDialogControls.AllObjectsRadioButton
        {
            get
            {
                if ((this.cachedAllObjectsRadioButton == null))
                {
                    this.cachedAllObjectsRadioButton = new RadioButton(this, CreateNewComponentGroupDialog.ControlIDs.AllObjectsRadioButton);
                }
                return this.cachedAllObjectsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNewComponentGroupDialogControls.WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl
        {
            get
            {
                if ((this.cachedWhatObjectsDoYouWantToAddToThisComponentGroupStaticControl == null))
                {
                    this.cachedWhatObjectsDoYouWantToAddToThisComponentGroupStaticControl = new StaticControl(this, CreateNewComponentGroupDialog.ControlIDs.WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl);
                }
                return this.cachedWhatObjectsDoYouWantToAddToThisComponentGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameYourComponentGroupTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNewComponentGroupDialogControls.NameYourComponentGroupTextBox
        {
            get
            {
                if ((this.cachedNameYourComponentGroupTextBox == null))
                {
                    this.cachedNameYourComponentGroupTextBox = new TextBox(this, CreateNewComponentGroupDialog.ControlIDs.NameYourComponentGroupTextBox);
                }
                return this.cachedNameYourComponentGroupTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameYourComponentGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNewComponentGroupDialogControls.NameYourComponentGroupStaticControl
        {
            get
            {
                if ((this.cachedNameYourComponentGroupStaticControl == null))
                {
                    this.cachedNameYourComponentGroupStaticControl = new StaticControl(this, CreateNewComponentGroupDialog.ControlIDs.NameYourComponentGroupStaticControl);
                }
                return this.cachedNameYourComponentGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNewComponentGroupDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNewComponentGroupDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNewComponentGroupDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, CreateNewComponentGroupDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
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
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Window tempWindow = Utility.GetDialogOrWindow(app, Strings.DialogTitle, 3000, false, true);
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
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
            private const string ResourceDialogTitle = 
                ";Create New Component Group;ManagedString;microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceComponentForm;$this.Text";
                //";Create New Component Group;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceComponentForm.en;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectsOfTheFollowingClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectsOfTheFollowingClasses = ";Objects of the following class(es):;ManagedString;Microsoft.MOM.UI.Components.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesig" +
                "nerEditor.CreateComponentForm;radioButtonTypes.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllObjects = ";All Objects;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceC" +
                "omponentForm;radioButtonAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WhatObjectsDoYouWantToAddToThisComponentGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWhatObjectsDoYouWantToAddToThisComponentGroup = ";What objects do you want to add to this service component group?;ManagedString;M" +
                "icrosoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor" +
                "CreateComponentForm;labelObject.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NameYourComponentGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNameYourComponentGroup = ";&Name your service component group:;ManagedString;Microsoft.MOM.UI.Components.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesig" +
                "nerEditor.CreateComponentForm;labelName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
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
            /// Caches the translated resource string for:  ObjectsOfTheFollowingClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectsOfTheFollowingClasses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WhatObjectsDoYouWantToAddToThisComponentGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWhatObjectsDoYouWantToAddToThisComponentGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NameYourComponentGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNameYourComponentGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
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
            /// Exposes access to the ObjectsOfTheFollowingClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectsOfTheFollowingClasses
            {
                get
                {
                    if ((cachedObjectsOfTheFollowingClasses == null))
                    {
                        cachedObjectsOfTheFollowingClasses = CoreManager.MomConsole.GetIntlStr(ResourceObjectsOfTheFollowingClasses);
                    }
                    return cachedObjectsOfTheFollowingClasses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllObjects
            {
                get
                {
                    if ((cachedAllObjects == null))
                    {
                        cachedAllObjects = CoreManager.MomConsole.GetIntlStr(ResourceAllObjects);
                    }
                    return cachedAllObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WhatObjectsDoYouWantToAddToThisComponentGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WhatObjectsDoYouWantToAddToThisComponentGroup
            {
                get
                {
                    if ((cachedWhatObjectsDoYouWantToAddToThisComponentGroup == null))
                    {
                        cachedWhatObjectsDoYouWantToAddToThisComponentGroup = CoreManager.MomConsole.GetIntlStr(ResourceWhatObjectsDoYouWantToAddToThisComponentGroup);
                    }
                    return cachedWhatObjectsDoYouWantToAddToThisComponentGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NameYourComponentGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NameYourComponentGroup
            {
                get
                {
                    if ((cachedNameYourComponentGroup == null))
                    {
                        cachedNameYourComponentGroup = CoreManager.MomConsole.GetIntlStr(ResourceNameYourComponentGroup);
                    }
                    return cachedNameYourComponentGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ObjectsOfTheFollowingClassesRadioButton
            /// </summary>
            public const string ObjectsOfTheFollowingClassesRadioButton = "radioButtonTypes";
            
            /// <summary>
            /// Control ID for AllObjectsRadioButton
            /// </summary>
            public const string AllObjectsRadioButton = "radioButtonAll";
            
            /// <summary>
            /// Control ID for WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl
            /// </summary>
            public const string WhatObjectsDoYouWantToAddToThisComponentGroupStaticControl = "labelObject";
            
            /// <summary>
            /// Control ID for NameYourComponentGroupTextBox
            /// </summary>
            public const string NameYourComponentGroupTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for NameYourComponentGroupStaticControl
            /// </summary>
            public const string NameYourComponentGroupStaticControl = "labelName";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
        }
        #endregion
    }
}
