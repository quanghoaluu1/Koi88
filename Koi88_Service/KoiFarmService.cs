using System.Collections.Generic;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class KoiFarmService : ICRUDService<KoiFarm>
    {
        private KoiFarmRepository _koiFarmRepository;

        public KoiFarmService()
        {
            _koiFarmRepository = new KoiFarmRepository();
        }

        public KoiFarm GetById(int id)
        {
            return _koiFarmRepository.GetById(id);
        }

        public List<KoiFarm> GetAll()
        {
            return _koiFarmRepository.GetAll();
        }

        public bool Create(KoiFarm entity)
        {
            return _koiFarmRepository.Create(entity);
        }

        public bool Update(KoiFarm entity)
        {
            return _koiFarmRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _koiFarmRepository.Delete(id);
        }
    }
}