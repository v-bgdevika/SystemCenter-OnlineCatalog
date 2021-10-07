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
    public class GetServiceLevelAgreementQuery : DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string ServiceLevel = "ServiceLevel";
            public const string TimeInterval = "TimeInterval";
        }

        #endregion

        #region private fields

        private string serviceLevel;
        private string timeInterval;

        #endregion

        #region Overridden properties

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.ServiceLevelComponents!Microsoft.SystemCenter.Visualization.SlaDetailsQuery"; }
        }

        protected override bool ShouldWait
        {
            get
            { return (serviceLevel != null); }
        }

        #endregion

        #region public properties

        public string ServiceLevel
        {
            get 
            { 
                return serviceLevel ?? (serviceLevel = null); 
            }
            
            set 
            { 
                serviceLevel = value; 
            }
        }
        public string TimeInterval
        {
            get
            {
                return timeInterval ?? (timeInterval = null);
            }

            set
            {
                timeInterval = value;
            }
        }

        #endregion

        #region default values

        /// <summary>
        /// Default values used in the creation of the composition
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {"ConnectionSessionTicket", UnityContainerHelpers.GetConnectionSessionTicket()},
                           {PropertyNames.ServiceLevel, ServiceLevel},
                           {PropertyNames.TimeInterval, TimeInterval},
                       };
        }

        #endregion

        #region Overridden methods

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.ServiceLevel:
                    {
                        ServiceLevel = value as string;
                        Utilities.LogMessage("Set GetServiceLevelAgreementQuery.ServiceLevel: " + ServiceLevel, true);
                        compRequest.SetParameter(PropertyNames.ServiceLevel, ServiceLevel);
                        break;
                    }
                case PropertyNames.TimeInterval:
                    {
                        ServiceLevel = value as string;
                        Utilities.LogMessage("Set GetServiceLevelAgreementQuery.TimeInterval: " + TimeInterval, true);
                        compRequest.SetParameter(PropertyNames.TimeInterval, TimeInterval);
                        break;
                    }
                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// String form of the parameters that is to be used for logging.
        /// </summary>
        /// <returns></returns>
        public override string LogParameters()
        {
            var newLine = Environment.NewLine;

            return "Parameters: " + newLine +
                PropertyNames.ServiceLevel + " : " + this.ServiceLevel +
                PropertyNames.TimeInterval + " : " + this.TimeInterval;
        }

        #endregion
    }
}
