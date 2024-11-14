using System;
using System.Collections.Generic;
using System.Linq;
using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace Koi88_DAO
{
    public class KoiFarmDAO
    {
        private static KoiFarmDAO instance;
        private static Koi88Context _dbContext;

        private KoiFarmDAO()
        {
        }

        public static KoiFarmDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiFarmDAO();
                    _dbContext = new Koi88Context();
                }
                return instance;
            }
        }

        public KoiFarm GetKoiFarmById(int farmId)
        {
            return _dbContext.KoiFarms.SingleOrDefault(x => x.FarmId == farmId);
        }

        public List<KoiFarm> GetAllKoiFarms()
        {
            return _dbContext.KoiFarms.ToList();
        }

        public bool CreateKoiFarm(KoiFarm koiFarm)
        {
            try
            {
                _dbContext.KoiFarms.Add(koiFarm);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateKoiFarm(KoiFarm koiFarm)
        {
            try
            {
                _dbContext.KoiFarms.Update(koiFarm);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteKoiFarm(int farmId)
        {
            try
            {
                var koiFarm = GetKoiFarmById(farmId);
                if (koiFarm != null)
                {
                    _dbContext.KoiFarms.Remove(koiFarm);
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