using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Idenitity
{
    public class ClaimMaster
    {
        public int Id { get; set; }
        public string Category { get; set; }//claimType
        public string ClaimValue { get; set; }
    }
}
