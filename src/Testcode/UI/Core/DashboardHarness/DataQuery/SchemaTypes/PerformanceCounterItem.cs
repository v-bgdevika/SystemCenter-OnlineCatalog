using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PresentationControls = Microsoft.EnterpriseManagement.Presentation.Controls;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class PerformanceCounterItem
    {
        private string objectName;
        private string counterName;
        private string instancename;

        public PerformanceCounterItem(string objectName, string counterName, string instancename)
        {
            this.objectName = objectName;
            this.counterName = counterName;
            this.instancename = instancename;
        }

        public PresentationControls.PerformanceCounterItem GetIDataObject()
        {
            var retVal = new PresentationControls.PerformanceCounterItem()
            {
                CounterName = this.counterName,
                InstanceName = this.instancename,
                ObjectName = this.objectName
            };

            return retVal;
        }

        public override string ToString()
        {
            return this.objectName + ", "
                + this.counterName + ", "
                + this.instancename;
        }
    }
}
