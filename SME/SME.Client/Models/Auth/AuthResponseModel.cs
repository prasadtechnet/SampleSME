using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Client.Models.Auth
{
    public class AuthResponseModel
    {
        public int statusCode { get; set; }
        public string token { get; set; }
        public IEnumerable<string> errors { get; set; }
        
}
}
