using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        void Save(T entity);
        void Delete(T entity);
        IEnumerable<T> GetList();
        T GetById(long id);
    }
}
