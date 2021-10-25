using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.CLI.Enums;
using Spectre.Console;

namespace SharpBank.CLI.Views
{
    class HomePage
    {
        private readonly Menu menu;

        public HomePage(Menu menu)
        {
            this.menu = menu;
        }

        public string Prompt() {

            AnsiConsole.Write(new Rule("[red]SharpBank[/]"));
            string option = AnsiConsole.Prompt(menu.BankMenu());
            if (option == "Exit")
            {
                Environment.Exit(0);
            }
            return option;
        }

    }
}
