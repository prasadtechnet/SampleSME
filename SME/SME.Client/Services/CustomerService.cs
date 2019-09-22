using Microsoft.AspNetCore.Http;
using SME.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Client.Services
{
    public interface ICustomerService
    {
        Task<string> GetCustomers();
    }
    public class CustomerService:BaseService, ICustomerService
    {
        public CustomerService(ClientAPI options, IHttpContextAccessor httpContext) : base(options.baseUrl, httpContext)
        {

        }

        public async  Task<string> GetCustomers()
        {
            var resp = await GetAsync<string>("customer/customers");
            return resp;
        }

      
    }
}
