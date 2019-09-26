using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.ServiceAPI.Business.Manager.Auth;
using SME.ServiceAPI.Business.Manager.Customer;
using SME.ServiceAPI.Business.Manager.Product;
using SME.ServiceAPI.Business.Manager.ServiceCall;
using SME.ServiceAPI.Business.Manager.User;
using SME.ServiceAPI.Data.Context;
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

            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IServiceCallManager, ServiceCallManager>();
            
        }
    }
}
