using System.Collections.Generic;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class VarietyRepository : ICRUDRepository<Variety>
    {
        private VarietyDAO _varietyDAO;

        public VarietyRepository()
        {
            _varietyDAO =  VarietyDAO.Instance;
        }

        public Variety GetById(int id)
        {
            return _varietyDAO.GetVarietyById(id);
        }

        public List<Variety> GetAll()
        {
            return _varietyDAO.GetAllVarieties();
        }

        public bool Create(Variety entity)
        {
            return _varietyDAO.CreateVariety(entity);
        }

        public bool Update(Variety entity)
        {
            return _varietyDAO.UpdateVariety(entity);
        }

        public bool Delete(int id)
        {
            return _varietyDAO.DeleteVariety(id);
        }
    }
}