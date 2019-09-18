using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Idenitity
{
    public class AppUser:IdentityUser
    {
        public override string Id { get; set; }
        public override bool LockoutEnabled { get; set; } = false;
    }
}
