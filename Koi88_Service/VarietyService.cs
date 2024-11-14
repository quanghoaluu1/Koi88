using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class VarietyService: IVarietyService
    {
        private IVarietyRepository varietyRepository;

        public VarietyService()
        {
            varietyRepository = new VarietyRepository();
        }

        public List<Variety> GetVarieties()
        {
            return varietyRepository.GetVarieties();
        }

        public Variety GetVarietyById(int id)
        {
            return varietyRepository.GetVarietyById(id);
        }
    }
}
