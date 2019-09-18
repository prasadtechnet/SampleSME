using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Security.JWT.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }

        public string issuer { get; set; }

        public int expiryDays { get; set; }

        public bool useRsa { get; set; }

        public string hmacSecretKey { get; set; }

        public string rsaPrivateKeyXml { get; set; }

        public string rsaPublicKeyXml { get; set; }
    }
}
