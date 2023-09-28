using Bai2.Data;
using Bai2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Common
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public BaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual bool Create(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
            var rows = this.dbContext.SaveChanges();

            if (rows <= 0)
            {
                return false;
            }

            return true;
        }

        public virtual bool DeleteById(int id)
        {
            var deleteEntity = this.dbContext.Set<T>().Find(id);
            if (deleteEntity == null)
            {
                return false;
            }

            this.dbContext.Set<T>().Remove(deleteEntity);
            var rows = this.dbContext.SaveChanges();

            if (rows <= 0)
            {
                return false;

            }

            return true;
        }

        public virtual List<T> FindAll()
        {
            return this.dbContext.Set<T>().ToList();
        }

        public virtual T FindById(int id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public virtual bool Update(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
            var rows = this.dbContext.SaveChanges();

            if (rows <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
