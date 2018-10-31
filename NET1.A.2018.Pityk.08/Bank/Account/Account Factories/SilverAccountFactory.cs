using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Account.Account_Factories
{
    public class SilverAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder.AccountHolder holder, string generatorId)
            => new AccountType.SilverAccount(holder, generatorId);
    }
}
