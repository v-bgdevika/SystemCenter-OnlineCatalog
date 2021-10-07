using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using Maui.Core;
//using Microsoft.EnterpriseManagement.Test.UI.Dashboards.Common;
using Mom.Test.UI.Core.Common;
using Microsoft.EnterpriseManagement;

namespace Mom.Test.UI.Core.Common
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ResourceAttribute : Attribute
    {
        public string ID
        {
            get;
            set;
        }
    }

    public interface IResourceExtractor
    {
        object GetValue(XElement node);
    }

    public abstract class BaseResourceExtractor
    {
        protected XName ItemXName = XName.Get("Item");
    }

    public class StringResourceExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                return node.Element(ItemXName).Value.Trim();
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }

    public class ListOfStringResourceExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                int numberOfElements = node.Elements(ItemXName).Count();
                if (numberOfElements == 0)
                {
                    return null;
                }

                List<string> retVal = new List<string>();

                foreach (var item in node.Elements(ItemXName))
                {
                    retVal.Add(item.Value.Trim());
                }

                return retVal;
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }

    public class ArrayOfStringResourceExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                int numberOfElements = node.Elements(ItemXName).Count();
                if (numberOfElements == 0)
                {
                    return null;
                }

                string[] retVal = new string[numberOfElements];
                for (int i = 0; i < numberOfElements; i++)
                {
                    retVal[i] = node.Elements().ElementAt(i).Value.Trim();
                }

                return retVal;
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }

    public class ListOfKeyValuePairStringStringResourceExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                int numberOfElements = node.Elements(ItemXName).Count();
                if (numberOfElements == 0)
                {
                    return null;
                }

                List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();
                int index = 0;
                string key = null;
                string value = null;
                foreach (var item in node.Elements(ItemXName))
                {
                    if (index == 0)
                    {
                        index++;
                        key = item.Value;
                    }
                    else
                    {
                        index = 0;
                        value = item.Value;

                        retVal.Add(new KeyValuePair<string, string>(key, value));
                    }
                }

                return retVal;
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }

    public class QIDExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                XCData cData = new XCData(node.Element(ItemXName).Value);
                return new QID(cData.Value);
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }

    public class CDataExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                XCData cData = new XCData(node.Element(ItemXName).Value);
                return (cData.Value);
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }

    public class MPDisplayStringResourceExtractor : BaseResourceExtractor, IResourceExtractor
    {
        public object GetValue(XElement node)
        {
            try
            {
                string mpResource = node.Element(ItemXName).Value.Trim();

                string[] parts = mpResource.Split("!".ToCharArray());
                string mpName = parts[0];
                string resourceId = parts[1];

                ManagementGroup connection = SDKConnectionManager.Current.GetManagementGroup();

                // Get the network management MP
                var managementPack = connection.GetManagementPacks().Where(mp => mp.Name.Equals(mpName)).FirstOrDefault();

                // Get the display name from the MP
                return managementPack.GetStringResource(resourceId).DisplayName;
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }


    public static class ResourceLoader
    {
        // All the XNames used by the resource loader
        public class XNames
        {
            public static XName Section = XName.Get("Section");
            public static XName Name = XName.Get("Name");
            public static XName Resource = XName.Get("Resource");
            public static XName Type = XName.Get("Type");
            public static XName Import = XName.Get("Import");
            public static XName Source = XName.Get("Source");
        }

        // State information
        private static bool isInitialized = false;

        // List of extractors
        private static Dictionary<string, IResourceExtractor> extractors = new Dictionary<string, IResourceExtractor>();

        // Use this to add more resource extractors
        public static Dictionary<string, IResourceExtractor> ResourceExtracors
        {
            get
            {
                return extractors;
            }
        }

        // Load resources for the object
        public static void LoadResources(Object instance, XElement section)
        {
            // Basic validation
            if (instance == null)
            {
                throw new ArgumentNullException("Cannot load resources for a null object");
            }

            if (section == null)
            {
                throw new ArgumentNullException("Resource section cannot be null.");
            }

            // This holds all the resources relevant for the section
            Dictionary<string, XElement> resourceList = new Dictionary<string, XElement>();

            // Get all the resources for the section
            InitializeResourceList(section, resourceList);

            // Process all the references
            Type type = instance.GetType();
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                object[] attributes = field.GetCustomAttributes(typeof(ResourceAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                try
                {
                    // ResourceAttribute.ID is the name of the resource
                    ResourceAttribute ra = attributes[0] as ResourceAttribute;
                    string resourceName = ra.ID;
                    if (!resourceList.ContainsKey(resourceName))
                    {
                        continue;
                    }

                    XElement fieldResource = resourceList[resourceName];
                    string typeOfResource = fieldResource.Attribute(XNames.Type).Value;
                    // Get the right extractor
                    IResourceExtractor resourceExtractor = GetResourceExtractor(typeOfResource);

                    // Use the extractor to set the value of the field
                    object value = resourceExtractor.GetValue(fieldResource);

                    // Set the value to the field
                    field.SetValue(instance, value);
                }
                catch (Exception e)
                {
                    throw new Exception("There was an error loading resource", e);
                }
            }
        }

        public static XElement GetSection(string sectionName, string resourceFile)
        {
            // Basic validation
            if (sectionName == null)
            {
                throw new ArgumentNullException("Section Name cannot be null.");
            }

            if (resourceFile == null)
            {
                throw new ArgumentNullException("Resource file cannot be null");
            }


            XElement resourcesRoot = XDocument.Load(resourceFile).Root;

            // Process request
            IEnumerable<XElement> allSections = resourcesRoot.Elements(ResourceLoader.XNames.Section);
            if (allSections == null)
            {
                return null;
            }

            return (from s in allSections
                    where s.Attribute(ResourceLoader.XNames.Name).Value.Equals(sectionName, StringComparison.OrdinalIgnoreCase)
                    select s).FirstOrDefault();
        }

        // Load the default resource extractors
        private static void LoadDefaultResourceExtractors()
        {
            extractors.Add("String", new StringResourceExtractor());
            extractors.Add("ListOfString", new ListOfStringResourceExtractor());
            extractors.Add("ArrayOfString", new ArrayOfStringResourceExtractor());
            extractors.Add("ListOfKeyValuePairStringString", new ListOfKeyValuePairStringStringResourceExtractor());
            extractors.Add("QID", new QIDExtractor());
            extractors.Add("CDATA", new CDataExtractor());
            extractors.Add("MPDisplayString", new MPDisplayStringResourceExtractor());
        }

        // Map name to resource extractor
        private static IResourceExtractor GetResourceExtractor(string typeOfResource)
        {
            // Initialize on the first call
            if (!isInitialized)
            {
                isInitialized = true;
                LoadDefaultResourceExtractors();
            }

            // Return what is available
            IResourceExtractor retVal = null;
            extractors.TryGetValue(typeOfResource, out retVal);

            return retVal;
        }

        // Initialize the resources relevant for a section
        private static void InitializeResourceList(XElement section, Dictionary<string, XElement> resourceList)
        {
            // Load the imported resources
            foreach (var item in GetImportedResources(section))
            {
                if (resourceList.ContainsKey(item.Key))
                {
                    resourceList[item.Key] = item.Value;
                }
                else
                {
                    resourceList.Add(item.Key, item.Value);
                }
            }

            // Load the local resources
            foreach (XElement item in section.Elements(XNames.Resource))
            {
                string key = item.Attribute(XNames.Name).Value;

                // Local resource has precedence over imported resource
                if (resourceList.ContainsKey(key))
                {
                    resourceList[key] = item;
                }
                else
                {
                    resourceList.Add(key, item);
                }
            }
        }

        // Get all the imported resources for a section
        private static Dictionary<string, XElement> GetImportedResources(XElement section)
        {
            Dictionary<string, XElement> importedResources = new Dictionary<string, XElement>();

            // Process all imports
            foreach (var import in section.Elements(XNames.Import))
            {
                // Open the references document
                XDocument doc = XDocument.Load(import.Attribute(XNames.Source).Value);

                // Find the right referenced section
                XElement refSection = null;
                foreach (var s in doc.Root.Elements(XNames.Section))
                {
                    if (s.Attribute(XNames.Name).Value == import.Attribute(XNames.Section).Value)
                    {
                        refSection = s;
                        break;
                    }
                }

                // Did not find the referenced section
                if (refSection == null)
                {
                    continue;
                }

                // Load all the resources from the referenced section
                foreach (var res in refSection.Elements(XNames.Resource))
                {
                    importedResources.Add(res.Attribute(XNames.Name).Value, res);
                }
            }

            return importedResources;
        }
    }
}
