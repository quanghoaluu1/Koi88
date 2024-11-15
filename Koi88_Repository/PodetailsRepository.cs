using Koi88_BusinessObject;
using Koi88_DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Repository
{
    public class PoDetailsRepository : IPodetailsRepository
    {
        public List<Podetail> GetPodetailsByPoId(int poId) => PodetailsDAO.Instance.GetPodetailsByPoId(poId);

        public void AddDodetail(Podetail podetail) => PodetailsDAO.Instance.AddDodetail(podetail);

        public void RemoveDodetail(int doDetailId) => PodetailsDAO.Instance.RemoveDodetail(doDetailId);
    }
}
