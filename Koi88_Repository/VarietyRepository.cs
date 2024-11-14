using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class VarietyRepository: IVarietyRepository
    {
        private VarietyDAO varietyDao;

        public VarietyRepository()
        {
            varietyDao = VarietyDAO.getInstance();
        }

        public List<Variety> GetVarieties()
        {
            return varietyDao.GetVarieties();
        }

        public Variety GetVarietyById(int id)
        {
            return varietyDao.GetVarietyById(id);
        }
    }
}
