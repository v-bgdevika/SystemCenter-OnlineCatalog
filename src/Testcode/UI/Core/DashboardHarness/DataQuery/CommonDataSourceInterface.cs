using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Monitoring.UnitComponents.Data;
using Microsoft.EnterpriseManagement.Presentation.Controls;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;
using System.Data;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    /// <summary>
    /// This has the additional behavior of the CommonDataSource interface based queries
    /// </summary>
    public abstract class CommonDataSourceInterface : DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string Properties = "Properties";
            public const string DisplayStrings = "DisplayStrings";
            public const string OutputItem = "OutputItem";
        }

        #endregion

        protected IEnumerable<ValueDefinitionType> properties;

        public IEnumerable<ValueDefinitionType> Properties
        {
            get { return properties ?? (properties = GetDefaultProperties()); }

            set { properties = value; }
        }

        #region Public methods


        #endregion

        /// <summary>
        /// All CommonDataSource interface based queries have properties and displaystrings
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.Properties, ValueDefinitionType.ToIDataObject(Properties)},
                           {PropertyNames.DisplayStrings, GetDefaultDisplayStrings()},
                       };
        }

        /// <summary>
        /// All derived classes should provide the default list 
        /// of properties to be fetched
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<ValueDefinitionType> GetDefaultProperties();
    }
}
