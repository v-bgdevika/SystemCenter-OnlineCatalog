using System;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class BaseManagedEntityType
    {
        // schema type
        private const string BaseManagedEntityXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!BaseManagedEntity";
        
        // property name
        public static class PropertyNames
        {
            public const string ManagedEntityId = "Id";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly Guid managedEntityId;

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static BaseManagedEntityType()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(BaseManagedEntityXSD);
            dataType.Properties.Create(PropertyNames.ManagedEntityId, typeof (string));
        }

        /// <summary>
        /// Get an instance of the BaseManagedEntityType 
        /// </summary>
        /// <param name="managedEntityId"></param>
        public BaseManagedEntityType(Guid managedEntityId)
        {
            this.managedEntityId = managedEntityId;
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            var instance = dataModel.CreateInstance(dataType);

            instance[PropertyNames.ManagedEntityId] = managedEntityId;

            return instance;
        }
    }
}