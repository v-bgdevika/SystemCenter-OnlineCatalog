using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.DataQuery.SchemaTypes
{
    public class SortValueDefinitionType
    {
        // schema type
        private const string SortValueDefinitionTypeXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/SortValueDefinition";

        public static class PropertyNames
        {
            public static string XPath = "XPath";
            public static string Ascending = "Ascending";
        }

        protected static IDataType dataType = null;
        protected static SimpleDataModel dataModel = null;

        /// <summary>
        /// This is to help in logging the sort property name
        /// </summary>
        public string PropertyName 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// XPath for property extraction
        /// </summary>
        public string XPath 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Sort direction. 
        /// true - ascending 
        /// false - descending
        /// </summary>
        public bool Ascending 
        { 
            get; 
            set; 
        }

        private static IDataType ValueDefType
        {
            get
            {
                if (dataType == null)
                {
                    dataType = ValueDefDataModel.Types.Create(SortValueDefinitionTypeXSD);
                    dataType.Properties.Create(PropertyNames.XPath, typeof(string));
                    dataType.Properties.Create(PropertyNames.Ascending, typeof(bool));
                }

                return dataType;
            }
        }

        private static SimpleDataModel ValueDefDataModel
        {
            get
            {
                if (dataModel == null)
                {
                    dataModel = new SimpleDataModel();
                }

                return dataModel;
            }
        }

        /// <summary>
        /// Initializes an instance of the SortValueDefinitionType
        /// </summary>
        public SortValueDefinitionType(
            string propertyName, 
            string xPath, 
            bool ascending
            )
        {
            this.XPath = xPath;
            this.PropertyName = propertyName;
            this.Ascending = ascending;
        }

        /// <summary>
        /// Convert the SortValueDefinitionType to an IDataObject
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = ValueDefDataModel.CreateInstance(ValueDefType);
            
            instance[PropertyNames.XPath] = this.XPath;
            instance[PropertyNames.Ascending] = this.Ascending;

            return instance;
        }

        /// <summary>
        /// Convert the collection of SortValueDefinitionType objects to 
        /// collection of IDataObjects
        /// </summary>
        public static IEnumerable<IDataObject> ToObservableCollection(IEnumerable<SortValueDefinitionType> list)
        {
            if (list == null) throw new ArgumentNullException("list");

            var retVal = new ObservableCollection<IDataObject>();

            foreach (var item in list)
            {
                retVal.Add(item.ToIDataObject());
            }

            return retVal;
        }

        /// <summary>
        /// This is used to log the property names in a meaningful way
        /// </summary>
        public static string ToString(IEnumerable<SortValueDefinitionType> sortProperties)
        {
            var sb = new StringBuilder();
            if (sortProperties != null)
            {
                foreach (var item in sortProperties)
                {
                    sb.Append(item.PropertyName + ", ");
                }
            }

            return "{ " + sb + " }";
        }
    }
}
