using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class TransactionCharge
    {
        public decimal IntraBank { get; set; }
        public decimal InterBank { get; set; }
    }
}
