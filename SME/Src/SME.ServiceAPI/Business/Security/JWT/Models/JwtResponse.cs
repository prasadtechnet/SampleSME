using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Security.JWT.Models
{
    public class JwtResponse
    {
        public string Token { get; set; }
        public bool  Success { get; set; }

        public string RefreshToken { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
