using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class ServiceCallModel : BaseEntity
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int BranchId { get; set; }
        public string Status { get; set; }
        public int NoOfProducts { get; set; }
        public decimal? Amount { get; set; }
        public decimal? GST { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }

        public List<ServiceCallProductModel> Products { get; set; }
    }
}
