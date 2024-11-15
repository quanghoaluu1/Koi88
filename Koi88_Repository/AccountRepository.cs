using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class AccountRepository: IAccountRepository
    {
        private AccountDAO _accountDAO;
        public AccountRepository()
        {
            _accountDAO = AccountDAO.Instance;
        }
        public Account GetAccountByUsername(string username)
        {
            return _accountDAO.GetAccountByUsername(username);
        }

        public Account GetAccountByAccountId(int id)
        {
            return _accountDAO.GetAccountByAccountID(id);
        }

        public List<Account> GetAccountsByRoleId(int roleId)
        {
            return _accountDAO.GetAccountsByRoleId(roleId);
        }

        public List<Account> GetAccountsByRoleIds(List<int> roleIds)
        {
            return _accountDAO.GetAccountsByRoleIds(roleIds);
        }

        public bool UpdateAccountStatus(Account account)
        {
            return _accountDAO.UpdateAccountStatus(account);
        }

        public Account GetAccountByCustomerId(int customerId)
        {
            return _accountDAO.GetAccountByCustomerId(customerId);
        }

        public List<Account> GetConsultantByRoleId(int roleId)
        {
            return _accountDAO.GetConsultantByRoleId(roleId) ;
        }

        public bool UpdateAccount(Account account)
        {
            return _accountDAO.UpdateAccount(account);
        }
    }
}
