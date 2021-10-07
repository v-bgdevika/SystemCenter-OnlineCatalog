using System;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class BaseManagedEntityWithRecursionLevel 
    {
        // schema type
        private const string BaseManagedEntityWithRecursionLevelXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataProvider/BaseManagedEntityWithRecursionLevel";

        // property name
        public static class PropertyNames
        {
            public const string ManagedEntityId = "Id";
            public const string RecursionLevel = "RecursionLevel";
        }

        private readonly Guid managedEntityId;
        protected readonly int recursionLevel;

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        /// <summary>
        /// Build the data model and the data type once
        /// </summary>
        static BaseManagedEntityWithRecursionLevel()
        {
            dataModel = new ObservableDataModel();

            dataType = dataModel.Types.Create(BaseManagedEntityWithRecursionLevelXSD);
            dataType.Properties.Create(PropertyNames.ManagedEntityId, typeof(string));
            dataType.Properties.Create(PropertyNames.RecursionLevel, typeof(int));
        }

        /// <summary>
        /// Build an instance of BaseManagedEntityWithRecursionLevel type
        /// </summary>
        public BaseManagedEntityWithRecursionLevel(Guid managedEntityId, int recursionLevel)
        {
            this.managedEntityId = managedEntityId;
            this.recursionLevel = recursionLevel;
        }

        /// <summary>
        /// Get an IDataObject representation
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = dataModel.CreateInstance(dataType);

            instance[PropertyNames.ManagedEntityId] = managedEntityId;
            instance[PropertyNames.RecursionLevel] = recursionLevel;

            return instance;
        }

    }
}
