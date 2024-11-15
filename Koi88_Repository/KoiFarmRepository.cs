using System.Collections.Generic;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class KoiFarmRepository : ICRUDRepository<KoiFarm>
    {
        private KoiFarmDAO _koiFarmDAO;

        public KoiFarmRepository()
        {
            _koiFarmDAO = KoiFarmDAO.Instance;
        }

        public KoiFarm GetById(int id)
        {
            return _koiFarmDAO.GetKoiFarmById(id);
        }

        public List<KoiFarm> GetAll()
        {
            return _koiFarmDAO.GetAllKoiFarms();
        }

        public bool Create(KoiFarm entity)
        {
            return _koiFarmDAO.CreateKoiFarm(entity);
        }

        public bool Update(KoiFarm entity)
        {
            return _koiFarmDAO.UpdateKoiFarm(entity);
        }

        public bool Delete(int id)
        {
            return _koiFarmDAO.DeleteKoiFarm(id);
        }
    }
}