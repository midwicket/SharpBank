using SharpBank.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharpBank.Models;

namespace SharpBank.API.Services.ImplementationDB
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext appDbContext;

        public TransactionService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Transaction Create(Transaction transaction)
        {
            appDbContext.Transactions.Add(transaction);
            appDbContext.SaveChanges();
            return appDbContext.Transactions.FirstOrDefault(t=>t.TransactionId==transaction.TransactionId);
            
        }

        public Transaction Delete(Guid Id)
        {
            Transaction transaction = appDbContext.Transactions.FirstOrDefault(t => t.TransactionId == Id);
            appDbContext.Transactions.Remove(transaction);
            appDbContext.SaveChanges();
            return transaction; 
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            //ISSUE THERE WILL COME BACK

            return appDbContext.Transactions
                .Include(t=>t.SourceAccount)
                .Include(t=>t.DestinationAccount)
                .Include(t=>t.Money)
                .ToList();
        }

        public Transaction GetTransactionById(Guid Id)
        {
            var t = appDbContext.Transactions.FirstOrDefault(t => t.TransactionId == Id);
            return t;
        }

        public Transaction Update(Transaction transaction)
        {
            appDbContext.Transactions.Attach(transaction);
            appDbContext.SaveChanges();
            return appDbContext.Transactions.FirstOrDefault(t=>t.TransactionId==transaction.TransactionId);
        }
    }
}
