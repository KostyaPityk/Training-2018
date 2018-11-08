using Bank.Account.Account_Factories;
using Bank.GenerateAccountNumber;

namespace Bank.BankService
{
    public interface IBankService
    {
        void OpenAccount(AccountHolder.AccountHolder holder, AccountFactory accountFactory, INumberGenerate generatorId);

        void CloseAccount(Account.Account accountNumber);

        void FrozenAccount(Account.Account accountNumber);

        void UnFrozenAccount(Account.Account accountNumber);

        void Deposit(Account.Account accountNumber, decimal sum);

        void Withdraw(Account.Account accountNumber, decimal sum);
    }
}
