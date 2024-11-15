using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_DAO
{
    public class PodetailsDAO
    {
        private static PodetailsDAO instance;
        private static Koi88Context _dbContext;

        private PodetailsDAO()
        {

        }
        public static PodetailsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PodetailsDAO();
                    _dbContext = new Koi88Context();
                }

                return instance;
            }

        }

        public List<Podetail> GetPodetailsByPoId(int poId)
        {
            return _dbContext.Podetails.Where(p => p.PoId.Equals(poId)).Include(m => m.Koi).Include(m => m.Farm).ToList();
        }

        public Podetail GetPodetailById(int id)
        {
            return _dbContext.Podetails.SingleOrDefault(m => m.PoDetailId.Equals(id));
        }

        public void AddDodetail(Podetail podetail)
        {
            _dbContext.Podetails.Add(podetail);
            _dbContext.SaveChanges();
        }

        public void RemoveDodetail(int doDetailId)
        {
            Podetail podetail = this.GetPodetailById(doDetailId);
            _dbContext.ChangeTracker.Clear();
            _dbContext.Podetails.Remove(podetail);
            _dbContext.SaveChanges();
        }
    }
}
