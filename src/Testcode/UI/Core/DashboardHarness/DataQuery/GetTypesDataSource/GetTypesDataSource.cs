using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;


namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetTypesDataSource : CommonDataSourceInterface
    {
        #region Property Names
        private const string SystemLibrarySystemEntity = "System.Library!System.Entity";

        new public class PropertyNames
        {
            public const string Properties = "Properties";
            public const string PropertiesInclusion = "Properties_Inclusion";
            public const string PropertiesExclusion = "Properties_Exclusion";
            public const string BaseTypeNames = "BaseTypeNames";
            public const string BaseTypeNamesInclusion = "BaseTypeNames_Inclusion";
            public const string BaseTypeNamesExclusion = "BaseTypeNames_Exclusion";
            public const string Recurse = "Recurse";
            public const string Refresh = "Refresh";
            public const string Output = "Output";
            public const string DisplayStrings = "DisplayStrings";
        }

        #endregion

        #region private fields

        private string[] baseTypeNames; // list of managed entities for which the properties are to be retreived.
        private bool recurse;

        #endregion

        #region Overridden properties

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
       {
           get { return "Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.GetTypesDataSource"; }
        }

        #endregion

        #region public properties

        /// <summary>
        /// criteria used to select the alert
        /// </summary>
        public bool Recurse
        {
            get 
            {
                return recurse; 
            }
            
            set 
            {
                recurse = value; 
            }
        }


        /// <summary>
        /// list of managed entities for which the alerts are to be retreived.
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


        

        #endregion

        #region default values

        /// <summary>
        /// Default values used in the creation of the composition
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            var retVal = base.GetDefaultQueryParameters();

            // Query specific properties
            retVal.Add(PropertyNames.Recurse, recurse);
            retVal.Add(PropertyNames.BaseTypeNames, BaseTypeNames.Select(item => (new BaseManagementPackType(item)).ToIDataObject()).ToList());
            retVal.Add(PropertyNames.Output, GetDefaultOutput());

            return retVal;
        }

        #endregion

        #region Overriden methods

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {

                case PropertyNames.PropertiesInclusion:
                    {
                        var propertiesToBeAdded = ManagedEntityProperty.GetValueDefinitions(value as List<string>);
                        var newSetOfProperties = DataQuery.CalculateNewColumnList(Properties, propertiesToBeAdded, true);

                        if (AreDifferent(Properties, newSetOfProperties))
                        {
                            Properties = newSetOfProperties;
                            Utilities.LogMessage("Set GetTypesDataSource.Properties: " + ValueDefinitionType.ToString(Properties), true);
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
                            Utilities.LogMessage("Set GetTypesDataSource.Properties: " + ValueDefinitionType.ToString(Properties), true);
                            compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        }

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
                            Utilities.LogMessage("Set GetTypesDataSource.BaseTypeNames: " + this.ConvertToString(BaseTypeNames), true);
                            var baseTypeNamesAsIDataObjects = BaseTypeNames.Select(item => new BaseManagementPackType(item)).ToList();
                            compRequest.SetParameter(PropertyNames.BaseTypeNames, baseTypeNamesAsIDataObjects);
                        }

                        break;
                    }

                case PropertyNames.BaseTypeNamesExclusion:
                    {
                        var result = new List<string>(BaseTypeNames);
                        foreach (var item in (value as List<string>))
                        {
                            result.RemoveAll(s => s.Equals(item, StringComparison.OrdinalIgnoreCase)); // remove all instances of the property
                        }

                        if (AreDifferent(BaseTypeNames, result))
                        {
                            BaseTypeNames = result.ToArray();
                            Utilities.LogMessage("Set GetTypesDataSource.BaseTypeNames: " + this.ConvertToString(BaseTypeNames), true);
                            var baseTypeNamesAsIDataObjects = BaseTypeNames.Select(item => (new BaseManagementPackType(item)).ToIDataObject()).ToList();
                            compRequest.SetParameter(PropertyNames.BaseTypeNames, baseTypeNamesAsIDataObjects);
                        }

                        break;
                    }
                case PropertyNames.Recurse:
                    {
                        recurse = (bool)value;
                        Utilities.LogMessage("Set GetTypesDataSource.Recurse: " + Recurse.ToString(), true);
                        compRequest.SetParameter(PropertyNames.Recurse, Recurse);
                        break;
                    }


                case PropertyNames.Refresh:
                    {
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.Refresh = true ", true);
                        compRequest.SetParameter(PropertyNames.Refresh, value);
                        break;
                    }

                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        protected override bool ShouldWait
        {
            get
            {
                return (baseTypeNames != null);
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// String form of the parameters that is to be used for logging.
        /// </summary>
        /// <returns></returns>
        public override string LogParameters()
        {
            var newLine = Environment.NewLine;

            var strings = this.BaseTypeNames;
            var dcBaseTypeNames = strings.Aggregate("", (current, s) => current + s);

            return "Parameters: " + newLine +
                   "Properties: " + ValueDefinitionType.ToString(Properties) + Environment.NewLine +
                   "BaseTypeNames: " + dcBaseTypeNames + Environment.NewLine +
                   PropertyNames.Recurse + " : " + this.Recurse.ToString() + newLine;
        }

        private string[] GetDefaultBaseTypeNames()
        {
            return new[] { SystemLibrarySystemEntity };
        }


        /// <summary>
        /// Default list of properties of the managed entity that will be retreived
        /// </summary>
        public override IEnumerable<ValueDefinitionType> GetDefaultProperties()
        {

            return new List<ValueDefinitionType>
                                         { 
                                             ManagedEntityProperty.ValueDefinitions["Name"],
                                             ManagedEntityProperty.ValueDefinitions["DisplayName"],
                                             ManagedEntityProperty.ValueDefinitions["Id"]

                                         };
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
        /// Convert an array of strings to a single concatenated string.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private string ConvertToString(string[] collection)
        {
            var sb = new StringBuilder();

            foreach (var item in collection)
            {
                sb.Append(item + ", ");
            }

            return sb.ToString();
        }
        #endregion
    }
}
