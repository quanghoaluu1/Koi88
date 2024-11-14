using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class FarmRepository: IFarmRepository
    {
        private FarmDAO _farmDAO;
        public FarmRepository()
        {
            _farmDAO = FarmDAO.Instance;
        }

        public List<KoiFarm> GetFarms()
        {
            return _farmDAO.GetFarms();
        }

    }
}
