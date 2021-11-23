using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public int bank_id { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public string password_hash { get; set; }
    }
}
