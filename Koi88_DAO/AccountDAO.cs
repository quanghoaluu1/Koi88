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
        private Koi88Context _dbContext;

        public AccountDAO()
        {
            _dbContext = new Koi88Context();
        }
        public AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
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
