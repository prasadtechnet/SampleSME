using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class CustomerModel : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LogonName { get; set; }
        public string Password { get; set; }
        public List<CustomerProductModel> Products { get; set; }

    }


    public class CustomerProductModel : BaseEntity
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
