using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts;
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

        public async Task SaveChangesAsync()
        {
            await _unitofWork.SaveChangesAsync();
        }
        public Task Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BaseEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetProduct(string Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

      

        public Task Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
