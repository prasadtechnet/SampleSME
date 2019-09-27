using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class UserModel 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class UserNewModel 
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class UserEditModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }      
        public string Phone { get; set; }
    }

    public class UserRoleAssignModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }     
    }

    public class UserClaimAssignModel
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

    

}
