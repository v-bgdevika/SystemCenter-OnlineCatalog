//-------------------------------------------------------------------
// <copyright file="ViewToolbar.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   View Toolbar.
// </summary>
//  <history>
//  [kellymor] 08SEP05: Created
//  [kellymor] 23SEP05: Added renamed interfaces.  Added new properties to
//                      to get the correct interface types.
//                      Added new click methods
//  [ruhim]    11SEP06: Added properties and click methods for Overrides Toolbar button
//  [kellymor] 09APR07: Updated diagram view toolbar interface, properties and
//                      methods.
//                      Added a strings class and a diagram menu
//                      class to hold resource strings for toolbar
//                      menu items.
//  [kellymor] 12APR07: Fixed off-by-one issue with diagram toolbar
//                      items.
//  [kellymor] 17JUL07: Added methods to diagram view toolbar interface to
//                      handle save view, autolayout and export to visio
//                      Added enumeration for new button indexes to improve
//                      code maintainability and readability
//  [kellymor] 18SEP07: Modified code for Export Image/Visio click methods
//  [kellymor] 20SEP07: Modified method to click hidden toolbar button
//                      to use AA.Click instead of AA.DoDefaultAction
//                      which can block UI automation in some instances
//  [KellyMor] 21SEP07: Added interface definition for ClickSaveView
//                      to IDiagramViewToolbar
//                      Updated ClickShowNonContainment and 
//                      ClickLegend methods for hidden toolbar items
//  [KellyMor] 11OCT07: Updated resource string for toolbar options
//                      button
//  [KellyMor]  06AUG08 Added class for diagram toolbar item text
//                      Modified diagram toolbar implementation to use
//                      toolbar item text instead of tooltip text
//  [KellyMor]  14AUG08 Modified ClickItemHiddenByOptionsMenu to use
//                      a new utility method to remove any hot-keys
//  [KellyMor]  15AUG08 Use new RemoveAcceleratorKeys method in other
//                      places:  Click methods, GetToolbarItemIndex.
//  [v-raienl]  30DEC09 Use the ScreenElement to find the toolbar item.
//                      Modified ClickItemHiddenByOptionsMenu as a
//                      workaround for it not working under MAUI 2.0
//                      Added ClickToolbarItem method
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core.WinControls;
    using Maui.Core;

    #endregion

    #region Interface Definition - IDiagramViewToolbar

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagramViewToolbar, for ViewToolbar.
    /// Defines properties for accessing UI controls on Diagram View Toolbar.
    /// </summary>
    /// <history>
    /// 	[kellymor] 08SEP05 Created
    ///     [kellymor] 23SEP05 Renamed to IDiagramViewToolbar
    ///     [kellymor] 17JUL07 Added methods for SaveView, Autolayout, and
    ///                        ExportToVisio
    /// </history>
    /// -----------------------------------------------------------------------------
    public interface IDiagramViewToolbar
    {
        #region Interface Properties

        /// <summary>
        /// Save view button
        /// </summary>
        ToolbarItem SaveViewToolbarItem
        {
            get;
        }

        /// <summary>
        /// Print button
        /// </summary>
        ToolbarItem PrintToolbarItem
        {
            get;
        }

        /// <summary>
        /// Print button
        /// </summary>
        ToolbarItem PrintPreviewToolbarItem
        {
            get;
        }

        /// <summary>
        /// Read-only property to get access to the find button
        /// </summary>
        ToolbarItem FindToolbarItem
        {
            get;
        }

        /// <summary>
        /// Read-only property to get access to the zoom in button
        /// </summary>
        ToolbarItem ZoomInToolbarItem
        {
            get;
        }

        /// <summary>
        /// Read-only property to get access to the zoom in button
        /// </summary>
        ToolbarItem ZoomOutToolbarItem
        {
            get;
        }

        /// <summary>
        /// Read-only property to get access to the zoom combo box
        /// </summary>
        ToolbarItem ZoomComboBox
        {
            get;
        }

        /// <summary>
        /// Fit To Space button
        /// </summary>
        ToolbarItem FitToSpaceToolbarItem
        {
            get;
        }

        /// <summary>
        /// Relayout button
        /// </summary>
        ToolbarItem RelayoutToolbarItem
        {
            get;
        }

        /// <summary>
        /// Autolayout button
        /// </summary>
        ToolbarItem AutolayoutToolbarItem
        {
            get;
        }

        /// <summary>
        /// Overview button
        /// </summary>
        ToolbarItem OverviewToolbarItem
        {
            get;
        }
        
        /// <summary>
        /// LayoutDirectionMenu button
        /// </summary>
        ToolbarItem LayoutDirectionMenuToolbarItem
        {
            get;
        }

        /// <summary>
        /// RedStatePath button
        /// </summary>
        ToolbarItem RedStatePathToolbarItem
        {
            get;
        }

        Button ProblemPath
        {
            get;
        }
        /// <summary>
        /// FilterHealthStateMenu button
        /// </summary>
        ToolbarItem FilterHealthStateMenuToolbarItem
        {
            get;
        }

        /// <summary>
        /// Layers button
        /// </summary>
        ToolbarItem LayersToolbarItem
        {
            get;
        }

        /// <summary>
        /// ShowNonContainment button
        /// </summary>
        ToolbarItem ShowNonContainmentToolbarItem
        {
            get;
        }

        /// <summary>
        /// ExportToVisio button
        /// </summary>
        ToolbarItem ExportToVisioToolbarItem
        {
            get;
        }

        /// <summary>
        /// ExportToImage button
        /// </summary>
        ToolbarItem ExportToImageToolbarItem
        {
            get;
        }

        /// <summary>
        /// Legend button
        /// </summary>
        ToolbarItem LegendToolbarItem
        {
            get;
        }

        #endregion // Interface Properties

        #region Interface Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Save Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickSaveView();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Print Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickPrint();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Print Preview Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickPrintPreview();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Find Toolbar Item
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickFind();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom In Toolbar button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickZoomIn();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Out Toolbar button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickZoomOut();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Toolbar Text Field
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickZoom();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Toolbar Dropdown Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickZoomDropDown();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Fit to Space Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickFitToSpace();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Relayout Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickRelayout();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Overview Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickOverview();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click LayoutDirectionMenu Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickLayoutDirectionMenu();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click RedStatePath Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickRedStatePath();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click State Menu Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickFilterHealthStateMenu();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Layers Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickLayers();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click ShowNonContainment Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickShowNonContainment();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Export to Image Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickExportToImage();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Export to Visio Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickExportToVisio();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Legend Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickLegend();

        #endregion // Interface Methods
    }
    #endregion

    #region Interface Definition - IAlertViewToolbar

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertViewToolbar, for ViewToolbar.
    /// Defines properties for accessing UI controls on Alert View Toolbar
    /// </summary>
    /// <history>
    /// 	[kellymor] 23SEP05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public interface IAlertViewToolbar
    {
        /// <summary>
        /// Resolve button
        /// </summary>
        ToolbarItem ResloveButtonToolbarItem
        {
            get;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Toolbar Text Field
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickReslove();
    }

    #endregion // Interface Definition - IAlertViewToolbar

    #region Interface Definition - IViewToolbar

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IViewToolbar, for ViewToolbar.
    /// Defines properties for accessing Common UI controls on View Toolbar
    /// </summary>
    /// <history>
    /// 	[ruhim] 11SEP06 Created
    ///     [kellymor]  09AUG07 Added item for the options button that appears when
    ///                         the toolbar doesn't have enough horizontal space
    ///                         to display all toolbar items.
    /// </history>
    /// -----------------------------------------------------------------------------
    public interface IViewToolbar
    {
        /// <summary>
        /// Overrides button
        /// </summary>
        ToolbarItem OverridesButtonToolbarItem
        {
            get;
        }

        /// <summary>
        /// Toolbar options item
        /// </summary>
        ActiveAccessibility ToolbarOptions { get; }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Overrides Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickOverrides();

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click the toolbar options menu
        /// </summary>
        /// ------------------------------------------------------------------
        void ClickOptionsMenu();
    }

    #endregion // Interface Definition - IViewToolbar

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Console Main Toolbar Definition
    /// </summary>
    /// <history>
    /// 	[kellymor] 12JUL05 Created
    ///     [kellymor] 23SEP05 Added renamed interfaces.  Added new properties to
    ///                        to get the correct interface types.
    ///                        Added new click methods
    ///     [kellymor] 09APR07 Updated diagram view toolbar interface, properties and
    ///                        methods.
    ///     [kellymor] 17JUL07 Added methods to diagram view toolbar interface to
    ///                        handle save view, autolayout and export to visio
    ///                        Added enumeration for new button indexes to improve
    ///                        code maintainability and readability
    /// </history>
    /// -----------------------------------------------------------------------------
    public sealed class ViewToolbar : Toolbar, IDiagramViewToolbar, IAlertViewToolbar, IViewToolbar
    {
        #region "constructors"

        /// ------------------------------------------------------------------
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="app">Console app</param>
        /// <remarks></remarks>
        /// <history>
        /// 	[kellymor] 08SEP05 Created
        /// </history>
        /// ------------------------------------------------------------------
        //public ViewToolbar(ConsoleApp app)
        //    : base(new Window("ViewToolbar", Maui.Core.Utilities.StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, Maui.Core.Utilities.StringMatchSyntax.WildCard, app.MainWindow, 6000))
        //{
        //    // default constructor
        //}
        public ViewToolbar(ConsoleApp app)
            : base(new Window(app.MainWindow, new QID(";[UIA, VisibleOnly] Role = 'tool bar'&& Instance = '3'"), 6000))
        {
            // default constructor
        }
        
        /// ------------------------------------------------------------------
        /// <summary>
        /// Overloaded constructor that takes in the Window Caption
        /// </summary>
        /// <param name="app">Console app</param>
        /// <param name="WindowCaption">Window Caption</param>
        /// <remarks></remarks>
        /// <history>
        /// 	[ruhim] 12SEP06 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ViewToolbar(ConsoleApp app, string WindowCaption)
            : base(new Window(WindowCaption, Maui.Core.Utilities.StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, Maui.Core.Utilities.StringMatchSyntax.WildCard, app.MainWindow, 6000))
        {
            // default constructor
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Overloaded constructor that takes in the Window Caption and parent Window
        /// </summary>
        /// <param name="dialog">Parent Widnow</param>
        /// <param name="WindowCaption">Window Caption</param>
        /// <remarks></remarks>
        /// <history>
        /// 	[v-cheli] 24MAR09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ViewToolbar(Window dialog, string WindowCaption)
            : base(new Window(WindowCaption, Maui.Core.Utilities.StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, Maui.Core.Utilities.StringMatchSyntax.WildCard,dialog, 6000))
        {
            // default constructor
        }
        #endregion

        #region Enumerations

        /// <summary>
        /// Enumeration to map toolbar buttons to indexes
        /// </summary>
        private enum DiagramViewToolbarButtons
        {
            SaveView = 1,
            PrintView,
            PrintPreviewView,
            FindInstance,
            ZoomIn,
            ZoomOut,
            ZoomLevel,
            FitToSpace,
            Relayout,
            AutoLayout,
            Overview,
            LayoutDirection,
            RedStatePath,
            FilterHealthState,
            Layers,
            ShowNonContainment,
            ExportToVisio,
            ExportToImage,
            Legend
        }

        #endregion

        #region "Properties"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the controls
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        public ViewToolbar Controls
        {
            get
            {
                return this;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the diagram controls
        /// </summary>
        /// <history>
        /// 	[kellymor] 	23SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        public IDiagramViewToolbar DiagramControls
        {
            get
            {
                return this;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the alert view controls
        /// </summary>
        /// <history>
        /// 	[kellymor] 	23SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        public IAlertViewToolbar AlertControls
        {
            get
            {
                return this;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the view controls
        /// </summary>
        /// <history>
        /// 	[ruhim] 	11SEP06	Created
        /// </history>
        /// ------------------------------------------------------------------
        public IViewToolbar ViewControls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region "IDiagramViewToolbar Implementation"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the SaveView Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	17JUL07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.SaveViewToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Save);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Print Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.PrintToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Print);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Print Preview Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.PrintPreviewToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.PrintPreview);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Find Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.FindToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Find);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the ZoomIn Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.ZoomInToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.ZoomIn);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the ZoomOut Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.ZoomOutToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.ZoomOut);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the ZoomComboBox Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.ZoomComboBox
        {
            get
            {
                return this.ToolbarItems[(int)DiagramViewToolbarButtons.ZoomLevel];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the FitToSpace Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.FitToSpaceToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.FitToSpace);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Relayout Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.RelayoutToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Relayout);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Autolayout Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	17JUL07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.AutolayoutToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Autolayout);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Overview Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.OverviewToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Overview);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Layout Direction Menu Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.LayoutDirectionMenuToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.LayoutDirection);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Red State Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.RedStatePathToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.ProblemPath);
                return this.ToolbarItems[index];
            }
        }
        //[v-lileo]Temporary workaround for Problem path button, bug#172466
        Button IDiagramViewToolbar.ProblemPath
        {
            get
            {
                ToolbarItems[0].Click();
                Button redStatePath = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA, VisibleOnly]Name = 'Problem Path' && Role = 'push button'"), 6000);
                return redStatePath;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Filter Health State Menu Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.FilterHealthStateMenuToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.FilterByHealth);
                return this.ToolbarItems[index];
                
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Layers Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.LayersToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Layers);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the ShowNonContainment Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.ShowNonContainmentToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.ShowNonContainment);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Export to Visio Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	17JUL07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.ExportToVisioToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.ToVisio);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Export to Image Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09APR07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.ExportToImageToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.ToImage);
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Legend Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IDiagramViewToolbar.LegendToolbarItem
        {
            get
            {
                int index = GetToolbarItemIndex(Strings.DiagramToolbarItems.Legend);
                return this.ToolbarItems[index];
            }
        }

        #endregion

        #region "IAlertViewToolbar Implementation"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the ZoomComboBox Toolbar item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	08SEP05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IAlertViewToolbar.ResloveButtonToolbarItem
        {
            get
            {
                return this.ToolbarItems[0];
            }
        }

        #endregion // "IAlertViewToolbar Implementation"

        #region "IViewToolbar Implementation"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Overrides Toolbar item
        /// </summary>
        /// <history>
        /// 	[ruhim] 	11SEP06	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IViewToolbar.OverridesButtonToolbarItem
        {
            get
            {
                int index = 0;
                Core.Common.Utilities.LogMessage("Toolbar Items Count: " + this.ToolbarItems.Count.ToString());
                while (index < this.ToolbarItems.Count)                    
                {
                    Core.Common.Utilities.LogMessage("Toolbar Text: " + this.ToolbarItems[index].Text);                    
                    if (string.Compare(this.ToolbarItems[index].Text, Overrides.Overrides.Strings.OverridesButton) == 0)
                    {
                        break;
                    }
                    index++;
                }
                return this.ToolbarItems[index];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Toolbar Options item
        /// </summary>
        /// <history>
        /// 	[kellymor] 	09AUG07	Created
        /// </history>
        /// ------------------------------------------------------------------
        ActiveAccessibility IViewToolbar.ToolbarOptions
        {
            get
            {
                return this.AccessibleObject.Children[Strings.ToolbarMenus.ToolbarOptions, 0];
            }
        }

        #endregion // "IViewToolbar Implementation"

        #region "IDiagramViewToolbar Public Methods"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click SaveView Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickSaveView()
        {
            this.DiagramControls.SaveViewToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Print Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickPrint()
        {
            this.DiagramControls.PrintToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Print Preview Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickPrintPreview()
        {
            this.DiagramControls.PrintPreviewToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Find Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickFind()
        {
            this.DiagramControls.FindToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click ZoomIn Toolbar button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickZoomIn()
        {
            this.DiagramControls.ZoomInToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click ZoomOut Toolbar button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickZoomOut()
        {
            this.DiagramControls.ZoomOutToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Toolbar Text Field
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickZoom()
        {
            this.DiagramControls.ZoomComboBox.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Toolbar Dropdown Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickZoomDropDown()
        {
            this.DiagramControls.ZoomComboBox.ClickDropdown();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click FitToSpace Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickFitToSpace()
        {
            this.DiagramControls.FitToSpaceToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Relayout Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickRelayout()
        {
            // TODO:  Refactor this code to all a common click method

            Maui.Core.WinControls.ToolbarItem relayout =
                this.DiagramControls.RelayoutToolbarItem;

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of RelayoutMenuMenuToolbarItem '" + relayout.ScreenElement.State.ToLowerInvariant() + "'");
            if (relayout.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                relayout.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.Relayout);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Autolayout Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickAutolayout()
        {
            // TODO:  Refactor this code to all a common click method

            Maui.Core.WinControls.ToolbarItem autolayout =
                this.DiagramControls.AutolayoutToolbarItem;

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of AutolayoutMenuMenuToolbarItem '" + autolayout.ScreenElement.State.ToLowerInvariant() + "'");
            if (autolayout.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                autolayout.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.Autolayout);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Overview Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickOverview()
        {
            // TODO:  Refactor this code to all a common click method

            //Maui.Core.WinControls.ToolbarItem overview =
            //    this.DiagramControls.OverviewToolbarItem;

            // workaroud for BUG 172466, click the dropdown arrow first to show all hidden toolbar items, and then click the expected toolbar item button
            this.ToolbarItems[0].Click();
            //Add a slight wait for dropdown animation finish
            Maui.Core.Utilities.Sleeper.Delay(Common.Constants.OneSecond);
            Button overview = new Button(
                CoreManager.MomConsole.MainWindow,
                new QID(";[UIA]Name = '" + Strings.DiagramToolbarItems.Overview + "' && Role = 'push button'"),
                ConsoleConstants.DefaultControlTimeout);

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of OverviewMenuMenuToolbarItem '" + overview.ScreenElement.State.ToLowerInvariant() + "'");
            if (overview.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                overview.Click();
                //close the dropdown list to avoid any potential issues that might happen, and in this case the list won't be closed until it's clicked twice
                this.ToolbarItems[0].Click(MouseClickType.DoubleClick);
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                //ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.Overview);

                this.ToolbarItems[0].Click();
                overview.Click();
                //close the dropdown list to avoid any potential issues that might happen, and in this case the list won't be closed until it's clicked twice
                this.ToolbarItems[0].Click(MouseClickType.DoubleClick);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Layout Direction Menu Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickLayoutDirectionMenu()
        {
            // TODO:  Refactor this code to all a common click method

            Maui.Core.WinControls.ToolbarItem layoutDirectionMenu =
                this.DiagramControls.LayoutDirectionMenuToolbarItem;

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of LayoutDirectionMenuMenuToolbarItem '" + layoutDirectionMenu.ScreenElement.State.ToLowerInvariant() + "'");
            if (layoutDirectionMenu.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                layoutDirectionMenu.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.LayoutDirection);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click RedStatePath Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickRedStatePath()
        {
            // TODO:  Refactor this code to all a common click method

            //Maui.Core.WinControls.ToolbarItem redStatePath =
            //    this.DiagramControls.RedStatePathToolbarItem;

            //[v-lileo]Temporary workaround for click Problem path button, bug#172466
            ToolbarItems[0].Click();
            Button redStatePath = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA, VisibleOnly]Name = 'Problem Path' && Role = 'push button'"), 6000);
            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of RedStatePathMenuToolbarItem '" + redStatePath.ScreenElement.State.ToLowerInvariant() + "'");
            if (redStatePath.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                redStatePath.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                //ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.ProblemPath);

                //[v-lileo]Temporary workaround for click FilterByHealth button, bug#172466
                ToolbarItems[0].Click();
                redStatePath.Click();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Filter Health State Menu Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickFilterHealthStateMenu()
        {
            // TODO:  Refactor this code to all a common click method
            
            //Maui.Core.WinControls.ToolbarItem filterHealthState =
            //    this.DiagramControls.FilterHealthStateMenuToolbarItem;

            //[v-lileo]Temporary workaround for click FilterByHealth button, bug#172466
            ToolbarItems[0].Click();
            //Add a slight wait for dropdown animation finish
            Maui.Core.Utilities.Sleeper.Delay(Common.Constants.OneSecond);
            Button filterHealthState = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA, VisibleOnly]Name = 'Filter by health' && Role = 'push button'"),6000);

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of FilterHealthStateMenuToolbarItem '" + filterHealthState.ScreenElement.State.ToLowerInvariant() + "'");
            if (filterHealthState.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                filterHealthState.Click();
            }
            else
            {
                //// the control is not visible and must be made visible and then clicked.
                //ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.FilterByHealth);

                //[v-lileo]Temporary workaround for click FilterByHealth button, bug#172466
                ToolbarItems[0].Click();
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(filterHealthState, 60);
                filterHealthState.Click();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Layers Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickLayers()
        {
            // TODO:  Refactor this code to all a common click method

            Maui.Core.WinControls.ToolbarItem layers =
                this.DiagramControls.LayersToolbarItem;

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of LayersMenuToolbarItem '" + layers.ScreenElement.State.ToLowerInvariant() + "'");
            if (layers.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                layers.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.Layers);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Show NonContainment Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickShowNonContainment()
        {
            Maui.Core.WinControls.ToolbarItem showNonContainment =
                this.DiagramControls.ShowNonContainmentToolbarItem;

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of ShowNonContainmentMenuToolbarItem '" + showNonContainment.ScreenElement.State.ToLowerInvariant() + "'");
            if (showNonContainment.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                showNonContainment.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.ShowNonContainment);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Export to Visio Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickExportToVisio()
        {
            //Maui.Core.WinControls.ToolbarItem exportToVisio =
            //    this.DiagramControls.ExportToVisioToolbarItem;

            //[v-lileo]Temporary workaround for click exportToVisio button, bug#172466
            ToolbarItems[0].Click();
            //Add a slight wait for dropdown animation finish
            Maui.Core.Utilities.Sleeper.Delay(Common.Constants.OneSecond);
            Button exportToVisio = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA, VisibleOnly]Name = 'To Visio' && Role = 'push button'"), 6000);
            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of ExportToVisioMenuToolbarItem '" + exportToVisio.ScreenElement.State.ToLowerInvariant() + "'");
            if (exportToVisio.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                exportToVisio.Click();
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                //ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.ToVisio);

                //[v-lileo]Temporary workaround for click exportToVisio button, bug#172466
                ToolbarItems[0].Click();
                exportToVisio.Click();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Export to Image Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickExportToImage()
        {
            //Maui.Core.WinControls.ToolbarItem exportToImage =
            //    this.DiagramControls.ExportToImageToolbarItem;

            //[v-lileo]Temporary workaround for click exportToImage button, bug#172466
            ToolbarItems[0].Click();
            //Add a slight wait for dropdown animation finish
            Maui.Core.Utilities.Sleeper.Delay(Common.Constants.OneSecond);
            Button exportToImage = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA, VisibleOnly]Name = 'To Image' && Role = 'push button'"), 6000);

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of ExportToImageMenuToolbarItem '" + exportToImage.ScreenElement.State.ToLowerInvariant() + "'");
            if (exportToImage.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                exportToImage.SendKeys(Mom.Test.UI.Core.Common.KeyboardCodes.Enter);
                
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                //ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.ToImage);

                //[v-lileo]Temporary workaround for click exportToImage button, bug#172466
                ToolbarItems[0].Click();
                exportToImage.Click();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Legend Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickLegend()
        {
            //Maui.Core.WinControls.ToolbarItem legend =
            //    this.DiagramControls.LegendToolbarItem;

            // workaroud for BUG 172466, click the dropdown arrow first to show all hidden toolbar items, and then click the expected toolbar item button
            this.ToolbarItems[0].Click();
            //Add a slight wait for dropdown animation finish
            Maui.Core.Utilities.Sleeper.Delay(Common.Constants.OneSecond);
            Button legend = new Button(
                CoreManager.MomConsole.MainWindow,
                new QID(";[UIA]Name = '" + Strings.DiagramToolbarItems.Legend + "' && Role = 'push button'"),
                ConsoleConstants.DefaultControlTimeout);

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: State of LegendMenuToolbarItem '" + legend.ScreenElement.State.ToLowerInvariant() + "'");
            if (legend.ScreenElement.State.ToLowerInvariant().Contains("invisible") == false)
            {
                //the toolbar item is visible and hence is safe to click.
                legend.Click();
                //close the dropdown list to avoid any potential issues that might happen, and in this case the list won't be closed until it's clicked twice
                this.ToolbarItems[0].Click(MouseClickType.DoubleClick);
            }
            else
            {
                // the control is not visible and must be made visible and then clicked.
                //ClickItemHiddenByOptionsMenu(Strings.DiagramToolbarItems.Legend);

                this.ToolbarItems[0].Click();
                legend.Click();
                //close the dropdown list to avoid any potential issues that might happen, and in this case the list won't be closed until it's clicked twice
                this.ToolbarItems[0].Click(MouseClickType.DoubleClick);
            }
        }

        #endregion

        #region "IAlertViewToolbar Public Methods"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Zoom Toolbar Text Field
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickReslove()
        {
            this.AlertControls.ResloveButtonToolbarItem.Click();
        }

        #endregion // "IAlertViewToolbar Public Methods"

        #region "IViewToolbar Public Methods"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Clicks Overrides Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickOverrides()
        {
            this.ViewControls.OverridesButtonToolbarItem.AccessibleObject.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click the options menu
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickOptionsMenu() 
        {
            this.ViewControls.ToolbarOptions.Click();
        }

        #endregion // "IViewToolbar Public Methods"

        #region "IViewToolbar Private Methods"

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to click a toolbar item by name.  This method checks to see
        /// if the current toolbar name matches the expected name.  If not,
        /// the method calls another method to find and click the hidden 
        /// toolbar item.
        /// </summary>
        /// <param name="currentToolbarItemName">
        /// Text name of the current toolbar item
        /// </param>
        /// <param name="expectedToolbarItemName">
        /// Text name of the expected toolbar item
        /// </param>
        /// ------------------------------------------------------------------
        private void ClickToolBarItem(
            string currentToolbarItemName, 
            string expectedToolbarItemName)
        {
            
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to click a toolbar item that has been hidden under the 
        /// Toolbar Options menu.
        /// </summary>
        /// <param name="hiddenToolbarItemName">
        /// Text name of the item to be clicked
        /// </param>
        /// ------------------------------------------------------------------
        private void ClickItemHiddenByOptionsMenu(string hiddenToolbarItemName)
        {
            // check for valid value
            if (false == String.IsNullOrEmpty(hiddenToolbarItemName))
            {
                // strip any hot-keys
                hiddenToolbarItemName = 
                    Core.Common.Utilities.RemoveAcceleratorKeys(
                        hiddenToolbarItemName);
            }
            else
            {
                throw new System.NullReferenceException(
                    "Parameter cannot be null or empty string!");
            }

            ClickToolbarItem(Strings.ToolbarMenus.ToolbarOptions);
            ClickToolbarItem(hiddenToolbarItemName);
        }

        /// <summary>
        /// This method finds the toolbar item and clicks it.
        /// </summary>
        /// <param name="toolbarItem">Name of the item to be clicked</param>
        private void ClickToolbarItem(string toolbarItem)
        {
            Core.Common.Utilities.LogMessage("ClickToolbarItem:: Looking for '" + toolbarItem + "'");

            int index = GetToolbarItemIndex(toolbarItem);

            if (index == -1)
            {
                throw new Maui.GlobalExceptions.MauiException(
                    "ClickToolbarItem:: Failed to find '" + toolbarItem + "' button!");
            }

            ToolbarItem toolbarOptionsItem = this.ToolbarItems[index];

            if (toolbarOptionsItem == null)
            {
                throw new Maui.GlobalExceptions.MauiException(
                    "ClickToolbarItem:: Failed to find '" + toolbarItem + "' button!");
            }

            Core.Common.Utilities.LogMessage("ClickToolbarItem:: Clicking '" + toolbarItem + "'");

            toolbarOptionsItem.Click();
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to get a toolbar button by matching toolbar item text
        /// </summary>
        /// <param name="toolbarItemText">
        /// Toolbar item text to match against.
        /// </param>
        /// <returns>
        /// An integer representing the index in the toolbar item collection
        /// of the toolbar item with the specified tooltip text
        /// </returns>
        /// ------------------------------------------------------------------
        private int GetToolbarItemIndex(string toolbarItemText)
        {
            // set the range
            int index = 0;
            int upperBound = this.ToolbarItems.Count;

            Core.Common.Utilities.LogMessage(
                "GetToolbarItemIndex::Toolbar Items Count: " + 
                upperBound.ToString());
            
            // remove any hot-keys
            toolbarItemText =
                Core.Common.Utilities.RemoveAcceleratorKeys(toolbarItemText);

            // loop through the existing toolbar items
            for (index = 0; index < upperBound; index++)
            {
                // get the current tool bar item's text
                string currentToolbarItemText =
                    this.ToolbarItems[index].Text;

                Core.Common.Utilities.LogMessage(
                    "GetToolbarItemIndexToolbar::Text @ index = " +
                    index + 
                    " : '" +
                    currentToolbarItemText + 
                    "'");

                // match toolbar item tooltip with tooltip text passed in
                if (null != currentToolbarItemText &&
                    toolbarItemText.ToLowerInvariant().Equals(
                        currentToolbarItemText.ToLowerInvariant()))
                {
                    Core.Common.Utilities.LogMessage(
                        "GetToolbarItemIndex::Found match, '" +
                        currentToolbarItemText + 
                        "', @ index = : " + 
                        index);

                    // found a match
                    break;
                }
            }

            Core.Common.Utilities.LogMessage(
                    "GetToolbarItemIndex::Checking for toolbar options button...");

            // check for index equaling upper bound
            if (upperBound == index)
            {
                Core.Common.Utilities.LogMessage(
                        "GetToolbarItemIndex::Last visible toolbar text := '" +
                        this.ToolbarItems[(upperBound - 1)].Text +
                        "'");

                // check to see if the toolbar options button is the last button
                if (this.ToolbarItems[(upperBound - 1)].Text.ToLowerInvariant().Equals(
                        Strings.ToolbarMenus.ToolbarOptions.ToLowerInvariant()))
                {
                    // return the index of the toolbar options button
                    index = (upperBound - 1);
                }
                else
                {
                    // the item does not exist in this collection
                    index = -1;
                }
            }

            Core.Common.Utilities.LogMessage(
                "GetToolbarItemIndex::Returning index := " +
                index);

            return index;
        }

        #endregion

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to hold strings related to toolbar menu items
        /// </summary>
        /// <history>
        ///     [kellymor]  09APR07 Created
        ///     [kellymor]  09AUG07 Added classes for diagram toolbar item
        ///                         tooltips and toolbar options menu
        ///     [kellymor]  06AUG08 Added class for diagram toolbar item text
        /// </history>
        /// -------------------------------------------------------------------
        public class Strings
        {
            /// ---------------------------------------------------------------
            /// <summary>
            /// Class to hold strings for diagram toolbar menus
            /// </summary>
            /// ---------------------------------------------------------------
            public class DiagramMenus
            {
                #region Constants

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold North South layout menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceNorthSouth = 
                    ";North South" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";NorthSouthText";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold South North layout menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceSouthNorth =
                    ";South North" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";SouthNorthText";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold East West layout menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceEastWest =
                    ";East West" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";EastWestText";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold West East layout menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceWestEast =
                    ";West East" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";WestEastText";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "All" health state menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceAllHealthStates =
                    ";All" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";AllHealthText";
                
                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "Red" health state menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceRedHealthState =
                    ";Red" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";RedHealthText";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "Green" health state menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceGreenHealthState =
                    ";Green" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";GreenHealthText";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "Yellow" health state menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceYellowHealthState =
                    ";Yellow" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";YellowHealthText";
                
                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "Unknown" health state menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceUnknownHealthState =
                    ";Unknown" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";GrayHealthText";
                
                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "All" layers menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceAllLayers = "";

                /// -----------------------------------------------------------
                /// <summary>
                /// Constant to hold "Default" layer menu resource
                /// </summary>
                /// -----------------------------------------------------------
                private const string ResourceDefaultLayer = "";

                #endregion

                #region Private Members

                /// <summary>
                /// holds the translated resource string for North South menu
                /// </summary>
                private static string cachedNorthSouth;

                /// <summary>
                /// holds the translated resource string for South North menu
                /// </summary>
                private static string cachedSouthNorth;

                /// <summary>
                /// holds the translated resource string for East West menu
                /// </summary>
                private static string cachedEastWest;

                /// <summary>
                /// holds the translated resource string for West East menu
                /// </summary>
                private static string cachedWestEast;

                /// <summary>
                /// holds the translated resource string for "All" health states menu
                /// </summary>
                private static string cachedAllHealthStates;

                /// <summary>
                /// holds the translated resource string for "Red" health state menu
                /// </summary>
                private static string cachedRedHealthState;

                /// <summary>
                /// holds the translated resource string for "Green" health state menu
                /// </summary>
                private static string cachedGreenHealthState;

                /// <summary>
                /// holds the translated resource string for "Yellow" health state menu
                /// </summary>
                private static string cachedYellowHealthState;

                /// <summary>
                /// holds the translated resource string for "Unknown" health state menu
                /// </summary>
                private static string cachedUnknownHealthState;

                /// <summary>
                /// holds the translated resource string for "All" layers menu
                /// </summary>
                private static string cachedAllLayers;

                /// <summary>
                /// holds the translated resource string for "Default" layer  menu
                /// </summary>
                private static string cachedDefaultLayer;
                
                #endregion

                #region Properties

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the NorthSouth layout menu item translated resource string
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string NorthSouth
                {
                    get
                    {
                        if ((cachedNorthSouth == null))
                        {
                            cachedNorthSouth = CoreManager.MomConsole.GetIntlStr(ResourceNorthSouth);
                        }

                        return cachedNorthSouth;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the SouthNorth layout menu item translated resource string
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string SouthNorth
                {
                    get
                    {
                        if ((cachedSouthNorth == null))
                        {
                            cachedSouthNorth = CoreManager.MomConsole.GetIntlStr(ResourceSouthNorth);
                        }

                        return cachedSouthNorth;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the EastWest layout menu item translated resource string
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string EastWest
                {
                    get
                    {
                        if ((cachedEastWest == null))
                        {
                            cachedEastWest = CoreManager.MomConsole.GetIntlStr(ResourceEastWest);
                        }

                        return cachedEastWest;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the WestEast layout menu item translated resource string
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string WestEast
                {
                    get
                    {
                        if ((cachedWestEast == null))
                        {
                            cachedWestEast = CoreManager.MomConsole.GetIntlStr(ResourceWestEast);
                        }

                        return cachedWestEast;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "All" health states filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string AllHealthStates
                {
                    get
                    {
                        if ((cachedAllHealthStates == null))
                        {
                            cachedAllHealthStates = CoreManager.MomConsole.GetIntlStr(ResourceAllHealthStates);
                        }

                        return cachedAllHealthStates;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "Red" health states filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string RedHealthState
                {
                    get
                    {
                        if ((cachedRedHealthState == null))
                        {
                            cachedRedHealthState = CoreManager.MomConsole.GetIntlStr(ResourceRedHealthState);
                        }

                        return cachedRedHealthState;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "Green" health states filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string GreenHealthState
                {
                    get
                    {
                        if ((cachedGreenHealthState == null))
                        {
                            cachedGreenHealthState = CoreManager.MomConsole.GetIntlStr(ResourceGreenHealthState);
                        }

                        return cachedGreenHealthState;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "Yellow" health states filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string YellowHealthState
                {
                    get
                    {
                        if ((cachedYellowHealthState == null))
                        {
                            cachedYellowHealthState = CoreManager.MomConsole.GetIntlStr(ResourceYellowHealthState);
                        }

                        return cachedYellowHealthState;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "Unknown" health states filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string UnknownHealthState
                {
                    get
                    {
                        if ((cachedUnknownHealthState == null))
                        {
                            cachedUnknownHealthState = CoreManager.MomConsole.GetIntlStr(ResourceUnknownHealthState);
                        }

                        return cachedUnknownHealthState;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "All" layers filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string AllLayers
                {
                    get
                    {
                        if ((cachedAllLayers == null))
                        {
                            cachedAllLayers = CoreManager.MomConsole.GetIntlStr(ResourceAllLayers);
                        }

                        return cachedAllLayers;
                    }
                }

                /// -----------------------------------------------------------------------------
                /// <summary>
                /// Exposes access to the "Default" layer filter menu item translated 
                /// resource string.
                /// </summary>
                /// <history>
                /// 	[kellymor] 09APR07 Created
                /// </history>
                /// -----------------------------------------------------------------------------
                public static string DefaultLayer
                {
                    get
                    {
                        if ((cachedDefaultLayer == null))
                        {
                            cachedDefaultLayer = CoreManager.MomConsole.GetIntlStr(ResourceDefaultLayer);
                        }

                        return cachedDefaultLayer;
                    }
                }

                #endregion
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Class to contain diagram toolbar item tooltip text
            /// </summary>
            /// ---------------------------------------------------------------
            public class DiagramTooltips
            {
                #region Constants

                /// <summary>
                /// Save tooltip text
                /// </summary>
                private const string ResourceSave = 
                    ";Save" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";SaveTooltip";

                /// <summary>
                /// Print tooltip text
                /// </summary>
                private const string ResourcePrint =
                    ";Print" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";PrintTooltip";

                /// <summary>
                /// Print Preview tooltip text
                /// </summary>
                private const string ResourcePrintPreview =
                    ";Print Preview" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";PrintPreviewTooltip";

                /// <summary>
                /// Find tooltip text
                /// </summary>
                private const string ResourceFind =
                    ";Find" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FindTooltip";

                /// <summary>
                /// Zoom in tooltip text
                /// </summary>
                private const string ResourceZoomIn =
                    ";Zoom in (Ctrl +)" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ZoomInTooltip";

                /// <summary>
                /// Zoom out tooltip text
                /// </summary>
                private const string ResourceZoomOut =
                    ";Zoom out (Ctrl -)" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ZoomOutTooltip";

                /// <summary>
                /// Fit to space tooltip text
                /// </summary>
                private const string ResourceFitToSpace =
                    ";Fit to space" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FitToSpaceTooltip";

                /// <summary>
                /// Relayout tooltip text
                /// </summary>
                private const string ResourceRelayout =
                    ";Relayout" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";RelayoutTooltip";

                /// <summary>
                /// Autolayout tooltip text
                /// </summary>
                private const string ResourceAutolayout =
                    ";Autolayout" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";AutolayoutTooltip";

                /// <summary>
                /// Overview tooltip text
                /// </summary>
                private const string ResourceOverview =
                    ";Overview" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";PanAndZoomTooltip";

                /// <summary>
                /// Layout direction tooltip text
                /// </summary>
                private const string ResourceLayoutDirection =
                    ";Layout direction" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";LayoutDirectionTooltip";
                
                /// <summary>
                /// Problem path tooltip text
                /// </summary>
                private const string ResourceProblemPath =
                    ";Problem Path" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ProblemPathTooltip";

                /// <summary>
                /// Filter by health tooltip text
                /// </summary>
                private const string ResourceFilterByHealth =
                    ";Filter by health" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FilterByHealthTooltip";

                /// <summary>
                /// Layers tooltip text
                /// </summary>
                private const string ResourceLayers =
                    ";Layers" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FilterByLayerTooltip";

                /// <summary>
                /// Show non-containment relations tooltip text
                /// </summary>
                private const string ResourceShowNonContainment =
                    ";Show non-containment relations" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";NonContainmentsTooltip";

                /// <summary>
                /// To Visio tooltip text
                /// </summary>
                private const string ResourceToVisio =
                    ";To Visio" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ExportToVisioTooltip";

                /// <summary>
                /// To Image tooltip text
                /// </summary>
                private const string ResourceToImage =
                    ";To Image" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ExportToImageTooltip";

                /// <summary>
                /// Legend tooltip text
                /// </summary>
                private const string ResourceLegend =
                    ";Legend" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";LegendTooltip";

                #endregion // Constants

                #region Private Members

                /// <summary>
                /// Save cached resource string
                /// </summary>
                private static string cachedSave;

                /// <summary>
                /// Print cached resource string
                /// </summary>
                private static string cachedPrint;

                /// <summary>
                /// Print Preview cached resource string
                /// </summary>
                private static string cachedPrintPreview;

                /// <summary>
                /// Find cached resource string
                /// </summary>
                private static string cachedFind;

                /// <summary>
                /// Zoom In cached resource string
                /// </summary>
                private static string cachedZoomIn;

                /// <summary>
                /// Zoom Out cached resource string
                /// </summary>
                private static string cachedZoomOut;

                /// <summary>
                /// Fit To Space cached resource string
                /// </summary>
                private static string cachedFitToSpace;

                /// <summary>
                /// Relayout cached resource string
                /// </summary>
                private static string cachedRelayout;

                /// <summary>
                /// Autolayout cached resource string
                /// </summary>
                private static string cachedAutolayout;

                /// <summary>
                /// Overview cached resource string
                /// </summary>
                private static string cachedOverview;

                /// <summary>
                /// Layout Direction cached resource string
                /// </summary>
                private static string cachedLayoutDirection;

                /// <summary>
                /// Problem Path cached resource string
                /// </summary>
                private static string cachedProblemPath;

                /// <summary>
                /// Filter By Health cached resource string
                /// </summary>
                private static string cachedFilterByHealth;

                /// <summary>
                /// Layers cached resource string
                /// </summary>
                private static string cachedLayers;

                /// <summary>
                /// Show Non-Containment cached resource string
                /// </summary>
                private static string cachedShowNonContainment;

                /// <summary>
                /// To Visio cached resource string
                /// </summary>
                private static string cachedToVisio;

                /// <summary>
                /// To Image cached resource string
                /// </summary>
                private static string cachedToImage;

                /// <summary>
                /// Legend cached resource string
                /// </summary>
                private static string cachedLegend;

                #endregion // Private Members

                #region Properties

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Save"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Save
                {
                    get
                    {
                        if (null == cachedSave)
                        {
                            cachedSave = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceSave);
                        }
                        return cachedSave;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Print"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Print
                {
                    get
                    {
                        if (null == cachedPrint)
                        {
                            cachedPrint = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourcePrint);
                        }
                        return cachedPrint;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "PrintPreview"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string PrintPreview
                {
                    get
                    {
                        if (null == cachedPrintPreview)
                        {
                            cachedPrintPreview = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourcePrintPreview);
                        }
                        return cachedPrintPreview;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Find"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Find
                {
                    get
                    {
                        if (null == cachedFind)
                        {
                            cachedFind = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceFind);
                        }
                        return cachedFind;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ZoomIn"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ZoomIn
                {
                    get
                    {
                        if (null == cachedZoomIn)
                        {
                            cachedZoomIn = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceZoomIn);
                        }
                        return cachedZoomIn;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ZoomOut"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ZoomOut
                {
                    get
                    {
                        if (null == cachedZoomOut)
                        {
                            cachedZoomOut = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceZoomOut);
                        }
                        return cachedZoomOut;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "FitToSpace"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string FitToSpace
                {
                    get
                    {
                        if (null == cachedFitToSpace)
                        {
                            cachedFitToSpace = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceFitToSpace);
                        }
                        return cachedFitToSpace;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Relayout"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Relayout
                {
                    get
                    {
                        if (null == cachedRelayout)
                        {
                            cachedRelayout = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceRelayout);
                        }
                        return cachedRelayout;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Autolayout"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Autolayout
                {
                    get
                    {
                        if (null == cachedAutolayout)
                        {
                            cachedAutolayout = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceAutolayout);
                        }
                        return cachedAutolayout;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Overview"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Overview
                {
                    get
                    {
                        if (null == cachedOverview)
                        {
                            cachedOverview = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceOverview);
                        }
                        return cachedOverview;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "LayoutDirection"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string LayoutDirection
                {
                    get
                    {
                        if (null == cachedLayoutDirection)
                        {
                            cachedLayoutDirection = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceLayoutDirection);
                        }
                        return cachedLayoutDirection;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ProblemPath"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ProblemPath
                {
                    get
                    {
                        if (null == cachedProblemPath)
                        {
                            cachedProblemPath = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceProblemPath);
                        }
                        return cachedProblemPath;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "FilterByHealth"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string FilterByHealth
                {
                    get
                    {
                        if (null == cachedFilterByHealth)
                        {
                            cachedFilterByHealth = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceFilterByHealth);
                        }
                        return cachedFilterByHealth;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Layers"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Layers
                {
                    get
                    {
                        if (null == cachedLayers)
                        {
                            cachedLayers = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceLayers);
                        }
                        return cachedLayers;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ShowNonContainment"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ShowNonContainment
                {
                    get
                    {
                        if (null == cachedShowNonContainment)
                        {
                            cachedShowNonContainment = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceShowNonContainment);
                        }
                        return cachedShowNonContainment;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ToVisio"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ToVisio
                {
                    get
                    {
                        if (null == cachedToVisio)
                        {
                            cachedToVisio = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceToVisio);
                        }
                        return cachedToVisio;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ToImage"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ToImage
                {
                    get
                    {
                        if (null == cachedToImage)
                        {
                            cachedToImage = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceToImage);
                        }
                        return cachedToImage;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Legend"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Legend
                {
                    get
                    {
                        if (null == cachedLegend)
                        {
                            cachedLegend = 
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceLegend);
                        }
                        return cachedLegend;
                    }
                }

                #endregion // Properties
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Class to contain diagram toolbar item text
            /// </summary>
            /// ---------------------------------------------------------------
            public class DiagramToolbarItems
            {
                #region Constants

                /// <summary>
                /// Save tooltip text
                /// </summary>
                private const string ResourceSave =
                    ";Save" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";SaveText";

                /// <summary>
                /// Print tooltip text
                /// </summary>
                private const string ResourcePrint =
                    ";Print" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";PrintText";

                /// <summary>
                /// Print Preview tooltip text
                /// </summary>
                private const string ResourcePrintPreview =
                    ";Print Preview" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";PrintPreviewText";

                /// <summary>
                /// Find tooltip text
                /// </summary>
                private const string ResourceFind =
                    ";Find" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FindText";

                /// <summary>
                /// Zoom in tooltip text
                /// </summary>
                private const string ResourceZoomIn =
                    ";Zoom in" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ZoomInText";

                /// <summary>
                /// Zoom out tooltip text
                /// </summary>
                private const string ResourceZoomOut =
                    ";Zoom out" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ZoomOutText";

                /// <summary>
                /// Fit to space tooltip text
                /// </summary>
                private const string ResourceFitToSpace =
                    ";Fit to space" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FitToSpaceText";

                //private const string ResourceFitToSpace = ";Fit to space;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources.en;FitToSpaceTooltip";

                /// <summary>
                /// Relayout tooltip text
                /// </summary>
                private const string ResourceRelayout =
                    ";Relayout" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";RelayoutText";

                /// <summary>
                /// Autolayout tooltip text
                /// </summary>
                private const string ResourceAutolayout =
                    ";Autolayout" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";AutolayoutText";

                /// <summary>
                /// Overview tooltip text
                /// </summary>
                private const string ResourceOverview =
                    ";Overview" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";PanAndZoomText";

                /// <summary>
                /// Layout direction tooltip text
                /// </summary>
                private const string ResourceLayoutDirection =
                    ";Layout direction" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";LayoutDirectionText";

                /// <summary>
                /// Problem path tooltip text
                /// </summary>
                private const string ResourceProblemPath =
                    ";Problem path" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ProblemPathText";

                /// <summary>
                /// Filter by health tooltip text
                /// </summary>
                private const string ResourceFilterByHealth =
                    ";Filter by health" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FilterByHealthText";

                /// <summary>
                /// Layers tooltip text
                /// </summary>
                private const string ResourceLayers =
                    ";Layers" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";FilterByLayerText";

                /// <summary>
                /// Show non-containment relations tooltip text
                /// </summary>
                private const string ResourceShowNonContainment =
                    ";Non-containment relations" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";NonContainmentsText";

                /// <summary>
                /// To Visio tooltip text
                /// </summary>
                private const string ResourceToVisio =
                    ";To Visio" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ExportToVisioText";

                /// <summary>
                /// To Image tooltip text
                /// </summary>
                private const string ResourceToImage =
                    ";To Image" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";ExportToImageText";

                /// <summary>
                /// Legend tooltip text
                /// </summary>
                private const string ResourceLegend =
                    ";Legend" +
                    ";ManagedString" +
                    ";Microsoft.MOM.UI.Components.dll" +
                    ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                    ";LegendText";

                #endregion // Constants

                #region Private Members

                /// <summary>
                /// Save cached resource string
                /// </summary>
                private static string cachedSave;

                /// <summary>
                /// Print cached resource string
                /// </summary>
                private static string cachedPrint;

                /// <summary>
                /// Print Preview cached resource string
                /// </summary>
                private static string cachedPrintPreview;

                /// <summary>
                /// Find cached resource string
                /// </summary>
                private static string cachedFind;

                /// <summary>
                /// Zoom In cached resource string
                /// </summary>
                private static string cachedZoomIn;

                /// <summary>
                /// Zoom Out cached resource string
                /// </summary>
                private static string cachedZoomOut;

                /// <summary>
                /// Fit To Space cached resource string
                /// </summary>
                private static string cachedFitToSpace;

                /// <summary>
                /// Relayout cached resource string
                /// </summary>
                private static string cachedRelayout;

                /// <summary>
                /// Autolayout cached resource string
                /// </summary>
                private static string cachedAutolayout;

                /// <summary>
                /// Overview cached resource string
                /// </summary>
                private static string cachedOverview;

                /// <summary>
                /// Layout Direction cached resource string
                /// </summary>
                private static string cachedLayoutDirection;

                /// <summary>
                /// Problem Path cached resource string
                /// </summary>
                private static string cachedProblemPath;

                /// <summary>
                /// Filter By Health cached resource string
                /// </summary>
                private static string cachedFilterByHealth;

                /// <summary>
                /// Layers cached resource string
                /// </summary>
                private static string cachedLayers;

                /// <summary>
                /// Show Non-Containment cached resource string
                /// </summary>
                private static string cachedShowNonContainment;

                /// <summary>
                /// To Visio cached resource string
                /// </summary>
                private static string cachedToVisio;

                /// <summary>
                /// To Image cached resource string
                /// </summary>
                private static string cachedToImage;

                /// <summary>
                /// Legend cached resource string
                /// </summary>
                private static string cachedLegend;

                #endregion // Private Members

                #region Properties

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Save"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Save
                {
                    get
                    {
                        if (null == cachedSave)
                        {
                            cachedSave =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceSave);
                        }
                        return cachedSave;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Print"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Print
                {
                    get
                    {
                        if (null == cachedPrint)
                        {
                            cachedPrint =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourcePrint);
                        }
                        return cachedPrint;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "PrintPreview"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string PrintPreview
                {
                    get
                    {
                        if (null == cachedPrintPreview)
                        {
                            cachedPrintPreview =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourcePrintPreview);
                        }
                        return cachedPrintPreview;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Find"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Find
                {
                    get
                    {
                        if (null == cachedFind)
                        {
                            cachedFind =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceFind);
                        }
                        return cachedFind;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ZoomIn"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ZoomIn
                {
                    get
                    {
                        if (null == cachedZoomIn)
                        {
                            cachedZoomIn =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceZoomIn);
                        }
                        return cachedZoomIn;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ZoomOut"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ZoomOut
                {
                    get
                    {
                        if (null == cachedZoomOut)
                        {
                            cachedZoomOut =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceZoomOut);
                        }
                        return cachedZoomOut;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "FitToSpace"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string FitToSpace
                {
                    get
                    {
                        if (null == cachedFitToSpace)
                        {
                            cachedFitToSpace =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceFitToSpace);
                        }
                        return cachedFitToSpace;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Relayout"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Relayout
                {
                    get
                    {
                        if (null == cachedRelayout)
                        {
                            cachedRelayout =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceRelayout);
                        }
                        return cachedRelayout;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Autolayout"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Autolayout
                {
                    get
                    {
                        if (null == cachedAutolayout)
                        {
                            cachedAutolayout =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceAutolayout);
                        }
                        return cachedAutolayout;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Overview"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Overview
                {
                    get
                    {
                        if (null == cachedOverview)
                        {
                            cachedOverview =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceOverview);
                        }
                        return cachedOverview;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "LayoutDirection"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string LayoutDirection
                {
                    get
                    {
                        if (null == cachedLayoutDirection)
                        {
                            cachedLayoutDirection =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceLayoutDirection);
                        }
                        return cachedLayoutDirection;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ProblemPath"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ProblemPath
                {
                    get
                    {
                        if (null == cachedProblemPath)
                        {
                            cachedProblemPath =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceProblemPath);
                        }
                        return cachedProblemPath;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "FilterByHealth"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string FilterByHealth
                {
                    get
                    {
                        if (null == cachedFilterByHealth)
                        {
                            cachedFilterByHealth =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceFilterByHealth);
                        }
                        return cachedFilterByHealth;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Layers"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Layers
                {
                    get
                    {
                        if (null == cachedLayers)
                        {
                            cachedLayers =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceLayers);
                        }
                        return cachedLayers;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ShowNonContainment"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ShowNonContainment
                {
                    get
                    {
                        if (null == cachedShowNonContainment)
                        {
                            cachedShowNonContainment =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceShowNonContainment);
                        }
                        return cachedShowNonContainment;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ToVisio"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ToVisio
                {
                    get
                    {
                        if (null == cachedToVisio)
                        {
                            cachedToVisio =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceToVisio);
                        }
                        return cachedToVisio;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "ToImage"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ToImage
                {
                    get
                    {
                        if (null == cachedToImage)
                        {
                            cachedToImage =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceToImage);
                        }
                        return cachedToImage;
                    }
                }

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to return the translated resource for "Legend"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string Legend
                {
                    get
                    {
                        if (null == cachedLegend)
                        {
                            cachedLegend =
                                CoreManager.MomConsole.GetIntlStr(
                                    ResourceLegend);
                        }
                        return cachedLegend;
                    }
                }

                #endregion // Properties
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Class to hold strings for general toolbar menus
            /// </summary>
            /// ---------------------------------------------------------------
            public class ToolbarMenus
            {
                #region Constants

                private const string ResourceToolbarOptions = 
                    ";ToolBar Options" +
                    ";ManagedString" +
                    ";System.Windows.Forms.dll" + 
                    ";System.Windows.Forms" + 
                    ";ToolStripOptions";

                #endregion // Constants

                #region Private Members

                private static string cachedToolbarOptions;

                #endregion // Private Members

                #region Properties

                /// ---------------------------------------------------------------
                /// <summary>
                /// Property to get the translated string for "ToolBar Options"
                /// </summary>
                /// ---------------------------------------------------------------
                public static string ToolbarOptions
                {
                    get
                    {
                        if (null == cachedToolbarOptions)
                        {
                            cachedToolbarOptions = CoreManager.MomConsole.GetIntlStr(ResourceToolbarOptions);
                        }
                        return cachedToolbarOptions;
                    }
                }

                #endregion // Properties
            }
        }
    }
}
