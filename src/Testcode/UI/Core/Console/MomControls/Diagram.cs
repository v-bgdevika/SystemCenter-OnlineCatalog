// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Diagram.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  Diagram view base class.
// </summary>
// <history>
//  [kellymor]  07-Sep-05   Created
//  [kellymor]  08-Sep-05   Added detailed click method to DiagramNode class
//                          Modified scan method to reset the vertical and
//                          horizontal step values to half the size of the
//                          first node found.  This should speed the search.
//                          Added click and drag method to DiagramNode class
//  [kellymor]  09-Sep-05   Added control ID's for the SOM and Application
//                          Structure diagrams.
//  [kellymor]  26-Sep-05   Added count property
//  [kellymor]  27-Sep-05   Modified step value to be 1/3 size of a node
//  [kellymor]  28-Sep-05   Modified method to find the node bounding box to
//                          use tooltips rather than cursor changes for edges
//                          Fixed issue finding height of node because the
//                          tooltip didn't disappear when expected.
//  [kellymor]  05-Oct-05   Added property to get an enumerator for the node
//                          collection, needed by foreach loops.
//  [kellymor]  07-Oct-05   Modified SetBoundingBox to check for tooltip text
//                          changes.
//                          Fixed index out of range issue in setting the 
//                          diagram node's name and health state.
//  [kellymor]  19-Oct-05   Added another constructor that takes a reference
//                          to window that contains the Diagram control.
//                          Modified SetBoundingBox to use the same width and
//                          height values for all nodes found.
// </history>
// ---------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.GlobalExceptions;
    using Maui.Core;

    #endregion // Using Directives

    /// <summary>
    /// Class to contain the functionality of a diagram control.
    /// </summary>
    public class Diagram : Maui.Core.WinControls.Control
    {
        #region Private Static Members

        /// <summary>
        /// tooltip separator characters
        /// </summary>
        private static string[] toolTipSeparators = new string[] { "\n", "\r", "\n\r", "\r\n" };

        #endregion // Private Static Members

        #region Private Members

        /// <summary>
        /// reference to the parentWindow
        /// </summary>
        private Window parentWindow;

        /// <summary>
        /// collection of diagram nodes
        /// </summary>
        private List<DiagramNode> nodes;

        /// <summary>
        /// Width of the current bounding box
        /// </summary>
        private int boundingBoxWidth;

        /// <summary>
        /// Height of the current bounding box
        /// </summary>
        private int boundingBoxHeight;

        #endregion // Private Members

        #region Constructors

        /// <summary>
        /// Constructs a new diagram control that is contained by the specified
        /// parent application with the specified control ID.
        /// </summary>
        /// <param name="parentApp">Reference to the parent application</param>
        /// <param name="controlID">Control ID of the diagram control</param>
        public Diagram(Maui.Core.App parentApp, string controlID)
            : base(parentApp.MainWindow, controlID)
        {
            this.nodes = new List<DiagramNode>();
            this.parentWindow = parentApp.MainWindow;
        }

        /// <summary>
        /// Constructs a new diagram control that is contained by the specified
        /// parent window with the specified control ID.
        /// </summary>
        /// <param name="parentWindow">Reference to the parent window</param>
        /// <param name="controlID">Control ID of the diagram control</param>
        public Diagram(Maui.Core.Window parentWindow, string controlID) 
            : base(parentWindow, controlID)
        {
            this.nodes = new List<DiagramNode>();
            this.parentWindow = parentWindow;
        }

        /// <summary>
        /// Constructor that takes a reference to the window that contains
        /// the Diagram control.
        /// </summary>
        /// <param name="knownWindow">
        /// Window that contains the Diagram control
        /// </param>
        public Diagram(Maui.Core.Window knownWindow)
            : base(knownWindow)
        {
            this.nodes = new List<DiagramNode>();
            this.parentWindow = knownWindow.Extended.Parent;
        }

        #endregion // Constructors

        #region Public Properties

        /// <summary>
        /// Read-only property to return the number of nodes
        /// </summary>
        public int NodeCount
        {
            get
            {
                if (this.nodes != null)
                {
                    return this.nodes.Count;
                }
                else return 0;
            }
        }

        /// <summary>
        /// Property to get an enumeration of diagram nodes.
        /// </summary>
        public List<DiagramNode> Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        #endregion // Public Properties

        #region Public Methods

        /// <summary>
        /// Method to find a node in a diagram and return it.
        /// </summary>
        /// <param name="name">Name of the node to find</param>
        /// <returns>A DiagramNode class</returns>
        /// <exception cref="DiagramNodeNotFoundException">
        /// Throws this exception if the node cannot be found in the
        /// current diagram view.
        /// </exception>
        public DiagramNode FindDiagramNode(string name) 
        {
            // initialize the diagram
            this.InitializeDiagram();

            // get the node from the list of nodes
            return this.GetDiagramNode(name);
        }

        /// <summary>
        /// Method to determine if the specified node exists in the current
        /// diagram view.
        /// </summary>
        /// <param name="name">Name of the node</param>
        /// <returns>
        /// Flag indicating whether or not the specified node exists
        /// </returns>
        public bool DiagramNodeExists(string name)
        {
            // check for null or zero-length list of nodes
            if (null != this.nodes && 0 < this.nodes.Count)
            {
                DiagramNode nodeToFind = null;

                // check for the node in the list
                try
                {
                    // get the node by name
                    nodeToFind = this.GetDiagramNode(name);
                }
                catch (DiagramNodeNotFoundException)
                {
                    Core.Common.Utilities.LogMessage("Failed to find diagram node with name:  '" + name + "'");
                }

                // return true if we found the node, false otherwise
                return (nodeToFind != null);
            }
            else
            {
                // the node does not exist in an empty list
                return false;
            }
        }

        /// <summary>
        /// Method to rescan the diagram view and rebuild the node list
        /// </summary>
        public void RescanDiagram()
        {
            // clear the list of nodes
            this.nodes.Clear();

            // rescan the diagram surface
            this.ScanForAllNodes();
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// Method to initialize the diagram control and diagram nodes
        /// </summary>
        private void InitializeDiagram()
        {
            // if the current list of nodes is empty or null
            if (null == this.nodes || 0 >= this.nodes.Count)
            {
                // scan for all nodes
                this.ScanForAllNodes();
            }
        }

        /// <summary>
        /// Method to scan a diagram's viewport for all visible nodes.
        /// </summary>
        private void ScanForAllNodes()
        {
            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes()...");

            // if the list of nodes is null
            if (null == this.nodes)
            {
                // create a new empty list
                this.nodes = new List<DiagramNode>();
            }

            // reference to a tooltip on a node
            string nodeToolTipText = null;

            // reference to a temporary node
            DiagramNode tempNode = null;

            // set initial vertical and horizontal step at 10 pixels
            int horizontalStep = 10;
            int verticalStep = 10;

            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Default horizontal step:  " + horizontalStep);
            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Default vertical step:    " + verticalStep);

            /* set the search start coordinates to control left and top, 
             * plus initial step values
             * start the search on the top line of the control
             */
            Maui.Core.Mouse.Move(this.Left, this.Top);
            for (int searchY = verticalStep + this.Top; 
                searchY < (this.Top + this.Height); 
                searchY += verticalStep)
            {
                // search from left to right on the current line
                for (int searchX = horizontalStep + this.Left; 
                    searchX < (this.Left + this.Width); 
                    searchX += horizontalStep)
                {
                    // Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Move mouse pointer to (x,y):  " + searchX + ", " + searchY);

                    // move the mouse pointer to the specified point
                    Maui.Core.Mouse.Move(searchX, searchY);

                    // if the cursor is not an arrow
                    if (Maui.Core.Mouse.CurrentCursorType != NativeMethods.MouseCursorType.Arrow)
                    {
                        Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Getting tooltip text...");

                        // click at the current mouse pointer location
                        // Maui.Core.Mouse.Click(searchX, searchX);
                        nodeToolTipText = this.GetToolTipText();

                        Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Tooltip text:  '" + nodeToolTipText + "'");

                        // if the tooltip text is not null or empty string
                        if (null != nodeToolTipText
                            && String.Empty.CompareTo(nodeToolTipText) != 0)
                        {
                            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Creating new node...");

                            // we've found a node!
                            tempNode = new DiagramNode();

                            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Getting node name and health state...");

                            // set the node name and health state
                            this.SetDiagramNodeName(tempNode, nodeToolTipText);

                            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Checking for existing instance of node...");

                            // if node is not in the list of nodes
                            if (false == this.DiagramNodeExists(tempNode.Name))
                            {
                                Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::Getting the bounding box...");

                                // set the bounding box for the node
                                this.SetNodeBoundingBox(tempNode);

                                // add the new diagram node to the list
                                this.nodes.Add(tempNode);
                            }

                            // reset the step values to 1/3 the size of a node
                            if (tempNode.Width > horizontalStep)
                            {
                                horizontalStep = tempNode.Width / 3;
                            }

                            if (tempNode.Height > verticalStep)
                            {
                                verticalStep = tempNode.Height / 3;
                            }

                            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::New horizontal step:  " + horizontalStep);
                            Core.Common.Utilities.LogMessage("Diagram::ScanForAllNodes::New vertical step:    " + verticalStep);
                        } // Has ToolTip Text
                    } // Cursor is an Arrow
                } // Search X
            } // Search Y
        }

        /// <summary>
        /// Method to get a node by name
        /// </summary>
        /// <param name="name">Name of the node</param>
        /// <returns>A DiagramNode object</returns>
        /// <exception cref="DiagramNodeNotFoundException">
        /// Throws an exception of the collection of nodes is null,
        /// empty, or the specified node does not exist.
        /// </exception>
        private DiagramNode GetDiagramNode(string name)
        {
            // if the list of nodes is not null and not empty
            if (null != this.nodes && 0 < this.nodes.Count)
            {
                // search the nodes
                foreach (DiagramNode currentNode in this.nodes)
                {
                    if (0 == currentNode.Name.CompareTo(name))
                    {
                        // return the node
                        return currentNode;
                    }
                }

                // searched the collection and found no match
                throw new DiagramNodeNotFoundException("Unable to find node by name:  '" + name + "'");
            }
            else
            {
                throw new DiagramNodeNotFoundException("Unable to locate requested node:  '" + name + "'\n\rThe collection of nodes is empty!");
            }
        }

        /// <summary>
        /// Method to get the dimensions of the selectable area around the
        /// specified node.
        /// </summary>
        /// <param name="node">The diagram node to explore</param>
        private void SetNodeBoundingBox(DiagramNode node)
        {
            // save the start point
            System.Drawing.Point startPoint =
                new System.Drawing.Point(Maui.Core.Mouse.X, Maui.Core.Mouse.Y);

            // get the initial tooltip text
            string startToolTipText = this.GetToolTipText();
            string currentToolTipText = null;

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Current start point (x,y):  " + startPoint.X + ", " + startPoint.Y);

            #region Set Left Boundary

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Getting left boundary...");

            // move left until the cursor changes
            for (int x = startPoint.X; x > this.Left; x--)
            {
                // move the mouse
                Maui.Core.Mouse.Move(x, startPoint.Y);

                // get the tooltip text
                currentToolTipText = this.GetToolTipText();

                // if the tooltip disappears, is blank or changes...
                if (null == currentToolTipText || 
                    0 == String.Empty.CompareTo(currentToolTipText) ||
                    0 != startToolTipText.CompareTo(currentToolTipText))
                {
                    // save width
                    node.Left = x;
                    break;
                }
            }

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Left boundary := " + node.Left);

            #endregion // Set Left Boundary

            #region Set Top Boundary

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Getting the top boundary...");

            // move back to start point
            Maui.Core.Mouse.Move(startPoint.X, startPoint.Y);
            currentToolTipText = null;

            // move up until cursor changes
            for (int y = startPoint.Y; y > this.Top; y--)
            {
                Maui.Core.Mouse.Move(startPoint.X, y);

                // get the tooltip text
                currentToolTipText = this.GetToolTipText();

                // if the tooltip disappears, is blank or changes...
                if (null == currentToolTipText ||
                    0 == String.Empty.CompareTo(currentToolTipText) ||
                    0 != startToolTipText.CompareTo(currentToolTipText))
                {
                    // save bottom
                    node.Top = y;
                    break;
                }
            }

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Top boundary := " + node.Top);

            #endregion // Set Top Boundary

            #region Set Width

            // if the width has not yet been determined
            if (this.boundingBoxWidth == 0)
            {
                Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Getting the width...");

                // move back to start point
                Maui.Core.Mouse.Move(startPoint.X, startPoint.Y);
                currentToolTipText = null;

                // move right until the cursor changes
                for (int x = startPoint.X; x < this.Right; x++)
                {
                    Maui.Core.Mouse.Move(x, startPoint.Y);

                    // get the tooltip text
                    currentToolTipText = this.GetToolTipText();

                    // if the tooltip disappears, is blank or changes...
                    if (null == currentToolTipText ||
                        0 == String.Empty.CompareTo(currentToolTipText) ||
                        0 != startToolTipText.CompareTo(currentToolTipText))
                    {
                        // save width
                        node.Width = x - node.Left;
                        break;
                    }
                }

                // set the current width for subsequent operations
                this.boundingBoxWidth = node.Width;
            }
            else
            {
                // use the last known width
                node.Width = this.boundingBoxWidth;
            }

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Node width := " + node.Width);

            #endregion // Set Width

            #region Set Height

            // if the height has not yet been determined
            if (this.boundingBoxHeight == 0)
            {
                Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Getting the height...");

                // move back to start point
                Maui.Core.Mouse.Move(startPoint.X, startPoint.Y);
                currentToolTipText = null;

                // move the cursor away from the exact edge of the tool tip
                int primeX = (node.Left + (node.Width / 2));

                // move down until cursor changes
                for (int y = startPoint.Y; y < this.Bottom; y++)
                {
                    // zig-zag down to avoid running over the tool tip left edge
                    if ((y % 2) == 0)
                    {
                        Maui.Core.Mouse.Move(primeX + 2, y);
                    }
                    else
                    {
                        Maui.Core.Mouse.Move(primeX - 2, y);
                    }

                    // get the tooltip text
                    currentToolTipText = this.GetToolTipText();

                    // if the tooltip disappears, is blank or changes...
                    if (null == currentToolTipText ||
                        0 == String.Empty.CompareTo(currentToolTipText) ||
                        0 != startToolTipText.CompareTo(currentToolTipText))
                    {
                        // save bottom
                        node.Height = y - node.Top;
                        break;
                    }
                }

                // set the current height for subsequent operations
                this.boundingBoxHeight = node.Height;
            }
            else
            {
                // use the last known height
                node.Height = this.boundingBoxHeight;
            }

            Core.Common.Utilities.LogMessage("Diagram::SetNodeBoundingBox::Node height := " + node.Height);

            #endregion // Set Height
        }

        /// <summary>
        /// Method to get the current tool tip text from the diagram
        /// </summary>
        /// <returns>A string representing the tooltip text</returns>
        private string GetToolTipText()
        {
            string returnValue = null;
            try
            {
                // create a new tooltip
                Maui.Core.WinControls.ToolTip toolTip =
                    new Maui.Core.WinControls.ToolTip(5000, true);

                // get the tooltip text
                returnValue = toolTip.Text;
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException exception)
            {
                UI.Core.Common.Utilities.LogMessage("Failed to find tooltip:  " + exception.Message);
            }
            return returnValue;
        }

        /// <summary>
        /// Method to set the name and healthstate by parsing the tooltip text
        /// </summary>
        /// <param name="node">The node to modify</param>
        /// <param name="toolTipText">The tooltip text</param>
        private void SetDiagramNodeName(DiagramNode node, string toolTipText)
        {
            // split the string around carriage return and line-feed characters
            string[] diagramDetails = 
                toolTipText.Split(
                    Diagram.toolTipSeparators, 
                    StringSplitOptions.RemoveEmptyEntries);

            // if the array is not null and has at least one item
            if (null != diagramDetails && 0 < diagramDetails.Length)
            {
                // the first part is the name
                node.Name = diagramDetails[0];

                Core.Common.Utilities.LogMessage("Diagram::SetDiagramNodeName::Node name := '" + node.Name + "'");

                // if there's another item
                if (1 < diagramDetails.Length
                    && diagramDetails[1].StartsWith(Diagram.Strings.HealthState))
                {
                    // get the health state text
                    string[] healthStateText =
                        diagramDetails[1].Split(
                        new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                    // check for health state text
                    if (null != healthStateText && 2 < healthStateText.Length)
                    {
                        // set the node health state
                        node.HealthState = healthStateText[2];

                        Core.Common.Utilities.LogMessage("Diagram::SetDiagramNodeName::Node health state := '" + node.HealthState + "'");
                    }
                    else
                    {
                        // set the health state to an empty string
                        node.HealthState = String.Empty;
                    }
                }
                else
                {
                    // set the health state to an empty string
                    node.HealthState = String.Empty;
                }
            }
            else
            {
                // set the node name and health state to an empty string
                node.Name = String.Empty;
                node.HealthState = String.Empty;
            }
        }

        #endregion // Private Methods

        #region ControlIDs

        /// <summary>
        /// Class to contain the control ID's of the various diagram views
        /// </summary>
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Monitoring diagram view
            /// </summary>
            /// <history>
            /// TODO: Need a WinFormsID, bug ID# 55997
            /// </history>
            public const string Monitoring = "Diagram";

            /// <summary>
            /// Control ID for Application Structure diagram view
            /// </summary>
            /// <history>
            /// TODO: Need a WinFormsID, bug ID# 56000
            /// </history>
            public const string ApplicationStructure = "Application Model";
        }

        #endregion // ControlIDs

        #region Strings

        /// <summary>
        /// String resources for diagram control
        /// </summary>
        public class Strings
        {
            #region Constants

            private const string ResourceHealthState = ";Health State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;HealthState";

            #endregion // Constants

            #region Private Members

            /// <summary>
            /// cached resource string for Health State:
            /// </summary>
            private static string cachedHealthState;

            #endregion // Private Members

            #region Properties

            /// <summary>
            /// Gets the translated string for Health State:
            /// </summary>
            public static string HealthState
            {
                get
                {
                    if (cachedHealthState == null)
                    {
                        cachedHealthState = CoreManager.MomConsole.GetIntlStr(ResourceHealthState);
                    }
                    return cachedHealthState;
                }
            }

            #endregion // Properties
        }

        #endregion Strings

        #region DiagramNode Class

        /// <summary>
        /// Class that represents a node in the diagram view.
        /// </summary>
        public class DiagramNode
        {
            #region Private Members

            /// <summary>
            /// Name of the node
            /// </summary>
            private string name;
            
            /// <summary>
            /// Health state of the node
            /// </summary>
            private string healthState;

            /// <summary>
            /// Left position or x-coordinate
            /// </summary>
            private int left;

            /// <summary>
            /// Top position or y-coordinate
            /// </summary>
            private int top;

            /// <summary>
            /// Width of the node
            /// </summary>
            private int width;

            /// <summary>
            /// Height of the node
            /// </summary>
            private int height;

            #endregion // Private Members

            #region Constructors

            /// <summary>
            /// Default constructor
            /// </summary>
            public DiagramNode()
            {
                // default constructor
                this.name = string.Empty;
                this.left = 0;
                this.top = 0;
                this.width = 0;
                this.height = 0;
                this.healthState = string.Empty;
            }

            /// <summary>
            /// Constructor that creates a DiagramNode based on the supplied
            /// parameters
            /// </summary>
            /// <param name="name">Name of the node</param>
            /// <param name="left">Left position or x-coordinate</param>
            /// <param name="top">Top position or y-coordinate</param>
            /// <param name="width">Width of the node</param>
            /// <param name="height">Height of the node</param>
            public DiagramNode(
                string name,
                int left,
                int top,
                int width,
                int height)
            {
                // default constructor
                this.name = name;
                this.left = left;
                this.top = top;
                this.width = width;
                this.height = height;
            }

            #endregion // Constructors

            #region Public Properties

            /// <summary>
            /// Property to get/set the name of the node
            /// </summary>
            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            /// <summary>
            /// Property to get/set the health state of the node
            /// </summary>
            public string HealthState
            {
                get
                {
                    return this.healthState;
                }

                set
                {
                    this.healthState = value;
                }
            }

            /// <summary>
            /// Property to get/set the left position or x-coordinate
            /// </summary>
            public int Left
            {
                get
                {
                    return this.left;
                }

                set
                {
                    this.left = value;
                }
            }

            /// <summary>
            /// Property to get/set the top position or y-coordinate
            /// </summary>
            public int Top
            {
                get
                {
                    return this.top;
                }

                set
                {
                    this.top = value;
                }
            }

            /// <summary>
            /// Property to get/set the width of the node
            /// </summary>
            public int Width
            {
                get
                {
                    return this.width;
                }

                set
                {
                    this.width = value;
                }
            }

            /// <summary>
            /// Property to get/set the height of the node
            /// </summary>
            public int Height
            {
                get
                {
                    return this.height;
                }

                set
                {
                    this.height = value;
                }
            }

            #endregion // Public Properties

            #region Public Methods

            /// <summary>
            /// Generic click method that positions the mouse pointer
            /// over the center of the node.
            /// </summary>
            public void Click()
            {
                Maui.Core.Mouse.Click(
                    this.left + (this.width / 2), 
                    this.top + (this.height / 2));
            }

            /// <summary>
            /// Method to click on a diagram node using the specified
            /// click-type and mouse flags.
            /// </summary>
            /// <param name="clickType">Type of click, e.g. single or double</param>
            /// <param name="flags">Flags for mouse button, e.g. left, right or center</param>
            public void Click(Maui.Core.MouseClickType clickType, Maui.Core.MouseFlags flags)
            {
                Maui.Core.Mouse.Click(
                    clickType,
                    flags,
                    this.left + (this.width / 2),
                    this.top + (this.height / 2));
            }

            /// <summary>
            /// Method to click and drag a diagram node to a new location.
            /// </summary>
            /// <param name="newX">New x-coordinate</param>
            /// <param name="newY">New y-coordinate</param>
            public void ClickDrag(int newX, int newY)
            {
                Maui.Core.Mouse.ClickDrag(
                    this.left + (this.width / 2),
                    this.top + (this.height / 2),
                    newX,
                    newY);
            }

            #endregion // Public Methods
        }
        #endregion // DiagramNode Class

        #region DiagramNodeNotFoundException Class

        /// <summary>
        /// Exception class for failure to find a node in a diagram
        /// </summary>
        public sealed class DiagramNodeNotFoundException : MauiException 
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public DiagramNodeNotFoundException()
                : base()
            {
                // default constructor
            }

            /// <summary>
            /// Default message constructor
            /// </summary>
            /// <param name="message">Message text</param>
            public DiagramNodeNotFoundException(string message)
                : base(message)
            {
                // default message constructor
            }

            /// <summary>
            /// Default message constructor with an inner exception.
            /// This constructor is used when another exception caused
            /// one or more methods to fail to find a diagram node.
            /// </summary>
            /// <param name="message">Message text</param>
            /// <param name="innerException">Inner exception</param>
            public DiagramNodeNotFoundException(string message, SystemException innerException)
                : base(message, innerException)
            {
                // default message constructor with an inner exception
            }
        }
        #endregion // DiagramNodeNotFoundException Class
    }
}
