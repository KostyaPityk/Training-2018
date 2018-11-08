using Bank.GenerateAccountNumber;

namespace Bank.Account.AccountType
{
    public class PlatinumAccount : Account
    {
        private const decimal DefaultBonus = 1m;

        public PlatinumAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal bonus = 0) : 
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus)
        {
        }

        public PlatinumAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal balance, decimal bonus = 0) : 
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance)
        {
        }

        public PlatinumAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal balance, int bonusPoints, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance, bonusPoints)
        {
        }
    }
}
