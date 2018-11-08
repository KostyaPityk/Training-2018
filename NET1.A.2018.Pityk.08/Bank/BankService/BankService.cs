using System;
using Bank.Account.Account_Factories;
using Bank.Account.AccountType;
using Bank.Repository;
using Bank.GenerateAccountNumber;

namespace Bank.BankService
{
    public class BankService : IBankService
    {
        private IRepository _repository;

        public IRepository Repository
        {
            get => _repository;
            set => _repository = value ?? throw new ArgumentException(nameof(value), "can't be equal to null!");
        }

        public BankService(IRepository repository)
        {
            Repository = repository;
        }
        public void CloseAccount(Account.Account account)
        {
            account.Status = AccountStatus.Closed;
            Repository.Close(account);
        }

        public void Deposit(Account.Account account, decimal sum)
        {
            account.Deposit(sum);
        }

        public void OpenAccount(AccountHolder.AccountHolder holder, AccountFactory accountFactory, INumberGenerate generatorId)
        {
            Account.Account new_account = accountFactory.CreateNewAccount(holder, generatorId);
            holder.AddAccount(new_account);
            Repository.Save(new_account);
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
