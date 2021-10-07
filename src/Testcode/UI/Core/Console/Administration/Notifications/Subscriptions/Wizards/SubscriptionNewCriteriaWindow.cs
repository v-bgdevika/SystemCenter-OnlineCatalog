using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maui.Core.WinControls;

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    /// <summary>
    /// Interface definition, ISubscriptionNewCriteriaWindow, for SubscriptionNewCriteriaWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    internal interface ISubscriptionNewCriteriaWindow
    {
        /// <summary>
        ///  Exposes access to the FormulaGridToolbar control
        /// </summary>
        Toolbar FormulaGridToolbar { get; }

        /// <summary>
        ///  Exposes access to the InsertMenu control
        /// </summary>
        Menu InsertMenu { get; }

        /// <summary>
        ///  Exposes access to the FormulaGrid control
        /// </summary>
        PropertyGridView FormulaGrid { get; }
    }

    /// <summary>
    /// Class to encapsulate the Subscription Criteria step functionality for  
    /// the Notification Subscription Wizard.
    /// </summary>
    class SubscriptionNewCriteriaWindow : ConsoleWizardBase, ISubscriptionNewCriteriaWindow
    {
        private PropertyGridView cachedFormulaGrid;

        private Toolbar cachedFormulaGridToolbar;
        private Menu cachedInsertMenu;


        public SubscriptionNewCriteriaWindow(MomConsoleApp app, bool editExisting) 
            : base(app, (editExisting? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
        }

        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        public new ISubscriptionNewCriteriaWindow Controls
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        ///  Exposes access to the FormulaGridToolbar control
        /// </summary>
        Toolbar ISubscriptionNewCriteriaWindow.FormulaGridToolbar
        {
            get
            {
                if ((this.cachedFormulaGridToolbar == null))
                {
                    this.cachedFormulaGridToolbar = new Toolbar(this.AccessibleObject.Window);
                }
                return this.cachedFormulaGridToolbar;
            }
        }

        /// <summary>
        ///  Exposes access to the InsertMenu control
        /// </summary>
        Menu ISubscriptionNewCriteriaWindow.InsertMenu

        {
            get
            {
                if ((this.cachedInsertMenu == null))
                {
                    this.cachedInsertMenu = new Menu(this.AccessibleObject.Window);
                }
                return this.cachedInsertMenu;
            }
        }

        /// <summary>
        ///  Exposes access to the FormulaGrid control
        /// </summary>
        PropertyGridView ISubscriptionNewCriteriaWindow.FormulaGrid
        {
            get
            {
                if ((this.cachedFormulaGrid == null))
                {
                    this.cachedFormulaGrid = new PropertyGridView(this, ControlIDs.FormulaGrid);
                }
                return this.cachedFormulaGrid;
            }
        }

        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        public static class ControlIDs
        {
            /// <summary>
            /// Control ID for FormulaGrid
            /// </summary>
            public const string FormulaGrid = "formulaGrid";
        }

        public static class Strings
        {
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWindowTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedModifyWindowTitle;

            private static string cachedFormulaToolbar;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWindowTitle =
                ";Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceModifyWindowTitle =
                ";Modify Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitleEdit";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the formula menu toolbar.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceFormulaToolbar =
                ";formulaMenu" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl" +
                ";formulaMenu.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }

                    return cachedWindowTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ModifyWindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ModifyWindowTitle
            {
                get
                {
                    if ((cachedModifyWindowTitle == null))
                    {
                        cachedModifyWindowTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceModifyWindowTitle);
                    }

                    return cachedModifyWindowTitle;
                }
            }

            /// <summary>
            /// Exposes access to the FormulaToolBar translated resource string
            /// </summary>
            public static string FormulaToolbar
            {
                get
                {
                    if ((cachedFormulaToolbar == null))
                    {
                        cachedFormulaToolbar = CoreManager.MomConsole.GetIntlStr(ResourceFormulaToolbar);
                    }

                    return cachedFormulaToolbar;
                }
            }
        }

    }

    
}
