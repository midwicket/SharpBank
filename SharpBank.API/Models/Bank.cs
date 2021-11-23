using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class Bank
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime updated_on { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public string logo { get; set; }
        public int transaction_charges_id { get; set; }

    }
}
