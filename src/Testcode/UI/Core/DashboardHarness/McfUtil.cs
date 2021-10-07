namespace Mom.Test.UI.Core
{
    using System;
    using System.Data;
    using Infra.Frmwrk;
    using System.Collections.Generic;
    using MomCommon = Mom.Test.UI.Core.Common;
    using System.Threading;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.EnterpriseManagement.Presentation.Security;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using System.IO;
    using System.Windows;

    using System.Xml;
    using System.Text;

            
    public class McfUtil
    {
        const string recParameter = "Parameter";
        const string recParameterName = "name";
        const string recParameterValue = "value";
        const string recParameterType = "type";
        const string recParameterCollectionType = "collectiontype";
        const string recConvertToDataObject = "converttodataobject";

        
        // Reads parameters from Varmap and converts them to objects of the appropriate type
        public static Dictionary<string, object> ReadParameters(IContext fncContext)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            List<Dictionary<string, List<string>>> parameters = ReadTrimmedSubValues(fncContext, recParameter);
            
            foreach (Dictionary<string, List<string>> parameter in parameters)
            {
                if(!parameter.ContainsKey(recParameterName) || parameter[recParameterName].Count !=1)
                    throw new VarFail("Unable to read " + recParameterName + " from VarMap");
                if(!parameter.ContainsKey(recParameterValue) || (parameter[recParameterValue].Count != 1 
                    && !parameter.ContainsKey(recParameterCollectionType)))
                    throw new VarFail("Unable to read " + recParameterValue + " from VarMap");
                if(!parameter.ContainsKey(recParameterType) || parameter[recParameterType].Count !=1)
                    throw new VarFail("Unable to read " + recParameterType + " from VarMap");
                                                   
                string name = parameter[recParameterName][0];
                string typeName = parameter[recParameterType][0];
                List<string> values = parameter[recParameterValue];
                string collectionTypeName=null;
                if(parameter.ContainsKey(recParameterCollectionType))
                    collectionTypeName=parameter[recParameterCollectionType][0];
                    
                Type type = Type.GetType(typeName);
                if(type != null)
                    MomCommon.Utilities.LogMessage("Got type: " + type.ToString());
                else
                    throw new VarFail("Unknown parameter type: " + typeName);
                bool convertToDataObject = parameter.ContainsKey(recConvertToDataObject);
                

                if (!String.IsNullOrEmpty(collectionTypeName))
                {
                    // Add a collection parameter
                    // While this is written generically, in practice it only works List<T>, ArrayList and similar collections
                    // because we require the collection to support the Add() method with a single parameter.

                    Type collectionType = Type.GetType(collectionTypeName);
                    if(collectionType == null)
                    {
                        MomCommon.Utilities.LogMessage("Failed to get collection type", true);
                        throw new VarFail(String.Format("Collection type '{0}' not recognized", collectionTypeName));
                    }
                    MomCommon.Utilities.LogMessage("Got collection type: " + collectionTypeName);

                    if(collectionType.IsGenericTypeDefinition)
                    {
                        collectionType = collectionType.MakeGenericType(type); 
                    }

                    object collection = Activator.CreateInstance(collectionType);
                    if(collection == null)
                        throw new VarFail("Could not create collection");                    
                    MomCommon.Utilities.LogMessage("Created: " + collection.ToString());
                    
                    MethodInfo addMethod = collectionType.GetMethod("Add");
                    if(addMethod == null)
                        throw new VarFail("Collection type '" + collectionTypeName + "' does not have an Add method, and is therefore unsupported.");

                    foreach (string value in values)
                    {
                        object obj = CreateObject(type, value);
                        MomCommon.Utilities.LogMessage("Created: " + obj.ToString());
                        addMethod.Invoke(collection, new object[] { obj });
                        MomCommon.Utilities.LogMessage("Inserting value into collection: " + value.ToString());
                    }
                    if (convertToDataObject)
                    {
                        result[name] = CreateIDataObjectCollection(collection as IEnumerable<object>, type);
                    }
                    else
                    {
                        result[name] = collection;
                    }
                }
                else
                {
                    //TODO: support conversion to IDataObject if actualy required by any queries
                    // Add a single parameter
                    object obj = CreateObject(type, values[0]);
                    MomCommon.Utilities.LogMessage("Created: " + obj.ToString());
                    MomCommon.Utilities.LogMessage(String.Format("{0}=({1}){2}", name, typeName, obj));
                    result[name] = obj;
                }
            }
            return result;
        }

        // Read recs with the specified name and returns a list of one dictionary per rec, mapping trimmed subrecord names to value lists
        // e.g. <rec name="Parameter"> name = foo ; values = 1, 2</rec>
        // returns a list of one dictionary with {"name" -> {"foo"} "value" -> {"1","2"}}
        public static List<Dictionary<string, List<string>>> ReadTrimmedSubValues(IContext fncContext, string recordName)
        {
            IRecords[] parameters = fncContext.FncRecords.GetSubRecords(recordName);
            List<Dictionary<string, List<string>>> result = new List<Dictionary<string, List<string>>>();
            foreach (IRecords parameter in parameters)
            {
                Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
                foreach(string key in parameter.GetKeys())
                {
                    string[] parameterValues = parameter.GetValues(key);
                    string trimmedKey = key.Trim(null);
                    List<String> trimmedValues = new List<String>();
                    foreach(string value in parameterValues)
                        trimmedValues.Add(value.Trim(null));
                    map[trimmedKey] = trimmedValues;

                    //write some debugging output
                    string output = trimmedKey + "=";
                    foreach(string s in trimmedValues)
                        output += s + " ";
                    MomCommon.Utilities.LogMessage(output);
                }
                result.Add(map);      
            }
            return result;
        }

        public static object CreateObject(string typeName, string value)
        {
            Type type = Type.GetType(typeName);
            if (type == null)
                throw new VarFail("Unknown parameter type: " + typeName);
            return CreateObject(type, value);
        }

        // Creates and object of a given type initialized with a string value
        public static object CreateObject(Type type, string value)
        {
            object obj;
            try
            {
                // Try calling a constructor taking a string
                obj = Activator.CreateInstance(type,new object[]{value} );                        
            }
            catch(MissingMethodException)
            {
                // if that fails, try to call convert ....
                try
                {
                    obj = Convert.ChangeType(value, type);
                }
                catch(InvalidCastException e)
                {
                    // if that fails, try to deserialize from xml...
                    XmlSerializer serializer = new XmlSerializer(type);
                    StringReader reader = new StringReader(value);
                    obj = serializer.Deserialize(reader);
                    if(obj == null)
                        throw new VarFail(String.Format("Unable to initialize type '{0}' from '{1}'", type, value), e);  
                }
            }
            return obj;
        }


        static IDataModel dm = new SimpleDataModel();
        static IDataObjectCollection CreateIDataObjectCollection(IEnumerable<object> objects, Type type)
        {
            IDataObjectCollection idoCollection = dm.CreateCollection();
            IDataType dt = dm.Types.Create(type.ToString());
            // HACK: hardcoding the property to "PropertyName" to match the query requirement in GetTargetedAlertsData.FetchData())
            dt.Properties.Create("PropertyName", type);
            foreach (string obj in objects)
            {
                IDataObject dataObject = dm.CreateInstance(dt);
                dataObject["PropertyName"] = obj;
                idoCollection.Add(dataObject);
            }
            return idoCollection;
        }
    }
}

