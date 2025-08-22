using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        void IRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.GetById(long id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository<T>.GetList()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
