using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

// ReSharper disable CheckNamespace
namespace Mom.Test.UI.Core.GenericDataQuery
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Use this to set ExtendedPropertiesType on a Data Query
    /// </summary>
    public class ExtendedPropertiesType
    {
        //schema type
        private const string ExtendedPropertiesTypeXsd = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/ExtendedProperties";

        private readonly IEnumerable<ExtendedProperty> _properties;

        protected static IDataType DataType;
        protected static SimpleDataModel DataModel;

        /// <summary>
        /// Set of ExtendedProperty objects 
        /// </summary>
        public IEnumerable<ExtendedProperty> Properties
        {
            get { return _properties; }
        }

        /// <summary>
        /// Data type of the ExtendedPropertiesType
        /// </summary>
        private static IDataType ExtendedPropertiesTypeType
        {
            get
            {
                return DataType ?? (DataType = ExtendedPropertiesTypeDataModel.Types.Create(ExtendedPropertiesTypeXsd));
            }
        }

        /// <summary>
        /// DataModel of the ExtendedPropertiesType
        /// </summary>
        private static SimpleDataModel ExtendedPropertiesTypeDataModel
        {
            get
            {
                return DataModel ?? (DataModel = new SimpleDataModel());
            }
        }

        /// <summary>
        /// Initialize an instance of ExtendedProeprtiesType
        /// </summary>
        public ExtendedPropertiesType(IEnumerable<ExtendedProperty> properties)
        {
            _properties = properties ?? new List<ExtendedProperty>();
        }

        /// <summary>
        /// Convert the ExtendedProeprtiesType to an IDataObject
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = ExtendedPropertiesTypeDataModel.CreateInstance(ExtendedPropertiesTypeType);
            return instance;
        }

        /// <summary>
        /// Convert the ExtendedPropertiesType objects to an IDataObjectCollection
        /// </summary>
        public IDataObjectCollection ToIDataObjectCollection()
        {
            return ExtendedProperty.ToIDataObjectCollection(_properties);
        }

        /// <summary>
        /// This is used to log an ExtendedPropertiesType object in a meaningful way
        /// </summary>
        public new string ToString()
        {
            return ExtendedProperty.ToString(_properties);
        }
    }
}
