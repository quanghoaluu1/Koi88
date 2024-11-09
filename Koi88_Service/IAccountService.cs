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
    }
}
