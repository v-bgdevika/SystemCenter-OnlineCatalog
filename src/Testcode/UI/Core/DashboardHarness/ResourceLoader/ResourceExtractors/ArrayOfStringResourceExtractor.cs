using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
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
}
