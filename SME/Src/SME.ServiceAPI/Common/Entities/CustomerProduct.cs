﻿using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class CustomerProduct:BaseEntity
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }

        public string SerialNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Warrenty { get; set; }
    }
}
