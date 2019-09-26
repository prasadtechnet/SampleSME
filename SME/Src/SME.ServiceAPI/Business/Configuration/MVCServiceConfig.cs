using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SME.ServiceAPI.Business.Contracts.BusinessEntities.Validators;
using Swashbuckle.AspNetCore.Swagger;

namespace SME.ServiceAPI.Business.Configuration
{
    public class MVCServiceConfig : IServiceConfig
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc()
                .AddFluentValidation(fvg=>fvg.RegisterValidatorsFromAssemblyContaining<ServiceCallValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Swagger
            services.AddSwaggerGen(config => {

                config.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Order Api",
                    Description = "Test API",
                    TermsOfService = "https://example.com/terms",
                    Contact = new Contact { Name = "prasad", Email = string.Empty, Url = "https://twitter.com/spboyer" },
                    License = new License { Name = "lic1", Url = "https://example.com/licence" }
                });

                var security = new Dictionary<string, IEnumerable<string>> {
                    {"Bearer",new string[0] }
                };

                config.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Jwt Authorization for Order Api",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"

                });
                config.AddSecurityRequirement(security);
            });
        }
    }
}
