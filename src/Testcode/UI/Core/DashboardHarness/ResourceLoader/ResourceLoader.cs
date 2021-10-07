using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Reflection;
using Maui.Core;
using Mom.Test.UI.Core.Common;
using Microsoft.EnterpriseManagement;
using Mom.Test.UI.Core.ResourceLoader;
using Mom.Test.UI.Core.ResourceLoader.ResourceExtractors;
using System.IO;

namespace Mom.Test.UI.Core.ResourceLoader
{
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

        #region private fields

        // State information
        private static bool isInitialized = false;

        // List of extractors
        private static Dictionary<string, IResourceExtractor> extractors = new Dictionary<string, IResourceExtractor>();

        private static XmlSchemaSet schemaSet = null;
        private static XmlSchemaSet SchemaSet
        {
            get
            {
                if (schemaSet == null)
                {
                    LoadSchemaSet();
                }

                return schemaSet;
            }
        }

        #endregion

        #region public properties

        // Use this to add more resource extractors
        public static Dictionary<string, IResourceExtractor> ResourceExtracors
        {
            get
            {
                return extractors;
            }
        }

        public static ManagementGroup Connection
        {
            get;
            set;
        }

        #endregion

        #region public methods

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

            // Get the type hierarchy
            var typeHierarchy = new List<Type>();
            GetTypeHierarchy(instance.GetType(), typeHierarchy);

            // Process all the references
            foreach (var type in typeHierarchy)
            {
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
        }

        private static void GetTypeHierarchy(Type type, List<Type> list)
        {
            if (type == null)
            {
                return;
            }

            list.Add(type);

            GetTypeHierarchy(type.BaseType, list);
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

            // Load the doc and validate it against the schema
            XDocument doc = XDocument.Load(resourceFile);


            doc.Validate(SchemaSet, null);
            return GetSection(sectionName, doc);
        }

        public static XElement GetSection(string sectionName, XDocument resourceDoc)
        {
            // Basic validation
            if (sectionName == null)
            {
                throw new ArgumentNullException("Section Name cannot be null.");
            }

            if (resourceDoc == null)
            {
                throw new ArgumentNullException("Resource cocument cannot be null");
            }

            resourceDoc.Validate(SchemaSet, null);

            // Process request

            IEnumerable<XElement> allSections = resourceDoc.Root.Elements(ResourceLoader.XNames.Section);

            if (allSections == null)
            {
                return null;
            }

            // Return the first section with matching name
            var retVal = (from s in allSections
                    where s.Attribute(ResourceLoader.XNames.Name).Value.Equals(sectionName, StringComparison.OrdinalIgnoreCase)
                    select s).FirstOrDefault();

            if (retVal == null)
            {
                throw new Exception("Did not find the section: " + sectionName);
            }

            return retVal;
        }

        public static XDocument GetDefaultResourceFile(string resourceFileName)
        {
            return GetResourceFileFromAssembly(resourceFileName, "Mom.Test.UI.Core.Console");
        }

        public static XDocument GetResourceFileFromAssembly(string resourceFileName, string assemblyString)
        {
            var assembly = Assembly.Load(assemblyString);
        
            return GetResource(resourceFileName, assembly);
        }

        public static XDocument GetResourceFileFromAssembly(string resourceFileName, Assembly assembly)
        {
            return GetResource(resourceFileName, assembly);
        }

        private static XDocument GetResource(string resourceFileName, Assembly assembly)
        {
            var stream = new StreamReader(assembly.GetManifestResourceStream(resourceFileName));
            return XDocument.Load(stream);
        }

        #endregion

        #region private methods

        // Load the default resource extractors
        private static void LoadDefaultResourceExtractors()
        {
            extractors.Add("String", new StringResourceExtractor());
            extractors.Add("ListOfString", new ListOfStringResourceExtractor());
            extractors.Add("ArrayOfString", new ArrayOfStringResourceExtractor());
            extractors.Add("ListOfKeyValuePairStringString", new ListOfKeyValuePairStringStringResourceExtractor());
            extractors.Add("CDATA", new CDataExtractor());
            extractors.Add("MPDisplayString", new MPDisplayStringResourceExtractor(Connection));
            extractors.Add("MPExtensionDisplayString", new MPExtensionDisplayString(Connection));

            //extractors.Add("TaskDisplayString", new TaskDisplayString(Connection));

        }

        // Map name to resource extractor
        private static IResourceExtractor GetResourceExtractor(string typeOfResource)
        {
            // Initialize on the first call
            if (!isInitialized)
            {
                isInitialized = true;
                Initialize();
            }

            // Return what is available
            IResourceExtractor retVal = null;
            extractors.TryGetValue(typeOfResource, out retVal);

            return retVal;
        }

        private static void Initialize()
        {
            LoadDefaultResourceExtractors();

            LoadSchemaSet();
        }

        private static void LoadSchemaSet()
        {
            schemaSet = new XmlSchemaSet();
            XmlSchema schema = null;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.ResourceLoader.ResourceFileSchema.xsd"));
                schema = XmlSchema.Read(stream, null);
            }
            catch (Exception e)
            {
                throw new Exception("Could not load the embedded resource ResourceFileSchema.xsd", e);
            }

            schemaSet.Add(schema);
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
                doc.Validate(SchemaSet, null);

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

        #endregion
    }
}
