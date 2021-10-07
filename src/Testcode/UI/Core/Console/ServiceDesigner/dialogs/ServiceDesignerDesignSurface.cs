// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceDesignerDesignSurfaceDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	Service Designer Design Surface
// </project>
// <summary>
// 	Allows users to create new Distributed Applications (aka Services).
// </summary>
// <history>
// 	[mcorning] 4/20/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IDesignSurfaceControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDesignSurfaceControls, for DesignSurface.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mcorning] 4/20/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDesignSurfaceControls
    {
        /// <summary>
        /// Read-only property to access ButtonGo
        /// </summary>
        Button ButtonGo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchForObjectsStaticControl
        /// </summary>
        StaticControl SearchForObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedSearchStaticControl
        /// </summary>
        StaticControl AdvancedSearchStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchForObjectsTextBox
        /// </summary>
        TextBox SearchForObjectsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ListViewSCInstances
        /// </summary>
        ListView ListViewSCInstances
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TreeViewDetails
        /// </summary>
        TreeView TreeViewDetails
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowSimilarObjectsAtTheSameLevelCheckBox
        /// </summary>
        CheckBox ShowSimilarObjectsAtTheSameLevelCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsStaticControl
        /// </summary>
        StaticControl ObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl
        /// </summary>
        StaticControl YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl
        /// </summary>
        StaticControl SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiagramViewStaticControl
        /// </summary>
        StaticControl DiagramViewStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertViewStaticControl
        /// </summary>
        StaticControl AlertViewStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StateViewStaticControl
        /// </summary>
        StaticControl StateViewStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewsStaticControl
        /// </summary>
        StaticControl ViewsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TemplateStaticControl
        /// </summary>
        StaticControl TemplateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LabelServiceComponentGroupsValue
        /// </summary>
        StaticControl LabelServiceComponentGroupsValue
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceComponentGroupsStaticControl
        /// </summary>
        StaticControl ServiceComponentGroupsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BlankStaticControl
        /// </summary>
        StaticControl BlankStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceTemplateStaticControl
        /// </summary>
        StaticControl ServiceTemplateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LabelServiceDescriptionValue
        /// </summary>
        StaticControl LabelServiceDescriptionValue
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceDescriptionStaticControl
        /// </summary>
        StaticControl ServiceDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KeyDetailsStaticControl
        /// </summary>
        StaticControl KeyDetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStripObjectSearch
        /// </summary>
        Toolbar ToolStripObjectSearch
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OrientationComboBox
        /// </summary>
        ComboBox OrientationComboBox
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
    /// 	[mcorning] 4/20/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DesignSurface : Dialog, IDesignSurfaceControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ButtonGo of type Button
        /// </summary>
        private Button cachedButtonGo;
        
        /// <summary>
        /// Cache to hold a reference to SearchForObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchForObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedSearchStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdvancedSearchStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchForObjectsTextBox of type TextBox
        /// </summary>
        private TextBox cachedSearchForObjectsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ListViewSCInstances of type ListView
        /// </summary>
        private ListView cachedListViewSCInstances;
        
        /// <summary>
        /// Cache to hold a reference to TreeViewDetails of type TreeView
        /// </summary>
        private TreeView cachedTreeViewDetails;
        
        /// <summary>
        /// Cache to hold a reference to ShowSimilarObjectsAtTheSameLevelCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedShowSimilarObjectsAtTheSameLevelCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiagramViewStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiagramViewStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertViewStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertViewStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StateViewStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStateViewStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LabelServiceComponentGroupsValue of type StaticControl
        /// </summary>
        private StaticControl cachedLabelServiceComponentGroupsValue;
        
        /// <summary>
        /// Cache to hold a reference to ServiceComponentGroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceComponentGroupsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BlankStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBlankStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceTemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LabelServiceDescriptionValue of type StaticControl
        /// </summary>
        private StaticControl cachedLabelServiceDescriptionValue;

        /// <summary>
        /// Cache to hold a reference to ServiceDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KeyDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKeyDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStripObjectSearch of type Toolbar
        /// </summary>
        private Toolbar cachedToolStripObjectSearch;
        
        /// <summary>
        /// Cache to hold a reference to OrientationComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedOrientationComboBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DesignSurface of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DesignSurface(MomConsoleApp app) : 
                base(app, Init(app))
        {
            //Mom.Test.UI.Core.Common.Utilities.LogMessage("Constructor is waiting for " + this.Caption + " to be ready...");
            //UISynchronization.WaitForUIObjectReady(this, 10000);
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DesignSurface of type MomConsoleApp
        /// </param>
        /// <param name="serviceName">name of specific service window to find</param>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DesignSurface(MomConsoleApp app, string serviceName) : 
                base(app, Init(app, serviceName))
        {
            //Mom.Test.UI.Core.Common.Utilities.LogMessage("Constructor is waiting for " + this.Caption + " to be ready...");
            //UISynchronization.WaitForUIObjectReady(this, 10000);
        }
        #endregion
        
        #region IDesignSurface Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDesignSurfaceControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ShowSimilarObjectsAtTheSameLevel
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowSimilarObjectsAtTheSameLevel
        {
            get
            {
                return this.Controls.ShowSimilarObjectsAtTheSameLevelCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ShowSimilarObjectsAtTheSameLevelCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SearchForObjects
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchForObjectsText
        {
            get
            {
                return this.Controls.SearchForObjectsTextBox.Text;
            }
            
            set
            {
                this.Controls.SearchForObjectsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control OrientationComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OrientationComboBoxText
        {
            get
            {
                return this.Controls.OrientationComboBox.Text;
            }
            
            set
            {
                this.Controls.OrientationComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ButtonGo control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDesignSurfaceControls.ButtonGo
        {
            get
            {
                if ((this.cachedButtonGo == null))
                {
                    this.cachedButtonGo = new Button(this, DesignSurface.ControlIDs.ButtonGo);
                }
                return this.cachedButtonGo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchForObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.SearchForObjectsStaticControl
        {
            get
            {
                if ((this.cachedSearchForObjectsStaticControl == null))
                {
                    this.cachedSearchForObjectsStaticControl = new StaticControl(this, DesignSurface.ControlIDs.SearchForObjectsStaticControl);
                }
                return this.cachedSearchForObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedSearchStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.AdvancedSearchStaticControl
        {
            get
            {
                if ((this.cachedAdvancedSearchStaticControl == null))
                {
                    this.cachedAdvancedSearchStaticControl = new StaticControl(this, DesignSurface.ControlIDs.AdvancedSearchStaticControl);
                }
                return this.cachedAdvancedSearchStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchForObjectsTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDesignSurfaceControls.SearchForObjectsTextBox
        {
            get
            {
                if ((this.cachedSearchForObjectsTextBox == null))
                {
                    this.cachedSearchForObjectsTextBox = new TextBox(this, DesignSurface.ControlIDs.SearchForObjectsTextBox);
                }
                return this.cachedSearchForObjectsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListViewSCInstances control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IDesignSurfaceControls.ListViewSCInstances
        {
            get
            {
                if ((this.cachedListViewSCInstances == null))
                {
                    this.cachedListViewSCInstances = new ListView(this, DesignSurface.ControlIDs.ListViewSCInstances);
                }
                return this.cachedListViewSCInstances;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TreeViewDetails control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IDesignSurfaceControls.TreeViewDetails
        {
            get
            {
                if ((this.cachedTreeViewDetails == null))
                {
                    this.cachedTreeViewDetails = new TreeView(this, DesignSurface.ControlIDs.TreeViewDetails);
                }
                return this.cachedTreeViewDetails;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowSimilarObjectsAtTheSameLevelCheckBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDesignSurfaceControls.ShowSimilarObjectsAtTheSameLevelCheckBox
        {
            get
            {
                if ((this.cachedShowSimilarObjectsAtTheSameLevelCheckBox == null))
                {
                    this.cachedShowSimilarObjectsAtTheSameLevelCheckBox = new CheckBox(this, DesignSurface.ControlIDs.ShowSimilarObjectsAtTheSameLevelCheckBox);
                }
                return this.cachedShowSimilarObjectsAtTheSameLevelCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.ObjectsStaticControl
        {
            get
            {
                if ((this.cachedObjectsStaticControl == null))
                {
                    this.cachedObjectsStaticControl = new StaticControl(this, DesignSurface.ControlIDs.ObjectsStaticControl);
                }
                return this.cachedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl
        {
            get
            {
                if ((this.cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAboveStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl
        {
            get
            {
                if ((this.cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl == null))
                {
                    this.cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl = new StaticControl(this, DesignSurface.ControlIDs.SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl);
                }
                return this.cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagramViewStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.DiagramViewStaticControl
        {
            get
            {
                if ((this.cachedDiagramViewStaticControl == null))
                {
                    this.cachedDiagramViewStaticControl = new StaticControl(this, DesignSurface.ControlIDs.DiagramViewStaticControl);
                }
                return this.cachedDiagramViewStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertViewStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.AlertViewStaticControl
        {
            get
            {
                if ((this.cachedAlertViewStaticControl == null))
                {
                    this.cachedAlertViewStaticControl = new StaticControl(this, DesignSurface.ControlIDs.AlertViewStaticControl);
                }
                return this.cachedAlertViewStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StateViewStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.StateViewStaticControl
        {
            get
            {
                if ((this.cachedStateViewStaticControl == null))
                {
                    this.cachedStateViewStaticControl = new StaticControl(this, DesignSurface.ControlIDs.StateViewStaticControl);
                }
                return this.cachedStateViewStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.ViewsStaticControl
        {
            get
            {
                if ((this.cachedViewsStaticControl == null))
                {
                    this.cachedViewsStaticControl = new StaticControl(this, DesignSurface.ControlIDs.ViewsStaticControl);
                }
                return this.cachedViewsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.TemplateStaticControl
        {
            get
            {
                if ((this.cachedTemplateStaticControl == null))
                {
                    this.cachedTemplateStaticControl = new StaticControl(this, DesignSurface.ControlIDs.DetailsTitleStaticControl);
                }
                return this.cachedTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LabelServiceComponentGroupsValue control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.LabelServiceComponentGroupsValue
        {
            get
            {
                if ((this.cachedLabelServiceComponentGroupsValue == null))
                {
                    this.cachedLabelServiceComponentGroupsValue = new StaticControl(this, DesignSurface.ControlIDs.LabelServiceComponentGroupsValue);
                }
                return this.cachedLabelServiceComponentGroupsValue;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceComponentGroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.ServiceComponentGroupsStaticControl
        {
            get
            {
                if ((this.cachedServiceComponentGroupsStaticControl == null))
                {
                    this.cachedServiceComponentGroupsStaticControl = new StaticControl(this, DesignSurface.ControlIDs.ServiceComponentGroupsStaticControl);
                }
                return this.cachedServiceComponentGroupsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BlankStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.BlankStaticControl
        {
            get
            {
                if ((this.cachedBlankStaticControl == null))
                {
                    this.cachedBlankStaticControl = new StaticControl(this, DesignSurface.ControlIDs.BlankStaticControl);
                }
                return this.cachedBlankStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceTemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.ServiceTemplateStaticControl
        {
            get
            {
                if ((this.cachedServiceTemplateStaticControl == null))
                {
                    this.cachedServiceTemplateStaticControl = new StaticControl(this, DesignSurface.ControlIDs.ServiceTemplateStaticControl);
                }
                return this.cachedServiceTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LabelServiceDescriptionValue control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.LabelServiceDescriptionValue
        {
            get
            {
                if ((this.cachedLabelServiceDescriptionValue == null))
                {
                    this.cachedLabelServiceDescriptionValue = new StaticControl(this, DesignSurface.ControlIDs.LabelServiceDescriptionValue);
                }
                return this.cachedLabelServiceDescriptionValue;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.ServiceDescriptionStaticControl
        {
            get
            {
                if ((this.cachedServiceDescriptionStaticControl == null))
                {
                    this.cachedServiceDescriptionStaticControl = new StaticControl(this, DesignSurface.ControlIDs.ServiceDescriptionStaticControl);
                }
                return this.cachedServiceDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KeyDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDesignSurfaceControls.KeyDetailsStaticControl
        {
            get
            {
                if ((this.cachedKeyDetailsStaticControl == null))
                {
                    this.cachedKeyDetailsStaticControl = new StaticControl(this, DesignSurface.ControlIDs.KeyDetailsStaticControl);
                }
                return this.cachedKeyDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStripObjectSearch control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IDesignSurfaceControls.ToolStripObjectSearch
        {
            get
            {
                if ((this.cachedToolStripObjectSearch == null))
                {
                    this.cachedToolStripObjectSearch = new Toolbar(this, DesignSurface.ControlIDs.ToolStripObjectSearch);
                }
                return this.cachedToolStripObjectSearch;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OrientationComboBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDesignSurfaceControls.OrientationComboBox
        {
            get
            {
                if ((this.cachedOrientationComboBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedOrientationComboBox = new ComboBox(wndTemp);
                }
                return this.cachedOrientationComboBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ButtonGo
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButtonGo()
        {
            this.Controls.ButtonGo.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on toolbar Save button
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSaveToolbar()
        {
            foreach (ToolbarItem item in this.Controls.ToolStripObjectSearch.ToolbarItems)
            {
                if (item.Text == "Save")
                {
                    item.Click();
                    break;
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowSimilarObjectsAtTheSameLevel
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowSimilarObjectsAtTheSameLevel()
        {
            this.Controls.ShowSimilarObjectsAtTheSameLevelCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            return Utility.GetDialogOrWindow(app, Strings.DialogTitle, 1000, true, true);
        }
        /// <summary>
        /// This function will attempt to find a specific service.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="app">MomConsoleApp class instance that owns this window.</param>)
        /// <param name="serviceName">Service name</param>
        /// <history>
        /// 	[mcorning] 14-Apr-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, string serviceName)
        {
            return Utility.GetDialogOrWindow(app, serviceName, 1000, true, true);
        }        

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mcorning] 4/20/2006 Created
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
            private const string ResourceDialogTitle = ";Service Designer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerResources;ServiceDesigner";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchForObjects
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchForObjects = "Search for o&bjects:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdvancedSearch
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvancedSearch = "Advanced Search";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowSimilarObjectsAtTheSameLevel
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowSimilarObjectsAtTheSameLevel = "Sho&w similar objects at the same level";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Objects
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjects = "Objects";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove = "You can create new Service Components by clicking the \'Add Service Component\' but" +
                "ton above.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet = "* Some links are disabled because the selected object has not been saved yet.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiagramView
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagramView = "Diagram View";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertView
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertView = "Alert View";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StateView
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceStateView = "State View";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Views
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceViews = "Views";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Template
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTemplate = "template";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_0 = "0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceComponentGroups
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceComponentGroups = "Service Component Groups:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Blank
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceBlank = "Blank";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceTemplate
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceTemplate = "Service Template:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceDescription
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceDescription = "Service Description:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  KeyDetails
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceKeyDetails = "Key Details";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateRelationship
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateRelationship = ";Create &Relationship;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripButtonCreateRelationship.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Relayout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRelayout = ";Rel&ayout;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripButtonAutoLayout.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Modeling Design Surface
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceModelingDesignSurface = ";Modeling Design Surface;ManagedString;Microsoft.VisualStudio.Modeling.Sdk.Diagrams.dll;Microsoft.VisualStudio.Modeling.Diagrams.DesignSurfaceStrings;DiagramClientViewAccessibleName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Area
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceArea = ";Area;ManagedString;Microsoft.VisualStudio.Modeling.Sdk.Diagrams.dll;Microsoft.VisualStudio.Modeling.Diagrams.DesignSurfaceStrings;AreaFieldAccessibleName";



            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  toolStripContainer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStripContainer = ";toolStripContainer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerControl;toolStripContainer.Text";

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
            /// Caches the translated resource string for:  SearchForObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchForObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdvancedSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvancedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowSimilarObjectsAtTheSameLevel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowSimilarObjectsAtTheSameLevel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiagramView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagramView;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertView;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StateView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateView;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViews;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceComponentGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceComponentGroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Blank
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBlank;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  KeyDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKeyDetails;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateRelationship
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateRelationship;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Relayout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRelayout;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ModelingDesignSurface
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedModelingDesignSurface;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Area
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedArea;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStripContainer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStripContainer;            
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
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
            /// Exposes access to the SearchForObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchForObjects
            {
                get
                {
                    if ((cachedSearchForObjects == null))
                    {
                        cachedSearchForObjects = CoreManager.MomConsole.GetIntlStr(ResourceSearchForObjects);
                    }
                    return cachedSearchForObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdvancedSearch translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedSearch
            {
                get
                {
                    if ((cachedAdvancedSearch == null))
                    {
                        cachedAdvancedSearch = CoreManager.MomConsole.GetIntlStr(ResourceAdvancedSearch);
                    }
                    return cachedAdvancedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowSimilarObjectsAtTheSameLevel translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowSimilarObjectsAtTheSameLevel
            {
                get
                {
                    if ((cachedShowSimilarObjectsAtTheSameLevel == null))
                    {
                        cachedShowSimilarObjectsAtTheSameLevel = CoreManager.MomConsole.GetIntlStr(ResourceShowSimilarObjectsAtTheSameLevel);
                    }
                    return cachedShowSimilarObjectsAtTheSameLevel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Objects translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Objects
            {
                get
                {
                    if ((cachedObjects == null))
                    {
                        cachedObjects = CoreManager.MomConsole.GetIntlStr(ResourceObjects);
                    }
                    return cachedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove
            {
                get
                {
                    if ((cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove == null))
                    {
                        cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove = CoreManager.MomConsole.GetIntlStr(ResourceYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove);
                    }
                    return cachedYouCanCreateNewServiceComponentsByClickingTheAddServiceComponentButtonAbove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet
            {
                get
                {
                    if ((cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet == null))
                    {
                        cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet = CoreManager.MomConsole.GetIntlStr(ResourceSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet);
                    }
                    return cachedSomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagramView translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagramView
            {
                get
                {
                    if ((cachedDiagramView == null))
                    {
                        cachedDiagramView = CoreManager.MomConsole.GetIntlStr(ResourceDiagramView);
                    }
                    return cachedDiagramView;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertView translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertView
            {
                get
                {
                    if ((cachedAlertView == null))
                    {
                        cachedAlertView = CoreManager.MomConsole.GetIntlStr(ResourceAlertView);
                    }
                    return cachedAlertView;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StateView translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateView
            {
                get
                {
                    if ((cachedStateView == null))
                    {
                        cachedStateView = CoreManager.MomConsole.GetIntlStr(ResourceStateView);
                    }
                    return cachedStateView;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Views
            {
                get
                {
                    if ((cachedViews == null))
                    {
                        cachedViews = CoreManager.MomConsole.GetIntlStr(ResourceViews);
                    }
                    return cachedViews;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Template translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Template
            {
                get
                {
                    if ((cachedTemplate == null))
                    {
                        cachedTemplate = CoreManager.MomConsole.GetIntlStr(ResourceTemplate);
                    }
                    return cachedTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _0 translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _0
            {
                get
                {
                    if ((cached_0 == null))
                    {
                        cached_0 = CoreManager.MomConsole.GetIntlStr(Resource_0);
                    }
                    return cached_0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceComponentGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceComponentGroups
            {
                get
                {
                    if ((cachedServiceComponentGroups == null))
                    {
                        cachedServiceComponentGroups = CoreManager.MomConsole.GetIntlStr(ResourceServiceComponentGroups);
                    }
                    return cachedServiceComponentGroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Blank translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Blank
            {
                get
                {
                    if ((cachedBlank == null))
                    {
                        cachedBlank = CoreManager.MomConsole.GetIntlStr(ResourceBlank);
                    }
                    return cachedBlank;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceTemplate
            {
                get
                {
                    if ((cachedServiceTemplate == null))
                    {
                        cachedServiceTemplate = CoreManager.MomConsole.GetIntlStr(ResourceServiceTemplate);
                    }
                    return cachedServiceTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceDescription
            {
                get
                {
                    if ((cachedServiceDescription == null))
                    {
                        cachedServiceDescription = CoreManager.MomConsole.GetIntlStr(ResourceServiceDescription);
                    }
                    return cachedServiceDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the KeyDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 4/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string KeyDetails
            {
                get
                {
                    if ((cachedKeyDetails == null))
                    {
                        cachedKeyDetails = CoreManager.MomConsole.GetIntlStr(ResourceKeyDetails);
                    }
                    return cachedKeyDetails;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateRelationship translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 7/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateRelationship
            {
                get
                {
                    if ((cachedCreateRelationship == null))
                    {
                        cachedCreateRelationship = CoreManager.MomConsole.GetIntlStr(ResourceCreateRelationship);
                    }
                    return cachedCreateRelationship;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Relayout translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Relayout
            {
                get
                {
                    if ((cachedRelayout == null))
                    {
                        cachedRelayout = CoreManager.MomConsole.GetIntlStr(ResourceRelayout);
                    }
                    return cachedRelayout;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ModelingDesignSurface translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ModelingDesignSurface
            {
                get
                {
                    if ((cachedModelingDesignSurface == null))
                    {
                        cachedModelingDesignSurface = CoreManager.MomConsole.GetIntlStr(ResourceModelingDesignSurface);
                    }
                    return cachedModelingDesignSurface;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Area translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 7/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Area
            {
                get
                {
                    if ((cachedArea == null))
                    {
                        cachedArea = CoreManager.MomConsole.GetIntlStr(ResourceArea);
                    }
                    return cachedArea;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStripContainer translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStripContainer
            {
                get
                {
                    if ((cachedToolStripContainer == null))
                    {
                        cachedToolStripContainer = CoreManager.MomConsole.GetIntlStr(ResourceToolStripContainer);
                    }
                    return cachedToolStripContainer;
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
        /// 	[mcorning] 4/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ButtonGo
            /// </summary>
            public const string ButtonGo = "buttonGo";
            
            /// <summary>
            /// Control ID for SearchForObjectsStaticControl
            /// </summary>
            public const string SearchForObjectsStaticControl = "labelSearch";
            
            /// <summary>
            /// Control ID for AdvancedSearchStaticControl
            /// </summary>
            public const string AdvancedSearchStaticControl = "linkLabelBrowseAdvanced";
            
            /// <summary>
            /// Control ID for SearchForObjectsTextBox
            /// </summary>
            public const string SearchForObjectsTextBox = "textBoxExpression";
            
            /// <summary>
            /// Control ID for ListViewSCInstances
            /// </summary>
            public const string ListViewSCInstances = "listViewSCInstances";
            
            /// <summary>
            /// Control ID for TreeViewDetails
            /// </summary>
            public const string TreeViewDetails = "treeViewDetails";
            
            /// <summary>
            /// Control ID for ShowSimilarObjectsAtTheSameLevelCheckBox
            /// </summary>
            public const string ShowSimilarObjectsAtTheSameLevelCheckBox = "checkBoxAllSameLevel";
            
            /// <summary>
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "leftLabel";
            
            /// <summary>
            /// Control ID for SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl
            /// </summary>
            public const string SomeLinksAreDisabledBecauseTheSelectedObjectHasNotBeenSavedYetStaticControl = "labelSDisabledLinks";
            
            /// <summary>
            /// Control ID for DiagramViewStaticControl
            /// </summary>
            public const string DiagramViewStaticControl = "linkLabelSDiagramView";
            
            /// <summary>
            /// Control ID for AlertViewStaticControl
            /// </summary>
            public const string AlertViewStaticControl = "linkLabelSAlertView";
            
            /// <summary>
            /// Control ID for StateViewStaticControl
            /// </summary>
            public const string StateViewStaticControl = "linkLabelSStateView";
            
            /// <summary>
            /// Control ID for ViewsStaticControl
            /// </summary>
            public const string ViewsStaticControl = "labelSViews";
            
            /// <summary>
            /// Control ID for TemplateStaticControl
            /// </summary>
            public const string DetailsTitleStaticControl = "labelSTitle";
            
            /// <summary>
            /// Control ID for LabelServiceComponentGroupsValue
            /// </summary>
            public const string LabelServiceComponentGroupsValue = "labelSServiceComponentGroupsValue";
            
            /// <summary>
            /// Control ID for ServiceComponentGroupsStaticControl
            /// </summary>
            public const string ServiceComponentGroupsStaticControl = "labelSServiceComponentGroups";
            
            /// <summary>
            /// Control ID for BlankStaticControl
            /// </summary>
            public const string BlankStaticControl = "labelSServiceTemplateValue";
            
            /// <summary>
            /// Control ID for ServiceTemplateStaticControl
            /// </summary>
            public const string ServiceTemplateStaticControl = "labelSServiceTemplate";
            
            /// <summary>
            /// Control ID for LabelServiceDescriptionValue
            /// </summary>
            public const string LabelServiceDescriptionValue = "labelSServiceDescriptionValue";
            
            /// <summary>
            /// Control ID for ServiceDescriptionStaticControl
            /// </summary>
            public const string ServiceDescriptionStaticControl = "labelServiceDescription";
            
            /// <summary>
            /// Control ID for KeyDetailsStaticControl
            /// </summary>
            public const string KeyDetailsStaticControl = "labelSKeyDetails";
            
            /// <summary>
            /// Control ID for ToolStripObjectSearch
            /// </summary>
            public const string ToolStripObjectSearch = "toolStripObjectSearch";
        }
        #endregion
    }
}
