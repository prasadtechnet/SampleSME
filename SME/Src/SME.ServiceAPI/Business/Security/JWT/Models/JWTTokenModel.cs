using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtRsaAPI.JWT.Models
{
    public class JWTTokenModel
    {
        public string Token { get; set; }
        public long Expires { get; set; }
        public string RefreshToken { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}
