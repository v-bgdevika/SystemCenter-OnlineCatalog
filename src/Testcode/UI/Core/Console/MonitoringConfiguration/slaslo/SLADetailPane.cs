// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DetailPane.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
// 	Details Pane methods for SLA 
// </summary>
// <history>
// 	[dialac] 24OCT08: Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console DetailPane Interface
    /// </summary>
    public interface ISLADetailPane
    {
        /// <summary>
        /// Read-only property to access SLANameDetailPaneStaticControl
        /// </summary>
        StaticControl SLANameDetailPaneStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SLADescDetailPaneStaticControl
        /// </summary>
        StaticControl SLADescDetailPaneStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SLATargetDetailPaneStaticControl
        /// </summary>
        StaticControl SLATargetDetailPaneStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SLOInfo1DetailPaneStaticControl
        /// </summary>
        StaticControl SLOInfo1DetailPaneStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SLOInfo2DetailPaneStaticControl
        /// </summary>
        StaticControl SLOInfo2DetailPaneStaticControl
        {
            get;
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Detail Pane Class
    /// </summary>
    /// <history>
    /// 	[dialac] 24OCT08 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class SLADetailPane : DetailPane, ISLADetailPane
    {
        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// DetailPane Window
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public SLADetailPane(ConsoleApp app) :
            base(app)
        {
            Utilities.LogMessage("SLA DetailPane:: Constructor");
        }
        #endregion

        #region Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the DetailPane SLA Name of the currently loaded view.
        /// </summary>
        /// <returns>DetailPane SLA Name String</returns>
        /// <history>
        /// [dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string SLANameDetailPane
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.SLANameDetailPaneStaticControl);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the DetailPane SLA Description of the currently loaded view.
        /// </summary>
        /// <returns>DetailPane SLA Description String</returns>
        /// <history>
        /// [dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string SLADescriptionDetailPane
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.SLADescDetailPaneStaticControl);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the DetailPane SLA Target of the currently loaded view.
        /// </summary>
        /// <returns>DetailPane SLA Target String</returns>
        /// <history>
        /// [dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string SLATargetDetailPane
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.SLATargetDetailPaneStaticControl);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the DetailPane SLO1 Info (name + Type) of the currently loaded view.
        /// </summary>
        /// <returns>DetailPane SLO Info String</returns>
        /// <history>
        /// [dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string SLOInfo1DetailPane
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.SLOInfo1DetailPaneStaticControl);
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the DetailPane SLO2 Info (name + Type) of the currently loaded view.
        /// </summary>
        /// <returns>DetailPane SLO Info String</returns>
        /// <history>
        /// [dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string SLOInfo2DetailPane
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.SLOInfo2DetailPaneStaticControl);
            }
        }


        #endregion

        #region ISLADetailPane Controls Property

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the app. window's control properties together</value>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public new ISLADetailPane Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Control Properties
        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SLANameDetailPaneStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl ISLADetailPane.SLANameDetailPaneStaticControl
        {
            get
            {
                return new StaticControl(this, ControlIDs.SLANameDetailPaneStaticControl);
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SLADescDetailPaneStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl ISLADetailPane.SLADescDetailPaneStaticControl
        {
            get
            {
                return new StaticControl(this, ControlIDs.SLADescDetailPaneStaticControl);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SLATargetDetailPaneStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl ISLADetailPane.SLATargetDetailPaneStaticControl
        {
            get
            {
                return new StaticControl(this, ControlIDs.SLATargetDetailPaneStaticControl);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SLOInfo1DetailPaneStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl ISLADetailPane.SLOInfo1DetailPaneStaticControl
        {
            get
            {
                //try
                //{
                //    new StaticControl(
                //}
                //catch
                //{
                //}
                return new StaticControl(this, ControlIDs.SLOInfo1DetailPaneStaticControl);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SLOInfo2DetailPaneStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl ISLADetailPane.SLOInfo2DetailPaneStaticControl
        {
            get
            {
                return new StaticControl(this, ControlIDs.SLOInfo2DetailPaneStaticControl);
            }
        }
        #endregion

        #region Public Methods
       
        #endregion

        #region ControlIDs
        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[dialac] 24OCT08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for DetailPane SLA Name Static Control
            /// </summary>
            public const string SLANameDetailPaneStaticControl = "nameLabelText";

            /// <summary>
            /// Control ID for DetailPane SLA Description StaticControl
            /// </summary>
            public const string SLADescDetailPaneStaticControl = "descriptionTextLabel";

            /// <summary>
            /// Control ID for DetailPane SLA Target Static Control
            /// </summary>
            public const string SLATargetDetailPaneStaticControl = "targetTextLabel";

            /// <summary>
            /// Control ID for DetailPane SLO Info (Name + Type)Static Control
            /// </summary>
            public const string SLOInfo1DetailPaneStaticControl = "1507524";

            /// <summary>
            /// Control ID for DetailPane SLO Info (Name + Type) Static Controle
            /// </summary>
            public const string SLOInfo2DetailPaneStaticControl = "198596";

            //TODO - The numbers are the AutomationId for the list of SLOs that can vary in number. 
            //For now I'm creating 2 ControlIds because the test case is going to create 2 slos and 
            //verify the information for the 2. 
            //Future - find a solution (or create more sloinfo control Ids) when test case is haddle more 
            //then 2 slos. 
        }
        #endregion
    }
}
