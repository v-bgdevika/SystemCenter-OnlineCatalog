using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
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
}
