using Bank.Account.AccountType;

namespace Bank.Repository
{
    public interface IRepository
    {
        void Save(Account.Account account);

        Account.Account GetAccountByNumber(string numbber);

        void Close(Account.Account account);
    }
}
