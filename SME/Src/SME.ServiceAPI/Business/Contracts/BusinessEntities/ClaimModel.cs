﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class ClaimModel : BaseEntity
    {
        public int Id { get; set; }
        public string Category { get; set; }//claimType
        public string ClaimValue { get; set; }
    }
}
