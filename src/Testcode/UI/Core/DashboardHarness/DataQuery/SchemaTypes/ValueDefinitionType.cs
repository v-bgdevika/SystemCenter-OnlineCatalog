using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    /// <summary>
    /// Use this to request the property value from the query
    /// </summary>
    public class ValueDefinitionType 
    {
        // schema type
        private const string ValueDefinitionTypeXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/ValueDefinition";

        public static class PropertyNames
        {
            public static string OutputPropertyName = "OutputPropertyName";
            public static string XPath = "XPath";
            public static string DisplayName = "DisplayName";
        }

        protected static IDataType dataType = null;
        protected static SimpleDataModel dataModel = null;
        private string expectedDisplayName = null;

        /// <summary>
        /// Property name on the output of the data query
        /// </summary>
        public string OutputPropertyName 
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
        /// DisplayName value that the product understands
        /// </summary>
        public string DisplayName 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// This is used as the column name of the expected data table
        /// </summary>
        public string PropertyName 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Data Type of the property value, used to build the dataColumn 
        /// for the property
        /// </summary>
        public Type PropertyType 
        { 
            get; 
            set; 
        }
        
        /// <summary>
        /// If true, then the property is real
        /// If false, the property is calculated
        /// </summary>
        public bool IsRealProperty 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Set the display name format protocol:protocolString
        /// </summary>
        public string ExpectedDisplayName
        {
            get 
            { 
                return TranslateString(expectedDisplayName); 
            }

            set 
            { 
                expectedDisplayName = value; 
            }
        }

        /// <summary>
        /// Data type of the ValueDefinitionType
        /// </summary>
        private static IDataType ValueDefType
        {
            get
            {
                if (dataType == null)
                {
                    dataType = ValueDefDataModel.Types.Create(ValueDefinitionTypeXSD);
                    dataType.Properties.Create(PropertyNames.OutputPropertyName, typeof(string));
                    dataType.Properties.Create(PropertyNames.XPath, typeof(string));
                    dataType.Properties.Create(PropertyNames.DisplayName, typeof(string));
                }

                return dataType;
            }
        }

        /// <summary>
        /// DataModel of the ValueDefinitionType
        /// </summary>
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
        /// Initialize an instance of ValueDefinitionType when the expected display name is not known
        /// </summary>
        public ValueDefinitionType( 
            string outputPropertyName, 
            string xPath, 
            string displayName, 
            string propertyName,
            Type propertyType,
            bool isReal) : this(outputPropertyName, xPath, displayName, null, propertyName, propertyType, isReal)
        {
        }

        /// <summary>
        /// Initialize an instance of ValueDefinitionType when the expected display name is known
        /// </summary>
        public ValueDefinitionType(
            string outputPropertyName,
            string xPath,
            string displayName,
            string expectedDisplayName,
            string propertyName,
            Type propertyType,
            bool isReal)
        {
            this.OutputPropertyName = outputPropertyName;
            this.XPath = xPath;
            this.DisplayName = displayName;
            this.ExpectedDisplayName = expectedDisplayName;
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.IsRealProperty = isReal;
        }

        /// <summary>
        /// Convert the ValueDefinitionType to an IDataObject
        /// </summary>
        public IDataObject ToIDataObject()
        {
            var instance = ValueDefDataModel.CreateInstance(ValueDefType);

            instance[PropertyNames.DisplayName] = this.DisplayName;
            instance[PropertyNames.OutputPropertyName] = this.OutputPropertyName;
            instance[PropertyNames.XPath] = this.XPath;

            return instance;
        }

        /// <summary>
        /// Convert the collection of ValueDefinitionType objects to 
        /// collection of IDataObjects
        /// </summary>
        public static IEnumerable<IDataObject> ToIDataObject(IEnumerable<ValueDefinitionType> list)
        {
            if (list == null) throw new ArgumentNullException("list");

            var retVal = new ObservableCollection<IDataObject>();

            foreach (var valueDefinitionType in list)
            {
                retVal.Add(valueDefinitionType.ToIDataObject());
            }

            return retVal;
        }

        /// <summary>
        /// Convert the expected display name to the actual display string
        /// </summary>
        /// <param name="expectedDisplayName"></param>
        /// <returns></returns>
        private string TranslateString(string expectedDisplayName)
        {
            // if the expected display name is null, then 
            // the display name is same as the output property
            if (expectedDisplayName == null)
            {
                return this.OutputPropertyName;
            }

            // expected display name format is protocol:protocolstring
            // if the string is not as per protocol retuen it as is.
            var splitString = expectedDisplayName.Trim().Split(':');
            if (splitString.Length < 2)
            {
                return expectedDisplayName;
            }

            // handle different protocols
            var protocol = splitString[0];
            switch (protocol)
            {
                case "DEF":
                    {
                        // Treat the protocol string as is. 
                        // If there were additional ':' characters 
                        // then assembly the remaining strings back
                        var retVal = "";
                        for (int i = 1; i < splitString.Length; i++)
                        {
                            retVal += splitString[i];
                        }

                        return retVal;
                    }

                case "MP":
                    {
                        // treat the protocolstring as the resource id
                        var resourceId = splitString[1].Split('!');
                        var mpName = resourceId[0];
                        var id = resourceId[1];

                        var connection = UnityContainerHelpers.GetConnection();
                        var mps = connection.ManagementPacks.GetManagementPacks(new ManagementPackCriteria("Name = '" + mpName + "'"));
                        var mp = mps[0];

                        ManagementPackElement mpElement = null;
                        try
                        {
                            mpElement = mp.FindManagementPackElementByName(id);
                        }
                        catch
                        {
                        }

                        return mpElement == null ? id : mpElement.DisplayName;
                    }

                case "NONE":
                    {
                        return null;
                    }

                default:
                    {
                        throw new Exception("DisplayString protocol not supported. Protocol: " + protocol);
                    }
            }
        }

        /// <summary>
        /// Get the expected display names as an IDataObject for the properties
        /// </summary>
        public static IDataObject GetExpectedDisplayStrings(List<ValueDefinitionType> properties)
        {
            var displayStringEntries = new List<KeyValuePair<string, string>>();

            // Get the translated expected display string for each of the properties
            foreach (var valueDefinitionType in properties)
            {
                displayStringEntries.Add(new KeyValuePair<string, string>(valueDefinitionType.PropertyName, valueDefinitionType.ExpectedDisplayName));           
            }

            // build an IDataObject out of it.
            return DataObjectHelpers.GetDisplayStringDataObject(displayStringEntries);
        }

        /// <summary>
        /// This is used to log the property names in a meaningful way
        /// </summary>
        public static string ToString(IEnumerable<ValueDefinitionType> properties)
        {
            var sb = new StringBuilder();

            if (properties != null)
            {
                foreach (ValueDefinitionType item in properties)
                {
                    sb.Append(item.PropertyName + ":" + item.PropertyType + ", ");
                }
            }

            return "{ " + sb + " }";
        }

        /// <summary>
        /// This is used to convert an enumeration of ValueDefinitionTypes into an IDataObjectCollection
        /// </summary>
        public static IDataObjectCollection ToIDataObjectCollection(IEnumerable<ValueDefinitionType> properties)
        {
            IDataObjectCollection collection = ValueDefDataModel.CreateCollection(ValueDefinitionTypeXSD);

            if (properties != null)
            {
                foreach (ValueDefinitionType item in properties)
                {
                    collection.Add(item.ToIDataObject());
                }
            }

            return collection;
        }
    }
}
