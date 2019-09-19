using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Data.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void RollbackTransaction();

        void CommitTransaction();

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
