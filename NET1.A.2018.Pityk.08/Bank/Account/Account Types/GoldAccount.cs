using Bank.GenerateAccountNumber;

namespace Bank.Account.AccountType
{
    public class GoldAccount : Account
    {
        private const decimal DefaultBonus = 0.1m;

        public GoldAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus)
        {
        }

        public GoldAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal balance, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance)
        {
        }

        public GoldAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId, decimal balance, int bonusPoints, decimal bonus = 0) :
            base(holder, generatorId, bonus == 0 ? DefaultBonus : bonus, balance, bonusPoints)
        {
        }
    }
}
