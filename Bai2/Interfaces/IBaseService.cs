using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Interfaces
{
    public interface IBaseService<T>
    {
        public List<T> FindAll();
        public T FindById(int id);
        public bool Create(T entity);
        public bool Update(T entity);
        public bool DeleteById(int id);
    }
}
