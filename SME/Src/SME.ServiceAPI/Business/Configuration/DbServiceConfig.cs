using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.ServiceAPI.Common.Idenitity;
using SME.ServiceAPI.Data.Context;

namespace SME.ServiceAPI.Business.Configuration
{
    public class DbServiceConfig : IServiceConfig
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddDefaultIdentity<AppUser>()
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.Configure<IdentityOptions>(opt => {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequiredUniqueChars = 1;

            });

         //   services.AddTransient<IUserStore<AppUser>>();
          //  services.AddTransient<IRoleStore<AppRole>>();
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
