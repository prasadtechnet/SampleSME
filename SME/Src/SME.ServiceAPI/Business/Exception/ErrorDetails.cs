using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Exception
{
    public class ErrorDetails
    {       
        public IEnumerable<string> Errors { get; set; }
    }
}
