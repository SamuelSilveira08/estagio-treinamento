using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    // Implementação genérica. Todas as implementações concretas vão herdar dela
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        private readonly List<T> _repository = new List<T>();
        private readonly Func<T, object, T> _factoryT;

        // Delegate Func<> age como factory para criar cópias de T
        public Repository(Func<T, object, T> factory) => _factoryT = factory;

        T IRepository<T>.Create(T entity)
        {
            // Verifica entrada duplicada
            if (_repository.Any(e => e.Equals(entity)))
                throw new DuplicatedRecordException($"Já existe um registro com esses valores: {entity}.");

            // Gera Id e copia entity para um novo objeto T com o Id gerado
            T copy = _factoryT(entity, Guid.NewGuid().ToString());
            _repository.Add(copy);
            Console.WriteLine($"Entidade {copy} adicionada com sucesso!");
            return copy;
        }

        T IRepository<T>.Update(T entity)
        {
            T toUpdate = _repository.Find(e => e.Id.Equals(entity.Id))
                ?? throw new EntityNotFoundException($"Entidade com ID {entity.Id} não encontrada.");

            _repository[_repository.IndexOf(toUpdate)] = entity;
            Console.WriteLine($"Entidade {entity} atualizada com sucesso!");
            return entity;
            
        }

        void IRepository<T>.Delete(T entity)
        {
            T toDelete = _repository.Find(e => e.Equals(entity))
                ?? throw new EntityNotFoundException($"Entidade com ID {entity.Id} não encontrada.");
            _repository.Remove(toDelete);
        }

        T IRepository<T>.DeleteById(string id)
        {
            T toDelete = _repository.Find(e => e.Id.Equals(id))
                ?? throw new EntityNotFoundException($"Entidade com Id {id} não encontrada.");
            _repository.Remove(toDelete);
            return toDelete;
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return _repository;
        }

        T IRepository<T>.GetById(string id)
        {
            return _repository.Find(e => e.Id.Equals(id)) ?? 
                throw new EntityNotFoundException($"Entidade com ID {id} não encontrada.");
        }
    }
}
