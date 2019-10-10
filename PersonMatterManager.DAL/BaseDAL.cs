using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.DAL
{
     public class BaseDAL<T> where T:class
    {
        HRCEntities db = new HRCEntities();
        public bool AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
            return Flag(db.SaveChanges());
        }

        public bool DeleteEntity(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return Flag(db.SaveChanges());
        }

        public bool ModifyEntity(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return Flag(db.SaveChanges());
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> GetPageInfo<s>(int pageIndex, int pageSize, out int total, Expression<Func<T, s>> orderbyLambda)
        {
            total = db.Set<T>().OrderBy<T, s>(orderbyLambda).Count();
            return db.Set<T>().OrderBy<T, s>(orderbyLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
        }

        public IQueryable<T> GetPageInfo<s>(int pageIndex, int pageSize, out int total, Expression<Func<T, s>> orderbyLambda, Expression<Func<T, bool>> whereLambda)
        {
            total = db.Set<T>().OrderBy<T, s>(orderbyLambda).Where(whereLambda).Count();
            var list = db.Set<T>().OrderBy<T, s>(orderbyLambda).Where(whereLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return list.AsQueryable();
        }

        public static bool Flag(int n)
        {
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
