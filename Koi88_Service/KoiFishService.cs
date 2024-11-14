using System.Collections.Generic;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class KoiFishService : ICRUDService<KoiFish>
    {
        private KoiFishRepository _koiFishRepository;

        public KoiFishService()
        {
            _koiFishRepository = new KoiFishRepository();
        }

        public KoiFish GetById(int id)
        {
            return _koiFishRepository.GetById(id);
        }

        public List<KoiFish> GetAll()
        {
            return _koiFishRepository.GetAll();
        }

        public bool Create(KoiFish entity)
        {
            return _koiFishRepository.Create(entity);
        }

        public bool Update(KoiFish entity)
        {
            return _koiFishRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _koiFishRepository.Delete(id);
        }
    }
}