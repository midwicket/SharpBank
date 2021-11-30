using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class TransactionCharge
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal RTGS { get; set; }
        public decimal IMPS { get; set; }
        public decimal NEFT { get; set; }
        public long BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
