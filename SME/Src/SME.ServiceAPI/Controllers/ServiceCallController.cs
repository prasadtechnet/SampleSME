using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Manager.ServiceCall;

namespace SME.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCallController : ControllerBase
    {      
        #region Varaibles

        private IServiceCallManager _scManager;
        private ILogger<ServiceCallController> _logger;

        #endregion

        #region Controller

        public ServiceCallController(IServiceCallManager scManager, ILogger<ServiceCallController> logger)
        {
            _scManager = scManager;
            _logger = logger;
        }

        #endregion

        #region Endpoints

        #region ServiceCall Create

        #endregion

        #region ServiceCall Update

        #endregion

        #endregion

    }
}