using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.Response
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public string Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
