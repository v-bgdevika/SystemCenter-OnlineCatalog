using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
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
}
