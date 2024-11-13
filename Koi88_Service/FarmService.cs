using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class FarmService: IFarmService
    {
        private IFarmRepository _farmRepository;
        public FarmService()
        {
            _farmRepository = new FarmRepository();
        }
        public List<KoiFarm> GetFarms()
        {
            return _farmRepository.GetFarms();
        }
    }
}
