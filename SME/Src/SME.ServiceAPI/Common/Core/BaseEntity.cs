using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Core
{
    public class BaseEntity
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
