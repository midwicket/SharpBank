using SharpBank.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class Transfer : IPage
    {
        public string Selection { get; set; }

        public Navigation Prompt()
        {
            throw new NotImplementedException();
        }
    }
}
