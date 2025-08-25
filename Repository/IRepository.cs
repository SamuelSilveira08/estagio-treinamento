using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        T DeleteById(string id);
        IEnumerable<T> GetAll();
        T GetById(string id);
    }
}