using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mom.Test.UI.Core.ResourceLoader
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ResourceAttribute : Attribute
    {
        public string ID
        {
            get;
            set;
        }
    }
}
