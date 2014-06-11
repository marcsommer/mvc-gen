﻿using System;
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
            return _dataContext.GetTable<T>().Update(predicate, setter);
        }

        public int MassDelete(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.GetTable<T>().Delete(predicate);
        }

        public object Insert(T entity)
        {
            return _dataContext.InsertWithIdentity(entity);
        }

        public int Update(T entity)
        {
            return _dataContext.Update(entity);
        }

        public int Delete(T entity)
        {
            return _dataContext.Delete(entity);
        }

        public int InsertBacth(IEnumerable<T> list)
        {
            return _dataContext.InsertBatch(list);
        }
    }
}