using System.Collections.Generic;
using System.Text;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    /// <summary>
    /// Use this to set DataTypeSpecifier on a Data Query
    /// </summary>
    public class DataTypeSpecifier
    {
        private const string DataTypeSpecifierXsd = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/DataTypeSpecifier";

        public static class PropertyNames
        {
            public static string DataType = "DataType";
            public static string ExtendedProperties = "ExtendedProperties";
        }

        protected static IDataType dataType;
        protected static SimpleDataModel DataModel;

        /// <summary>
        /// Property DataType on the DataTypeSpecifier
        /// </summary>
        public string DataType
        {
            get;
            set;
        }

        /// <summary>
        /// Property ExtendedProperties on the DataTypeSpecifier
        /// </summary>
        public ExtendedPropertiesType ExtendedProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Data Type of the DataTypeSpecifierType
        /// </summary>
        private static IDataType DataTypeSpecifierType
        {
            get
            {
                if (dataType == null)
                {
                    dataType = DataTypeSpecifierDataModel.Types.Create(DataTypeSpecifierXsd);
                    dataType.Properties.Create(PropertyNames.DataType, typeof(string));
                    dataType.Properties.Create(PropertyNames.ExtendedProperties, typeof(bool));  //???
                }

                return dataType;
            }
        }

        /// <summary>
        /// DataModel of the DataTypeSpecifier
        /// </summary>
        private static SimpleDataModel DataTypeSpecifierDataModel
        {
            get
            {
                return DataModel ?? (DataModel = new SimpleDataModel());
            }
        }

        /// <summary>
        /// Initialize an instance of DataTypeSpecifier
        /// </summary>
        public DataTypeSpecifier(string dataType, ExtendedPropertiesType extendedProperties)
        {
            DataType = dataType;
            ExtendedProperties = extendedProperties;
        }

        /// <summary>
        /// Convert the DataTypeSpecifier to an IDataObject
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = DataTypeSpecifierDataModel.CreateInstance(DataTypeSpecifierType);

            instance[PropertyNames.DataType] = DataType;
            instance[PropertyNames.ExtendedProperties] =
                ExtendedProperty.ToIDataObjectCollection(ExtendedProperties.Properties);

            return instance;
        }

        /// <summary>
        /// This is used to convert an enumeration of DataTypeSpecifiers into an IDataObjectCollection
        /// </summary>
        public static IDataObjectCollection ToIDataObjectCollection(IEnumerable<DataTypeSpecifier> dataTypeSpecifiers)
        {
            IDataObjectCollection collection = DataTypeSpecifierDataModel.CreateCollection(DataTypeSpecifierXsd);

            foreach(DataTypeSpecifier dts in dataTypeSpecifiers)
            {
                collection.Add(dts.ToIDataObject());
            }

            return collection;
        }

        /// <summary>
        /// This is used to log a set of DataTypeSpecifiers in a meaningful way
        /// </summary>
        public static string ToString(IEnumerable<DataTypeSpecifier> datatypes)
        {
            var sb = new StringBuilder();

            if (datatypes != null)
            {
                foreach (var item in datatypes)
                {
                    sb.Append(item.DataType + ":" + item.ExtendedProperties.ToString() + ",");
                }
            }

            return "{ " + sb + " }";
        }
    }
}
