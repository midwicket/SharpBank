using SharpBank.Models;

namespace SharpBank.API.Services.Interfaces
{
    public interface ITransactionService
    {
        public IEnumerable<Transaction> GetTransactions();
        public Transaction GetTransactionById(Guid Id);

        public Transaction Create(Transaction transaction);
        public Transaction Update(Transaction transaction);
        public Transaction Delete(Guid Id);
    }
}
