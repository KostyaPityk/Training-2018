using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using System.Text.RegularExpressions;

namespace ConsoleBankTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Regex.IsMatch("+8 (029) 370-4492", @"^\+\d \(\d{3}\) \d{3}-\d{4}$"));
            Bank.BankService.BankService service = new Bank.BankService.BankService();

            Bank.AccountHolder.AccountHolder first_holder = Bank.AccountHolder.CreateAccountHolder.CreateAccount("Kostya", "Pityk", "kostya@gmail.com", "+8 (029) 250-1234");

            Bank.AccountHolder.AccountHolder second_holder = Bank.AccountHolder.CreateAccountHolder.CreateAccount("Stas", "Ivanov", "stats@gmail.com", "+8 (029) 370-8656");

            service.OpenAccount(first_holder, new Bank.Account.Account_Factories.SilverAccountFactory(), "1");
            service.OpenAccount(first_holder, new Bank.Account.Account_Factories.GoldAccountFactory(), "2");

            IEnumerable<Bank.Account.Account> accounts = first_holder.GetAllAccount();

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
