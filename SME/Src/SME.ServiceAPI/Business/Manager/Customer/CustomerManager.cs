using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Manager.ServiceCall;
using SME.ServiceAPI.Data.Interface;
using SME.ServiceAPI.Common.Entities;
using AutoMapper;

namespace SME.ServiceAPI.Business.Manager.Customer
{
    public class CustomerManager : ICustomerManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<CustomerManager> _logger;
        private IServiceCallManager _serviceCallManager;
        private IMapper _mapper;
        #endregion

        #region Constructor
        public CustomerManager( IServiceCallManager serviceCallManager, IRepository repository,IUnitOfWork unitofWork,IMapper mapper,ILogger<CustomerManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _serviceCallManager = serviceCallManager;
        }

        #endregion

        public async Task SaveChangesAsync()
        {
            await _unitofWork.SaveChangesAsync();
        }
        public async Task Create(BaseEntity entity)
        {
            var customerEntity = _mapper.Map<SME.ServiceAPI.Common.Entities.Customer>(entity as CustomerModel);
            
            _repository.Create<SME.ServiceAPI.Common.Entities.Customer>(customerEntity);
            await _unitofWork.SaveChangesAsync();
          
        }

        public Task CreateServiceCall()
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

      

    

        public Task ServiceCallFeedback()
        {
            throw new NotImplementedException();
        }

        public Task TrackServiceCall(string Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
