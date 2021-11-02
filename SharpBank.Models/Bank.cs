using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class Bank
    {
        public long BankId { get; set; }
        public string Name { get; set; }

        public string Logo { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }


        public TransactionCharge IMPS { get; set; }
        public TransactionCharge RTGS { get; set; }
        public TransactionCharge NEFT { get; set; }


        public TransactionCharge GetTransactionCharge(TransactionType transactionType) => transactionType switch
        {
            TransactionType.RTGS => this.RTGS,
            TransactionType.IMPS => this.IMPS,
            TransactionType.NEFT => this.NEFT,
            _ => new TransactionCharge { InterBank=0m,IntraBank=0m }
        };

        public ICollection<Account> Accounts { get; set; }

    }
}
