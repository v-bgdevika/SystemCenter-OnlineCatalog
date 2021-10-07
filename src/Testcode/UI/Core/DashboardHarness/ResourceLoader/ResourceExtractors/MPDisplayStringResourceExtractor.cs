using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.EnterpriseManagement;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
    public class MPDisplayStringResourceExtractor : BaseResourceExtractor, IResourceExtractor
    {
        ManagementGroup connection = null;

        public MPDisplayStringResourceExtractor(ManagementGroup connection)
        {
            this.connection = connection;
        }

        public object GetValue(XElement node)
        {
            try
            {
                string mpResource = node.Element(ItemXName).Value.Trim();

                string[] parts = mpResource.Split("!".ToCharArray());
                string mpName = parts[0];
                string resourceId = parts[1];


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

}
