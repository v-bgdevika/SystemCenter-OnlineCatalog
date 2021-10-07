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
    public class GetTopNEntitiesByAlertsDataSource : DataQuery
    {
        #region Property Names
        private const string SystemLibrarySystemEntity = "System.Library!System.Entity";
        private const string ApplicationComponent = "Microsoft.Windows.ApplicationComponent";

        new public class PropertyNames
        {
            public const string TargetGroup = "TargetGroup";
            public const string SelectedType = "SelectedType";
            public const string NumberOfEntities = "NumberOfEntities";
            public const string AlertCriteriaString = "AlertCriteriaString";
            public const string Refresh = "Refresh";
            public const string Output = "Output";
        }

        #endregion

        #region private fields

        private string refresh;
        private string selectedType;
        private int numberOfEntities = 1;
        private string alertCriteriaString;
        private IDataObject targetGroup = null;

        #endregion

        #region Overridden properties

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
       {
           get { return "Microsoft.SystemCenter.Visualization.Library!GetTopNEntitiesByAlertsDataSource"; }
        }

        #endregion

        #region public properties

        public string Refresh
        {
            get
            {
                return refresh ?? (refresh = "ManualRefreshAction");
            }

            set
            {
                refresh = value;
            }
        }

        public IDataObject TargetGroup
        {
            get
            {
                return targetGroup;
            }

            set
            {
                targetGroup = value;
            }
        }

        public string SelectedType
        {
            get
            {
                return selectedType ?? (selectedType = ApplicationComponent);
            }

            set
            {
                selectedType = value;
            }
        }

        public int NumberOfEntities
        {
            get
            {
                return numberOfEntities;
            }

            set
            {
                numberOfEntities = value;
            }
        }

        /// <summary>
        /// criteria used to select the alert
        /// </summary>
        /// <summary>
        /// criteria string used to select the managed entities
        /// </summary>
        public string AlertCriteriaString
        {
            get
            {
                return alertCriteriaString ?? (alertCriteriaString = "Resolution != 255");
            }

            set
            {
                alertCriteriaString = value;
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
            Dictionary<string, object> retVal = new Dictionary<string, object>();

            // Query specific properties
            retVal.Add("ConnectionSessionTicket", UnityContainerHelpers.GetConnectionSessionTicket());
            retVal.Add(PropertyNames.SelectedType, selectedType);
            retVal.Add(PropertyNames.NumberOfEntities, numberOfEntities);
            retVal.Add(PropertyNames.Output, GetDefaultOutput());
            retVal.Add(PropertyNames.Refresh,Refresh);
            return retVal;
        }

        #endregion

        #region Overriden methods

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.TargetGroup:
                    targetGroup = (IDataObject)value;
                    Utilities.LogMessage("Set GetTopNEntitiesByAlertsDataSource.targetGroup: " + targetGroup, true);
                    compRequest.SetParameter(PropertyNames.TargetGroup, targetGroup);
                    break;
                    break;

                case PropertyNames.SelectedType :
                    selectedType = value as string;
                    Utilities.LogMessage("Set GetTopNEntitiesByAlertsDataSource.SelectedType: " + selectedType, true);
                    compRequest.SetParameter(PropertyNames.SelectedType, selectedType);
                    break;

                case PropertyNames.AlertCriteriaString :
                    alertCriteriaString = value as string;
                    Utilities.LogMessage("Set GetTopNEntitiesByAlertsDataSource.alertCriteriaString: " + alertCriteriaString, true);
                    compRequest.SetParameter(PropertyNames.AlertCriteriaString, alertCriteriaString);

                    break;

                case PropertyNames.NumberOfEntities:
                    {
                        numberOfEntities = (int)value;
                        Utilities.LogMessage("Set GetTopNEntitiesByAlertsDataSource.numberOfEntities: " + numberOfEntities.ToString(), true);
                        compRequest.SetParameter(PropertyNames.NumberOfEntities, numberOfEntities);
                        break;
                    }


                case PropertyNames.Refresh:
                    {
                        refresh = (string)value;
                        Utilities.LogMessage("Set GetTopNEntitiesByAlertsDataSource.Refresh = true ", true);
                        compRequest.SetParameter(PropertyNames.Refresh, value);
                        break;
                    }

                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        protected override bool ShouldWait
        {
            get
            {
                return (selectedType != null);
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
                PropertyNames.SelectedType + " : " + SelectedType + Environment.NewLine +
                PropertyNames.AlertCriteriaString + ": " + AlertCriteriaString + Environment.NewLine +
                PropertyNames.NumberOfEntities+ ": " + NumberOfEntities  + Environment.NewLine +
                PropertyNames.Refresh + " : " + Refresh + newLine;
        }


 
        #endregion
    }
}
