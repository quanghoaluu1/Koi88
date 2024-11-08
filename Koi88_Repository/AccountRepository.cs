﻿using System;
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
            _accountDAO = new AccountDAO();
        }
        public Account GetAccountByUsername(string username)
        {
            return _accountDAO.Instance.GetAccountByUsername(username);
        }

        public Account GetAccountByAccountID(int id)
        {
            return _accountDAO.Instance.GetAccountByAccountID(id);
        }
    }
}
