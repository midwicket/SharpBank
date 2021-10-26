using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class CreateAccount : IPage
    {
        private readonly AccountsController accountsController;
        private readonly long bankId;

        public string Selection { get ; set; }
        public long AccountId { get; set; }
        public string Password { get; set; }

        public CreateAccount(AccountsController accountsController, long BankId)
        {
            this.accountsController = accountsController;
            bankId = BankId;
        }

        public Navigation Prompt()
        {
            AccountId = accountsController.CreateAccount(bankId);
            AnsiConsole.WriteLine("Your account number is " + AccountId.ToString("D10") + " Dont forget it .");
            return Navigation.AuthenticationOperations;
        }
    }
}
