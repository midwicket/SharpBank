using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class Login : IPage
    {
        private readonly AccountsController accountsController;
        private readonly long bankId;

        public long AccountId { get; set; }
        public string Password { get; set; }

        public Login(AccountsController accountsController,long BankId)
        {
            this.accountsController = accountsController;
            bankId = BankId;
        }

        public string Selection { get ; set ; }

        public Navigation Prompt()
        {
            AccountId = Inputs.GetAccountId();
            string hashedPassword = accountsController.GetHashedPassword(bankId,AccountId);
            string AccountPassword = Inputs.GetPassword(hashedPassword);

            return Navigation.AuthenticationOperations;
        }
    }
}
