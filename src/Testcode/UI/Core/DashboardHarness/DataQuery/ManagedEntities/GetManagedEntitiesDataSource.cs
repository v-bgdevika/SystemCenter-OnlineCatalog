using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using MEProperties = Mom.Test.UI.Core.GenericDataQuery.ManagedEntityProperty.PropertyNames;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetManagedEntitiesDataSource : CommonDataSourceInterface
    {
        private const string SystemLibrarySystemEntity = "System.Library!System.Entity";

        // property names used
        new public class PropertyNames
        {
            public const string CriteriaString = "CriteriaString";
            public const string Refresh = "Refresh";
            public const string Properties = "Properties";
            public const string PropertiesInclusion = "Properties_Inclusion";
            public const string PropertiesExclusion = "Properties_Exclusion";
            public const string RelatedObjectsInclusion = "RelatedObjects_Properties_Inclusion";
            public const string BaseTypeNames = "BaseTypeNames";
            public const string BaseTypeNamesInclusion = "BaseTypeNames_Inclusion";
            public const string BaseTypeNamesExclusion = "BaseTypeNames_Exclusion";
            public const string MaxEntities = "MaxEntities";
            public const string TargetEntities = "TargetEntities";
            public const string RecursionTypeNames = "RecursionTypeNames";
            public const string SortProperties = "SortProperties";
            public const string Output = "Output";
        }

        private string criteriaString; // criteria string used to select the managed entities
        private IEnumerable<SortValueDefinitionType> sortProperties; // properties by which the output is to be sorted
        private string[] baseTypeNames; // base type names of the managed entities
        private IEnumerable<IDataObject> targets; // target managed entities
        private int maxEntities = 10; // maximum number of entities to be selected
        private string[] recursionTypeNames; // recursively select the related objects of this type

        #region Public properties

        /// <summary>
        /// criteria string used to select the managed entities
        /// </summary>
        public string CriteriaString
        {
            get 
            { 
                return criteriaString ?? (criteriaString = GetDefaultCriteriaString()); 
            }
            
            set 
            { 
                criteriaString = value; 
            }
        }

        /// <summary>
        /// base type names of the managed entities
        /// </summary>
        public string[] BaseTypeNames
        {
            get 
            { 
                return (baseTypeNames ?? (baseTypeNames = GetDefaultBaseTypeNames())); 
            }
            
            set 
            { 
                baseTypeNames = value; 
            }
        }

        /// <summary>
        /// maximum number of entities to be selected
        /// </summary>
        public int MaxEntities
        {
            get 
            { 
                return maxEntities; 
            }
            
            set 
            { 
                maxEntities = value; 
            }
        }

        /// <summary>
        /// target managed entities
        /// </summary>
        public IEnumerable<IDataObject> Targets
        {
            get 
            { 
                return targets ?? (targets = GetDefaultInput()); 
            }
            
            set 
            { 
                targets = value; 
            }
        }

        /// <summary>
        /// recursively select the related objects of this type
        /// </summary>
        public string[] RecursionTypeNames
        {
            get 
            { 
                return recursionTypeNames ?? (recursionTypeNames = GetDefaultRecursionTypeNames()); 
            }
            
            set 
            { 
                recursionTypeNames = value; 
            }
        }

        /// <summary>
        /// properties by which the output is to be sorted
        /// </summary>
        public IEnumerable<SortValueDefinitionType> SortProperties
        {
            get 
            { 
                return sortProperties ?? (sortProperties = GetDefaultSortProperties()); 
            }
            
            set 
            { 
                sortProperties = value; 
            }
        }

        #endregion

        /// <summary>
        /// Always wait for the composition to be ready
        /// </summary>
        protected override bool ShouldWait
        {
            get { return true; }
        }

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.GetManagedEntitiesDataSource"; }
        }

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch(propertyName)
            {
                case PropertyNames.Refresh:
                    {
                        Utilities.LogMessage("Set GetManagedEntitiesDataSource.Refresh = true ", true);
                        compRequest.SetParameter(PropertyNames.Refresh, value);
                        break;
                    }

                case PropertyNames.PropertiesInclusion:
                    {
                        var propertiesToBeAdded = ManagedEntityProperty.GetValueDefinitions(value as List<string>);
                        var newSetOfProperties = DataQuery.CalculateNewColumnList(Properties, propertiesToBeAdded, true);

                        if (AreDifferent(Properties, newSetOfProperties))
                        {
                            Properties = newSetOfProperties;
                            Utilities.LogMessage("Set GetManagedEntitiesDataSource.Properties: " + ValueDefinitionType.ToString(Properties), true);
                            compRequest.SetParameter(PropertyNames.Properties, ValueDefinitionType.ToIDataObject(Properties));
                        }

                        break;
                    }

                case PropertyNames.PropertiesExclusion:
                    {
                        var propertiesToBeDeleted = ManagedEntityProperty.GetValueDefinitions(value as List<string>);
                        var newSetOfProperties = DataQuery.CalculateNewColumnList(Properties, propertiesToBeDeleted, false);

                        if (AreDifferent(Properties, newSetOfProperties))
                        {
                            Properties = newSetOfProperties;
                            Utilities.LogMessage("Set GetManagedEntitiesDataSource.Properties: " + ValueDefinitionType.ToString(Properties), true);
                            compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        }

                        break;
                    }

                case PropertyNames.RelatedObjectsInclusion:
                    {
                        var relatedObjects = ManagedEntityProperty.ValueDefinitions[ManagedEntityProperty.PropertyNames.RelatedObjects];
                        relatedObjects.XPath = value as string;

                        var additionalProperties = new List<ValueDefinitionType>();
                        additionalProperties.Add(relatedObjects);
                        
                        Properties = Properties.Union(additionalProperties);

                        Utilities.LogMessage("Set GetManagedEntitiesDataSource." + ManagedEntityProperty.PropertyNames.RelatedObjects + " : " + relatedObjects.XPath, true);
                        compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        break;
                    }

                case PropertyNames.CriteriaString:
                    {
                        CriteriaString = value as string;
                        Utilities.LogMessage("Set GetManagedEntitiesDataSource.CriteriaString: " + CriteriaString, true);
                        compRequest.SetParameter(PropertyNames.CriteriaString, CriteriaString);
                        break;
                    }

                case PropertyNames.BaseTypeNamesInclusion:
                    {
                        var result = new List<string>(BaseTypeNames);
                        foreach (var item in value as List<string>)
                        {
                            result.Add(item); // do not check for duplicates
                        }

                        if (AreDifferent(BaseTypeNames, result))
                        {
                            BaseTypeNames = result.ToArray();
                            Utilities.LogMessage("Set GetManagedEntitiesDataSource.BaseTypeNames: " + this.ConvertToString(BaseTypeNames), true);
                            var baseTypeNamesAsIDataObjects = BaseTypeNames.Select(item => new BaseManagementPackType(item)).ToList();
                            compRequest.SetParameter(PropertyNames.BaseTypeNames, baseTypeNamesAsIDataObjects);
                        }

                        break;
                    }

                case PropertyNames.BaseTypeNamesExclusion:
                    {
                        var result = new List<string>(BaseTypeNames);
                        foreach(var item in (value as List<string>))
                        {
                            result.RemoveAll(s => s.Equals(item, StringComparison.OrdinalIgnoreCase)); // remove all instances of the property
                        }

                        if (AreDifferent(BaseTypeNames, result))
                        {
                            BaseTypeNames = result.ToArray();
                            Utilities.LogMessage("Set GetManagedEntitiesDataSource.BaseTypeNames: " + this.ConvertToString(BaseTypeNames), true);
                            var baseTypeNamesAsIDataObjects = BaseTypeNames.Select(item => (new BaseManagementPackType(item)).ToIDataObject()).ToList();
                            compRequest.SetParameter(PropertyNames.BaseTypeNames, baseTypeNamesAsIDataObjects);
                        }

                        break;
                    }

                case PropertyNames.MaxEntities:
                    {
                        MaxEntities = (int) value;
                        Utilities.LogMessage("Set GetManagedEntitiesDataSource.MaxEntities: " + MaxEntities, true);
                        compRequest.SetParameter(PropertyNames.MaxEntities, MaxEntities);
                        break;
                    }

                case PropertyNames.TargetEntities:
                    {
                        Targets = value as IEnumerable<IDataObject>;
                        Utilities.LogMessage("Set GetManagedEntitiesDataSource.TargetEntities.Count: " + Targets.Count(), true);
                        compRequest.SetParameter(PropertyNames.TargetEntities, Targets);
                        break;
                    }

                case PropertyNames.RecursionTypeNames:
                    {
                        RecursionTypeNames = (value as List<string>).ToArray();
                        Utilities.LogMessage("Set GetManagedEntitiesDataSource.RecursionTypeNames: " + ConvertToString(RecursionTypeNames), true);
                        var recursionTypeNamesIDataObjects = RecursionTypeNames.Select(item => (new BaseManagementPackType(item)).ToIDataObject()).ToList();
                        compRequest.SetParameter(PropertyNames.RecursionTypeNames, recursionTypeNamesIDataObjects);
                        break;
                    }

                case PropertyNames.SortProperties:
                    {
                        SortProperties = ManagedEntityProperty.GetSortProperties(value as List<string>);
                        Utilities.LogMessage("Set GetManagedEntitiesDataSource.SortProperties: " + SortValueDefinitionType.ToString(SortProperties), true);
                        compRequest.SetParameter(PropertyNames.SortProperties, SortValueDefinitionType.ToObservableCollection(SortProperties));
                        break;
                    }

                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }
        
        /// <summary>
        /// Collections are same if they have the same items, order is ignored
        /// </summary>
        private bool AreDifferent(IEnumerable<ValueDefinitionType> col1, IEnumerable<ValueDefinitionType> col2)
        {
            if (col1.Count() != col2.Count())
            {
                return true;
            }

            if (col2.Any(item => !col1.Contains(item)))
            {
                return true;
            }

            if (col1.Any(item => !col2.Contains(item)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Collection of string is the same if they have the same values, order does not matter
        /// </summary>
        private bool AreDifferent(IEnumerable<string> col1, IEnumerable<string> col2)
        {
            if (col1.Count() != col2.Count())
            {
                return true;
            }

            if (col2.Any(item => !col1.Contains(item)))
            {
                return true;
            }

            if (col1.Any(item => !col2.Contains(item)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Default query parameter values used while creating a new instance of the query
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            var retVal = base.GetDefaultQueryParameters();

            // Query specific properties
            retVal.Add(PropertyNames.CriteriaString, CriteriaString);
            retVal.Add(PropertyNames.BaseTypeNames, BaseTypeNames.Select(item => (new BaseManagementPackType(item)).ToIDataObject()).ToList());
            retVal.Add(PropertyNames.MaxEntities, MaxEntities);
            retVal.Add(PropertyNames.TargetEntities, Targets);
            retVal.Add(PropertyNames.RecursionTypeNames, RecursionTypeNames.Select(item => (new BaseManagementPackType(item)).ToIDataObject()).ToList());
            retVal.Add(PropertyNames.SortProperties, SortProperties);
            retVal.Add(PropertyNames.Output, GetDefaultOutput());

            return retVal;
        }

        /// <summary>
        /// Return a string form of the parameters for logging.
        /// </summary>
        public override string LogParameters()
        {
            var dcCriteriaString = this.CriteriaString;
            var strings = this.BaseTypeNames; 
            var dcBaseTypeNames = strings.Aggregate("", (current, s) => current + s);
            var dcMaxEntities = this.MaxEntities;
            return Environment.NewLine +
                   "Properties: " + ValueDefinitionType.ToString(Properties) + Environment.NewLine +
                   "CriteriaString: " + dcCriteriaString + Environment.NewLine +
                   "BaseTypeNames: " + dcBaseTypeNames + Environment.NewLine +
                   "MaxEntities: " + dcMaxEntities + Environment.NewLine +
                   "SortProperties: " + SortValueDefinitionType.ToString(this.SortProperties) + Environment.NewLine +
                   "RecursionTypeNames: " + ConvertToString(this.RecursionTypeNames);
        }

        private string[] GetDefaultBaseTypeNames()
        {
            return new[] { SystemLibrarySystemEntity };
        }

        private string GetDefaultCriteriaString()
        {
            return null;
        }

        private string[] GetDefaultRecursionTypeNames()
        {
            return new string[0];
        }

        /// <summary>
        /// Default list of properties of the managed entity that will be retreived
        /// </summary>
        public override IEnumerable<ValueDefinitionType> GetDefaultProperties()
        {
            return new List<ValueDefinitionType>
                                         {
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.InMaintenanceMode],
                                             // Commented because this value is potentially changed by HS between expected and actual data query
                                             // ManagedEntityProperty.ValueDefinitions[MEProperties.IsAvailable], 
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.IsManaged],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.Name],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.Path],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.DisplayName],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.FullName],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.LeastDerivedNonAbstractManagementPackClassId],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.TimeAdded],
                                             ManagedEntityProperty.ValueDefinitions[MEProperties.Id],
                                             // Bug 195532 ManagedEntityProperty.ValueDefinitions["LastModified"]
                                         };
            // TODO: Need to uncomment this - return ManagedEntityProperty.ValueDefinitions.Values.Where(p => !excludedProperties.Contains(p));
        }

        /// <summary>
        /// Convert an array of strings to a single concatenated string.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private string ConvertToString(string[] collection)
        {
            var sb = new StringBuilder();

            foreach(var item in collection)
            {
                sb.Append(item + ", ");
            }

            return sb.ToString();
        }
    }
}
