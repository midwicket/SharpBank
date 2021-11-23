using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public int source_account_id { get; set; }
        public int source_bank_id { get; set; }
        public int destination_account_id { get; set; }
        public int destination_bank_id { get; set; }
        public int money_id { get; set; }


    }
}
