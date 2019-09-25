using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class ServiceCallFeedbackModel : BaseEntity
    {
        public int Id { get; set; }
        public string ServiceCallId { get; set; }
        public int Rating { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
