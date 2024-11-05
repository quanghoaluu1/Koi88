using Koi88_BusinessObject;

namespace Koi88_Repository;

public interface IAccountRepository
{
    public Account GetAccountByUsername(string username);
    public Account GetAccountByAccountID(int id);

}