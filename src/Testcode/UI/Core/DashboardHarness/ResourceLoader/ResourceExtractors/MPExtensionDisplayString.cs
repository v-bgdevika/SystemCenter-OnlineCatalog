using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.EnterpriseManagement;
using System.Globalization;
using Microsoft.EnterpriseManagement.Configuration;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
    public class MPExtensionDisplayString : BaseResourceExtractor, IResourceExtractor
    {
        private ManagementGroup connection = null;

        public MPExtensionDisplayString(ManagementGroup connection)
        {
            this.connection = connection;
        }

        public object GetValue(XElement node)
        {
            
            try
            {
                if (this.connection == null)
                {
                    throw new Exception("Managementgroup connection is not set.");
                }

                string mpResource = node.Element(ItemXName).Value.Trim();

                return GetExtensionDisplayName(mpResource);
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }

        public object GetExtensionDisplayName(string mpResource)
        {
            string[] parts = mpResource.Split("!".ToCharArray());
            string mpName = parts[0];
            string MPExtensionId = parts[1];

            return GetExtensionDisplayName(mpName, MPExtensionId);
        }

        private object GetExtensionDisplayName(string mpName, string MPExtensionId)
        {
            var managementPack = connection.GetManagementPacks().Where(mp => mp.Name.Equals(mpName)).FirstOrDefault();
            var elementQueryCriteria = string.Format("Name = '{0}'", MPExtensionId);
            var managementPackElements = connection.Dashboard.GetComponentTypes(new ManagementPackComponentTypeCriteria(elementQueryCriteria));
            if (managementPackElements.Count > 0)
            {
                return managementPackElements[0].DisplayName;
            }

            return null;
        }
    }
}
