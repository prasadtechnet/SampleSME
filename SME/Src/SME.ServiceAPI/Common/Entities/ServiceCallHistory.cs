﻿using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class ServiceCallHistory 
    {
        public int Id { get; set; }
        public string ServiceCallId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifieidBy { get; set; }

        public virtual ServiceCall ServiceCall { get; set; }
    }
}
