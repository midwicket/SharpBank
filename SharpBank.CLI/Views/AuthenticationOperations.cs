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
    class AuthenticationOperations : IPage
    {
        private readonly BanksController banksController;
        private readonly long bankId;
        private readonly Menu menu;

        public AuthenticationOperations(BanksController banksController,long BankId, Menu menu)
        {
            this.banksController = banksController;
            this.bankId = BankId;
            this.menu = menu;
        }

        public string Selection { get; set ; }

        public Navigation Prompt()
        {
            AnsiConsole.Write(new Rule("[red]" + banksController.GetBank(bankId) + "[/] Services"));

            LoginOptions option;

            Enum.TryParse(AnsiConsole.Prompt(menu.LoginMenu()).Split()[0], out option);

            switch (option)
            {
                case LoginOptions.Create:
                    return Navigation.CreateAccount;
                case LoginOptions.Login:
                    return Navigation.Login;
                case LoginOptions.Back:
                    return Navigation.HomePage;
                case LoginOptions.Exit:
                    Environment.Exit(0);
           
                    break;
            }
            return Navigation.HomePage;
        }
    }
}
