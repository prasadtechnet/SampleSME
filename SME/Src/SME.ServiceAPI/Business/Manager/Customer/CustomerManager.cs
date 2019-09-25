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

        #region Customer
       
        public async Task<bool> UpdateCustomer(CustomerModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCustomer(CustomerModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerModel> CustomerById(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerModel> CustomerByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerModel>> Customers(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCustomer(string Id)
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
