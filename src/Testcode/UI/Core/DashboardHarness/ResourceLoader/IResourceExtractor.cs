using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader
{
    public interface IResourceExtractor
    {
        object GetValue(XElement node);
    }
}
