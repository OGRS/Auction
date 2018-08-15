using Auction.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.Repositories
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() 
            => _dbSet.AsNoTracking().ToList();

        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
            => Include(includeProperties).ToList();

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public T FindById(int id) => _dbSet.Find(id);

        public T FindWithInclude(Func<T, bool> predicate, 
            params Expression<Func<T, object>>[] includeProperties)
            => Include(includeProperties).SingleOrDefault(predicate);

        public IEnumerable<T> Find(Func<T, bool> predicate) 
            => _dbSet.AsNoTracking().Where(predicate).ToList();

        public void Create(T item) => _dbSet.Add(item);

        public void Update(T item) 
            => _context.Entry(item).State = EntityState.Modified;
    
        public void Remove(T item) => _dbSet.Remove(item);

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
