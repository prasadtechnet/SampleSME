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
            _mapper = mapper;
        }



        #endregion             

        #region Customer
       
        public async Task<bool> UpdateCustomer(CustomerModel objInput)
        {
            await _repository.Update<SME.ServiceAPI.Common.Entities.Customer>(_mapper.Map<SME.ServiceAPI.Common.Entities.Customer>(objInput));

            await _unitofWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateCustomer(CustomerModel objInput)
        {
            await _repository.Create< SME.ServiceAPI.Common.Entities.Customer>(_mapper.Map<SME.ServiceAPI.Common.Entities.Customer>(objInput));

            await _unitofWork.SaveChangesAsync();

            return true;
        }

        public async Task<CustomerModel> CustomerById(string Id)
        {
            var objCust= await _repository.Find<SME.ServiceAPI.Common.Entities.Customer>(x=>x.Id==Id);
            if (objCust != null)
            {
                return _mapper.Map<CustomerModel>(objCust);
            }

            return null;
        }

        public async Task<CustomerModel> CustomerByName(string Name)
        {
            var objCust = await _repository.Find<SME.ServiceAPI.Common.Entities.Customer>(x => x.Name == Name);
            if (objCust != null)
            {
                return _mapper.Map<CustomerModel>(objCust);
            }

            return null;
        }

        public async Task<List<CustomerModel>> Customers()
        {
            var objCust = await _repository.All<SME.ServiceAPI.Common.Entities.Customer>();
            if (objCust != null)
            {
                return objCust.Select(x=>_mapper.Map<CustomerModel>(x)).ToList();
            }

            return null;
        }

        public async Task<bool> DeleteCustomer(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerAuthResponseModel> Authenticate(CustomerAuthRequestModel objInput)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResetResponseModel> ResetPassword(CustomerResetRequestModel objInput)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SaveChanges commit
        //public async Task SaveChangesAsync()
        //{
        //    _unitofWork.SaveChangesAsync();
        //}
        #endregion
    }
}
