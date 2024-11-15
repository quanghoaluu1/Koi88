using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_DAO
{
    public class KoiDAO
    {
        private static KoiDAO instance;
        private static Koi88Context db;
        public static KoiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiDAO();
                    db = new Koi88Context();
                }
                return instance;
            }
        }
        private KoiDAO()
        {
        }

        public List<KoiFish> GetFish()
        {
            return db.KoiFishes.ToList();
        }
    }
}
