using System;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class DisplayStrings
    {
        // schema type
        private const string DisplayStringsXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.DataSourceTypes/DisplayStrings";
        
        private IDataType dataType;
        private DynamicObservableDictionaryDataModel<string> dataModel;

        private readonly Dictionary<string, string> properties;

        /// <summary>
        /// Property name value pairs
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> DisplayStringEntries
        {
            get
            {
                return this.properties;
            }
        }

        private DisplayStrings()
        {
            dataModel = new DynamicObservableDictionaryDataModel<string>("Id", "Value", "DisplayName");
            dataType = dataModel.Types.Create(DisplayStringsXSD);
        }

        /// <summary>
        /// Initializes and instance of the DisplayStrings type with the collection of
        /// display name and value pairs
        /// </summary>
        public DisplayStrings(IEnumerable<KeyValuePair<string, string>> displayStringEntries)
            : this()
        {
            this.properties = new Dictionary<string, string>();
            foreach (var item in displayStringEntries)
            {
                this.properties.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Initializes and instance of the DisplayStrings type with an IDataObject  that
        /// represents the collection of display name and value pairs
        /// </summary>
        public DisplayStrings(IDataObject displayStrings)
            : this()
        {
            this.properties = ConvertToDictionary(displayStrings);
        }

        /// <summary>
        /// Get an IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            // Create the data type
            foreach (var entry in this.properties)
            {
                dataType.Properties.Create(entry.Key, typeof(string));
            }

            var displayStrings = dataModel.CreateInstance(dataType);

            // Update the DisplayStrings object and data type
            foreach (var entry in this.properties)
            {
                displayStrings[entry.Key] = entry.Value;
            }

            return displayStrings;
        }

        /// <summary>
        /// Convert the IDataObject to a dictionary
        /// </summary>
        private static Dictionary<string, string> ConvertToDictionary(IDataObject displayStrings)
        {
            if (displayStrings == null)
            {
                return null;
            }

            var dataType = displayStrings.Type;

            var retVal = new Dictionary<string, string>();
            foreach (var property in dataType.Properties)
            {
                retVal.Add(property.Name, displayStrings[property.Name] as string);
            }

            return retVal;
        }
    }
}