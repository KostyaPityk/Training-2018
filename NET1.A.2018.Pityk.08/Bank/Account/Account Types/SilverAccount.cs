using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Account.AccountType
{
    public class SilverAccount : Account
    {
        private const decimal DefaultBonus = 0.01m;

        public SilverAccount(AccountHolder.AccountHolder holder, string generatorId, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus)
        {
        }

        public SilverAccount(AccountHolder.AccountHolder holder, string generatorId, decimal balance, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance)
        {
        }

        public SilverAccount(AccountHolder.AccountHolder holder, string generatorId, decimal balance, int bonusPoints, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance, bonusPoints)
        {
        }
    }
}
