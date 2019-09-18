﻿using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class Customer:BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LogonName { get; set; }

        
    }
}