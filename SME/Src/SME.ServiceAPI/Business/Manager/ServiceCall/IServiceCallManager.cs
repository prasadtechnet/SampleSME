using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.ServiceCall
{
   public interface IServiceCallManager 
    {
  // 5.ServiceCall
    //5.1 Create
	//5.2 AssignCall	
	//5.4 AcceptCall
	//5.5 NotAcceptCall
	//5.6 NotResolvedCall
	//5.7 ResolvedCall
	//5.8 ClosedCall

        Task<bool> CreateServiceCall(ServiceCallModel objInput);
        Task<bool> AssignServiceCall(ServiceCallModel objInput);
        Task<bool> AcceptServiceCall(ServiceCallModel objInput);
        Task<bool> NotAcceptedServiceCall(ServiceCallModel objInput);
        Task<bool> ResolvedServiceCall(ServiceCallModel objInput);
        Task<bool> NotResolveServiceCall(ServiceCallModel objInput);
        Task<bool> CloseServiceCall(ServiceCallModel objInput);
        Task<List<ServiceCallHistoryModel>> TrackServiceCall(string Id);
        Task<bool> CreateServiceCallFeedback(ServiceCallFeedbackModel objInput);
        Task<ServiceCallModel> GetServiceCallDetails(string Id);

        Task SaveChangesAsync();

    }
}
