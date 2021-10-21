using Money;
using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public long SourceBankId { get; set; }
        public long DestinationBankId { get; set; }
        public long SourceAccountId { get; set; }
        public long DestinationAccountId { get; set; }
        public Money<decimal> Amount { get; set; }
        public DateTime On { get; set; }
        public TransactionType Type { get; set; }
        public override string ToString()
        {
            string res = $"  {TransactionId.ToString("D10")}  | {SourceBankId.ToString("D10")}  |   {SourceAccountId.ToString("D10")}   |   {DestinationBankId.ToString("D10")}  |  {DestinationAccountId.ToString("D10")}   | {Amount.ToString()} | {On}";
            return res;
        }
    }
}
