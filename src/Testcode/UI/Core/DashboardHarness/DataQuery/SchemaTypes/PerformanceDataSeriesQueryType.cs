using System;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class PerformanceDataSeriesQueryType
    {
        // schema type
        private const string PerformanceDataSeriesQueryTypeXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/PerformanceDataSeriesQueryType";
        
        // property name
        public static class PropertyNames
        {
            public const string PerformanceObjectName = "PerformanceObjectName";
            public const string PerformanceCounterName = "PerformanceCounterName";
            public const string PerformanceCounterInstanceName = "PerformanceCounterInstanceName";
            public const string ManagedEntityIds = "ManagedEntityIds";
            public const string DatapointReduction = "DatapointReduction";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly string performanceObjectName;
        private readonly string performanceCounterName;
        private readonly string performanceCounterInstanceName;
        private readonly Guid[] managedEntityIds;
        private readonly string datapointReduction;

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static PerformanceDataSeriesQueryType()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(PerformanceDataSeriesQueryTypeXSD);
            dataType.Properties.Create(PropertyNames.PerformanceObjectName, typeof(String));
            dataType.Properties.Create(PropertyNames.PerformanceCounterName, typeof(String));
            dataType.Properties.Create(PropertyNames.PerformanceCounterInstanceName, typeof(String));
            dataType.Properties.Create(PropertyNames.ManagedEntityIds, typeof(IEnumerable<IDataObject>));
            dataType.Properties.Create(PropertyNames.DatapointReduction, typeof(String));
        }

        /// <summary>
        /// Get an instance of the PerformanceDataSeriesQueryType 
        /// </summary>
        /// <param name="managedEntityId"></param>
        public PerformanceDataSeriesQueryType(string objectName, string counterName, string instanceName, Guid[] managedEntityIds, string datapointReduction)
        {
            this.performanceObjectName = objectName;
            this.performanceCounterName = counterName;
            this.performanceCounterInstanceName = instanceName;
            this.managedEntityIds = managedEntityIds;
            this.datapointReduction = datapointReduction;
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            //Set for TargetGroup
            IDataObjectCollection managedEntities = dataModel.CreateCollection();

            foreach(Guid entityId in managedEntityIds)
            {
                BaseManagedEntityType entity = new BaseManagedEntityType(entityId);
                managedEntities.Add(entity.ToIDataObject());
            }
            
            var instance = dataModel.CreateInstance(dataType);
            instance[PropertyNames.PerformanceObjectName] = performanceObjectName;
            instance[PropertyNames.PerformanceCounterName] = performanceCounterName;
            instance[PropertyNames.PerformanceCounterInstanceName] = performanceCounterInstanceName;
            instance[PropertyNames.ManagedEntityIds] = managedEntities;
            instance[PropertyNames.DatapointReduction] = datapointReduction;

            return instance;
        }

        /// <summary>
        /// This is used to log an PerformanceDataSeriesQueryType object in a meaningful way
        /// </summary>
        public new string ToString()
        {
            string Ids = string.Empty;

            foreach (Guid id in managedEntityIds)
            {
                Ids += ", " + id.ToString(); 
            }

            //Remove the first comma and space
            if (Ids.Length > 0)
            {
                Ids = Ids.Substring(2);
            }
            
            return PropertyNames.PerformanceObjectName + " = " + performanceObjectName + ", " + 
                   PropertyNames.PerformanceCounterName + " = " + performanceCounterName + ", " +
                   PropertyNames.ManagedEntityIds + " = (" + Ids + "), " +
                   PropertyNames.PerformanceCounterInstanceName + " = " + performanceCounterInstanceName + ", " +
                   PropertyNames.DatapointReduction + " = " + datapointReduction;
        }
    }
}
