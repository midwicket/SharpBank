using SharpBank.Models.Enums;

namespace SharpBank.API.DTOs.Transaction
{
    public class GetTransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public Models.Money Money { get; set; }
        public DateTime On { get; set; }
        public TransactionType Type { get; set; }
    }
}
