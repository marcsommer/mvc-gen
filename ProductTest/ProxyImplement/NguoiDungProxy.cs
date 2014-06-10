using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProductTest.Mapping;
using ProductTest.Repository;

namespace ProductTest.ProxyImplement
{
    public class NguoiDungProxy : IProvider<NguoiDung>
    {
        public NguoiDungProxy()
        {
            Provider = new DataProvider<NguoiDung>();
        }

        private IProvider<NguoiDung> Provider { get; set; }

        public IEnumerable<NguoiDung> GetAll()
        {
            //validate & log...
            //.......
            //.......
            return Provider.GetAll();
        }

        public IEnumerable<NguoiDung> Find(Func<NguoiDung, bool> predicate)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Find(predicate);
        }

        public int MassUpdate(Expression<Func<NguoiDung, bool>> predicate, Expression<Func<NguoiDung, NguoiDung>> setter)
        {
            //validate & log...
            //.......
            //.......
            return Provider.MassUpdate(predicate, setter);
        }

        public int MassDelete(Expression<Func<NguoiDung, bool>> predicate)
        {
            //validate & log...
            //.......
            //.......
            return Provider.MassDelete(predicate);
        }

        public int Insert(NguoiDung entity)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Insert(entity);
        }

        public int Update(NguoiDung entity)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Update(entity);
        }

        public int Delete(NguoiDung entity)
        {
            //validate & log...
            //.......
            //.......
            return Provider.Delete(entity);
        }

        public int InsertBacth(IEnumerable<NguoiDung> list)
        {
            //validate & log...  
            //.......
            //.......
            return Provider.InsertBacth(list);
        }
    }
}