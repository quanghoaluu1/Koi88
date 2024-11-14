using Koi88_BusinessObject;

namespace Koi88_Repository;

public interface IAccountRepository
{
    public Account GetAccountByUsername(string username);
    public Account GetAccountByAccountId(int id);

    public List<Account> GetAccountsByRoleId(int roleId);
    public List<Account> GetAccountsByRoleIds(List<int> roleIds);
    public bool UpdateAccountStatus(Account account);
    public Account GetAccountByCustomerId(int customerId);
    public List<Account> GetConsultantByRoleId(int roleId);

}