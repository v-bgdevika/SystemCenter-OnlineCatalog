using System;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class DateTimeRangePart
    {
        // schema type
        private const string DateTimeRangePartXSD = "xsd://Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.ChartDataTypes/DateTimeRangePart";
        
        // property name
        public static class PropertyNames
        {
            public const string BaseDateTime = "BaseDateTime";
            public const string Offset = "Offset";
            public const string OffsetType = "OffsetType";
        }

        private static IDataType dataType;
        private static ObservableDataModel dataModel;

        private readonly string baseDateTime;
        private readonly int offset;
        private readonly string offsetType;

        /// <summary>
        /// Initialize the data model and the data type once per app
        /// </summary>
        static DateTimeRangePart()
        {
            dataModel = new ObservableDataModel();
            dataType = dataModel.Types.Create(DateTimeRangePartXSD);
            dataType.Properties.Create(PropertyNames.BaseDateTime, typeof(string));
            dataType.Properties.Create(PropertyNames.Offset, typeof(int));
            dataType.Properties.Create(PropertyNames.OffsetType, typeof(string));
        }

        /// <summary>
        /// Get an instance of the DateTimeRangePart 
        /// </summary>
        /// <param name="managedEntityId"></param>
        public DateTimeRangePart(string baseDateTime, int offset, string offsetType)
        {
            this.baseDateTime = baseDateTime;
            this.offset = offset;
            this.offsetType = offsetType;
        }

        /// <summary>
        /// Get the IDataObject representation
        /// </summary>
        /// <returns></returns>
        public IDataObject ToIDataObject()
        {
            var instance = dataModel.CreateInstance(dataType);
            instance[PropertyNames.BaseDateTime] = baseDateTime;
            instance[PropertyNames.Offset] = offset;
            instance[PropertyNames.OffsetType] = offsetType;

            return instance;
        }

        /// <summary>
        /// This is used to log an DateTimeRangePart object in a meaningful way
        /// </summary>
        public new string ToString()
        {
            return PropertyNames.BaseDateTime + " = " + baseDateTime + ", " +
                   PropertyNames.Offset + " = " + offset + ", " +
                   PropertyNames.OffsetType + " = " + offsetType;
        }
    }
}
