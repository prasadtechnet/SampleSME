using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class ServiceCallHistoryModel : BaseEntity
    {
        public int Id { get; set; }
        public string ServiceCallId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
