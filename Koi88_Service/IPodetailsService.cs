using Koi88_BusinessObject;
using Koi88_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Service
{
    public interface IPodetailsService
    {
        public List<Podetail> GetPodetailsByPoId(int poId);

        public void AddDodetail(Podetail podetail);

        public void RemoveDodetail(int doDetailId);
    }
}
