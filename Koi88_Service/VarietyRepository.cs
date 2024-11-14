using System.Collections.Generic;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class VarietyService : ICRUDService<Variety>
    {
        private VarietyRepository _varietyRepository;

        public VarietyService( )
        {
            _varietyRepository = new VarietyRepository();
        }

        public Variety GetById(int id)
        {
            return _varietyRepository.GetById(id);
        }

        public List<Variety> GetAll()
        {
            return _varietyRepository.GetAll();
        }

        public bool Create(Variety entity)
        {
            return _varietyRepository.Create(entity);
        }

        public bool Update(Variety entity)
        {
            return _varietyRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _varietyRepository.Delete(id);
        }
    }
}