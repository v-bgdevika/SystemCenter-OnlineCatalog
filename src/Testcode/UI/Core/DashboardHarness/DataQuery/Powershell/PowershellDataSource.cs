namespace Mom.Test.UI.Core.GenericDataQuery
{

    #region Using Directives
    using System;
    using System.Collections.Generic;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using Common;
    #endregion 

    public class PowershellDataSource : CommonDataSourceInterface
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string DataTypes = "DataTypes";
            public const string Parameters = "Parameters";
            public const string InitialScript = "InitialScript";
            public const string RefreshScript = "RefreshScript";
            public const string Timeout = "Timeout";
            public const string IsDebugEnabled = "IsDebugEnabled";
            public const string KeyProperty = "KeyProperty";
            public const string RefreshProperties = "RefreshProperties";
            public const string Refresh = "Refresh";
            public const string Modules = "Modules";
            public const string SnapIns = "SnapIns";
            public const string Assemblies = "Assemblies";
            public const string DisplayStrings = "DisplayStrings";
            public const string Properties = "Properties";
        }

        #endregion

        #region Private fields

        private IEnumerable<DataTypeSpecifier> _dataTypes;
        private IEnumerable<Parameter> _parameters;
        private string _initialScript;
        private string _refreshScript;
        private int _timeout = GetDefaultTimeout();
        private bool _isDebugEnabled = GetDefaultIsDebugEnabled();
        private string _keyProperty;
        private IEnumerable<string> _refreshProperties;
        private IEnumerable<string> _modules;
        private IEnumerable<string> _snapIns;
        private IEnumerable<string> _assemblies;
        private IDataObject _displayStrings;

        public PowershellDataSource()
        {
            Refresh = false;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// DataTypes
        /// </summary>
        public IEnumerable<DataTypeSpecifier> DataTypes
        {
            get
            {
                return _dataTypes ?? (_dataTypes = GetDefaultDataTypes());
            }

            set
            {
                _dataTypes = value;
            }
        }

        /// <summary>
        /// Parameters
        /// </summary>
        public IEnumerable<Parameter> Parameters
        {
            get
            {
                return _parameters ?? (_parameters = GetDefaultParameters());
            }

            set
            {
                _parameters = value;
            }
        }

        /// <summary>
        /// InitialScript
        /// </summary>
        public string InitialScript
        {
            get
            {
                return _initialScript ?? (_initialScript = GetDefaultScript());
            }

            set
            {
                _initialScript = value;
            }
        }

        /// <summary>
        /// RefreshScript
        /// </summary>
        public string RefreshScript
        {
            get
            {
                return _refreshScript ?? (_refreshScript = GetDefaultScript());
            }

            set
            {
                _refreshScript = value;
            }
        }

        /// <summary>
        /// Timeout
        /// </summary>
        public int Timeout
        {
            get
            {
                return _timeout;
            }

            set
            {
                _timeout = value;
            }
        }

        /// <summary>
        /// IsDebugEnabled flag
        /// </summary>
        public bool IsDebugEnabled
        {
            get
            {
                return _isDebugEnabled;
            }

            set
            {
                _isDebugEnabled = value;
            }
        }
        
        /// <summary>
        /// Key Property
        /// </summary>
        public string KeyProperty
        {
            get
            {
                return _keyProperty ?? (_keyProperty = GetDefaultKeyProperty());
            }

            set
            {
                _keyProperty = value;
            }
        }

        /// <summary>
        /// Refresh Properties
        /// </summary>
        public IEnumerable<string> RefreshProperties
        {
            get
            {
                return _refreshProperties ?? (_refreshProperties = GetDefaultIEnumerable());
            }

            set
            {
                _refreshProperties = value;
            }
        }

        /// <summary>
        /// Refresh 
        /// </summary>
        public bool Refresh
        {
            get; set;
        }

        /// <summary>
        /// Modules
        /// </summary>
        public IEnumerable<string> Modules
        {
            get
            {
                return _modules ?? (_modules = GetDefaultIEnumerable());
            }

            set
            {
                _modules = value;
            }
        }

        /// <summary>
        /// SnapIns
        /// </summary>
        public IEnumerable<string> SnapIns
        {
            get
            {
                return _snapIns ?? (_snapIns = GetDefaultIEnumerable());
            }

            set
            {
                _snapIns = value;
            }
        }

        /// <summary>
        /// Assemblies
        /// </summary>
        public IEnumerable<string> Assemblies
        {
            get
            {
                return _assemblies ?? (_assemblies = GetDefaultIEnumerable());
            }

            set
            {
                _assemblies = value;
            }
        }

        /// <summary>
        /// Display Strings
        /// </summary>
        public IDataObject DisplayStrings
        {
            get
            {
                return _displayStrings ?? (_displayStrings = GetDefaultDisplayStrings());
            }
        }

        /// <summary>
        /// Always wait for the composition to be ready
        /// </summary>
        protected override bool ShouldWait
        {
            get { return true; }
        }

        #endregion

        #region Overridden properties

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!Microsoft.SystemCenter.Visualization.PowershellDataSource"; }
        }

        #endregion

       #region Default values

        private static IEnumerable<DataTypeSpecifier> GetDefaultDataTypes()
        {
            return new List<DataTypeSpecifier>();
        }

        private static IEnumerable<Parameter> GetDefaultParameters()
        {
            return new List<Parameter>();
        }

        private static string GetDefaultScript()
        {
            return null;
        }

        private static int GetDefaultTimeout()
        {
            return 10;
        }

        private static bool GetDefaultIsDebugEnabled()
        {
            return false;
        }

        private static string GetDefaultKeyProperty()
        {
            return "Id";
        }

        private static IEnumerable<string> GetDefaultIEnumerable()
        {
            return new List<string>();
        }
        
        /// <summary>
        /// Default query parameter values used while creating a new instance of the query
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            // Properties are added here
            var retVal = base.GetDefaultQueryParameters();

            // Query specific properties
            retVal.Add(PropertyNames.DataTypes, DataTypes);
            retVal.Add(PropertyNames.Parameters, Parameters);
            retVal.Add(PropertyNames.InitialScript, InitialScript);
            retVal.Add(PropertyNames.RefreshScript, RefreshScript);
            retVal.Add(PropertyNames.Timeout, Timeout);
            retVal.Add(PropertyNames.IsDebugEnabled, IsDebugEnabled);
            retVal.Add(PropertyNames.KeyProperty, KeyProperty);
            retVal.Add(PropertyNames.RefreshProperties, RefreshProperties);
            retVal.Add(PropertyNames.Modules, Modules);
            retVal.Add(PropertyNames.SnapIns, SnapIns);
            retVal.Add(PropertyNames.Assemblies, Assemblies);

            return retVal;
        }

        #endregion

        #region Overriden methods

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.DataTypes:
                    {
                        DataTypes = value as IEnumerable<DataTypeSpecifier>;
                        string message = "Set PowershellDataSource.DataTypes: " + DataTypeSpecifier.ToString(DataTypes);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.DataTypes, DataTypeSpecifier.ToIDataObjectCollection(DataTypes));
                        break;
                    }
                case PropertyNames.Parameters:
                    {
                        Parameters = value as IEnumerable<Parameter>;
                        string message = "Set PowershellDataSource.Parameters: " + Parameter.ToString(Parameters);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.Parameters, Parameters);
                        break;
                    }
                case PropertyNames.InitialScript:
                    {
                        InitialScript = value as string;
                        Utilities.LogMessage("Set PowershellDataSource.InitialScript: " + InitialScript, true);
                        compRequest.SetParameter(PropertyNames.InitialScript, InitialScript);
                        break;
                    }
                case PropertyNames.RefreshScript:
                    {
                        RefreshScript = value as string;
                        Utilities.LogMessage("Set PowershellDataSource.RefreshScript: " + RefreshScript, true);
                        compRequest.SetParameter(PropertyNames.RefreshScript, RefreshScript);
                        break;
                    }
                case PropertyNames.Timeout:
                    {
                        Timeout = int.Parse(value.ToString());
                        Utilities.LogMessage("Set PowershellDataSource.Timeout: " + Timeout, true);
                        compRequest.SetParameter(PropertyNames.Timeout, Timeout);
                        break;
                    }
                case PropertyNames.IsDebugEnabled:
                    {
                        IsDebugEnabled = Boolean.Parse(value.ToString());
                        Utilities.LogMessage("Set PowershellDataSource.IsDebugEnabled: " + IsDebugEnabled, true);
                        compRequest.SetParameter(PropertyNames.IsDebugEnabled, IsDebugEnabled);
                        break;
                    }
                case PropertyNames.KeyProperty:
                    {
                        KeyProperty = value as string;
                        Utilities.LogMessage("Set PowershellDataSource.KeyProperty: " + KeyProperty, true);
                        compRequest.SetParameter(PropertyNames.KeyProperty, KeyProperty);
                        break;
                    }
                case PropertyNames.RefreshProperties:
                    {
                        RefreshProperties = value as List<string>;
                        string message = "Set PowershellDataSource.RefreshProperties: " +
                                         ToString(RefreshProperties);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.RefreshProperties, RefreshProperties);
                        break;
                    }
                case PropertyNames.Refresh:
                    {
                        Utilities.LogMessage("Set PowershellDataSource.Refresh", true);
                        compRequest.SetParameter(PropertyNames.Refresh, value);
                        break;
                    }
                case PropertyNames.Modules:
                    {
                        Modules = value as List<string>;
                        string message = "Set PowershellDataSource.Modules: " +
                                         ToString(Modules);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.Modules, Modules);
                        break;
                    }
                case PropertyNames.SnapIns:
                    {
                        SnapIns = value as List<string>;
                        string message = "Set PowershellDataSource.SnapIns: " +
                                         ToString(SnapIns);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.SnapIns, SnapIns);
                        break;
                    }
                case PropertyNames.Assemblies:
                    {
                        Assemblies = value as List<string>;
                        string message = "Set PowershellDataSource.Assemblies: " +
                                         ToString(Assemblies);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.Assemblies, Assemblies);
                        break;
                    }
                case PropertyNames.Properties:
                    {
                        Properties = value as IEnumerable<ValueDefinitionType>;
                        string message = "Set PowershellDataSource.Properties: " +
                                         ValueDefinitionType.ToString(Properties);
                        Utilities.LogMessage(message, true);
                        compRequest.SetParameter(PropertyNames.Properties, ValueDefinitionType.ToIDataObjectCollection(Properties));
                        break;
                    }
                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        /// <summary>
        /// Return a string form of the parameters for logging.
        /// </summary>
        public override string LogParameters()
        {
            return Environment.NewLine +
                   "Properties: " + ValueDefinitionType.ToString(Properties) + Environment.NewLine +
                   "DataTypes: " + DataTypeSpecifier.ToString(DataTypes) + Environment.NewLine +
                   "Parameters: " + Parameter.ToString(Parameters) + Environment.NewLine +
                   "InitialScript: " + ToString(new List<string>{_initialScript}) + Environment.NewLine +
                   "RefreshScript: " + ToString(new List<string>{_refreshScript}) + Environment.NewLine +
                   "Timeout: " + Timeout + Environment.NewLine +
                   "IsDebugEnabled: " + IsDebugEnabled + Environment.NewLine +
                   "KeyProperty: " + KeyProperty + Environment.NewLine +
                   "RefreshProperties: " + ToString(RefreshProperties) + Environment.NewLine +
                   "Modules: " + ToString(Modules) + Environment.NewLine +
                   "SnapIns: " + ToString(SnapIns) + Environment.NewLine +
                   "Assemblies: " + ToString(Assemblies) + Environment.NewLine +
                   "Properties: " + ValueDefinitionType.ToString(Properties);
        }

        /// <summary>
        /// Default list of properties of the managed entity that will be retreived
        /// </summary>
        public override IEnumerable<ValueDefinitionType> GetDefaultProperties()
        {
            return new List<ValueDefinitionType>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// This is used to log a set of strings in a meaningful way
        /// </summary>
        public static string ToString(IEnumerable<string > strings)
        {
            string returnValue = "";
            foreach (string property in strings)
            {
                returnValue += property + ",";
            }
            return returnValue;
        }

        #endregion
    }
}
