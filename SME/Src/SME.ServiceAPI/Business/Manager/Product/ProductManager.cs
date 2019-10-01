using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
using SME.ServiceAPI.Business.Manager.Customer;
using SME.ServiceAPI.Data.Interface;

namespace SME.ServiceAPI.Business.Manager.Product
{
    public class ProductManager : IProductManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<ProductManager> _logger;
        private IMapper _mapper;
        #endregion

        #region Constructor
        public ProductManager(IRepository repository, IUnitOfWork unitofWork, IMapper mapper, ILogger<ProductManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion

        #region product

     
        public async Task<ResponseModel> CreateProduct(ProductModel entity)
        {
            try
            {
                var objInput = entity as ProductModel;
                await _repository.Create<SME.ServiceAPI.Common.Entities.Product>(_mapper.Map<SME.ServiceAPI.Common.Entities.Product>(objInput));

                await _unitofWork.SaveChangesAsync();
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "Product has been created." };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> DeleteProduct(string Id)
        {
            try { 
            throw new NotImplementedException();
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "Product has been deleted" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            try
            {
                var objProd = await _repository.All<SME.ServiceAPI.Common.Entities.Product>();
                if (objProd != null)
                {
                    return objProd.Select(x => _mapper.Map<ProductModel>(x)).ToList();
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public async Task<ProductModel> GetProductById(string id)
        {
            try
            {
                var objProd = await _repository.Find<SME.ServiceAPI.Common.Entities.Product>(x => x.Id == id);
                if (objProd != null)
                {
                    return _mapper.Map<ProductModel>(objProd);
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public async Task<ProductModel> GetProductByName(string name)
        {
            try
            {
                var objProd = await _repository.Find<SME.ServiceAPI.Common.Entities.Product>(x => x.Name == name);
                if (objProd != null)
                {
                    return _mapper.Map<ProductModel>(objProd);
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public async Task<ResponseModel> UpdateProduct(ProductModel entity)
        {
            try
            {
                var objInput = entity as ProductModel;
                await _repository.Update<SME.ServiceAPI.Common.Entities.Product>(_mapper.Map<SME.ServiceAPI.Common.Entities.Product>(objInput));

                await _unitofWork.SaveChangesAsync();
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "Product has been updated" };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }
        #endregion

        #region SaveChanges commit
        //public async Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}
