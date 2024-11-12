using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace Koi88_DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private static Koi88Context _dbContext;

        private AccountDAO()
        {
           
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                    _dbContext = new Koi88Context();
                }
                    
                return instance;
            }
            
        }

        public Account GetAccountByUsername(string username)
        {
            return _dbContext.Accounts.Include(a => a.Customers).SingleOrDefault(x => x.Username == username);
        }

        public Account GetAccountByAccountID(int id)
        {
            return _dbContext.Accounts.Include(a => a.Customers).SingleOrDefault(x => x.AccountId == id);
        }
    }
}
