using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services.Interfaces
{
    public interface ITransactionService
    {
        public IEnumerable<Transaction> GetTransactions();
        public Transaction GetTransactionById(Guid Id);

        public Models.Money RegisterMoney(Models.Money money);
        public Guid GetFundsId(Guid accountId);
        public Transaction Create(Transaction transaction);
        public Transaction Update(Transaction transaction);
        public Transaction Delete(Guid Id);
    }
}
