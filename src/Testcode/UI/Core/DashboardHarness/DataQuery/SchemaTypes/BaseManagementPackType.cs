using System;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class BaseManagementPackType
    {
        // schema type
        private const string BaseManagementPackTypeXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.OperationalDataTypes/BaseManagementPackType";
        
        // property name
        public static class PropertyNames
        {
            public const string FullyQualifiedName = "FullyQualifiedName";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly string fullyQualifiedName;

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static BaseManagementPackType()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(BaseManagementPackTypeXSD);
            dataType.Properties.Create(PropertyNames.FullyQualifiedName, typeof (string));
        }

        /// <summary>
        /// Get an instance of the BaseManagedEntityType 
        /// </summary>
        /// <param name="managedEntityId"></param>
        public BaseManagementPackType(string fullyQualifiedName)
        {
            this.fullyQualifiedName = fullyQualifiedName;
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            var instance = dataModel.CreateInstance(dataType);

            instance[PropertyNames.FullyQualifiedName] = fullyQualifiedName;

            return instance;
        }

        /// <summary>
        /// This is used to log an BaseManagementPackType object in a meaningful way
        /// </summary>
        public new string ToString()
        {
            return fullyQualifiedName;
        }
    }
}
