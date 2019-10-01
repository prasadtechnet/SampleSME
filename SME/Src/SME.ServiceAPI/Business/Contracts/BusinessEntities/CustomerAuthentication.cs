using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.BusinessEntities
{
    public class CustomerAuthRequestModel
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class CustomerAuthResponseModel
    {
        public bool  Status { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }

    public class CustomerResetRequestModel
    {
        public string user { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
    public class CustomerResetResponseModel
    {
        public bool Status { get; set; }
        public string Success { get; set; }
        public string Error { get; set; }
    }
}
