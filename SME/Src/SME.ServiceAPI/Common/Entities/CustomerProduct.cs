using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class CustomerProduct
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }

        public string SerialNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Warrenty { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifieidBy { get; set; }
        
        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
