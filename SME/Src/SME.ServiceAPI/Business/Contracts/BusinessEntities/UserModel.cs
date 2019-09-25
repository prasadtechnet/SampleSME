using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class UserModel : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
