using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.BusinessFlow.Core;
using SME.ServiceAPI.Business.Feature;
using SME.ServiceAPI.Business.Manager.ServiceCall;
using SME.ServiceAPI.Common.Entities;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.ServiceAPI.Business.BusinessFlow
{
    
   public class CallWorkFlow: IWorkFlowManager
    {
        //histroy,Features activities based on status
        IWorkflowHandler _hdlerStatus;
        private Dictionary<string, IWorkflowHandler> objDict;
        public CallWorkFlow(ServiceCall objCall,IRepository repository,IUnitOfWork unitOfWork,IFeatureModule featureModule, ILogger<ServiceCallManager> logger)
        {
          
            objDict = new Dictionary<string, IWorkflowHandler>
            {
                {"OPEN",new OpenHandler(objCall,repository,unitOfWork,featureModule,logger)},
                {"ASSIGNED",new AssignedHandler(objCall,repository,unitOfWork,featureModule,logger)},
                {"ACCEPTED",new AcceptedHandler(objCall,repository,unitOfWork,logger)},
                {"NOTACCEPTED",new NotAcceptedHandler(objCall,repository,unitOfWork,logger)},
                {"RESOLVED",new ResolvedHandler(objCall,repository,unitOfWork,logger)},
                {"NOTRESOLVED",new NotResolvedHandler(objCall,repository,unitOfWork,featureModule,logger)},
                {"CLOSED",new CloseHandler(objCall,repository,unitOfWork,featureModule,logger)}
            };
            _hdlerStatus = objDict[objCall.Status.ToUpper()];
        }

        public void Execute()
        {
            _hdlerStatus.Handle();
        }

        public class OpenHandler : IWorkflowHandler, IDisposable
        {
            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private IFeatureModule _featureModule;
            private ILogger<ServiceCallManager> _logger;
            public OpenHandler(ServiceCall objCall,IRepository repository, IUnitOfWork unitOfWork, IFeatureModule featureModule, ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _featureModule = featureModule;
                _logger = logger;
            }

          

            public  void Handle()
            {
                

                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
        public class AssignedHandler : IWorkflowHandler, IDisposable
        {          
            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private IFeatureModule _featureModule;
            private ILogger<ServiceCallManager> _logger;
            public AssignedHandler(ServiceCall objCall, IRepository repository, IUnitOfWork unitOfWork, IFeatureModule featureModule,ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _featureModule = featureModule;
                _logger = logger;
            }
            public  void Handle()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
        public class AcceptedHandler : IWorkflowHandler, IDisposable
        {
            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private ILogger<ServiceCallManager> _logger;
            public AcceptedHandler(ServiceCall objCall, IRepository repository, IUnitOfWork unitOfWork, ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public void Handle()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
        public class NotAcceptedHandler : IWorkflowHandler, IDisposable
        {
            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private ILogger<ServiceCallManager> _logger;
            public NotAcceptedHandler(ServiceCall objCall, IRepository repository, IUnitOfWork unitOfWork, ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public void Handle()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
        public class ResolvedHandler : IWorkflowHandler, IDisposable
        {
           
            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private ILogger<ServiceCallManager> _logger;
            public ResolvedHandler(ServiceCall objCall, IRepository repository, IUnitOfWork unitOfWork, ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public  void Handle()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
        public class NotResolvedHandler : IWorkflowHandler, IDisposable
        {

            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private IFeatureModule _featureModule;
            private ILogger<ServiceCallManager> _logger;
            public NotResolvedHandler(ServiceCall objCall, IRepository repository, IUnitOfWork unitOfWork, IFeatureModule featureModule, ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _featureModule = featureModule;
                _logger = logger;
            }
            public void Handle()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
        public class CloseHandler : IWorkflowHandler, IDisposable
        {

            private ServiceCall _call;
            private IRepository _repository;
            private IUnitOfWork _unitOfWork;
            private IFeatureModule _featureModule;
            private ILogger<ServiceCallManager> _logger;
            public CloseHandler(ServiceCall objCall,IRepository repository, IUnitOfWork unitOfWork, IFeatureModule featureModule, ILogger<ServiceCallManager> logger)
            {
                _call = objCall;
                _repository = repository;
                _unitOfWork = unitOfWork;
                _featureModule = featureModule;
                _logger = logger;
            }
            public  void Handle()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                this.Dispose();
            }
        }
    }
}
