using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    
namespace SME.ServiceAPI.Business.Configuration
{
    public static class ServiceExtension
    {
        public static void AddServicesInAssembly(IServiceCollection services, IConfiguration configuration)
        {
            var servs = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IServiceConfig).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IServiceConfig>().ToList();

            servs.ForEach(x => x.AddServices(services, configuration));
        }
    }
}
