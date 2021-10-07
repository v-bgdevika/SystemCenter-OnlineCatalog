using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class AlertResolutionStateProperty
    {
        public class PropertyNames
        {
            public const string IsSystem = "IsSystem";
            public const string DisplayName = "DisplayName";
            public const string Value = "Value";
            public const string ShortcutKey = "ShortcutKey";
        }

        #region Alert resolution state property list

        public static Dictionary<string, ValueDefinitionType> ValueDefinitions =
            new Dictionary<string, ValueDefinitionType>
                {
                    {
                        PropertyNames.IsSystem, 
                        new ValueDefinitionType(
                            outputPropertyName: PropertyNames.IsSystem,
                            xPath: "$Object/Property[Name='IsSystem']$",
                            displayName:@"$DEFAULT$", 
                            propertyName: PropertyNames.IsSystem,
                            propertyType: typeof (bool), isReal: true)
                        },
                    {
                        PropertyNames.DisplayName, 
                        new ValueDefinitionType(
                            outputPropertyName: PropertyNames.DisplayName,
                            xPath: "$Object/Property[Name='Name']$",
                            displayName:@"$DEFAULT$",
                            propertyName: PropertyNames.DisplayName,
                            propertyType: typeof (string), isReal: true)
                        },
                    {
                        PropertyNames.Value, 
                        new ValueDefinitionType(
                            outputPropertyName: PropertyNames.Value,
                            xPath: "$Object/Property[Name='ResolutionState']$",
                            displayName:@"$DEFAULT$",
                            propertyName: PropertyNames.Value,
                            propertyType: typeof (byte), isReal: true)
                        },
                    {
                        PropertyNames.ShortcutKey,
                        new ValueDefinitionType(
                            outputPropertyName: PropertyNames.ShortcutKey,
                            xPath: "$Object/Property[Name='ShortcutKey']$",
                            displayName:@"$DEFAULT$",
                            propertyName: PropertyNames.ShortcutKey,
                            propertyType: typeof (string),
                            isReal: true)
                        }
                };

        #endregion

        public static Dictionary<string, object> GetResolutionStatePropertyValues(MonitoringAlertResolutionState resolutionState)
        {
            var retVal = new Dictionary<string, object>()
                             {
                                 {PropertyNames.IsSystem, resolutionState.IsSystem},
                                 {PropertyNames.DisplayName, resolutionState.Name},
                                 {PropertyNames.Value, resolutionState.ResolutionState},
                                 {PropertyNames.ShortcutKey, resolutionState.ShortcutKey}
                            };

            return retVal;
        }

        public static List<ValueDefinitionType> GetValueDefinitions(IEnumerable<string> value)
        {
            return value.Select(item => AlertProperty.ValueDefinitions[item]).ToList();
        }
    }
}