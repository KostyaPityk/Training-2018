using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.GenerateAccountNumber;

namespace Bank.Account.Account_Factories
{
    public class BaseAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder.AccountHolder holder, INumberGenerate generatorId)
            => new AccountType.BaseAccount(holder, generatorId);
    }
}
