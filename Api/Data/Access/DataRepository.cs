using System.Collections.Generic;
using System.Linq;


using Microsoft.EntityFrameworkCore;

using Api.Interfaces;
using Api.Data.Models;
using Api.Data.Contexts;

namespace Api.Data.Access
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly ReadyToGoContext _context;
        private readonly DbSet<T> _dbSet;
        public DataRepository(ReadyToGoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetUsingRawSql(string query, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(query, parameters);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T Get(params object[] parameters)
        {
            return _dbSet.Find(parameters);
        }

    }
}
