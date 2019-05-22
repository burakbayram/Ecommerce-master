using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Data
{
    public interface IRepository<T> where T:BaseEntity
    {
        IList<T> GetAll(params string[] navigation);
        IList<T> GetAll(Expression<Func<T, bool>> where, params string[] navigation);
        T Get(string id, params string[] navigation);
        T Get(Expression<Func<T, bool>> where, params string[] navigation);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
