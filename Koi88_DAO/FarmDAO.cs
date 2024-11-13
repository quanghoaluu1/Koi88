using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;

namespace Koi88_DAO
{
    public class FarmDAO
    {
        private static FarmDAO instance;
        private static Koi88Context db;
        public static FarmDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FarmDAO();
                    db = new Koi88Context();
                }
                return instance;
            }
        }
        private FarmDAO()
        {
        }

        public List<KoiFarm> GetFarms()
        {
            return db.KoiFarms.ToList();
        }
    }
}
