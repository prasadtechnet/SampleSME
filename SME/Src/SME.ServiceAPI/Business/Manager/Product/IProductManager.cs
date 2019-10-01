using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
using SME.ServiceAPI.Business.Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Product
{
   public interface IProductManager

    {
        Task<ResponseModel> CreateProduct(ProductModel objInput);
        Task<ResponseModel> UpdateProduct(ProductModel objInput);
        Task<ResponseModel> DeleteProduct(string Id);     
        Task<ProductModel> GetProductById(string id);

        Task<ProductModel> GetProductByName(string name);
        Task<List<ProductModel>> GetProducts();

    }
}
