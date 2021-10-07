//-------------------------------------------------------------------
// <copyright file="GetPerformanceCountersForEntitiesDataSourceQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains the wrapper for query component GetPerformanceCountersForEntitiesDataSource
// </summary>
// 
//  <history>
//  [shreedp] NOV 2010:  Created
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
    /// Class: Wrapper around query component GetPerformanceCountersForEntitiesDataSource. 
    /// Contains library methods to Set properties, Dump DataContext
    /// </summary>
    public class GetPerformanceCountersForEntitiesDataSourceQuery : DataQuery
    {
        #region private fields

        /// <summary>
        /// Variable to hold the list of managedEntities that will be passed to GetPerformanceCountersForEntitiesDataSource
        /// </summary>
        private IEnumerable<IDataObject> managedEntities = null;

        /// <summary>
        /// Variable to hold the PerformanceObjectName that will be passed to GetPerformanceCountersForEntitiesDataSource
        /// </summary>
        private string PerformanceObjectName = null;

        /// <summary>
        /// Variable to hold the PerformanceCounterName that will be passed to GetPerformanceCountersForEntitiesDataSource
        /// </summary>
        private string PerformanceCounterName = null;

        /// <summary>
        /// Variable to hold the PerformanceInstanceName that will be passed to GetPerformanceCountersForEntitiesDataSource
        /// </summary>
        private string PerformanceInstanceName = null;

        /// <summary>
        /// Variable to hold the Refresh that will be passed to GetPerformanceCountersForEntitiesDataSource
        /// </summary>
        private string Refresh = null;
        #endregion

        #region Private Constants
        private const string propertyNameManagedEntities = "ManagedEntities";
        private const string propertyNamePerformanceObjectName = "PerformanceObjectName";
        private const string propertyNamePerformanceCounterName = "PerformanceCounterName";
        private const string propertyNamePerformanceInstanceName = "PerformanceInstanceName";
        private const string propertyNameRefresh = "Refresh";
        private const string propertyNameOutput = "Output";        
        #endregion

        #region Overridden properties

        /// <summary>
        /// Property for ShouldWait
        /// </summary>
        protected override bool ShouldWait
        {
            get
            {
                return (managedEntities != null);
            }        
        }

        /// <summary>
        /// Property for QueryName
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!GetPerformanceCountersForEntitiesDataSource"; }
        }

        #endregion

        #region default values

        /// <summary>
        /// Method for getting the default parameters for the query component
        /// </summary>
        /// <history>
        /// [shreedp] NOV 2010:  Created
        /// </history>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {"ConnectionSessionTicket", UnityContainerHelpers.GetConnectionSessionTicket()},
                           {propertyNameManagedEntities, managedEntities},
                           {propertyNamePerformanceObjectName, "%"},
                           {propertyNamePerformanceCounterName, "%"},
                           {propertyNamePerformanceInstanceName, "%"}, 
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
        /// [shreedp] NOV 2010:  Created
        /// </history>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case (propertyNameManagedEntities):
                    {
                        var baseManagedEntities = new List<IDataObject>();
                        foreach (var item in value as List<Guid>)
                        {
                            baseManagedEntities.Add((new BaseManagedEntityType(item)).ToIDataObject());
                        }

                        managedEntities = baseManagedEntities;
                        compRequest.SetParameter(propertyNameManagedEntities, managedEntities);
                        break;
                    }
                case propertyNamePerformanceObjectName:
                    {
                        PerformanceObjectName = value as String;
                        compRequest.SetParameter(propertyNamePerformanceObjectName, PerformanceObjectName);
                        break;
                    }
                case propertyNamePerformanceCounterName:
                    {
                        PerformanceCounterName = value as String;
                        compRequest.SetParameter(propertyNamePerformanceCounterName, PerformanceCounterName);
                        break;
                    }
                case propertyNamePerformanceInstanceName:
                    {
                        PerformanceInstanceName = value as String;
                        compRequest.SetParameter(propertyNamePerformanceInstanceName, PerformanceInstanceName);
                        break;
                    }
                case propertyNameRefresh:
                    {
                        Refresh = value as String;
                        compRequest.SetParameter(propertyNameRefresh, Refresh);
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
            //DataContextHelpers.DumpContext(this.compRequest);
        }

        public override string LogParameters()
        {
            return "Parameters: " +
                "PerformanceObjectName: " + this.PerformanceObjectName +
                "PerformanceCounterName" + this.PerformanceCounterName +
                "PerformanceInstanceName" + this.PerformanceInstanceName;
        }

        #endregion
    }
}
