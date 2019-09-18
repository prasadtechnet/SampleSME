using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class ServiceCallHistory : BaseEntity
    {
        public int Id { get; set; }
        public string ServiceCallId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }

    }
}
