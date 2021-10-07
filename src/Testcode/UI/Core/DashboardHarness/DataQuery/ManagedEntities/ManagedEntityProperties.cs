using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public static class ManagedEntityProperty
    {
        #region PropertyNames

        public class PropertyNames
        {
            public const string Id = "Id";
            public const string AvailabilityLastModified = "AvailabilityLastModified";
            public const string HealthState = "HealthState";
            public const string InMaintenanceMode = "InMaintenanceMode";
            public const string IsAvailable = "IsAvailable";
            public const string IsManaged = "IsManaged";
            public const string MaintenanceModeLastModified = "MaintenanceModeLastModified";
            public const string StateLastModified = "StateLastModified";
            public const string DisplayName = "DisplayName";
            public const string FullName = "FullName";
            public const string LastModified = "LastModified";
            public const string LastModifiedBy = "LastModifiedBy";
            public const string LeastDerivedNonAbstractManagementPackClassId = "LeastDerivedNonAbstractManagementPackClassId";
            public const string ManagementPackClassIds = "ManagementPackClassIds";
            public const string Name = "Name";
            public const string Path = "Path";
            public const string TimeAdded = "TimeAdded";
            public const string RelatedObjects = "RelatedObjects";
        }

        #endregion

        #region ManagedEntity Properties

        public static Dictionary<string, ValueDefinitionType> ValueDefinitions =
            new Dictionary<string, ValueDefinitionType>
                {
                    {
                        "Id",
                        new ValueDefinitionType(
                            outputPropertyName: "Id",
                            xPath: "$Object/Property[Name='Id']$",
                            displayName: "Id",
                            propertyName: "Id",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "AvailabilityLastModified",
                        new ValueDefinitionType(
                            outputPropertyName: "AvailabilityLastModified",
                            xPath: "$Object/Property[Name='AvailabilityLastModified']$",
                            displayName: "AvailabilityLastModified",
                            propertyName: "AvailabilityLastModified",
                            propertyType: typeof (DateTime), isReal: true)
                        },
                    {
                        "HealthState",
                        new ValueDefinitionType(
                            outputPropertyName: "HealthState",
                            xPath: "$Object/Property[Name='HealthState']$",
                            displayName: "HealthState",
                            propertyName: "HealthState",
                            propertyType: typeof (int), isReal: true)
                        },
                    {
                        "InMaintenanceMode",
                        new ValueDefinitionType(
                            outputPropertyName: "InMaintenanceMode",
                            xPath: "$Object/Property[Name='InMaintenanceMode']$",
                            displayName: "InMaintenanceMode",
                            propertyName: "InMaintenanceMode.Value",
                            propertyType: typeof (bool), isReal: true)
                        },
                    {
                        "IsAvailable",
                        new ValueDefinitionType(
                            outputPropertyName: "IsAvailable",
                            xPath: "$Object/Property[Name='IsAvailable']$",
                            displayName: "IsAvailable",
                            propertyName: "IsAvailable",
                            propertyType: typeof (bool), isReal: true)
                        },
                    {
                        "IsManaged",
                        new ValueDefinitionType(
                            outputPropertyName: "IsManaged",
                            xPath: "$Object/Property[Name='IsManaged']$",
                            displayName: "IsManaged",
                            propertyName: "IsManaged",
                            propertyType: typeof (bool), isReal: true)
                        },
                    {
                        "MaintenanceModeLastModified",
                        new ValueDefinitionType(
                            outputPropertyName: "MaintenanceModeLastModified",
                            xPath: "$Object/Property[Name='MaintenanceModeLastModified']$",
                            displayName: "MaintenanceModeLastModified",
                            propertyName: "MaintenanceModeLastModified",
                            propertyType: typeof (DateTime), isReal: true)
                        },
                    {
                        "StateLastModified",
                        new ValueDefinitionType(
                            outputPropertyName: "StateLastModified",
                            xPath: "$Object/Property[Name='StateLastModified']$",
                            displayName: "StateLastModified",
                            propertyName: "StateLastModified",
                            propertyType: typeof (DateTime), isReal: true)
                        },
                    {
                        "DisplayName",
                        new ValueDefinitionType(
                            outputPropertyName: "DisplayName",
                            xPath: "$Object/Property[Name='DisplayName']$",
                            displayName: "DisplayName",
                            propertyName: "DisplayName",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "FullName",
                        new ValueDefinitionType(
                            outputPropertyName: "FullName",
                            xPath: "$Object/Property[Name='FullName']$",
                            displayName: "FullName",
                            propertyName: "FullName",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "LastModified",
                        new ValueDefinitionType(
                            outputPropertyName: "LastModified",
                            xPath: "$Object/Property[Name='LastModified']$",
                            displayName: "LastModified",
                            propertyName: "LastModified",
                            propertyType: typeof (DateTime), isReal: true)
                        },
                    {
                        "LastModifiedBy",
                        new ValueDefinitionType(
                            outputPropertyName: "LastModifiedBy",
                            xPath: "$Object/Property[Name='LastModifiedBy']$",
                            displayName: "LastModifiedBy",
                            propertyName: "LastModifiedBy",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "LeastDerivedNonAbstractManagementPackClassId",
                        new ValueDefinitionType(
                            outputPropertyName: "LeastDerivedNonAbstractManagementPackClassId",
                            xPath: "$Object/Property[Name='LeastDerivedNonAbstractManagementPackClassId']$",
                            displayName: "LeastDerivedNonAbstractManagementPackClassId",
                            propertyName: "LeastDerivedNonAbstractManagementPackClassId",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "ManagementPackClassIds",
                        new ValueDefinitionType(
                            outputPropertyName: "ManagementPackClassIds",
                            xPath: "$Object/Property[Name='ManagementPackClassIds']$",
                            displayName: "ManagementPackClassIds",
                            propertyName: "ManagementPackClassIds",
                            propertyType: typeof (IList<string>), isReal: true)
                        },
                    {
                        "Name",
                        new ValueDefinitionType(
                            outputPropertyName: "Name",
                            xPath: "$Object/Property[Name='Name']$",
                            displayName: "Name",
                            propertyName: "Name",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "Path",
                        new ValueDefinitionType(
                            outputPropertyName: "Path",
                            xPath: "$Object/Property[Name='Path']$",
                            displayName: "Path",
                            propertyName: "Path",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        "TimeAdded",
                        new ValueDefinitionType(
                            outputPropertyName: "TimeAdded",
                            xPath: "$Object/Property[Name='TimeAdded']$",
                            displayName: "TimeAdded",
                            propertyName: "TimeAdded",
                            propertyType: typeof (DateTime), isReal: true)
                        },
                    {
                        "RelatedObjects",
                        new ValueDefinitionType(
                            outputPropertyName: "RelatedObjects",
                            xPath: "$Object/Path[Relationship=\'<relationship>\' SeedRole=\'<role>\' TypeConstraint=\'<type>\']$",
                            displayName: "RelatedObjects",
                            propertyName: "RelatedObjects",
                            propertyType: typeof (object), isReal: false)
                        }

                        //,
                    //{
                    //    "TypeWithIcon",
                    //    new ValueDefinitionType(
                    //        outputPropertyName: "TypeWithIcon",
                    //        xPath: "$Object/Property[Name='TypeWithIcon']$",
                    //        displayName: "TypeWithIcon",
                    //        propertyName: "TypeWithIcon.Value",
                    //        propertyType: typeof (string), isReal: true)
                    //    }

                };

        #endregion

        /// <summary>
        /// Extract the property values from the PartialMonitoringObject 
        /// and build a dictionary out of it
        /// </summary>
        public static Dictionary<string, object> GetPropertyValues(PartialMonitoringObject mo)
        {
            var retVal = new Dictionary<string, object>()
                             {
                                 {PropertyNames.Id, mo.Id.ToString()},
                                 {PropertyNames.AvailabilityLastModified, mo.AvailabilityLastModified ?? DateTime.MinValue},
                                 {PropertyNames.HealthState, (int) mo.HealthState},
                                 {PropertyNames.InMaintenanceMode + ".Value", mo.InMaintenanceMode},
                                 {PropertyNames.IsAvailable, mo.IsAvailable},
                                 {PropertyNames.IsManaged, mo.IsManaged},
                                 {PropertyNames.MaintenanceModeLastModified, mo.MaintenanceModeLastModified.HasValue ? mo.MaintenanceModeLastModified : DateTime.MinValue},
                                 {PropertyNames.StateLastModified, mo.StateLastModified.HasValue ? mo.StateLastModified : DateTime.MinValue},
                                 {PropertyNames.DisplayName, mo.DisplayName},
                                 {PropertyNames.FullName, mo.FullName},
                                 {PropertyNames.LastModified, mo.LastModified},
                                 {PropertyNames.LastModifiedBy, mo.LastModifiedBy.HasValue ? mo.LastModifiedBy.ToString() : Guid.Empty.ToString()},
                                 {PropertyNames.LeastDerivedNonAbstractManagementPackClassId, mo.LeastDerivedNonAbstractManagementPackClassId.ToString()},
                                 {PropertyNames.ManagementPackClassIds, mo.ManagementPackClassIds.Select(item => item.ToString()).ToList()},
                                 {PropertyNames.Name, mo.Name},
                                 {PropertyNames.Path, mo.Path},
                                 {PropertyNames.TimeAdded, mo.TimeAdded},
                                 // TODO {"Type", monitoringObject.M}
                                 // TypeWithIcon - Not returned. THis should be manually verified.
                             };

            return retVal;
        }

        /// <summary>
        /// Get the value definition objects for the list of managed entity property names
        /// </summary>
        public static List<ValueDefinitionType> GetValueDefinitions(IEnumerable<string> managedEntityPropertyNames)
        {
            return managedEntityPropertyNames.Select(item => ManagedEntityProperty.ValueDefinitions[item]).ToList();
        }

        /// <summary>
        /// Get the sort value definition types for the list of managed entity property names
        /// </summary>
        public static IEnumerable<SortValueDefinitionType> GetSortProperties(IEnumerable<string> list)
        {
            if (list == null) throw new ArgumentNullException("list");

            var sortProperties = new List<SortValueDefinitionType>();

            foreach (var item in list)
            {
                var splitStrings = item.Split(" ".ToCharArray());
                var propertyName = splitStrings[0];
                var sortDirection = splitStrings[1];
                var ascending = sortDirection.Equals("ASC") ? true : false;

                sortProperties.Add(ManagedEntityProperty.GetSortValueDefinitionType(propertyName, ascending));
            }

            return sortProperties;
        }

        /// <summary>
        /// Get a single sort value definition object for a managed entity property
        /// </summary>
        public static SortValueDefinitionType GetSortValueDefinitionType(string propertyName, bool ascending)
        {
            return new SortValueDefinitionType(propertyName,
                ValueDefinitions[propertyName].XPath,
                ascending);
        }

    }
}
