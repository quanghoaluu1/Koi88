using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class AccountService: IAccountService
    {
        private IAccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }
        public Account GetAccountByUsername(string username)
        {
            return _accountRepository.GetAccountByUsername(username);
        }

        public Account GetAccountByAccountId(int id)
        {
            return _accountRepository.GetAccountByAccountId(id);
        }

        public List<Account> GetAccountsByRoleId(int roleId)
        {
            return _accountRepository.GetAccountsByRoleId(roleId);
        }

        public List<Account> GetAccountsByRoleIds(List<int> roleIds)
        {
            return _accountRepository.GetAccountsByRoleIds(roleIds);
        }

        public Account GetAccountByCustomerId(int customerId)
        {
            return _accountRepository.GetAccountByCustomerId(customerId);
        }

        public bool UpdateAccountStatus(Account account)
        {
           return _accountRepository.UpdateAccountStatus(account);
        }

        public List<Account> GetConsultantByRoleId(int roleId)
        {
            return _accountRepository.GetConsultantByRoleId(roleId) ;
        }
    }
}
