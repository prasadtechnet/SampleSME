using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class ServiceCallProduct
    {
        public int Id { get; set; }
        public string ServiceCallId { get; set; }
        public string ProductId { get; set; }     
        public bool IsUnderWarrenty { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string UOM { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifieidBy { get; set; }

        public virtual ServiceCall ServiceCall { get; set; }
    }
}
