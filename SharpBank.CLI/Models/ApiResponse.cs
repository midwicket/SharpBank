using Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Models
{
    class ApiResponse
    {
        public string Disclaimer { get; set; }
        public long Timestamp { get; set; }
        public string Base { get; set; }
        public IDictionary<string,decimal> Rates { get; set; }
    }
}
