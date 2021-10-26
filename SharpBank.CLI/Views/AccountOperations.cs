using SharpBank.CLI.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class AccountOperations : IPage
    {
        private readonly Menu menu;

        public string Selection { get; set; }
        public AccountOperations(Menu menu)
        {
            this.menu = menu;
        }

        public Navigation Prompt()
        {
            UserOptions option;
            Enum.TryParse(AnsiConsole.Prompt(menu.UserMenu()).Replace(" ", ""), out option);

            switch (option)
            {
                case UserOptions.Deposit:
                    return Navigation.Deposit;
                case UserOptions.Withdraw:
                    return Navigation.Withdraw;
                case UserOptions.Transfer:
                    return Navigation.Transfer;
                case UserOptions.Balance:
                    return Navigation.Balance;
                case UserOptions.TransactionHistory:
                    return Navigation.TransactionHistory;
                case UserOptions.Back:
                    return Navigation.AuthenticationOperations;
                    break;
                case UserOptions.Exit:
                    Environment.Exit(0);
                    return Navigation.HomePage;
                default:
                    return Navigation.AccountOperations;

            }
        }
    }
}
