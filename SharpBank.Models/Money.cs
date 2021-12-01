using Money;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{

    public class Money
    {
        [Key]
        public Guid Id { get; set; }
        public Currency Currency { get; set; }

        public decimal Amount { get; set; }

        public Guid FundsId { get; set; }

        //Tells to which funds does this money belong to [InverseProperty]
        public Funds Funds { get; set; }
    }
}
