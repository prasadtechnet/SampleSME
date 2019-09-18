using SME.ServiceAPI.Business.BusinessFlow.Core;
using SME.ServiceAPI.Common.Entities;
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
        public CallWorkFlow(ServiceCall objCall)
        {
          
            objDict = new Dictionary<string, IWorkflowHandler>
            {
                {"OPEN",new OpenHandler(objCall)},
                {"APPROVED",new ApproveHandler(objCall)},
                {"REJECTED",new RejectHandler(objCall)},
                {"CLOSED",new CloseHandler(objCall)}
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
            public OpenHandler(ServiceCall objCall)
            {
                _call = objCall;
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
        public class ApproveHandler : IWorkflowHandler, IDisposable
        {          
            private ServiceCall _call;
            public ApproveHandler(ServiceCall objCall)
            {
                _call = objCall;
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
        public class RejectHandler : IWorkflowHandler, IDisposable
        {
           
            private ServiceCall _call;
            public RejectHandler(ServiceCall objCall)
            {
                _call = objCall;
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
        public class CloseHandler : IWorkflowHandler, IDisposable
        {

            private ServiceCall _call;
            public CloseHandler(ServiceCall objCall)
            {
                _call = objCall;
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
