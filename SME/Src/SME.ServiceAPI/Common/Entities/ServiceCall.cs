using SME.ServiceAPI.Common.Core;
using SME.ServiceAPI.Common.Idenitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class ServiceCall
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }    
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public string Status { get; set; }
        public int NoOfProducts { get; set; }
        public decimal? Amount { get; set; }
        public decimal? GST { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifieidBy { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<ServiceCallProduct> Products { get; set; }
        public virtual ICollection<ServiceCallHistory> History { get; set; }
        public virtual ServiceCallFeedback ServiceCallFeedback { get; set; }

    }
}
