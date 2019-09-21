using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.ServiceAPI.Business.Manager.Auth;
using SME.ServiceAPI.Data.Core;
using SME.ServiceAPI.Data.Interface;

namespace SME.ServiceAPI.Business.Configuration
{
    public class ManagerConfig : IServiceConfig
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
