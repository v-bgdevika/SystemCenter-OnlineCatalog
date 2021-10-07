using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Mom.Test.UI.Core.Common;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using System.Diagnostics;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    internal class DataQueryBusyIndicator
    {
        #region private fields

        // When the composition engine creates the component, it sets the default value to false.
        // Hence the busy indicator goes to 0 at that time.
        private int busyCount = 1;

        #endregion

        #region public properties

        public bool IsBusy
        {
            get
            {
                if (busyCount < 0)
                {
                    Utilities.LogMessage("Busy count was negative: " + busyCount);
                    return false;
                }

                if (busyCount == 0)
                {
                    return false;
                }

                return true;
            }
        }

        #endregion

        #region public methods

        public void IsBusyEventHandler(object sender, EngineServiceChangedEventArgs eventArgs)
        {
            var prefix = "DataQueryBusyIndicator.IsBusyEventHandler ";

            if (eventArgs.ServiceName != "IsBusy")
            {
                throw new Exception("DataQueryBusyIndicator is not hooked up to changes to IsBusy service");
            }

            // Busy indicator has changed.
            var isBusy = DataObjectHelpers.IsBusy(eventArgs.Value as IDataObject);
            lock (this)
            {
                if (isBusy)
                {
                    busyCount++;
                }
                else
                {
                    busyCount--;

                    if (busyCount < 0)
                    {
                        //ShowOffendingStackTrace(); //Commented to curb the growth of log files.
                    }
                }
            }

            // Commented to curb the growth of log files
            // Utilities.LogMessage(prefix + eventArgs.ServiceName + ": " + busyCount);
        }

        #endregion

        #region private methods

        private void ShowOffendingStackTrace()
        {
            Utilities.LogMessage("++++++++++++++++Stack trace when the busyIndicator went negative: ++++++++++++++++");

            var trace = new StackTrace(true);

            foreach (var frame in trace.GetFrames())
            {
                var method = frame.GetMethod();
                var methodName = method.Name;
                var declaringType = method.DeclaringType.Name;

                Utilities.LogMessage(declaringType + "." + methodName);
            }

            Utilities.LogMessage("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        #endregion

    }
}
