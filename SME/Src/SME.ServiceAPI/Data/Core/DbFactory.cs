using SME.ServiceAPI.Data.Context;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SME.ServiceAPI.Data.Core
{
    public class DbFactory : IDbFactory, IDisposable
    {

        private ApplicationDbContext _dataContext;
        public DbFactory(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ApplicationDbContext GetDataContext
        {
            get
            {
                return _dataContext;
            }
        }

        #region Disposing 

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                }
            }
            isDisposed = true;
        }

        #endregion
    }
}
