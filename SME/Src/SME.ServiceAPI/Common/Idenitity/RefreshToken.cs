using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Idenitity
{
    public class RefreshToken:IdentityUserToken<string>
    {
     
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; }
        public bool InValidated { get; set; }
        public string UserId { get; set; }
        //FK user
        public virtual AppUser user { get; set; }


    }
}
