using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LitmosRESTClientSample.Models
{
    public class ApiTestRequest
    {
        public ApiTestRequest()
        {
        }

        public string ApiKey { get; set; }
        public string Source { get; set; }
        public string BaseUri { get; set; }
        public string RequestType { get; set; }
        public string RequestBody { get; set; }
        public string ResponseStatusCode { get; set; }
        public string ResponseDescription { get; set; }
        public string ResponseBody { get; set; }
    }
}
