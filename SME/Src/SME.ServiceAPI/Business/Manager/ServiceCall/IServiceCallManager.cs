using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
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

        Task<ResponseModel> CreateServiceCall(ServiceCallModel objInput);
        Task<ResponseModel> AssignServiceCall(ServiceCallModel objInput);
        Task<ResponseModel> AcceptServiceCall(ServiceCallModel objInput);
        Task<ResponseModel> NotAcceptedServiceCall(ServiceCallModel objInput);
        Task<ResponseModel> ResolvedServiceCall(ServiceCallModel objInput);
        Task<ResponseModel> NotResolveServiceCall(ServiceCallModel objInput);
        Task<ResponseModel> CloseServiceCall(ServiceCallModel objInput);
        Task<List<ServiceCallHistoryModel>> TrackServiceCall(string Id);
        Task<ResponseModel> CreateServiceCallFeedback(ServiceCallFeedbackModel objInput);
        Task<ServiceCallModel> GetServiceCallDetails(string Id);

      //  Task SaveChangesAsync();

    }
}
