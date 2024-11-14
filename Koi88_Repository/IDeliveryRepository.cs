using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;

namespace Koi88_Repository
{
    public interface IDeliveryRepository
    {
        List<Po> GetDepositPo();
        public Po GetPoById(int id);

    }
}
