using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private DeliveryDAO _deliveryDAO;

        public DeliveryRepository()
        {
            _deliveryDAO = DeliveryDAO.Instance;
        }

        public List<Po> GetDepositPo()
        {
            return _deliveryDAO.GetDepositPo();
        }

        public Po GetPoById(int id)
        {
            return _deliveryDAO.GetPoById(id);
        }
    }
}
