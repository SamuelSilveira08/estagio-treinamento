using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> where T : class, IEntity, IEnumerable<T>
    {
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        T DeleteById(long id);
        IEnumerable<T> GetAll();
        T GetById(long id);
    }
}