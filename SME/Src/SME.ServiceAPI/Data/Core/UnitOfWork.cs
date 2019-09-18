using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SME.ServiceAPI.Data.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        
        
        public void BeginTransaction()
        {
            _dbFactory.GetDataContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _dbFactory.GetDataContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            _dbFactory.GetDataContext.Database.CommitTransaction();
        }

        public void SaveChanges()
        {
           // _dbFactory.GetDataContext.Save();
        }
    }
}
