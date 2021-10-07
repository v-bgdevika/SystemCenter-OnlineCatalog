using System.Collections.Generic;
using System.Text;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    /// <summary>
    /// Use this to set Parameters in Data Queries
    /// </summary>
    public class Parameter
    {
        // schema type
        private const string ParameterXsd = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/Parameter";

        public static class PropertyNames
        {
            public static string Name = "Name";
            public static string Value = "Value";
        }

        protected static IDataType DataType;
        protected static SimpleDataModel DataModel;

        /// <summary>
        /// Name of the Parameter
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Value of the Parameter
        /// </summary>
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// Data Type of the ParameterType
        /// </summary>
        private static IDataType ParameterType
        {
            get
            {
                if (DataType == null)
                {
                    DataType = ParameterDataModel.Types.Create(ParameterXsd);
                    DataType.Properties.Create(PropertyNames.Name, typeof(string));
                    DataType.Properties.Create(PropertyNames.Value, typeof(string));  
                }

                return DataType;
            }
        }

        /// <summary>
        /// DataModel of the ParameterType
        /// </summary>
        private static SimpleDataModel ParameterDataModel
        {
            get
            {
                return DataModel ?? (DataModel = new SimpleDataModel());
            }
        }

        /// <summary>
        /// Initialize an instance of Parameter
        /// </summary>
        public Parameter(
            string name, 
            string value
            )
        {
            Name = name;
            Value = value;
        }
        
        /// <summary>
        /// Convert the Parameter to an IDataObject
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = ParameterDataModel.CreateInstance(ParameterType);

            instance[PropertyNames.Name] = Name;
            instance[PropertyNames.Value] = Value;

            return instance;
        }

        /// <summary>
        /// This is used to convert an enumeration of Paraemters into an IDataObjectCollection
        /// </summary>
        public static IDataObjectCollection ToIDataObjectCollection(IEnumerable<Parameter> parameters)
        {
            IDataObjectCollection collection = ParameterDataModel.CreateCollection(ParameterXsd);

            if (parameters != null)
            {
                foreach (Parameter item in parameters)
                {
                    collection.Add(item.ToIDataObject());
                }
            }

            return collection;
        }

        /// <summary>
        /// This is used to log a Parameter in a meaningful way
        /// </summary>
        public new string ToString()
        {
            return Name + ":" + Value;
        }

        /// <summary>
        /// This is used to log a set of Parameters in a meaningful way
        /// </summary>
        public static string ToString(IEnumerable<Parameter> parameters)
        {
            var sb = new StringBuilder();

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    sb.Append(item.ToString());
                }
            }

            return "{ " + sb + " }";
        }

    }
}
