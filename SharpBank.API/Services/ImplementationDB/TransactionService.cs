using SharpBank.API.Services.Interfaces;
using SharpBank.Models;

namespace SharpBank.API.Services.ImplementationDB
{
    public class TransactionService : ITransactionService
    {
        public Transaction Create(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionsById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Transaction Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
