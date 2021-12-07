using Money;
using SharpBank.Models.Enums;

namespace SharpBank.API.DTOs.Transaction
{
    public class CreateTransactionDTO
    {
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public Currency CurrencyId { get; set; }
        public TransactionType Type { get; set; }
    }
}
