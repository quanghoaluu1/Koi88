using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;

namespace Koi88_DAO
{
    public class DeliveryDAO
    {
        private static DeliveryDAO _instance;
        private static Koi88Context _context;
        public static DeliveryDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeliveryDAO();
                    _context = new Koi88Context();
                }
                return _instance;
            }
            private set { }
        }

        public List<Po> GetDepositPo()
        {
            return _context.Pos.Where(p => p.Status == "Deposit").ToList();
        }

        public Po GetPoById(int poId)
        {
            return _context.Pos.SingleOrDefault(p => p.PoId == poId);
        }

    }
}
