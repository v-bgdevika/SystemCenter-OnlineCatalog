using System;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class BaseDataType
    {
        // schema type
        private const string BaseDataTypeXSD = "xsd://System.Library!BaseDataType";
        
        // property name
        public static class PropertyNames
        {
            public const string Value = "Value";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly object value;

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static BaseDataType()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(BaseDataTypeXSD);
            dataType.Properties.Create(PropertyNames.Value, typeof (object));
        }

        /// <summary>
        /// Get an instance of the BaseManagedEntityType 
        /// </summary>
        /// <param name="objectValue"></param>
        public BaseDataType(object objectValue)
        {
            this.value = objectValue;
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            var instance = dataModel.CreateInstance(dataType);

            instance[PropertyNames.Value] = value;

            return instance;
        }

        public static object ToValue(IDataObject dataObject)
        {
            return dataObject[PropertyNames.Value];
        }
    }
}
