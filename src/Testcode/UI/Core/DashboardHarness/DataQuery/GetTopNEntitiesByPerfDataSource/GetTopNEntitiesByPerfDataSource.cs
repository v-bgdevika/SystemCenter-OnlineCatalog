namespace Mom.Test.UI.Core.GenericDataQuery
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using Microsoft.EnterpriseManagement.Presentation.Controls;
    using Common;
    #endregion 

    /// <summary>
    /// Class: Wrapper around query component GetTopNEntitiesByPerfDataSource. 
    /// Contains library methods to Set properties, Dump DataContext
    /// </summary>
    public class GetTopNEntitiesByPerfDataSource : DataQuery
    {        
        private string refresh;
        private PerformanceDataSeriesQueryType counterQueryInfo = null;
        private BaseManagementPackType selectedType = null;
        private DynamicDateTimeRange timeInterval = null;
        private int numberOfEntities = 10;
        private bool returnBottomN = false;
        private string excludeInstanceNameList = string.Empty;

        new public class PropertyNames
        {
            public const string Output = "Output";
            public const string Refresh = "Refresh";

            public const string CounterQueryInfo = "CounterQueryInfo";
            public const string TimeInterval = "TimeInterval";
            public const string NumberOfEntities = "NumberOfEntities";
            public const string ReturnBottomN = "ReturnBottomN";
        }

        public GetTopNEntitiesByPerfDataSource(int timeoutMinutes, int sleepSeconds)
            : base(timeoutMinutes, sleepSeconds)
        {

        }


        protected override bool ShouldWait
        {
            get
            {
                return (counterQueryInfo != null);
            }        
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!GetTopNEntitiesByPerfDataSource"; }
        }

        /// <summary>
        /// Method for getting the default parameters for the query component
        /// </summary>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.CounterQueryInfo, null},
                           {PropertyNames.TimeInterval, null},
                           {PropertyNames.NumberOfEntities, numberOfEntities},
                           {PropertyNames.ReturnBottomN, returnBottomN},
                           {PropertyNames.Output, GetDefaultOutput()},
                           {PropertyNames.Refresh, refresh}
                       };
        }

        /// <summary>
        /// Method for Setting property in the query component
        /// </summary>
        /// <param name="propertyName">Name of the property to be set</param>
        /// <param name="value">Value to be set</param>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {            
                case (PropertyNames.CounterQueryInfo):
                    {
                        counterQueryInfo = (PerformanceDataSeriesQueryType)value;
                        string message = "Set GetTopNEntitiesByPerfDataSource.counterQueryInfo: " + value.ToString();
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.CounterQueryInfo, counterQueryInfo.ToIDataObject());
                        break;
                    }
                case PropertyNames.Refresh:
                    {
                        refresh = value as String;
                        string message = "Set GetTopNEntitiesByPerfDataSource.Refresh: " + value.ToString();
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.Refresh, refresh);
                        break;
                    }
                case PropertyNames.TimeInterval:
                    {
                        timeInterval = (DynamicDateTimeRange)value;
                        string message = "Set GetTopNEntitiesByPerfDataSource.TimeInterval: " + value.ToString();
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.TimeInterval, timeInterval.ToIDataObject());
                        break;
                    }
                case PropertyNames.NumberOfEntities:
                    {
                        numberOfEntities = (int)value;
                        string message = "Set GetTopNEntitiesByPerfDataSource.ReturnBottomN: " + value.ToString();
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.NumberOfEntities, numberOfEntities);
                        break;
                    }
                case PropertyNames.ReturnBottomN:
                    {
                        returnBottomN = (bool)value;
                        string message = "Set GetTopNEntitiesByPerfDataSource.ReturnBottomN: " + value.ToString();
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.ReturnBottomN, returnBottomN);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Propery name: " + propertyName);
                    }
            }
        }

        /// <summary>
        /// Method for dumping the current DataContext 
        /// </summary>
        public void DumpDataContext()
        {
            //DataContextHelpers.DumpContext(this.dataContext);
        }

        public override string LogParameters()
        {
            return "Parameters: " + Environment.NewLine +
                    PropertyNames.CounterQueryInfo + ": " + (counterQueryInfo != null ? counterQueryInfo.ToString() : string.Empty) + Environment.NewLine +
                    PropertyNames.TimeInterval + ": " + (timeInterval != null ? timeInterval.ToString() : string.Empty) + Environment.NewLine +
                    PropertyNames.NumberOfEntities + ": " + numberOfEntities + Environment.NewLine +
                    PropertyNames.ReturnBottomN + ": " + returnBottomN;
        }
    }
}
