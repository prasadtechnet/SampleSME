using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
using SME.ServiceAPI.Business.Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Customer
{
  public  interface ICustomerManager 
    {
        //2.Customer
        //2.1. Create
        //2.2. Update
        //2.3. Delete set flag
        //2.4. CustomerById(include products)
        //2.5. CustomerByName(include products)
        //2.6. Customers(not include childs)  
        //2.7  Customer login
        //2.8  Customer Password Reset

        Task<ResponseModel> CreateCustomer(CustomerModel objInput);
        Task<ResponseModel> UpdateCustomer(CustomerModel objInput);
        Task<ResponseModel> DeleteCustomer(string Id);
        Task<CustomerModel> CustomerById(string Id);
        Task<CustomerModel> CustomerByName(string Name);
        Task<List<CustomerModel>> Customers();

        Task<ResponseModel> AddCustomerProduct(CustomerProductModel objInput);
        Task<ResponseModel> DeleteCustomerProduct(CustomerProductModel objInput);


        Task<CustomerAuthResponseModel> Authenticate(CustomerAuthRequestModel objInput);

        Task<CustomerResetResponseModel> ResetPassword(CustomerResetRequestModel objInput);

        // Task SaveChangesAsync();
    }
}
