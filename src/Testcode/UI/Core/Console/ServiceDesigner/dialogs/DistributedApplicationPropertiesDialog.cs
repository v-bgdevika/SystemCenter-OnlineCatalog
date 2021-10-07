// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DistributedApplicationPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mcorning] 5/11/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IDistributedApplicationPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDistributedApplicationPropertiesDialogControls, for DistributedApplicationPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mcorning] 5/11/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDistributedApplicationPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access BasedOnDistributedApplicationTemplateTextBox
        /// </summary>
        TextBox BasedOnDistributedApplicationTemplateTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BasedOnDistributedApplicationTemplateStaticControl
        /// </summary>
        StaticControl BasedOnDistributedApplicationTemplateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributedApplicationNameTextBox
        /// </summary>
        TextBox DistributedApplicationNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributedApplicationNameStaticControl
        /// </summary>
        StaticControl DistributedApplicationNameStaticControl
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
    /// 	[mcorning] 5/11/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DistributedApplicationPropertiesDialog : Dialog, IDistributedApplicationPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to BasedOnDistributedApplicationTemplateTextBox of type TextBox
        /// </summary>
        private TextBox cachedBasedOnDistributedApplicationTemplateTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BasedOnDistributedApplicationTemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBasedOnDistributedApplicationTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DistributedApplicationNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedDistributedApplicationNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DistributedApplicationNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributedApplicationNameStaticControl;
        
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
        /// Owner of DistributedApplicationPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DistributedApplicationPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDistributedApplicationPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDistributedApplicationPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control BasedOnDistributedApplicationTemplate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BasedOnDistributedApplicationTemplateText
        {
            get
            {
                return this.Controls.BasedOnDistributedApplicationTemplateTextBox.Text;
            }
            
            set
            {
                this.Controls.BasedOnDistributedApplicationTemplateTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DistributedApplicationName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DistributedApplicationNameText
        {
            get
            {
                return this.Controls.DistributedApplicationNameTextBox.Text;
            }
            
            set
            {
                this.Controls.DistributedApplicationNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasedOnDistributedApplicationTemplateTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDistributedApplicationPropertiesDialogControls.BasedOnDistributedApplicationTemplateTextBox
        {
            get
            {
                if ((this.cachedBasedOnDistributedApplicationTemplateTextBox == null))
                {
                    this.cachedBasedOnDistributedApplicationTemplateTextBox = new TextBox(this, DistributedApplicationPropertiesDialog.ControlIDs.BasedOnDistributedApplicationTemplateTextBox);
                }
                return this.cachedBasedOnDistributedApplicationTemplateTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasedOnDistributedApplicationTemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDistributedApplicationPropertiesDialogControls.BasedOnDistributedApplicationTemplateStaticControl
        {
            get
            {
                if ((this.cachedBasedOnDistributedApplicationTemplateStaticControl == null))
                {
                    this.cachedBasedOnDistributedApplicationTemplateStaticControl = new StaticControl(this, DistributedApplicationPropertiesDialog.ControlIDs.BasedOnDistributedApplicationTemplateStaticControl);
                }
                return this.cachedBasedOnDistributedApplicationTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDistributedApplicationPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, DistributedApplicationPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDistributedApplicationPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, DistributedApplicationPropertiesDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributedApplicationNameTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDistributedApplicationPropertiesDialogControls.DistributedApplicationNameTextBox
        {
            get
            {
                if ((this.cachedDistributedApplicationNameTextBox == null))
                {
                    this.cachedDistributedApplicationNameTextBox = new TextBox(this, DistributedApplicationPropertiesDialog.ControlIDs.DistributedApplicationNameTextBox);
                }
                return this.cachedDistributedApplicationNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributedApplicationNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDistributedApplicationPropertiesDialogControls.DistributedApplicationNameStaticControl
        {
            get
            {
                if ((this.cachedDistributedApplicationNameStaticControl == null))
                {
                    this.cachedDistributedApplicationNameStaticControl = new StaticControl(this, DistributedApplicationPropertiesDialog.ControlIDs.DistributedApplicationNameStaticControl);
                }
                return this.cachedDistributedApplicationNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDistributedApplicationPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DistributedApplicationPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDistributedApplicationPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, DistributedApplicationPropertiesDialog.ControlIDs.OKButton);
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
        /// 	[mcorning] 5/11/2006 Created
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
        /// 	[mcorning] 5/11/2006 Created
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
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            return (Window)Utility.GetDialogOrWindow(app, Strings.DialogTitle, Constants.OneMinute, false, true);

        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
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
                ";Distributed Application Properties;ManagedString;Microsoft.enterprisemanagement.ui.authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServicePropertiesForm;$this.Text";
                //";Distributed Application Properties;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServicePropertiesForm.en;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BasedOnDistributedApplicationTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBasedOnDistributedApplicationTemplate = ";Based on Distributed Application &Template:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Serv" +
                "iceDesignerEditor.ServicePropertiesForm;labelTemplate.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.Pages.NameAndDescriptionPage;descLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DistributedApplicationName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDistributedApplicationName = ";Distributed Application &name:;ManagedString;Microsoft.MOM.UI.Components.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEd" +
                "itor.ServicePropertiesForm;labelServiceName.Text";
            
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
            /// Caches the translated resource string for:  BasedOnDistributedApplicationTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasedOnDistributedApplicationTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DistributedApplicationName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDistributedApplicationName;
            
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
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the BasedOnDistributedApplicationTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasedOnDistributedApplicationTemplate
            {
                get
                {
                    if ((cachedBasedOnDistributedApplicationTemplate == null))
                    {
                        cachedBasedOnDistributedApplicationTemplate = CoreManager.MomConsole.GetIntlStr(ResourceBasedOnDistributedApplicationTemplate);
                    }
                    return cachedBasedOnDistributedApplicationTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    return cachedDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DistributedApplicationName translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DistributedApplicationName
            {
                get
                {
                    if ((cachedDistributedApplicationName == null))
                    {
                        cachedDistributedApplicationName = CoreManager.MomConsole.GetIntlStr(ResourceDistributedApplicationName);
                    }
                    return cachedDistributedApplicationName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// 	[mcorning] 5/11/2006 Created
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
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for BasedOnDistributedApplicationTemplateTextBox
            /// </summary>
            public const string BasedOnDistributedApplicationTemplateTextBox = "textBoxTemplate";
            
            /// <summary>
            /// Control ID for BasedOnDistributedApplicationTemplateStaticControl
            /// </summary>
            public const string BasedOnDistributedApplicationTemplateStaticControl = "labelTemplate";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "textBoxDescription";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for DistributedApplicationNameTextBox
            /// </summary>
            public const string DistributedApplicationNameTextBox = "textBoxServiceName";
            
            /// <summary>
            /// Control ID for DistributedApplicationNameStaticControl
            /// </summary>
            public const string DistributedApplicationNameStaticControl = "labelServiceName";
            
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
