using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.BusinessFlow;
using SME.ServiceAPI.Business.BusinessFlow.Core;
using SME.ServiceAPI.Business.Contracts;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
using SME.ServiceAPI.Business.Manager.Customer;
using SME.ServiceAPI.Business.Manager.User;
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
        private IMapper _mapper;
        private IAppUserManager _appUserManager;
        private ICustomerManager _customerManager;
        #endregion

        #region Constructor
        public ServiceCallManager(IAppUserManager appUserManager, ICustomerManager customerManager,IRepository repository, IUnitOfWork unitofWork, IMapper mapper, ILogger<ServiceCallManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
            _appUserManager = appUserManager;
            _customerManager = customerManager;
        }


        #endregion

        #region ServiceCall
        public async Task<ResponseModel> CreateServiceCall(ServiceCallModel objInput)
        {
            try
            {
                var scObj = _mapper.Map<SME.ServiceAPI.Common.Entities.ServiceCall>(objInput);

                await _repository.Create<SME.ServiceAPI.Common.Entities.ServiceCall>(scObj);

                await _unitofWork.SaveChangesAsync();

                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }
        public async Task<ResponseModel> AssignServiceCall(ServiceCallModel objInput)
        {
            try
            {
                


                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> NotAcceptedServiceCall(ServiceCallModel objInput)
        {
            try
            {
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> NotResolveServiceCall(ServiceCallModel objInput)
        {
            try
            {
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> ResolvedServiceCall(ServiceCallModel objInput)
        {
            try
            {
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }
        public async Task<ResponseModel> AcceptServiceCall(ServiceCallModel objInput)
        {
            try
            {
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> CloseServiceCall(ServiceCallModel objInput)
        {
            try
            {
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }
        public async Task<ServiceCallModel> GetServiceCallDetails(string Id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Feedback
        public async Task<ResponseModel> CreateServiceCallFeedback(ServiceCallFeedbackModel objInput)
        {
            try
            {
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }
        #endregion

        #region History
        public async Task<List<ServiceCallHistoryModel>> TrackServiceCall(string Id)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region SaveChanges commit
        //public async Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        
    }
}
