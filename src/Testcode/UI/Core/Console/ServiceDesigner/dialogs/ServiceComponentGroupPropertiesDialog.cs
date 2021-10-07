// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ComponentGroupPropertiesDialog.cs">
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
    
    #region Interface Definition - IComponentGroupPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IComponentGroupPropertiesDialogControls, for ComponentGroupPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mcorning] 03-Apr-06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IComponentGroupPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access ObjectsThatCanBeAddedToThisComponentGroupTreeView
        /// </summary>
        TreeView ObjectsThatCanBeAddedToThisComponentGroupTreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsThatCanBeAddedToThisComponentGroupStaticControl
        /// </summary>
        StaticControl ObjectsThatCanBeAddedToThisComponentGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComponentGroupNameTextBox
        /// </summary>
        TextBox ComponentGroupNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComponentGroupNameStaticControl
        /// </summary>
        StaticControl ComponentGroupNameStaticControl
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
    public class ComponentGroupPropertiesDialog : Dialog, IComponentGroupPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ObjectsThatCanBeAddedToThisComponentGroupTreeView of type TreeView
        /// </summary>
        private TreeView cachedObjectsThatCanBeAddedToThisComponentGroupTreeView;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsThatCanBeAddedToThisComponentGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsThatCanBeAddedToThisComponentGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComponentGroupNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedComponentGroupNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ComponentGroupNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComponentGroupNameStaticControl;
        
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
        /// Owner of ComponentGroupPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ComponentGroupPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IComponentGroupPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IComponentGroupPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control ComponentGroupName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComponentGroupNameText
        {
            get
            {
                return this.Controls.ComponentGroupNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ComponentGroupNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsThatCanBeAddedToThisComponentGroupTreeView control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IComponentGroupPropertiesDialogControls.ObjectsThatCanBeAddedToThisComponentGroupTreeView
        {
            get
            {
                if ((this.cachedObjectsThatCanBeAddedToThisComponentGroupTreeView == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedObjectsThatCanBeAddedToThisComponentGroupTreeView = new TreeView(wndTemp);
                }
                return this.cachedObjectsThatCanBeAddedToThisComponentGroupTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsThatCanBeAddedToThisComponentGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComponentGroupPropertiesDialogControls.ObjectsThatCanBeAddedToThisComponentGroupStaticControl
        {
            get
            {
                if ((this.cachedObjectsThatCanBeAddedToThisComponentGroupStaticControl == null))
                {
                    this.cachedObjectsThatCanBeAddedToThisComponentGroupStaticControl = new StaticControl(this, ComponentGroupPropertiesDialog.ControlIDs.ObjectsThatCanBeAddedToThisComponentGroupStaticControl);
                }
                return this.cachedObjectsThatCanBeAddedToThisComponentGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComponentGroupNameTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IComponentGroupPropertiesDialogControls.ComponentGroupNameTextBox
        {
            get
            {
                if ((this.cachedComponentGroupNameTextBox == null))
                {
                    this.cachedComponentGroupNameTextBox = new TextBox(this, ComponentGroupPropertiesDialog.ControlIDs.ComponentGroupNameTextBox);
                }
                return this.cachedComponentGroupNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComponentGroupNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 03-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComponentGroupPropertiesDialogControls.ComponentGroupNameStaticControl
        {
            get
            {
                if ((this.cachedComponentGroupNameStaticControl == null))
                {
                    this.cachedComponentGroupNameStaticControl = new StaticControl(this, ComponentGroupPropertiesDialog.ControlIDs.ComponentGroupNameStaticControl);
                }
                return this.cachedComponentGroupNameStaticControl;
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
        Button IComponentGroupPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ComponentGroupPropertiesDialog.ControlIDs.CancelButton);
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
        Button IComponentGroupPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ComponentGroupPropertiesDialog.ControlIDs.OKButton);
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
            return (Window)Utility.GetDialogOrWindow(app, Strings.DialogTitle, 1000, false, true);
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
            private const string ResourceDialogTitle = "Component Group Properties";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectsThatCanBeAddedToThisComponentGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectsThatCanBeAddedToThisComponentGroup = ";&Objects that can be added to this service component group:;ManagedString;Micros" +
                "oft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring" +
                ".ServiceDesignerEditor.ComponentPropertiesForm;labelObject.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComponentGroupName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComponentGroupName = ";Service component group &name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEd" +
                "itor.ComponentPropertiesForm;labelName.Text";
            
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
            /// Caches the translated resource string for:  ObjectsThatCanBeAddedToThisComponentGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectsThatCanBeAddedToThisComponentGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComponentGroupName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComponentGroupName;
            
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
            /// Exposes access to the ObjectsThatCanBeAddedToThisComponentGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectsThatCanBeAddedToThisComponentGroup
            {
                get
                {
                    if ((cachedObjectsThatCanBeAddedToThisComponentGroup == null))
                    {
                        cachedObjectsThatCanBeAddedToThisComponentGroup = CoreManager.MomConsole.GetIntlStr(ResourceObjectsThatCanBeAddedToThisComponentGroup);
                    }
                    return cachedObjectsThatCanBeAddedToThisComponentGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComponentGroupName translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 03-Apr-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComponentGroupName
            {
                get
                {
                    if ((cachedComponentGroupName == null))
                    {
                        cachedComponentGroupName = CoreManager.MomConsole.GetIntlStr(ResourceComponentGroupName);
                    }
                    return cachedComponentGroupName;
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
            /// Control ID for ObjectsThatCanBeAddedToThisComponentGroupStaticControl
            /// </summary>
            public const string ObjectsThatCanBeAddedToThisComponentGroupStaticControl = "labelObject";
            
            /// <summary>
            /// Control ID for ComponentGroupNameTextBox
            /// </summary>
            public const string ComponentGroupNameTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for ComponentGroupNameStaticControl
            /// </summary>
            public const string ComponentGroupNameStaticControl = "labelName";
            
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
