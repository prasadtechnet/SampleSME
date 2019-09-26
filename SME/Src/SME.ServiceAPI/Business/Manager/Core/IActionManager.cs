using SME.ServiceAPI.Business.Contracts;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Core
{
   public interface IActionManager
    {

        Task Create(BaseEntity entity);
        Task Update(BaseEntity entity);
        Task Delete(BaseEntity entity);
        Task<IEnumerable<BaseEntity>> GetAll();

      //  void SaveChanges();
      //  Task SaveChangesAsync();
    }
}
