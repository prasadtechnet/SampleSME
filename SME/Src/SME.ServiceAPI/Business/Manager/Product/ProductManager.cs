using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        #endregion

        #region Constructor
        public ProductManager(IRepository repository, IUnitOfWork unitofWork, ILogger<ProductManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
        }

        #endregion

        #region product

     
        public async Task Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BaseEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> GetProduct(string Id)
        {
            throw new NotImplementedException();
        }

      

        public async Task Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SaveChanges commit
        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
