using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class ServiceCallProductModel:BaseEntity
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
    }
}
