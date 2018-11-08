using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.GenerateAccountNumber
{
    public class GenerateAccountNumber : INumberGenerate
    {
        public string GenerateAccountNumberId() => Guid.NewGuid().ToString();
    }
}
