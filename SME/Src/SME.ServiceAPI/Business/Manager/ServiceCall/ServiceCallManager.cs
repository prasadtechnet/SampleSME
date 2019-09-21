using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.BusinessFlow;
using SME.ServiceAPI.Business.BusinessFlow.Core;
using SME.ServiceAPI.Business.Contracts;
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

        public async Task SaveChangesAsync()
        {
            await _unitofWork.SaveChangesAsync();
        }
        public Task Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateServiceCallFeedback()
        {
            throw new NotImplementedException();
        }

        public Task Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BaseEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetFeedbackOfCall(string ServiceCallId)
        {
            throw new NotImplementedException();
        }

        public Task GetHistoryOfCall(string ServiceCallId)
        {
            throw new NotImplementedException();
        }

        public Task GetProductsOfCall(string ServiceCallId)
        {
            throw new NotImplementedException();
        }

        public Task Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task AssignServiceCall()
        {
            throw new NotImplementedException();
        }

        public Task AcceptServiceCall()
        {
            throw new NotImplementedException();
        }

        public Task NotAcceptServiceCall()
        {
            throw new NotImplementedException();
        }

        public Task NotResolvedServiceCall()
        {
            throw new NotImplementedException();
        }

        public Task ResolvedServiceCall()
        {
            throw new NotImplementedException();
        }

        public Task CloseServiceCall()
        {
            throw new NotImplementedException();
        }
    }
}
