using System.Collections.Generic;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class KoiFishRepository : ICRUDRepository<KoiFish>
    {
        private KoiFishDAO _koiFishDAO;

        public KoiFishRepository()
        {
            _koiFishDAO = KoiFishDAO.Instance;
        }

        public KoiFish GetById(int id)
        {
            return _koiFishDAO.GetKoiFishById(id);
        }

        public List<KoiFish> GetAll()
        {
            return _koiFishDAO.GetAllKoiFishes();
        }

        public bool Create(KoiFish entity)
        {
            return _koiFishDAO.CreateKoiFish(entity);
        }

        public bool Update(KoiFish entity)
        {
            return _koiFishDAO.UpdateKoiFish(entity);
        }

        public bool Delete(int id)
        {
            return _koiFishDAO.DeleteKoiFish(id);
        }
    }
}