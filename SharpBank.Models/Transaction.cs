using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public long TransactionId { get; set; }
        public long SourceBankId { get; set; }
        public long DestinationBankId { get; set; }
        public long SourceAccountId { get; set; }
        public Account SourceAccount { get; set; }
        public long DestinationAccountId { get; set; }
        public Account DestinationAccount { get; set; }
        public Money Amount { get; set; }
        public DateTime On { get; set; }
        public TransactionType Type { get; set; }

    }
}
