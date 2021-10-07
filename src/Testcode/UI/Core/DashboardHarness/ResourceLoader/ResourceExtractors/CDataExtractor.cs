using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader.ResourceExtractors
{
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

}
