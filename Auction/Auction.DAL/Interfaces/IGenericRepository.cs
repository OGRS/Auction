using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Auction.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        T FindById(int id);

        T FindWithInclude(Func<T, bool> predicate, 
            params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Create(T item);

        void Update(T item);

        void Remove(T item);
    }
}
