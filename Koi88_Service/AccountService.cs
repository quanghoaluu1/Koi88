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
    }
}
