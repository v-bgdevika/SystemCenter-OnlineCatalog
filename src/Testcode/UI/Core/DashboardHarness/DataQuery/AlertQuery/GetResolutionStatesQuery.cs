using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetResolutionStatesQuery : DataQuery
    {
        protected override bool ShouldWait
        {
            get { return true; }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Configuration.Library!GetResolutionStatesQuery"; }
        }

        protected override void SetPropertyInternal(string propertyName, object value) { }

        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                {
                    {"Output", GetDefaultOutput()}
                };
        }
    }
}
