using System;
using System.Collections.Generic;
using Microsoft.EnterpriseManagement.Monitoring.UnitComponents.Data;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.GenericDataQuery;

namespace Mom.Test.UI.Core
{
    /// <summary>
    /// This class makes it easier to work with simple IDataObjects
    /// </summary>
    public static class DataObjectHelpers
    {
        /// <summary>
        /// This function extracts the exception information from the IDataObject
        /// </summary>
        /// <param name="lastError">IDataObject representing the error</param>
        /// <returns>exception object that has the details of the error</returns>
        public static Exception GetLastError(IDataObject lastError)
        {
            if (lastError == null)
            {
                return null;
            }

            var header = lastError["Header"] as string;
            var detail = lastError["Detail"] as string;

            return new Exception(header + ":" + detail);
        }

        /// <summary>
        /// This function extracts the busy state from the IDataObject        
        /// </summary>
        /// <param name="isBusy">IDataObject representing the busy state</param>
        /// <returns>true - busy, false - not busy</returns>
        public static bool IsBusy(IDataObject isBusy)
        {
            if (isBusy == null)
            {
                return false;
            }

            return (bool)isBusy["IsBusy"];
        }

        /// <summary>
        /// This builds a DisplayStrings object from a set of key value pairs.
        /// </summary>
        /// <param name="displayStringEntries">Key - property name, value - dispaly string value for the property</param>
        /// <returns>IDataObject representation of the DisplayStrings object</returns>
        public static IDataObject GetDisplayStringDataObject(IEnumerable<KeyValuePair<string, string>> displayStringEntries)
        {
            var displayString = new DisplayStrings(displayStringEntries);
            return displayString.ToIDataObject();
        }
    }
}
