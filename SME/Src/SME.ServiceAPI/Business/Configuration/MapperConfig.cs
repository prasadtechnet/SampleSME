using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.ServiceAPI.Business.Mapper;

namespace SME.ServiceAPI.Business.Configuration
{
    public class MapperConfig : IServiceConfig
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var newMapProfile = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            IMapper mapper = newMapProfile.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
            services.AddAutoMapper(typeof(IStartup));
        }
    }
}
