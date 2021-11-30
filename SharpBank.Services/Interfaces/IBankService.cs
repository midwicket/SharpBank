using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services.Interfaces
{
    interface IBankService
    {
        public IEnumerable<Bank> GetBanks();
        public Bank GetBankById(long Id);
        public Bank GetBankByName(string bankName);

        public Bank Create(Bank bank);
        public Bank Update(Bank bank);
        public void Delete(long Id);
    }
}
