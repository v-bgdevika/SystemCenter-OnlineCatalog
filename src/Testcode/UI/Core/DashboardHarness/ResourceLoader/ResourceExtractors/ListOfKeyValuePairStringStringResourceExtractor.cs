using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
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

                if ((numberOfElements % 2) != 0)
                {
                    throw new Exception("Need to have matching number of key and value pairs");
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
}
