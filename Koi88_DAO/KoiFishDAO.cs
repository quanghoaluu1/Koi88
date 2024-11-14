using System;
using System.Collections.Generic;
using System.Linq;
using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace Koi88_DAO
{
    public class KoiFishDAO
    {
        private static KoiFishDAO instance;
        private static Koi88Context _dbContext;

        private KoiFishDAO()
        {
        }

        public static KoiFishDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiFishDAO();
                    _dbContext = new Koi88Context();
                }
                return instance;
            }
        }

        public KoiFish GetKoiFishById(int koiId)
        {
            return _dbContext.KoiFishes.Include(k => k.Variety).SingleOrDefault(x => x.KoiId == koiId);
        }

        public List<KoiFish> GetAllKoiFishes()
        {
            return _dbContext.KoiFishes.Include(k => k.Variety).ToList();
        }

        public bool CreateKoiFish(KoiFish koiFish)
        {
            try
            {
                _dbContext.KoiFishes.Add(koiFish);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            try
            {
                _dbContext.KoiFishes.Update(koiFish);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteKoiFish(int koiId)
        {
            try
            {
                var koiFish = GetKoiFishById(koiId);
                if (koiFish != null)
                {
                    _dbContext.KoiFishes.Remove(koiFish);
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