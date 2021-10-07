using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mom.Test.UI.Core.Common;
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Test.ScCommon;
using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
using Infra.Frmwrk;

//using System.Linq;
//using System.Text;
//using Mom.Test.UI.Core.Console;
//using Mom.Test.UI.Core.Console.MomControls;
//using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
//using System.Windows.Automation;
//using Microsoft.EnterpriseManagement.Monitoring.DataProviders;

namespace Mom.Test.UI.Core.Console.MomControls.Dashboards
{
    internal struct ConnectionMapping
    {
        public MonitoringObject Connection;
        public MonitoringObject Endpoint1;
        public MonitoringObject Endpoint2;
    }

    public enum WidgetType
    {
        MapWidget,
        TopologyWidget
    }

    public abstract class WidgetBase : DashboardControls.Dashboard
    {
        #region Private Members

        #endregion

        protected WidgetBase(Window knownWindow)
            : base(knownWindow)
        {
            //TODO: Instantiated the widget common controls here.
        }

        #region Common Methods
        /// <summary>
        /// Abstract method
        /// </summary>
        public abstract void VerifyWidgetContent(Double topLatitude, Double bottomLatitude, Double leftLongitude, Double rightLongitude);

        /// <summary>
        /// zoom the widget to page
        /// </summary>
        /// <param name="zoom">If true, then zoom to page. otherwise no zoom</param>
        public void ZoomToPage(bool zoom)
        {
            //note: zoomToPageCheckBox is currently not used
            var zoomToPageCheckBox = new CheckBox(this, new QID(QIDs.QidZoomToPage)) {Checked = zoom};
        }

        /// <summary>
        /// Show computers
        /// </summary>
        /// <param name="show">If true, then show computers. otherwise don't show</param>
        public void ShowComputers(bool show)
        {
            //note: showComputersCheckBox is currently not used
            var showComputersCheckBox = new CheckBox(this, new QID(QIDs.QidShowComputers)) {Checked = show};
        }

        /// <summary>
        /// Set the number of hops the vicinity agent is using.
        /// </summary>
        /// <param name="hops">Number of hops to set vicnity agent to.</param>
        public void SetHops(int hops)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Export widget to image
        /// </summary>
        public void Export()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wait for widget loading completely
        /// </summary>
        public void WaitForWidgetReady()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region QIDs
        //TODO: update the QIDs of the controls if necessary
        public class QIDs
        {
            /// <summary>
            /// Zoom to page checkbox QID
            /// </summary>
            public const string QidZoomToPage = ";[UIA]AutomationId=\'ZoomToPageCheckBox\'";

            /// <summary>
            /// Show computers checkbox QID
            /// </summary>
            public const string QidShowComputers = ";[UIA]AutomationId=\'ShowComputersCheckBox\'";

            /// <summary>
            /// Number of hops text box QID
            /// </summary>
            public const string QidNumberOfHops = ";[UIA]AutomationId=\'NumberOfHops\'";

            /// <summary>
            /// MapWidget TreeView QID
            /// </summary>
            public const string QidMapWidgetTreeView = ";[UIA]AutomationId=\'NodeTreeView\'";

            /// <summary>
            /// Map TreeNode QID
            /// </summary>
            public const string QidMapTreeNode = ";[FindAll, UIA, VisibleOnly]ClassName=\'Image\'";
        }
        #endregion
    }

    public class MapWidget : WidgetBase
    {
        #region Privates Fields
        private readonly DiagramControl _diagramControl;
        private static readonly MachineInfo MomServer = (MachineInfo)Topology.MomServersInfo[0];
        private static readonly ManagementGroup Mg = Utilities.ConnectToManagementServer(MomServer.DNSMachineName);
        private static readonly ManagementPackRelationship ReferenceRelationship = 
            Mg.EntityTypes.GetRelationshipClass(new Guid(ManagementPackReferences.SYSTEM_REFERENCE_REFERENCE));

        #endregion

        public MapWidget(Window knownWindow)
            : base(knownWindow)
        {
            _diagramControl = new DiagramControl(knownWindow);
        }

        /// <summary>
        /// Verify the points properties such as latitude longtitude etc.
        /// </summary>
        public override void VerifyWidgetContent(
            Double topLatitude,
            Double bottomLatitude,
            Double leftLongitude,
            Double rightLongitude
            )
        {
            var nodesFromMap = _diagramControl.GetAllVisibleNodes();
            var nodeGuidsFromMap = CreateNodeGuidCollection(nodesFromMap);
            var numNodes = 0;
            if(nodeGuidsFromMap != null)
            {
                numNodes = nodeGuidsFromMap.Count;
            }

            Utilities.LogMessage("Number of nodes shown on map (less background node): " + (numNodes - 1)); //number of nodes less 1 (background 'node')
            var waitTime = 0;
            if (numNodes <= 1)
            {
                //if nodes not yet present on map (or map not yet displayed), poll for 30 seconds
                //temporarily changed to 60 to see if that avoids perf issue notes in _bug #219791
                const int maxWaitInSeconds = 300;
                nodesFromMap = _diagramControl.GetAllVisibleNodes();
                while (numNodes <= 1 && waitTime < maxWaitInSeconds)
                {
                    Utilities.TakeScreenshot(string.Format("MapWidget-{0}", DateTime.Now.ToString("yyyy-MM-dd HHmmss")));
                    nodesFromMap = _diagramControl.GetAllVisibleNodes();
                    nodeGuidsFromMap = CreateNodeGuidCollection(nodesFromMap);
                    if (nodeGuidsFromMap != null)
                    {
                        numNodes = nodeGuidsFromMap.Count;
                    }
                    waitTime += 5;
                    Sleeper.Delay(5000); //sleep five seconds before continuing to check again for nodes in Map
                }

                

                //after having waited until maxWaitInSeconds, if still no nodes present, throw VarFail
                if (numNodes <= 1)
                {
                    throw new VarFail((numNodes - 1) + " nodes found after waiting for " + waitTime + " seconds");
                }
                CompareMapNodes(nodeGuidsFromMap, topLatitude, bottomLatitude, leftLongitude, rightLongitude);
            }
            else
            {
                CompareMapNodes(nodeGuidsFromMap, topLatitude, bottomLatitude, leftLongitude, rightLongitude);
            }
        }

        private static List<Guid> CreateNodeGuidCollection(IEnumerable<DiagramControl.NodeControl> nodeControlList)
        {
            List<Guid> nodeGuidList = new List<Guid>();
            //for reference:
            foreach (DiagramControl.NodeControl node in nodeControlList)
            {
                string tmpStr = node.AutomationElement.Current.Name.Substring(node.AutomationElement.Current.Name.IndexOf("Id=") + 3, 36);
                var tmpGuid = new Guid(tmpStr);
                nodeGuidList.Add(tmpGuid);
            }
            return nodeGuidList;
            
            //equivalent LINQ expression:
            //return nodeControlList.Select(node => node.AutomationElement.Current.Name.Substring(node.AutomationElement.Current.Name.IndexOf("Id=") + 3, 36)).Select(tmpStr => new Guid(tmpStr)).ToList();
        }

        private bool CompareMapNodes(
            List<Guid> nodeIdsFromMap,
            Double topLatitude,
            Double bottomLatitude,
            Double leftLongitude,
            Double rightLongitude
            )
        {
            var nodeIdsFromDb = GetNodeIdsFromOpsDb();
            var nodeIdsConfirmedOnMap = AddNodesToConfirmedNodesList(nodeIdsFromMap, nodeIdsFromDb);
            FailIfNoNodesFoundOnMap(nodeIdsConfirmedOnMap);
            //FYI: at this point, nodeIdsConfirmedOnMap entries are confirmed to exist in OpsDB,
            //will not to be duplicated on the map, and will not include the background entry
            //as it does not get confirmed as being an inserted HS entity in the OpsDB; also,
            //they have not yet been confirmed as properly within the bounds of the current map

            //get Visualization MP
            const string configItemReferencesLocationRelationshipName = ManagementPackReferences.SYSTEM_CONFIGITEMREFERENCESLOCATION_REFERENCE;
            const string configItemToLocationProjectionName = "Microsoft.SystemCenter.Visualization.ConfigItemToLocation.Projection";
            const string visualizationLibraryMpName = "Microsoft.SystemCenter.Visualization.Library";
            var visualizationMp = GetVisualizationManagementPack(visualizationLibraryMpName);

            if (visualizationMp != null)
            {
                var connectionDictionary = new Dictionary<Guid, ConnectionMapping>();
                var locationsFoundByProjection = new Dictionary<Guid, MonitoringObject>();
                var configItemToLocationMpProjection = Mg.EntityTypes.GetTypeProjection(configItemToLocationProjectionName, visualizationMp);

                GetProjectionLocationForEachNodeInMap(configItemToLocationMpProjection, locationsFoundByProjection, connectionDictionary, configItemReferencesLocationRelationshipName, nodeIdsConfirmedOnMap);
                VerifyNumberOfEntitiesMatchesNumberOfLocations_IfNotLogAllEntities(locationsFoundByProjection, nodeIdsConfirmedOnMap);
                LogEntityNodesWithCorrespondingLocationNames(locationsFoundByProjection, nodeIdsConfirmedOnMap);

                var nodeIdsExpectedInCurrentMap = GetExpectedLocationsFromOpsDbBasedOnMapBoundaryValues(topLatitude,bottomLatitude,leftLongitude,rightLongitude);
                VerifyNumberOfExpectedNodesMatchesNumberOfConfirmedNodesFromMap(nodeIdsConfirmedOnMap, nodeIdsExpectedInCurrentMap);
                var nodeIdsConfirmedInExpectedSet = VerifyNodesFoundByProjectionMatchExpectedNodes(locationsFoundByProjection, nodeIdsExpectedInCurrentMap);
                VerifyExpectedNodesAndConfirmedNodesCountMatches(nodeIdsConfirmedOnMap, nodeIdsConfirmedInExpectedSet, nodeIdsExpectedInCurrentMap);

                return nodeIdsFromDb.Count >= nodeIdsFromMap.Count + 1;
            }
            return false;
        }

        private static List<Guid> GetNodeIdsFromOpsDb()
        {
            //get all nodes from Ops DB and populate list of guids
            const string getMapNodesQuery = "select * from BaseManagedEntity where Path like 'PrincipalName%'";

            DBUtil.ConnectToMOMDB(Topology.RootMomSdkServerName);
            DataView nodeQueryResults = DBUtil.ExecuteQueryWithResults(getMapNodesQuery);

            var mapNodes = new List<Guid>();
            if (nodeQueryResults != null && nodeQueryResults.Count > 0)
            {
                for (int i = 0; i < nodeQueryResults.Count; i++)
                {
                    var tmpGuid = new Guid((nodeQueryResults[i].Row[0]).ToString());

                    mapNodes.Add(tmpGuid);
                }
            }
            else
            {
                throw new Exception("No map node results from Ops DB - please investigate");
            }

            DBUtil.CloseMOMDBConnection();

            return mapNodes;
        }

        private static List<Guid> AddNodesToConfirmedNodesList(List<Guid> nodeIdsFromMap, List<Guid> nodeIdsFromDb)
        {
            var nodeIdsConfirmedOnMap = new List<Guid>();
            //where nodes from map exist in OpsDB (i.e. valid entities)
            Utilities.LogMessage("Verifying that nodes in map exist in Ops DB and are not duplicated");
            foreach (var guid in nodeIdsFromMap.Where(guid => nodeIdsFromDb.Contains(guid)))
            {
                //...verify node is not a duplicate entry in map
                if (nodeIdsConfirmedOnMap.Contains(guid))
                {
                    throw new Exception("Duplicate guid found in UI: " + guid);
                }

                //if valid and not a duplicate, add to list
                nodeIdsConfirmedOnMap.Add(guid);
            }
            return nodeIdsConfirmedOnMap;
        }
        
        private static void FailIfNoNodesFoundOnMap(List<Guid> nodeIdsConfirmedOnMap)
        {
            if (nodeIdsConfirmedOnMap.Count <= 1)
            {
                throw new VarFail("No nodes found on map");
            }
        }

        private static ManagementPack GetVisualizationManagementPack(string visualizationLibraryMpName)
        {
            ManagementPack visualizationMp = null;
            var mpList = Mg.ManagementPacks.GetManagementPacks();
            foreach (
                var managementPack in
                    mpList.Where(managementPack => managementPack.Name != null).Where(
                        managementPack => String.Compare(managementPack.Name, visualizationLibraryMpName) == 0))
            {
                visualizationMp = managementPack;
                break;
            }
            return visualizationMp;
        }

        private EnterpriseManagementObjectProjection GetProjection(ManagementGroup mgmtGroup,
            ManagementPackTypeProjection projection, Guid seedId)
        {
            IObjectProjectionReader<MonitoringObject> reader = GetProjection(mgmtGroup, projection, new List<Guid>(new[] { seedId }));
            if (reader.Count != 1)
            {
                return null;
            }
            return reader.GetData(0);
        }

        private IObjectProjectionReader<MonitoringObject> GetProjection(ManagementGroup mgmtGroup,
            ManagementPackTypeProjection projection, IEnumerable<Guid> seedIds)
        {
            string idValueCriteria = seedIds.Aggregate(string.Empty, (current, seedId) => current + string.Format(ProjectionCriteriaIdValue, seedId));
            string criteriaString = String.Format(ProjectionCriteriaById, idValueCriteria);
            var criteria = new ObjectProjectionCriteria(criteriaString, projection, mgmtGroup);
            var options = new ObjectQueryOptions(ObjectPropertyRetrievalBehavior.None)
            {
                ObjectRetrievalMode = ObjectRetrievalOptions.NonBuffered
            };

            return mgmtGroup.EntityObjects.GetObjectProjectionReader<MonitoringObject>(criteria, options);
        }

        private const string ProjectionCriteriaById = @"
            <Criteria xmlns=""http://Microsoft.EnterpriseManagement.Core.Criteria/"">
                <Expression>
                    <In>
                        <GenericProperty>Id</GenericProperty>
                        <Values>
                            {0}
                        </Values>
                    </In>
                </Expression>
            </Criteria>";

        private const string ProjectionCriteriaIdValue = @"<Value>{0}</Value>";

        private void GetProjectionLocationForEachNodeInMap(ManagementPackTypeProjection configItemToLocationMpProjection,
            IDictionary<Guid, MonitoringObject> locationsFound,
            Dictionary<Guid, ConnectionMapping> connectionDictionary,
            string configItemReferencesLocationRelationshipName,
            IEnumerable<Guid> nodeIdsConfirmedOnMap)
        {
            if (nodeIdsConfirmedOnMap == null) throw new ArgumentNullException("nodeIdsConfirmedOnMap");
            Utilities.LogMessage("Getting Projected Location for each Entity in map");
            foreach (var node in nodeIdsConfirmedOnMap)
            {
                EnterpriseManagementObjectProjection configItemToLocationObjectProjection = null;

                ManagementPackRelationship configItemReferencesLocationRelationship =
                    Mg.EntityTypes.GetRelationshipClass(new Guid(configItemReferencesLocationRelationshipName));

                configItemToLocationObjectProjection = GetProjection(Mg, configItemToLocationMpProjection, node);

                foreach (
                    var locationConnection in
                        configItemToLocationObjectProjection[configItemReferencesLocationRelationship.Target
                            ])
                {
                    AddLocationIfNotAlreadyAdded(node,
                        //configItemToLocationObjectProjection,
                        connectionDictionary,
                        locationConnection, 
                        locationsFound);
                }
            }
        }

        private static void AddLocationIfNotAlreadyAdded(Guid node,
            //EnterpriseManagementObjectProjection configItemToLocationObjectProjection,
            IDictionary<Guid, ConnectionMapping> connectionDictionary,
            IComposableProjection locationConnection,
            IDictionary<Guid, MonitoringObject> locationsFound)
        {
            if (connectionDictionary.ContainsKey(locationConnection.Object.Id)) return;
            locationsFound.Add(node, (MonitoringObject)locationConnection.Object);
        }

        private static void VerifyNumberOfEntitiesMatchesNumberOfLocations_IfNotLogAllEntities(
            ICollection<KeyValuePair<Guid, MonitoringObject>> locationsFound,
            ICollection<Guid> nodeIdsConfirmedOnMap)
        {
            Utilities.LogMessage("Verifying that all nodes found on map were valid nodes");
            if (locationsFound.Count != nodeIdsConfirmedOnMap.Count)
            {
                //only log information in case of a mismatch
                foreach (var guid in locationsFound)
                {
                    Utilities.LogMessage("Debugging: Locations found: " + guid);
                }
                foreach (var guid in nodeIdsConfirmedOnMap)
                {
                    Utilities.LogMessage("Debugging: Entities found: " + guid);
                }

                throw new VarFail("Locations not found for all nodes shown on map; investigate further...");
            }
        }

        private static void LogEntityNodesWithCorrespondingLocationNames(
            Dictionary<Guid, MonitoringObject> locationsFound,
            IEnumerable<Guid> nodeIdsConfirmedOnMap)
        {
            Utilities.LogMessage("Entities on map and associated locations:");
            foreach (var node in nodeIdsConfirmedOnMap)
            {
                if (locationsFound.Keys.Contains(node))
                {
                    Utilities.LogMessage("Node on map: " + node + " corresponds to " + "Location: " + locationsFound[node].Name);
                }
            }
        }

        private static List<Guid> GetExpectedLocationsFromOpsDbBasedOnMapBoundaryValues(
            double latitudeTop,
            double latitudeBottom,
            double longitudeLeft,
            double longitudeRight)
        {
            const string entityColumnName = "BaseManagedEntityId";
            const string longitudeColumnName = "Longitude_66A0755C_8AA3_C5E9_E85E_7794D32FC074";
            const string latitudeColumnName = "Latitude_D86A5093_7028_7C84_7DB7_79A0C5F2CB87";

            const string geoLocationQuery = "select " + entityColumnName + ", " + longitudeColumnName + ", " +
                                            latitudeColumnName + " from dbo.MT_System$GeoLocation";

            DBUtil.ConnectToMOMDB(Topology.RootMomSdkServerName);
            DataView locationQueryResults = DBUtil.ExecuteQueryWithResults(geoLocationQuery);

            var expectedNodes = new List<Guid>();
            Utilities.LogMessage("Identifying which locations lie within current map boundaries:");
            if (locationQueryResults != null && locationQueryResults.Count > 0)
            {
                for (var i = 0; i < locationQueryResults.Count; i++)
                {
                    var currentLongitude = Convert.ToDouble(locationQueryResults[i].Row[1]);
                    var currentLatitude = Convert.ToDouble(locationQueryResults[i].Row[2]);

                    if (longitudeLeft < longitudeRight)
                    {
                        if (currentLongitude > longitudeLeft && currentLongitude < longitudeRight
                            && currentLatitude > latitudeBottom && currentLatitude < latitudeTop)
                        {
                            Utilities.LogMessage("Debugging: Node within map boundaries: " +
                                (locationQueryResults[i].Row[0]));
                            AddToExpectedNodes(locationQueryResults, i, expectedNodes);
                        }
                        else
                        {
                            Utilities.LogMessage("Debugging: Node outside of map boundaries: " +
                                (locationQueryResults[i].Row[0]));
                        }
                    }
                    else //i.e. if wrapped beyond 180/-180
                    {
                        if (currentLongitude > longitudeLeft && (currentLongitude < 180 ||
                            (currentLongitude > -180 && currentLongitude < longitudeRight))
                            && currentLatitude > latitudeBottom && currentLatitude < latitudeTop)
                        {
                            AddToExpectedNodes(locationQueryResults, i, expectedNodes);
                        }
                        else if (currentLongitude < longitudeRight && (currentLongitude > -180 ||
                            (currentLongitude < 180 && currentLongitude > longitudeLeft))
                            && currentLatitude > latitudeBottom && currentLatitude < latitudeTop)
                        {
                            AddToExpectedNodes(locationQueryResults, i, expectedNodes);
                        }
                        else
                        {
                            Utilities.LogMessage("Debugging: Node outside of map boundaries: " +
                                (locationQueryResults[i].Row[0]));
                        }
                    }
                }
            }
            else
            {
                throw new Exception("No map node results from Ops DB - please investigate");
            }

            DBUtil.CloseMOMDBConnection();

            Utilities.LogMessage("Debugging: Total number of nodes expected to be in map: " + expectedNodes.Count);

            return expectedNodes;
        }

        private static void AddToExpectedNodes(
            DataView locationQueryResults,
            int i,
            ICollection<Guid> expectedNodes)
        {
            var tmpGuid = new Guid((locationQueryResults[i].Row[0]).ToString());
            //Utilities.LogMessage("Debugging: Expected node: " + tmpGuid);
            expectedNodes.Add(tmpGuid);
        }

        private static void VerifyNumberOfExpectedNodesMatchesNumberOfConfirmedNodesFromMap(
            ICollection nodeIdsConfirmedOnMap,
            ICollection nodeIdsExpectedInCurrentMap)
        {
            Utilities.LogMessage("Verifying that number of nodes found on map is the same as that expected based on geographical boundaries");
            if (nodeIdsExpectedInCurrentMap.Count != nodeIdsConfirmedOnMap.Count)
            {
                throw new VarFail("Number of expected nodes on map: " + nodeIdsExpectedInCurrentMap.Count +
                                  " inconsistent with actual number of nodes found on map: " + nodeIdsConfirmedOnMap.Count);
            }
            else
            {
                Utilities.LogMessage("Confirmed...");
            }
        }

        private static List<Guid> VerifyNodesFoundByProjectionMatchExpectedNodes(
            IEnumerable<KeyValuePair<Guid, MonitoringObject>> locationsFoundByProjection,
            ICollection<Guid> nodeIdsExpectedInCurrentMap)
        {
            var nodeIdsConfirmedInExpectedSet = new List<Guid>();
            Utilities.LogMessage("Verifying that locations associated with entities in map correspond with locations expected to be in map, based on geographic boundaries:");
            foreach (var expectedNodeGuid in locationsFoundByProjection)
            {
                Utilities.LogMessage("Debugging: LocationFoundByProjection: " + expectedNodeGuid.Value.Id + ", name: " +
                    expectedNodeGuid.Value.Name + ", entity association: " + expectedNodeGuid.Key);
                if (!IsExpectedMapNodeFound(nodeIdsConfirmedInExpectedSet, expectedNodeGuid.Value.Id, nodeIdsExpectedInCurrentMap))
                {
                    throw new VarFail("Expected node: " + expectedNodeGuid.Value.Id + "not in locations found collection");
                }
                continue;
            }
            return nodeIdsConfirmedInExpectedSet;
        }

        private static bool IsExpectedMapNodeFound(
            ICollection<Guid> nodeIdsConfirmedInExpectedSet,
            Guid expectedNodeGuid,
            ICollection<Guid> nodeIdsExpectedInCurrentMap)
        {
            if (!nodeIdsExpectedInCurrentMap.Contains(expectedNodeGuid))
            {
                return false;
            }
            
            //verify node is not duplicate
            if (nodeIdsConfirmedInExpectedSet.Contains(expectedNodeGuid))
            {
                throw new Exception("Duplicate guid found in expected set of locations: " + expectedNodeGuid);
            }

            //if node has valid Id, and is not a dupe, add to list
            nodeIdsConfirmedInExpectedSet.Add(expectedNodeGuid);
            return true;
        }

        private static void VerifyExpectedNodesAndConfirmedNodesCountMatches(
            ICollection nodeIdsConfirmedOnMap,
            ICollection nodeIdsConfirmedInExpectedSet,
            ICollection nodeIdsExpectedInCurrentMap)
        {
            if (nodeIdsExpectedInCurrentMap.Count != nodeIdsConfirmedInExpectedSet.Count)
            {
                throw new VarFail("Number of expected nodes on map: " + nodeIdsExpectedInCurrentMap.Count +
                                  " inconsistent with actual number of nodes found on map: " + nodeIdsConfirmedOnMap.Count);
            }
            else
            {
                Utilities.LogMessage("Verified that projected locations correspond to (are equal in number, with no duplicates) the expected nodes, based on map geographic boundaries - PASS " +
                                     nodeIdsConfirmedInExpectedSet.Count);
            }
        }

        /*
        private MonitoringObject GetEndpointFromConnection(ManagementPackRelationship relationship,
            IComposableProjection locationConnection,
            IDictionary<Guid, MonitoringObject> locationsFound,
            bool computersOnly) //_note: computersOnly is currently not used
        {
            MonitoringObject endpoint = null;

            // Find the port connected on the other side (the right) of the Connection
            foreach (IComposableProjection location in locationConnection[relationship.Target])
            {
                // Find the associated location
                endpoint = GetHosts((MonitoringObject)location.Object);

                if (endpoint != null)
                {
                    // Add this to the locationsFound
                    locationsFound.Add(endpoint.Id, endpoint);
                }
            }

            return endpoint;
        }

        private static MonitoringObject GetHosts(MonitoringObject networkAdapter)
        {
            EnterpriseManagementGroup enterpriseManagementGroup = networkAdapter.ManagementGroup;
            IList<EnterpriseManagementRelationshipObject<MonitoringObject>> hostingrelationships =
                enterpriseManagementGroup.EntityObjects.GetRelationshipObjectsWhereTarget<MonitoringObject>(
                    networkAdapter.Id,
                    ReferenceRelationship,
                    DerivedClassTraversalDepth.Recursive,
                    TraversalDepth.OneLevel,
                    ObjectQueryOptions.Default);

            if (hostingrelationships.Count != 1)
            {
                return null;
            }

            return hostingrelationships[0].SourceObject;
        }
        */

        #region QIDs
        /// <summary>
        /// Gets access to the MapWigetTreeView resource qid string
        /// </summary>
        public static QID MapWidgetTreeViewQid
        {
            get
            {
                return new QID(QIDs.QidMapWidgetTreeView);
            }
        }
        #endregion

        #region constants
        internal const string AccountName = "asttest";
        internal const string DomainName = "SMX";
        internal const string ConfigFilesLocation = @"\..\..\MOMCommon\ConfigFiles";
        internal const string EntityLocationRelationshipTypeName = "System!System.ConfigItemReferencesLocation";
        #endregion
    }

    public class WidgetTest
    {
        #region Private Members
        private WidgetBase _widget;
        private readonly WidgetType _widgetType;

        #endregion
        //Catch the MapWidget View
        public ListView MapWidgetTreeView
        {
            get
            {
                return new ListView(CoreManager.MomConsole.ViewPane, MapWidget.MapWidgetTreeViewQid);
            }
        }
        //Catch the Location
        MauiCollection<IScreenElement> MapTreeNodes
        {
            get
            {
                return MapWidgetTreeView.ScreenElement.FindAllDescendants(-1, WidgetBase.QIDs.QidMapTreeNode, null);
            }
        }
        #region Constructor
        public WidgetTest(WidgetType type)
        {
            _widgetType = type;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Navigate to the widget view
        /// </summary>
        /// <param name="consoleApp">Mom console appication</param>
        /// <param name="widgetViewName">widget view name</param>
        public void OpenWidget(MomConsoleApp consoleApp, String widgetViewName)
        {

            consoleApp.NavigationPane.SelectNode(widgetViewName, NavigationPane.NavigationTreeView.Monitoring);

            switch (_widgetType)
            {
                case WidgetType.MapWidget:
                    _widget = new MapWidget(consoleApp.MainWindow);
                    break;
                case WidgetType.TopologyWidget:
                    break;
                default:
                    break;
            }
        }

        public void VerifyWidgetContent(Double topLatitude, Double bottomLatitude, Double leftLongitude, Double rightLongitude)
        {
            if (_widget != null)
                _widget.VerifyWidgetContent(topLatitude, bottomLatitude, leftLongitude, rightLongitude);
        }

        public bool VerifyNodeProperties()
        {
            const bool retVal = false;

            Utilities.LogMessage(MapTreeNodes == null ? "MapTreeNodes == null" : "MapTreeNodes != null");

            if (MapTreeNodes != null)
                foreach (var screenElement in MapTreeNodes)
                {
                    Utilities.LogMessage("screenElement.Accessible: " + screenElement.Accessible);
                    Utilities.LogMessage("screenElement.AttachMethod: " + screenElement.AttachMethod);
                    Utilities.LogMessage("screenElement.AutomationElement: " + screenElement.AutomationElement);
                    Utilities.LogMessage("screenElement.ChildId: " + screenElement.ChildId);
                    Utilities.LogMessage("screenElement.ClassName: " + screenElement.ClassName);
                    Utilities.LogMessage("screenElement.HasFocus: " + screenElement.HasFocus);
                    Utilities.LogMessage("screenElement.IdentificationString: " + screenElement.IdentificationString);
                    Utilities.LogMessage("screenElement.IsEnabled: " + screenElement.IsEnabled);
                    Utilities.LogMessage("screenElement.IsVisible: " + screenElement.IsVisible);
                    Utilities.LogMessage("screenElement.Name: " + screenElement.Name);
                    Utilities.LogMessage("screenElement.Parent: " + screenElement.Parent);
                    Utilities.LogMessage("screenElement.State: " + screenElement.State);
                    Utilities.LogMessage("screenElement.Value: " + screenElement.Value);
                }

            return retVal;
        }

        public bool VerifyToolTips()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::start...");
            //Get the MapWidget Tree View

            //TreeNode locationNode = null;
            Utilities.LogMessage(MapTreeNodes == null ? "MapTreeNodes == null" : "MapTreeNodes != null");
            if (MapTreeNodes != null)
            {
                Utilities.LogMessage("Number of Location" + MapTreeNodes.Count);
                Utilities.LogMessage("MapTreeNodes" + MapTreeNodes);
                Utilities.LogMessage("IsMapTreeNodes[0]Enabled:" + MapTreeNodes[0].IsEnabled);
                Utilities.LogMessage(MapTreeNodes[0].Accessible == null
                                         ? "Map Tree Node Accessible is null"
                                         : "Map Tree Node Accessible is not null");

                #region Check the properties - Check the property which one relate to Tooltips
                //Utilities.LogMessage("IdentificationString" + this.MapTreeNodes[0].IdentificationString);
                //Utilities.LogMessage("Name" + this.MapTreeNodes[0].Name);
                //Utilities.LogMessage("RuntimeId" + this.MapTreeNodes[0].RuntimeId);
                //Utilities.LogMessage("Value" + this.MapTreeNodes[0].Value);
                //Utilities.LogMessage("FrameworkId" + this.MapTreeNodes[0].FrameworkId);
                //Utilities.LogMessage("AutomationElement" + this.MapTreeNodes[0].AutomationElement);
                //Utilities.LogMessage("accHelp" + this.MapTreeNodes[0].Accessible.accHelp); //Accessible is null
                //Utilities.LogMessage("accName" + this.MapTreeNodes[0].Accessible.accName);
                //Utilities.LogMessage(this.MapTreeNodes[0].Accessible.accHelp.ToString());
                //Utilities.LogMessage(MapTreeNodes[0].AutomationElement.ToString());

                //string[] toolTips = null;

                #endregion 
                #region Mouse Over the location then get the tooltips

                for (int locationTemp = 0; locationTemp < MapTreeNodes.Count; locationTemp++)
                {
                    Utilities.LogMessage("This is the check for the " + locationTemp + 1 + " Location");
                    System.Drawing.Point coordinate = MapTreeNodes[locationTemp].GetClickablePoint();
                    //MapTreeNodes[locationTemp].LeftButtonClick(coordinate.X, coordinate.Y);
                    MapTreeNodes[locationTemp].MoveMouse(coordinate.X, coordinate.Y);
                    Utilities.LogMessage("Got the coordinate: X= " + coordinate.X + " Y=" + coordinate.Y);
                    //Sleeper.Delay(ToolTip.DefaultWaitTimeout);
                    //MapTreeNodes[locationTemp].WaitForGone(ToolTip.DefaultWaitTimeout,Constants.OneSecond);
                    
                    //note: tooltip1 is currently not used
                    var tooltip1 = new ToolTip(coordinate.X, coordinate.Y, Control.DefaultTimeout);
                    var tooltip = new ToolTip(coordinate, Window.DefaultWaitTimeout);
                    Utilities.LogMessage("The tool tip is not null!");
                    Utilities.LogMessage("The " + locationTemp + "Location's Tooltip is: " + tooltip);
                    Utilities.LogMessage("The " + locationTemp + "Location's Tooltip is: " + tooltip.Caption);
                    Utilities.LogMessage("The " + locationTemp + "Location's Tooltip is: " + tooltip.HelpText);
                    Utilities.LogMessage("The " + locationTemp + "Location's Tooltip is: " + tooltip.Text);
                    Utilities.LogMessage("The " + locationTemp + "Location's Tooltip is: " + tooltip.ClassName);
                    Utilities.LogMessage("The " + locationTemp + "Location's Tooltip is: " + tooltip.Extended);
                }
            }

            #endregion

            return true;
        }

        #endregion
    }
}
