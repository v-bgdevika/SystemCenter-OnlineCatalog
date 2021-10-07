using System;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class DynamicDateTimeRange
    {
        // schema type
        private const string DynamicDateTimeRangeXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.ChartDataTypes/DynamicDateTimeRange";
        
        // property name
        public static class PropertyNames
        {
            public const string StartPoint = "StartPoint";
            public const string EndPoint = "EndPoint";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly DateTimeRangePart startPoint;
        private readonly DateTimeRangePart endPoint;

        /// <summary>
        /// XML root Node
        /// </summary>
        protected const string XmlNodeNameInterval = "Interval";

        /// <summary>
        /// XML Start Interval Property node name
        /// </summary>
        protected const string XmlNodeNameStartInterval = "Start";

        /// <summary>
        /// XML End Interval Property node name
        /// </summary>
        protected const string XmlNodeNameEndInterval = "End";
        /// <summary>
        /// XML Date Base Property node name
        /// </summary>
        private const string XmlNodeNameDateBase = "Base";

        /// <summary>
        /// XML Offset Type Property Value node name
        /// </summary>
        private const string XmlNodeNameOffsetType = "Offset/@Type";

        /// <summary>
        /// XML Offset Value Property node name
        /// </summary>
        private const string XmlNodeNameOffsetValue = "Offset";

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static DynamicDateTimeRange()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(DynamicDateTimeRangeXSD);
            dataType.Properties.Create(PropertyNames.StartPoint, typeof(IDataObject));
            dataType.Properties.Create(PropertyNames.EndPoint, typeof(IDataObject));
        }

        /// <summary>
        /// Get an instance of the DynamicDateTimeRange 
        /// </summary>
        /// <param name="managedEntityId"></param>
        public DynamicDateTimeRange(string timeIntervalSetting)
        {
            //Parse time interval define
            XmlReader timeRangeReader = XmlReader.Create(new StringReader(timeIntervalSetting));
            System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Load(timeRangeReader);
            XPathNavigator intervalNavigator = xdoc.CreateNavigator().SelectSingleNode(XmlNodeNameInterval);

            this.startPoint = GetDateTimePoint(intervalNavigator.SelectSingleNode(XmlNodeNameStartInterval));
            this.endPoint = GetDateTimePoint(intervalNavigator.SelectSingleNode(XmlNodeNameEndInterval));
        }

        /// <summary>
        /// Get datatime point setting
        /// </summary>
        /// <param name="intervalNavigator"></param>
        /// <returns></returns>
        private DateTimeRangePart GetDateTimePoint(XPathNavigator intervalNavigator)
        {
            string offsetType = string.Empty;
            string baseDate = string.Empty;
            string timeOffset = string.Empty;

            XPathNavigator timeNavigator = intervalNavigator.SelectSingleNode(XmlNodeNameOffsetValue);
            timeOffset = timeNavigator.Value;

            XPathNavigator dateBaseNavigator = intervalNavigator.SelectSingleNode(XmlNodeNameDateBase);
            baseDate = dateBaseNavigator.Value;

            XPathNavigator offsetTypeNavigator = intervalNavigator.SelectSingleNode(XmlNodeNameOffsetType);
            offsetType = offsetTypeNavigator.Value;

            //default timeOffset = 0
            if (string.IsNullOrEmpty(timeOffset))
            {
                timeOffset = "0";
            }

            return new DateTimeRangePart(baseDate, int.Parse(timeOffset), offsetType);
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {           
            var instance = dataModel.CreateInstance(dataType);
            instance[PropertyNames.StartPoint] = startPoint.ToIDataObject();
            instance[PropertyNames.EndPoint] = endPoint.ToIDataObject();

            return instance;
        }

        /// <summary>
        /// This is used to log an DynamicDateTimeRange object in a meaningful way
        /// </summary>
        public new string ToString()
        {
            return PropertyNames.StartPoint + " = { " + startPoint.ToString() + "}, " +
                   PropertyNames.EndPoint + " = {" + endPoint.ToString() + "}";
        }
    }
}
