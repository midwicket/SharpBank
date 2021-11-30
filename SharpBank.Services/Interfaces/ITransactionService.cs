using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services.Interfaces
{
    interface ITransactionService
    {
        public IEnumerable<Transaction> GetTransactions();
        public Transaction GetTransactionsById(long Id);

        public Transaction Create(Transaction transaction);
        public Transaction Update(Transaction transaction);
        public Transaction Delete(long Id);
    }
}
