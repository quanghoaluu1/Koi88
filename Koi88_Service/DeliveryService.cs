using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class DeliveryService: IDeliveryService
    {
        private IDeliveryRepository _deliveryRepository;

        public DeliveryService()
        {
            _deliveryRepository = new DeliveryRepository();
        }
        public List<Po> GetDepositPo()
        {
            return _deliveryRepository.GetDepositPo();
        }

        public Po GetPoById(int id)
        {
            return _deliveryRepository.GetPoById(id);
        }
    }
}
