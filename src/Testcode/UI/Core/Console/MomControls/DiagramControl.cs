//-------------------------------------------------------------------
// <copyright file="DiagramControl.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  Contains classes and methods to use to manipulate nodes, edges through the UI.
// </summary>
//  <history>
//  [jefftow] 21OCT09:  Created
//  [starrpar] 18APR11: Moved to MOMv3.Main branch for use with MapWidget control
//  </history>
//-------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using Maui.Core;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Common;

//NOTE: This file will be moved into UI.Core.Console namespace shortly - just placing here for convenience for now

namespace Mom.Test.UI.Core.Console
{

    /// <summary>
    /// DiagramControl class used to access the diagram control in testcode.
    /// </summary>
    public class DiagramControl
    {
        /// <summary>
        /// QID for vertical scroll bar.
        /// </summary>
        private const string QIDVerticalScrollBar = ";[UIA]AutomationId=\'VerticalScrollBar\'";

        /// <summary>
        /// QID for horizontal scroll bar.
        /// </summary>
        private const string QIDHorizontalScrollBar = ";[UIA]AutomationId=\'HorizontalScrollBar\'";

        /// <summary>
        /// QID for node tree view.
        /// </summary>
        private const string QIDNodeTreeView = ";[UIA]AutomationId=\'NodeTreeView\'";

        /// <summary>
        /// Node tree view ID.
        /// </summary>
        private const string NodeTreeView = "NodeTreeView";

        /// <summary>
        /// Edge list view ID.
        /// </summary>
        private const string EdgeListView = "EdgeTreeView";

        /// <summary>
        /// QID for edge list view.
        /// </summary>
        private const string QIDListView = ";[UIA]AutomationId=\'EdgeTreeView\'";

        /// <summary>
        /// Current set runtime, either wpf or silverlight, default to wpf.
        /// </summary>
        private static Runtime currentRuntime = Runtime.WPF;

        /// <summary>
        /// Console application object.
        /// </summary>
        private Window application;

        /// <summary>
        /// Vertical scroll bar.
        /// </summary>
        private VerticalScrollBar verticalScrollBar;

        /// <summary>
        /// Horizontal scroll bar.
        /// </summary>
        private HorizontalScrollBar horizontalScrollBar;

        /// <summary>
        /// Constructor for diagram control.
        /// </summary>
        /// <param name="application">ConsoleApp application object that contains diagram control.</param>
        public DiagramControl(Window window)
        {
            this.application = window;

            try
            {
                // Query the vertical scrollbar controls.
                this.verticalScrollBar = new VerticalScrollBar(application, new QID(QIDVerticalScrollBar));
            }
            catch (Exception)
            {
                Utilities.LogMessage("No Vertical scroll bar was found");
                this.verticalScrollBar = null;
            }

            try
            {
                // Query the horizontal scrollbar controls.
                this.horizontalScrollBar = new HorizontalScrollBar(application, new QID(QIDHorizontalScrollBar));
            }
            catch (Exception)
            {
                Utilities.LogMessage("No Horizontal scroll bar was found");
                this.horizontalScrollBar = null;
            }
        }

        /// <summary>
        /// Framework runtime, WPF or Silverlight.
        /// </summary>
        public enum Runtime
        {
            /// <summary>
            /// WPF runtime.
            /// </summary>
            WPF,

            /// <summary>
            /// Silvleright runtime.
            /// </summary>
            Silverlight
        }

        /// <summary>
        /// Gets or sets the currrent runtime.
        /// </summary>
        public static Runtime CurrentRuntime
        {
            get
            {
                return currentRuntime;
            }

            set
            {
                currentRuntime = value;
            }
        }

        /// <summary>
        /// Gets reference to the vertical scrollbar of the diagram control.
        /// </summary>
        public VerticalScrollBar VerticalScrollBar
        {
            get
            {
                if (this.verticalScrollBar == null)
                {
                    Utilities.LogMessage("Attempting to access vertical scrollbar, but it is currently null.  Trying again to get a reference");
                    this.verticalScrollBar = new VerticalScrollBar(this.application, new QID(QIDVerticalScrollBar));
                }

                return this.verticalScrollBar;
            }
        }

        /// <summary>
        /// Gets reference to the horizontal scrollbar of the diagram control.
        /// </summary>
        public HorizontalScrollBar HorizontalScrollBar
        {
            get
            {
                if (this.horizontalScrollBar == null)
                {
                    Utilities.LogMessage("Attempting to access horizontal scrollbar, but it is currently null.  Trying again to get a reference");
                    this.horizontalScrollBar = new HorizontalScrollBar(this.application, new QID(QIDHorizontalScrollBar));
                }

                return this.horizontalScrollBar;
            }
        }

        /// <summary>
        /// Finds a node with the given automationID, does not expand to reveal hidden node. Node has to be visible on the panel, but
        /// doesn't have to be in the scrolled viewport it will find nodes outside the viewable area.
        /// </summary>
        /// <param name="nodeId">Automation id for the node.</param>
        /// <returns>Returns NodeControl representing the found node, or null if not found.</returns>
        public NodeControl FindNode(string nodeId)
        {
            Utilities.LogMessage(String.Format("FindNode Id [{0}]", nodeId));

            // Grab reference to the TreeView
            TreeView nodeTreeView = new TreeView(this.application, new QID(QIDNodeTreeView));
            if (nodeTreeView == null)
            {
                return null;
            }

            // Obtains the root treeView.
            AutomationElement treeView = (AutomationElement)nodeTreeView.ScreenElement.AutomationElement;

            // Call FindNode recursive method that will search TreeViews, within TreeViews (boxes) for the given node.
            NodeControl foundNode = this.FindNode(treeView, nodeId);

            return foundNode;
        }

        /// <summary>
        /// Finds an edge with the given automationID
        /// </summary>
        /// <param name="edgeId">edge automation id.</param>
        /// <returns>Returns EdgeControl represented by automation id.</returns>
        public EdgeControl FindEdge(string edgeId)
        {
            Utilities.LogMessage(String.Format("FindEdge Id [{0}]", edgeId));

            // Grab reference to the ListView
            ListView edgeListView = new ListView(this.application, new QID(QIDListView));
            if (edgeListView == null)
            {
                return null;
            }

            // Create a control TreeWalker
            TreeWalker walker = TreeWalker.ControlViewWalker;

            // Gets the first listViewItem 
            AutomationElement listViewItem = walker.GetFirstChild((AutomationElement)edgeListView.ScreenElement.AutomationElement);

            if (listViewItem != null)
            {
                // Check if the first list view item matches the edge we are searching.
                if (listViewItem.Current.AutomationId.CompareTo(edgeId) == 0)
                {
                    Utilities.LogMessage(String.Format("Edge with Id [{0}] found!", edgeId));
                    return new EdgeControl(listViewItem);
                }

                // Keep traversing all the siblings of the ListView, looking for a match to our edge.
                while (((listViewItem = walker.GetNextSibling(listViewItem)) != null))
                {
                    if (listViewItem.Current.AutomationId.CompareTo(edgeId) == 0)
                    {
                        Utilities.LogMessage("Edge with Id [{0}] found: " + edgeId);
                        return new EdgeControl(listViewItem);
                    }
                }
            }
            else
            {
                // No children found at all.
                Utilities.LogMessage("No edge found matching id, in fact no edges at all found");
                return null;
            }

            // We have to recursively traverse all the TreeView's looking through all the possible ListView's in the TreeView until we locate the edge.
            TreeView nodeTreeView = new TreeView(this.application, new QID(QIDNodeTreeView));

            // Obtains the root treeView.
            AutomationElement treeViewAutomationElement = (AutomationElement)nodeTreeView.ScreenElement.AutomationElement;

            return this.FindEdge(treeViewAutomationElement, edgeId);
        }

        /// <summary>
        /// Send key combination string to application.
        /// </summary>
        /// <param name="keys">String key combination.</param>
        public void SendKeys(string keys)
        {
            this.application.SendKeys(keys);
        }

        // TODO: has to be fixed to get all the visible nodes that are in boxes as well.. See NodeControl.FindNode..

        /// <summary>
        /// Returns a list of all the visible nodes, this collection includes nodes that can be scrolled to.
        /// </summary>
        /// <returns>List of all vislble nodes.</returns>
        public List<NodeControl> GetAllVisibleNodes()
        {
            List<NodeControl> visibleNodes = new List<NodeControl>();

            // Grab reference to the TreeView
            TreeView nodeTreeView = new TreeView(this.application, new QID(QIDNodeTreeView));
            if (nodeTreeView == null)
            {
                return null;
            }

            AutomationElement node = null;

            TreeWalker walker = TreeWalker.ControlViewWalker;
            AutomationElement child = walker.GetFirstChild((AutomationElement)nodeTreeView.ScreenElement.AutomationElement);

            if (child != null)
            {
                // Add the first child
                visibleNodes.Add(new NodeControl(child));

                while (((child = walker.GetNextSibling(child)) != null) && (node == null))
                {
                    visibleNodes.Add(new NodeControl(child));
                }
            }

            return visibleNodes;
        }

        // TODO: Has to be fixed to find visible edges as well belonging to "boxed nodes" 

        /// <summary>
        /// Returns a list of all the visible edges, this collection includes edges that can be scrolled to.
        /// </summary>
        /// <returns>List of all visible edges.</returns>
        public List<EdgeControl> GetAllVisibleEdges()
        {
            List<EdgeControl> visibleEdges = new List<EdgeControl>();

            ListView edgeListView = new ListView(this.application, new QID(QIDListView));
            if (edgeListView == null)
            {
                return null;
            }

            AutomationElement edge = null;

            TreeWalker walker = TreeWalker.ControlViewWalker;
            AutomationElement child = walker.GetFirstChild((AutomationElement)edgeListView.ScreenElement.AutomationElement);

            if (child != null)
            {
                // Add first child edge
                visibleEdges.Add(new EdgeControl(child));

                while (((child = walker.GetNextSibling(child)) != null) && (edge == null))
                {
                    visibleEdges.Add(new EdgeControl(child));
                }
            }

            return visibleEdges;
        }

        /// <summary>
        /// Recurse through all the TreeViews, looking for ListViews, searching for an edge given an edge id and that the edge is visible.
        /// </summary>
        /// <param name="treeViewAutomationElement">Tree view automation element.</param>
        /// <param name="edgeId">Edge automation id.</param>
        /// <returns>Reference to edge control.</returns>
        private EdgeControl FindEdge(AutomationElement treeViewAutomationElement, string edgeId)
        {
            // Create a control TreeWalker
            TreeWalker treeViewWalker = TreeWalker.ControlViewWalker;

            // Gets the first treeViewItem
            AutomationElement treeViewItem = treeViewWalker.GetFirstChild(treeViewAutomationElement);

            if (treeViewItem != null)
            {
                // Creates a TreeWalker to walk the TreeViewItems.
                TreeWalker treeViewItemWalker = TreeWalker.ControlViewWalker;
                AutomationElement childTreeViewItem = treeViewItemWalker.GetFirstChild(treeViewItem);

                // Attempt to search for ListView under this TreeViewItem, which possibly contains our edge.
                EdgeControl edge = this.FindEdgeInTreeViewItem(childTreeViewItem, edgeId);
                if (edge != null)
                {
                    return edge;
                }

                // Look at the first child, see if this is a TreeView, if so recurse.
                if (childTreeViewItem.Current.AutomationId == NodeTreeView)
                {
                    EdgeControl foundEdge = this.FindEdge(childTreeViewItem, edgeId);
                    if (foundEdge != null)
                    {
                        return foundEdge;
                    }
                }

                // Look at all subsequent children, looking for ListViews containing our edge, or TreeViews which we have to recurse.
                while ((childTreeViewItem = treeViewItemWalker.GetNextSibling(childTreeViewItem)) != null)
                {
                    // Look for the edge in the ListView
                    edge = this.FindEdgeInTreeViewItem(childTreeViewItem, edgeId);
                    if (edge != null)
                    {
                        return edge;
                    }

                    // If another TreeView, Recurse.
                    if (childTreeViewItem.Current.AutomationId == NodeTreeView)
                    {
                        EdgeControl foundEdge = this.FindEdge(childTreeViewItem, edgeId);
                        if (foundEdge != null)
                        {
                            return foundEdge;
                        }
                    }
                }

                // Look at the rest of the TreeView Item siblings.
                while ((treeViewItem = treeViewWalker.GetNextSibling(treeViewItem)) != null)
                {
                    treeViewItemWalker = TreeWalker.ControlViewWalker;
                    childTreeViewItem = treeViewItemWalker.GetFirstChild(treeViewItem);

                    // Attempt to search for ListView under this TreeViewItem, which possibly contains our edge.
                    edge = this.FindEdgeInTreeViewItem(childTreeViewItem, edgeId);
                    if (edge != null)
                    {
                        return edge;
                    }

                    // Look at the first child, see if this is a TreeView, if so recurse.
                    if (childTreeViewItem.Current.AutomationId == NodeTreeView)
                    {
                        EdgeControl foundEdge = this.FindEdge(childTreeViewItem, edgeId);
                        if (foundEdge != null)
                        {
                            return foundEdge;
                        }
                    }

                    // Look at all subsequent children, looking for ListViews containing our edge, or TreeViews which we have to recurse.
                    while ((childTreeViewItem = treeViewItemWalker.GetNextSibling(childTreeViewItem)) != null)
                    {
                        // Look for the edge in the ListView
                        edge = this.FindEdgeInTreeViewItem(childTreeViewItem, edgeId);
                        if (edge != null)
                        {
                            return edge;
                        }

                        // If another TreeView, Recurse.
                        if (childTreeViewItem.Current.AutomationId == NodeTreeView)
                        {
                            EdgeControl foundEdge = this.FindEdge(childTreeViewItem, edgeId);
                            if (foundEdge != null)
                            {
                                return foundEdge;
                            }
                        }
                    }
                }
            }
            else
            {
                // No nodes found at all.
                Utilities.LogMessage("No nodes found in TreeView");
                return null;
            }

            Utilities.LogMessage("No matching node found in TreeView");
            return null;
        }

        /// <summary>
        /// Helper method that searches for an edge ListView, then the Edge inside a tree view item.
        /// </summary>
        /// <param name="treeViewItem">Tree view item to search for edge.</param>
        /// <param name="edgeId">Edge id we are looking for.</param>
        /// <returns>An EdgeControl representing the found edge, null if not found.</returns>
        private EdgeControl FindEdgeInTreeViewItem(AutomationElement treeViewItem, string edgeId)
        {
            if (treeViewItem.Current.AutomationId == EdgeListView)
            {
                // Go through all the ListView items looking for our edge.
                TreeWalker edgeListViewItemWalker = TreeWalker.ControlViewWalker;
                AutomationElement edgeItem = edgeListViewItemWalker.GetFirstChild(treeViewItem);

                if (edgeItem.Current.AutomationId == edgeId)
                {
                    return new EdgeControl(edgeItem);
                }

                while ((edgeItem = edgeListViewItemWalker.GetNextSibling(edgeItem)) != null)
                {
                    if (edgeItem.Current.AutomationId == edgeId)
                    {
                        return new EdgeControl(edgeItem);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Searches all the TreeViews within TreeViews for the tree item that represents the node.
        /// </summary>
        /// <param name="treeView">TreeView to start search for node.</param>
        /// <param name="nodeId">String of the automation Id of the node we are searching for.</param>
        /// <returns>A NodeControl representing the found node, or null if not found.</returns>
        private NodeControl FindNode(AutomationElement treeView, string nodeId)
        {
            // Create a control TreeWalker
            TreeWalker treeViewWalker = TreeWalker.ControlViewWalker;

            // Gets the first treeViewItem
            AutomationElement treeViewItem = treeViewWalker.GetFirstChild(treeView);

            if (treeViewItem != null)
            {
                // Check if the first tree view item matches the node we are searching.
                if (treeViewItem.Current.AutomationId.CompareTo(nodeId) == 0)
                {
                    Utilities.LogMessage(String.Format("Node with Id [{0}] found!", nodeId));
                    return new NodeControl(treeViewItem);
                }

                // If this child contains another TreeView, we have to recursivley traverse that TreeView
                TreeWalker treeViewItemWalker = TreeWalker.ControlViewWalker;
                AutomationElement childTreeView = treeViewItemWalker.GetFirstChild(treeViewItem);

                #region Look for another TreeView in all the Tree view items, and recurse

                // Look at the first child, see if this is a TreeView, if so recurse
                if (childTreeView.Current.AutomationId == NodeTreeView)
                {
                    NodeControl foundNode = this.FindNode(childTreeView, nodeId);
                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }

                // Look at all subsequent children, see if any child is a TreeView, if so recurse
                while ((childTreeView = treeViewItemWalker.GetNextSibling(childTreeView)) != null)
                {
                    if (childTreeView.Current.AutomationId == NodeTreeView)
                    {
                        NodeControl foundNode = this.FindNode(childTreeView, nodeId);
                        if (foundNode != null)
                        {
                            return foundNode;
                        }
                    }
                }

                #endregion Look for another TreeView in all the Tree view items, and recurse

                // Keep treversing all the siblings of the TreeView, looking for a match to our node.
                while ((treeViewItem = treeViewWalker.GetNextSibling(treeViewItem)) != null)
                {
                    if (treeViewItem.Current.AutomationId.CompareTo(nodeId) == 0)
                    {
                        Utilities.LogMessage(String.Format("Node with Id [{0}] found!", nodeId));
                        return new NodeControl(treeViewItem);
                    }

                    #region Look for another TreeView in all the Tree view items, and recurse

                    childTreeView = treeViewItemWalker.GetFirstChild(treeViewItem);

                    // If this child contains another TreeView, we have to recursivley traverse that
                    if (childTreeView.Current.AutomationId == NodeTreeView)
                    {
                        NodeControl foundNode = this.FindNode(childTreeView, nodeId);
                        if (foundNode != null)
                        {
                            return foundNode;
                        }
                    }

                    while ((childTreeView = treeViewItemWalker.GetNextSibling(childTreeView)) != null)
                    {
                        if (childTreeView.Current.AutomationId == NodeTreeView)
                        {
                            NodeControl foundNode = this.FindNode(childTreeView, nodeId);
                            if (foundNode != null)
                            {
                                return foundNode;
                            }
                        }
                    }

                    #endregion Look for another TreeView in all the Tree view items, and recurse
                }
            }
            else
            {
                // No nodes found at all.
                Utilities.LogMessage("No nodes found in TreeView");
                return null;
            }

            Utilities.LogMessage("No matching node found in TreeView");
            return null;
        }

        /// <summary>
        /// Node Control class used to manipulate nodes through the UI.
        /// </summary>
        public class NodeControl
        {
            /// <summary>
            /// Automation element for node control.
            /// </summary>
            private AutomationElement node = null;

            /// <summary>
            /// Constructor that creates a node control from a screen element.
            /// </summary>
            /// <param name="node">Automation element that is context of a node item.</param>
            public NodeControl(AutomationElement node)
            {
                this.node = node;
            }

            public AutomationElement AutomationElement
            {
                get
                {
                    return node;
                }
            }

            public Window Window
            {
                get
                {
                    Window window = new Window(new QID(string.Format(";[UIA]AutomationId=\'{0}\'", this.AutomationId)), 200);
                    return window;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the node is selected or not.
            /// </summary>
            public bool IsSelected
            {
                get
                {
                    return this.GetSelectionItemPattern().Current.IsSelected;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the node is expanded or not.
            /// </summary>
            public bool Expanded
            {
                get
                {
                    return (this.GetExpandCollapseItemPattern().Current.ExpandCollapseState == ExpandCollapseState.Expanded) ? true : false;
                }
            }

            /// <summary>
            /// Gets boolean representing if the node control is enabled.
            /// </summary>
            public bool IsEnabled
            {
                get
                {
                    return this.node.Current.IsEnabled;
                }
            }

            /// <summary>
            /// Gets the automation Id for this element.
            /// </summary>
            public string AutomationId
            {
                get
                {
                    return this.node.Current.AutomationId;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the node is Boxed or not.
            /// </summary>
            public bool Boxed
            {
                get
                {
                    return this.node.Current.Name.Contains("IsBox=True");
                }
            }

            /// <summary>
            /// Ensure the node is visible by scrolling to it on the screen.
            /// </summary>
            public void EnsureVisible()
            {
                Utilities.LogMessage(String.Format("Ensuring node {0} is visible", this.node.Current.AutomationId));
                this.GetScrollItemPattern().ScrollIntoView();
            }

            /// <summary>
            /// Selects the node.
            /// </summary>
            public void Select()
            {
                Utilities.LogMessage(String.Format("Selecting node {0}", this.node.Current.AutomationId));
                this.GetSelectionItemPattern().Select();
            }

            /// <summary>
            /// Sends key combination string to the node control.
            /// </summary>
            /// <param name="keys">String key combination.</param>
            public void SendKeys(string keys)
            {
                Utilities.LogMessage(String.Format("Sending keys {0} to node {1}", keys, this.node.Current.AutomationId));
                this.SendKeys(keys);
            }

            /// <summary>
            /// Unselects the node.
            /// </summary>
            public void UnSelect()
            {
                Utilities.LogMessage(String.Format("UnSelecting node {0}", this.node.Current.AutomationId));
                this.GetSelectionItemPattern().RemoveFromSelection();
            }

            /// <summary>
            /// Expands the node.
            /// </summary>
            public void Expand()
            {
                Utilities.LogMessage(String.Format("Expanding node {0}", this.node.Current.AutomationId));
                this.GetExpandCollapseItemPattern().Expand();
            }

            /// <summary>
            /// Collapses the node.
            /// </summary>
            public void Collapse()
            {
                Utilities.LogMessage(String.Format("Collapsing node {0}", this.node.Current.AutomationId));
                this.GetExpandCollapseItemPattern().Collapse();
            }

            /// <summary>
            /// Returns a bounding rectangle for the given node.
            /// </summary>
            /// <returns>Boundary rectangle of the ndoe.</returns>
            public System.Windows.Rect GetBoundingRectangle()
            {
                Utilities.LogMessage(String.Format("Bounding rectangle {0} for node {1}", this.node.Current.BoundingRectangle, this.node.Current.AutomationId));
                return this.node.Current.BoundingRectangle;
            }

            /// <summary>
            /// Boxes the node.
            /// </summary>
            public void Box()
            {
                Utilities.LogMessage(String.Format("Boxing node {0}", this.node.Current.AutomationId));
                ValuePattern valuePattern = this.GetBoxUnboxItemPattern();
                valuePattern.SetValue("Box=True");
            }

            /// <summary>
            /// Unboxes the node.
            /// </summary>
            public void UnBox()
            {
                Utilities.LogMessage(String.Format("UnBoxing node {0}", this.node.Current.AutomationId));
                ValuePattern valuePattern = this.GetBoxUnboxItemPattern();
                valuePattern.SetValue("Box=False");
            }

            /// <summary>
            /// Obtains the expand collapse pattern (used for box mode).
            /// </summary>
            /// <returns>ExpandCollapsePattern that represnts box mode.</returns>
            private ValuePattern GetBoxUnboxItemPattern()
            {
                object objPattern;
                ValuePattern valueCollapsePatern = null;

                if (true == this.node.TryGetCurrentPattern(ValuePattern.Pattern, out objPattern))
                {
                    valueCollapsePatern = objPattern as ValuePattern;
                }

                return valueCollapsePatern;
            }

            /// <summary>
            /// Obtains the selection item pattern automation peer for edges.
            /// </summary>
            /// <returns>SelectionItemPattern object for node.</returns>
            private SelectionItemPattern GetSelectionItemPattern()
            {
                object objPattern;
                SelectionItemPattern selectionPatern = null;

                if (true == this.node.TryGetCurrentPattern(SelectionItemPattern.Pattern, out objPattern))
                {
                    selectionPatern = objPattern as SelectionItemPattern;
                }

                return selectionPatern;
            }

            /// <summary>
            /// Obtains the scroll item pattern automation peer for nodes.
            /// </summary>
            /// <returns>ScrollItemPattern object for edge.</returns>
            private ScrollItemPattern GetScrollItemPattern()
            {
                object objPattern;
                ScrollItemPattern scrollPatern = null;

                if (true == this.node.TryGetCurrentPattern(ScrollItemPattern.Pattern, out objPattern))
                {
                    scrollPatern = objPattern as ScrollItemPattern;
                }

                return scrollPatern;
            }

            /// <summary>
            /// Obtains the scroll item pattern automation peer for nodes.
            /// </summary>
            /// <returns>ScrollItemPattern object for edge.</returns>
            private ExpandCollapsePattern GetExpandCollapseItemPattern()
            {
                object objPattern;
                ExpandCollapsePattern expandCollapsePatern = null;

                if (true == this.node.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out objPattern))
                {
                    expandCollapsePatern = objPattern as ExpandCollapsePattern;
                }

                return expandCollapsePatern;
            }
        }

        /// <summary>
        /// Edge Control class used to manipulate an edge.
        /// </summary>
        public class EdgeControl
        {
            /// <summary>
            /// Edge automation element.
            /// </summary>
            private AutomationElement edge;

            /// <summary>
            /// Constructor to create EdgeControl from a ScreeElement that is in the context of an "Edge".
            /// </summary>
            /// <param name="edge">ScreenElement that is in context of an edge item.</param>
            public EdgeControl(AutomationElement edge)
            {
                this.edge = edge;
            }

            /// <summary>
            /// Gets the automation Id for the edge.
            /// </summary>
            public string AutomationId
            {
                get
                {
                    return this.edge.Current.AutomationId;
                }
            }

            /// <summary>
            /// Gets a value indicating whether Edges  is selected or not.
            /// </summary>
            public bool IsSelected
            {
                get
                {
                    return this.GetSelectionItemPattern().Current.IsSelected;
                }
            }

            /// <summary>
            /// Gets if this edge control is enabled.
            /// </summary>
            public bool IsEnabled
            {
                get
                {
                    return this.edge.Current.IsEnabled;
                }
            }

            /// <summary>
            /// Select the Edge.
            /// </summary>
            public void Select()
            {
                Utilities.LogMessage(String.Format("Selecting edge {0}", this.edge.Current.AutomationId));
                this.GetSelectionItemPattern().Select();
            }

            /// <summary>
            /// Send key combinations to edge control.
            /// </summary>
            /// <param name="keys">String key combination to send to edge control.</param>
            public void SendKeys(string keys)
            {
                Utilities.LogMessage(String.Format("Sending keys {0} to edge {1}", keys, this.edge.Current.AutomationId));
                this.SendKeys(keys);
            }

            /// <summary>
            /// Scrolls the edge into view.
            /// </summary>
            public void EnsureVisible()
            {
                Utilities.LogMessage(String.Format("Ensure edge is visible {0}", this.edge.Current.AutomationId));
                this.GetScrollItemPattern().ScrollIntoView();
            }

            /// <summary>
            /// Returns a bounding rectangle for the given edge.
            /// </summary>
            /// <returns>Boundary rectangle of the node.</returns>
            public System.Windows.Rect GetBoundingRectangle()
            {
                Utilities.LogMessage(String.Format("Bounding rectangle {0} for node {1}", this.edge.Current.BoundingRectangle, this.edge.Current.AutomationId));
                return this.edge.Current.BoundingRectangle;
            }

            /// <summary>
            /// Unselect the Edge.
            /// </summary>
            public void UnSelect()
            {
                Utilities.LogMessage(String.Format("Removing edge {0} from selection", this.edge.Current.AutomationId));
                this.GetSelectionItemPattern().RemoveFromSelection();
            }

            /// <summary>
            /// Gets the node id of the source this edge is attached to.
            /// </summary>
            /// <returns>String representing node id of the source this edge is connected to.</returns>
            public string GetSource()
            {
                Utilities.LogMessage("Getting source node id for edge {0}: " + this.edge.Current.AutomationId);

                // Parse out from the Name the source ID
                Regex sourceNodeIdExpression = new Regex(@"Source=\[Node: Id=(\w*);", RegexOptions.None);
                MatchCollection matchCollection = sourceNodeIdExpression.Matches(this.edge.Current.Name);
                string nodeId = matchCollection[0].Groups[1].Value;

                return nodeId;
            }

            /// <summary>
            /// Gets the node id of the sink this edge is connected to.
            /// </summary>
            /// <returns>String of the node id of the sink this edge is connected to.</returns>
            public string GetSink()
            {
                Utilities.LogMessage("Getting sink node id for edge {0}: " + this.edge.Current.AutomationId);

                // Parse out from the Name the Sink ID
                Regex sourceNodeIdExpression = new Regex(@"Sink=\[Node: Id=(\w*);", RegexOptions.None);
                MatchCollection matchCollection = sourceNodeIdExpression.Matches(this.edge.Current.Name);
                string nodeId = matchCollection[0].Groups[1].Value;

                return nodeId;
            }

            /// <summary>
            /// Obtains the selection item pattern automation peer for edges.
            /// </summary>
            /// <returns>SelectionItemPattern object for edge.</returns>
            private SelectionItemPattern GetSelectionItemPattern()
            {
                object objPattern;
                SelectionItemPattern selectionPatern = null;

                if (true == this.edge.TryGetCurrentPattern(SelectionItemPattern.Pattern, out objPattern))
                {
                    selectionPatern = objPattern as SelectionItemPattern;
                }

                return selectionPatern;
            }

            /// <summary>
            /// Obtains the scroll item pattern automation peer for edges.
            /// </summary>
            /// <returns>ScrollItemPattern object for edge.</returns>
            private ScrollItemPattern GetScrollItemPattern()
            {
                object objPattern;
                ScrollItemPattern scrollPatern = null;

                if (true == this.edge.TryGetCurrentPattern(ScrollItemPattern.Pattern, out objPattern))
                {
                    scrollPatern = objPattern as ScrollItemPattern;
                }

                return scrollPatern;
            }
        }
    }
}
