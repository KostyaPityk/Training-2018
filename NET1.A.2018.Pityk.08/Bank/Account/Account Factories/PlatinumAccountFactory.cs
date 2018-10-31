using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Account.Account_Factories
{
    public class PlatinumAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder.AccountHolder holder, string generatorId)
            => new AccountType.PlatinumAccount(holder, generatorId);
    }
}
