using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.EnterpriseManagement;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
    public class TaskDisplayString : BaseResourceExtractor, IResourceExtractor
    {
        private ManagementGroup connection = null;

        public TaskDisplayString(ManagementGroup connection)
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

                string[] parts = mpResource.Split("!".ToCharArray());
                string mpName = parts[0];
                string taskId = parts[1];

                // Get the network management MP
                var managementPack = connection.GetManagementPacks().Where(mp => mp.Name.Equals(mpName)).FirstOrDefault();

                foreach (var item in managementPack.GetTasks())
                {
                    Console.WriteLine(item.Name + " : " + item.DisplayName);
                }

                // Get the display name from the MP
                return managementPack.GetTask(taskId).DisplayName;
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }
    }
}
