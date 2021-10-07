namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;
    using Mom.Test.UI.Core.Console.MomControls.Nitro;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;

    /// <summary>
    /// This interface lists the controls in a DiagramView
    /// </summary>
    public interface IDiagramControlViewHost
    {
        /// <summary>
        /// The diagram control
        /// </summary>
        DiagramControl Diagram
        {
            get;
        }

        /// <summary>
        /// The tool bar for the diagram
        /// </summary>
        DiagramToolBar ToolBar
        {
            get;
        }
    }

    /// <summary>
    /// This class represents a view that has the diagram as the content
    /// </summary>
    public class DiagramControlViewHost : ViewHost, IDiagramControlViewHost
    {
        #region QIDs

        /// <summary>
        /// This is a list of default QIDs for the controls on the view
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the content
            /// </summary>
            public static QID ContentQID = new QID(";[UIA]ClassName = 'ComponentContainer'");

            /// <summary>
            /// QID for the diagram control
            /// </summary>
            public static QID DiagramControlQID = new QID(";[UIA]ClassName = 'ComponentContainer';[UIA]ClassName => 'VicinityDiagramControl'");

            /// <summary>
            /// QID for the toolbar
            /// </summary>
            public static QID ToolbarQID = new QID(";[UIA]ClassName = 'ComponentContainer';[UIA]ClassName = 'SimpleToolBar'");
        }

        /// <summary>
        /// Gets the QID for the content
        /// </summary>
        /// <returns>QID for the content</returns>
        protected override QID GetContentQID()
        {
            return ControlQIDs.ContentQID;
        }

        /// <summary>
        /// Gets the QID for the DiagramControl
        /// </summary>
        /// <returns>QID for the DiagramControl</returns>
        protected virtual QID GetDiagramControlQID()
        {
            return ControlQIDs.DiagramControlQID;
        }

        /// <summary>
        /// Gets the QID for the Toolbar
        /// </summary>
        /// <returns>QID for the Toolbar</returns>
        protected virtual QID GetToolbarQID()
        {
            return ControlQIDs.ToolbarQID;
        }

        #endregion

        #region private variables

        /// <summary>
        /// Used to latch on to the controls
        /// </summary>
        private const int TIME_OUT = MomCommon.Constants.OneMinute;

        #endregion

        #region protected variables

        /// <summary>
        /// The diagram control
        /// </summary>
        protected DiagramControl diagramControl;

        /// <summary>
        /// The tool bar for the diagram
        /// </summary>
        protected DiagramToolBar toolBar;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the DiagramControlViewHost class
        /// </summary>
        /// <param name="knownWindow">Window that is the DiagramControlViewHost</param>
        public DiagramControlViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region IDiagramControlViewHost Members

        /// <summary>
        /// The diagram control
        /// </summary>
        public DiagramControl Diagram
        {
            get
            {
                if (this.diagramControl == null)
                {
                    this.diagramControl = new DiagramControl(
                        new Window(
                            this.Content,
                            this.GetDiagramControlQID(),
                            TIME_OUT)
                            );
                }

                return this.diagramControl;
            }
        }

        /// <summary>
        /// The toolbar
        /// </summary>
        public DiagramToolBar ToolBar
        {
            get
            {
                if (this.toolBar == null)
                {
                    Window toolbarWindow = new Window(this.Content, this.GetToolbarQID(), TIME_OUT);
                    this.toolBar = new DiagramToolBar(toolbarWindow);
                }

                return this.toolBar;
            }
        }

        #endregion
    }

    /// <summary>
    /// This interface lists the controls on a diagram view toolbar
    /// </summary>
    public interface IDiagramToolBarControls
    {
        /// <summary>
        /// The Zoom to page checkbox
        /// </summary>
        CheckBox ZoomToPage
        {
            get;
        }

        /// <summary>
        /// Label for Zoom value
        /// </summary>
        StaticControl ZoomLabel
        {
            get;
        }

        /// <summary>
        /// Amount of zoom
        /// </summary>
        ComboBox Zoom
        {
            get;
        }

        /// <summary>
        /// Label to the number of hops
        /// </summary>
        StaticControl HopsLabel
        {
            get;
        }

        /// <summary>
        /// Current hop value
        /// </summary>
        ComboBox Hops
        {
            get;
        }

        /// <summary>
        /// Show all computers
        /// </summary>
        CheckBox ShowAllComputers
        {
            get;
        }
    }

    /// <summary>
    /// This class represents the tool bar in a diagram view
    /// </summary>
    public class DiagramToolBar : Control, IDiagramToolBarControls
    {
        #region QIDs

        /// <summary>
        /// This is a list of default QIDs for the controls on the view
        /// </summary>
        new class ControlQIDs
        {
            /// <summary>
            /// QID of the Zoom to page control
            /// </summary>
            public static QID ZoomToPageQID = new QID(";[UIA]ClassName = 'SimpleCheckBox' && Instance = '1';[UIA]ClassName = 'CheckBox'");

            /// <summary>
            /// QID of the Show all computers control
            /// </summary>
            public static QID ShowAllComputersQID = new QID(";[UIA]ClassName = 'SimpleCheckBox' && Instance = '2';[UIA]ClassName = 'CheckBox'");

            /// <summary>
            /// QID for the Zoom control
            /// </summary>
            public static QID ZoomQID = new QID(";[UIA]ClassName = 'SimpleComboBox' && Instance = '1';[UIA]ClassName = 'ComboBox'");

            /// <summary>
            /// QID for the Hops control
            /// </summary>
            public static QID HopsQID = new QID(";[UIA]ClassName = 'SimpleComboBox' && Instance = '2';[UIA]ClassName = 'ComboBox'");

            /// <summary>
            /// QID for the label to the zoom control
            /// </summary>
            public static QID ZoomLabelQID = new QID(";[UIA]ClassName = 'SimpleLabel' && Instance = '1';[UIA]ClassName = 'TextBlock'");

            /// <summary>
            /// QID for the label to the hops control
            /// </summary>
            public static QID HopsLabelQID = new QID(";[UIA]ClassName = 'SimpleLabel' && Instance = '2';[UIA]ClassName = 'TextBlock'");
        }

        /// <summary>
        /// Gets the QID for the ZoomToPage control
        /// </summary>
        /// <returns>QID for the ZoomToPage</returns>
        protected virtual QID GetZoomToPageQID()
        {
            return ControlQIDs.ZoomToPageQID;
        }

        /// <summary>
        /// Gets the QID for the ShowAllComputers control
        /// </summary>
        /// <returns>QID for the ShowAllComputers</returns>
        protected virtual QID GetShowAllComputersQID()
        {
            return ControlQIDs.ShowAllComputersQID;
        }

        /// <summary>
        /// Gets the QID for the Zoom control
        /// </summary>
        /// <returns>QID for the Zoom</returns>
        protected virtual QID GetZoomQID()
        {
            return ControlQIDs.ZoomQID;
        }

        /// <summary>
        /// Gets the QID for the ZoomToPage control
        /// </summary>
        /// <returns>QID for the ZoomToPage</returns>
        protected virtual QID GetHopsQID()
        {
            return ControlQIDs.HopsQID;
        }

        /// <summary>
        /// Gets the QID for the Zoom label
        /// </summary>
        /// <returns>QID for the Zoom label</returns>
        protected virtual QID GetZoomLabelQID()
        {
            return ControlQIDs.ZoomLabelQID;
        }

        /// <summary>
        /// Gets the QID for the Hops Label
        /// </summary>
        /// <returns>QID for the Hops Label</returns>
        protected virtual QID GetHopsLabelQID()
        {
            return ControlQIDs.HopsLabelQID;
        }

        #endregion

        #region protected variables

        /// <summary>
        /// The zoom to page control
        /// </summary>
        protected CheckBox zoomToPage;

        /// <summary>
        /// The show all computers checkbox
        /// </summary>
        protected CheckBox showAllComputers;

        /// <summary>
        /// The zoom value combobox
        /// </summary>
        protected ComboBox zoom;

        /// <summary>
        /// THe hops value combo box
        /// </summary>
        protected ComboBox hops;

        /// <summary>
        /// The label to the zoom combobox
        /// </summary>
        protected StaticControl zoomLabel;

        /// <summary>
        /// The label to the hops combobox
        /// </summary>
        protected StaticControl hopsLabel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DiagramToolBar class
        /// </summary>
        /// <param name="knownWindow">Window that is the diagram tool bar</param>
        public DiagramToolBar(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region IDiagramToolBarControls Members

        /// <summary>
        /// The Zoom to page control
        /// </summary>
        public CheckBox ZoomToPage
        {
            get
            {
                if (this.zoomToPage == null)
                {
                    this.zoomToPage = new CheckBox(this, this.GetZoomToPageQID());
                }

                return this.zoomToPage;
            }
        }

        /// <summary>
        /// Label to the Zoom value
        /// </summary>
        public StaticControl ZoomLabel
        {
            get
            {
                if (this.zoomLabel == null)
                {
                    this.zoomLabel = new StaticControl(this, this.GetZoomLabelQID());
                }

                return this.zoomLabel;
            }
        }

        /// <summary>
        /// The Zoom value
        /// </summary>
        public ComboBox Zoom
        {
            get
            {
                if (this.zoom == null)
                {
                    this.zoom = new ComboBox(this, this.GetZoomQID());
                }

                return this.zoom;
            }
        }

        /// <summary>
        /// Label to the hops value
        /// </summary>
        public StaticControl HopsLabel
        {
            get
            {
                if (this.hopsLabel == null)
                {
                    this.hopsLabel = new StaticControl(this, this.GetHopsLabelQID());
                }

                return this.hopsLabel;
            }
        }

        /// <summary>
        /// Hops value
        /// </summary>
        public ComboBox Hops
        {
            get
            {
                if (this.hops == null)
                {
                    this.hops = new ComboBox(this, this.GetHopsQID());
                }

                return this.hops;
            }
        }

        /// <summary>
        /// Show all computers check box
        /// </summary>
        public CheckBox ShowAllComputers
        {
            get
            {
                if (this.showAllComputers == null)
                {
                    this.showAllComputers = new CheckBox(this, this.GetShowAllComputersQID());
                }

                return this.showAllComputers;
            }
        }

        #endregion
    }
}