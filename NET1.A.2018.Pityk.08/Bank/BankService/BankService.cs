using System;
using Bank.Account.Account_Factories;
using Bank.Account;

namespace Bank.BankService
{
    public class BankService : IBankService
    {
        public void CloseAccount(Account.Account account)
        {
            account.Status = AccountStatus.Closed;
        }

        public void Deposit(Account.Account account, decimal sum)
        {
            account.Deposit(sum);
        }

        public void OpenAccount(AccountHolder.AccountHolder holder, AccountFactory accountFactory, string generatorId)
        {
            Account.Account new_account = accountFactory.CreateNewAccount(holder, generatorId);
            holder.AddAccount(new_account);
        }

        public void FrozenAccount(Account.Account account)
        {
            if (account.Status != AccountStatus.Open)
            {
                throw new ArgumentException(nameof(account.Status), "it is impossible to frosen not open account");
            }

            account.Status = AccountStatus.Frozen;
        }

        public void UnFrozenAccount(Account.Account account)
        {
            if (account.Status != AccountStatus.Frozen)
            {
                throw new ArgumentException(nameof(account.Status), "it is impossible to unfrosen not open account");
            }

            account.Status = AccountStatus.Open;
        }

        public void Withdraw(Account.Account account, decimal sum)
        {
            account.Withdraw(sum);
        }
    }
}
