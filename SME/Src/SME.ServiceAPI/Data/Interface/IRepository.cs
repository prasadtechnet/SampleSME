using SME.ServiceAPI.Data.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SME.ServiceAPI.Data.Interface
{
    public interface IRepository
    {
        Task<IQueryable<T>> All<T>() where T : class;
        Task Create<T>(T TObject) where T : class;
        Task Delete<T>(T TObject) where T : class;
        Task Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task Update<T>(T TObject) where T : class;
        Task ExecuteProcedure(string procedureCommand, params object[] sqlParams);
        Task<IEnumerable<T>> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class;
        Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> Single<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<bool> Contains<T>(Expression<Func<T, bool>> predicate) where T : class;

        Task<string> GetKey(string keyType);
    }
}
