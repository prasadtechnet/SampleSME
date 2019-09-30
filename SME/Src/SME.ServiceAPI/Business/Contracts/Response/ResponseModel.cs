using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.Response
{
    public class ResponseModel
    {
 
        public HttpStatusCode Status { get; set; }
        public string Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
