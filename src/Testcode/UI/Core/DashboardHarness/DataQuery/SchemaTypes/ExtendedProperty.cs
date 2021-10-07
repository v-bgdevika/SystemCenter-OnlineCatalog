using System.Collections.Generic;
using System.Text;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    /// <summary>
    /// Use this to set ExtendedProperty on a Data Query
    /// </summary>
    public class ExtendedProperty
    {
        // schema type
        private const string ExtendedPropertyXsd = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/ExtendedProperty";

        public static class PropertyNames
        {
            public static string Name = "Name";
            public static string Type = "Type";
        }

        protected static IDataType DataType;
        protected static SimpleDataModel DataModel;

        /// <summary>
        /// Property name on the ExtendedProperty
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Property type on the ExtendedProperty
        /// </summary>
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Data type of the ExtendedPropertyType
        /// </summary>
        private static IDataType ExtendedPropertyType
        {
            get
            {
                if (DataType == null)
                {
                    DataType = ExtendedPropertyDataModel.Types.Create(ExtendedPropertyXsd);
                    DataType.Properties.Create(PropertyNames.Name, typeof(string));
                    DataType.Properties.Create(PropertyNames.Type, typeof(string));  
                }

                return DataType;
            }
        }

        /// <summary>
        /// DataModel of the ExtendedProperty
        /// </summary>
        private static SimpleDataModel ExtendedPropertyDataModel
        {
            get
            {
                return DataModel ?? (DataModel = new SimpleDataModel());
            }
        }

        /// <summary>
        /// Initialize an instance of ExtendedProeprty
        /// </summary>
        public ExtendedProperty(
            string name, 
            string type
            )
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Convert the ExtendedProeprty to an IDataObject
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = ExtendedPropertyDataModel.CreateInstance(ExtendedPropertyType);

            instance[PropertyNames.Name] = Name;
            instance[PropertyNames.Type] = Type;

            return instance;
        }

        /// <summary>
        /// Convert the collection of ExtendedProperty objects to an IDataObjectCollection
        /// </summary>
        /// <param name="extendedProperties"></param>
        /// <returns></returns>
        public static IDataObjectCollection ToIDataObjectCollection(IEnumerable<ExtendedProperty> extendedProperties)
        {
            IDataObjectCollection collection = ExtendedPropertyDataModel.CreateCollection(ExtendedPropertyXsd);

            foreach (ExtendedProperty ep in extendedProperties)
            {
                collection.Add(ep.ToIDataObject());
            }

            return collection;
        }

        /// <summary>
        /// This is used to log an ExtendedProperty object in a meaningful way
        /// </summary>
        public new string ToString()
        {
            return Name + ":" + Type;
        }

        /// <summary>
        /// This is used to log a set of ExtendedProperty objects in a meaningful way
        /// </summary>
        public static string ToString(IEnumerable<ExtendedProperty> properties)
        {
            var sb = new StringBuilder();

            if (properties != null)
            {
                foreach (var item in properties)
                {
                    sb.Append(item.ToString());
                }
            }

            return "{ " + sb + " }";
        }

    }
}
