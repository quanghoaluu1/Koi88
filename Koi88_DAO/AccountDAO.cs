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

        public List<Account> GetAccountsByRoleId(int roleId)
        {
            return _dbContext.Accounts
           .Where(x => x.RoleId == roleId)
           .Select(a => new Account
           {
               AccountId = a.AccountId,
               Lastname = a.Lastname,
               Email = a.Email,
               Status = a.Status,
               // Get the first CustomerId from the Customers collection
               Customers = a.Customers.ToList() // Keep the Customers collection if needed
           })
           .ToList();
        }

        public List<Account> GetConsultantByRoleId(int roleId)
        {
            return _dbContext.Accounts.Where(a => a.RoleId == roleId).ToList();
        }

        public List<Account> GetAccountsByRoleIds(List<int> roleIds)
        {
            return _dbContext.Accounts
                .Include(a => a.Role)
                .Where(x => roleIds.Contains(x.RoleId.Value))
                .ToList();
        }

        public Account GetAccountByCustomerId(int customerId)
        {
            
            return _dbContext.Accounts
                .Include(a => a.Customers) 
                .FirstOrDefault(a => a.Customers.Any(c => c.CustomerId == customerId));
        }

        public bool UpdateAccountStatus(Account account)
        {
            // Find the existing account in the database
            var existingAccount = _dbContext.Accounts.SingleOrDefault(x => x.AccountId == account.AccountId);

            if (existingAccount != null)
            {
                // Update the status
                existingAccount.Status = account.Status;

                // Save changes to the database
                _dbContext.SaveChanges();
                return true; // Update was successful
            }
            else
            {
                return false; // Account not found
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                if (account != null)
                {
                    _dbContext.Accounts.Update(account);
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
