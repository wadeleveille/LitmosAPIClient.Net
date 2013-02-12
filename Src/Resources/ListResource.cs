using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Litmos.API.Resources
{
    [CollectionDataContract(Name="{0}s", Namespace="")]   
    public class ListResource<T> : List<T>
    {
        public ListResource()
        {
        }
        
        public ListResource(List<T> items)
        {
            this.AddRange(items);
        }
    }
}
