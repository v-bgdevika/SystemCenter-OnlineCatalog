using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Monitoring.UnitComponents.Data;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetAlertsForEntitiesDataSourceQuery : CommonDataSourceInterface
    {
        #region private fields

        private IEnumerable<IDataObject> sortProperties;
        private IEnumerable<IDataObject> managedEntities = null;
        private object criteriaString = null;

        #endregion

        #region private properties

        public IEnumerable<IDataObject> SortProperties
        {
            get { return sortProperties ?? (sortProperties = GetDefaultSortProperties()); }
            set { sortProperties = value; }
        }

        private IEnumerable<IDataObject> ManagedEntities
        {
            get { return managedEntities ?? (managedEntities = GetDefaultInput()); }
            set { managedEntities = value; }
        }

        #endregion

        #region Overridden properties

        protected override Dictionary<string, object> QueryParameters
        {
            get { return queryParameters ?? (queryParameters = GetDefaultParameters()); }
        }

        protected override bool ShouldWait
        {
            get
            {
                return ((managedEntities != null) &&
                        (sortProperties != null) &&
                        (criteriaString != null) &&
                        (properties != null));
            }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!GetAlertsForEntitiesDataSource"; }
        }

        #endregion

        #region default values

        private Dictionary<string, object> GetDefaultParameters()
        {
            var retVal = base.GetDefaultQueryParameters();

            // Query specific properties
            retVal.Add("SortProperties", SortProperties);
            retVal.Add("ManagedEntities", ManagedEntities);
            retVal.Add("CriteriaString", "ResolutionState != 255");

            return retVal;
        }


        #endregion

        #region Overridden methods

        public override IEnumerable<ValueDefinitionType> GetDefaultProperties()
        {
            return new List<ValueDefinitionType>()
                       {
                           AlertProperty.ValueDefinitions[AlertHelper.Id],
                       };
        }

        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case "ManagedEntities":
                    {
                        ManagedEntities = value as IEnumerable<IDataObject>;
                        compRequest.SetParameter("ManagedEntities", ManagedEntities);
                        break;
                    }

                case "SortProperties":
                    {
                        SortProperties = SortValueDefinitionType.ToObservableCollection(AlertProperty.GetSortProperties(value as List<string>));
                        compRequest.SetParameter("SortProperties", SortProperties);
                        break;
                    }

                case "CriteriaString":
                    {
                        criteriaString = value;
                        compRequest.SetParameter("CriteriaString", value as string);
                        break;
                    }

                case "Properties_Inclusion":
                    {
                        var additionalProperties = AlertProperty.GetValueDefinitions(value as List<string>);
                        Properties = GetColumns(Properties, additionalProperties, true);
                        compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        break;
                    }

                case "Properties_Exclusion":
                    {
                        var propertiesToBeDeleted = AlertProperty.GetValueDefinitions(value as List<string>);
                        Properties = GetColumns(Properties, propertiesToBeDeleted, false);
                        compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        break;
                    }

                case "Refresh":
                    {
                        compRequest.SetParameter("Refresh", value);
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException("Propery name: " + propertyName);
                    }
            }
        }

        #endregion
    }
}