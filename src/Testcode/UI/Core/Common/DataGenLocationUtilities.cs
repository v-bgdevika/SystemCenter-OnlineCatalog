//-------------------------------------------------------------------
// <copyright file="MapWidgetDataGeneration.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  MapWidgetDataGeneration class
// </summary>
//  <history>
//  [starrpar] 21MAR11:  Created
//  </history>
//-------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Test.DataGeneration;
using Microsoft.EnterpriseManagement.Test.DataGeneration.OperationsManager;
using Microsoft.EnterpriseManagement.Test.ScCommon;
using Mom.Test.UI.Core.Common;
using Infra.Frmwrk;

namespace Mom.Test.UI.Core.Common
{

    #region Location class
    public class Location
    {
        #region Public Properties

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }

        #endregion

        #region Private Fields

        string id;
        double longitude;
        double latitude;
        
        #endregion
    };

    #endregion //end Location class

    #region MapWidgetDataGeneration class

    /// <summary>
    /// This class encapsulates Map Widget Targets behavior
    /// </summary>
    public class DataGenerationMapUtilities
    {
        #region Properties

        public List<string> LocationStringsFromVarmap
        {
            get
            {
                return locationStringsFromVarmap;
            }
            set
            {
                locationStringsFromVarmap = value;
            }
        }
        public List<Location> LocationsFromVarmap
        {
            get
            {
                return locationsFromVarmap;
            }
            set
            {
                locationsFromVarmap = value;
            }
        }
        public List<Location> LocationList
        {
            get
            {
                return locationList;
            }
            set
            {
                locationList = value;
            }
        }
        public List<Entity> LocationEntityList
        {
            get
            {
                return locationEntityList;
            }
            set
            {
                locationEntityList = value;
            }
        }
        public List<Entity> AgentEntityList
        {
            get
            {
                return agentEntityList;
            }
            set
            {
                agentEntityList = value;
            }
        }
        public List<Relationship> RelationshipList
        {
            get
            {
                return relationshipList;
            }
            set
            {
                relationshipList = value;
            }
        }

        public int LocationIndex
        {
            get
            {
                return locationIndex;
            }
            set
            {
                locationIndex = value;
            }
        }

        internal EnterpriseManagementGroup ManagementGroup
        {
            get;
            private set;
        }

        #endregion

        #region Private Fields

        public delegate List<Entity> GenerateLocationsDelegate(DataGenerationEngine engine, int numLocations);

        private List<string> locationStringsFromVarmap;
        private List<Location> locationsFromVarmap;
        private List<Location> locationList;
        private List<Entity> locationEntityList;
        private int locationIndex = 0;
        private List<Entity> agentEntityList;
        private List<Relationship> relationshipList;

        #endregion

        #region private constructor with static creation method
        private DataGenerationMapUtilities()
        {

        }

        public static DataGenerationMapUtilities CreateDataGenerationMapUtilities()
        {
            return new DataGenerationMapUtilities();
        }
        #endregion

        #region Data Generation methods

        #region Sample code for use of MomCommon DG simplification methods

        public void GenerateDataGenEntities(DataGenerationEngine engine, int numLocations, string placementAlgorithm, string stateType)
        {
            DataGenPrep(engine);
            LocationEntityList = GenerateLocationEntities(engine, placementAlgorithm, numLocations);
            AgentEntityList = GenerateHealthServiceEntities(engine, LocationEntityList.Count);
            PrepareEntitiesToSetState();
            SetStateValues(engine, AgentEntityList, stateType);
            RelationshipList = GenerateRelationships(engine, AgentEntityList, LocationEntityList);
        }

        public void RemoveDataGenEntities(DataGenerationEngine engine)
        {
            RemoveRelationshipEntities(engine);
            RemoveLocationEntities(engine);
            RemoveHealthServiceEntities(engine);
        }

        private void PrepareEntitiesToSetState()
        {
            string verifyIfAlreadyAddedToAvailabilityQuery = "select COUNT(*) from Availability as A WHERE BaseManagedEntityId IN (select BaseManagedEntityId from BaseManagedEntity where DisplayName like 'Agent%')";
            string addToAvailabilityQuery = "INSERT Availability (BaseManagedEntityId) select BaseManagedEntityId from BaseManagedEntity where DisplayName like 'Agent%'";
            string updateAvailabilityQuery = "UPDATE Availability SET IsAvailable = 1, LastModified = CURRENT_TIMESTAMP WHERE BaseManagedEntityId IN ( select BaseManagedEntityId from BaseManagedEntity where DisplayName like 'Agent%')";

            DBUtil.ConnectToMOMDB(Topology.RootMomSdkServerName);
            int numRecords = Convert.ToInt32(DBUtil.ExecuteScalarQuery(verifyIfAlreadyAddedToAvailabilityQuery));
            if (numRecords <= 0)
            {
                DBUtil.ExecuteScalarQuery(addToAvailabilityQuery);
                DBUtil.ExecuteScalarQuery(updateAvailabilityQuery);
            }
            DBUtil.CloseMOMDBConnection();
        }

        private void SetStateValues(DataGenerationEngine engine, List<Entity> agents, string stateType)
        {
            if (stateType.ToLower().Equals(Constants.Random))
                RandomEntityStates(engine, agents);
            else if (stateType.ToLower().Equals(Constants.Green))
                EntityStates_Green(engine, agents);
            else if (stateType.ToLower().Equals(Constants.Yellow))
                EntityStates_Yellow(engine, agents);
            else if (stateType.ToLower().Equals(Constants.Red))
                EntityStates_Red(engine, agents);
        }

        #region data gen prep
        public void DataGenPrep(DataGenerationEngine engine)
        {
            DataGenUtil.DataGenInitialize(engine, ManagementGroup, Constants.ConfigFilesLocation, Constants.AccountName, Constants.DomainName);
        }
        #endregion

        #region generate health service entities
        public List<Entity> GenerateHealthServiceEntities(DataGenerationEngine engine, int numAgents)
        {
            List<KeyValuePair<string, object>> healthServiceProperties = GenerateHealthServiceProperties();
            return DataGenUtil.GenerateAgentEntityList(engine, ManagementGroup, numAgents, healthServiceProperties);
        }

        private static List<KeyValuePair<string, object>> GenerateHealthServiceProperties()
        {
            List<KeyValuePair<string, object>> healthServiceProperties = new List<KeyValuePair<string, object>>();

            KeyValuePair<string, object> displayName = new KeyValuePair<string, object>(Constants.DisplayNameProperty, Constants.Agent);
            KeyValuePair<string, object> isAgent = new KeyValuePair<string, object>(Constants.IsAgentProperty, true);

            healthServiceProperties.Add(displayName);
            healthServiceProperties.Add(isAgent);
            return healthServiceProperties;
        }
        #endregion

        #region set entity state methods
        public void RandomEntityStates(DataGenerationEngine engine, List<Entity> agents)
        {
            Random random = new Random();
            double healthSelector = 0;

            var configContainer = engine.ConfigContainers.GetConfigContainerByName(Constants.SystemHealthLibraryConfigContainerName);

            foreach (Entity entity in agents)
            {
                var oldHealthState = MonitorHealthState.Uninitialized;
                var newHealthState = MonitorHealthState.Uninitialized;

                //simple algorithm to randomly set 1 of 3 states
                healthSelector = random.NextDouble() * 3;
                if (healthSelector < 1)
                {
                    newHealthState = MonitorHealthState.Success;
                }
                else if (healthSelector >= 1 && healthSelector < 2)
                {
                    newHealthState = MonitorHealthState.Warning;
                }
                else if (healthSelector >= 2 && healthSelector < 3)
                {
                    newHealthState = MonitorHealthState.Error;
                }

                entity.CreateStateChange(oldHealthState, newHealthState, DateTime.UtcNow, configContainer, Constants.SystemHealthEntityStateMonitorName);
            }

            engine.FlushPendingData();
        }

        public void EntityStates_Green(DataGenerationEngine engine, List<Entity> agents)
        {
            DataGenUtil.SetEntityState(engine, Constants.SystemHealthLibraryConfigContainerName,
                Constants.SystemHealthEntityStateMonitorName, agents, MonitorHealthState.Uninitialized, MonitorHealthState.Success);
        }

        public void EntityStates_Yellow(DataGenerationEngine engine, List<Entity> agents)
        {
            DataGenUtil.SetEntityState(engine, Constants.SystemHealthLibraryConfigContainerName,
                Constants.SystemHealthEntityStateMonitorName, agents, MonitorHealthState.Uninitialized, MonitorHealthState.Warning);
        }

        public void EntityStates_Red(DataGenerationEngine engine, List<Entity> agents)
        {
            DataGenUtil.SetEntityState(engine, Constants.SystemHealthLibraryConfigContainerName,
                Constants.SystemHealthEntityStateMonitorName, agents, MonitorHealthState.Uninitialized, MonitorHealthState.Error);
        }
        #endregion

        #region generate relationships
        public List<Relationship> GenerateRelationships(DataGenerationEngine engine, List<Entity> agents, List<Entity> locations)
        {
            return DataGenUtil.CreateRelationships(engine, Constants.SystemConfigContainerName, Constants.EntityLocationRelationshipTypeName, agents, locations);
        }
        #endregion

        #region test scenario
        public void CreateEntitiesAndRelationships(DataGenerationEngine engine, int numEntities)
        {
            List<Entity> agents = CreateEntities(engine, Constants.WindowsLibraryConfigContainerName, numEntities, Constants.WindowsComputerEntityTypeName);
            DataGenUtil.SetEntityState(engine, Constants.SystemHealthLibraryConfigContainerName, Constants.SystemHealthEntityStateMonitorName, agents, MonitorHealthState.Uninitialized, MonitorHealthState.Success);
            List<Entity> locations = CreateEntities(engine, Constants.SystemConfigContainerName, numEntities, Constants.LocationEntityTypeName);
            DataGenUtil.CreateRelationships(engine, Constants.SystemCenterLibraryConfigContainerName, Constants.HealthServiceManagesEntityRelationshipTypeName, agents, locations);
        }

        public static List<Entity> CreateEntities(DataGenerationEngine engine,
            string MPName, int numberOfEntities, string entityTypeName)
        {
            ConfigContainer configContainerName = engine.ConfigContainers.GetConfigContainerByName(MPName, DataGenerationEngine.DefaultPublicKeyToken);
            EntityType entityType = engine.EntityTypes.GetEntityTypeByName(configContainerName, entityTypeName);
            List<Relationship> relationships = new List<Relationship>();

            List<Entity> Entities = new List<Entity>();

            for (int i = 0; i < numberOfEntities; i++)
            {
                Entity entityInstance = entityType.CreateInstance();
                Entities.Add(entityInstance);
            }

            engine.FlushPendingData();

            return Entities;
        }
        #endregion
        #endregion

        #region Generate Location Entities - move to UICommon Utilities class

        #region base location calculation methods
        public List<Entity> GenerateLocationEntities(DataGenerationEngine engine, string placementAlgorithm, int numLocations)
        {
            //designate a delegate to execute my local algorithm and return a List<Entity> collection
            GenerateLocationsDelegate callBackLocationGeneratingAlgorithm;

            //assign an algorithm based on test area logic
            callBackLocationGeneratingAlgorithm = AssignAlgorithmToDelegate(placementAlgorithm);

            //invoke the delegate, executing whichever algorithm was assigned
            return callBackLocationGeneratingAlgorithm.Invoke(engine, numLocations);
        }

        private GenerateLocationsDelegate AssignAlgorithmToDelegate(string placementAlgorithm)
        {
            GenerateLocationsDelegate callBackLocationGenerationAlgorithm;

            string algorithm = placementAlgorithm.ToLower();
            if (algorithm.Equals(Constants.Random))
            {
                callBackLocationGenerationAlgorithm = new GenerateLocationsDelegate(GenerateRandomLocations);
            }
            else if (algorithm.Equals(Constants.Specific))
            {
                callBackLocationGenerationAlgorithm = new GenerateLocationsDelegate(GenerateSpecifiedLocations);
            }
            else if (algorithm.Equals(Constants.Linear))
            {
                callBackLocationGenerationAlgorithm = new GenerateLocationsDelegate(GenerateStructuredLocations);
            }
            else if (algorithm.Equals(Constants.Smile))
            {
                callBackLocationGenerationAlgorithm = new GenerateLocationsDelegate(GenerateSmileLocations);
            }
            else
            {
                throw new Exception("invalid placement algorithm type: " + algorithm);
            }

            return callBackLocationGenerationAlgorithm;
        }
        #endregion

        #region underlying location calculation methods
        private void CreateRandomLocations(int numLocations)
        {
            //get location parameters (id, longitude, latitude)
            //either using random or specific values (for all 3 params)
            //and complies list per numLocations value passed

            LocationList = new List<Location>();

            this.LocationIndex = 0;

            for (int i = 0; i < numLocations; i++)
            {
                Location location = SetRandomLocationParameters();
                LocationList.Add(location);
            }
        }

        private void CreateLinearLocations(int numLocations)
        {
            //get location parameters (id, longitude, latitude)
            //either using random or specific values (for all 3 params)
            //and complies list per numLocations value passed

            LocationList = new List<Location>();

            this.LocationIndex = 0;

            for (int i = 0; i < numLocations; i++)
            {
                Location location = SetLinearLocationParameters();
                LocationList.Add(location);
            }
        }

        private Location SetRandomLocationParameters()
        {
            //sets parameters (id, longitude, latitude)
            //either randomly or using specific values

            //Following are considerations in making use
            //of this location functionality generic enough
            //for others' purposes - may put this
            //in common code area (Utilities?)

            //TODO: may want to support specifying
            //such things as longitude/latitude increments,
            //starting longitude/latitude values and
            //id string length

            //Also, may want to specify values assigned
            //in specific (non-random) case

            Location location = new Location();
            KeyValuePair<double, double> locationParams;
            int minNameLength = 15;
            int maxNameLength = 35;

            location.Id = CreateRandomLocationName(minNameLength, maxNameLength);
            locationParams = CreateRandomLocationParameters();

            location.Longitude = locationParams.Key;
            location.Latitude = locationParams.Value;

            return location;
        }

        private Location SetLinearLocationParameters()
        {
            //sets parameters (id, longitude, latitude)
            //either randomly or using specific values

            //Following are considerations in making use
            //of this location functionality generic enough
            //for others' purposes - may put this
            //in common code area (Utilities?)

            //TODO: may want to support specifying
            //such things as longitude/latitude increments,
            //starting longitude/latitude values and
            //id string length

            //Also, may want to specify values assigned
            //in specific (non-random) case

            Location location = new Location();
            KeyValuePair<double, double> locationParams;
            int startingLongitude = -180;
            int startingLatitude = 0;
            double LongitudinalIncrement = 5;
            double LatitudinalIncrement = 5;

            location.Id = CreateLocationName(this.LocationIndex);
            locationParams = CreateLocationParameters(LongitudinalIncrement, LatitudinalIncrement,
                startingLongitude, startingLatitude, this.LocationIndex++);

            location.Longitude = locationParams.Key;
            location.Latitude = locationParams.Value;

            return location;
        }
        #endregion

        #region Node Layout Algorithms

        #region structured location parameter values

        //Comment: the purpose of the linear/structured algorithm for node placement is to be able to visually assess
        //if the longitude and latitude lines are correctly located

        private List<Entity> GenerateStructuredLocations(DataGenerationEngine engine, int numLocations)
        {
            EntityType locationType = engine.ConfigContainers[Constants.SystemConfigContainerName].
                EntityTypes[Constants.LocationEntityTypeName];

            //create list of locations
            CreateLinearLocations(numLocations);

            //generate locations in datagen (and insert into operational database)
            this.LocationEntityList = BuildLocationEntities(engine, locationType, LocationList);

            return this.LocationEntityList;
        }

        private string CreateLocationName(int index)
        {
            return "Location" + index;
        }

        private KeyValuePair<double, double> CreateLocationParameters(double longitudeIncrement, double latitudeIncrement,
            int startingLongitude, int startingLatitude, int index)
        {
            double longitude;
            double latitude;

            CreateLongitudeLatitudeValues(longitudeIncrement, latitudeIncrement, startingLongitude, startingLatitude,
                index, out longitude, out latitude);
            KeyValuePair<double, double> longitudeLatitudePair = new KeyValuePair<double, double>(longitude, latitude);

            return longitudeLatitudePair;
        }

        private void CreateLongitudeLatitudeValues(double specifiedLongitudeIncrement, double specifiedLatitudeIncrement,
            int startingLongitude, int startingLatitude, int index,
            out double longitude, out double latitude)
        {
            //Purpose: this is a quick, easy algorithm to get a lot of points/locations
            //plotted on the map widget for performance testing, while at the same time,
            //making it quick to review proper spacing of points on overall map, as this
            //places a node every 'specifiedLongitudeIncrement' degrees of longitude (and latitude),
            //so the map should show as being "evenly" distributed along latitudinal and longitudinal
            //lines (so easy to visually assess if spacing is correct and even E-W and N-S)

            int threeSixty = 360;
            int numberNodesPerLatitude = threeSixty / (int)specifiedLongitudeIncrement;
            int oneEighty = threeSixty / 2;
            int ninety = threeSixty / 4;
            int initialIndex = index;
            int multiplier;

            //keep index between 0 - 35
            while (index >= numberNodesPerLatitude)
            {
                index = index - numberNodesPerLatitude;
            }

            double longitudeIncrement = specifiedLongitudeIncrement * index;
            multiplier = initialIndex / numberNodesPerLatitude;
            double latitudeIncrement = specifiedLatitudeIncrement * multiplier;

            //add increment
            longitude = startingLongitude + longitudeIncrement;
            latitude = startingLatitude + latitudeIncrement;

            //if result exceeds limit, wrap around to negative region
            longitude = longitude > oneEighty ? longitude - threeSixty : longitude;
            if (latitude > oneEighty + 10)
            {
                latitude = latitude - oneEighty + 20;
            }
            else if (latitude > ninety)
            {
                latitude = latitude - oneEighty + 10;
            }
        }
        #endregion

        #region random location parameter values

        //Comment: the purpose of the random algorithm for node placement is for quickly placing
        //a large number of nodes (5000-10000) for performance testing

        private List<Entity> GenerateRandomLocations(DataGenerationEngine engine, int numLocations)
        {
            EntityType locationType = engine.ConfigContainers[Constants.SystemConfigContainerName].
                EntityTypes[Constants.LocationEntityTypeName];

            //create list of locations
            CreateRandomLocations(numLocations);

            //generate locations in datagen (and insert into operational database)
            this.LocationEntityList = BuildLocationEntities(engine, locationType, LocationList);

            return this.LocationEntityList;
        }

        private string CreateRandomLocationName(int minLength, int maxLength)
        {
            RandomStrings randomString = new RandomStrings();
            return randomString.CreateRandomString(minLength, maxLength);
        }

        private KeyValuePair<double, double> CreateRandomLocationParameters()
        {
            double longitude;
            double latitude;

            CreateRandomLongitudeLatitudeValues(out longitude, out latitude);
            KeyValuePair<double, double> longitudeLatitudePair = new KeyValuePair<double, double>(longitude, latitude);

            return longitudeLatitudePair;
        }

        /// <summary>
        /// simple concept for creating random location data
        /// - use a separate random seed:
        ///   - for negative/positive longitude
        ///   - for negative/positive latitude
        ///   - for value of longitude, scaled from 0 - 180
        ///   - for value of latitude, scaled from 0 - 90
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        private void CreateRandomLongitudeLatitudeValues(out double longitude, out double latitude)
        {
            int longitudeLimit = 180;
            int latitudeLimit = 90;
            Random randomValue = new Random();
            int negativeOrPositiveLongitudeDecider = (randomValue.NextDouble() * 2) > 1 ? 1 : -1;
            int negativeOrPositiveLatitudeDecider = (randomValue.NextDouble() * 2) > 1 ? 1 : -1;
            longitude = negativeOrPositiveLongitudeDecider * longitudeLimit * randomValue.NextDouble();
            latitude = negativeOrPositiveLatitudeDecider * latitudeLimit * randomValue.NextDouble();
        }
        #endregion

        #region specify locations in varmap

        //Comment: the purpose of the specific algorithm for node placement is to be able to visually assess
        //if the individual placement of nodes in all parts of the map are accurate

        private List<Entity> GenerateSpecifiedLocations(DataGenerationEngine engine, int numLocations)
        {
            List<string> LocationStringsFromVarmap = new List<string>();
            List<Location> LocationsFromVarmap = new List<Location>();
            List<Entity> LocationEntityList = new List<Entity>();

            LocationStringsFromVarmap = ReadLocationsFromVarmap();
            LocationsFromVarmap = ParseLocationStrings(LocationStringsFromVarmap);

            EntityType locationType = engine.ConfigContainers[Constants.SystemConfigContainerName].
                EntityTypes[Constants.LocationEntityTypeName];

            LocationEntityList = BuildLocationEntities(engine, locationType, LocationsFromVarmap);

            return LocationEntityList;
        }

        public List<string> ReadLocationsFromVarmap()
        {
            Infra.Frmwrk.IContext ctx = Mom.Test.UI.Core.Common.Mcf.FrameworkContext;

            List<string> LocationStringsFromVarmap = new List<string>();

            string[] locationStrings = null;
            if (ctx.FncRecords.HasKey(Constants.Location))
                locationStrings = ctx.FncRecords.GetValues(Constants.Location);

            foreach (string locationString in locationStrings)
            {
                if (locationString != null)
                {
                    LocationStringsFromVarmap.Add(locationString);
                }
            }
            return LocationStringsFromVarmap;
        }

        public List<Location> ParseLocationStrings(List<string> LocationStringsFromVarmap)
        {
            string[] stringArray = null;
            Location location;
            List<Location> LocationsFromVarmap = new List<Location>();

            //int numLocations = 0;
            foreach (string s in LocationStringsFromVarmap)
            {
                if (s != null) //if non-null, assume proper formatting -- <rec key="Location">Seattle,-122.255859,47.576526</rec>
                {
                    stringArray = s.Split(',');
                }
                location = new Location();
                location.Id = stringArray[0];
                location.Longitude = Convert.ToDouble(stringArray[1]);
                location.Latitude = Convert.ToDouble(stringArray[2]);
                LocationsFromVarmap.Add(location);
                //numLocations++;
            }

            //MapWidget.NumAgents = numLocations;

            return LocationsFromVarmap;
        }

        #endregion

        #region Smile algorithm

        //Comment: the purpose of this smile algorithm for node placement is to be able to place nodes
        //in such a way as to make a smile face on the map, using location nodes

        private List<Entity> GenerateSmileLocations(DataGenerationEngine engine, int numLocations)
        {
            EntityType locationType = engine.ConfigContainers[Constants.SystemConfigContainerName].
                EntityTypes[Constants.LocationEntityTypeName];

            //create list of locations
            int numPoints = CreateSmileLocations();
            if (numLocations != numPoints)
                Utilities.LogMessage("Incorrect number of points indicated in varmap: " + numLocations +
                    ", whereas total number of points in smile face = " + numPoints);

            //generate locations in datagen (and insert into operational database)
            this.LocationEntityList = BuildLocationEntities(engine, locationType, LocationList);

            return this.LocationEntityList;
        }

        private int CreateSmileLocations()
        {
            LocationList = new List<Location>();

            List<string> locationNames = new List<string>();

            List<KeyValuePair<double, double>> faceLongitudeLatitudePairings = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> smileLongitudeLatitudePairings = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> rightEyeLongitudeLatitudePairings = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> leftEyeLongitudeLatitudePairings = new List<KeyValuePair<double, double>>();

            int numFacePoints = 72;
            int faceRadius = 50;
            int numSmilePoints = 72;
            int smileRadius = 35;
            int numRightEyePoints = 12;
            int rightEyeRadius = 5;
            int numLeftEyePoints = 12;
            int leftEyRadius = 5;
            int minNameLength = 15;
            int maxNameLength = 35;

            faceLongitudeLatitudePairings = CreateFaceLongitudeLatitudeValues(numFacePoints, faceRadius);
            smileLongitudeLatitudePairings = CreateSmileLongitudeLatitudeValues(numSmilePoints, smileRadius);
            rightEyeLongitudeLatitudePairings = CreateRightEyeLongitudeLatitudeValues(numRightEyePoints, rightEyeRadius);
            leftEyeLongitudeLatitudePairings = CreateLeftEyeLongitudeLatitudeValues(numLeftEyePoints, leftEyRadius);

            int totalNumberOfPoints = faceLongitudeLatitudePairings.Count + smileLongitudeLatitudePairings.Count +
                rightEyeLongitudeLatitudePairings.Count + leftEyeLongitudeLatitudePairings.Count;

            locationNames = CreateSmileLocationNames(minNameLength, maxNameLength, totalNumberOfPoints);
            int locNameIndex = 0;

            for (int i = 0; i < faceLongitudeLatitudePairings.Count; i++)
            {
                locNameIndex = AddLocationToList(i, faceLongitudeLatitudePairings, locNameIndex, locationNames);
            }

            for (int i = 0; i < smileLongitudeLatitudePairings.Count; i++)
            {
                locNameIndex = AddLocationToList(i, smileLongitudeLatitudePairings, locNameIndex, locationNames);
            }

            for (int i = 0; i < rightEyeLongitudeLatitudePairings.Count; i++)
            {
                locNameIndex = AddLocationToList(i, rightEyeLongitudeLatitudePairings, locNameIndex, locationNames);
            }

            for (int i = 0; i < leftEyeLongitudeLatitudePairings.Count; i++)
            {
                locNameIndex = AddLocationToList(i, leftEyeLongitudeLatitudePairings, locNameIndex, locationNames);
            }
            return totalNumberOfPoints;
        }

        private int AddLocationToList(int i, List<KeyValuePair<double, double>> kvpPairing, int locNameIndex, List<string> locationNames)
        {
            Location tempLocation = new Location();
            tempLocation.Id = locationNames[locNameIndex++];
            tempLocation.Longitude = kvpPairing[i].Key;
            tempLocation.Latitude = kvpPairing[i].Value;
            LocationList.Add(tempLocation);
            return locNameIndex;
        }

        private List<string> CreateSmileLocationNames(int minLength, int maxLength, int numLocations)
        {
            RandomStrings randomString = new RandomStrings();
            List<string> names = new List<string>();

            for (int i = 0; i < numLocations; i++)
            {
                string name = randomString.CreateRandomString(minLength, maxLength);
                names.Add(name);
            }
            return names;
        }

        private List<KeyValuePair<double, double>> CreateFaceLongitudeLatitudeValues(int numPoints, int radius)
        {
            double longitude;
            double latitude;

            double centerLongitude = 180 - 168.7; // 11.3
            double centerLatitude = 84 - (84 + 60.7) / 2; // 11.65
            double degrees = 360 / numPoints;

            List<KeyValuePair<double, double>> longitudeLatitudePairings = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < numPoints; i++)
            {
                longitude = centerLongitude + Math.Cos(degrees * i) * radius;
                latitude = centerLatitude + Math.Sin(degrees * i) * radius;

                KeyValuePair<double, double> latLongPairing = new KeyValuePair<double, double>(longitude, latitude);
                longitudeLatitudePairings.Add(latLongPairing);
            }
            return longitudeLatitudePairings;
        }

        private List<KeyValuePair<double, double>> CreateSmileLongitudeLatitudeValues(int numPoints, int radius)
        {
            double longitude;
            double latitude;

            double centerLongitude = 180 - 168.7; // 11.3
            double centerLatitude = 84 - (84 + 60.7) / 2; // 11.65

            List<KeyValuePair<double, double>> longitudeLatitudePairings = new List<KeyValuePair<double, double>>();

            int leftBoundaryOfSmile = 360 * 5 / 8;
            int rightBoundaryOfSmile = 360 * 7 / 8;
            double degrees = (rightBoundaryOfSmile - leftBoundaryOfSmile)/(double)numPoints;
            double degreeIndex = leftBoundaryOfSmile;
            double piOver180 = Math.PI / 180;

            for (int i = 0; i < numPoints; i++)
            {
                longitude = centerLongitude + Math.Cos(degreeIndex * piOver180) * radius;
                latitude = centerLatitude + Math.Sin(degreeIndex * piOver180) * radius;
                Utilities.LogMessage("Debugging smile: longitude - " + longitude.ToString() + " latitude - " + latitude.ToString());
                KeyValuePair<double, double> latLongPairing = new KeyValuePair<double, double>(longitude, latitude);
                longitudeLatitudePairings.Add(latLongPairing);
                degreeIndex += degrees;
            }
            return longitudeLatitudePairings;
        }

        private List<KeyValuePair<double, double>> CreateLeftEyeLongitudeLatitudeValues(int numPoints, int radius)
        {
            double longitude;
            double latitude;
            double longitudeOffset = 18;
            double latitudeOffset = 24;
            double centerLongitude = 180 - 168.7 - longitudeOffset;
            double centerLatitude = 84 + latitudeOffset - (84 + 60.7) / 2;
            double degrees = 360 / numPoints;

            List<KeyValuePair<double, double>> longitudeLatitudePairings = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < numPoints; i++)
            {
                longitude = centerLongitude + Math.Cos(degrees * i) * radius;
                latitude = centerLatitude + Math.Sin(degrees * i) * radius;
                Utilities.LogMessage("Debugging Left Eye: longitude - " + longitude.ToString() + " latitude - " + latitude.ToString());
                KeyValuePair<double, double> latLongPairing = new KeyValuePair<double, double>(longitude, latitude);
                longitudeLatitudePairings.Add(latLongPairing);
            }
            return longitudeLatitudePairings;
        }

        private List<KeyValuePair<double, double>> CreateRightEyeLongitudeLatitudeValues(int numPoints, int radius)
        {
            double longitude;
            double latitude;
            double longitudeOffset = 18;
            double latitudeOffset = 24;
            double centerLongitude = 180 - 168.7 + longitudeOffset;
            double centerLatitude = 84 + latitudeOffset - (84 + 60.7) / 2;
            double degrees = 360 / numPoints;

            List<KeyValuePair<double, double>> longitudeLatitudePairings = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < numPoints; i++)
            {
                longitude = centerLongitude + Math.Cos(degrees * i) * radius;
                latitude = centerLatitude + Math.Sin(degrees * i) * radius;
                Utilities.LogMessage("Debugging Right Eye: longitude - " + longitude.ToString() + " latitude - " + latitude.ToString());
                KeyValuePair<double, double> latLongPairing = new KeyValuePair<double, double>(longitude, latitude);
                longitudeLatitudePairings.Add(latLongPairing);
            }
            return longitudeLatitudePairings;
        }
        #endregion

        #endregion

        #region location entity creation - move to UICommon Utilities method

        //require user of these methods to provide a callback method
        //in which an algorithm for creation of the List<Location> collection
        //is provided - allows common testcode support with local definition
        //of location placement
        public static List<Location> GenerateLocations(Delegate callBackMethod)
        {
            List<Location> locations = (List<Location>)callBackMethod.DynamicInvoke();

            return locations;
        }

        public static List<Entity> BuildLocationEntities(DataGenerationEngine engine, EntityType type, List<Location> locations)
        {
            if (locations == null)
                throw new Exception("invalid state - List<Location> collection is null");

            List<Entity> Entities = new List<Entity>();
            Entities.Capacity = locations.Count;
            foreach (Location location in locations)
            {
                EntityBuilder locationBuilder = type.CreateEntityBuilder();
                locationBuilder.Properties["Id"].Value = location.Id;
                locationBuilder.Properties["Longitude"].Value = location.Longitude.ToString();
                locationBuilder.Properties["Latitude"].Value = location.Latitude.ToString();
                Entities.Add(locationBuilder.Construct());
            }

            engine.FlushPendingData();

            return Entities;
        }
        #endregion
        #endregion
        
        #endregion

        #region Generated Data Removal methods

        #region Remove Location Entities
        public void RemoveLocationEntities(DataGenerationEngine engine)
        {
            if (LocationEntityList != null)
            {
                foreach (Entity entity in LocationEntityList)
                {
                    entity.Delete();
                }
                engine.FlushPendingData();
            }
        }

        public void RemoveAllLocationEntities(DataGenerationEngine engine, EnterpriseManagementGroup mg)
        {
            engine.LoadInstancesOfType(mg, Constants.SystemConfigContainerName, Constants.LocationEntityTypeName);

            IEnumerable<Entity> locationEntities = engine.ConfigContainers[Constants.SystemConfigContainerName].
                    EntityTypes[Constants.LocationEntityTypeName].Entities.Where(e => !e.Properties["DisplayName"].Equals(""));

            int counter = 0;
            foreach (Entity entity in locationEntities)
            {
                entity.Delete();
                counter++;
            }

            Utilities.LogMessage("Removed " + counter + " location entities");
        }
        #endregion

        #region Remove HealthService Entities
        public void RemoveHealthServiceEntities(DataGenerationEngine engine)
        {
            if (AgentEntityList != null)
            {
                foreach (Entity entity in AgentEntityList)
                {
                    entity.Delete();
                }
                engine.FlushPendingData();
            }
        }

        public void RemoveAllFakeHealthServiceEntities(DataGenerationEngine engine, EnterpriseManagementGroup mg)
        {
            //this.Engine.LoadAgents(ManagementGroup);
            engine.LoadInstancesOfType(mg, Constants.SystemCenterLibraryConfigContainerName, Constants.HealthServiceEntityTypeName);

            IEnumerable<Entity> agentEntities = engine.ConfigContainers[Constants.SystemCenterLibraryConfigContainerName].
                    EntityTypes[Constants.HealthServiceEntityTypeName].Entities.Where(e => !e.Properties["PrincipalName"].
                        ValueAsString.StartsWith(Environment.MachineName)); ;

            int counter = 0;
            foreach (Entity entity in agentEntities)
            {
                entity.Delete();
                counter++;
            }

            Utilities.LogMessage("Removed " + counter + " healthservice entities");
        }
        #endregion

        #region Remove Relationships
        public void RemoveRelationshipEntities(DataGenerationEngine engine)
        {
            if (RelationshipList != null)
            {
                foreach (Relationship relationship in RelationshipList)
                {
                    relationship.Delete();
                }
                engine.FlushPendingData();
            }
        }

        public void RemoveAllFakeRelationshipEntities(DataGenerationEngine engine, EnterpriseManagementGroup mg)
        {
            engine.LoadInstancesOfType(mg, Constants.SystemConfigContainerName, Constants.EntityLocationRelationshipTypeName);

            IEnumerable<Entity> relationshipEntities = engine.ConfigContainers[Constants.SystemCenterLibraryConfigContainerName].
                    EntityTypes[Constants.EntityLocationRelationshipTypeName].Entities.Where(e => e.Properties["RelationshipTypeId"].
                        ValueAsString.Equals(e.Properties["RelationshipTypeName"].ValueAsString.StartsWith
                            (Constants.EntityLocationRelationshipTypeName)));

            int counter = 0;
            foreach (Entity entity in relationshipEntities)
            {
                entity.Delete();
                counter++;
            }

            Utilities.LogMessage("Removed " + counter + " relationship entities");
        }
        #endregion

        #endregion
    }

    #endregion //end MapWidgetDataGeneration class
}