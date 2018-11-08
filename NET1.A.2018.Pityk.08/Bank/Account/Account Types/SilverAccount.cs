using Bank.GenerateAccountNumber;

namespace Bank.Account.AccountType
{
    public class SilverAccount : Account
    {
        private const decimal DefaultBonus = 0.01m;

        public SilverAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus)
        {
        }

        public SilverAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal balance, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance)
        {
        }

        public SilverAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal balance, int bonusPoints, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance, bonusPoints)
        {
        }
    }
}
