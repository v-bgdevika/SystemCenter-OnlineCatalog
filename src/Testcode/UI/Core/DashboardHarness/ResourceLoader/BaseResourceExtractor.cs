using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mom.Test.UI.Core.ResourceLoader
{
    public abstract class BaseResourceExtractor
    {
        protected XName ItemXName = XName.Get("Item");
    }
}
