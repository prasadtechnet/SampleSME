using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class ServiceCall:BaseEntity
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public string Status { get; set; }
        public bool IsUnderWarrenty { get; set; }

    }
}
