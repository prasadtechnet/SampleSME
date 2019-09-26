using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
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

     
        public async Task<bool> CreateProduct(ProductModel entity)
        {
            var objInput = entity as ProductModel;
            await _repository.Create<SME.ServiceAPI.Common.Entities.Product>(_mapper.Map<SME.ServiceAPI.Common.Entities.Product>(objInput));

            await _unitofWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProduct(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var objProd = await _repository.All<SME.ServiceAPI.Common.Entities.Product>();
            if (objProd != null)
            {
                return objProd.Select(x => _mapper.Map<ProductModel>(x)).ToList();
            }

            return null;
        }

        public async Task<ProductModel> GetProductById(string id)
        {
            var objProd = await _repository.Find<SME.ServiceAPI.Common.Entities.Product>(x => x.Id == id);
            if (objProd != null)
            {
                return _mapper.Map<ProductModel>(objProd);
            }

            return null;
        }

        public async Task<ProductModel> GetProductByName(string name)
        {
            var objProd = await _repository.Find<SME.ServiceAPI.Common.Entities.Product>(x => x.Name == name);
            if (objProd != null)
            {
                return _mapper.Map<ProductModel>(objProd);
            }

            return null;
        }

        public async Task<bool> UpdateProduct(ProductModel entity)
        {
            var objInput = entity as ProductModel;
            await _repository.Update<SME.ServiceAPI.Common.Entities.Product>(_mapper.Map<SME.ServiceAPI.Common.Entities.Product>(objInput));

            await _unitofWork.SaveChangesAsync();

            return true;
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
