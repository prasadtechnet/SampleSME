using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.BusinessFlow;
using SME.ServiceAPI.Business.BusinessFlow.Core;
using SME.ServiceAPI.Business.Contracts;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Data.Interface;

namespace SME.ServiceAPI.Business.Manager.ServiceCall
{
    public class ServiceCallManager : IServiceCallManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<ServiceCallManager> _logger;
       // private IWorkFlowManager _scFlowManager;
        #endregion
             
        #region Constructor
        public ServiceCallManager(IRepository repository, IUnitOfWork unitofWork,  ILogger<ServiceCallManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;           
        }


        #endregion

        #region ServiceCall
        public async Task<bool> CreateServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> AssignServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NotAcceptedServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NotResolveServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResolvedServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> AcceptServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CloseServiceCall(ServiceCallModel objInput)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceCallModel> GetServiceCallDetails(string Id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Feedback
        public async Task<bool> CreateServiceCallFeedback(ServiceCallFeedbackModel objInput)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region History
        public async Task<List<ServiceCallHistoryModel>> TrackServiceCall(string Id)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region SaveChanges commit
        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
        
    }
}
