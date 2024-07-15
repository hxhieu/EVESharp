using EVESharp.Database.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EVESharp.StandaloneServer.Database.Repository
{
    internal interface IGenericRepository<T> where T : class
    {
        Task AddAsync (T entity);
        Task<T?> GetFirstAsync (Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync (bool tracked = true);
        Task UpdateAsync (T entity);
        Task DeleteAsync (Expression<Func<T, bool>> expression);
        Task SaveAsync ();
    }

    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EveSharpDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository (EveSharpDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T> ();
        }

        public async Task<T?> GetFirstAsync (Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                return null;
            }
            return await _dbContext.Set<T> ().FirstOrDefaultAsync (expression);
        }

        public async Task AddAsync (T entity)
        {
            await _dbSet.AddAsync (entity);
            await SaveAsync ();
        }

        public async Task DeleteAsync (Expression<Func<T, bool>> expression)
        {
            var entityToDelete = await GetFirstAsync (expression);

            if (entityToDelete != null)
            {
                _dbSet.Remove (entityToDelete);
                await SaveAsync ();
            }
        }

        public async Task<List<T>> GetAllAsync (bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking ();
            }

            return await query.ToListAsync ();
        }

        public async Task UpdateAsync (T entity)
        {
            _dbSet.Update (entity);
            await SaveAsync ();
        }

        public async Task SaveAsync ()
        {
            await _dbContext.SaveChangesAsync ();
        }
    }
}
