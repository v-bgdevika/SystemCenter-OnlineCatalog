// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupandObjectFilterControl.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-lileo] 12/14/2010 Created
// </history>
// ------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using System.Collections.Generic;

    #region Interface Definition - IWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGroupandObjectFilterControl, for Window.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 12/14/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupandObjectFilterControl
    {
        /// <summary>
        /// Gets read-only property to access Groups button
        /// </summary>
        Button GroupsRadioButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access GroupsAndObject button
        /// </summary>
        Button GroupsAndObjectsRadioButton
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    ///   [v-lileo] 12/14/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GroupandObjectFilterControl : IGroupandObjectFilterControl
    {
        #region Private Member Variables

        private Window Content = null;

        /// <summary>
        /// Cache to hold a reference to Groups of type button
        /// </summary>
        private Button cachedGroupsRadioButton;

        /// <summary>
        /// Cache to hold a reference to GroupsAndObjects of type button
        /// </summary>
        private Button cachedGroupsAndObjectsRadioButton;
        #endregion
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Window class.
        /// </summary>
        /// <param name='app'></param>
        /// <param name='timeOut'></param>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupandObjectFilterControl(Window KnownWindow)
        {
            this.Content = KnownWindow;
        }
        #endregion
        #region IGroupandObjectFilterControl Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the GroupandObjectFilterControl's control properties together</value>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGroupandObjectFilterControl Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region public Control Properties

        /// <summary>
        /// Filter Control
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DashboardControls.FilterControl Filter
        {
            get
            {
                return new DashboardControls.FilterControl(this.Content);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupsRadioButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupandObjectFilterControl.GroupsRadioButton
        {
            get
            {
                if (this.cachedGroupsRadioButton == null)
                {
                    this.cachedGroupsRadioButton = new Button(this.Content, GroupandObjectFilterControl.QueryIds.GroupsRadioButton);
                }
                return this.cachedGroupsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupsAndObjectsRadioButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupandObjectFilterControl.GroupsAndObjectsRadioButton
        {
            get
            {
                if (this.cachedGroupsAndObjectsRadioButton == null)
                {
                    this.cachedGroupsAndObjectsRadioButton = new Button(this.Content, GroupandObjectFilterControl.QueryIds.GroupsAndObjectsRadioButton);
                }
                return this.cachedGroupsAndObjectsRadioButton;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupsRadioButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupsRadioButton()
        {
            this.Controls.GroupsRadioButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupsAndObjectsRadioButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupsAndObjectsRadioButton()
        {
            this.Controls.GroupsAndObjectsRadioButton.Click();
        }

        #endregion

        public void SelectGroupsOrObjectAndGroups(bool option, string FilterText)
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    if (option == true)
                    {
                        Utilities.LogMessage("SelectGroupsOrObjectAndGroups:: Select Groups option");
                        this.ClickGroupsRadioButton();
                        if (FilterText != null)
                        {
                            this.Filter.SetFilterTextBoxText(FilterText);
                        }
                    }
                    else
                    {
                        Utilities.LogMessage("SelectGroupsOrObjectAndGroups:: Select Groups and Object option");
                        this.ClickGroupsAndObjectsRadioButton();
                        if (FilterText != null)
                        {
                            this.Filter.SetFilterTextBoxText(FilterText);
                        }
                        this.Filter.FilterSearchButton.Click();
                    }
                    break;
                case ProductSkuLevel.Web:
                    //In the webconsole, filter is obscured by other UI element, so use sendkey to oprate them
                    if (option == true)
                    {
                        Utilities.LogMessage("SelectGroupsOrObjectAndGroups:: Select Groups option");
                        this.ClickGroupsRadioButton();
                        if (FilterText != null)
                        {
                            this.Content.SendKeys(KeyboardCodes.Tab);
                            this.Content.SendKeys(KeyboardCodes.Tab);
                            this.Content.SendKeys(FilterText);
                        }
                    }
                    else
                    {
                        Utilities.LogMessage("SelectGroupsOrObjectAndGroups:: Select Groups and Object option");
                        this.ClickGroupsAndObjectsRadioButton();
                        if (FilterText != null)
                        {
                            this.Content.SendKeys(KeyboardCodes.Tab);
                            this.Content.SendKeys(FilterText);
                        }
                        this.Content.SendKeys(KeyboardCodes.Enter);
                    }
                    
                    break;
            }
            
        }

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/14/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for GroupsRadioButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupsRadioButton = ";[UIA]AutomationId=\'groupsRadioButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for GroupsAndObjectsRadioButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupsAndObjectsRadioButton = ";[UIA]AutomationId=\'groupsAndObjectsRadioButton\'";

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupsRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupsRadioButton
            {
                get
                {
                    return new QID(ResourceGroupsRadioButton);
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupsAndObjectsRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupsAndObjectsRadioButton
            {
                get
                {
                    return new QID(ResourceGroupsAndObjectsRadioButton);
                }
            }

            #endregion
        }
        #endregion
    }
}
