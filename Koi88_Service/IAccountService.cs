using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Service
{
    public interface IAccountService
    {
        public Account GetAccountByUsername(string username);
        public Account GetAccountByAccountId(int id);
        public List<Account> GetAccountsByRoleId(int roleId);
        public List<Account> GetAccountsByRoleIds(List<int> roleIds);
        public bool UpdateAccountStatus(Account account);
        public Account GetAccountByCustomerId(int customerId);
        public List<Account> GetConsultantByRoleId(int roleId);
    }
}
