using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class ServiceCallFeedback : BaseEntity
    {
        public int Id { get; set; }
        public string ServiceCallId { get; set; }
        public int  Rating { get; set; }
        public string Remarks { get; set; }
    }
}
