using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using @NameSpace@.Mapping;
using @NameSpace@.Repository;

namespace @NameSpace@.Services
{
    public class @ClassName@Service : IProvider<@ClassName@>
    {
        public @ClassName@Service()
        {
            Provider = new DataProvider<@ClassName@>();
        }

        private IProvider<@ClassName@> Provider { get; set; }

        public IEnumerable<@ClassName@> GetAll()
        {
            //validate & log...
            //.......
            //.......
            return Provider.GetAll();
        }

        public IEnumerable<@ClassName@> Find(Func<@ClassName@, bool> predicate)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Find(predicate);
        }

        public int MassUpdate(Expression<Func<@ClassName@, bool>> predicate, Expression<Func<@ClassName@, @ClassName@>> setter)
        {
            //validate & log...
            //.......
            //.......
            return Provider.MassUpdate(predicate, setter);
        }

        public int MassDelete(Expression<Func<@ClassName@, bool>> predicate)
        {
            //validate & log...
            //.......
            //.......
            return Provider.MassDelete(predicate);
        }

        public int Insert(@ClassName@ entity)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Insert(entity);
        }

        public int Update(@ClassName@ entity)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Update(entity);
        }

        public int Delete(@ClassName@ entity)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Delete(entity);
        }

        public int InsertBacth(IEnumerable<@ClassName@> list)
        {
            //validate & log...  
            //.......
            //.......
            return Provider.InsertBacth(list);
        }
    }
}