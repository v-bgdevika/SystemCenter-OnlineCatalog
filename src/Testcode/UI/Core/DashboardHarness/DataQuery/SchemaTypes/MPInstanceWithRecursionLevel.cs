using System;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class MPInstanceWithRecursionLevelType
    {
        // schema type
        private const string MPInstanceWithRecursionLevelXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataProvider/MPInstanceWithRecursionLevel";
        
        // property name
        public static class PropertyNames
        {
            public const string MPInstance = "MPInstance";
            public const string RecursionLevel = "RecursionLevel";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly BaseManagedEntityType mpInstance;
        private readonly int recursionLevel;

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static MPInstanceWithRecursionLevelType()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(MPInstanceWithRecursionLevelXSD);
            dataType.Properties.Create(PropertyNames.MPInstance, typeof (IDataObject));
            dataType.Properties.Create(PropertyNames.RecursionLevel, typeof (int));
        }

        /// <summary>
        /// Get an instance of the BaseManagedEntityType 
        /// </summary>
        /// <param name="managedEntityId"></param>
        public MPInstanceWithRecursionLevelType(BaseManagedEntityType mpInstance, int recursionLevel)
        {
            this.mpInstance = mpInstance;
            this.recursionLevel = recursionLevel;
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            var instance = dataModel.CreateInstance(dataType);

            instance[PropertyNames.MPInstance] = mpInstance.ToIDataObject();
            instance[PropertyNames.RecursionLevel] = recursionLevel;

            return instance;
        }
    }
}
