using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLToolkit.Data;
using BLToolkit.Data.Linq;

namespace @NameSpace@.Repository
{
    public class DataProvider<T> : IProvider<T> where T : class
    {
        private readonly DbManager _dataContext = new DbManager();

        public IEnumerable<T> GetAll()
        {
            return _dataContext.GetTable<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            if (predicate == null)
                return GetAll();
            return GetAll().Where(predicate);
        }

        public int MassUpdate(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> setter)
        {
            try
            {
                return _dataContext.GetTable<T>().Update(predicate, setter);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int MassDelete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dataContext.GetTable<T>().Delete(predicate);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public object Insert(T entity)
        {
            try
            {
                return _dataContext.InsertWithIdentity(entity);

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public int Update(T entity)
        {
            try
            {
                return _dataContext.Update(entity);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int Delete(T entity)
        {
            try
            {
                return _dataContext.Delete(entity);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int InsertBacth(IEnumerable<T> list)
        {
            try
            {
                return _dataContext.InsertBatch(list);
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}