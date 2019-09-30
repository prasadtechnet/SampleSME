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
using SME.ServiceAPI.Business.Manager.User;
using JwtRsaAPI.JWT;
using SME.ServiceAPI.Business.Contracts.Response;
using System.Net;

namespace SME.ServiceAPI.Business.Manager.Customer
{
    public class CustomerManager : ICustomerManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<CustomerManager> _logger;
        private IServiceCallManager _serviceCallManager;
        private IAppUserManager _appUserManager;
        private IMapper _mapper;
        private IJWTHandler _jwtManager;
        #endregion

        #region Constructor
        public CustomerManager( IServiceCallManager serviceCallManager,IAppUserManager appUserManager, IJWTHandler jwtManager, IRepository repository,IUnitOfWork unitofWork,IMapper mapper,ILogger<CustomerManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _serviceCallManager = serviceCallManager;
            _mapper = mapper;
            _appUserManager = appUserManager;
            _jwtManager = jwtManager;
        }



        #endregion             

        #region Customer
       
        public async Task<ResponseModel> UpdateCustomer(CustomerModel objInput)
        {
            await _repository.Update<SME.ServiceAPI.Common.Entities.Customer>(_mapper.Map<SME.ServiceAPI.Common.Entities.Customer>(objInput));

            await _unitofWork.SaveChangesAsync();

            return new ResponseModel { Status = HttpStatusCode.OK, Success = "Customer updated successfully" };
        }

        public async Task<ResponseModel> CreateCustomer(CustomerModel objInput)
        {
            await _repository.Create< SME.ServiceAPI.Common.Entities.Customer>(_mapper.Map<SME.ServiceAPI.Common.Entities.Customer>(objInput));

            await _unitofWork.SaveChangesAsync();

            //Get Customer Role Claims
            //Future--- PriporityCustomer,NormalCutomer

            //assgin default claim

              return new ResponseModel { Status = HttpStatusCode.OK, Success = "Customer has been created" };
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

        public async Task<ResponseModel> DeleteCustomer(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerAuthResponseModel> Authenticate(CustomerAuthRequestModel objInput)
        {
            try
            {
               var cust= await _repository.Find<SME.ServiceAPI.Common.Entities.Customer>(x => x.LogonName == objInput.User || x.Mobile == objInput.User || x.Email == objInput.User);
               if (cust == null)
                   return new CustomerAuthResponseModel { Status=false,Error="Invalid user" };

              if(cust.Password!=objInput.Password)
                    return new CustomerAuthResponseModel { Status = false, Error = "Invalid password" };


                var lsRoleClaims=await _appUserManager.GetCustomerClaims();
                if (lsRoleClaims != null)
                {
                    //Create JwtToken
                    var jwtResp = await _jwtManager.GenerateCustomerToken(lsRoleClaims, "Customer", cust.Id, cust.Email);

                    return new CustomerAuthResponseModel { Status = true, Token = jwtResp.Token };
                }
               

            }
            catch (System.Exception ex)
            {
                return new CustomerAuthResponseModel { Status = false,Error="Exception:"+ex.Message};
            }


            return null;
        }

        public async Task<CustomerResetResponseModel> ResetPassword(CustomerResetRequestModel objInput)
        {
            throw new NotImplementedException();
        }

    

        public async Task<ResponseModel> AddCustomerProduct(CustomerProductModel objInput)
        {
            try
            {
               await _repository.Create<CustomerProduct>(_mapper.Map<CustomerProduct>(objInput));

               await _unitofWork.SaveChangesAsync();

               return new ResponseModel { Status = HttpStatusCode.OK,Success="Product added successfully" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }

            
        }

        public async Task<ResponseModel> DeleteCustomerProduct(CustomerProductModel objInput)
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
