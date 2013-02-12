using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Litmos.API
{
    public class RESTResponse
    {
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public object Body { get; set; }
    }
}
