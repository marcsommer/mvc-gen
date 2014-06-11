using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace @NameSpace@.Repository
{
    public interface IProvider<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        int MassUpdate(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> setter);
        int MassDelete(Expression<Func<T, bool>> predicate);
        object Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        int InsertBacth(IEnumerable<T> list);
    }
}