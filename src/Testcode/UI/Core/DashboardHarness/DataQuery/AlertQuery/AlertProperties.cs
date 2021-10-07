using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class AlertProperty
    {
        #region Alert Property Names

        public class PropertyNames
        {
            public const string Age = "Age";
//            public const string Category = "Category";
            public const string ClassId = "ClassId";
            public const string ConnectorId = "ConnectorId";
            public const string ConnectorStatus = "ConnectorStatus";
            public const string Context = "Context";
            public const string CustomField1 = "CustomField1";
            public const string CustomField10 = "CustomField10";
            public const string CustomField2 = "CustomField2";
            public const string CustomField3 = "CustomField3";
            public const string CustomField4 = "CustomField4";
            public const string CustomField5 = "CustomField5";
            public const string CustomField6 = "CustomField6";
            public const string CustomField7 = "CustomField7";
            public const string CustomField8 = "CustomField8";
            public const string CustomField9 = "CustomField9";
            public const string Description = "Description";
            public const string Id = "Id";
            public const string IsMonitorAlert = "IsMonitorAlert";
            public const string LastModified = "LastModified";
            public const string LastModifiedBy = "LastModifiedBy";
            public const string LastModifiedByNonConnector = "LastModifiedByNonConnector";
            public const string LastModifiedByNonConnectorUTC = "LastModifiedByNonConnectorUTC";
            public const string LastModifiedUTC = "LastModifiedUTC";
            public const string Latency = "Latency";
            public const string MaintenanceModeLastModified = "MaintenanceModeLastModified";
            public const string MaintenanceModeLastModifiedUTC = "MaintenanceModeLastModifiedUTC";
            public const string MonitoringObjectDisplayName = "MonitoringObjectDisplayName";
            public const string MonitoringObjectFullName = "MonitoringObjectFullName";
            public const string MonitoringObjectHealthState = "MonitoringObjectHealthState";
            public const string MonitoringObjectId = "MonitoringObjectId";
            public const string MonitoringObjectInMaintenanceMode = "MonitoringObjectInMaintenanceMode";
            public const string MonitoringObjectName = "MonitoringObjectName";
            public const string MonitoringObjectPath = "MonitoringObjectPath";
            public const string Name = "Name";
            public const string NetbiosComputerName = "NetbiosComputerName";
            public const string NetbiosDomainName = "NetbiosDomainName";
            public const string Owner = "Owner";
            public const string Parameters = "Parameters";
            public const string PrincipalName = "PrincipalName";
            public const string Priority = "Priority";
            public const string ProblemId = "ProblemId";
            public const string RepeatCount = "RepeatCount";
//            public const string ResolutionState = "ResolutionState";
            public const string ResolvedBy = "ResolvedBy";
            public const string RuleId = "RuleId";
            public const string Severity = "Severity";
            public const string SiteName = "SiteName";
            public const string StateLastModified = "StateLastModified";
            public const string StateLastModifiedUTC = "StateLastModifiedUTC";
            public const string TargetDisplayName = "TargetDisplayName";
            public const string TicketId = "TicketId";
            public const string TimeAdded = "TimeAdded";
            public const string TimeAddedUTC = "TimeAddedUTC";
            public const string TimeInState = "TimeInState";
            public const string TimeRaised = "TimeRaised";
            public const string TimeRaisedUTC = "TimeRaisedUTC";
            public const string TimeResolutionStateLastModified = "TimeResolutionStateLastModified";
            public const string TimeResolutionStateLastModifiedUTC = "TimeResolutionStateLastModifiedUTC";
            public const string TimeResolved = "TimeResolved";
            public const string TimeResolvedUTC = "TimeResolvedUTC";
            public const string TypeDisplayName = "TypeDisplayName";
        }
        #endregion

        #region Alert property list

        /// <summary>
        /// List of alert properties that can be retreived from the data query
        /// </summary>
        public static Dictionary<string, ValueDefinitionType> ValueDefinitions =
            new Dictionary<string, ValueDefinitionType>
                {
                    {
                        PropertyNames.Age, 
                        new ValueDefinitionType(
                            outputPropertyName: "Age",
                            xPath: "$Object/Property[Name='Age']$",
                            displayName:@"$DEFAULT$", 
                            propertyName: "Age",
                            propertyType: typeof (TimeSpan), isReal: false)
                        },
//                    {
//                        PropertyNames.Category, 
//                        new ValueDefinitionType(
//                            outputPropertyName: "Category",
//                            xPath: "$Object/Property[Name='Category']$",
//                            displayName: @"$DEFAULT$",
//                            propertyName: "Category.Value",
//                            propertyType: typeof (int), isReal: true)
//                        },
                    {
                        PropertyNames.ClassId, 
                        new ValueDefinitionType(
                            outputPropertyName: "ClassId",
                            xPath: "$Object/Property[Name='ClassId']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "ClassId",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.ConnectorId, 
                        new ValueDefinitionType(
                            outputPropertyName: "ConnectorId",
                            xPath: "$Object/Property[Name='ConnectorId']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "ConnectorId",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.ConnectorStatus, 
                        new ValueDefinitionType( 
                            outputPropertyName: "ConnectorStatus",
                            xPath: "$Object/Property[Name='ConnectorStatus']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "ConnectorStatus.Value",
                            propertyType: typeof (int),
                            isReal: false)
                        },
                    {
                        PropertyNames.Context, 
                        new ValueDefinitionType(
                            outputPropertyName: "Context",
                            xPath: "$Object/Property[Name='Context']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Context",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.CustomField1, 
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField1",
                            xPath: "$Object/Property[Name='CustomField1']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField1",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField2, 
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField2",
                            xPath: "$Object/Property[Name='CustomField2']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField2",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField3,
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField3",
                            xPath: "$Object/Property[Name='CustomField3']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField3",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField4,
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField4",
                            xPath: "$Object/Property[Name='CustomField4']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField4",
                            propertyType: typeof (string), 
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField5,
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField5",
                            xPath: "$Object/Property[Name='CustomField5']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField5",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField6,
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField6",
                            xPath: "$Object/Property[Name='CustomField6']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField6",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.CustomField7, 
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField7",
                            xPath: "$Object/Property[Name='CustomField7']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField7",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField8, 
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField8",
                            xPath: "$Object/Property[Name='CustomField8']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "CustomField8",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField9, 
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField9",
                            xPath:"$Object/Property[Name='CustomField9']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"CustomField9",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.CustomField10, 
                        new ValueDefinitionType(
                            outputPropertyName: "CustomField10",
                            xPath:"$Object/Property[Name='CustomField10']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"CustomField10",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.Description, 
                        new ValueDefinitionType(
                            outputPropertyName: "Description",
                            xPath:"$Object/Property[Name='Description']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"Description",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.Id, 
                        new ValueDefinitionType(
                            outputPropertyName: "Id",
                            xPath: "$Object/Property[Name='Id']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Id",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.IsMonitorAlert, 
                        new ValueDefinitionType(
                            outputPropertyName: "IsMonitorAlert",
                            xPath:"$Object/Property[Name='IsMonitorAlert']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"IsMonitorAlert.Value",
                            propertyType: typeof (bool),
                            isReal: true)
                        },
                    {
                        PropertyNames.LastModified, 
                        new ValueDefinitionType(
                            outputPropertyName: "LastModified",
                            xPath:"$Object/Property[Name='LastModified']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"LastModified",
                            propertyType: typeof (DateTime),
                            isReal: false)
                        },
                    {
                        PropertyNames.LastModifiedUTC, 
                        new ValueDefinitionType(
                            outputPropertyName:"LastModifiedUTC",
                            xPath:"$Object/Property[Name='LastModifiedUTC']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"LastModifiedUTC",
                            propertyType: typeof (DateTime),
                            isReal: true)
                        },
                    {
                        PropertyNames.LastModifiedBy, 
                        new ValueDefinitionType(
                            outputPropertyName: "LastModifiedBy",
                            xPath:"$Object/Property[Name='LastModifiedBy']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"LastModifiedBy",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.LastModifiedByNonConnector, 
                        new ValueDefinitionType(
                            outputPropertyName:"LastModifiedByNonConnector",
                            xPath:"$Object/Property[Name='LastModifiedByNonConnector']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"LastModifiedByNonConnector",
                            propertyType:typeof (DateTime),
                            isReal: false)
                        },
                    {
                        PropertyNames.LastModifiedByNonConnectorUTC, 
                        new ValueDefinitionType(
                            outputPropertyName:"LastModifiedByNonConnectorUTC",
                            xPath:"$Object/Property[Name='LastModifiedByNonConnectorUTC']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"LastModifiedByNonConnectorUTC",
                            propertyType:typeof (DateTime),
                            isReal: true)
                        },
                    {
                        PropertyNames.Latency, 
                        new ValueDefinitionType(
                            outputPropertyName: "Latency",
                            xPath: "$Object/Property[Name='Latency']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Latency",
                            propertyType: typeof (TimeSpan),
                            isReal: false)
                        },
                    {
                        PropertyNames.MaintenanceModeLastModified, 
                        new ValueDefinitionType(
                            outputPropertyName:"MaintenanceModeLastModified",
                            xPath:"$Object/Property[Name='MaintenanceModeLastModified']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"MaintenanceModeLastModified",
                            propertyType:typeof (DateTime),
                            isReal: false)
                        },
                    {
                        PropertyNames.MaintenanceModeLastModifiedUTC, 
                        new ValueDefinitionType(
                            outputPropertyName:"MaintenanceModeLastModifiedUTC",
                            xPath:"$Object/Property[Name='MaintenanceModeLastModifiedUTC']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"MaintenanceModeLastModifiedUTC",
                            propertyType:typeof (DateTime),
                            isReal: true)
                        },
                    {
                        PropertyNames.MonitoringObjectDisplayName, 
                        new ValueDefinitionType(
                            outputPropertyName:"MonitoringObjectDisplayName",
                            xPath:"$Object/Property[Name='MonitoringObjectDisplayName']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"MonitoringObjectDisplayName",
                            propertyType:typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.MonitoringObjectFullName, 
                        new ValueDefinitionType(
                            outputPropertyName:"MonitoringObjectFullName",
                            xPath:"$Object/Property[Name='MonitoringObjectFullName']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"MonitoringObjectFullName",
                            propertyType:typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.MonitoringObjectHealthState, 
                        new ValueDefinitionType(
                            outputPropertyName:"MonitoringObjectHealthState",
                            xPath:"$Object/Property[Name='MonitoringObjectHealthState']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"MonitoringObjectHealthState.Value",
                            propertyType:typeof (int),
                            isReal: false)
                        },
                    {
                        PropertyNames.MonitoringObjectId, 
                        new ValueDefinitionType(
                            outputPropertyName:"MonitoringObjectId",
                            xPath:"$Object/Property[Name='MonitoringObjectId']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"MonitoringObjectId",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.MonitoringObjectInMaintenanceMode,
                        new ValueDefinitionType(
                            outputPropertyName: "MonitoringObjectInMaintenanceMode",
                            xPath: "$Object/Property[Name='MonitoringObjectInMaintenanceMode']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "MonitoringObjectInMaintenanceMode.Value",
                            propertyType: typeof (bool), isReal: false)
                        },
                    {
                        PropertyNames.MonitoringObjectName, 
                        new ValueDefinitionType(
                            outputPropertyName:"MonitoringObjectName",
                            xPath:"$Object/Property[Name='MonitoringObjectName']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"MonitoringObjectName",
                            propertyType: typeof (string),
                            isReal: true)
                    },
                    {
                        PropertyNames.MonitoringObjectPath,
                        new ValueDefinitionType(
                            outputPropertyName:"MonitoringObjectPath",
                            xPath:"$Object/Property[Name='MonitoringObjectPath']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"MonitoringObjectPath",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.Name, 
                        new ValueDefinitionType(
                            outputPropertyName: "Name",
                            xPath: "$Object/Property[Name='Name']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Name",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.NetbiosComputerName, 
                        new ValueDefinitionType(
                            outputPropertyName:"NetbiosComputerName",
                            xPath:"$Object/Property[Name='NetbiosComputerName']$",
                            displayName:@"$DEFAULT$",
                            propertyName:"NetbiosComputerName",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.NetbiosDomainName, 
                        new ValueDefinitionType(
                            outputPropertyName:"NetbiosDomainName",
                            xPath:"$Object/Property[Name='NetbiosDomainName']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"NetbiosDomainName",
                            propertyType: 
                            typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.Owner, 
                        new ValueDefinitionType(
                            outputPropertyName: "Owner",
                            xPath: "$Object/Property[Name='Owner']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Owner",
                            propertyType: typeof (string), 
                            isReal: true)
                    },
                    {
                        PropertyNames.Parameters, 
                        new ValueDefinitionType(
                            outputPropertyName: "Parameters",
                            xPath:"$Object/Property[Name='Parameters']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Parameters",
                            propertyType: typeof (object),
                            isReal: true)
                        },
                    // todo
                    {
                        PropertyNames.PrincipalName, 
                        new ValueDefinitionType(
                            outputPropertyName: "PrincipalName",
                            xPath:"$Object/Property[Name='PrincipalName']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"PrincipalName",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.Priority, 
                        new ValueDefinitionType(
                            outputPropertyName: "Priority",
                            xPath: "$Object/Property[Name='Priority']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Priority.Value",
                            propertyType: typeof (int), isReal: false)
                        },
                    {
                        PropertyNames.ProblemId, 
                        new ValueDefinitionType(
                            outputPropertyName: "ProblemId",
                            xPath:"$Object/Property[Name='ProblemId']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "ProblemId",
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.RepeatCount, 
                        new ValueDefinitionType(
                            outputPropertyName: "RepeatCount",
                            xPath:"$Object/Property[Name='RepeatCount']$",
                            displayName: @"$DEFAULT$",
                            propertyName:"RepeatCount",
                            propertyType: typeof (int), isReal: true)
                        },
//                    {
//                        PropertyNames.ResolutionState, 
//                        new ValueDefinitionType(
//                            outputPropertyName:"ResolutionState",
//                            xPath:"$Object/Property[Name='ResolutionState']$",
//                            displayName: @"$DEFAULT$",
//                            propertyName:"ResolutionState.Value",
//                            propertyType: typeof (Byte),
//                            isReal: false)
//                        },
                    {
                        PropertyNames.ResolvedBy, 
                        new ValueDefinitionType(
                            outputPropertyName: "ResolvedBy",
                            xPath:"$Object/Property[Name='ResolvedBy']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "ResolvedBy",
                            propertyType: typeof (string),
                            isReal: true)
                        },
                    {
                        PropertyNames.RuleId, 
                        new ValueDefinitionType(
                            outputPropertyName: "RuleId",
                            xPath: "$Object/Property[Name='RuleId']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "RuleId",
                            propertyType: typeof (string), 
                            isReal: true)
                        },
                    {
                        PropertyNames.Severity,
                        new ValueDefinitionType(
                            outputPropertyName: "Severity",
                            xPath: "$Object/Property[Name='Severity']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "Severity.Value",
                            propertyType: typeof (int), 
                            isReal: false)
                        },
                    {
                        PropertyNames.SiteName, 
                        new ValueDefinitionType(
                            outputPropertyName: "SiteName",
                            xPath: "$Object/Property[Name='SiteName']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "SiteName",
                            propertyType: typeof (string), 
                            isReal: true)
                        },
                    {
                        PropertyNames.StateLastModified,
                        new ValueDefinitionType(
                            outputPropertyName: "StateLastModified",
                            xPath: "$Object/Property[Name='StateLastModified']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "StateLastModified",
                            propertyType: typeof (DateTime), 
                            isReal: false)
                        },
                    {
                        PropertyNames.StateLastModifiedUTC,
                        new ValueDefinitionType(
                            outputPropertyName: "StateLastModifiedUTC",
                            xPath: "$Object/Property[Name='StateLastModifiedUTC']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "StateLastModifiedUTC",
                            propertyType: typeof (DateTime), 
                            isReal: true)
                        },
                    {
                        PropertyNames.TargetDisplayName,
                        new ValueDefinitionType(
                            outputPropertyName: "TargetDisplayName",
                            xPath: "$Object/Property[Name='TargetDisplayName']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TargetDisplayName",
                            propertyType: typeof (string), 
                            isReal: false)
                        },
                    {
                        PropertyNames.TicketId,
                        new ValueDefinitionType(
                            outputPropertyName: "TicketId",
                            xPath: "$Object/Property[Name='TicketId']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TicketId",
                            propertyType: typeof (string), 
                            isReal: true)
                        },
                    {
                        PropertyNames.TimeAdded,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeAdded",
                            xPath: "$Object/Property[Name='TimeAdded']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeAdded",
                            propertyType: typeof (DateTime), 
                            isReal: false)
                        },
                    {
                        PropertyNames.TimeAddedUTC,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeAddedUTC",
                            xPath: "$Object/Property[Name='TimeAddedUTC']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeAddedUTC",
                            propertyType: typeof (DateTime), 
                            isReal: true)
                        },
                    {
                        PropertyNames.TimeInState,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeInState",
                            xPath: "$Object/Property[Name='TimeInState']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeInState",
                            propertyType: typeof (TimeSpan), 
                            isReal: false)
                        },
                    {
                        PropertyNames.TimeRaised,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeRaised",
                            xPath: "$Object/Property[Name='TimeRaised']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeRaised",
                            propertyType: typeof (DateTime), 
                            isReal: false)
                        },
                    {
                        PropertyNames.TimeRaisedUTC,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeRaisedUTC",
                            xPath: "$Object/Property[Name='TimeRaisedUTC']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeRaisedUTC",
                            propertyType: typeof (DateTime), 
                            isReal: true)
                        },
                    {
                        PropertyNames.TimeResolutionStateLastModified,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeResolutionStateLastModified",
                            xPath: "$Object/Property[Name='TimeResolutionStateLastModified']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeResolutionStateLastModified",
                            propertyType: typeof (DateTime), 
                            isReal: false)
                        },
                    {
                        PropertyNames.TimeResolutionStateLastModifiedUTC,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeResolutionStateLastModifiedUTC",
                            xPath: "$Object/Property[Name='TimeResolutionStateLastModifiedUTC']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeResolutionStateLastModifiedUTC",
                            propertyType: typeof (DateTime), 
                            isReal: true)
                        },
                    {
                        PropertyNames.TimeResolved,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeResolved",
                            xPath: "$Object/Property[Name='TimeResolved']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeResolved",
                            propertyType: typeof (DateTime?), 
                            isReal: false)
                        },
                    {
                        PropertyNames.TimeResolvedUTC,
                        new ValueDefinitionType(
                            outputPropertyName: "TimeResolvedUTC",
                            xPath: "$Object/Property[Name='TimeResolvedUTC']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TimeResolvedUTC",
                            propertyType: typeof (DateTime?), 
                            isReal: true)
                        },
                    {
                        PropertyNames.TypeDisplayName,
                        new ValueDefinitionType(
                            outputPropertyName: "TypeDisplayName",
                            xPath: "$Object/Property[Name='TypeDisplayName']$",
                            displayName: @"$DEFAULT$",
                            propertyName: "TypeDisplayName",
                            propertyType: typeof (string), 
                            isReal: false)
                        }
                };

        #endregion

        /// <summary>
        /// List of properties that cannot be verified by automation
        /// </summary>
        public static IEnumerable<ValueDefinitionType> PropertiesThatCannotBeVerified
        {
            get
            {
                return new List<ValueDefinitionType>
                           {
                               AlertProperty.ValueDefinitions[PropertyNames.Age],
                               AlertProperty.ValueDefinitions[PropertyNames.TimeInState],
                               AlertProperty.ValueDefinitions[PropertyNames.ConnectorId],
                               AlertProperty.ValueDefinitions[PropertyNames.Parameters], // BUG: 192576
                               AlertProperty.ValueDefinitions[PropertyNames.TimeResolved], // BUG: 194065
                               AlertProperty.ValueDefinitions[PropertyNames.TimeResolvedUTC], // BUG: 194065
                               AlertProperty.ValueDefinitions[PropertyNames.TargetDisplayName], // TODO - Remove this
                               AlertProperty.ValueDefinitions[PropertyNames.TypeDisplayName], // TODO - Remove this
                           };
            }
        }
        
        public static IEnumerable<string> PropertiesThatCannotBeNull
        {
            get
            {
                return new List<string>
                           {
                               "Age.Value",
                               "TimeInState.Value"
                           };
            }
        }

        public static IEnumerable<ValueDefinitionType> RealProperties
        {
            get 
            {
                return ValueDefinitions.Values.Where(v => v.IsRealProperty); 
            }
        }

        public static IEnumerable<ValueDefinitionType> PseudoProperties
        {
            get 
            {
                return ValueDefinitions.Values.Where(v => !v.IsRealProperty); 
            }
        }

        public static bool IsReal(string propertyName)
        {
            return (RealProperties.Select(v => v.PropertyName.Equals(propertyName)).Count() > 0);
        }

        /// <summary>
        /// Get a SortValueDefinitionType for the alert property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public static SortValueDefinitionType GetSortValueDefinitionType(string propertyName, bool ascending)
        {
            return new SortValueDefinitionType(propertyName, 
                ValueDefinitions[propertyName].XPath, 
                ascending);    
        }

        /// <summary>
        /// Get the list of ValueDefinitionType for a given collection of alert properties 
        /// </summary>
        public static List<ValueDefinitionType> GetValueDefinitions(IEnumerable<string> alertProperties)
        {
            return alertProperties.Select(item => AlertProperty.ValueDefinitions[item]).ToList();
        }

        /// <summary>
        /// Format is PropertyName ASC
        /// </summary>
        /// <param name="alertProperties"></param>
        /// <returns></returns>
        public static IEnumerable<SortValueDefinitionType> GetSortProperties(IEnumerable<string> alertProperties)
        {
            if (alertProperties == null) throw new ArgumentNullException("list");

            var sortProperties = new List<SortValueDefinitionType>();

            foreach (var item in alertProperties)
            {
                var splitStrings = item.Split(" ".ToCharArray());
                var propertyName = splitStrings[0];
                var sortDirection = splitStrings[1];
                var ascending = sortDirection.Equals("ASC") ? true : false;

                sortProperties.Add(AlertProperty.GetSortValueDefinitionType(propertyName, ascending));
            }

            return sortProperties;
        }

        /// <summary>
        /// Extract the alert roperty values from the MonitoringAlert 
        /// to create a dictionary for of the same
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetAlertPropertyValues(MonitoringAlert alert)
        {
            var retVal = new Dictionary<string, object>();

            foreach (var item in GetRealPropertyValues(alert))
            {
                retVal.Add(item.Key, item.Value);
            }

            foreach (var item in GetPseudoPropertyValues(alert))
            {
                retVal.Add(item.Key, item.Value);
            }

            return retVal;
        }

        private static Dictionary<string, object> GetRealPropertyValues(MonitoringAlert alert)
        {
            var retVal = new Dictionary<string, object>()
                             {
                                 {AlertProperty.PropertyNames.ClassId, alert.ClassId.ToString()},
                                 {AlertProperty.PropertyNames.ConnectorId, (alert.ConnectorId.HasValue ? alert.ConnectorId.Value.ToString() : Guid.Empty.ToString())},
                                 {AlertProperty.PropertyNames.Context, alert.Context},
                                 {AlertProperty.PropertyNames.CustomField1, alert.CustomField1},
                                 {AlertProperty.PropertyNames.CustomField2, alert.CustomField2},
                                 {AlertProperty.PropertyNames.CustomField3, alert.CustomField3},
                                 {AlertProperty.PropertyNames.CustomField4, alert.CustomField4},
                                 {AlertProperty.PropertyNames.CustomField5, alert.CustomField5},
                                 {AlertProperty.PropertyNames.CustomField6, alert.CustomField6},
                                 {AlertProperty.PropertyNames.CustomField7, alert.CustomField7},
                                 {AlertProperty.PropertyNames.CustomField8, alert.CustomField8},
                                 {AlertProperty.PropertyNames.CustomField9, alert.CustomField9},
                                 {AlertProperty.PropertyNames.CustomField10, alert.CustomField10},
                                 {AlertProperty.PropertyNames.Description, alert.Description},
                                 {AlertProperty.PropertyNames.Id, alert.Id.ToString()},
                                 {AlertProperty.PropertyNames.IsMonitorAlert + ".Value", alert.IsMonitorAlert},
                                 {AlertProperty.PropertyNames.LastModifiedUTC, alert.LastModified},
                                 {AlertProperty.PropertyNames.LastModifiedBy, alert.LastModifiedBy},
                                 {AlertProperty.PropertyNames.LastModifiedByNonConnectorUTC, alert.LastModifiedByNonConnector},
                                 {AlertProperty.PropertyNames.MaintenanceModeLastModifiedUTC, alert.MaintenanceModeLastModified},
                                 {AlertProperty.PropertyNames.MonitoringObjectDisplayName, alert.MonitoringObjectDisplayName},
                                 {AlertProperty.PropertyNames.MonitoringObjectFullName, alert.MonitoringObjectFullName},
                                 {AlertProperty.PropertyNames.MonitoringObjectId, alert.MonitoringObjectId.ToString()},
                                 {AlertProperty.PropertyNames.MonitoringObjectName, alert.MonitoringObjectName},
                                 {AlertProperty.PropertyNames.MonitoringObjectPath, alert.MonitoringObjectPath},
                                 {AlertProperty.PropertyNames.Name, alert.Name}, 
                                 {AlertProperty.PropertyNames.NetbiosComputerName, alert.NetbiosComputerName},
                                 {AlertProperty.PropertyNames.NetbiosDomainName,alert.NetbiosDomainName},
                                 {AlertProperty.PropertyNames.Owner, alert.Owner},
                                 {AlertProperty.PropertyNames.Parameters, alert.Parameters},
                                 {AlertProperty.PropertyNames.PrincipalName, alert.PrincipalName},
                                 {AlertProperty.PropertyNames.ProblemId, alert.ProblemId.ToString()},
                                 {AlertProperty.PropertyNames.RepeatCount, alert.RepeatCount},
                                 {AlertProperty.PropertyNames.ResolvedBy, alert.ResolvedBy},
                                 {AlertProperty.PropertyNames.RuleId, alert.RuleId.ToString()},
                                 {AlertProperty.PropertyNames.SiteName, alert.SiteName},
                                 {AlertProperty.PropertyNames.StateLastModifiedUTC, alert.StateLastModified},
                                 {AlertProperty.PropertyNames.TicketId, alert.TicketId},
                                 {AlertProperty.PropertyNames.TimeAddedUTC, alert.TimeAdded},
                                 {AlertProperty.PropertyNames.TimeRaisedUTC, alert.TimeRaised},
                                 {AlertProperty.PropertyNames.TimeResolutionStateLastModifiedUTC, alert.TimeResolutionStateLastModified},
                                 {AlertProperty.PropertyNames.TimeResolvedUTC, (alert.TimeResolved.HasValue ? alert.TimeResolved.Value : (DateTime?) null)},
                             };

            return retVal;
        }

        private static Dictionary<string, object> GetPseudoPropertyValues(MonitoringAlert alert)
        {
            var currentTime = DateTime.Now;

            var retVal = new Dictionary<string, object>()
                             {
                                {AlertProperty.PropertyNames.Age, currentTime - alert.TimeAdded},
//                                {AlertProperty.PropertyNames.Category +".Value", (int) alert.Category},
                                {AlertProperty.PropertyNames.ConnectorStatus + ".Value", (int) alert.ConnectorStatus},
                                {AlertProperty.PropertyNames.LastModified, alert.LastModified},
                                {AlertProperty.PropertyNames.LastModifiedByNonConnector, alert.LastModifiedByNonConnector},
                                {AlertProperty.PropertyNames.Latency, alert.TimeAdded - alert.TimeRaised},
                                {AlertProperty.PropertyNames.MaintenanceModeLastModified, alert.MaintenanceModeLastModified},
                                {AlertProperty.PropertyNames.MonitoringObjectHealthState + ".Value", (int) alert.MonitoringObjectHealthState},
                                {AlertProperty.PropertyNames.MonitoringObjectInMaintenanceMode+ ".Value", alert.MonitoringObjectInMaintenanceMode},
                                {AlertProperty.PropertyNames.Priority + ".Value", (int) alert.Priority},
//                                {AlertProperty.PropertyNames.ResolutionState + ".Value", alert.ResolutionState},
                                {AlertProperty.PropertyNames.Severity + ".Value", (int) alert.Severity},
                                {AlertProperty.PropertyNames.StateLastModified, alert.StateLastModified},
                                {AlertProperty.PropertyNames.TimeAdded, alert.TimeAdded},
                                {AlertProperty.PropertyNames.TimeInState, currentTime - alert.TimeResolutionStateLastModified},
                                {AlertProperty.PropertyNames.TimeRaised, alert.TimeRaised},
                                {AlertProperty.PropertyNames.TimeResolutionStateLastModified, alert.TimeResolutionStateLastModified},
                                {AlertProperty.PropertyNames.TimeResolved, (alert.TimeResolved.HasValue ? alert.TimeResolved.Value : (DateTime?) null)}
                            };

            return retVal;
        }

    }
}
