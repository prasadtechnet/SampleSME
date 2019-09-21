using SME.ServiceAPI.Business.Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.ServiceCall
{
   public interface IServiceCallManager : IActionManager
    {
        Task GetHistoryOfCall(string ServiceCallId);
        Task GetFeedbackOfCall(string ServiceCallId);
        Task GetProductsOfCall(string ServiceCallId);
        Task CreateServiceCallFeedback();
        Task AssignServiceCall();
        Task AcceptServiceCall();
        Task NotAcceptServiceCall();
        Task NotResolvedServiceCall();
        Task ResolvedServiceCall();
        Task CloseServiceCall();

    }
}
