// ---------------------------------------------------------------------------
// <copyright company="Microsoft" file="TreeView.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  TreeView
// </summary>
// <history>
//  [mbickle]  30JUN08: Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.Text;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using MauiWinControls = Maui.Core.WinControls;
    #endregion
    
    /// <summary>
    /// SC TreeView
    /// Inherits Maui.WinControls.TreeView.
    /// Addes extra support methods for manipulating TreeView controls.
    /// </summary>
    public class TreeView : MauiWinControls.TreeView
    {
        #region Constructors
        /// <summary>
        /// TreeView
        /// </summary>
        /// <param name="knownWindow">Known Window</param>
        public TreeView(Window knownWindow) : base(knownWindow)
        {
        }

        /// <summary>
        /// TreeView
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        public TreeView(Window parent, QID queryId)
            : base(parent, queryId)
        {
        }

        /// <summary>
        /// TreeView
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        public TreeView(Window parent, QID queryId, int timeout)
            : base(parent, queryId, timeout)
        {
        }

        /// <summary>
        /// TreeView
        /// </summary>
        /// <param name="parameters">Window Parameters</param>
        public TreeView(WindowParameters parameters) : base(parameters)
        {
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        //public new bool IsWpfElement
        //{
        //    get
        //    {
        //        if (this.ClassName.Equals("MicrosoftSilverlight", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            return true;
        //        }
        //        else 
        //        {
        //            return base.IsWpfElement;
        //        }
        //    }
        //}

        /// ------------------------------------------------------------------
        /// <summary>
        /// Expand the TreePath - MaxRetry = 1
        /// </summary>
        /// <param name="nodePath">Full path to Node</param>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <returns>TreeNode</returns>
        /// <history>
        /// [mbickle] 28SEP05 Using StringBuilder now.
        /// [mbickle] 12OCT05 Modified so if can't find node reset index and try again from the top.
        ///                   This was done because sometimes the nodes take a moment to become expandable.
        /// [mbickle] 22JUN06 Copied from NavPane class and made public so it can be used in other places.
        /// </history>
        /// ------------------------------------------------------------------
        public MauiWinControls.TreeNode ExpandTreePath(string nodePath)
        {
            return this.ExpandTreePath(nodePath, 1);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Expand the TreePath 
        /// </summary>
        /// <param name="nodePath">Full path to Node</param>
        /// <param name="maxRetry">Number of times to Try</param>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <returns>TreeNode</returns>
        /// <history>
        /// [mbickle] 28SEP05 Using StringBuilder now.
        /// [mbickle] 12OCT05 Modified so if can't find node reset index and try again from the top.
        ///                   This was done because sometimes the nodes take a moment to become expandable.
        /// [mbickle] 22JUN06 Copied from NavPane class and made public so it can be used in other places.
        /// </history>
        /// ------------------------------------------------------------------
        public MauiWinControls.TreeNode ExpandTreePath(string nodePath, int maxRetry)
        {
            Utilities.LogMessage("TreeView.ExpandTreePath::");

            MauiWinControls.TreeNode treeNode = null;
            char[] delimiter = Constants.PathDelimiter.ToCharArray();
            StringBuilder nodes = new StringBuilder();
            string[] treeNodes = null;

            // check if nodePath IsNullOrEmpty
            if (String.IsNullOrEmpty(nodePath))
            {
                throw new ArgumentNullException("nodePath", "TreeView.ExpandTreePath:: nodePath IsNullOrEmpty");
            }

            Utilities.LogMessage("TreeView.ExpandTreePath:: Split Path");
            treeNodes = nodePath.Split(delimiter);

            int retry = 0;
            int nodeFindRetry = 0;

            // Wait for TreeView to be ready.
            this.ScreenElement.WaitForReady();

            // Loop through the nodePath and expand the nodes
            for (int index = 0; index < treeNodes.Length; index++)
            {
                treeNode = null;
                nodes.Append(treeNodes[index]);
                Utilities.LogMessage("TreeView.ExpandTreePath:: Path: " + nodes);

                retry = 0;

                // Attempting to get NodeByPath and setting treeNode
                while (treeNode == null && retry < maxRetry)
                {
                    try
                    {
                        // If node has a PathDelimiter we'll use GetNodeByPath
                        if (nodes.ToString().Contains(Constants.PathDelimiter))
                        {
                            Utilities.LogMessage("TreeView.ExpandTreePath:: GetNodeByPath: '" + nodes.ToString() + "'");
                            treeNode = this.GetNodeByPath(nodes.ToString(), Constants.PathDelimiter, 1, false);
                            //handle caseSensitive
                            if (treeNode.Text.Equals("UNIX/Linux Computers"))
                            {
                                treeNode = this.GetNodeByPath(nodes.ToString(), Constants.PathDelimiter, 1, true);
                            }
                        }
                        else
                        {
                            // No PathDelimiter in Node so using basic Find.
                            Utilities.LogMessage("TreeView.ExpandTreePath:: Find node: " + nodes);
                            treeNode = this.Find(nodes.ToString(), 1, false);

                            //handle caseSensitive
                            if (treeNode.Text.Equals("UNIX/Linux Computers"))
                            {
                                treeNode = this.Find(nodes.ToString(), 1, true);
                            }
                        }
                    }
                    catch (MauiWinControls.TreeNode.Exceptions.InvalidFullPathException ex)
                    {
                        // Only Log if hit maxRetry to cut down on noise.
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("TreeView_ExpandTreePath_InvalidFullPathException");
                            Utilities.LogMessage("TreeView.ExpandTreePath:: TreeNode.Exceptions.InvalidFullpathException: " + ex);
                            Utilities.LogMessage("TreeView.ExpandTreePath:: retry: " + retry.ToString());
                        }

                        Sleeper.Delay(1000);
                    }
                    catch (MauiWinControls.TreeNode.Exceptions.NodeNotFoundException ex)
                    {
                        // Only Log if hit maxRetry to cut down on noise.
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("TreeView_ExpandTreePath_NodeNotFoundException");
                            Utilities.LogMessage("TreeView.ExpandTreePath:: TreeNode.Exceptions.NodeNotFoundException: " + ex);
                            Utilities.LogMessage("TreeView.ExpandTreePath:: retry: " + retry.ToString());
                        }

                        Sleeper.Delay(1000);
                    }

                    retry++;
                }

                // Check to make sure TreeNode isn't null
                if (treeNode == null && nodeFindRetry < maxRetry)
                {
                    Utilities.LogMessage("TreeView.ExpandTreePath:: treeNode == null, backing up to try again.");

                    // Tree Node is null, so increment retry count and try again.
                    nodeFindRetry++;

                    // Reset Index
                    index = -1;

                    // Clear what was already added.
                    nodes.Remove(0, nodes.Length);

                    if (nodeFindRetry == maxRetry)
                    {
                        Utilities.LogMessage("TreeView.ExandTreePath:: Node not found, hit max retry");
                        Utilities.TakeScreenshot("TreeView_ExpandTreePath_NodeNotFound");
                    }
                }
                else
                {
                    if (treeNode == null)
                    {
                        throw new MauiWinControls.TreeNode.Exceptions.NodeNotFoundException("TreeView.ExpandTreePath:: treeNode was null after max nodeFindRetry");
                    }

                    bool expanded = false;
                    retry = 0;

                    // Retry logic as sometimes we get a ChildNotFoundException here 
                    // when trying to expand tree node.
                    Utilities.LogMessage("TreeView.ExpandTreePath:: Expand TreeNode.");
                    while (!expanded && retry < maxRetry)
                    {
                        try
                        {
                            if (treeNode.IsExpandable)
                            {
                                Utilities.LogMessage("TreeView.ExpandTreePath: Expanding TreeNode");

                                treeNode.Expand(true);
                                this.ScreenElement.WaitForReady();

                                if (treeNode.Expanded)
                                {
                                    Utilities.LogMessage("TreeView.ExpandTreePath: TreeNode Expanded");
                                    expanded = true;
                                }
                            }
                            else
                            {
                                expanded = true;
                            }
                        }
                        catch (Maui.Core.ActiveAccessibility.Exceptions.ChildNotFoundException ex)
                        {
                            // Only Log if hit maxRetry to cut down on noise.
                            if (retry == maxRetry)
                            {
                                Utilities.TakeScreenshot("TreeView_ExpandTree_ChildNotFoundException");
                                Utilities.LogMessage("TreeView.ExpandTreePath:: ActiveAccessibility.Exception.ChildNotFound: " + ex);
                            }
                        }
                        catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException ex)
                        {
                            if (retry == maxRetry)
                            {
                                Utilities.TakeScreenshot("TreeView_ExpandTreePath_NodeNotFoundException");
                                Utilities.LogMessage("TreeView.ExpandTreePath:: NodeNotFoundException.Exception: " + ex);
                            }
                        }

                        Sleeper.Delay(1000);
                        Utilities.LogMessage("TreeView.ExpandTreePath:: Expand Node retry: " + retry.ToString());
                        retry++;
                    }

                    Utilities.LogMessage("TreeView.ExpandTreePath:: Wait for UI to settle.");
                    nodes.Append(Constants.PathDelimiter);
                    Utilities.LogMessage("TreeNode.ExpandTreePath::TreeNode=" + treeNode);
                }
            }

            return treeNode;
        }
    }
}
