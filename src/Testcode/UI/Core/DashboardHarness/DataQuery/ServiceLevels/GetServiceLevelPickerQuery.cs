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
    public class GetServiceLevelPickerQuery : DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string CriteriaString = "CriteriaString";
            public const string Output = "Output";
        }

        #endregion

        #region private fields

        private string criteriaString; // criteria used to select the SLA

        #endregion

        #region Overridden properties

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.ServiceLevelComponents!Microsoft.SystemCenter.Visualization.SlaPickerQuery"; }
        }

        protected override bool ShouldWait
        {
            get
            { return (criteriaString != null); }
        }

        #endregion

        #region public properties

        /// <summary>
        /// criteria used to select the SLA
        /// </summary>
        public string CriteriaString
        {
            get 
            { 
                return criteriaString ?? (criteriaString = null); 
            }
            
            set 
            { 
                criteriaString = value; 
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
                           {PropertyNames.CriteriaString, CriteriaString},
                           {PropertyNames.Output, GetDefaultOutput()},
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
                case PropertyNames.CriteriaString:
                    {
                        CriteriaString = value as string;
                        Utilities.LogMessage("Set GetServiceLevelsQuery.CriteriaString: " + CriteriaString, true);
                        compRequest.SetParameter(PropertyNames.CriteriaString, CriteriaString);
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
                PropertyNames.CriteriaString + " : " + this.CriteriaString;
        }

        #endregion
    }
}
