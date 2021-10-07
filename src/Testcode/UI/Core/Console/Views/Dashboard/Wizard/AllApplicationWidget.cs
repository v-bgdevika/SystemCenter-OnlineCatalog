// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AllApplicationWidget.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-tfeng] 11/9/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console.MomControls.Dashboards;
    
    #region Interface Definition - IAllApplicationWidgetControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAllApplicationWidgetControls, for AllApplicationWidget.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 11/9/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAllApplicationWidgetControls
    {
        /// <summary>
        /// Gets read-only property to access ProgressBar4
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ProgressBar ProgressBar4
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AllApplicationsTextBox
        /// </summary>
        TextBox AllApplicationsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SCOMFilterControlSearchButtonButton
        /// </summary>
        Button SCOMFilterControlSearchButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SCOMFilterControlCloseButtonButton
        /// </summary>
        Button SCOMFilterControlCloseButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DataGrid5
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        DataGrid DataGrid5
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Button1Button
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1Button
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ProgressBar6
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ProgressBar ProgressBar6
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ServiceLevelAgreementsTextBox
        /// </summary>
        TextBox ServiceLevelAgreementsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SCOMFilterControlSearchButtonButton2
        /// </summary>
        Button SCOMFilterControlSearchButtonButton2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SCOMFilterControlCloseButtonButton2
        /// </summary>
        Button SCOMFilterControlCloseButtonButton2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DataGrid7
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        DataGrid DataGrid7
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Button3Button
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button3Button
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access LineUpButton
        /// </summary>
        Button LineUpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PageUpButton
        /// </summary>
        Button PageUpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PageDownButton
        /// </summary>
        Button PageDownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access LineDownButton
        /// </summary>
        Button LineDownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access LineLeftButton
        /// </summary>
        Button LineLeftButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PageLeftButton
        /// </summary>
        Button PageLeftButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PageRightButton
        /// </summary>
        Button PageRightButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access LineRightButton
        /// </summary>
        Button LineRightButton
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
    ///   [asttest] 11/9/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AllApplicationWidget : IAllApplicationWidgetControls
    {
        #region Private Static Members

        private GridLayoutDashboard dashboard;

        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ProgressBar4 of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar4;
        
        /// <summary>
        /// Cache to hold a reference to AllApplicationsTextBox of type TextBox
        /// </summary>
        private TextBox cachedAllApplicationsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlSearchButtonButton of type Button
        /// </summary>
        private Button cachedSCOMFilterControlSearchButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlCloseButtonButton of type Button
        /// </summary>
        private Button cachedSCOMFilterControlCloseButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to DataGrid5 of type DataGrid
        /// </summary>
        private DataGrid cachedDataGrid5;
        
        /// <summary>
        /// Cache to hold a reference to Button1Button of type Button
        /// </summary>
        private Button cachedButton1Button;
        
        /// <summary>
        /// Cache to hold a reference to ProgressBar6 of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar6;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelAgreementsTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceLevelAgreementsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlSearchButtonButton2 of type Button
        /// </summary>
        private Button cachedSCOMFilterControlSearchButtonButton2;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlCloseButtonButton2 of type Button
        /// </summary>
        private Button cachedSCOMFilterControlCloseButtonButton2;
        
        /// <summary>
        /// Cache to hold a reference to DataGrid7 of type DataGrid
        /// </summary>
        private DataGrid cachedDataGrid7;
        
        /// <summary>
        /// Cache to hold a reference to Button3Button of type Button
        /// </summary>
        private Button cachedButton3Button;
        
        /// <summary>
        /// Cache to hold a reference to LineUpButton of type Button
        /// </summary>
        private Button cachedLineUpButton;
        
        /// <summary>
        /// Cache to hold a reference to PageUpButton of type Button
        /// </summary>
        private Button cachedPageUpButton;
        
        /// <summary>
        /// Cache to hold a reference to PageDownButton of type Button
        /// </summary>
        private Button cachedPageDownButton;
        
        /// <summary>
        /// Cache to hold a reference to LineDownButton of type Button
        /// </summary>
        private Button cachedLineDownButton;
        
        /// <summary>
        /// Cache to hold a reference to LineLeftButton of type Button
        /// </summary>
        private Button cachedLineLeftButton;
        
        /// <summary>
        /// Cache to hold a reference to PageLeftButton of type Button
        /// </summary>
        private Button cachedPageLeftButton;
        
        /// <summary>
        /// Cache to hold a reference to PageRightButton of type Button
        /// </summary>
        private Button cachedPageRightButton;
        
        /// <summary>
        /// Cache to hold a reference to LineRightButton of type Button
        /// </summary>
        private Button cachedLineRightButton;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the AllApplicationWidget class.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of AllApplicationWidget of type App
        /// </param>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AllApplicationWidget(int cells)
        {
            this.dashboard = new GridLayoutDashboard(CoreManager.MomConsole.ViewPane, cells); 
        }
        #endregion
        
        #region IAllApplicationWidget Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAllApplicationWidgetControls Controls //?
        {
            get
            {
                return this.Controls;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control AllApplications
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AllApplicationsText
        {
            get
            {
                return this.Controls.AllApplicationsTextBox.Text;
            }
            
            set
            {
                this.Controls.AllApplicationsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control ServiceLevelAgreements
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceLevelAgreementsText
        {
            get
            {
                return this.Controls.ServiceLevelAgreementsTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceLevelAgreementsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar4 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar IAllApplicationWidgetControls.ProgressBar4
        {
            get
            {
                if ((this.cachedProgressBar4 == null))
                {
                    this.cachedProgressBar4 = new ProgressBar(this.dashboard.Cells[0], AllApplicationWidget.QueryIds.ProgressBar4);
                }
                
                return this.cachedProgressBar4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AllApplicationsTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAllApplicationWidgetControls.AllApplicationsTextBox
        {
            get
            {
                if ((this.cachedAllApplicationsTextBox == null))
                {
                    this.cachedAllApplicationsTextBox = new TextBox(this.dashboard.Cells[0], AllApplicationWidget.QueryIds.AllApplicationsTextBox);
                }
                
                return this.cachedAllApplicationsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SCOMFilterControlSearchButtonButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.SCOMFilterControlSearchButtonButton
        {
            get
            {
                if ((this.cachedSCOMFilterControlSearchButtonButton == null))
                {
                    this.cachedSCOMFilterControlSearchButtonButton = new Button(this.dashboard.Cells[0], AllApplicationWidget.QueryIds.SCOMFilterControlSearchButtonButton);
                }
                
                return this.cachedSCOMFilterControlSearchButtonButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SCOMFilterControlCloseButtonButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.SCOMFilterControlCloseButtonButton
        {
            get
            {
                if ((this.cachedSCOMFilterControlCloseButtonButton == null))
                {
                    this.cachedSCOMFilterControlCloseButtonButton = new Button(this.dashboard.Cells[0], AllApplicationWidget.QueryIds.SCOMFilterControlCloseButtonButton);
                }
                
                return this.cachedSCOMFilterControlCloseButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DataGrid5 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IAllApplicationWidgetControls.DataGrid5
        {
            get
            {
                if ((this.cachedDataGrid5 == null))
                {
                    this.cachedDataGrid5 = new DataGrid(this.dashboard.Cells[0], AllApplicationWidget.QueryIds.DataGrid5);
                }
                
                return this.cachedDataGrid5;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Button1Button control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (Button1Button) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.Button1Button
        {
            get
            {
                if ((this.cachedButton1Button == null))
                {
                    //
                }
                
                return this.cachedButton1Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar6 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (ProgressBar) is used multiple times in this window.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        ProgressBar IAllApplicationWidgetControls.ProgressBar6
        {
            get
            {
                // TODO: The ID for this control (ProgressBar) is used multiple times in this window.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedProgressBar6 == null))
                {
                    //
                }
                
                return this.cachedProgressBar6;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ServiceLevelAgreementsTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (SCOMWatermarkTextBox) is used multiple times in this window.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        TextBox IAllApplicationWidgetControls.ServiceLevelAgreementsTextBox
        {
            get
            {
                // TODO: The ID for this control (SCOMWatermarkTextBox) is used multiple times in this window.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedServiceLevelAgreementsTextBox == null))
                {
                    //
                }
                
                return this.cachedServiceLevelAgreementsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SCOMFilterControlSearchButtonButton2 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (SCOMFilterControlSearchButton) is used multiple times in this window.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.SCOMFilterControlSearchButtonButton2
        {
            get
            {
                // TODO: The ID for this control (SCOMFilterControlSearchButton) is used multiple times in this window.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedSCOMFilterControlSearchButtonButton2 == null))
                {
                    //
                }
                
                return this.cachedSCOMFilterControlSearchButtonButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SCOMFilterControlCloseButtonButton2 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (SCOMFilterControlCloseButton) is used multiple times in this window.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.SCOMFilterControlCloseButtonButton2
        {
            get
            {
                // TODO: The ID for this control (SCOMFilterControlCloseButton) is used multiple times in this window.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedSCOMFilterControlCloseButtonButton2 == null))
                {
                    //
                }
                
                return this.cachedSCOMFilterControlCloseButtonButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DataGrid7 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (InnerDataGrid) is used multiple times in this window.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        DataGrid IAllApplicationWidgetControls.DataGrid7
        {
            get
            {
                if ((this.cachedDataGrid7 == null))
                {
                    this.cachedDataGrid7 = new DataGrid(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.DataGrid7);
                }
                
                return this.cachedDataGrid7;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Button3Button control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (Button3Button) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.Button3Button
        {
            get
            {
                if ((this.cachedButton3Button == null))
                {
                    //
                }
                
                return this.cachedButton3Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LineUpButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.LineUpButton
        {
            get
            {
                if ((this.cachedLineUpButton == null))
                {
                    this.cachedLineUpButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.LineUpButton);
                }
                
                return this.cachedLineUpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PageUpButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.PageUpButton
        {
            get
            {
                if ((this.cachedPageUpButton == null))
                {
                    this.cachedPageUpButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.PageUpButton);
                }
                
                return this.cachedPageUpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PageDownButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.PageDownButton
        {
            get
            {
                if ((this.cachedPageDownButton == null))
                {
                    this.cachedPageDownButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.PageDownButton);
                }
                
                return this.cachedPageDownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LineDownButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.LineDownButton
        {
            get
            {
                if ((this.cachedLineDownButton == null))
                {
                    this.cachedLineDownButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.LineDownButton);
                }
                
                return this.cachedLineDownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LineLeftButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.LineLeftButton
        {
            get
            {
                if ((this.cachedLineLeftButton == null))
                {
                    this.cachedLineLeftButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.LineLeftButton);
                }
                
                return this.cachedLineLeftButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PageLeftButton control
        /// </summary>
        /// <history>
        Button IAllApplicationWidgetControls.PageLeftButton
        {
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
            get
            {
                if ((this.cachedPageLeftButton == null))
                {
                    this.cachedPageLeftButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.PageLeftButton);
                }
                
                return this.cachedPageLeftButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PageRightButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.PageRightButton
        {
            get
            {
                if ((this.cachedPageRightButton == null))
                {
                    this.cachedPageRightButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.PageRightButton);
                }
                
                return this.cachedPageRightButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LineRightButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAllApplicationWidgetControls.LineRightButton
        {
            get
            {
                if ((this.cachedLineRightButton == null))
                {
                    this.cachedLineRightButton = new Button(this.dashboard.Cells[1], AllApplicationWidget.QueryIds.LineRightButton);
                }
                
                return this.cachedLineRightButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SCOMFilterControlSearchButton
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSCOMFilterControlSearchButton()
        {
            this.Controls.SCOMFilterControlSearchButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SCOMFilterControlCloseButton
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSCOMFilterControlCloseButton()
        {
            this.Controls.SCOMFilterControlCloseButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SCOMFilterControlSearchButton2
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSCOMFilterControlSearchButton2()
        {
            this.Controls.SCOMFilterControlSearchButtonButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SCOMFilterControlCloseButton2
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSCOMFilterControlCloseButton2()
        {
            this.Controls.SCOMFilterControlCloseButtonButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button3
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton3()
        {
            this.Controls.Button3Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button LineUp
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLineUp()
        {
            this.Controls.LineUpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PageUp
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPageUp()
        {
            this.Controls.PageUpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PageDown
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPageDown()
        {
            this.Controls.PageDownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button LineDown
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLineDown()
        {
            this.Controls.LineDownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button LineLeft
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLineLeft()
        {
            this.Controls.LineLeftButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PageLeft
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPageLeft()
        {
            this.Controls.PageLeftButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PageRight
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPageRight()
        {
            this.Controls.PageRightButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button LineRight
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLineRight()
        {
            this.Controls.LineRightButton.Click();
        }
        #endregion
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ProgressBar4 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar4 = ";[UIA]AutomationId=\'ProgressBar\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AllApplicationsTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllApplicationsTextBox = ";[UIA]AutomationId=\'SCOMWatermarkTextBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMFilterControlSearchButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMFilterControlSearchButtonButton = ";[UIA]AutomationId=\'SCOMFilterControlSearchButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMFilterControlCloseButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMFilterControlCloseButtonButton = ";[UIA]AutomationId=\'SCOMFilterControlCloseButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DataGrid5 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGrid5 = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ProgressBar6 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar6 = ";[UIA]AutomationId=\'ProgressBar\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ServiceLevelAgreementsTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelAgreementsTextBox = ";[UIA]AutomationId=\'SCOMWatermarkTextBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMFilterControlSearchButtonButton2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMFilterControlSearchButtonButton2 = ";[UIA]AutomationId=\'SCOMFilterControlSearchButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMFilterControlCloseButtonButton2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMFilterControlCloseButtonButton2 = ";[UIA]AutomationId=\'SCOMFilterControlCloseButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DataGrid7 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGrid7 = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LineUpButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLineUpButton = ";[UIA]AutomationId=\'LineUp\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PageUpButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePageUpButton = ";[UIA]AutomationId=\'PageUp\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PageDownButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePageDownButton = ";[UIA]AutomationId=\'PageDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LineDownButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLineDownButton = ";[UIA]AutomationId=\'LineDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LineLeftButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLineLeftButton = ";[UIA]AutomationId=\'LineLeft\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PageLeftButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePageLeftButton = ";[UIA]AutomationId=\'PageLeft\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PageRightButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePageRightButton = ";[UIA]AutomationId=\'PageRight\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LineRightButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLineRightButton = ";[UIA]AutomationId=\'LineRight\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ProgressBar4 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar4
            {
                get
                {
                    return new QID(ResourceProgressBar4);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AllApplicationsTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AllApplicationsTextBox
            {
                get
                {
                    return new QID(ResourceAllApplicationsTextBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMFilterControlSearchButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMFilterControlSearchButtonButton
            {
                get
                {
                    return new QID(ResourceSCOMFilterControlSearchButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMFilterControlCloseButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMFilterControlCloseButtonButton
            {
                get
                {
                    return new QID(ResourceSCOMFilterControlCloseButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DataGrid5 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DataGrid5
            {
                get
                {
                    return new QID(ResourceDataGrid5);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ProgressBar6 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar6
            {
                get
                {
                    return new QID(ResourceProgressBar6);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ServiceLevelAgreementsTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ServiceLevelAgreementsTextBox
            {
                get
                {
                    return new QID(ResourceServiceLevelAgreementsTextBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMFilterControlSearchButtonButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMFilterControlSearchButtonButton2
            {
                get
                {
                    return new QID(ResourceSCOMFilterControlSearchButtonButton2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMFilterControlCloseButtonButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMFilterControlCloseButtonButton2
            {
                get
                {
                    return new QID(ResourceSCOMFilterControlCloseButtonButton2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DataGrid7 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DataGrid7
            {
                get
                {
                    return new QID(ResourceDataGrid7);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the LineUpButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LineUpButton
            {
                get
                {
                    return new QID(ResourceLineUpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PageUpButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PageUpButton
            {
                get
                {
                    return new QID(ResourcePageUpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PageDownButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PageDownButton
            {
                get
                {
                    return new QID(ResourcePageDownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the LineDownButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LineDownButton
            {
                get
                {
                    return new QID(ResourceLineDownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the LineLeftButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LineLeftButton
            {
                get
                {
                    return new QID(ResourceLineLeftButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PageLeftButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PageLeftButton
            {
                get
                {
                    return new QID(ResourcePageLeftButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PageRightButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PageRightButton
            {
                get
                {
                    return new QID(ResourcePageRightButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the LineRightButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/9/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LineRightButton
            {
                get
                {
                    return new QID(ResourceLineRightButton);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [asttest] 11/9/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Private Static Members

            private static string cachedHealthColumn;
            private const  string ResourceHealthColumn="";

            private static string cachedDashboardDisplayNameColumn;
            private const  string ResourceDashboardDisplayNameColumn="";

            private static string cachedAverageResponseTimeColumn;
            private const  string ResourceAverageResponseTimeColumn="";

            private static string cachedAvailabilityColumn;
            private const  string ResourceAvailabilityColumn="";

            private static string cachedPerformanceColumn;
            private const  string ResourcePerformanceColumn="";

            private static string cachedReliabilityColumn;
            private const  string ResourceReliabilityColumn="";

            private static string cachedServiceLevelAgreementsTitle;
            private const  string ResourceServiceLevelAgreementsTitle="";

            private static string cachedSLAComplianceColumn;
            private const  string ResourceSLAComplianceColumn="";

            private static string cachedSLADisplayNameColumn;
            private const  string ResourceSLADisplayNameColumn="";
            
            #endregion

            #region Properties

            public static string HealthColumn
            {
                get 
                {
                    if ((cachedHealthColumn == null))
                    {
                        cachedHealthColumn = CoreManager.MomConsole.GetIntlStr(ResourceHealthColumn);
                    }
                    return cachedHealthColumn;
                }
            }

            public static string DashboardDisplayNameColumn
            {
                get 
                {
                    if ((cachedDashboardDisplayNameColumn == null))
                    {
                        cachedDashboardDisplayNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceDashboardDisplayNameColumn);
                    }
                    return cachedDashboardDisplayNameColumn;
                }
            }

            public static string AverageResponseTimeColumn
            {
                get 
                {
                    if ((cachedAverageResponseTimeColumn == null))
                    {
                        cachedAverageResponseTimeColumn = CoreManager.MomConsole.GetIntlStr(ResourceAverageResponseTimeColumn);
                    }
                    return cachedAverageResponseTimeColumn;
                }
            }

            public static string AvailabilityColumn
            {
                get 
                {
                    if ((cachedAvailabilityColumn == null))
                    {
                        cachedAvailabilityColumn = CoreManager.MomConsole.GetIntlStr(ResourceAvailabilityColumn);
                    }
                    return cachedAvailabilityColumn;
                }
            }

            public static string PerformanceColumn
            {
                get 
                {
                    if ((cachedPerformanceColumn == null))
                    {
                        cachedPerformanceColumn = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceColumn);
                    }
                    return cachedPerformanceColumn;
                }
            }

            public static string ReliabilityColumn
            {
                get 
                {
                    if ((cachedReliabilityColumn == null))
                    {
                        cachedReliabilityColumn = CoreManager.MomConsole.GetIntlStr(ResourceReliabilityColumn);
                    }
                    return cachedReliabilityColumn;
                }
            }

            public static string ServiceLevelAgreementsTitle
            {
                get 
                {
                    if ((cachedServiceLevelAgreementsTitle == null))
                    {
                        cachedServiceLevelAgreementsTitle = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelAgreementsTitle);
                    }
                    return cachedServiceLevelAgreementsTitle;
                }
            }

            public static string SlaComplianceColumn
            {
                get 
                {
                    if ((cachedSLAComplianceColumn == null))
                    {
                        cachedSLAComplianceColumn = CoreManager.MomConsole.GetIntlStr(ResourceSLAComplianceColumn);
                    }
                    return cachedSLAComplianceColumn;
                }
            }

            public static string SlaDisplayNameColumn
            {
                get 
                {
                    if ((cachedSLADisplayNameColumn == null))
                    {
                        cachedSLADisplayNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceSLADisplayNameColumn);
                    }
                    return cachedSLADisplayNameColumn;
                }
            }

            #endregion
        }
        #endregion
    }
}
