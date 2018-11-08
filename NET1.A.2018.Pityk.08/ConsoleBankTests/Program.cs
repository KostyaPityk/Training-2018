using System;
using System.Collections.Generic;
using Bank.BankService;
using Bank.Repository;
using Bank.Account;
using Bank.AccountHolder;
using Bank.GenerateAccountNumber;

namespace ConsoleBankTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ListRepository repository = new ListRepository();

            BankService service = new BankService(repository);

            AccountHolder first_holder = CreateAccountHolder.CreateAccount("Kostya", "Pityk", "kostya@gmail.com", "+8 (029) 250-1234");

            AccountHolder second_holder = CreateAccountHolder.CreateAccount("Stas", "Ivanov", "stats@gmail.com", "+8 (029) 370-8656");

            service.OpenAccount(first_holder, new Bank.Account.Account_Factories.SilverAccountFactory(), new GenerateAccountNumber());
            service.OpenAccount(first_holder, new Bank.Account.Account_Factories.GoldAccountFactory(), new GenerateAccountNumber());

            IEnumerable<Account> accounts = first_holder.GetAllAccount();

            foreach (var temp in accounts)
            {
                temp.Deposit(80);
                temp.Withdraw(30);
                Console.WriteLine(temp.ToString());
            }
            
            foreach (var temp in accounts)
            {
                service.FrozenAccount(temp);
                Console.WriteLine(temp.ToString());
            }

            foreach (var temp in accounts)
            {
                service.UnFrozenAccount(temp);
                Console.WriteLine(temp.ToString());
            }

            foreach(var temp in accounts)
            {
                service.CloseAccount(temp);
                Console.WriteLine(temp.ToString());
            }

            Console.ReadKey();
        }
    }
}
