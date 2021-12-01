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
    [Table("Banks")]
    public class Bank
    {
        [Key]
        public Guid BankId { get; set; }
        public string Name { get; set; }

        public string Logo { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }


        public ICollection<TransactionCharge> Charges{ get; set; }

        public ICollection<Account> Accounts { get; set; }

    }
}
