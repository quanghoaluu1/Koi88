using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_DAO
{
    public class PoDAO
    {
        private static PoDAO instance;
        private static Koi88Context _dbContext;

        private PoDAO()
        {

        }
        public static PoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PoDAO();
                    _dbContext = new Koi88Context();
                }

                return instance;
            }

        }

        public void AddPo(Po po)
        {
            _dbContext.Add(po);
            _dbContext.SaveChanges();
        }
    }
}
