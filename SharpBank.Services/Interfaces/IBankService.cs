using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services.Interfaces
{
    public interface IBankService
    {
        public IEnumerable<Bank> GetBanks();
        public Bank GetBankById(Guid Id);
        public Bank GetBankByName(string bankName);
        public TransactionCharge GetTransactionChargeByName(Guid bankId, string Name);

        public TransactionCharge CreateTransactionCharge(Bank bank, decimal rtgs,decimal imps,decimal neft,string name );
        public TransactionCharge UpdateTransactionCharge(Bank bank, decimal rtgs,decimal imps,decimal neft,string name );
        public Bank Create(Bank bank);
        public Bank Update(Bank bank);
        public Bank Delete(Guid Id);
    }
}
