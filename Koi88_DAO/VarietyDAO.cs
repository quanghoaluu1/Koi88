using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;

namespace Koi88_DAO
{
    public class VarietyDAO
    {
        private static Koi88Context _dbContext;
        private static VarietyDAO instance;

        private VarietyDAO()
        {
        }

        public static VarietyDAO getInstance() {
            if (instance == null)
            {
                _dbContext = new Koi88Context();
                instance = new VarietyDAO();
            }
            return instance;
        }

        public List<Variety> GetVarieties()
        {
            return _dbContext.Varieties.ToList();
        }

        public Variety GetVarietyById(int id)
        {
            return _dbContext.Varieties.FirstOrDefault(v => v.VarietyId == id);
        }
    }
}
