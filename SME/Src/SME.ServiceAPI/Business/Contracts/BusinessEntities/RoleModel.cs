using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class RoleNewModel 
    {
        public string Name { get; set; }
    }
    public class RoleModel 
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleClaimAssignModel
    {
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
