// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="KnowledgeProperties.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 13-Sep-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge.Dialogs;
    
    #region Interface Definition - IKnowledgePropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IKnowledgePropertiesControls, for KnowledgeProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 13-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IKnowledgePropertiesControls
    {
        /// <summary>
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditButton
        /// </summary>
        Button EditButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Dependency Monitor properties Knowledge Tab. 
    /// This class manages the advanced functions for the properties dialog 
    /// for a Dependency Monitor.  
    /// </summary>
    /// <history>
    /// 	[ruhim] 13-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class KnowledgeProperties : Dialog, IKnowledgePropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to EditButton of type Button
        /// </summary>
        private Button cachedEditButton;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>Owner of KnowledgeProperties of type App</param>
        /// <param name="title">Dialog title.</param>
        /// <history>
        /// 	[ruhim]  13-Sep-05 Created
        ///     [barryw] 13DEC05 Added title parameter.
        /// </history>
        /// -----------------------------------------------------------------------------
        public KnowledgeProperties(Mom.Test.UI.Core.Console.MomConsoleApp app, string title)
            : 
                base(app, Init(app, title))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);  
        }
        #endregion
        
        #region IKnowledgeProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IKnowledgePropertiesControls Controls
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
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IKnowledgePropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, KnowledgeProperties.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesControls.EditButton
        {
            get
            {
                if ((this.cachedEditButton == null))
                {
                    this.cachedEditButton = new Button(this, KnowledgeProperties.ControlIDs.EditButton);
                }
                return this.cachedEditButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IKnowledgePropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, KnowledgeProperties.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit
        /// </summary>
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.EditButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>)
        /// <param name="title">Dialog title.</param>
        /// <history>
        /// 	[ruhim]  13-Sep-05 Created
        ///     [barryw] 13DEC05 Added title parameter.
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app, string title)
        {
            Common.Utilities.LogMessage("KnowledgeProperties.Init(...)");
            Window tempWindow = app.GetWizardDialog(
                title,
                Timeout);

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit = ";&Edit;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.M" +
                "om.Internal.UI.PageFrameworks.SheetFramework;menuEdit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 13-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 13-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit
            {
                get
                {
                    if ((cachedEdit == null))
                    {
                        cachedEdit = CoreManager.MomConsole.GetIntlStr(ResourceEdit);
                    }
                    return cachedEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 13-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
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
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for EditButton
            /// </summary>
            public const string EditButton = "editKnowledge";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";
        }
        #endregion

        #region Boundaries

        /// <summary>
        /// Field boundary sizes, where the field sizes are the same as the wizard dialogs
        /// the sizes are maintained in the wizard boundaries class.
        /// </summary>
        public class Boundaries
        {
            #region Constants section

            /// <summary>
            /// Minimum length of SomeField
            /// </summary>
            ////Todo: Add real field and get value from KnowledgeWordDialog.Boundaries
            public const int MinLengthSomeField = KnowledgeWordDialog.Boundaries.MinLengthSomeField;

            /// <summary>
            /// Maximum length of name
            /// </summary>
            ////Todo: Add real field and get value from KnowledgeWordDialog.Boundaries
            public const int MaxLengthSomeField = KnowledgeWordDialog.Boundaries.MaxLengthSomeField;

            #endregion
        }
        #endregion
    }
}
