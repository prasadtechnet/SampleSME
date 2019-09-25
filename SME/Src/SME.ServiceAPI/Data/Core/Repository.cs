﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Data.Context;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SME.ServiceAPI.Data.Core
{
    public class Repository : IRepository
    {
      private ApplicationDbContext _context;
        public Repository(IDbFactory dbFactory)
        {
           _context = dbFactory.GetDataContext;
        }
      
        public async Task<T> Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return  _context.Set<T>().AsQueryable().FirstOrDefault(expression);
        }

        public async Task<IQueryable<T>> All<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _context.Set<T>().Where<T>(filter).AsQueryable() : _context.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual async Task Create<T>(T TObject) where T : class
        {
            var newEntry = _context.Set<T>().Add(TObject);
          
        }

        public virtual async Task Delete<T>(T TObject) where T : class
        {
            _context.Set<T>().Remove(TObject);
           
        }

        public virtual async Task Update<T>(T TObject) where T : class
        {
            try
            {
                
                var entry = _context.Entry(TObject);
                _context.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = await Filter<T>(predicate);
            foreach (var obj in objects)
                _context.Set<T>().Remove(obj);

           
        }
        public async Task<bool> Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Count<T>(predicate) > 0;
        }
        public virtual async Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }
        public virtual async Task ExecuteProcedure(String procedureCommand, params object[] sqlParams)
        {
            _context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }

        public Task<string> GetKey(string keyType) 
        {
            object keyValue = "";


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC [GenerateKey] '" + keyType + "'";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        keyValue = result[0];
                    }
                }
            }
            return Task.FromResult<string>(keyValue.ToString());
        }
    }
}
