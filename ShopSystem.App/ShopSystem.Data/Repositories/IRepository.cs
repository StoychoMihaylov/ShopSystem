using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        T Add(T entity);

        T Update(T entity);

        T Remove(object id);

        void Remove(T entity);

        void SaveChanges();
    }
}
