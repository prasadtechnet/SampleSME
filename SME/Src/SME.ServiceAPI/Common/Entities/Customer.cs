using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LogonName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifieidBy { get; set; }

        public virtual ICollection<CustomerProduct> Products { get; set; }
    }
}
