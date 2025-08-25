using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;

namespace Service
{
    public class BestiarioService
    {
        private readonly Func<BestiarioRecord, object, BestiarioRecord> _factory;
        private readonly IRepository<BestiarioRecord> _repository;

        public BestiarioService()
        {
            _factory = (entity, id) => entity.With(id: id.ToString());
            _repository = new Repository<BestiarioRecord>(_factory);
        }

        public BestiarioRecord Update(BestiarioRecord entity)
        {
            entity = entity.Update(entity);
            return _repository.Update(entity);
        }

        public BestiarioRecord Create(BestiarioRecord entity)
        {
            return _repository.Create(entity);
        }

        public void Delete(BestiarioRecord entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteById(string id)
        {
            _repository.DeleteById(id);
        }

        public IEnumerable<BestiarioRecord> GetAll()
        {
            return _repository.GetAll();
        }

        public BestiarioRecord GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}
