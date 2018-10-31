using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Account.AccountType
{
    public class BaseAccount : Account
    {
        private const decimal DefaultBonus = 0.001m;

        public BaseAccount(AccountHolder.AccountHolder holder, string generatorId, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus)
        {
        }

        public BaseAccount(AccountHolder.AccountHolder holder, string generatorId, decimal balance, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance)
        {
        }

        public BaseAccount(AccountHolder.AccountHolder holder, string generatorId, decimal balance, int bonusPoints, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance, bonusPoints)
        {
        }
    }
}
