//-------------------------------------------------------------------
// <copyright file="GetPerformanceDataForEntitiesDataSourceQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains the wrapper for query component GetPerformanceDataForEntitiesDataSourceQuery
// </summary>
// 
//  <history>
//  [shreedp] DEC 2010:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.GenericDataQuery
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    #endregion 

    /// <summary>
    /// Class: Wrapper around query component GetPerformanceDataForEntitiesDataSourceQuery. 
    /// Contains library methods to Set properties, Dump DataContext
    /// </summary>
    public class GetPerformanceDataForEntitiesDataSourceQuery : DataQuery
    {        
        #region private fields
        /// <summary>
        /// Variable to hold the list of PerformanceDataSeriesQueryItems that will be passed to GetPerformanceDataForEntitiesDataSource
        /// </summary>
        private ObservableCollection<IDataObject> performanceDataSeriesQueryItems = new ObservableCollection<IDataObject>();

        /// <summary>
        /// Variable to hold the Refresh that will be passed to GetPerformanceDataForEntitiesDataSource
        /// </summary>
        private string Refresh;

        /// <summary>
        /// Variable to hold the StartDate that will be passed to GetPerformanceDataForEntitiesDataSource
        /// </summary>
        private IDataObject interval = null; // Temp fix to get past bug 197034. Must be changed later

        /// <summary>
        /// Variable to hold the NumberOfDataPoints that will be passed to GetPerformanceDataForEntitiesDataSource
        /// </summary>
        private int numberOfDatapoints = 10; // Temp fix to get past bug 197034. Must be changed later
        #endregion

        #region Private Constants
        private const string propertyNamePerformanceDataSeriesQueryItems = "PerformanceDataSeriesQueryItems";
        private const string propertyNameRefresh = "Refresh";
        private const string propertyNameOutput = "Output";      
        private const string propertyNameInterval = "Interval";
        private const string propertyNameNumberOfDatapoints = "NumberOfDatapoints"; 
        #endregion

        #region Overridden properties

        /// <summary>
        /// Property for ShouldWait
        /// </summary>
        protected override bool ShouldWait
        {
            get
            {
                return (performanceDataSeriesQueryItems != null);
            }        
        }

        /// <summary>
        /// Property for QueryName
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!GetPerformanceDataForEntitiesDataSource"; }
        }

        #endregion

        #region default values

        /// <summary>
        /// Method for getting the default parameters for the query component
        /// </summary>
        /// <history>
        /// [shreedp] DEC 2010:  Created
        /// </history>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {"ConnectionSessionTicket", UnityContainerHelpers.GetConnectionSessionTicket()},
                           {propertyNamePerformanceDataSeriesQueryItems, performanceDataSeriesQueryItems},
                           {propertyNameInterval, interval},
                           {propertyNameNumberOfDatapoints, numberOfDatapoints},
                           {propertyNameOutput, null},
                           {propertyNameRefresh, Refresh}
                       };
        }

        #endregion

        #region Overridden methods

        /// <summary>
        /// Method for Setting property in the query component
        /// </summary>
        /// <param name="propertyName">Name of the property to be set</param>
        /// <param name="value">Value to be set</param>
        /// <history>
        /// [shreedp] DEC 2010:  Created
        /// </history>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case (propertyNamePerformanceDataSeriesQueryItems):
                    {
                        foreach (IDataObject ido in value as ObservableCollection<IDataObject>)
                        {
                            performanceDataSeriesQueryItems.Add(ido);
                        }
                        compRequest.SetParameter(propertyNamePerformanceDataSeriesQueryItems, performanceDataSeriesQueryItems);
                        break;
                    }
                case propertyNameRefresh:
                    {
                        Refresh = value as String;
                        compRequest.SetParameter(propertyNameRefresh, Refresh);
                        break;
                    }
                case propertyNameInterval:
                    {
                        interval = (IDataObject)value;
                        compRequest.SetParameter(propertyNameInterval, interval);
                        break;
                    }
                case propertyNameNumberOfDatapoints:
                    {
                        numberOfDatapoints = (int)value;
                        compRequest.SetParameter(propertyNameNumberOfDatapoints, numberOfDatapoints);
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
        /// <history>
        /// [shreedp] DEC 2010:  Created
        /// </history>
        public void DumpDataContext()
        {
            //DataContextHelpers.DumpContext(this.dataContext);
        }

        public override string LogParameters()
        {
            return "Parameters: ";
        }

        #endregion
    }
}
