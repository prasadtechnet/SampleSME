
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Configuration
{
   public interface IServiceConfig
    {
        void AddServices(IServiceCollection services, IConfiguration configuration);
    }
}
