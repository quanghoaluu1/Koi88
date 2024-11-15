using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Repository
{
    public interface IPodetailsRepository
    {
        public List<Podetail> GetPodetailsByPoId(int poId);

        public void AddDodetail(Podetail podetail);

        public void RemoveDodetail(int doDetailId);
    }
}
