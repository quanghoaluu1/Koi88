using Koi88_BusinessObject;
using Koi88_DAO;
using Koi88_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Service
{
    public class PodetailsService : IPodetailsService
    {

        private IPodetailsRepository podetailsRepository;
        public PodetailsService()
        {
            podetailsRepository = new PoDetailsRepository();
        }

        public List<Podetail> GetPodetailsByPoId(int poId)
        {
            return podetailsRepository.GetPodetailsByPoId(poId);
        }

        public void AddDodetail(Podetail podetail)
        {
            podetailsRepository.AddDodetail(podetail);
        }

        public void RemoveDodetail(int doDetailId)
        {
            podetailsRepository.RemoveDodetail(doDetailId);
        }
    }
}
