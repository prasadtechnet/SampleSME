using SME.ServiceAPI.Business.Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Customer
{
  public  interface ICustomerManager:IActionManager
    {
        Task CreateServiceCall();
        Task TrackServiceCall(string Id);
        Task ServiceCallFeedback();

    }
}
