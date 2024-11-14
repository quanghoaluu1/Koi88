using System;
using System.Collections.Generic;
using System.Linq;
using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace Koi88_DAO
{
    public class VarietyDAO
    {
        private static VarietyDAO instance;
        private static Koi88Context _dbContext;

        private VarietyDAO()
        {
        }

        public static VarietyDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VarietyDAO();
                    _dbContext = new Koi88Context();
                }
                return instance;
            }
        }

        public Variety GetVarietyById(int varietyId)
        {
            return _dbContext.Varieties.SingleOrDefault(x => x.VarietyId == varietyId);
        }

        public List<Variety> GetAllVarieties()
        {
            return _dbContext.Varieties.ToList();
        }

        public bool CreateVariety(Variety variety)
        {
            try
            {
                _dbContext.Varieties.Add(variety);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateVariety(Variety variety)
        {
            try
            {
                _dbContext.Varieties.Update(variety);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteVariety(int varietyId)
        {
            try
            {
                var variety = GetVarietyById(varietyId);
                if (variety != null)
                {
                    _dbContext.Varieties.Remove(variety);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}